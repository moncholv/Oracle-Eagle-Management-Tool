using System;
using System.Text;
using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Windows
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            StringBuilder aboutText = new StringBuilder();
            aboutText.AppendLine("Vodafone Roaming Services Engineering Tool");
            aboutText.AppendLine(string.Format("Version {0}", version));
            aboutText.AppendLine("RLV");
            About_label.Text = aboutText.ToString();
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
