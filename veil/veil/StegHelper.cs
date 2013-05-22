using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace veil
{
    class StegHelper
    {

        public StegHelper()
        { 
        }

        public long MaxConcealSize(List<string> filenames)
        {
            // validate input
            foreach (string file in filenames) if (!File.Exists(file)) throw new ArgumentException(file + " does not exist");
            long count = 0;

            foreach (string file in filenames)
            {
                StegBase sb = GetStegObject(file);
                count += sb.maxHiddenFileSize();
                sb.Dispose();
            }
            return count;
        }
        public void Decoding(List<string> filenames, string outputPath, bool isEncrypted, string password, ByteEncryption.SymmetricAlgorithmType alg)
        {
            // validate input
            foreach (string file in filenames) if (!File.Exists(file)) throw new ArgumentException(file + " does not exist");
            if (!Directory.Exists(outputPath)) throw new ArgumentException(outputPath + " does not exist");

            List<byte> outBytes = new List<byte>();
            string fileType = "";

            for (int i = 0; i < filenames.Count; i++)
            {
                // object to retrieve info
                StegBase sb = GetStegObject(filenames[i]);

                // [extension (16 bytes)] [data]
                List<byte> readBytes = new List<byte>(sb.DecodeBytes());

                if (isEncrypted)
                {
                    ByteEncryption be = new ByteEncryption();
                    byte[] temp = be.Decrypt(alg, password, readBytes.ToArray());
                    readBytes.Clear();
                    readBytes = new List<byte>(temp);
                }


                byte[] fileTypeByte = readBytes.GetRange(0, 16).ToArray();

                // delete the null bytes that might exist in the file type array
                var list = new List<byte>();
                for (int j = 0; j < fileTypeByte.Length; j++)
                {
                    if (fileTypeByte[j] != 0) list.Add(fileTypeByte[j]);
                }
                fileTypeByte = new byte[list.Count];

                // convert the list into an ascii string
                fileTypeByte = list.ToArray();
                fileType = System.Text.Encoding.ASCII.GetString(fileTypeByte);
                // if the extension is not valid then there is most likely not a file hidden in the image
                if (!StegBase.isValidFileExtension(fileType)) throw new InvalidDataException("If data has been stored in this file, it has been corrupted and cannot be recovered");
                outBytes.AddRange(readBytes.GetRange(16,readBytes.Count - 16));
                sb.Dispose();
            }

            // write the bytes to the given file
            string filename = outputPath + @"\HiddenFile" + fileType;
            File.WriteAllBytes(filename, outBytes.ToArray());

        }

        public void Encoding(List<string> filenames, string concealFile, string outputPath, bool isEncrypted, string password, ByteEncryption.SymmetricAlgorithmType alg)
        {
            // validate input
            foreach (string file in filenames) if (!File.Exists(file)) throw new ArgumentException(file + " does not exist");
            if (!File.Exists(concealFile)) throw new ArgumentException(concealFile + " does not exist");
            if (!Directory.Exists(outputPath)) throw new ArgumentException(outputPath + " does not exist");

            // size of the concealed file
            long concealSize = 0;
            FileInfo fi = new FileInfo(concealFile);
            concealSize = fi.Length;

            // amount of information each file can hold
            var fileStegCapacity = new List<long>();
            foreach (string filename in filenames) fileStegCapacity.Add(GetMaximumHiddenSize(filename));

            // count the total size
            long totalSizeCapacity = 0;
            foreach (long i in fileStegCapacity) totalSizeCapacity += i;

            // determine if the file can be hidden inside of the listed file
            if (concealSize > totalSizeCapacity) throw new ArgumentException("The concealed file will not fit in the given files");

            // get the amount of bytes to store in each file
            var fileStegUsage = new List<long>();
            long remainConcealSize = concealSize;
            for(int i = 0; i < fileStegCapacity.Count; i++)
            {
                if (i != fileStegCapacity.Count - 1)
                {
                    // use the % of total capacity to assign an amount of bytes to hide in the file
                    long val = concealSize * (fileStegCapacity[i] / totalSizeCapacity);
                    remainConcealSize -= val;
                    fileStegUsage.Add(val);
                }
                // because of rounding add the remaining bytes to the last file
                else fileStegUsage.Add(remainConcealSize);
            }

            if (concealSize != fileStegUsage.Sum()) throw new InvalidDataException("Concealed byte sizes are not equivalent");

            // get the concealed files bytes
            byte[] concealBytes = GetFileBytes(concealFile);

            // write the concealed bytes to each object
            for (int i = 0; i < filenames.Count; i++)
            {
                // object to hide info
                StegBase sb = GetStegObject(filenames[i]);

                // get the starting index for the conceal byte array
                long startIndex = 0;
                for(int j = 0; j < i; j++) startIndex += fileStegUsage[j];

                // setup the header
                // [(int) size of bytes hidden] [(16 bytes) extension of hidden file]
                byte[] write;
                byte[] byteLen = StegBase.integerToByteArray((int)fileStegUsage[i] + 16);
                string extension = Path.GetExtension(concealFile);
                if (string.IsNullOrEmpty(extension)) throw new ArgumentException("Failed to find the extension for file:  " + filenames[i]);
                byte[] extAscii = System.Text.Encoding.ASCII.GetBytes(extension);

                // combine all three arrays [data length, extension, data]
                var list = new List<byte>();
                list.AddRange(byteLen);
                list.AddRange(extAscii);

                // null pad the header to the HEADER_SIZE
                while (list.Count < StegBase.HEADER_SIZE) list.Add(0);

                // ensure the header hasn't exceeded the set size
                if (list.Count > StegBase.HEADER_SIZE) throw new ArgumentException("Failed to convert file extension to byte array");

                // get the full plaintext array to write
                list.AddRange(GetRangeOfByteArray(concealBytes, (int)startIndex, (int)(startIndex + fileStegUsage[i])));

                // encrypt the plaintext if a password is provided
                if (isEncrypted)
                {
                    ByteEncryption be = new ByteEncryption();
                    // don't need to duplicate the size data
                    list.RemoveRange(0, sizeof(int));
                    write = be.Encrypt(alg, password, list.ToArray());
                    byteLen = StegBase.integerToByteArray(write.Length);
                    list.Clear();
                    list.AddRange(byteLen);
                    list.AddRange(write);
                }
                write = list.ToArray();

                // create the output path
                outputPath = StegBase.correctFilePath(outputPath);
                string ext = Path.GetExtension(filenames[i]);
                if (string.IsNullOrEmpty(ext)) throw new ArgumentException("Failed to find the extension for file:  " + filenames[i]);
                string finOutputPath = outputPath + @"\veil" + i + ext;

                // hide the bytes inside the file
                sb.EncodeBytes(write, finOutputPath);

                // clean up the object
                sb.Dispose();
            }
        }


        public byte[] GetRangeOfByteArray(byte[] array, int start, int finish)
        {
            byte[] subset = new byte[finish - start];
            Array.Copy(array, start, subset, 0, finish - start);
            return subset;
        }

        public byte[] GetFileBytes(string filename)
        {
             // open the hidden image file stream
            using (FileStream hideStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
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
                return bytesHide;
            }
        }

        public StegBase GetStegObject(string filename)
        {
            // if the file steg has been implemented then return the object
            string ext = Path.GetExtension(filename);
            if (string.IsNullOrEmpty(ext)) throw new ArgumentException("Failed to find the extension for file:  " + filename);
            switch (ext)
            {
                // case ".bmp":
                case ".png":
                case ".tif":
                case ".tiff":
                    return new StegBitmap(filename);
                default:
                    throw new NotImplementedException(ext + " is not currently capable of storing information");
            }
        }

        public long GetMaximumHiddenSize(string filename)
        {
            return GetStegObject(filename).maxHiddenFileSize();
        }
    }
}
