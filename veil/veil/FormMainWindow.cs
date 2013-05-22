using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace veil
{
    public partial class FormMainWindow : Form
    {
        public FormMainWindow()
        {
            InitializeComponent();
        }

        #region ControlEvents

        #region Buttons
        private void buttonGo_Click(object sender, EventArgs e)
        {
            ByteEncryption.SymmetricAlgorithmType alg = new ByteEncryption.SymmetricAlgorithmType();
            if (radioButtonAES.Checked == true) alg = ByteEncryption.SymmetricAlgorithmType.AES;
            else if (radioButtonBlowfish.Checked == true) alg = ByteEncryption.SymmetricAlgorithmType.Blowfish;
            else if (radioButtonDES.Checked == true) alg = ByteEncryption.SymmetricAlgorithmType.DES;
            else if (radioButtonMars.Checked == true) alg = ByteEncryption.SymmetricAlgorithmType.Mars;
            else if (radioButtonRC2.Checked == true) alg = ByteEncryption.SymmetricAlgorithmType.RC2;
            else if (radioButtonRijndael.Checked == true) alg = ByteEncryption.SymmetricAlgorithmType.Rijndael;
            else if (radioButtonSerpent.Checked == true) alg = ByteEncryption.SymmetricAlgorithmType.Serpent;
            else if (radioButtonTripleDES.Checked == true) alg = ByteEncryption.SymmetricAlgorithmType.TripleDES;
            else if (radioButtonTwofish.Checked == true) alg = ByteEncryption.SymmetricAlgorithmType.Twofish;
            // encoding mode
            if (labelConceal.Enabled == true)
            {
                List<string> filenames = new List<string>();
                foreach (ListViewItem item in listViewCarrier.Items)
                {
                    filenames.Add(item.Text);
                }
                StegHelper sh = new StegHelper();
                try
                {
                    sh.Encoding(filenames, textBoxConceal.Text, textBoxOutPath.Text, checkBoxPassword.Checked, maskedTextBoxPassword.Text, alg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                List<string> filenames = new List<string>();
                foreach (ListViewItem item in listViewCarrier.Items)
                {
                    filenames.Add(item.Text);
                }
                StegHelper sh = new StegHelper();
                try
                {
                    sh.Decoding(filenames, textBoxOutPath.Text, checkBoxPassword.Checked, maskedTextBoxPassword.Text, alg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            buttonClear.PerformClick();
            textBoxConceal.Text = "";

        }
        private void buttonToggle_Click(object sender, EventArgs e)
        {
            if (textBoxConceal.Enabled == true)
            {
                // enable decoding mode
                textBoxConceal.Enabled = false;
                buttonConcealBrowse.Enabled = false;
                labelConceal.Enabled = false;
                toolStripStatusLabelMode.Text = "Decoding Mode";
                buttonGo.Text = "Decode";
            }
            else
            {
                // enable encoding mode
                textBoxConceal.Enabled = true;
                buttonConcealBrowse.Enabled = true;
                labelConceal.Enabled = true;
                toolStripStatusLabelMode.Text = "Encoding Mode";
                buttonGo.Text = "Encode";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // clear the listview
            listViewCarrier.ClearItems();
            checkEncodeDecodeButtonEnable(sender, e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // remove the selected items from the listview
            foreach (ListViewItem lvi in listViewCarrier.SelectedItems)
            {
                listViewCarrier.RemoveItem(lvi);
            }
            checkEncodeDecodeButtonEnable(sender, e);
        }

        private void buttonOutBrowse_Click(object sender, EventArgs e)
        {
            // open a folder browser
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            // get the path to store the output file
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxOutPath.Text = fbd.SelectedPath;
            }
            fbd.Dispose();
        }

        private void buttonConcealBrowse_Click(object sender, EventArgs e)
        {
            textBoxConceal.Text = openFile("All Files (*.*)|*.*", Directory.GetCurrentDirectory());
        }

        private void buttonCarrierBrowse_Click(object sender, EventArgs e)
        {
            // get set of files to hide or recover data
            //string[] carriers = openFiles("Image File (*.bmp, *.png, *.tif, *.tiff)|*.bmp;*.png;*.tif;*.tiff", Directory.GetCurrentDirectory());
            string[] carriers = openFiles("Image File (*.png, *.tif, *.tiff)|*.png;*.tif;*.tiff", Directory.GetCurrentDirectory());
            if (carriers == null) return;
            // populate the list view with the paths
            foreach (string carrier in carriers) listViewCarrier.AddItem(carrier);
            checkEncodeDecodeButtonEnable(sender, e);
        }

        #endregion

        #region Textboxes
        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // get the drag files
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (((TextBox)sender).Name.Equals("textBoxOutPath") == true)
                {
                    // ensure only one file was dragged and that the file supports hiding
                    if (files.Length != 1) MessageBox.Show("Please only input one folder to the text box", "Input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //else if (!canHideInfo(files[0])) MessageBox.Show(files[0] + " is currently not supported for steganography", "Input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (Directory.Exists(files[0])) ((TextBox)sender).Text = files[0];
                    else MessageBox.Show("Please enter a valid directory to store the output files", "Input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (((TextBox)sender).Name.Equals("textBoxConceal") == true)
                {
                    // ensure only one file was dragged and that the file supports hiding
                    if (files.Length != 1) MessageBox.Show("Please only input one file to the text box", "Input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //else if (!canHideInfo(files[0])) MessageBox.Show(files[0] + " is currently not supported for steganography", "Input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else ((TextBox)sender).Text = files[0];
                }

            }
        }

        private void textBox_DragEnter(object sender, DragEventArgs e)
        {
            // display file dropping effects
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void updateAndCheckFileSizes(object sender, EventArgs e)
        {
            checkEncodeDecodeButtonEnable(sender, e);
            long maxConcealSize = 0;
            long carrierSize = 0;

            List<string> filenames = new List<string>();
            foreach (ListViewItem item in listViewCarrier.Items)
            {
                // get the total carrier file size
                if (File.Exists(item.Text))
                {
                    FileInfo fi = new FileInfo(item.Text);
                    carrierSize += fi.Length;
                    filenames.Add(item.Text);
                }
                else
                {
                    // remove the file from the list since it doesn't exist
                    MessageBox.Show("The file <" + item.Text + "> no longer exists", "Input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listViewCarrier.RemoveItem(item);
                }
            }

            StegHelper sh = new StegHelper();
            maxConcealSize = sh.MaxConcealSize(filenames);

            // if the concealed file has an entry and the path exists then get the file size
            if (textBoxConceal.Text.Length > 0 && File.Exists(textBoxConceal.Text))
            {
                FileInfo fi = new FileInfo(textBoxConceal.Text);

                // if the file is too large for the carriers
                if (maxConcealSize > 0 && fi.Length > maxConcealSize)
                {
                    MessageBox.Show("The concealed file is too large for the carrier file(s)", "Input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxConceal.Text = "";
                }
            }

            toolStripStatusLabelConcealSize.Text = String.Format("|  Max Concealed Size:  {0:0.000} kB", maxConcealSize / 1024.0);
            toolStripStatusLabelCarrierSize.Text = String.Format("|  Total Carrier Size:  {0:0.000} kB", carrierSize / 1024.0);
        }

        #endregion

        #region ListViews
        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // get the drag files
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // populate the drag files into the listview
                foreach (string filePath in files)
                {
                    if (canHideInfo(filePath))
                    {
                        ((MonitoredListView)sender).AddItem(filePath);
                        checkEncodeDecodeButtonEnable(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("This file is not currently supported for Steganography", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            // display file dropping effects
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        #endregion

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControlMain.SelectedTab.Name == "tabPageSteg")
            {
                // set the status label to the current mode
                if (textBoxConceal.Enabled == true) toolStripStatusLabelMode.Text = "Encoding Mode";
                else toolStripStatusLabelMode.Text = "Decoding Mode";
            }
            else toolStripStatusLabelMode.Text = "";
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            checkEncodeDecodeButtonEnable(sender, e);
            if (checkBoxPassword.Checked == true)
            {
                // enable password options
                groupBoxEncryption.Enabled = true;
                labelPassword.Enabled = true;
                buttonPassword.Enabled = true;
                maskedTextBoxPassword.Enabled = true;
            }
            else
            {
                // disable password options
                groupBoxEncryption.Enabled = false;
                labelPassword.Enabled = false;
                buttonPassword.Enabled = false;
                maskedTextBoxPassword.Enabled = false;
            }
        }
        private void FormMainWindow_Load(object sender, EventArgs e)
        {
            textBoxOutPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        #endregion

        #region Validation
        private bool canHideInfo(string filepath)
        {
            // determine if the file type is currently supported to hide info
            string ext = Path.GetExtension(filepath);

            switch (ext)
            {
                //case ".bmp":
                case ".png":
                case ".tif":
                case ".tiff":
                    return true;
                default:
                    return false;
            }
        }

        private void checkEncodeDecodeButtonEnable(object sender, EventArgs e)
        {
            if (listViewCarrier.Items.Count > 0 && listviewItemsAreValid() && passwordItemIsValid() && textBoxOutPath.TextLength > 0 && Directory.Exists(textBoxOutPath.Text) && textBoxConceal.TextLength > 0 && File.Exists(textBoxConceal.Text))
            {
                buttonGo.Enabled = true;
            }
            else buttonGo.Enabled = false;
        }

        private bool listviewItemsAreValid()
        {
            if (listViewCarrier.Items.Count < 1) return false;
            // if a file doesn't exist return false
            foreach (ListViewItem item in listViewCarrier.Items)
            {
                if (!File.Exists(item.Text)) return false;
            }
            return true;
        }

        private bool passwordItemIsValid()
        {
            if (checkBoxPassword.Checked == false) return true;
            if (maskedTextBoxPassword.TextLength > 0) return true;
            return false;
        }
        #endregion

        #region FileIO
        private static string openFile(string filter, string directory)
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
                ofd.Dispose();
                return ofd.FileName;
            }
            ofd.Dispose();
            return "";
        }

        private static string[] openFiles(string filter, string directory)
        {
            // open a file dialog asking for an input
            OpenFileDialog ofd = new OpenFileDialog();

            // ofd settings
            ofd.Filter = filter;
            ofd.InitialDirectory = directory;
            ofd.RestoreDirectory = true;
            ofd.Multiselect = true;
            ofd.CheckFileExists = true;

            // return the path
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ofd.Dispose();
                return ofd.FileNames;
            }
            ofd.Dispose();
            return null;
        }
        #endregion

    }
}
