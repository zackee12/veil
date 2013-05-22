using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;


/*
 * Hidden info format
 * [Data size] sizeof(int)
 * [Data]
 */


namespace veil
{
    class StegBitmap : StegBase
    {

        #region GlobalVariables
        
        private Bitmap bmp; // image to hide and extract files from
        #endregion

        #region Constructors
        public StegBitmap(string filename)
        {
            bmp = new Bitmap(filename);
        }
        #endregion

        #region ReadWrite

        public override byte[] DecodeBytes()
        {
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
            byte[] header = new byte[sizeof(int)];
            byte[] MASK = { 1, 2, 4, 8, 16, 32, 64, 128 };
            for (int i = 0; i < sizeof(int); i++)
            {
                // get one byte of data utilizing the mask
                for (int j = 0; j < 8; j++)
                {
                    // if the byte is odd then the respective bit is set to 1
                    if (isByteOdd(rgbValues[8 * i + j])) header[i] |= MASK[j];
                }
            }

            // hidden file data length
            int dataLength = byteArrayToInteger(header);
            if (dataLength < 0)
            {
                // unlock the bits.
                bmp.UnlockBits(bmpData);
                throw new InvalidDataException("Invalid header read.  If data is hidden, it is not recoverable");
            }

            // read the encoded file data
            byte[] data = new byte[dataLength];
            for (int i = sizeof(int); i < dataLength + sizeof(int); i++)
            {
                // get one byte of data utilizing the mask
                for (int j = 0; j < 8; j++)
                {
                    // if the byte is odd then the respective bit is set to 1
                    if (isByteOdd(rgbValues[8 * i + j])) data[i - sizeof(int)] |= MASK[j];
                }
            }

            // copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, byteNum);

            // unlock the bits.
            bmp.UnlockBits(bmpData);

            return data;
        }

        public override void EncodeBytes(byte[] hiddenBytes, string filenameOutput)
        {
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
            foreach (byte b in hiddenBytes)
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
        }

        
        #endregion

        public override void Dispose()
        {
            // release image
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
            // Encoder enc = Encoder.Quality;
            // EncoderParameters encPars = new EncoderParameters(1);
            // encPars.Param[0] = new EncoderParameter(enc, 100L);

            // bmp.Save(filename, codecInfo, encPars);
            // encPars.Dispose();
            bmp.Save(filename,filenameToImageFormat(filename));
        }

        private static ImageCodecInfo getImageCodecInfo(ImageFormat format)
        {
            // find the correct id in the list of encoders and return it
            return ImageCodecInfo.GetImageEncoders().ToList().Find(delegate(ImageCodecInfo codec)
            {
                return codec.FormatID == format.Guid;
            });
        }

        private static ImageFormat filenameToImageFormat(string filename)
        {
            // convert a filename with path to an image format
            string extension = Path.GetExtension(filename);
            if (string.IsNullOrEmpty(extension)) throw new ArgumentException("Failed to find the extension for file:  " + filename);

            // only lossless image formats are supported
            switch (extension.ToLower())
            {
                // case ".bmp":
                //    return ImageFormat.Bmp;

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
