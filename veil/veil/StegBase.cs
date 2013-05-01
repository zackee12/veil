
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace veil
{
    abstract class StegBase:IDisposable
    {

        #region MustInherit
        // try to get the encoded file and return whether the function was successful or not
        abstract public bool extractEncodedFile(string filepath);

        // create the encoded file with the given filename embedded inside
        abstract public bool createEncodedFile(string filenameHide, string filenameOutput);

        // get the total number of bytes that the object has available for storing data
        abstract public long getNumBytes();

        // get the maximum size that can be stored in teh object
        abstract public long maxHiddenFileSize();

        public virtual void Dispose()
        {
            // do nothing   
        }
        #endregion

        #region Conversions
        protected byte[] integerToByteArray(int val)
        {
            // convert integer to a byte array
            byte[] intBytes = BitConverter.GetBytes(val);
            if (BitConverter.IsLittleEndian) Array.Reverse(intBytes);
            return intBytes;
        }

        protected int byteArrayToInteger(byte[] b)
        {
            // convert byte array to an integer
            if (b.Length != sizeof(int)) throw new ArgumentException(String.Format("The byte array size was not correct for type integer.  Passed {0} bytes", b.Length));
            if (BitConverter.IsLittleEndian) Array.Reverse(b);
            return BitConverter.ToInt32(b, 0);
        }
        #endregion

        #region Validations
        public bool canFitFile(string filename)
        {
            // determine if the selected file can be hidden in the image
            if (!File.Exists(filename)) return false;
            FileInfo fi = new FileInfo(filename);
            if (fi.Length > maxHiddenFileSize()) return false;
            return true;
        }

        protected bool isByteOdd(byte b)
        {
            // check if the byte is odd
            if (b % 2 == 1) return true;
            return false;
        }

        protected bool isValidFileExtension(string ext)
        {
            // if the extension contains an invalid character return false
            string invalidFileNameChars = new string(System.IO.Path.GetInvalidFileNameChars());
            Regex reg = new Regex("[" + Regex.Escape(invalidFileNameChars) + "]");
            if (reg.IsMatch(ext)) return false;
            // if the first character is not a period it is invalid
            if (!ext.Substring(0, 1).Equals(".")) return false;
            return true;
        }

        protected string correctFilePath(string filepath)
        {
            // if the supplied directory doesn't work then use the current directory
            if (!Directory.Exists(filepath))
            {
                MessageBox.Show(String.Format("The directory <{0}> doesn't exist.  The current directory <{1}> will be used", filepath, Directory.GetCurrentDirectory()), "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                filepath = Directory.GetCurrentDirectory();
            }

            // if the path ends in a slash remove it to prevent duplicate slashes
            if (filepath.Substring(filepath.Length - 1).Equals(@"\") || filepath.Substring(filepath.Length - 1).Equals(@"/")) filepath = filepath.Substring(0, filepath.Length - 1);
            return filepath;
        }
        #endregion

    }
}
