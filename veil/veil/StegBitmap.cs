using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace veil
{
    class StegBitmap : StegBase
    {

        #region GlobalVariables
        private const int HEADER_SIZE = 20; // size of the hidden header
        private Bitmap bmp; // image to hide and extract files from
        #endregion

        #region Constructors
        public StegBitmap(string filename)
        {
            bmp = new Bitmap(filename);
        }
        #endregion

        #region ReadWrite
        public override bool extractEncodedFile(string filepath)
        {
            // update the filepath to ensure it is exists
            filepath = correctFilePath(filepath);

            // lock the bits in the bitmap for more efficient access than GetPixel/SetPixel
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            // get the address of the first line
            IntPtr ptr = bmpData.Scan0;

            // initialize an array to hold all of the data 
            int byteNum = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[byteNum];

            // copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, byteNum);

            // read the header bytes
            byte[] header = new byte[HEADER_SIZE];
            byte[] MASK = { 1, 2, 4, 8, 16, 32, 64, 128 };
            for (int i = 0; i < HEADER_SIZE; i++)
            {
                // get one byte of data utilizing the mask
                for (int j = 0; j < 8; j++)
                {
                    // if the byte is odd then the respective bit is set to 1
                    if (isByteOdd(rgbValues[8 * i + j])) header[i] |= MASK[j];
                }
            }

            // hidden file data length
            byte[] dataLenArray = new byte[sizeof(int)];
            Array.Copy(header, 0, dataLenArray, 0, sizeof(int));
            int dataLength = byteArrayToInteger(dataLenArray);
            if (dataLength < 0)
            {
                // unlock the bits.
                bmp.UnlockBits(bmpData);
                return false;
            }

            // extension of the hidden file
            byte[] fileTypeArray = new byte[HEADER_SIZE - sizeof(int)];
            Array.Copy(header, sizeof(int), fileTypeArray, 0, HEADER_SIZE - sizeof(int));

            // delete the null bytes that might exist in the file type array
            var list = new List<byte>();
            for (int i = 0; i < fileTypeArray.Length; i++)
            {
                if (fileTypeArray[i] != 0) list.Add(fileTypeArray[i]);
            }
            fileTypeArray = new byte[list.Count];

            // convert the list into an ascii string
            fileTypeArray = list.ToArray();
            string fileType = System.Text.Encoding.ASCII.GetString(fileTypeArray);

            // if the extension is not valid then there is most likely not a file hidden in the image
            if (!isValidFileExtension(fileType))
            {
                // unlock the bits.
                bmp.UnlockBits(bmpData);
                return false;
            }

            // read the encoded file data
            byte[] data = new byte[dataLength];
            for (int i = HEADER_SIZE; i < dataLength + HEADER_SIZE; i++)
            {
                // get one byte of data utilizing the mask
                for (int j = 0; j < 8; j++)
                {
                    // if the byte is odd then the respective bit is set to 1
                    if (isByteOdd(rgbValues[8 * i + j])) data[i - HEADER_SIZE] |= MASK[j];
                }
            }

            // copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, byteNum);

            // unlock the bits.
            bmp.UnlockBits(bmpData);

            // write the bytes to the given file
            string filename = filepath + @"\HiddenFile" + fileType;
            File.WriteAllBytes(filename, data);
            return true;
        }

        public override bool createEncodedFile(string filenameHide, string filenameOutput)
        {
            // check if the hidden file will fit into the image
            if (!canFitFile(filenameHide))
            {
                MessageBox.Show("The file selected to embed is too large for this image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // open the hidden image file stream
            using (FileStream hideStream = new FileStream(filenameHide, FileMode.Open, FileAccess.Read))
            {

                // read the hidden file into a byte array. 
                byte[] bytesHide = new byte[hideStream.Length];
                int numBytesToRead = (int)hideStream.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    // read may return anything from 0 to numBytesToRead. 
                    int n = hideStream.Read(bytesHide, numBytesRead, numBytesToRead);

                    // break when the end of the file is reached. 
                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }

                // add the file info to the bytes array
                /* Bytes Format
                Hidden Data Length - 4 bytes
                File Extension - 16 bytes (null padded)
                Data - X bytes
                 */
                byte[] byteLen = integerToByteArray(bytesHide.Length);

                // get the extension and convert to ascii bytes
                string extension = Path.GetExtension(filenameHide);
                if (string.IsNullOrEmpty(extension)) throw new ArgumentException("Failed to find the extension for file:  " + filenameHide);
                byte[] extAscii = System.Text.Encoding.ASCII.GetBytes(extension);

                // combine all three arrays [data length, extension, data]
                var list = new List<byte>();
                list.AddRange(byteLen);
                list.AddRange(extAscii);

                // null pad the header to a length of HEADER_SIZE
                while (list.Count < HEADER_SIZE) list.Add(0);

                // ensure the header hasn't exceeded the set size
                if (list.Count > HEADER_SIZE) throw new ArgumentException("Failed to convert file extension to byte array");
                list.AddRange(bytesHide);
                bytesHide = new byte[list.Count];
                bytesHide = list.ToArray();

                // lock the bitmap's bits.  
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

                // get the address of the first line.
                IntPtr ptr = bmpData.Scan0;

                // declare an array to hold the bytes of the bitmap. 
                int byteNum = Math.Abs(bmpData.Stride) * bmp.Height;

                byte[] rgbValues = new byte[byteNum];

                // copy the RGB values into the array.
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, byteNum);

                int i = 0;
                // get each byte in the file to be hidden
                foreach (byte b in bytesHide)
                {
                    bool bit = false;
                    for (int j = 0; j < 8; j++)
                    {
                        // for each bit find if it is set to one
                        bit = (b & (1 << j)) != 0;
                        // if the color byte is odd and the bit is zero, make the color pixel even or if the opposite is true
                        if ((isByteOdd(rgbValues[8 * i + j]) && !bit) || (!isByteOdd(rgbValues[8 * i + j]) && bit))
                        {
                            if (rgbValues[8 * i + j] < 255)
                            {
                                rgbValues[8 * i + j]++;
                            }
                            //We don't want to loop 255 into 0 since the color will be noticeable so decrement instead
                            else
                            {
                                rgbValues[8 * i + j]--;
                            }
                        } // else: the color pixel is already set correctly

                    }
                    i++;
                }

                // copy the RGB values back to the bitmap
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, byteNum);

                // unlock the bits.
                bmp.UnlockBits(bmpData);

                // save the image
                saveImage(filenameOutput);
                return true;
            }
        }
        #endregion

        public override void Dispose()
        {
            bmp.Dispose();
        }


        public override long getNumBytes()
        {
            // return the number of bytes that can contain hidden information
            return (bmp.Size.Width * bmp.Size.Height * (Image.GetPixelFormatSize(bmp.PixelFormat) / 8));
        }

        public override long maxHiddenFileSize()
        {
            // return the largest file size you can embed
            return (getNumBytes() - HEADER_SIZE) / 8;
        }

        private void saveImage(string filename)
        {
            // save the image with quality level 100
            ImageFormat fileFormat = filenameToImageFormat(filename);
            ImageCodecInfo codecInfo = getImageCodecInfo(fileFormat);

            // set the quality parameter to 100
            Encoder enc = Encoder.Quality;
            EncoderParameters encPars = new EncoderParameters(1);
            encPars.Param[0] = new EncoderParameter(enc, 100L);

            bmp.Save(filename, codecInfo, encPars);
        }

        private ImageCodecInfo getImageCodecInfo(ImageFormat format)
        {
            // find the correct id in the list of encoders and return it
            return ImageCodecInfo.GetImageEncoders().ToList().Find(delegate(ImageCodecInfo codec)
            {
                return codec.FormatID == format.Guid;
            });
        }

        private ImageFormat filenameToImageFormat(string filename)
        {
            // convert a filename with path to an image format
            string extension = Path.GetExtension(filename);
            if (string.IsNullOrEmpty(extension)) throw new ArgumentException("Failed to find the extension for file:  " + filename);

            // only lossless image formats are supported
            switch (extension.ToLower())
            {
                case ".bmp":
                    return ImageFormat.Bmp;

                case ".png":
                    return ImageFormat.Png;

                case ".tif":
                case ".tiff":
                    return ImageFormat.Tiff;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
