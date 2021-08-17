using System.ComponentModel;
using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace VRS_Eng_Manage_Tool.Base
{
    public partial class FormBase : Form
    {
        public string FilePath { get; set; }

        public BackgroundWorker Action_backgroundWorker;

        #region [ FormBase --> (Constructor) ]
        public FormBase()
        {
            
        }
        #endregion        

        #region [ InitializeComponent ]
        public void InitializeComponent()
        {
            this.SuspendLayout();

            Action_backgroundWorker = new BackgroundWorker();
            this.Action_backgroundWorker.WorkerReportsProgress = true;
            this.Action_backgroundWorker.DoWork += new DoWorkEventHandler(this.RunProcess);
            this.Action_backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.Action_ProgressChanged);
            this.Action_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.Action_RunWorkerCompleted);

            // FormBase
            this.Name = "FormBase";
            this.ResumeLayout(false);
        }
        #endregion

        #region [ BackgroundWorker Methods ]
        public virtual void RunProcess(object sender, DoWorkEventArgs e)
        {

        }

        public virtual void Action_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        public virtual void Action_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        #endregion

        #region [ SetGridStyle ]
        public void SetGridStyle(DataGridView dgView)
        {
            for (int i = 0; i < dgView.ColumnCount; i++)
            {
                dgView.Columns[i].HeaderCell.Style.BackColor = Color.FromArgb(200, 6, 27);
                dgView.Columns[i].HeaderCell.Style.ForeColor = Color.White;
                dgView.Columns[i].HeaderCell.Style.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            }
        }
        #endregion
    }
}