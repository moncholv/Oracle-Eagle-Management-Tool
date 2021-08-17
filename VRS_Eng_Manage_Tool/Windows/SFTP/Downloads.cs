using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.IO;
using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Windows.SFTP
{
    public partial class Downloads : Base.FormBase
    {
        string User { get; set; }
        string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public Downloads()
        {
            InitializeComponent();
        }

        public void DownloadServerFiles()
        {
            try
            {
                using (SftpClient sftp = new SftpClient(Properties.Settings.Default.server, User, Password))
                {
                    try
                    {
                        SftpStatus_textBox.Text = "Connecting to ftp server..." + Environment.NewLine;

                        sftp.Connect();

                        SftpStatus_textBox.Text = "Connection established." + Environment.NewLine;


                        // By default, the method doesn't download subdirectories
                        // therefore you need to indicate that you want their content too
                        bool recursiveDownload = true;

                        // Start download of the directory
                        DownloadDirectory(
                            sftp,
                            Properties.Settings.Default.remotePath,
                            Properties.Settings.Default.LocalPath,
                            recursiveDownload
                        );

                        sftp.Disconnect();
                    }
                    catch (Exception er)
                    {
                        SftpStatus_textBox.Text = SftpStatus_textBox.Text + Environment.NewLine + string.Format("Error:{0}{1}", Environment.NewLine, er.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                SftpStatus_textBox.Text = SftpStatus_textBox.Text + Environment.NewLine + string.Format("Error:{0}{1}", Environment.NewLine, ex.Message);
            }
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DownloadDirectory(SftpClient client, string source, string destination, bool recursive = false)
        {
            SftpStatus_textBox.Text = "Starting download..." + Environment.NewLine;

            // List the files and folders of the directory
            var files = client.ListDirectory(source);
            int downloadingFile, totalFiles;
            downloadingFile = 0;
            // Iterate over them
            foreach (SftpFile file in files)
            {
                downloadingFile += 1;
                // If is a file, download it
                if (!file.IsDirectory && !file.IsSymbolicLink)
                {
                    DownloadFilesStatus_label.Text = string.Format("Downloading file {0} of 98", downloadingFile.ToString());
                    DownloadFile(client, file, destination);
                }
                // If it's a symbolic link, ignore it
                else if (file.IsSymbolicLink)
                {
                    Console.WriteLine("Symbolic link ignored: {0}", file.FullName);
                }
                // If its a directory, create it locally (and ignore the .. and .=) 
                //. is the current folder
                //.. is the folder above the current folder -the folder that contains the current folder.
                else if (file.Name != "." && file.Name != "..")
                {
                    var dir = Directory.CreateDirectory(Path.Combine(destination, file.Name));
                    // and start downloading it's content recursively :) in case it's required
                    if (recursive)
                    {
                        DownloadDirectory(client, file.FullName, dir.FullName);
                    }
                }
            }
        }

        /// <summary>
        /// Downloads a remote file through the client into a local directory
        /// </summary>
        /// <param name="client"></param>
        /// <param name="file"></param>
        /// <param name="directory"></param>
        private void DownloadFile(SftpClient client, SftpFile file, string directory)
        {
            SftpStatus_textBox.Text = SftpStatus_textBox.Text + Environment.NewLine + string.Format("Downloading file............{0}", file.FullName);
            //Console.WriteLine("Downloading {0}", file.FullName);

            using (Stream fileStream = File.OpenWrite(Path.Combine(directory, file.Name)))
            {
                client.DownloadFile(file.FullName, fileStream);
            }
        }

        private void DownloadFiles_button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(username_textBox.Text) && !string.IsNullOrEmpty(Password_textBox.Text))
            {
                User = username_textBox.Text;
                Password = Password_textBox.Text;

                //TODO --> QUITAR
                Password = "Dd8163.9";

                DownloadServerFiles();
                this.Close_button.Focus();
            }
            else
                MessageBox.Show("Please type both user and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}