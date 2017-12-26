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

namespace StreamCypher
{
    public partial class Main : Form
    {

        const string sourcePath = @"D:\chamber\sources\1.rar";
        const string destinationPath = @"D:\chamber\decrypted";

        private CypherModel _model;

        public Main()
        {
            InitializeComponent();
            _model = new CypherModel();
            textBoxSourceFile.Text = sourcePath;
            textBoxDestinationFolder.Text = destinationPath;
            textBoxEncryptedFilename.Text = @"1";
        }
        
        public void Report(int progress)
        {
            progressBar.Value = progress;
        }

        private async void actionButton_Click(object sender, EventArgs e)
        {
            actionButton.Enabled = false;
            var destinationPath = Path.Combine(textBoxDestinationFolder.Text, textBoxEncryptedFilename.Text + "." + CypherModel.ENCRYPTED_EXTENSION);

            await CypherEngine.Encrypt(textBoxSourceFile.Text, destinationPath, new Progress<int>(Report));

            actionButton.Enabled = true;
            progressBar.Value = 0;
        }

        private void buttonSelectSourceFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

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
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            DialogResult result = folderDialog.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    textBoxDestinationFolder.Text = folderDialog.SelectedPath;
                    break;
                default: break;
            }
        }
    }
}
