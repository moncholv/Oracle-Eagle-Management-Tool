using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Windows.STP_Data
{
    public partial class LoadedData : Base.FormBase
    {
        private bool InitLoad { get; set; }
        public Data.LoadedInfo LoadedInfo { get; set; }
        public bool SaveData { get; set; }

        public LoadedData(Data.LoadedInfo loadedInfo)
        {
            InitLoad = true;

            InitializeComponent();

            LoadedInfo = loadedInfo;

            if (LoadedInfo.STPs != null)
            {
                stpRat1_checkBox.Checked = LoadedInfo.STPs[0];
                stpRat1_checkBox.Enabled = LoadedInfo.STPs[0];
                stpRat2_checkBox.Checked = LoadedInfo.STPs[1];
                stpRat2_checkBox.Enabled = LoadedInfo.STPs[1];
                stpMil1_checkBox.Checked = LoadedInfo.STPs[2];
                stpMil1_checkBox.Enabled = LoadedInfo.STPs[2];
                stpMil2_checkBox.Checked = LoadedInfo.STPs[3];
                stpMil2_checkBox.Enabled = LoadedInfo.STPs[3];

                InitLoad = false;

                foreach (Data.Enum.ModuleType module in LoadedInfo.Modules)
                {
                    switch (module)
                    {
                        case Data.Enum.ModuleType.GTTSEL:
                            gttsel_checkBox.Enabled = true;
                            gttsel_checkBox.Checked = true;
                            break;

                        case Data.Enum.ModuleType.GTTSET:
                            gttset_checkBox.Enabled = true;
                            gttset_checkBox.Checked = true;
                            break;

                        case Data.Enum.ModuleType.GTA:
                            gta_checkBox.Enabled = true;
                            gta_checkBox.Checked = true;
                            break;

                        case Data.Enum.ModuleType.OPCODE:
                            opcode_checkBox.Enabled = true;
                            opcode_checkBox.Checked = true;
                            break;

                        case Data.Enum.ModuleType.MRNSET:
                            mrnset_checkBox.Enabled = true;
                            mrnset_checkBox.Checked = true;
                            break;

                        case Data.Enum.ModuleType.DSTN:
                            dstn_checkBox.Enabled = true;
                            dstn_checkBox.Checked = true;
                            break;

                        case Data.Enum.ModuleType.SLK:
                            slk_checkBox.Enabled = true;
                            slk_checkBox.Checked = true;
                            break;

                        case Data.Enum.ModuleType.ASSOC:
                            assoc_checkBox.Enabled = true;
                            assoc_checkBox.Checked = true;
                            break;

                        case Data.Enum.ModuleType.HOST:
                            host_checkBox.Enabled = true;
                            host_checkBox.Checked = true;
                            break;
                    }
                }
            }
        }        

        private void close_button_Click(object sender, EventArgs e)
        {
            SaveData = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadedInfo = new Data.LoadedInfo()
            {
                STPs = new List<bool>()
                {
                    stpRat1_checkBox.Checked,
                    stpRat2_checkBox.Checked,
                    stpMil1_checkBox.Checked,
                    stpMil2_checkBox.Checked
                },
                Modules = new List<Data.Enum.ModuleType>()
            };

            if (gttsel_checkBox.Checked) { LoadedInfo.Modules.Add(Data.Enum.ModuleType.GTTSEL); };
            if (gttset_checkBox.Checked) { LoadedInfo.Modules.Add(Data.Enum.ModuleType.GTTSET); };
            if (gta_checkBox.Checked) { LoadedInfo.Modules.Add(Data.Enum.ModuleType.GTA); };
            if (opcode_checkBox.Checked) { LoadedInfo.Modules.Add(Data.Enum.ModuleType.OPCODE); };
            if (mrnset_checkBox.Checked) { LoadedInfo.Modules.Add(Data.Enum.ModuleType.MRNSET); };
            if (dstn_checkBox.Checked) { LoadedInfo.Modules.Add(Data.Enum.ModuleType.DSTN); };
            if (slk_checkBox.Checked) { LoadedInfo.Modules.Add(Data.Enum.ModuleType.SLK); };
            if (assoc_checkBox.Checked) { LoadedInfo.Modules.Add(Data.Enum.ModuleType.ASSOC); };
            if (host_checkBox.Checked) { LoadedInfo.Modules.Add(Data.Enum.ModuleType.HOST); };

            SaveData = true;
            this.Close();
        }

        private void stp_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //if (!stpRat1_checkBox.Checked && !stpRat2_checkBox.Checked && !stpMil1_checkBox.Checked && !stpMil2_checkBox.Checked)
            //{
            //    var checkBoxes = type_groupBox.Controls.OfType<CheckBox>();
            //    foreach (CheckBox cBox in checkBoxes)
            //        cBox.Checked = false;
            //}

            ((CheckBox)sender).CheckState = CheckState.Checked;
        }
    }
}
