namespace veil
{
    partial class FormPasswordGenerator
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
            this.checkBoxLower = new System.Windows.Forms.CheckBox();
            this.checkBoxUpper = new System.Windows.Forms.CheckBox();
            this.checkBoxDigits = new System.Windows.Forms.CheckBox();
            this.checkBoxSpecial = new System.Windows.Forms.CheckBox();
            this.checkBoxBrackets = new System.Windows.Forms.CheckBox();
            this.checkBoxSpace = new System.Windows.Forms.CheckBox();
            this.checkBoxUnderscore = new System.Windows.Forms.CheckBox();
            this.checkBoxPunctuation = new System.Windows.Forms.CheckBox();
            this.checkBoxWords = new System.Windows.Forms.CheckBox();
            this.textBoxCustom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxPasswords = new System.Windows.Forms.ListBox();
            this.buttonObfuscate = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxLower
            // 
            this.checkBoxLower.AutoSize = true;
            this.checkBoxLower.Checked = true;
            this.checkBoxLower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLower.Location = new System.Drawing.Point(6, 19);
            this.checkBoxLower.Name = "checkBoxLower";
            this.checkBoxLower.Size = new System.Drawing.Size(104, 17);
            this.checkBoxLower.TabIndex = 0;
            this.checkBoxLower.Text = "Lower-case (a-z)";
            this.checkBoxLower.UseVisualStyleBackColor = true;
            this.checkBoxLower.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // checkBoxUpper
            // 
            this.checkBoxUpper.AutoSize = true;
            this.checkBoxUpper.Checked = true;
            this.checkBoxUpper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUpper.Location = new System.Drawing.Point(6, 42);
            this.checkBoxUpper.Name = "checkBoxUpper";
            this.checkBoxUpper.Size = new System.Drawing.Size(107, 17);
            this.checkBoxUpper.TabIndex = 1;
            this.checkBoxUpper.Text = "Upper-case (A-Z)";
            this.checkBoxUpper.UseVisualStyleBackColor = true;
            this.checkBoxUpper.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // checkBoxDigits
            // 
            this.checkBoxDigits.AutoSize = true;
            this.checkBoxDigits.Checked = true;
            this.checkBoxDigits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDigits.Location = new System.Drawing.Point(6, 65);
            this.checkBoxDigits.Name = "checkBoxDigits";
            this.checkBoxDigits.Size = new System.Drawing.Size(76, 17);
            this.checkBoxDigits.TabIndex = 2;
            this.checkBoxDigits.Text = "Digits (0-9)";
            this.checkBoxDigits.UseVisualStyleBackColor = true;
            this.checkBoxDigits.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // checkBoxSpecial
            // 
            this.checkBoxSpecial.AutoSize = true;
            this.checkBoxSpecial.Checked = true;
            this.checkBoxSpecial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSpecial.Location = new System.Drawing.Point(6, 88);
            this.checkBoxSpecial.Name = "checkBoxSpecial";
            this.checkBoxSpecial.Size = new System.Drawing.Size(115, 17);
            this.checkBoxSpecial.TabIndex = 3;
            this.checkBoxSpecial.Text = "Special (!@#$%^&*)";
            this.checkBoxSpecial.UseVisualStyleBackColor = true;
            this.checkBoxSpecial.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // checkBoxBrackets
            // 
            this.checkBoxBrackets.AutoSize = true;
            this.checkBoxBrackets.Location = new System.Drawing.Point(6, 111);
            this.checkBoxBrackets.Name = "checkBoxBrackets";
            this.checkBoxBrackets.Size = new System.Drawing.Size(118, 17);
            this.checkBoxBrackets.TabIndex = 4;
            this.checkBoxBrackets.Text = "Brackets ((),{},[],<>)";
            this.checkBoxBrackets.UseVisualStyleBackColor = true;
            this.checkBoxBrackets.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // checkBoxSpace
            // 
            this.checkBoxSpace.AutoSize = true;
            this.checkBoxSpace.Location = new System.Drawing.Point(6, 134);
            this.checkBoxSpace.Name = "checkBoxSpace";
            this.checkBoxSpace.Size = new System.Drawing.Size(69, 17);
            this.checkBoxSpace.TabIndex = 5;
            this.checkBoxSpace.Text = "Space ( )";
            this.checkBoxSpace.UseVisualStyleBackColor = true;
            this.checkBoxSpace.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // checkBoxUnderscore
            // 
            this.checkBoxUnderscore.AutoSize = true;
            this.checkBoxUnderscore.Location = new System.Drawing.Point(6, 157);
            this.checkBoxUnderscore.Name = "checkBoxUnderscore";
            this.checkBoxUnderscore.Size = new System.Drawing.Size(96, 17);
            this.checkBoxUnderscore.TabIndex = 6;
            this.checkBoxUnderscore.Text = "Underscore (_)";
            this.checkBoxUnderscore.UseVisualStyleBackColor = true;
            this.checkBoxUnderscore.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // checkBoxPunctuation
            // 
            this.checkBoxPunctuation.AutoSize = true;
            this.checkBoxPunctuation.Location = new System.Drawing.Point(6, 180);
            this.checkBoxPunctuation.Name = "checkBoxPunctuation";
            this.checkBoxPunctuation.Size = new System.Drawing.Size(117, 17);
            this.checkBoxPunctuation.TabIndex = 7;
            this.checkBoxPunctuation.Text = "Punctuation (.,?;:\'\")";
            this.checkBoxPunctuation.UseVisualStyleBackColor = true;
            this.checkBoxPunctuation.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // checkBoxWords
            // 
            this.checkBoxWords.AutoSize = true;
            this.checkBoxWords.Location = new System.Drawing.Point(6, 203);
            this.checkBoxWords.Name = "checkBoxWords";
            this.checkBoxWords.Size = new System.Drawing.Size(57, 17);
            this.checkBoxWords.TabIndex = 8;
            this.checkBoxWords.Text = "Words";
            this.checkBoxWords.UseVisualStyleBackColor = true;
            this.checkBoxWords.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // textBoxCustom
            // 
            this.textBoxCustom.Location = new System.Drawing.Point(6, 226);
            this.textBoxCustom.Name = "textBoxCustom";
            this.textBoxCustom.Size = new System.Drawing.Size(115, 20);
            this.textBoxCustom.TabIndex = 10;
            this.textBoxCustom.TextChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Custom characters";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(12, 332);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 12;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(255, 332);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(240, 26);
            this.textBoxPassword.TabIndex = 13;
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.Location = new System.Drawing.Point(6, 265);
            this.numericUpDownLength.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownLength.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(115, 20);
            this.numericUpDownLength.TabIndex = 14;
            this.numericUpDownLength.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.label2);
            this.groupBoxSettings.Controls.Add(this.checkBoxLower);
            this.groupBoxSettings.Controls.Add(this.numericUpDownLength);
            this.groupBoxSettings.Controls.Add(this.checkBoxUpper);
            this.groupBoxSettings.Controls.Add(this.checkBoxDigits);
            this.groupBoxSettings.Controls.Add(this.checkBoxSpecial);
            this.groupBoxSettings.Controls.Add(this.label1);
            this.groupBoxSettings.Controls.Add(this.checkBoxBrackets);
            this.groupBoxSettings.Controls.Add(this.textBoxCustom);
            this.groupBoxSettings.Controls.Add(this.checkBoxSpace);
            this.groupBoxSettings.Controls.Add(this.checkBoxUnderscore);
            this.groupBoxSettings.Controls.Add(this.checkBoxWords);
            this.groupBoxSettings.Controls.Add(this.checkBoxPunctuation);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(132, 314);
            this.groupBoxSettings.TabIndex = 15;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Length";
            // 
            // listBoxPasswords
            // 
            this.listBoxPasswords.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPasswords.FormattingEnabled = true;
            this.listBoxPasswords.ItemHeight = 19;
            this.listBoxPasswords.Location = new System.Drawing.Point(150, 22);
            this.listBoxPasswords.Name = "listBoxPasswords";
            this.listBoxPasswords.Size = new System.Drawing.Size(345, 289);
            this.listBoxPasswords.TabIndex = 16;
            this.listBoxPasswords.SelectedIndexChanged += new System.EventHandler(this.listBoxPasswords_SelectedIndexChanged);
            // 
            // buttonObfuscate
            // 
            this.buttonObfuscate.Location = new System.Drawing.Point(93, 331);
            this.buttonObfuscate.Name = "buttonObfuscate";
            this.buttonObfuscate.Size = new System.Drawing.Size(75, 23);
            this.buttonObfuscate.TabIndex = 17;
            this.buttonObfuscate.Text = "Obfuscate";
            this.buttonObfuscate.UseVisualStyleBackColor = true;
            this.buttonObfuscate.Click += new System.EventHandler(this.buttonObfuscate_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(174, 331);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 18;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // FormPasswordGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 368);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonObfuscate);
            this.Controls.Add(this.listBoxPasswords);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonGenerate);
            this.Name = "FormPasswordGenerator";
            this.Text = "FormPasswordGenerator";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxLower;
        private System.Windows.Forms.CheckBox checkBoxUpper;
        private System.Windows.Forms.CheckBox checkBoxDigits;
        private System.Windows.Forms.CheckBox checkBoxSpecial;
        private System.Windows.Forms.CheckBox checkBoxBrackets;
        private System.Windows.Forms.CheckBox checkBoxSpace;
        private System.Windows.Forms.CheckBox checkBoxUnderscore;
        private System.Windows.Forms.CheckBox checkBoxPunctuation;
        private System.Windows.Forms.CheckBox checkBoxWords;
        private System.Windows.Forms.TextBox textBoxCustom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxPasswords;
        private System.Windows.Forms.Button buttonObfuscate;
        private System.Windows.Forms.Button buttonSelect;
    }
}