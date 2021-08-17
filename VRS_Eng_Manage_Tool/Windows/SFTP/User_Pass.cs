using System;
using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Windows.SFTP
{
    public partial class User_Pass : Form
    {
        public string User { get; set; }
        public string Password { get; set; }

        public User_Pass()
        {
            InitializeComponent();
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(username_textBox.Text) && !string.IsNullOrEmpty(Password_textBox.Text))
            {
                User = username_textBox.Text;
                Password = Password_textBox.Text;

                string execFile = string.Format(@"{0}WinSCP\WinSCP.com", AppDomain.CurrentDomain.BaseDirectory);
                string command = string.Format(@" /command ""open sftp://{0}:{1}@{2}/"" ""cd {3}"" ""get * {4}\"" ""exito""",
                    User,
                    Password,
                    Properties.Settings.Default.server,
                    Properties.Settings.Default.remotePath,
                    Properties.Settings.Default.LocalPath);

                System.Diagnostics.Process.Start(execFile, command);

                Close();
            }
            else
                MessageBox.Show("Please type both user and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}