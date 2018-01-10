using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StreamCypher.Cypher;
using System.IO;
using StreamCypher.Helper;
using Sodium;

namespace StreamCypher
{
    public partial class Main : Form
    {

        const string sourcePath = @"D:\chamber\encrypted\1.enc";
        const string destinationPath = @"D:\chamber\decrypted";
        private bool _decryptActivated = false;

        private CypherModel _model;

        OpenFileDialog fileDialog = new OpenFileDialog();
        FolderBrowserDialog folderDialog = new FolderBrowserDialog();

        public Main()
        {
            InitializeComponent();
            _model = new CypherModel();
            textBoxSourceFile.Text = sourcePath;
            textBoxDestinationFolder.Text = destinationPath;
            textBoxEncryptedFilename.Text = @"1.rar";

            textBoxKey.Text = Encoding.Default.GetString(_model.Key);
            textBoxNonce.Text = Encoding.Default.GetString(_model.Nonce);
        }

        private void configureMode()
        {
            if (_decryptActivated)
            {
                actionButton.Text = "Decrypt";
            } else
            {
                actionButton.Text = "Encrypt";
            }
        }

        private async void actionButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            actionButton.Enabled = false;

            Action<int> reporter = progress => { progressBar.Value = progress; };
            var stats = _decryptActivated ? await _model.Decrypt(reporter) : await _model.Encrypt(reporter);

            actionButton.Enabled = true;
            var seconds = stats.duration / 1000;
            var message = (_decryptActivated ? "Encryption" : "Decryption") + " Complete!";
            UIEx.ShowNotice(message, "Duration: " + seconds.ToString() + " seconds.");
        }

        private void buttonSelectSourceFile_Click(object sender, EventArgs e)
        {
            fileDialog.Title = "Select Source File";

            DialogResult result = fileDialog.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    textBoxSourceFile.Text = fileDialog.FileName;
                    var filename = Path.GetFileName(fileDialog.FileName);
                    textBoxEncryptedFilename.Text = Path.ChangeExtension(filename, "dec");
                    break;
                default: break;
            }
        }

        private void buttonSelectDestinationFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderDialog.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    textBoxDestinationFolder.Text = folderDialog.SelectedPath;
                    break;
                default: break;
            }
        }

        private void textBoxSourceFile_TextChanged(object sender, EventArgs e)
        {
            _model.SourceFilePath = textBoxSourceFile.Text;
        }

        private void textBoxDestinationFolder_TextChanged(object sender, EventArgs e)
        {
            _model.EncryptedDirectory = textBoxDestinationFolder.Text;
        }

        private void textBoxEncryptedFilename_TextChanged(object sender, EventArgs e)
        {
            _model.EncryptedFileName = textBoxEncryptedFilename.Text;
        }

        private void radioButtonDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            _decryptActivated = radioButtonDecrypt.Checked;
            configureMode();
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            _model.Key = Encoding.Default.GetBytes(textBoxKey.Text);
        }

        private void textBoxNonce_TextChanged(object sender, EventArgs e)
        {
            _model.Nonce = Encoding.Default.GetBytes(textBoxNonce.Text);
        }
    }
}
