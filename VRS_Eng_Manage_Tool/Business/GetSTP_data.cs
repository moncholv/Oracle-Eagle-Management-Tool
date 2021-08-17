using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.IO;
using System.Threading;

namespace VRS_Eng_Manage_Tool.Business
{
    public class GetSTP_data
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="remotePath"></param>
        /// <param name="localPath"></param>
        public void GetServerData(string server, string user, string pass, string remotePath, string localPath)
        {
            Thread myThread = new Thread(delegate () {
                string host = server;
                string username = user;
                string password = pass;

                // Path to folder on SFTP server
                string pathRemoteDirectory = remotePath;
                // Path where the file should be saved once downloaded (locally)
                string pathLocalDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), localPath);

                using (SftpClient sftp = new SftpClient(host, username, password))
                {
                    try
                    {
                        sftp.Connect();

                        // By default, the method doesn't download subdirectories
                        // therefore you need to indicate that you want their content too
                        bool recursiveDownload = true;

                        // Start download of the directory
                        DownloadDirectory(
                            sftp,
                            pathRemoteDirectory,
                            pathLocalDirectory,
                            recursiveDownload
                        );

                        sftp.Disconnect();
                    }
                    catch (Exception er)
                    {
                        Console.WriteLine("An exception has been caught " + er.ToString());
                    }
                }
            });

            myThread.Start();

        }

        /// <summary>
        /// Downloads a remote directory into a local directory
        /// </summary>
        /// <param name="client"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        private void DownloadDirectory(SftpClient client, string source, string destination, bool recursive = false)
        {
            // List the files and folders of the directory
            var files = client.ListDirectory(source);

            // Iterate over them
            foreach (SftpFile file in files)
            {
                // If is a file, download it
                if (!file.IsDirectory && !file.IsSymbolicLink)
                {
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
            Console.WriteLine("Downloading {0}", file.FullName);

            using (Stream fileStream = File.OpenWrite(Path.Combine(directory, file.Name)))
            {
                client.DownloadFile(file.FullName, fileStream);
            }
        }
    }
}