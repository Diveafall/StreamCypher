namespace StreamCypher
{
    partial class Main
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.actionButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDecrypt = new System.Windows.Forms.RadioButton();
            this.radioButtonEncrypt = new System.Windows.Forms.RadioButton();
            this.textBoxEncryptedFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSelectDestinationFolder = new System.Windows.Forms.Button();
            this.textBoxDestinationFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSelectSourceFile = new System.Windows.Forms.Button();
            this.textBoxSourceFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNonce = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(10, 234);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(452, 27);
            this.progressBar.TabIndex = 0;
            // 
            // actionButton
            // 
            this.actionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.actionButton.Location = new System.Drawing.Point(468, 234);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(75, 29);
            this.actionButton.TabIndex = 1;
            this.actionButton.Text = "Encrypt";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxNonce);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxKey);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.radioButtonDecrypt);
            this.groupBox1.Controls.Add(this.radioButtonEncrypt);
            this.groupBox1.Controls.Add(this.textBoxEncryptedFilename);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonSelectDestinationFolder);
            this.groupBox1.Controls.Add(this.textBoxDestinationFolder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonSelectSourceFile);
            this.groupBox1.Controls.Add(this.textBoxSourceFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 216);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AES";
            // 
            // radioButtonDecrypt
            // 
            this.radioButtonDecrypt.AutoSize = true;
            this.radioButtonDecrypt.Location = new System.Drawing.Point(190, 19);
            this.radioButtonDecrypt.Name = "radioButtonDecrypt";
            this.radioButtonDecrypt.Size = new System.Drawing.Size(62, 17);
            this.radioButtonDecrypt.TabIndex = 9;
            this.radioButtonDecrypt.Text = "Decrypt";
            this.radioButtonDecrypt.UseVisualStyleBackColor = true;
            this.radioButtonDecrypt.CheckedChanged += new System.EventHandler(this.radioButtonDecrypt_CheckedChanged);
            // 
            // radioButtonEncrypt
            // 
            this.radioButtonEncrypt.AutoSize = true;
            this.radioButtonEncrypt.Checked = true;
            this.radioButtonEncrypt.Location = new System.Drawing.Point(123, 19);
            this.radioButtonEncrypt.Name = "radioButtonEncrypt";
            this.radioButtonEncrypt.Size = new System.Drawing.Size(61, 17);
            this.radioButtonEncrypt.TabIndex = 8;
            this.radioButtonEncrypt.TabStop = true;
            this.radioButtonEncrypt.Text = "Encrypt";
            this.radioButtonEncrypt.UseVisualStyleBackColor = true;
            // 
            // textBoxEncryptedFilename
            // 
            this.textBoxEncryptedFilename.Location = new System.Drawing.Point(116, 183);
            this.textBoxEncryptedFilename.Name = "textBoxEncryptedFilename";
            this.textBoxEncryptedFilename.Size = new System.Drawing.Size(318, 20);
            this.textBoxEncryptedFilename.TabIndex = 7;
            this.textBoxEncryptedFilename.TextChanged += new System.EventHandler(this.textBoxEncryptedFilename_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Encrypted Filename";
            // 
            // buttonSelectDestinationFolder
            // 
            this.buttonSelectDestinationFolder.Location = new System.Drawing.Point(440, 155);
            this.buttonSelectDestinationFolder.Name = "buttonSelectDestinationFolder";
            this.buttonSelectDestinationFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectDestinationFolder.TabIndex = 5;
            this.buttonSelectDestinationFolder.Text = "Select";
            this.buttonSelectDestinationFolder.UseVisualStyleBackColor = true;
            this.buttonSelectDestinationFolder.Click += new System.EventHandler(this.buttonSelectDestinationFolder_Click);
            // 
            // textBoxDestinationFolder
            // 
            this.textBoxDestinationFolder.Location = new System.Drawing.Point(116, 157);
            this.textBoxDestinationFolder.Name = "textBoxDestinationFolder";
            this.textBoxDestinationFolder.Size = new System.Drawing.Size(318, 20);
            this.textBoxDestinationFolder.TabIndex = 4;
            this.textBoxDestinationFolder.TextChanged += new System.EventHandler(this.textBoxDestinationFolder_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination Folder";
            // 
            // buttonSelectSourceFile
            // 
            this.buttonSelectSourceFile.Location = new System.Drawing.Point(440, 129);
            this.buttonSelectSourceFile.Name = "buttonSelectSourceFile";
            this.buttonSelectSourceFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectSourceFile.TabIndex = 2;
            this.buttonSelectSourceFile.Text = "Select";
            this.buttonSelectSourceFile.UseVisualStyleBackColor = true;
            this.buttonSelectSourceFile.Click += new System.EventHandler(this.buttonSelectSourceFile_Click);
            // 
            // textBoxSourceFile
            // 
            this.textBoxSourceFile.Location = new System.Drawing.Point(116, 131);
            this.textBoxSourceFile.Name = "textBoxSourceFile";
            this.textBoxSourceFile.Size = new System.Drawing.Size(318, 20);
            this.textBoxSourceFile.TabIndex = 1;
            this.textBoxSourceFile.TextChanged += new System.EventHandler(this.textBoxSourceFile_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source File";
            // 
            // textBoxNonce
            // 
            this.textBoxNonce.Location = new System.Drawing.Point(116, 76);
            this.textBoxNonce.Name = "textBoxNonce";
            this.textBoxNonce.Size = new System.Drawing.Size(318, 20);
            this.textBoxNonce.TabIndex = 13;
            this.textBoxNonce.TextChanged += new System.EventHandler(this.textBoxNonce_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nonce";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(116, 50);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(318, 20);
            this.textBoxKey.TabIndex = 11;
            this.textBoxKey.TextChanged += new System.EventHandler(this.textBoxKey_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Key";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 273);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Cypher";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSelectDestinationFolder;
        private System.Windows.Forms.TextBox textBoxDestinationFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectSourceFile;
        private System.Windows.Forms.TextBox textBoxSourceFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEncryptedFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonDecrypt;
        private System.Windows.Forms.RadioButton radioButtonEncrypt;
        private System.Windows.Forms.TextBox textBoxNonce;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label label5;
    }
}

