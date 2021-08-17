using System;
using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Windows.SS7_PC_Converter
{
    public partial class Decimal_14bit383 : Base.FormBase
    {
        public Decimal_14bit383()
        {
            InitializeComponent();

            pcValue_textBox.KeyPress += new KeyPressEventHandler(Business.OnlyNumbers.OnlyNumbers_textBox_KeyPress);
        }

        private void Convert_button_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(pcValue_textBox.Text))
                resultValue_textBox.Text = Business.SS7_PointCode_Converter.DecimalToBit383(int.Parse(pcValue_textBox.Text));
        }

        private void copyToClipboard_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(!string.IsNullOrEmpty(resultValue_textBox.Text))
                Clipboard.SetText(resultValue_textBox.Text);
        }
    }
}
