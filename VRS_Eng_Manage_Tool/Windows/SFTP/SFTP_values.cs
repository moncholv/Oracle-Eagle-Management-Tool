using System;
using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Windows.SFTP
{
    public partial class SFTP_values : Form
    {
        public SFTP_values()
        {
            InitializeComponent();

            if(!string.IsNullOrEmpty(Properties.Settings.Default.server))
                RemoteServer_textBox.Text = Properties.Settings.Default.server;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.remotePath))
                RemotePath_textBox.Text = Properties.Settings.Default.remotePath;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.LocalPath))
                LocalPathValue_label.Text = Properties.Settings.Default.LocalPath;
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {
            bool changed = false;

            if (!string.IsNullOrEmpty(RemoteServer_textBox.Text) && !string.IsNullOrEmpty(RemotePath_textBox.Text) && !string.IsNullOrEmpty(LocalPathValue_label.Text))
            {
                if (Properties.Settings.Default.server != RemoteServer_textBox.Text)
                {
                    Properties.Settings.Default.server = RemoteServer_textBox.Text;
                    changed = true;
                }
                if (Properties.Settings.Default.remotePath != RemotePath_textBox.Text)
                {
                    Properties.Settings.Default.remotePath = RemotePath_textBox.Text;
                    changed = true;
                }
                if (Properties.Settings.Default.LocalPath != LocalPathValue_label.Text)
                {
                    Properties.Settings.Default.LocalPath = LocalPathValue_label.Text;
                    changed = true;
                }

                if (changed)
                    Properties.Settings.Default.Save();

                this.Close();
            }
            else
                MessageBox.Show("Please type all values", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LocalPathValue_label_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(!string.IsNullOrEmpty(Properties.Settings.Default.LocalPath))
                fbd.SelectedPath = Properties.Settings.Default.LocalPath;

            DialogResult result = fbd.ShowDialog();
            LocalPathValue_label.Text = fbd.SelectedPath;
        }

        public bool HasAllValues()
        {
            return !string.IsNullOrEmpty(Properties.Settings.Default.server) && !string.IsNullOrEmpty(Properties.Settings.Default.LocalPath) && !string.IsNullOrEmpty(Properties.Settings.Default.remotePath);
        }
    }
}