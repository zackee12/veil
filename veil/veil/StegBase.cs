/*
Copyright (c) 2013 "Zachary Graber"

This file is part of veil.

Veil is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

/* 
 * File Format [not encrypted]
 * 4 bytes - remaining data size
 * 16 bytes - file extension (null padded)
 * x bytes - data
 * 
 * File Format [encrypted]
 * 4 bytes - remaining data size
 * 16 bytes - key validation encryption
 * 16 bytes - crypto salt
 * 16 bytes - crypto iv
 * x bytes - encrypted data
 */

namespace veil
{
    abstract class StegBase:IDisposable
    {
        public const int HEADER_SIZE = 20; // size of the file information header

        #region MustInherit

        // write bytes into the file
        abstract public void EncodeBytes(byte[] hiddenBytes, string filenameOutput);

        // read bytes from the file
        abstract public byte[] DecodeBytes();

        // get the total number of bytes that the object has available for storing data
        abstract public long getNumBytes();

        // get the maximum size that can be stored in teh object
        abstract public long maxHiddenFileSize();

        // do nothing this should be override
        public virtual void Dispose(){}
        #endregion

        #region Conversions
        public static byte[] integerToByteArray(int val)
        {
            // convert integer to a byte array
            byte[] intBytes = BitConverter.GetBytes(val);
            if (BitConverter.IsLittleEndian) Array.Reverse(intBytes);
            return intBytes;
        }

        public static int byteArrayToInteger(byte[] b)
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

        protected static bool isByteOdd(byte b)
        {
            // check if the byte is odd
            if (b % 2 == 1) return true;
            return false;
        }

        public static bool isValidFileExtension(string ext)
        {
            // if the extension contains an invalid character return false
            string invalidFileNameChars = new string(System.IO.Path.GetInvalidFileNameChars());
            Regex reg = new Regex("[" + Regex.Escape(invalidFileNameChars) + "]");
            if (reg.IsMatch(ext)) return false;
            // if the first character is not a period it is invalid
            if (!ext.Substring(0, 1).Equals(".")) return false;
            return true;
        }

        public static string correctFilePath(string filepath)
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
