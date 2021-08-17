using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VRS_Eng_Manage_Tool.Base
{
    public class UserControlBase : UserControl
    {
        private IContainer components;
        public Image ButtonEnabled { get; set; }
        public Image ButtonDisabled { get; set; }
        public string FilePath { get; set; }
        public Data.Enum.OperationType OperationType { get; set; }
        public bool CompleteData { get; set; }
        public System.Collections.Generic.List<bool> ItemSelected { get; set; }

        public int ErrorTop = 995;
        public int ErrorLeft = 22;
        public int ErrorWidth = 304;
        public int ErrorHeight = 86;
        //987, 557

        public void InitializeComponent()
        {
            components = new Container();
            SuspendLayout();
            ResumeLayout(false);
        }

        public string SetExcelFilePath()
        {
            FilePath = MLVSoft_Common.Utilities.FilesManagement.SaveFileDialog("Excel", "xlsx", "Select path and file name for Excel file");
            if (!string.IsNullOrEmpty(FilePath))
            {
                OperationType = Data.Enum.OperationType.GenerateExcel;
            }

            return FilePath;
        }

        public void CopyValuesClipboard(ListBox listbox)
        {
            if (listbox.Items.Count > 0)
            {
                Business.Utilities.CopyListboxElementsToClipboard(listbox.Items);
                MessageBox.Show("Elements copied to clipboard", "Operation completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool CheckButtonEnabled(string controlName)
        {
            return ((Button)Controls.Find(controlName, true)[0]).Enabled;
        }

        public void SetButtonEnabled(string controlName, bool value)
        {
            ((Button)Controls.Find(controlName, true)[0]).Enabled = value;
        }

        public void SetGridStyle(DataGridView dgView)
        {
            for (int i = 0; i < dgView.ColumnCount; i++)
            {
                dgView.Columns[i].HeaderCell.Style.BackColor = Color.FromArgb(200, 6, 27);
                dgView.Columns[i].HeaderCell.Style.ForeColor = Color.White;
                dgView.Columns[i].HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            }
        }

        #region [ InitItemSelected ]
        public void InitItemSelected<T>()
        {
            ItemSelected = new System.Collections.Generic.List<bool>();
            for (int i = 0; i < Enum.GetNames(typeof(T)).Length; i++)
                ItemSelected.Add(false);
        }
        #endregion

        #region [ EnableButton ]
        public void EnableButton(Button filterButton, bool value)
        {
            filterButton.Enabled = value;
            filterButton.BackgroundImage = value ? ButtonEnabled : ButtonDisabled;
        }
        #endregion
    }
}