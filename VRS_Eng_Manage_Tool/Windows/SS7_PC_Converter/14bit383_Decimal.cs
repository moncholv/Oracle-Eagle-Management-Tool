using System;
using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Windows.SS7_PC_Converter
{
    public partial class _14bit383_Decimal : Form
    {
        public _14bit383_Decimal()
        {
            InitializeComponent();

            pcValue1_textBox.KeyPress += new KeyPressEventHandler(Business.OnlyNumbers.OnlyNumbers_textBox_KeyPress);
            pcValue2_textBox.KeyPress += new KeyPressEventHandler(Business.OnlyNumbers.OnlyNumbers_textBox_KeyPress);
            pcValue3_textBox.KeyPress += new KeyPressEventHandler(Business.OnlyNumbers.OnlyNumbers_textBox_KeyPress);
        }

        private void Convert_button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(pcValue1_textBox.Text) && !string.IsNullOrEmpty(pcValue2_textBox.Text) && !string.IsNullOrEmpty(pcValue3_textBox.Text))
                resultValue_textBox.Text = Business.SS7_PointCode_Converter._14Bit383_toDecimal(string.Format("{0}-{1}-{2}", pcValue1_textBox.Text, pcValue2_textBox.Text, pcValue3_textBox.Text));
            else
                pcValue1_textBox.Focus();
        }

        private void copyToClipboard_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(!string.IsNullOrEmpty(resultValue_textBox.Text))
                Clipboard.SetText(resultValue_textBox.Text);
        }
    }
}
