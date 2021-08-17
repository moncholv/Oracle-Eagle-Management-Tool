using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Windows.Audits
{
    public partial class Loopsets : Base.FormBase
    {
        List<Data.Audits.LoopsetData> LoopsetInfo { get; set; }

        public Loopsets(List<Data.Audits.LoopsetData> loopsetErrors)
        {
            InitializeComponent();
            LoopsetInfo = loopsetErrors;

            loopsetsData_dataGridView.DataSource = GetGridColumns();
            loopsetsData_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {
            var gridColumns = from t in LoopsetInfo
                              orderby t.Table.ToString()
                              select new
                              {
                                  Table = t.Table,
                                  GTA = t.Gta,
                                  End_GTA = t.End_Gta,
                                  DPC = t.DPC,
                                  Loopset = t.Loopset,
                                  Suggestion = t.Suggested_Loopset
                              };

            return gridColumns.ToList();
        }

        #endregion

        #region [ Excel Button ]
        private void excel_button_Click(object sender, EventArgs e)
        {
            FilePath = MLVSoft_Common.Utilities.FilesManagement.SaveFileDialog("Excel", "xlsx", "Select path and file name for Excel file");
            try
            {
                Business.Excel.Audits.LoopsetErrors(LoopsetInfo, FilePath);

                generatedFile_linkLabel.Text = FilePath;
                fileGenerated_panel.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generatedFile_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fileGenerated_panel.Visible = false;
            System.Diagnostics.Process.Start(generatedFile_linkLabel.Text);
        }

        private void folder_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select, " + generatedFile_linkLabel.Text);
        }

        private void closeFileGenerated_button_Click(object sender, EventArgs e)
        {
            fileGenerated_panel.Visible = false;
        }
    }
}