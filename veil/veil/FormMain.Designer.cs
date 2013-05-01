namespace veil
{
    partial class FormMain
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
            this.buttonDecode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDecodePass = new System.Windows.Forms.TextBox();
            this.buttonBrowseDecodeOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDecodeOut = new System.Windows.Forms.TextBox();
            this.textBoxDecodeIn = new System.Windows.Forms.TextBox();
            this.buttonBrowseDecodeIn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonEncode = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEncodePass = new System.Windows.Forms.TextBox();
            this.buttonBrowseEncodeOut = new System.Windows.Forms.Button();
            this.textBoxEncodeOut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEncodeIn = new System.Windows.Forms.TextBox();
            this.buttonBrowseEncodeEmbed = new System.Windows.Forms.Button();
            this.buttonBrowseEncodeIn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEncodeEmbed = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(219, 97);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(75, 23);
            this.buttonDecode.TabIndex = 0;
            this.buttonDecode.Text = "Decode File";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxDecodePass);
            this.groupBox1.Controls.Add(this.buttonBrowseDecodeOut);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxDecodeOut);
            this.groupBox1.Controls.Add(this.textBoxDecodeIn);
            this.groupBox1.Controls.Add(this.buttonBrowseDecodeIn);
            this.groupBox1.Controls.Add(this.buttonDecode);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Decode File";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output Path";
            // 
            // textBoxDecodePass
            // 
            this.textBoxDecodePass.Location = new System.Drawing.Point(6, 97);
            this.textBoxDecodePass.Name = "textBoxDecodePass";
            this.textBoxDecodePass.Size = new System.Drawing.Size(207, 20);
            this.textBoxDecodePass.TabIndex = 16;
            // 
            // buttonBrowseDecodeOut
            // 
            this.buttonBrowseDecodeOut.Location = new System.Drawing.Point(219, 58);
            this.buttonBrowseDecodeOut.Name = "buttonBrowseDecodeOut";
            this.buttonBrowseDecodeOut.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseDecodeOut.TabIndex = 5;
            this.buttonBrowseDecodeOut.Text = "Browse";
            this.buttonBrowseDecodeOut.UseVisualStyleBackColor = true;
            this.buttonBrowseDecodeOut.Click += new System.EventHandler(this.buttonBrowseDecodeOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input File";
            // 
            // textBoxDecodeOut
            // 
            this.textBoxDecodeOut.Location = new System.Drawing.Point(6, 58);
            this.textBoxDecodeOut.Name = "textBoxDecodeOut";
            this.textBoxDecodeOut.Size = new System.Drawing.Size(207, 20);
            this.textBoxDecodeOut.TabIndex = 3;
            // 
            // textBoxDecodeIn
            // 
            this.textBoxDecodeIn.Location = new System.Drawing.Point(6, 19);
            this.textBoxDecodeIn.Name = "textBoxDecodeIn";
            this.textBoxDecodeIn.Size = new System.Drawing.Size(207, 20);
            this.textBoxDecodeIn.TabIndex = 2;
            // 
            // buttonBrowseDecodeIn
            // 
            this.buttonBrowseDecodeIn.Location = new System.Drawing.Point(219, 19);
            this.buttonBrowseDecodeIn.Name = "buttonBrowseDecodeIn";
            this.buttonBrowseDecodeIn.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseDecodeIn.TabIndex = 1;
            this.buttonBrowseDecodeIn.Text = "Browse";
            this.buttonBrowseDecodeIn.UseVisualStyleBackColor = true;
            this.buttonBrowseDecodeIn.Click += new System.EventHandler(this.buttonBrowseDecodeIn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonEncode);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxEncodePass);
            this.groupBox2.Controls.Add(this.buttonBrowseEncodeOut);
            this.groupBox2.Controls.Add(this.textBoxEncodeOut);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxEncodeIn);
            this.groupBox2.Controls.Add(this.buttonBrowseEncodeEmbed);
            this.groupBox2.Controls.Add(this.buttonBrowseEncodeIn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxEncodeEmbed);
            this.groupBox2.Location = new System.Drawing.Point(12, 197);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 185);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Encode File";
            // 
            // buttonEncode
            // 
            this.buttonEncode.Location = new System.Drawing.Point(219, 133);
            this.buttonEncode.Name = "buttonEncode";
            this.buttonEncode.Size = new System.Drawing.Size(75, 23);
            this.buttonEncode.TabIndex = 18;
            this.buttonEncode.Text = "Encode File";
            this.buttonEncode.UseVisualStyleBackColor = true;
            this.buttonEncode.Click += new System.EventHandler(this.buttonEncode_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Output File";
            // 
            // textBoxEncodePass
            // 
            this.textBoxEncodePass.Location = new System.Drawing.Point(6, 136);
            this.textBoxEncodePass.Name = "textBoxEncodePass";
            this.textBoxEncodePass.Size = new System.Drawing.Size(207, 20);
            this.textBoxEncodePass.TabIndex = 18;
            // 
            // buttonBrowseEncodeOut
            // 
            this.buttonBrowseEncodeOut.Location = new System.Drawing.Point(219, 97);
            this.buttonBrowseEncodeOut.Name = "buttonBrowseEncodeOut";
            this.buttonBrowseEncodeOut.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseEncodeOut.TabIndex = 14;
            this.buttonBrowseEncodeOut.Text = "Browse";
            this.buttonBrowseEncodeOut.UseVisualStyleBackColor = true;
            this.buttonBrowseEncodeOut.Click += new System.EventHandler(this.buttonBrowseEncodeOut_Click);
            // 
            // textBoxEncodeOut
            // 
            this.textBoxEncodeOut.Location = new System.Drawing.Point(6, 97);
            this.textBoxEncodeOut.Name = "textBoxEncodeOut";
            this.textBoxEncodeOut.Size = new System.Drawing.Size(207, 20);
            this.textBoxEncodeOut.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Embed File";
            // 
            // textBoxEncodeIn
            // 
            this.textBoxEncodeIn.Location = new System.Drawing.Point(6, 19);
            this.textBoxEncodeIn.Name = "textBoxEncodeIn";
            this.textBoxEncodeIn.Size = new System.Drawing.Size(207, 20);
            this.textBoxEncodeIn.TabIndex = 8;
            // 
            // buttonBrowseEncodeEmbed
            // 
            this.buttonBrowseEncodeEmbed.Location = new System.Drawing.Point(219, 58);
            this.buttonBrowseEncodeEmbed.Name = "buttonBrowseEncodeEmbed";
            this.buttonBrowseEncodeEmbed.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseEncodeEmbed.TabIndex = 11;
            this.buttonBrowseEncodeEmbed.Text = "Browse";
            this.buttonBrowseEncodeEmbed.UseVisualStyleBackColor = true;
            this.buttonBrowseEncodeEmbed.Click += new System.EventHandler(this.buttonBrowseEncodeEmbed_Click);
            // 
            // buttonBrowseEncodeIn
            // 
            this.buttonBrowseEncodeIn.Location = new System.Drawing.Point(219, 19);
            this.buttonBrowseEncodeIn.Name = "buttonBrowseEncodeIn";
            this.buttonBrowseEncodeIn.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseEncodeIn.TabIndex = 7;
            this.buttonBrowseEncodeIn.Text = "Browse";
            this.buttonBrowseEncodeIn.UseVisualStyleBackColor = true;
            this.buttonBrowseEncodeIn.Click += new System.EventHandler(this.buttonBrowseEncodeIn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Input File";
            // 
            // textBoxEncodeEmbed
            // 
            this.textBoxEncodeEmbed.Location = new System.Drawing.Point(6, 58);
            this.textBoxEncodeEmbed.Name = "textBoxEncodeEmbed";
            this.textBoxEncodeEmbed.Size = new System.Drawing.Size(207, 20);
            this.textBoxEncodeEmbed.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 400);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 422);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBrowseDecodeOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDecodeOut;
        private System.Windows.Forms.TextBox textBoxDecodeIn;
        private System.Windows.Forms.Button buttonBrowseDecodeIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEncodeIn;
        private System.Windows.Forms.Button buttonBrowseEncodeEmbed;
        private System.Windows.Forms.Button buttonBrowseEncodeIn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEncodeEmbed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDecodePass;
        private System.Windows.Forms.Button buttonEncode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEncodePass;
        private System.Windows.Forms.Button buttonBrowseEncodeOut;
        private System.Windows.Forms.TextBox textBoxEncodeOut;
    }
}

