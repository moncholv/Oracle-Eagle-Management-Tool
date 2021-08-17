using System;
using System.IO;

namespace VRS_Eng_Manage_Tool.Windows.Reports
{
    public partial class RTMT_keys : Base.FormBase
    {
        string internalKeys_File = string.Format(@"{0}RTMT_keys\internalkeys.txt", AppDomain.CurrentDomain.BaseDirectory);
        string ipbbKeys_File = string.Format(@"{0}RTMT_keys\ipbbkeys.txt", AppDomain.CurrentDomain.BaseDirectory);
        string carrierKeys_File = string.Format(@"{0}RTMT_keys\carrierkeys.txt", AppDomain.CurrentDomain.BaseDirectory);

        public RTMT_keys()
        {
            InitializeComponent();

            ipbbKeys_textBox.Text = File.ReadAllText(ipbbKeys_File);
            internalKeys_textBox.Text = File.ReadAllText(internalKeys_File);
            carrierKeys_textBox.Text = File.ReadAllText(carrierKeys_File);

            save_button.Focus();
        }

        private void accept_button_Click(object sender, EventArgs e)
        {
            using (var stream = File.CreateText(internalKeys_File))
                stream.Write(internalKeys_textBox.Text);

            using (var stream = File.CreateText(ipbbKeys_File))
                stream.Write(ipbbKeys_textBox.Text);

            using (var stream = File.CreateText(carrierKeys_File))
                stream.Write(carrierKeys_textBox.Text);

            this.Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}