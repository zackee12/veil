namespace veil
{
    partial class FormMainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageSteg = new System.Windows.Forms.TabPage();
            this.buttonGo = new System.Windows.Forms.Button();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.buttonOutBrowse = new System.Windows.Forms.Button();
            this.textBoxOutPath = new System.Windows.Forms.TextBox();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.groupBoxPassword = new System.Windows.Forms.GroupBox();
            this.checkBoxPassword = new System.Windows.Forms.CheckBox();
            this.buttonPassword = new System.Windows.Forms.Button();
            this.maskedTextBoxPassword = new System.Windows.Forms.MaskedTextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.groupBoxEncryption = new System.Windows.Forms.GroupBox();
            this.radioButtonTwofish = new System.Windows.Forms.RadioButton();
            this.radioButtonSerpent = new System.Windows.Forms.RadioButton();
            this.radioButtonTripleDES = new System.Windows.Forms.RadioButton();
            this.radioButtonRijndael = new System.Windows.Forms.RadioButton();
            this.radioButtonRC2 = new System.Windows.Forms.RadioButton();
            this.radioButtonMars = new System.Windows.Forms.RadioButton();
            this.radioButtonDES = new System.Windows.Forms.RadioButton();
            this.radioButtonBlowfish = new System.Windows.Forms.RadioButton();
            this.radioButtonAES = new System.Windows.Forms.RadioButton();
            this.buttonConcealBrowse = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCarrierBrowse = new System.Windows.Forms.Button();
            this.textBoxConceal = new System.Windows.Forms.TextBox();
            this.listViewCarrier = new veil.MonitoredListView();
            this.labelConceal = new System.Windows.Forms.Label();
            this.labelCarrier = new System.Windows.Forms.Label();
            this.buttonToggle = new System.Windows.Forms.Button();
            this.tabPageAnalysis = new System.Windows.Forms.TabPage();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCarrierSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelConcealSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain.SuspendLayout();
            this.tabPageSteg.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxPassword.SuspendLayout();
            this.groupBoxEncryption.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageSteg);
            this.tabControlMain.Controls.Add(this.tabPageAnalysis);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(487, 466);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageSteg
            // 
            this.tabPageSteg.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSteg.Controls.Add(this.buttonGo);
            this.tabPageSteg.Controls.Add(this.groupBoxOutput);
            this.tabPageSteg.Controls.Add(this.groupBoxInput);
            this.tabPageSteg.Controls.Add(this.buttonToggle);
            this.tabPageSteg.Location = new System.Drawing.Point(4, 22);
            this.tabPageSteg.Name = "tabPageSteg";
            this.tabPageSteg.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSteg.Size = new System.Drawing.Size(479, 440);
            this.tabPageSteg.TabIndex = 0;
            this.tabPageSteg.Text = "Steganography";
            // 
            // buttonGo
            // 
            this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGo.Enabled = false;
            this.buttonGo.Location = new System.Drawing.Point(6, 394);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(465, 23);
            this.buttonGo.TabIndex = 10;
            this.buttonGo.Text = "Encode";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOutput.Controls.Add(this.buttonOutBrowse);
            this.groupBoxOutput.Controls.Add(this.textBoxOutPath);
            this.groupBoxOutput.Location = new System.Drawing.Point(6, 332);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(465, 56);
            this.groupBoxOutput.TabIndex = 9;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // buttonOutBrowse
            // 
            this.buttonOutBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOutBrowse.Location = new System.Drawing.Point(384, 19);
            this.buttonOutBrowse.Name = "buttonOutBrowse";
            this.buttonOutBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonOutBrowse.TabIndex = 6;
            this.buttonOutBrowse.Text = "Browse";
            this.buttonOutBrowse.UseVisualStyleBackColor = true;
            this.buttonOutBrowse.Click += new System.EventHandler(this.buttonOutBrowse_Click);
            // 
            // textBoxOutPath
            // 
            this.textBoxOutPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOutPath.Location = new System.Drawing.Point(9, 21);
            this.textBoxOutPath.Name = "textBoxOutPath";
            this.textBoxOutPath.Size = new System.Drawing.Size(369, 20);
            this.textBoxOutPath.TabIndex = 0;
            this.textBoxOutPath.TextChanged += new System.EventHandler(this.checkEncodeDecodeButtonEnable);
            this.textBoxOutPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBoxOutPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInput.Controls.Add(this.groupBoxPassword);
            this.groupBoxInput.Controls.Add(this.groupBoxEncryption);
            this.groupBoxInput.Controls.Add(this.buttonConcealBrowse);
            this.groupBoxInput.Controls.Add(this.buttonDelete);
            this.groupBoxInput.Controls.Add(this.buttonClear);
            this.groupBoxInput.Controls.Add(this.buttonCarrierBrowse);
            this.groupBoxInput.Controls.Add(this.textBoxConceal);
            this.groupBoxInput.Controls.Add(this.listViewCarrier);
            this.groupBoxInput.Controls.Add(this.labelConceal);
            this.groupBoxInput.Controls.Add(this.labelCarrier);
            this.groupBoxInput.Location = new System.Drawing.Point(6, 35);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(465, 291);
            this.groupBoxInput.TabIndex = 8;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Input";
            // 
            // groupBoxPassword
            // 
            this.groupBoxPassword.Controls.Add(this.checkBoxPassword);
            this.groupBoxPassword.Controls.Add(this.buttonPassword);
            this.groupBoxPassword.Controls.Add(this.maskedTextBoxPassword);
            this.groupBoxPassword.Controls.Add(this.labelPassword);
            this.groupBoxPassword.Location = new System.Drawing.Point(6, 175);
            this.groupBoxPassword.Name = "groupBoxPassword";
            this.groupBoxPassword.Size = new System.Drawing.Size(190, 108);
            this.groupBoxPassword.TabIndex = 15;
            this.groupBoxPassword.TabStop = false;
            this.groupBoxPassword.Text = "Password Protection";
            // 
            // checkBoxPassword
            // 
            this.checkBoxPassword.AutoSize = true;
            this.checkBoxPassword.Checked = true;
            this.checkBoxPassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPassword.Location = new System.Drawing.Point(6, 19);
            this.checkBoxPassword.Name = "checkBoxPassword";
            this.checkBoxPassword.Size = new System.Drawing.Size(65, 17);
            this.checkBoxPassword.TabIndex = 9;
            this.checkBoxPassword.Text = "Enabled";
            this.checkBoxPassword.UseVisualStyleBackColor = true;
            this.checkBoxPassword.CheckedChanged += new System.EventHandler(this.checkBoxPassword_CheckedChanged);
            // 
            // buttonPassword
            // 
            this.buttonPassword.Location = new System.Drawing.Point(3, 76);
            this.buttonPassword.Name = "buttonPassword";
            this.buttonPassword.Size = new System.Drawing.Size(75, 23);
            this.buttonPassword.TabIndex = 14;
            this.buttonPassword.Text = "Generate";
            this.buttonPassword.UseVisualStyleBackColor = true;
            // 
            // maskedTextBoxPassword
            // 
            this.maskedTextBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBoxPassword.Location = new System.Drawing.Point(4, 37);
            this.maskedTextBoxPassword.Name = "maskedTextBoxPassword";
            this.maskedTextBoxPassword.PasswordChar = '*';
            this.maskedTextBoxPassword.Size = new System.Drawing.Size(180, 20);
            this.maskedTextBoxPassword.TabIndex = 10;
            this.maskedTextBoxPassword.TextChanged += new System.EventHandler(this.checkEncodeDecodeButtonEnable);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(1, 60);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 11;
            this.labelPassword.Text = "Password";
            // 
            // groupBoxEncryption
            // 
            this.groupBoxEncryption.Controls.Add(this.radioButtonTwofish);
            this.groupBoxEncryption.Controls.Add(this.radioButtonSerpent);
            this.groupBoxEncryption.Controls.Add(this.radioButtonTripleDES);
            this.groupBoxEncryption.Controls.Add(this.radioButtonRijndael);
            this.groupBoxEncryption.Controls.Add(this.radioButtonRC2);
            this.groupBoxEncryption.Controls.Add(this.radioButtonMars);
            this.groupBoxEncryption.Controls.Add(this.radioButtonDES);
            this.groupBoxEncryption.Controls.Add(this.radioButtonBlowfish);
            this.groupBoxEncryption.Controls.Add(this.radioButtonAES);
            this.groupBoxEncryption.Location = new System.Drawing.Point(202, 175);
            this.groupBoxEncryption.Name = "groupBoxEncryption";
            this.groupBoxEncryption.Size = new System.Drawing.Size(257, 108);
            this.groupBoxEncryption.TabIndex = 13;
            this.groupBoxEncryption.TabStop = false;
            this.groupBoxEncryption.Text = "Encryption";
            // 
            // radioButtonTwofish
            // 
            this.radioButtonTwofish.AutoSize = true;
            this.radioButtonTwofish.Location = new System.Drawing.Point(182, 19);
            this.radioButtonTwofish.Name = "radioButtonTwofish";
            this.radioButtonTwofish.Size = new System.Drawing.Size(62, 17);
            this.radioButtonTwofish.TabIndex = 20;
            this.radioButtonTwofish.Text = "Twofish";
            this.radioButtonTwofish.UseVisualStyleBackColor = true;
            // 
            // radioButtonSerpent
            // 
            this.radioButtonSerpent.AutoSize = true;
            this.radioButtonSerpent.Location = new System.Drawing.Point(90, 65);
            this.radioButtonSerpent.Name = "radioButtonSerpent";
            this.radioButtonSerpent.Size = new System.Drawing.Size(62, 17);
            this.radioButtonSerpent.TabIndex = 19;
            this.radioButtonSerpent.Text = "Serpent";
            this.radioButtonSerpent.UseVisualStyleBackColor = true;
            // 
            // radioButtonTripleDES
            // 
            this.radioButtonTripleDES.AutoSize = true;
            this.radioButtonTripleDES.Location = new System.Drawing.Point(90, 88);
            this.radioButtonTripleDES.Name = "radioButtonTripleDES";
            this.radioButtonTripleDES.Size = new System.Drawing.Size(73, 17);
            this.radioButtonTripleDES.TabIndex = 18;
            this.radioButtonTripleDES.Text = "TripleDES";
            this.radioButtonTripleDES.UseVisualStyleBackColor = true;
            // 
            // radioButtonRijndael
            // 
            this.radioButtonRijndael.AutoSize = true;
            this.radioButtonRijndael.Location = new System.Drawing.Point(90, 42);
            this.radioButtonRijndael.Name = "radioButtonRijndael";
            this.radioButtonRijndael.Size = new System.Drawing.Size(63, 17);
            this.radioButtonRijndael.TabIndex = 17;
            this.radioButtonRijndael.Text = "Rijndael";
            this.radioButtonRijndael.UseVisualStyleBackColor = true;
            // 
            // radioButtonRC2
            // 
            this.radioButtonRC2.AutoSize = true;
            this.radioButtonRC2.Location = new System.Drawing.Point(91, 19);
            this.radioButtonRC2.Name = "radioButtonRC2";
            this.radioButtonRC2.Size = new System.Drawing.Size(46, 17);
            this.radioButtonRC2.TabIndex = 16;
            this.radioButtonRC2.Text = "RC2";
            this.radioButtonRC2.UseVisualStyleBackColor = true;
            // 
            // radioButtonMars
            // 
            this.radioButtonMars.AutoSize = true;
            this.radioButtonMars.Location = new System.Drawing.Point(6, 88);
            this.radioButtonMars.Name = "radioButtonMars";
            this.radioButtonMars.Size = new System.Drawing.Size(48, 17);
            this.radioButtonMars.TabIndex = 15;
            this.radioButtonMars.Text = "Mars";
            this.radioButtonMars.UseVisualStyleBackColor = true;
            // 
            // radioButtonDES
            // 
            this.radioButtonDES.AutoSize = true;
            this.radioButtonDES.Location = new System.Drawing.Point(6, 65);
            this.radioButtonDES.Name = "radioButtonDES";
            this.radioButtonDES.Size = new System.Drawing.Size(47, 17);
            this.radioButtonDES.TabIndex = 14;
            this.radioButtonDES.Text = "DES";
            this.radioButtonDES.UseVisualStyleBackColor = true;
            // 
            // radioButtonBlowfish
            // 
            this.radioButtonBlowfish.AutoSize = true;
            this.radioButtonBlowfish.Location = new System.Drawing.Point(6, 42);
            this.radioButtonBlowfish.Name = "radioButtonBlowfish";
            this.radioButtonBlowfish.Size = new System.Drawing.Size(64, 17);
            this.radioButtonBlowfish.TabIndex = 13;
            this.radioButtonBlowfish.Text = "Blowfish";
            this.radioButtonBlowfish.UseVisualStyleBackColor = true;
            // 
            // radioButtonAES
            // 
            this.radioButtonAES.AutoSize = true;
            this.radioButtonAES.Checked = true;
            this.radioButtonAES.Location = new System.Drawing.Point(6, 19);
            this.radioButtonAES.Name = "radioButtonAES";
            this.radioButtonAES.Size = new System.Drawing.Size(46, 17);
            this.radioButtonAES.TabIndex = 12;
            this.radioButtonAES.TabStop = true;
            this.radioButtonAES.Text = "AES";
            this.radioButtonAES.UseVisualStyleBackColor = true;
            // 
            // buttonConcealBrowse
            // 
            this.buttonConcealBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConcealBrowse.Location = new System.Drawing.Point(384, 116);
            this.buttonConcealBrowse.Name = "buttonConcealBrowse";
            this.buttonConcealBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonConcealBrowse.TabIndex = 8;
            this.buttonConcealBrowse.Text = "Browse";
            this.buttonConcealBrowse.UseVisualStyleBackColor = true;
            this.buttonConcealBrowse.Click += new System.EventHandler(this.buttonConcealBrowse_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(384, 48);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(384, 77);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonCarrierBrowse
            // 
            this.buttonCarrierBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCarrierBrowse.Location = new System.Drawing.Point(384, 19);
            this.buttonCarrierBrowse.Name = "buttonCarrierBrowse";
            this.buttonCarrierBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonCarrierBrowse.TabIndex = 5;
            this.buttonCarrierBrowse.Text = "Browse";
            this.buttonCarrierBrowse.UseVisualStyleBackColor = true;
            this.buttonCarrierBrowse.Click += new System.EventHandler(this.buttonCarrierBrowse_Click);
            // 
            // textBoxConceal
            // 
            this.textBoxConceal.AllowDrop = true;
            this.textBoxConceal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConceal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxConceal.Location = new System.Drawing.Point(9, 119);
            this.textBoxConceal.Name = "textBoxConceal";
            this.textBoxConceal.Size = new System.Drawing.Size(369, 20);
            this.textBoxConceal.TabIndex = 4;
            this.textBoxConceal.TextChanged += new System.EventHandler(this.updateAndCheckFileSizes);
            this.textBoxConceal.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_DragDrop);
            this.textBoxConceal.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_DragEnter);
            // 
            // listViewCarrier
            // 
            this.listViewCarrier.AllowDrop = true;
            this.listViewCarrier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCarrier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewCarrier.Location = new System.Drawing.Point(10, 19);
            this.listViewCarrier.Name = "listViewCarrier";
            this.listViewCarrier.Size = new System.Drawing.Size(368, 81);
            this.listViewCarrier.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewCarrier.TabIndex = 3;
            this.listViewCarrier.UseCompatibleStateImageBehavior = false;
            this.listViewCarrier.View = System.Windows.Forms.View.List;
            this.listViewCarrier.ItemChanged += new veil.MonitoredListView.ItemChangedEventHandler(this.updateAndCheckFileSizes);
            this.listViewCarrier.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listViewCarrier.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            // 
            // labelConceal
            // 
            this.labelConceal.AutoSize = true;
            this.labelConceal.Location = new System.Drawing.Point(6, 142);
            this.labelConceal.Name = "labelConceal";
            this.labelConceal.Size = new System.Drawing.Size(77, 13);
            this.labelConceal.TabIndex = 2;
            this.labelConceal.Text = "Concealed File";
            // 
            // labelCarrier
            // 
            this.labelCarrier.AutoSize = true;
            this.labelCarrier.Location = new System.Drawing.Point(6, 103);
            this.labelCarrier.Name = "labelCarrier";
            this.labelCarrier.Size = new System.Drawing.Size(67, 13);
            this.labelCarrier.TabIndex = 1;
            this.labelCarrier.Text = "Carrier File(s)";
            // 
            // buttonToggle
            // 
            this.buttonToggle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToggle.Location = new System.Drawing.Point(6, 6);
            this.buttonToggle.Name = "buttonToggle";
            this.buttonToggle.Size = new System.Drawing.Size(465, 23);
            this.buttonToggle.TabIndex = 7;
            this.buttonToggle.Text = "Encode / Decode Toggle";
            this.buttonToggle.UseVisualStyleBackColor = true;
            this.buttonToggle.Click += new System.EventHandler(this.buttonToggle_Click);
            // 
            // tabPageAnalysis
            // 
            this.tabPageAnalysis.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAnalysis.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnalysis.Name = "tabPageAnalysis";
            this.tabPageAnalysis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnalysis.Size = new System.Drawing.Size(479, 440);
            this.tabPageAnalysis.TabIndex = 1;
            this.tabPageAnalysis.Text = "Steganalysis";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMode,
            this.toolStripStatusLabelCarrierSize,
            this.toolStripStatusLabelConcealSize});
            this.statusStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStripMain.Location = new System.Drawing.Point(0, 446);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(487, 20);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelMode
            // 
            this.toolStripStatusLabelMode.Name = "toolStripStatusLabelMode";
            this.toolStripStatusLabelMode.Size = new System.Drawing.Size(91, 15);
            this.toolStripStatusLabelMode.Text = "Encoding Mode";
            // 
            // toolStripStatusLabelCarrierSize
            // 
            this.toolStripStatusLabelCarrierSize.Name = "toolStripStatusLabelCarrierSize";
            this.toolStripStatusLabelCarrierSize.Size = new System.Drawing.Size(135, 15);
            this.toolStripStatusLabelCarrierSize.Text = "|  Total Carrier Size:  0 kB";
            // 
            // toolStripStatusLabelConcealSize
            // 
            this.toolStripStatusLabelConcealSize.Name = "toolStripStatusLabelConcealSize";
            this.toolStripStatusLabelConcealSize.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabelConcealSize.Size = new System.Drawing.Size(151, 15);
            this.toolStripStatusLabelConcealSize.Text = "|  Max Concealed Size:  0 kB";
            // 
            // FormMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 466);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.tabControlMain);
            this.MinimumSize = new System.Drawing.Size(503, 504);
            this.Name = "FormMainWindow";
            this.Text = "FormMainWindow";
            this.Load += new System.EventHandler(this.FormMainWindow_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageSteg.ResumeLayout(false);
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxPassword.ResumeLayout(false);
            this.groupBoxPassword.PerformLayout();
            this.groupBoxEncryption.ResumeLayout(false);
            this.groupBoxEncryption.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageSteg;
        private System.Windows.Forms.TabPage tabPageAnalysis;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.Button buttonToggle;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.GroupBox groupBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxPassword;
        private System.Windows.Forms.Button buttonPassword;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.GroupBox groupBoxEncryption;
        private System.Windows.Forms.RadioButton radioButtonTwofish;
        private System.Windows.Forms.RadioButton radioButtonSerpent;
        private System.Windows.Forms.RadioButton radioButtonTripleDES;
        private System.Windows.Forms.RadioButton radioButtonRijndael;
        private System.Windows.Forms.RadioButton radioButtonRC2;
        private System.Windows.Forms.RadioButton radioButtonMars;
        private System.Windows.Forms.RadioButton radioButtonDES;
        private System.Windows.Forms.RadioButton radioButtonBlowfish;
        private System.Windows.Forms.RadioButton radioButtonAES;
        private System.Windows.Forms.Button buttonConcealBrowse;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCarrierBrowse;
        private System.Windows.Forms.TextBox textBoxConceal;
        private MonitoredListView listViewCarrier;
        private System.Windows.Forms.Label labelConceal;
        private System.Windows.Forms.Label labelCarrier;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.Button buttonOutBrowse;
        private System.Windows.Forms.TextBox textBoxOutPath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMode;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCarrierSize;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelConcealSize;
        private System.Windows.Forms.Button buttonGo;
    }
}