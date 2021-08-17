using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Windows.SFTP
{
    public partial class SelectionSTP : Form
    {
        public List<bool> StpValues { get; set; }

        public SelectionSTP(List<bool> stpValues)
        {
            InitializeComponent();

            StpValues = stpValues;

            RAT1_checkBox.Checked = stpValues[0];
            RAT2_checkBox.Checked = stpValues[1];
            MIL1_checkBox.Checked = stpValues[2];
            MIL2_checkBox.Checked = stpValues[3];
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {
            StpValues = new List<bool>();
            StpValues.Add(RAT1_checkBox.Checked);
            StpValues.Add(RAT2_checkBox.Checked);
            StpValues.Add(MIL1_checkBox.Checked);
            StpValues.Add(MIL2_checkBox.Checked);

            if (StpValues.Contains(true))
                this.Close();
            else
                MessageBox.Show("At least one STP has to be selected", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void allStps_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            RAT1_checkBox.Checked = allStps_checkBox.Checked;
            RAT2_checkBox.Checked = allStps_checkBox.Checked;
            MIL1_checkBox.Checked = allStps_checkBox.Checked;
            MIL2_checkBox.Checked = allStps_checkBox.Checked;
        }
    }
}
