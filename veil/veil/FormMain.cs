using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veil
{
    public partial class FormMain : Form
    {

        #region GlobalVariables
            StegBase stegImage;
        #endregion

        #region Contructors
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region FormEvents
        private void FormMain_Load(object sender, EventArgs e)
        {
            // set the default path to store any created files
            textBoxDecodeOut.Text = Directory.GetCurrentDirectory();
            buttonDecode.Enabled = false;
            buttonEncode.Enabled = false;
            toolStripStatusLabelFileSize.Text = " ";
        }
        #endregion

        #region ButtonEvents
        private void buttonBrowseDecodeIn_Click(object sender, EventArgs e)
        {
            // only lossless image formats
            textBoxDecodeIn.Text = openFile("Image File (*.bmp, *.png, *.tif)|*.bmp;*.png;*.tif", Directory.GetCurrentDirectory());
        }

        private void buttonBrowseDecodeOut_Click(object sender, EventArgs e)
        {
            // open a folder browser
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            // get the path to store the output file
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxDecodeOut.Text = fbd.SelectedPath;

            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            // try to read an encoded file
            stegImage = new StegBitmap(textBoxDecodeIn.Text);
            if (!stegImage.extractEncodedFile(textBoxDecodeOut.Text))
            {
                MessageBox.Show("Error decoding file");
            }
            else
            {
                Process.Start(textBoxDecodeOut.Text);
            }

            stegImage.Dispose();
            textBoxDecodeIn.Text = "";
            textBoxDecodePass.Text = "";
            toolStripStatusLabelFileSize.Text = " ";
        }

        private void buttonBrowseEncodeIn_Click(object sender, EventArgs e)
        {
            // set the path to read in a cover image
            textBoxEncodeIn.Text = openFile(getImageFileFilter(), Directory.GetCurrentDirectory());
            if (textBoxEncodeIn.Text.Length > 0) stegImage = new StegBitmap(textBoxEncodeIn.Text);
            setFileSizeStatusLabelText();

        }

        private void buttonBrowseEncodeEmbed_Click(object sender, EventArgs e)
        {
            // set the path to read in a file to hide
            textBoxEncodeEmbed.Text = openFile("All Files (*.*)|*.*", Directory.GetCurrentDirectory());
            setFileSizeStatusLabelText();
        }

        private void buttonBrowseEncodeOut_Click(object sender, EventArgs e)
        {
            // set the path to write out the lossless image 
            textBoxEncodeOut.Text = saveFile("Image File (*.bmp, *.png, *.tif)|*.bmp;*.png;*.tif", Directory.GetCurrentDirectory());
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            // try to read the image

            if (stegImage.createEncodedFile(textBoxEncodeEmbed.Text, textBoxEncodeOut.Text))
            {
                Process.Start(Path.GetDirectoryName(textBoxEncodeOut.Text));
            }


            stegImage.Dispose();
            textBoxEncodeEmbed.Text = "";
            textBoxEncodeIn.Text = "";
            textBoxEncodeOut.Text = "";
            textBoxEncodePass.Text = "";
            toolStripStatusLabelFileSize.Text = " ";
        }
        #endregion

        #region TextboxEvents
        private void validateDecodeButton(object sender, EventArgs e)
        {
            // determine if the pushbutton can be clicked
            if (textBoxDecodeOut.Text.Length > 0 && textBoxDecodePass.Text.Length > 0 && textBoxDecodeIn.Text.Length > 0) buttonDecode.Enabled = true;
            else buttonDecode.Enabled = false;
        }

        private void validateEncodeButton(object sender, EventArgs e)
        {
            // determine if the pushbutton can be clicked
            if (textBoxEncodeOut.Text.Length > 0 && textBoxEncodePass.Text.Length > 0 && textBoxEncodeEmbed.Text.Length > 0 && textBoxEncodeIn.Text.Length > 0) buttonEncode.Enabled = true;
            else buttonEncode.Enabled = false;
        }
        #endregion

        #region FileDialogs
        private string openFile(string filter, string directory)
        {
            // open a file dialog asking for an input
            OpenFileDialog ofd = new OpenFileDialog();

            // ofd settings
            ofd.Filter = filter;
            ofd.InitialDirectory = directory;
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            ofd.CheckFileExists = true;

            // return the path
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return "";
        }

        private string saveFile(string filter, string directory)
        {
            // open a file dialog asking for an  input
            SaveFileDialog sfd = new SaveFileDialog();

            // sfd settings
            sfd.Filter = filter;
            sfd.InitialDirectory = directory;
            sfd.RestoreDirectory = true;

            // get the image filename, store it in the text box, and display it in the picturebox
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                return sfd.FileName;
            }
            return "";
        }
        #endregion

        #region Formatting
        private string getImageFileFilter()
        {
            // set up the filter with all image codecs
            string filter = "";
            System.Drawing.Imaging.ImageCodecInfo[] codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            String sep = String.Empty;
            int filterCnt = 0;
            foreach (System.Drawing.Imaging.ImageCodecInfo c in codecs)
            {
                String codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                filter = String.Format("{0}{1}{2} ({3})|{3}", filter, sep, codecName, c.FilenameExtension);
                sep = "|";
                filterCnt++;
            }
            filter = String.Format("{0}{1}{2} ({3})|{3}", filter, sep, "All Files", "*.*");
            return filter;
        }

        private void setFileSizeStatusLabelText()
        {
            string maxSize = @"N/A";
            string embSize = @"N/A";
            if (stegImage != null) maxSize = String.Format("{0:0.000}", (stegImage.maxHiddenFileSize() / 1024.0));
            if (textBoxEncodeEmbed.Text.Length > 0 && File.Exists(textBoxEncodeEmbed.Text))
            {
                FileInfo fi = new FileInfo(textBoxEncodeEmbed.Text);
                embSize = String.Format("{0:0.000}", (fi.Length / 1024.0));
            }
            toolStripStatusLabelFileSize.Text = String.Format("Max Embedded Size:  {0} kb  |  Embedded Size:  {1} kb", maxSize, embSize);
        }
        #endregion

    }
}
