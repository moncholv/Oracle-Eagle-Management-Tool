using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Windows
{
    public partial class FileGenerated : Form
    {
        public FileGenerated(string filePath)
        {
            InitializeComponent();

            GeneratedFile_linkLabel.Text = filePath;
        }

        private void GeneratedFile_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.GeneratedFile_linkLabel.Text);
            this.Close();
        }

        private void close_button_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void folder_button_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select, " + this.GeneratedFile_linkLabel.Text);
        }
    }
}
