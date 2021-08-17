using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using LinqKit;
using System.Windows.Forms;

using DATA_ENUM = VRS_Eng_Manage_Tool.Data.Enum;
using System.Text;

namespace VRS_Eng_Manage_Tool
{
    public partial class Main_Form : Base.FormBase
    {
        Color CommonColor = Color.WhiteSmoke;
        Color GroupColor1 = Color.FromArgb(189, 215, 238);
        Color GroupColor2 = Color.FromArgb(198, 224, 180);

        const string ClearButtonName = "clear_button";       
        
        const string TabAdvSearch = "Advanced Search";
        const string TabOperator = "Operator";
        const string TabAgreements = "Agreements";
        const string TabOST = "OST";
        const string TabAudit = "STP Audit";

        const int showMessageLeft = 994;
        const int showMessageTop = 63;
        const int showOpErrorMessageLeft = 40;
        const int showOpErrorMessageTop = 102;

        #region [ ---- Variables ---- ]
        bool ClearAll { get; set; }
        bool GtaLoaded { get; set; }
        bool OpcodeLoaded { get; set; }
        bool GttselLoaded { get; set; }
        bool GttsetLoaded { get; set; }
        bool MrnsetLoaded { get; set; }
        bool MapsetLoaded { get; set; }
        bool DstnLoaded { get; set; }
        bool SlkLoaded { get; set; }
        bool AssocLoaded { get; set; }
        bool HostLoaded { get; set; }
        bool LoopsetLoaded { get; set; }
        bool ttMapLoaded { get; set; }

        private List<bool> StpValues { get; set; }
        DATA_ENUM.STP FirstLoadedSet { get; set; }

        DATA_ENUM.OperationType OperationType { get; set; }
        DATA_ENUM.ImportMode ImportMode { get; set; }
        DATA_ENUM.SearchType SearchType { get; set; }
        DATA_ENUM.ExcelType ExcelType { get; set; }
        DATA_ENUM.OST_Types OstType { get; set; }
        DATA_ENUM.OST_Types AuditType { get; set; }
        DATA_ENUM.STP SelectedSTP { get; set; }
        Data.ResultItem ActionResult { get; set; }

        UserControls.OST.GTA GtaUC { get; set; }
        UserControls.OST.OPCODE OpcodeUC { get; set; }
        UserControls.OST.GTTSEL GttselUC { get; set; }
        UserControls.OST.GTTSET GttsetUC { get; set; }
        UserControls.OST.MRNSET MrnsetUC { get; set; }
        UserControls.OST.MAPSET MapsetUC { get; set; }
        UserControls.OST.DSTN DstnUC { get; set; }
        UserControls.OST.SLK SlkUC { get; set; }
        UserControls.OST.ASSOC AssocUC { get; set; }
        UserControls.OST.HOST HostUC { get; set; }
        UserControls.OST.LOOPSET LoopsetUC { get; set; }
        UserControls.OST.TTMAP TTMapUC { get; set; }

        List<Data.Audits.LoopsetData> LoopsetInfo { get; set; }

        string ImportStatusMessage { get; set; }

        Dictionary<DATA_ENUM.STP, Data.OST.STP_Info> STPsInfo { get; set; }
        Dictionary<DATA_ENUM.STP, Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>> AuditData { get; set; }
        Tuple<bool, bool, DATA_ENUM.RangeType, DATA_ENUM.RangeType> AgreementsResult { get; set; }
        Data.OperatorData OperatorData { get; set; }

        private static List<Data.Romina.RominaAgent> RominaData { get; set; }
        #endregion

        #region [ -----> Constructor <----- ]
        public Main_Form()
        {
            InitializeComponent();

            var attribute = System.Reflection.Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(System.Reflection.AssemblyDescriptionAttribute), false)
                    .Cast<System.Reflection.AssemblyDescriptionAttribute>().FirstOrDefault();

            if (attribute != null)
                Text = string.Format("{0} v{1}", attribute.Description, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);

            search_tabControl.Selecting += new TabControlCancelEventHandler(SearchtabControl_Selecting);
            stps_tabControl.Selecting += new TabControlCancelEventHandler(stps_tabControl_Selecting);
            stps_tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            stps_tabControl.DrawItem += new DrawItemEventHandler(stps_tabControl_DrawItem);
            fileGenerated_panel.Paint += new PaintEventHandler(fileGenerated_panel_Paint);
            advancedSearchBox_textBox.KeyDown += Search_textBox_KeyDown;
            advancedSearchResult_dataGridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(advancedSearchResult_dataGridView_DataBindingComplete);
            advancedSearchResult_dataGridView.EnableHeadersVisualStyles = false;
            advancedSearchResult_dataGridView.CellClick += new DataGridViewCellEventHandler(advancedSearchResult_dataGridView_CellEnter);
            operatorMgtSearch_textBox.KeyPress += new KeyPressEventHandler(MLVSoft_Common.Utilities.OnlyNumbers.OnlyNumbers_textBox_KeyPress);

            agreementsTsc1_textBox.KeyDown += SearchAgreements;
            agreementsTsc2_textBox.KeyDown += SearchAgreements;

            operatorTscSearch_textBox.KeyDown += SearchOperator;
            operatorMgtSearch_textBox.KeyDown += SearchOperator;
            operatorImsiSearch_textBox.KeyDown += SearchOperator;

            auditDetails_dataGridView.EnableHeadersVisualStyles = false;

            SetTabHeader(new List<TabPage>() { gta_tabPage, opcode_tabPage, gttsel_tabPage, gttset_tabPage, slk_tabPage, mapset_tabPage, loopset_tabPage, ttmap_tabPage }, CommonColor);
            SetTabHeader(new List<TabPage>() { mrnset_tabPage, dstn_tabPage }, GroupColor1);
            SetTabHeader(new List<TabPage>() { assoc_tabPage, host_tabPage }, GroupColor2);

            SearchType = DATA_ENUM.SearchType.AdvancedSearch;
            OstType = DATA_ENUM.OST_Types.GTA;

            STPsInfo = new Dictionary<DATA_ENUM.STP, Data.OST.STP_Info>();
            ClearAll = GtaLoaded = OpcodeLoaded = GttselLoaded = GttsetLoaded = MrnsetLoaded = MapsetLoaded = DstnLoaded = SlkLoaded = AssocLoaded = HostLoaded = LoopsetLoaded  = ttMapLoaded = false;

            //Marcamos como activo solo el primer STP (RAT1) por defecto
            StpValues = new List<bool>();
            StpValues.Add(true);
            StpValues.AddRange(Enumerable.Range(1, 3).Select(x => false));

            completeDataToolStripMenuItem.Checked = Properties.Settings.Default.Complete;

            ImportStatusMessage = "Importing {0} data";
            WorkMessage_label.Text = string.Empty;

            #region [ Action BackgroundWorker ]
            Action_backgroundWorker = new BackgroundWorker();
            Action_backgroundWorker.DoWork += new DoWorkEventHandler(RunProcess);
            Action_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Action_RunWorkerCompleted);
            Action_backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(Action_ProgressChanged);
            Action_backgroundWorker.WorkerReportsProgress = true;
            #endregion
        }
        #endregion


        #region [ Background Worker Process ]

        #region [ ---> Run Process ]
        public override void RunProcess(object sender, DoWorkEventArgs e)
        {
            switch (OperationType)
            {
                #region [ ImportSTP ]
                case DATA_ENUM.OperationType.ImportSTP:

                    ActionResult = new Data.ResultItem();

                    switch (ImportMode)
                    {
                        case DATA_ENUM.ImportMode.All:
                            GetAllSTPs_Data();
                            break;

                        case DATA_ENUM.ImportMode.GTA:
                            GetGTA_Data();
                            break;

                        case DATA_ENUM.ImportMode.OPCODE:
                            GetOpCodeData();
                            break;

                        case DATA_ENUM.ImportMode.GTTSEL:
                            GetGTTSelData();
                            break;

                        case DATA_ENUM.ImportMode.GTTSET:
                            GetGTTSetData();
                            break;

                        case DATA_ENUM.ImportMode.MRNSET:
                            GetMrnsetData();
                            break;

                        case DATA_ENUM.ImportMode.MAPSET:
                            GetMapsetData();
                            break;

                        case DATA_ENUM.ImportMode.DSTN:
                            GetDstnData();
                            break;

                        case DATA_ENUM.ImportMode.SLK:
                            GetSlkData();
                            break;

                        case DATA_ENUM.ImportMode.ASSOC:
                            GetAssocData();
                            break;

                        case DATA_ENUM.ImportMode.HOST:
                            GetHostData();
                            break;

                        case DATA_ENUM.ImportMode.LOOPSETS:
                            GetLoopsetsData();
                            break;

                        case DATA_ENUM.ImportMode.TTMAP:
                            GetTTMapData();
                            break;
                    }
                    break;
                #endregion

                #region [ GenerateExcel ]
                case DATA_ENUM.OperationType.GenerateExcel:
                    switch (SearchType)
                    {
                        case DATA_ENUM.SearchType.AdvancedSearch:

                            break;
                            
                        case DATA_ENUM.SearchType.OST:
                            OstGenerateExcels();
                            break;

                        case DATA_ENUM.SearchType.Audits:
                            AuditGenerateExcel();
                            break;
                    }
                    break;
                #endregion
                
                case DATA_ENUM.OperationType.Audits:
                    Audit();
                    break;
                
                case DATA_ENUM.OperationType.SearchOperator:
                    SearchOperator();
                    break;

                case DATA_ENUM.OperationType.AuditLoopsets:
                    AuditLoopsets();
                    break;
            }
        }
        #endregion

        #region [ ---> RunWorker Completed ]
        public override void Action_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string successMessage = null;
            Working_pictureBox.Visible = false;
            WorkMessage_label.Visible = false;
            sTPsToolStripMenuItem.Enabled = true;
            confluenceToolStripMenuItem.Enabled = true;
            search_tabControl.Enabled = true;

            if (ActionResult.Result && OperationType == DATA_ENUM.OperationType.ImportSTP && (ImportMode == DATA_ENUM.ImportMode.All || ImportMode == DATA_ENUM.ImportMode.GTA))
                agreementsSearch_panel.Enabled = RominaData != null;

            if (ActionResult.Result && OperationType == DATA_ENUM.OperationType.ImportSTP && (ImportMode == DATA_ENUM.ImportMode.All || ImportMode == DATA_ENUM.ImportMode.DSTN))
                buildReportToolStripMenuItem.Enabled = true;

            switch (OperationType)
            {
                #region [ ImportSTP ]
                case DATA_ENUM.OperationType.ImportSTP:
                    switch (ImportMode)
                    {
                        case DATA_ENUM.ImportMode.All:
                            successMessage = "All STP's";
                            break;

                        default:
                            successMessage = ImportMode.ToString();
                            break;
                    }

                    SetDataLoaded();
                    ShowActionResult(ActionResult, string.Format("{0} data loaded", successMessage), "STP Data");
                    break;
                #endregion

                #region [ GenerateExcel ]
                case DATA_ENUM.OperationType.GenerateExcel:
                    switch (SearchType)
                    {
                        case DATA_ENUM.SearchType.AdvancedSearch:

                            break;

                        case DATA_ENUM.SearchType.OST:
                            ShowActionResult(ActionResult, "Excel file generated", "OST Data");

                            if (ActionResult.Result)
                            {
                                fileGenerated_panel.Visible = true;
                                generatedFile_linkLabel.Text = FilePath;

                                SearchType = (DATA_ENUM.SearchType)Enum.Parse(typeof(DATA_ENUM.SearchType), search_tabControl.SelectedTab.Text.Replace(" ", ""));
                            }
                            else
                                MessageBox.Show(ActionResult.Message, "File opened", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;

                        case DATA_ENUM.SearchType.Audits:
                            AuditType = (DATA_ENUM.OST_Types)Enum.Parse(typeof(DATA_ENUM.OST_Types), auditType_comboBox.Text);
                            ShowActionResult(ActionResult, "Excel file generated", "OST Data");

                            if (ActionResult.Result)
                            {
                                fileGenerated_panel.Visible = true;
                                generatedFile_linkLabel.Text = FilePath;
                            }
                            else
                                MessageBox.Show(ActionResult.Message, "File opened", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    break;
                #endregion

                case DATA_ENUM.OperationType.SearchOperator:
                    ShowOperatorResult();
                    break;

                case DATA_ENUM.OperationType.Audits:
                    ShowAuditResult();
                    break;

                case DATA_ENUM.OperationType.AuditLoopsets:
                    if (LoopsetInfo != null)
                    {
                        Windows.Audits.Loopsets loopsetsAudit = new Windows.Audits.Loopsets(LoopsetInfo);
                        loopsetsAudit.ShowDialog();

                        LoopsetInfo = null;
                    }
                    else
                        ShowMessage(MessageTimer_label, "No loopset inconsistencies found.", false, showMessageLeft, showMessageTop, 304, 26);
            break;
            }

            this.Cursor = Cursors.Default;
        }
        #endregion

        #region [ ---> Action Progress Changed ]
        public override void Action_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is String)
                this.WorkMessage_label.Text = e.UserState as String;
        }
        #endregion

        #endregion


        #region [ PerformAction ]
        private void PerformAction()
        {
            Working_pictureBox.Visible = true;
            WorkMessage_label.Visible = true;
            sTPsToolStripMenuItem.Enabled = false;
            confluenceToolStripMenuItem.Enabled = false;
            search_tabControl.Enabled = false;
            Cursor = Cursors.WaitCursor;

            Action_backgroundWorker.RunWorkerAsync();
        }
        #endregion


        #region [ ------- Menu options ------- ]

        #region [ ---- STPs ---- ]
        private void selectSTPsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.SFTP.SelectionSTP stpValues = new Windows.SFTP.SelectionSTP(StpValues);
            stpValues.ShowDialog();

            StpValues = stpValues.StpValues;
        }

        private void setInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.SFTP.SFTP_values sftpValues = new Windows.SFTP.SFTP_values();
            sftpValues.ShowDialog();
        }

        private void completeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Complete = completeDataToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();

            SetDataLoaded();
        }

        private void freeMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FreeSTPMemory();
            ShowMessage(MessageTimer_label, "Freed memory", false, showMessageLeft, showMessageTop, 304, 26);
        }

        private void loadedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.LoadedInfo loadedInfo = new Data.LoadedInfo();
            loadedInfo.Modules = new List<DATA_ENUM.ModuleType>();

            if (STPsInfo.Select(s => s.Value.GTA_Data != null).Contains(true)) { loadedInfo.Modules.Add(DATA_ENUM.ModuleType.GTA); }
            if (STPsInfo.Select(s => s.Value.OpCodeData != null).Contains(true)) { loadedInfo.Modules.Add(DATA_ENUM.ModuleType.OPCODE); }
            if (STPsInfo.Select(s => s.Value.GTTSelData != null).Contains(true)) { loadedInfo.Modules.Add(DATA_ENUM.ModuleType.GTTSEL); }
            if (STPsInfo.Select(s => s.Value.GTTSetData != null).Contains(true)) { loadedInfo.Modules.Add(DATA_ENUM.ModuleType.GTTSET); }
            if (STPsInfo.Select(s => s.Value.MrnsetData != null).Contains(true)) { loadedInfo.Modules.Add(DATA_ENUM.ModuleType.MRNSET); }
            if (STPsInfo.Select(s => s.Value.DstnData != null).Contains(true)) { loadedInfo.Modules.Add(DATA_ENUM.ModuleType.DSTN); }
            if (STPsInfo.Select(s => s.Value.SlkData != null).Contains(true)) { loadedInfo.Modules.Add(DATA_ENUM.ModuleType.SLK); }
            if (STPsInfo.Select(s => s.Value.AssocData != null).Contains(true)) { loadedInfo.Modules.Add(DATA_ENUM.ModuleType.ASSOC); }
            if (STPsInfo.Select(s => s.Value.HostData != null).Contains(true)) { loadedInfo.Modules.Add(DATA_ENUM.ModuleType.HOST); }
            if (STPsInfo.Select(s => s.Value.LoopsetData != null).Contains(true)) { loadedInfo.Modules.Add(DATA_ENUM.ModuleType.LOOPSET); }
            if (STPsInfo.Select(s => s.Value.TTMapData != null).Contains(true)) { loadedInfo.Modules.Add(DATA_ENUM.ModuleType.TTMAP); }

            if (loadedInfo.Modules.Count > 0)
                loadedInfo.STPs = StpValues;

            Windows.STP_Data.LoadedData loadedData = new Windows.STP_Data.LoadedData(loadedInfo);
            loadedData.ShowDialog();

            if (loadedData.SaveData)
            {
                if (loadedData.LoadedInfo.STPs.Contains(true))
                {
                    for (int index = 0; index < 4; index++)
                        if (!loadedData.LoadedInfo.STPs[index]) { RemoveStpInfo((DATA_ENUM.STP)index); }

                    if (loadedData.LoadedInfo.Modules.Count > 0)
                    {
                        List<DATA_ENUM.ModuleType> existingModules = Enum.GetValues(typeof(DATA_ENUM.ModuleType)).Cast<DATA_ENUM.ModuleType>().ToList();
                        List<DATA_ENUM.ModuleType> modulesRemove = existingModules.Except(loadedData.LoadedInfo.Modules).ToList();

                        foreach (DATA_ENUM.ModuleType module in modulesRemove)
                        {
                            switch (module)
                            {
                                case DATA_ENUM.ModuleType.GTTSEL:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].GTTSelData = null);
                                    break;

                                case DATA_ENUM.ModuleType.GTTSET:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].GTTSetData = null);
                                    break;

                                case DATA_ENUM.ModuleType.GTA:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].GTA_Data = null);
                                    break;

                                case DATA_ENUM.ModuleType.OPCODE:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].OpCodeData = null);
                                    break;

                                case DATA_ENUM.ModuleType.MRNSET:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].MrnsetData = null);
                                    break;

                                case DATA_ENUM.ModuleType.MAPSET:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].MapsetData = null);
                                    break;

                                case DATA_ENUM.ModuleType.DSTN:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].DstnData = null);
                                    break;

                                case DATA_ENUM.ModuleType.SLK:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].SlkData = null);
                                    break;

                                case DATA_ENUM.ModuleType.ASSOC:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].AssocData = null);
                                    break;

                                case DATA_ENUM.ModuleType.HOST:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].HostData = null);
                                    break;

                                case DATA_ENUM.ModuleType.LOOPSET:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].LoopsetData = null);
                                    break;

                                case DATA_ENUM.ModuleType.TTMAP:
                                    STPsInfo.Keys.ToList().ForEach(k => STPsInfo[k].TTMapData = null);
                                    break;
                            }
                        }

                        GC.Collect();
                        SetDataLoaded();
                    }
                    else
                        FreeSTPMemory();
                }
                else
                    FreeSTPMemory();
            }
        }

        private void RemoveStpInfo(DATA_ENUM.STP stp)
        {
            if (STPsInfo.ContainsKey(stp))
                STPsInfo.Remove(stp);
        }

        #region [ --- Import STPs Data --- ]

        private bool CheckPaths()
        {
            bool result = true;

            if(string.IsNullOrEmpty(Properties.Settings.Default.LocalPath) || string.IsNullOrEmpty(Properties.Settings.Default.remotePath) || string.IsNullOrEmpty(Properties.Settings.Default.server))
            {
                Windows.SFTP.SFTP_values sftpValues = new Windows.SFTP.SFTP_values();
                sftpValues.ShowDialog();
                result = false;                
            }

            return result;
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.All;

                PerformAction();
            }
        }

        private void gTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.GTA;
                PerformAction();
            }
        }

        private void opCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.OPCODE;
                PerformAction();
            }
        }

        private void mRNSETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.MRNSET;
                PerformAction();
            }
        }

        private void mAPSETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.MAPSET;
                PerformAction();
            }
        }

        private void dSTNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.DSTN;
                PerformAction();
            }
        }

        private void sLKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.SLK;
                PerformAction();
            }
        }

        private void aSSOCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.ASSOC;
                PerformAction();
            }
        }

        private void hOSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.HOST;
                PerformAction();
            }
        }

        private void gTTSELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.GTTSEL;
                PerformAction();
            }
        }

        private void gTTSETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.GTTSET;
                PerformAction();
            }
        }

        private void stpLoopsetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.LOOPSETS;
                PerformAction();
            }
        }

        private void tTMAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckPaths())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.TTMAP;
                PerformAction();
            }
        }
        #endregion

        #endregion

        #region [ ---- Reports ---- ]

        private void setKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.Reports.RTMT_keys rtmtKeys = new Windows.Reports.RTMT_keys();
            rtmtKeys.ShowDialog();
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilePath = MLVSoft_Common.Utilities.FilesManagement.SaveFileDialog("CSV", "csv", "Select path and file name for csv file");

            if (!string.IsNullOrEmpty(FilePath))
            {
                List<string> dataList = GetRtmtEnrichmentData("|");
                StringBuilder cadena = new StringBuilder(dataList.Count);
                foreach (string item in dataList)
                    cadena.AppendLine(item);

                using (StreamWriter swriter = new StreamWriter(FilePath)) { swriter.Write(cadena.ToString()); }

                ShowActionResult(new Data.ResultItem(true), "CSV file generated", "RTMT Enrichment file");
                fileGenerated_panel.Visible = true;
                generatedFile_linkLabel.Text = FilePath;

            }
        }        

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilePath = MLVSoft_Common.Utilities.FilesManagement.SaveFileDialog("Excel", "xls", "Select path and file name for Excel file");

            if (!string.IsNullOrEmpty(FilePath))
            {
                try
                {
                    OfficeOpenXml.ExcelPackage xlPackage = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelPackage(FilePath);
                    Business.Excel.Reports.RTMT_Report(xlPackage, GetRtmtEnrichmentData(";"));
                    xlPackage.Save();
                    xlPackage.Dispose();

                    ShowActionResult(new Data.ResultItem(true), "Excel file generated", "RTMT Enrichment file");
                    fileGenerated_panel.Visible = true;
                    generatedFile_linkLabel.Text = FilePath;
                }
                catch (IOException ioEx)
                {
                    ShowActionResult(new Data.ResultItem(false, "You have to close the existing file first"), "Excel file generated", "OST Data");
                }
            }
        }

        #region [ GetRtmtEnrichmentData ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        private List<string> GetRtmtEnrichmentData(string separator)
        {
            List<string> ipbbKeys = File.ReadLines(string.Format(@"{0}RTMT_keys\ipbbkeys.txt", AppDomain.CurrentDomain.BaseDirectory)).ToList();
            List<string> internalKeys = File.ReadLines(string.Format(@"{0}RTMT_keys\internalkeys.txt", AppDomain.CurrentDomain.BaseDirectory)).ToList();
            Dictionary<string, string> carrierKeys = File.ReadLines(string.Format(@"{0}RTMT_keys\carrierkeys.txt", AppDomain.CurrentDomain.BaseDirectory)).Select(line => line.Split(';')).ToDictionary(line => line[0], line => line[1]);

            List<string> cadena = new List<string>();

            cadena.Add(string.Format("SP{0}SPID{0}CARRIER{0}VF_INTERNAL", separator));

            foreach (string point in STPsInfo.First().Value.DstnData.Where(w => w.RC != "No").Select(s => s.DPC_Dec).Distinct())
            {
                Data.OST.DSTN_Data dstnData = STPsInfo.First().Value.DstnData.Where(w => w.DPC_Dec == point).First();
                string key = dstnData.LSN.Substring(0, 4);

                cadena.Add(string.Format("{1}{0}{2}{0}{3}{0}{4}",
                    separator,
                    dstnData.DPC_Dec,
                    dstnData.CLLI,
                    ipbbKeys.Any(f => dstnData.LSN.StartsWith(f)) ? "VF IPBB" : carrierKeys.ContainsKey(key) ? carrierKeys[key].ToUpper() : key.ToUpper(),
                    internalKeys.Any(f => dstnData.CLLI.StartsWith(f)) ? "Y" : string.Empty));
            }

            return cadena;
        }
        #endregion

        #endregion

        #region [ --- SS7 PC Converter --- ]

        #region [ Decimal --> 14 bit (3-8-3) ]
        private void decimal14Bit383ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.SS7_PC_Converter.Decimal_14bit383 converter = new Windows.SS7_PC_Converter.Decimal_14bit383();
            converter.ShowDialog();
        }
        #endregion

        #region [ 14 bit (3-8-3) --> Decimal ]
        private void bit383DecimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.SS7_PC_Converter._14bit383_Decimal converter = new Windows.SS7_PC_Converter._14bit383_Decimal();
            converter.ShowDialog();
        }
        #endregion

        #endregion

        private void getFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool action = true;

            if (string.IsNullOrEmpty(Properties.Settings.Default.server) || string.IsNullOrEmpty(Properties.Settings.Default.remotePath) || string.IsNullOrEmpty(Properties.Settings.Default.LocalPath))
            {
                action = false;

                Windows.SFTP.SFTP_values sftpValues = new Windows.SFTP.SFTP_values();
                sftpValues.ShowDialog();
                if (sftpValues.HasAllValues())
                    action = true;
            }

            if (action)
            {
                Windows.SFTP.User_Pass getFiles = new Windows.SFTP.User_Pass();
                getFiles.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region [ ----- Citrix Launcher ----- ]
        private void callTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenIcaFile(Data.Enum.icaFiles.CallTrace);
        }

        private void webCallTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenIcaFile(Data.Enum.icaFiles.WebCallTrace);
        }

        private void ericssonOSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenIcaFile(Data.Enum.icaFiles.OST);
        }

        private void nGIMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenIcaFile(Data.Enum.icaFiles.NGIMA);
        }
        #endregion

        #endregion

        #region [ OpenIcaFile ]
        private void OpenIcaFile(Data.Enum.icaFiles icaFile)
        {
            string icaFilePath = string.Format("\\{0}.ica", icaFile.ToString());

            File.Copy(AppDomain.CurrentDomain.BaseDirectory + "\\ica_files" + icaFilePath, Path.GetTempPath() + icaFilePath, true);
            try
            {
                System.Diagnostics.Process.Start(Path.GetTempPath() + icaFilePath);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message + ". (" + icaFile.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openIcaFilesDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\ica_files");
        }
        #endregion

        #region [ ShowActionResult ]
        private void ShowActionResult(Data.ResultItem actionResult, string message, string section)
        {
            if (ActionResult.Result)
            {
                if (STPsInfo.Count > 0 && STPsInfo.First().Value.LoopsetData != null)
                    loopsetsToolStripMenuItem.Enabled = true;

                //////if (STPsInfo.Count > 0 && STPsInfo.First().Value.LoopsetData != null)
                //////    mTPConnectionsToolStripMenuItem.Enabled = true;

                freeMemoryToolStripMenuItem.Enabled = true;
                loadedDataToolStripMenuItem.Enabled = true;
                generateExcelToolStripMenuItem.Enabled = true;
                ShowMessage(MessageTimer_label, message, false, showMessageLeft, showMessageTop, 304, 26);
            }
            else
            {
                ShowMessage(MessageTimer_label, ActionResult.Message, true, 130, 300, 700, 75);
            }
        }
        #endregion

        #region [ Search TabControl Selecting ]
        private void SearchtabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage currentTab = (sender as TabControl).SelectedTab;

            switch (currentTab.Text.Trim())
            {
                case TabAdvSearch:
                    SearchType = DATA_ENUM.SearchType.AdvancedSearch;
                    break;

                case TabOST:
                    SearchType = DATA_ENUM.SearchType.OST;
                    LoadStpSection((DATA_ENUM.ModuleType)Enum.Parse(typeof(DATA_ENUM.ModuleType), stps_tabControl.SelectedTab.Text));
                    break;

                case TabAudit:
                    SearchType = DATA_ENUM.SearchType.Audits;
                    break;

                case TabAgreements:
                    agreementsTsc1_textBox.Focus();
                    break;
            }
        }
        #endregion

        #region [ Set Data Loaded ]
        private void SetDataLoaded()
        {
            try
            {
                FirstLoadedSet = GetFirstLoadedSet();

                rat1_pictureBox.BackgroundImage = STPsInfo.Keys.Contains(DATA_ENUM.STP.RAT1) ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                rat2_pictureBox.BackgroundImage = STPsInfo.Keys.Contains(DATA_ENUM.STP.RAT2) ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                mil1_pictureBox.BackgroundImage = STPsInfo.Keys.Contains(DATA_ENUM.STP.MIL1) ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                mil2_pictureBox.BackgroundImage = STPsInfo.Keys.Contains(DATA_ENUM.STP.MIL2) ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;

                switch (search_tabControl.SelectedTab.Text)
                {
                    case TabAdvSearch:

                        break;

                    case TabOST:
                        LoadStpSection((DATA_ENUM.ModuleType)Enum.Parse(typeof(DATA_ENUM.ModuleType), stps_tabControl.SelectedTab.Text));
                        break;

                    case TabAudit:

                        break;
                }

                gta_pictureBox.BackgroundImage = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].GTA_Data != null ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                opcode_pictureBox.BackgroundImage = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].OpCodeData != null ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                gttsel_pictureBox.BackgroundImage = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].GTTSelData != null ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                gttset_pictureBox.BackgroundImage = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].GTTSetData != null ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                mrnset_pictureBox.BackgroundImage = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].MrnsetData != null ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                dstn_pictureBox.BackgroundImage = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].DstnData != null ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                assoc_pictureBox.BackgroundImage = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].AssocData != null ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                slk_pictureBox.BackgroundImage = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].SlkData != null ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                host_pictureBox.BackgroundImage = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].HostData != null ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                loopset_pictureBox.BackgroundImage = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].LoopsetData != null ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;
                ttmap_pictureBox.BackgroundImage = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].TTMapData != null ? Properties.Resources.Checked_small : Properties.Resources.Unchecked_small;

                CheckAuditOptions();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ ShowMessage ]
        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="errorMessage"></param>
        public void ShowMessage(Label messageLabel, string message, bool errorMessage, int left, int top, int width, int height)
        {
            fileGenerated_panel.Visible = false;

            messageLabel.Left = left;
            messageLabel.Top = top;
            messageLabel.Size = new Size(width, height);
            this.Loading_timer.Interval = errorMessage ? 5000 : 1500;
            this.Loading_timer.Tick += new EventHandler(this.Analysis_timer_Tick);
            messageLabel.Text = message;
            messageLabel.Visible = true;
            messageLabel.BackColor = errorMessage ? Color.FromArgb(255, 115, 115) : Color.FromArgb(0, 102, 204);
            messageLabel.ForeColor = errorMessage ? Color.FromArgb(63, 54, 54) : Color.FromArgb(224, 255, 255);
            this.Loading_timer.Start();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Analysis_timer_Tick(object sender, EventArgs e)
        {
            Loading_timer.Stop();
            MessageTimer_label.Visible = false;
            unkownSearch_label.Visible = false;
            agreementsSearchMessage_label.Visible = false;
            operatorErrorMessage_label.Visible = false;
        }
        #endregion

        #region [ Build Message ]
        private void BuildMessage(object sender, EventArgs e)
        {
            Data.MessageItem messageItem = sender as Data.MessageItem;
            ShowMessage(MessageTimer_label, messageItem.Message, messageItem.ErrorMessage, messageItem.Left,
                messageItem.Top, messageItem.Width, messageItem.Height);
        }
        #endregion

        #region [ Get First Loaded Set ]
        private DATA_ENUM.STP GetFirstLoadedSet()
        {
            DATA_ENUM.STP firstElement = Data.Enum.STP.RAT1;

            for (int i = 0; i < StpValues.Count; i++)
            {
                if (StpValues[i])
                {
                    firstElement = (DATA_ENUM.STP)i;
                    break;
                }
            }

            return firstElement;
        }
        #endregion

        #region [ GenerateExcel ]
        private void GenerateExcel(object sender, EventArgs e)
        {
            OstType = (DATA_ENUM.OST_Types)Enum.Parse(typeof(DATA_ENUM.OST_Types), stps_tabControl.SelectedTab.Text);
            GenerateExcel(true);
        }

        private void GenerateExcel(bool setFilePath)
        {
            OperationType = DATA_ENUM.OperationType.GenerateExcel;
            bool generateFile = true;

            if (setFilePath)
            {
                switch (SearchType)
                {
                    #region [ STPs ]
                    case DATA_ENUM.SearchType.OST:
                        switch (OstType)
                        {
                            case DATA_ENUM.OST_Types.GTA:
                                FilePath = GtaUC.SetExcelFilePath();
                                break;

                            case DATA_ENUM.OST_Types.OPCODE:
                                FilePath = OpcodeUC.SetExcelFilePath();
                                break;

                            case DATA_ENUM.OST_Types.GTTSEL:
                                FilePath = GttselUC.SetExcelFilePath();
                                break;

                            case DATA_ENUM.OST_Types.GTTSET:
                                FilePath = GttsetUC.SetExcelFilePath();
                                break;

                            case DATA_ENUM.OST_Types.MRNSET:
                                FilePath = MrnsetUC.SetExcelFilePath();
                                break;

                            case DATA_ENUM.OST_Types.MAPSET:
                                FilePath = MapsetUC.SetExcelFilePath();
                                break;

                            case DATA_ENUM.OST_Types.DSTN:
                                FilePath = DstnUC.SetExcelFilePath();
                                break;

                            case DATA_ENUM.OST_Types.SLK:
                                FilePath = SlkUC.SetExcelFilePath();
                                break;

                            case DATA_ENUM.OST_Types.ASSOC:
                                FilePath = AssocUC.SetExcelFilePath();
                                break;

                            case DATA_ENUM.OST_Types.HOST:
                                FilePath = HostUC.SetExcelFilePath();
                                break;

                            case DATA_ENUM.OST_Types.LOOPSET:
                                FilePath = LoopsetUC.SetExcelFilePath();
                                break;

                            case DATA_ENUM.OST_Types.TTMAP:
                                FilePath = TTMapUC.SetExcelFilePath();
                                break;
                        }
                        break;
                    #endregion
                        
                    case DATA_ENUM.SearchType.Audits:
                        FilePath = MLVSoft_Common.Utilities.FilesManagement.SaveFileDialog("Excel", "xlsx", "Select path and file name for Excel file");
                        if (!string.IsNullOrEmpty(FilePath))
                        {
                            try { OfficeOpenXml.ExcelPackage xlPackage = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelPackage(FilePath); }
                            catch(IOException ioEx)
                            {
                                generateFile = false;
                                MessageBox.Show("You have to close the existing file first", "File opened", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            generateFile = false;
                        break;
                }
            }

            if(generateFile)
                PerformAction();
        }
        #endregion

        #region [ Generated File Section ]
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

        private void fileGenerated_panel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.fileGenerated_panel.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
        }

        private void generateExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilePath = MLVSoft_Common.Utilities.FilesManagement.SaveFileDialog("Excel", "xlsx", "Select path and file name for Excel file");
            if (!string.IsNullOrEmpty(FilePath))
            {
                SearchType = DATA_ENUM.SearchType.OST;
                OstType = DATA_ENUM.OST_Types.All;
                GenerateExcel(false);
            }
        }

        private void firstLoadedSTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilePath = MLVSoft_Common.Utilities.FilesManagement.SaveFileDialog("Excel", "xlsx", "Select path and file name for Excel file");
            if (!string.IsNullOrEmpty(FilePath))
            {
                ExcelType = DATA_ENUM.ExcelType.First;
                SearchType = DATA_ENUM.SearchType.OST;
                OstType = DATA_ENUM.OST_Types.All;
                GenerateExcel(false);
            }
        }

        private void allLoadedSTPsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilePath = MLVSoft_Common.Utilities.FilesManagement.SaveFileDialog("Excel", "xlsx", "Select path and file name for Excel file");
            if (!string.IsNullOrEmpty(FilePath))
            {
                ExcelType = DATA_ENUM.ExcelType.Complete;
                SearchType = DATA_ENUM.SearchType.OST;
                OstType = DATA_ENUM.OST_Types.All;
                GenerateExcel(false);
            }
        }
        #endregion

        #region [ --- Romina --- ]
        private void selectFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectRominaFile();
        }

        private void loadDattaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadRominaData();
        }

        private bool LoadRominaData()
        {
            bool search = true;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.RominaPath) || (string.IsNullOrEmpty(Properties.Settings.Default.RominaPath) && SelectRominaFile()))
            {
                try
                {
                    RominaData = Business.Romina.GetRominaData(Properties.Settings.Default.RominaPath);
                    rominaLoaded_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                    ShowMessage(MessageTimer_label, "Romina data loaded", false, showMessageLeft, showMessageTop, 304, 26);
                    advancedSearchBox_textBox.Enabled = true;
                    advancedSearch_button.Enabled = true;
                    operatorSearch_groupBox.Enabled = true;

                    if (!operatorSource_comboBox.Items.Contains("Romina"))
                    {
                        operatorSource_comboBox.Items.Add("Romina");
                        operatorSource_comboBox.SelectedIndex = 0;
                    }

                    if (SearchType == DATA_ENUM.SearchType.AdvancedSearch)
                        advancedSearchBox_textBox.Focus();

                    if (STPsInfo.Keys.Count > 0)
                        agreementsSearch_panel.Enabled = true;
                }
                catch (IOException ioEx)
                {
                    ShowMessage(MessageTimer_label, "The file is opened or it doesn't exist", true, showMessageLeft, showMessageTop, 304, 26);
                }
            }
            else
                search = false;

            return search;
        }

        private bool SelectRominaFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Please select Romina file path";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Properties.Settings.Default.RominaPath != openFileDialog.FileName)
                {
                    Properties.Settings.Default.RominaPath = openFileDialog.FileName;
                    Properties.Settings.Default.Save();
                }
                return true;
            }
            return false;
        }
        #endregion


        #region [ ---------------> STPs <--------------- ]

        #region [ -- STPs Data Loading -- ]

        #region [ Get ALL ]
        private void GetAllSTPs_Data()
        {
            ActionResult.Result = true;

            try
            {
                if (ActionResult.Result) { GetGTA_Data(); }
                if (ActionResult.Result) { GetOpCodeData(); }
                if (ActionResult.Result) { GetGTTSelData(); }
                if (ActionResult.Result) { GetGTTSetData(); }
                if (ActionResult.Result) { GetMrnsetData(); }
                if (ActionResult.Result) { GetMapsetData(); }
                if (ActionResult.Result) { GetDstnData(); }
                if (ActionResult.Result) { GetSlkData(); }
                if (ActionResult.Result) { GetAssocData(); }
                if (ActionResult.Result) { GetHostData(); }
                if (ActionResult.Result) { GetLoopsetsData(); }
                if (ActionResult.Result) { GetTTMapData(); }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get GTA Data ]
        private void GetGTA_Data()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "GTA"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.GTA_Data>> GTA_Data =
                    Business.Import_STP_data.GetGTA_Data(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in GTA_Data.Keys)
                {
                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].GTA_Data = GTA_Data[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get OPCODE Data ]
        private void GetOpCodeData()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "OPCODE"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.OPCODE_Data>> OpCodeData =
                    Business.Import_STP_data.GetOpCode_Data(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in OpCodeData.Keys)
                {
                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].OpCodeData = OpCodeData[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get GTTSEL Data ]
        private void GetGTTSelData()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "GTTSEL"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSEL_Data>> GTTSelData =
                    Business.Import_STP_data.GetGTTSelData(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in GTTSelData.Keys)
                {
                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].GTTSelData = GTTSelData[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get GTTSET Data ]
        private void GetGTTSetData()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "GTTSET"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSET_Data>> GTTSetData =
                    Business.Import_STP_data.GetGTTSetData(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in GTTSetData.Keys)
                {
                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].GTTSetData = GTTSetData[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get MRNSET Data ]
        private void GetMrnsetData()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "MRNSET"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.MRNSET_Data>> MrnsetData =
                    Business.Import_STP_data.GetMRNSET_Data(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in MrnsetData.Keys)
                {
                    // Añadimos el valor de CLLI en caso de que los datos de DSTN hayan sido importados
                    if (STPsInfo.Count > 0 && STPsInfo.Keys.Contains(stp) && STPsInfo[stp].DstnData != null)
                    {
                        foreach (Data.OST.MRNSET_Data item in MrnsetData[stp])
                            item.CLLI = STPsInfo[stp].DstnData.Where(w => w.DPC == item.PC).First().CLLI;
                    }

                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].MrnsetData = MrnsetData[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get MAPSET Data ]
        private void GetMapsetData()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "MAPSET"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.MAPSET_Data>> MapsetData =
                    Business.Import_STP_data.GetMAPSET_Data(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in MapsetData.Keys)
                {
                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].MapsetData = MapsetData[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get DSTN Data ]
        private void GetDstnData()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "DSTN"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.DSTN_Data>> DstnData =
                    Business.Import_STP_data.GetDSTN_Data(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in DstnData.Keys)
                {
                    // Añadimos el valor de CLLI a MRNSET en caso de que ya hubiera sido importado
                    if (STPsInfo.Count > 0 && STPsInfo.Keys.Contains(stp) && STPsInfo[stp].MrnsetData != null)
                    {
                        foreach (Data.OST.MRNSET_Data item in STPsInfo[stp].MrnsetData)
                            item.CLLI = DstnData[stp].Where(w => w.DPC == item.PC).First().CLLI;
                    }

                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].DstnData = DstnData[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get SLK Data ]
        private void GetSlkData()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "SLK"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.SLK_Data>> SlkData =
                    Business.Import_STP_data.GetSLK_Data(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in SlkData.Keys)
                {
                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].SlkData = SlkData[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get ASSOC Data ]
        private void GetAssocData()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "ASSOC"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.ASSOC_Data>> AssocData =
                    Business.Import_STP_data.GetAssocData(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in AssocData.Keys)
                {
                    // Añadimos las IPs en caso de que HOST ya hubiera sido importado
                    if (STPsInfo.Count > 0 && STPsInfo.Keys.Contains(stp) && STPsInfo[stp].HostData != null)
                    {
                        foreach (Data.OST.ASSOC_Data item in AssocData[stp])
                        {
                            item.LOCAL_IP = STPsInfo[stp].HostData.Where(w => w.HOST == item.LHOST).First().IPADDR;
                            var aLocalIP = !item.ALHOST.StartsWith("-") ? STPsInfo[stp].HostData.Where(w => w.HOST == item.ALHOST) : null;
                            item.ALOCAL_IP = aLocalIP != null && aLocalIP.Count() > 0 ? aLocalIP.First().IPADDR : "---";
                            var remoteIP = !item.RHOST.StartsWith("-") ? STPsInfo[stp].HostData.Where(w => w.HOST == item.RHOST) : null;
                            item.REMOTE_IP = remoteIP != null && remoteIP.Count() > 0 ? remoteIP.First().IPADDR : "---";
                            var aRemoteIP = !item.ARHOST.StartsWith("-") ? STPsInfo[stp].HostData.Where(w => w.HOST == item.ARHOST) : null;
                            item.AREMOTE_IP = aRemoteIP != null && aRemoteIP.Count() > 0 ? aRemoteIP.First().IPADDR : "---";
                        }
                    }

                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].AssocData = AssocData[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get HOST Data ]
        private void GetHostData()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "HOST"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.HOST_Data>> HostData =
                    Business.Import_STP_data.GetHostData(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in HostData.Keys)
                {
                    // Añadimos las IPs a ASSOC en caso de que ya hubiera sido importado
                    if (STPsInfo.Count > 0 && STPsInfo.Keys.Contains(stp) && STPsInfo[stp].AssocData != null)
                    {
                        foreach (Data.OST.ASSOC_Data item in STPsInfo[stp].AssocData)
                        {
                            item.LOCAL_IP = HostData[stp].Where(w => w.HOST == item.LHOST).First().IPADDR;
                            var aLocalIP = !item.ALHOST.StartsWith("-") ? HostData[stp].Where(w => w.HOST == item.ALHOST) : null;
                            item.ALOCAL_IP = aLocalIP != null && aLocalIP.Count() > 0 ? aLocalIP.First().IPADDR : "---";
                            var remoteIP = !item.RHOST.StartsWith("-") ? HostData[stp].Where(w => w.HOST == item.RHOST) : null;
                            item.REMOTE_IP = remoteIP != null && remoteIP.Count() > 0 ? remoteIP.First().IPADDR : "---";
                            var aRemoteIP = !item.ARHOST.StartsWith("-") ? HostData[stp].Where(w => w.HOST == item.ARHOST) : null;
                            item.AREMOTE_IP = aRemoteIP != null && aRemoteIP.Count() > 0 ? aRemoteIP.First().IPADDR : "---";
                        }
                    }

                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].HostData = HostData[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get LOOPSETS Data ]
        private void GetLoopsetsData()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "LOOPSET"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.LOOPSET_Data>> LoopsetData =
                    Business.Import_STP_data.GetLoopsetData(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in LoopsetData.Keys)
                {
                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].LoopsetData = LoopsetData[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #region [ Get TTMAP Data ]
        private void GetTTMapData()
        {
            ActionResult.Result = true;
            Action_backgroundWorker.ReportProgress(0, string.Format(ImportStatusMessage, "TTMAP"));

            try
            {
                Dictionary<DATA_ENUM.STP, List<Data.OST.TTMAP_Data>> TTMapData =
                    Business.Import_STP_data.GetTTMapData(StpValues, Properties.Settings.Default.LocalPath, Properties.Settings.Default.Complete);

                foreach (DATA_ENUM.STP stp in TTMapData.Keys)
                {
                    if (!STPsInfo.ContainsKey(stp))
                        STPsInfo.Add(stp, new Data.OST.STP_Info());

                    STPsInfo[stp].TTMapData = TTMapData[stp];
                }
            }
            catch (Exception ex)
            {
                ActionResult.Result = false;
                ActionResult.Message = ex.Message;
            }
        }
        #endregion

        #endregion

        #region [ STPs Tab Control Selecting ]
        private void stps_tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage currentTab = (sender as TabControl).SelectedTab;
            LoadStpSection((DATA_ENUM.ModuleType)Enum.Parse(typeof(DATA_ENUM.ModuleType), currentTab.Text.Trim()));
        }
        #endregion

        #region [ Load STP Section ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleType"></param>
        private void LoadStpSection(DATA_ENUM.ModuleType moduleType)
        {
            bool hasData = false;
            bool loadUC = false;

            DATA_ENUM.STP FirstLoadedSet = GetFirstLoadedSet();

            switch (moduleType)
            {
                #region [ GTA ]
                case DATA_ENUM.ModuleType.GTA:
                    OstType = DATA_ENUM.OST_Types.GTA;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].GTA_Data != null;
                    if (hasData)
                    {
                        if (GtaLoaded && completeDataToolStripMenuItem.Checked != GtaUC.CompleteData)
                        {
                            gtaStp_comboBox.Items.Clear();
                            gta_panel.Controls.Remove(GtaUC);
                            GtaUC = null;
                            loadUC = true;
                        }
                        else if (!GtaLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            gtaStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            gtaStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), gtaStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.GTA);
                            gta_panel.Controls.Add(GtaUC);

                            gtaGlobal_panel.Visible = true;
                            gta_panel.Enabled = hasData;
                        }

                        gtaClearAll_button.Enabled = ClearAll;
                    }
                    break;
                #endregion

                #region [ OPCODE ]
                case DATA_ENUM.ModuleType.OPCODE:
                    OstType = DATA_ENUM.OST_Types.OPCODE;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].OpCodeData != null;

                    if (hasData)
                    {
                        if (OpcodeLoaded && completeDataToolStripMenuItem.Checked != OpcodeUC.CompleteData)
                        {
                            opStp_comboBox.Items.Clear();
                            opcode_panel.Controls.Remove(OpcodeUC);
                            OpcodeUC = null;
                            loadUC = true;
                        }
                        else if (!OpcodeLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            opStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            opStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), opStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.OPCODE);
                            opcode_panel.Controls.Add(OpcodeUC);

                            opcodeGlobal_panel.Visible = true;
                            opcode_panel.Enabled = hasData;
                        }

                        opClearAll_button.Enabled = ClearAll;
                    }
                    break;
                #endregion

                #region [ GTTSEL ]
                case DATA_ENUM.ModuleType.GTTSEL:
                    OstType = DATA_ENUM.OST_Types.GTTSEL;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].GTTSelData != null;
                    if (hasData)
                    {
                        if (GttselLoaded && completeDataToolStripMenuItem.Checked != GttselUC.CompleteData)
                        {
                            gttselStp_comboBox.Items.Clear();
                            gttsel_panel.Controls.Remove(GttselUC);
                            GttselUC = null;
                            loadUC = true;
                        }
                        else if (!GttselLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            gttselStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            gttselStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), gttselStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.GTTSEL);
                            gttsel_panel.Controls.Add(GttselUC);

                            gttselGlobal_panel.Visible = true;
                            gttsel_panel.Enabled = hasData;
                        }

                        gttselClearAll_button.Enabled = ClearAll;
                    }
                    break;
                #endregion

                #region [ GTTSET ]
                case DATA_ENUM.ModuleType.GTTSET:
                    OstType = DATA_ENUM.OST_Types.GTTSET;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].GTTSetData != null;
                    if (hasData)
                    {
                        if (GttsetLoaded && completeDataToolStripMenuItem.Checked != GttsetUC.CompleteData)
                        {
                            gttsetStp_comboBox.Items.Clear();
                            gttset_panel.Controls.Remove(GttsetUC);
                            GttsetUC = null;
                            loadUC = true;
                        }
                        else if (!GttsetLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            gttsetStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            gttsetStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), gttsetStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.GTTSET);
                            gttset_panel.Controls.Add(GttsetUC);

                            gttsetGlobal_panel.Visible = true;
                            gttset_panel.Enabled = hasData;
                        }

                        gttselClearAll_button.Enabled = ClearAll;
                    }
                    break;
                #endregion

                #region [ MRNSET ]
                case DATA_ENUM.ModuleType.MRNSET:
                    OstType = DATA_ENUM.OST_Types.MRNSET;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].MrnsetData != null;
                    if (hasData)
                    {
                        if (MrnsetLoaded && completeDataToolStripMenuItem.Checked != MrnsetUC.CompleteData)
                        {
                            mrnsetStp_comboBox.Items.Clear();
                            mrnset_panel.Controls.Remove(MrnsetUC);
                            MrnsetUC = null;
                            loadUC = true;
                        }
                        else if (!MrnsetLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            mrnsetStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            mrnsetStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), mrnsetStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.MRNSET);
                            mrnset_panel.Controls.Add(MrnsetUC);

                            mrnsetGlobal_panel.Visible = true;
                            mrnset_panel.Enabled = hasData;
                        }

                        mrnsetClearAll_button.Enabled = ClearAll;
                    }
                    break;
                #endregion

                #region [ MAPSET ]
                case DATA_ENUM.ModuleType.MAPSET:
                    OstType = DATA_ENUM.OST_Types.MAPSET;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].MapsetData != null;
                    if (hasData)
                    {
                        if (MapsetLoaded && completeDataToolStripMenuItem.Checked != MapsetUC.CompleteData)
                        {
                            mapsetStp_comboBox.Items.Clear();
                            mapset_panel.Controls.Remove(MapsetUC);
                            MapsetUC = null;
                            loadUC = true;
                        }
                        else if (!MapsetLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            mapsetStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            mapsetStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), mapsetStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.MAPSET);
                            mapset_panel.Controls.Add(MapsetUC);

                            mapsetGlobal_panel.Visible = true;
                            mapset_panel.Enabled = hasData;
                        }

                        mapsetClearAll_button.Enabled = ClearAll;
                    }
                    break;
                #endregion

                #region [ DSTN ]
                case DATA_ENUM.ModuleType.DSTN:
                    OstType = DATA_ENUM.OST_Types.DSTN;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].DstnData != null;
                    if (hasData)
                    {
                        if (DstnLoaded && completeDataToolStripMenuItem.Checked != DstnUC.CompleteData)
                        {
                            dstnStp_comboBox.Items.Clear();
                            dstn_panel.Controls.Remove(DstnUC);
                            DstnUC = null;
                            loadUC = true;
                        }
                        else if (!DstnLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            dstnStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            dstnStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), dstnStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.DSTN);
                            dstn_panel.Controls.Add(DstnUC);

                            dstnGlobal_panel.Visible = true;
                            dstn_panel.Enabled = hasData;
                        }

                        dstnClearAll_button.Enabled = ClearAll;
                    }
                    break;
                #endregion

                #region [ SLK ]
                case DATA_ENUM.ModuleType.SLK:
                    OstType = DATA_ENUM.OST_Types.SLK;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].SlkData != null;
                    if (hasData)
                    {
                        if (SlkLoaded && completeDataToolStripMenuItem.Checked != SlkUC.CompleteData)
                        {
                            slkStp_comboBox.Items.Clear();
                            slk_panel.Controls.Remove(SlkUC);
                            SlkUC = null;
                            loadUC = true;
                        }
                        else if (!SlkLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            slkStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            slkStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), slkStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.SLK);
                            slk_panel.Controls.Add(SlkUC);

                            slkGlobal_panel.Visible = true;
                            slk_panel.Enabled = hasData;
                        }

                        gtaClearAll_button.Enabled = ClearAll;
                    }
                    break;
                #endregion

                #region [ ASSOC ]
                case DATA_ENUM.ModuleType.ASSOC:
                    OstType = DATA_ENUM.OST_Types.ASSOC;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].AssocData != null;
                    if (hasData)
                    {
                        if (AssocLoaded && completeDataToolStripMenuItem.Checked != AssocUC.CompleteData)
                        {
                            assocStp_comboBox.Items.Clear();
                            assoc_panel.Controls.Remove(AssocUC);
                            AssocUC = null;
                            loadUC = true;
                        }
                        else if (!AssocLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            assocStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            assocStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), assocStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.ASSOC);
                            assoc_panel.Controls.Add(AssocUC);

                            assocGlobal_panel.Visible = true;
                            assoc_panel.Enabled = hasData;
                        }

                        assocClearAll_button.Enabled = ClearAll;
                    }
                    break;
                #endregion

                #region [ HOST ]
                case DATA_ENUM.ModuleType.HOST:
                    OstType = DATA_ENUM.OST_Types.HOST;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].HostData != null;
                    if (hasData)
                    {
                        if (HostLoaded && completeDataToolStripMenuItem.Checked != HostUC.CompleteData)
                        {
                            hostStp_comboBox.Items.Clear();
                            host_panel.Controls.Remove(HostUC);
                            HostUC = null;
                            loadUC = true;
                        }
                        else if (!HostLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            hostStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            hostStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), hostStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.HOST);
                            host_panel.Controls.Add(HostUC);

                            hostGlobal_panel.Visible = true;
                            host_panel.Enabled = hasData;
                        }

                        hostClearAll_button.Enabled = ClearAll;
                    }
                    break;
                #endregion

                #region [ LOOPSET ]
                case DATA_ENUM.ModuleType.LOOPSET:
                    OstType = DATA_ENUM.OST_Types.LOOPSET;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].LoopsetData != null;
                    if (hasData)
                    {
                        if (LoopsetLoaded && completeDataToolStripMenuItem.Checked != LoopsetUC.CompleteData)
                        {
                            loopsetStp_comboBox.Items.Clear();
                            loopset_panel.Controls.Remove(LoopsetUC);
                            LoopsetUC = null;
                            loadUC = true;
                        }
                        else if (!LoopsetLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            loopsetStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            loopsetStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), loopsetStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.LOOPSET);
                            loopset_panel.Controls.Add(LoopsetUC);

                            loopsetGlobal_panel.Visible = true;
                            loopset_panel.Enabled = hasData;
                        }

                        loopsetClearAll_button.Enabled = ClearAll;
                    }
                    break;
                #endregion

                #region [ TTMAP ]
                case DATA_ENUM.ModuleType.TTMAP:
                    OstType = DATA_ENUM.OST_Types.TTMAP;
                    hasData = STPsInfo.Count > 0 && STPsInfo[FirstLoadedSet].TTMapData != null;
                    if (hasData)
                    {
                        if (ttMapLoaded && completeDataToolStripMenuItem.Checked != TTMapUC.CompleteData)
                        {
                            ttmapStp_comboBox.Items.Clear();
                            ttmap_panel.Controls.Remove(TTMapUC);
                            TTMapUC = null;
                            loadUC = true;
                        }
                        else if (!ttMapLoaded)
                            loadUC = true;

                        if (loadUC)
                        {
                            ttmapStp_comboBox.Items.AddRange(STPsInfo.Select(s => s.Key.ToString()).ToArray());
                            ttmapStp_comboBox.SelectedIndex = 0;
                            SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), ttmapStp_comboBox.Text);

                            GenerateUC(DATA_ENUM.ModuleType.TTMAP);
                            ttmap_panel.Controls.Add(TTMapUC);

                            ttmapGlobal_panel.Visible = true;
                            ttmap_panel.Enabled = hasData;
                        }

                        loopsetClearAll_button.Enabled = ClearAll;
                    }
                    break;
                    #endregion
            }
        }
        #endregion

        #region [ STP ComboBox Selected Index Changed ]
        private void Stp_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (OstType)
            {
                #region [ GTA ]
                case DATA_ENUM.OST_Types.GTA:
                    if (GtaUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), gtaStp_comboBox.Text);
                        gtaClearAll_button.Enabled = false;
                        gta_panel.Controls.Remove(GtaUC);
                        GtaUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.GTA);
                        gta_panel.Controls.Add(GtaUC);
                    }
                    break;
                #endregion

                #region [ OPCODE ]
                case DATA_ENUM.OST_Types.OPCODE:
                    if (OpcodeUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), opStp_comboBox.Text);
                        opClearAll_button.Enabled = false;
                        opcode_panel.Controls.Remove(OpcodeUC);
                        OpcodeUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.OPCODE);
                        opcode_panel.Controls.Add(OpcodeUC);
                    }
                    break;
                #endregion

                #region [ GTTSEL ]
                case DATA_ENUM.OST_Types.GTTSEL:
                    if (GttselUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), gttselStp_comboBox.Text);
                        gttselClearAll_button.Enabled = false;
                        gttsel_panel.Controls.Remove(GttselUC);
                        GttselUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.GTTSEL);
                        gttsel_panel.Controls.Add(GttselUC);
                    }
                    break;
                #endregion

                #region [ GTTSET ]
                case DATA_ENUM.OST_Types.GTTSET:
                    if (GttsetUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), gttsetStp_comboBox.Text);
                        gttsetClearAll_button.Enabled = false;
                        gttset_panel.Controls.Remove(GttsetUC);
                        GttsetUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.GTTSET);
                        gttset_panel.Controls.Add(GttsetUC);
                    }
                    break;
                #endregion

                #region [ MRNSET ]
                case DATA_ENUM.OST_Types.MRNSET:
                    if (MrnsetUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), mrnsetStp_comboBox.Text);
                        mrnsetClearAll_button.Enabled = false;
                        mrnset_panel.Controls.Remove(MrnsetUC);
                        MrnsetUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.MRNSET);
                        mrnset_panel.Controls.Add(MrnsetUC);
                    }
                    break;
                #endregion

                #region [ MAPSET ]
                case DATA_ENUM.OST_Types.MAPSET:
                    if (MapsetUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), mapsetStp_comboBox.Text);
                        mapsetClearAll_button.Enabled = false;
                        mapset_panel.Controls.Remove(MapsetUC);
                        MapsetUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.MAPSET);
                        mapset_panel.Controls.Add(MapsetUC);
                    }
                    break;
                #endregion

                #region [ DSTN ]
                case DATA_ENUM.OST_Types.DSTN:
                    if (DstnUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), dstnStp_comboBox.Text);
                        dstnClearAll_button.Enabled = false;
                        dstn_panel.Controls.Remove(DstnUC);
                        DstnUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.DSTN);
                        dstn_panel.Controls.Add(DstnUC);
                    }
                    break;
                #endregion

                #region [ SLK ]
                case DATA_ENUM.OST_Types.SLK:
                    if (SlkUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), slkStp_comboBox.Text);
                        slkClearAll_button.Enabled = false;
                        slk_panel.Controls.Remove(SlkUC);
                        SlkUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.SLK);
                        slk_panel.Controls.Add(SlkUC);
                    }
                    break;
                #endregion

                #region [ ASSOC ]
                case DATA_ENUM.OST_Types.ASSOC:
                    if (AssocUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), assocStp_comboBox.Text);
                        assocClearAll_button.Enabled = false;
                        assoc_panel.Controls.Remove(AssocUC);
                        AssocUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.ASSOC);
                        assoc_panel.Controls.Add(AssocUC);
                    }
                    break;
                #endregion

                #region [ HOST ]
                case DATA_ENUM.OST_Types.HOST:
                    if (HostUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), hostStp_comboBox.Text);
                        hostClearAll_button.Enabled = false;
                        host_panel.Controls.Remove(HostUC);
                        HostUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.HOST);
                        host_panel.Controls.Add(HostUC);
                    }
                    break;
                #endregion

                #region [ LOOPSET ]
                case DATA_ENUM.OST_Types.LOOPSET:
                    if (LoopsetUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), loopsetStp_comboBox.Text);
                        loopsetClearAll_button.Enabled = false;
                        loopset_panel.Controls.Remove(LoopsetUC);
                        LoopsetUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.LOOPSET);
                        loopset_panel.Controls.Add(LoopsetUC);
                    }
                    break;
                #endregion

                #region [ TTMAP ]
                case DATA_ENUM.OST_Types.TTMAP:
                    if (TTMapUC != null)
                    {
                        SelectedSTP = (DATA_ENUM.STP)Enum.Parse(typeof(DATA_ENUM.STP), ttmapStp_comboBox.Text);
                        ttmapClearAll_button.Enabled = false;
                        ttmap_panel.Controls.Remove(TTMapUC);
                        TTMapUC = null;
                        GenerateUC(DATA_ENUM.ModuleType.TTMAP);
                        ttmap_panel.Controls.Add(TTMapUC);
                    }
                    break;
                    #endregion
            }
        }
        #endregion

        #region [ Clear All ]
        private void SetClearAll(object sender, EventArgs e)
        {
            bool? clearAll = sender as bool?;
            ClearAll = clearAll.Value;

            switch (stps_tabControl.SelectedTab.Text)
            {
                case "GTA":
                    gtaClearAll_button.Enabled = ClearAll;
                    break;

                case "OPCODE":
                    opClearAll_button.Enabled = ClearAll;
                    break;

                case "GTTSEL":
                    gttselClearAll_button.Enabled = ClearAll;
                    break;

                case "GTTSET":
                    gttsetClearAll_button.Enabled = ClearAll;
                    break;

                case "MRNSET":
                    mrnsetClearAll_button.Enabled = ClearAll;
                    break;

                case "MAPSET":
                    mapsetClearAll_button.Enabled = ClearAll;
                    break;

                case "DSTN":
                    dstnClearAll_button.Enabled = ClearAll;
                    break;

                case "SLK":
                    slkClearAll_button.Enabled = ClearAll;
                    break;

                case "ASSOC":
                    assocClearAll_button.Enabled = ClearAll;
                    break;

                case "HOST":
                    hostClearAll_button.Enabled = ClearAll;
                    break;

                case "LOOPSET":
                    loopsetClearAll_button.Enabled = ClearAll;
                    break;

                case "TTMAP":
                    ttmapClearAll_button.Enabled = ClearAll;
                    break;
            }
        }
        #endregion

        #region [ GenerateUC ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleType"></param>
        private UserControl GenerateUC(DATA_ENUM.ModuleType moduleType)
        {
            UserControl returnUC = null;

            switch (moduleType)
            {
                case DATA_ENUM.ModuleType.GTA:
                    GtaUC = new UserControls.OST.GTA(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.GTA_Data, Properties.Settings.Default.Complete);
                    GtaUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    GtaUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    GtaUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    GtaUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    GtaLoaded = true;
                    gtaGlobal_panel.Enabled = true;
                    returnUC = GtaUC;
                    break;

                case DATA_ENUM.ModuleType.OPCODE:
                    OpcodeUC = new UserControls.OST.OPCODE(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.OpCodeData, Properties.Settings.Default.Complete);
                    OpcodeUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    OpcodeUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    OpcodeUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    OpcodeUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    OpcodeLoaded = true;
                    opcodeGlobal_panel.Enabled = true;
                    returnUC = OpcodeUC;
                    break;

                case DATA_ENUM.ModuleType.GTTSEL:
                    GttselUC = new UserControls.OST.GTTSEL(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.GTTSelData, Properties.Settings.Default.Complete);
                    GttselUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    GttselUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    GttselUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    GttselUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    GttselLoaded = true;
                    gttselGlobal_panel.Enabled = true;
                    returnUC = GttselUC;
                    break;

                case DATA_ENUM.ModuleType.GTTSET:
                    GttsetUC = new UserControls.OST.GTTSET(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.GTTSetData, Properties.Settings.Default.Complete);
                    GttsetUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    GttsetUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    GttsetUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    GttsetUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    GttsetLoaded = true;
                    gttsetGlobal_panel.Enabled = true;
                    returnUC = GttsetUC;
                    break;

                case DATA_ENUM.ModuleType.MRNSET:
                    MrnsetUC = new UserControls.OST.MRNSET(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.MrnsetData, Properties.Settings.Default.Complete);
                    MrnsetUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    MrnsetUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    MrnsetUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    MrnsetUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    MrnsetLoaded = true;
                    mrnsetGlobal_panel.Enabled = true;
                    returnUC = MrnsetUC;
                    break;

                case DATA_ENUM.ModuleType.MAPSET:
                    MapsetUC = new UserControls.OST.MAPSET(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.MapsetData, Properties.Settings.Default.Complete);
                    MapsetUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    MapsetUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    MapsetUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    MapsetUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    MapsetLoaded = true;
                    mapsetGlobal_panel.Enabled = true;
                    returnUC = MapsetUC;
                    break;

                case DATA_ENUM.ModuleType.DSTN:
                    DstnUC = new UserControls.OST.DSTN(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.DstnData, Properties.Settings.Default.Complete);
                    DstnUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    DstnUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    DstnUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    DstnUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    DstnLoaded = true;
                    dstnGlobal_panel.Enabled = true;
                    returnUC = DstnUC;
                    break;

                case DATA_ENUM.ModuleType.SLK:
                    SlkUC = new UserControls.OST.SLK(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.SlkData, Properties.Settings.Default.Complete);
                    SlkUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    SlkUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    SlkUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    SlkUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    SlkLoaded = true;
                    slkGlobal_panel.Enabled = true;
                    returnUC = SlkUC;
                    break;

                case DATA_ENUM.ModuleType.ASSOC:
                    AssocUC = new UserControls.OST.ASSOC(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.AssocData, Properties.Settings.Default.Complete);
                    AssocUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    AssocUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    AssocUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    AssocUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    AssocLoaded = true;
                    assocGlobal_panel.Enabled = true;
                    returnUC = AssocUC;
                    break;

                case DATA_ENUM.ModuleType.HOST:
                    HostUC = new UserControls.OST.HOST(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.HostData, Properties.Settings.Default.Complete);
                    HostUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    HostUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    HostUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    HostUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    HostLoaded = true;
                    hostGlobal_panel.Enabled = true;
                    returnUC = HostUC;
                    break;

                case DATA_ENUM.ModuleType.LOOPSET:
                    LoopsetUC = new UserControls.OST.LOOPSET(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.LoopsetData, Properties.Settings.Default.Complete);
                    LoopsetUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    LoopsetUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    LoopsetUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    LoopsetUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    LoopsetLoaded = true;
                    loopsetGlobal_panel.Enabled = true;
                    returnUC = LoopsetUC;
                    break;

                case DATA_ENUM.ModuleType.TTMAP:
                    TTMapUC = new UserControls.OST.TTMAP(STPsInfo.Where(w => w.Key == SelectedSTP).FirstOrDefault().Value.TTMapData, Properties.Settings.Default.Complete);
                    TTMapUC.ClearAllPerformed += new EventHandler(SetClearAll);
                    TTMapUC.ShowMessageRaised += new EventHandler(BuildMessage);
                    TTMapUC.GenerateExcelClicked += new EventHandler(GenerateExcel);
                    TTMapUC.ClearAllClicked += new EventHandler(ClearFiltersClick);
                    ttMapLoaded = true;
                    ttmapGlobal_panel.Enabled = true;
                    returnUC = TTMapUC;
                    break;
            }

            return returnUC;
        }
        #endregion

        #region [ Reset UC ]
        private void ResetUC()
        {
            foreach (DATA_ENUM.ModuleType moduleType in Enum.GetValues(typeof(DATA_ENUM.ModuleType)))
            {
                switch (moduleType)
                {
                    case DATA_ENUM.ModuleType.GTA:
                        if (GtaLoaded)
                        {
                            gtaGlobal_panel.Visible = false;
                            gtaStp_comboBox.Items.Clear();
                            gta_panel.Controls.Remove(GtaUC);
                            GtaUC = null;
                            GtaLoaded = false;
                        }
                        break;

                    case DATA_ENUM.ModuleType.OPCODE:
                        if (OpcodeLoaded)
                        {
                            opcodeGlobal_panel.Visible = false;
                            opStp_comboBox.Items.Clear();
                            opcode_panel.Controls.Remove(OpcodeUC);
                            OpcodeUC = null;
                            OpcodeLoaded = false;
                        }
                        break;

                    case DATA_ENUM.ModuleType.GTTSEL:
                        if (GttselLoaded)
                        {
                            gttselGlobal_panel.Visible = false;
                            gttselStp_comboBox.Items.Clear();
                            gttsel_panel.Controls.Remove(GttselUC);
                            GttselUC = null;
                            GttselLoaded = false;
                        }
                        break;

                    case DATA_ENUM.ModuleType.GTTSET:
                        if (GttsetLoaded)
                        {
                            gttsetGlobal_panel.Visible = false;
                            gttsetStp_comboBox.Items.Clear();
                            gttset_panel.Controls.Remove(GttsetUC);
                            GttsetUC = null;
                            GttsetLoaded = false;
                        }
                        break;

                    case DATA_ENUM.ModuleType.MRNSET:
                        if (MrnsetLoaded)
                        {
                            mrnsetGlobal_panel.Visible = false;
                            mrnsetStp_comboBox.Items.Clear();
                            mrnset_panel.Controls.Remove(MrnsetUC);
                            MrnsetUC = null;
                            MrnsetLoaded = false;
                        }
                        break;

                    case DATA_ENUM.ModuleType.MAPSET:
                        if (MapsetLoaded)
                        {
                            mapsetGlobal_panel.Visible = false;
                            mapsetStp_comboBox.Items.Clear();
                            mapset_panel.Controls.Remove(MapsetUC);
                            MapsetUC = null;
                            MapsetLoaded = false;
                        }
                        break;

                    case DATA_ENUM.ModuleType.DSTN:
                        if (DstnLoaded)
                        {
                            dstnGlobal_panel.Visible = false;
                            dstnStp_comboBox.Items.Clear();
                            dstn_panel.Controls.Remove(DstnUC);
                            DstnUC = null;
                            DstnLoaded = false;
                        }
                        break;

                    case DATA_ENUM.ModuleType.SLK:
                        if (SlkLoaded)
                        {
                            slkGlobal_panel.Visible = false;
                            slkStp_comboBox.Items.Clear();
                            slk_panel.Controls.Remove(SlkUC);
                            SlkUC = null;
                            SlkLoaded = false;
                        }
                        break;

                    case DATA_ENUM.ModuleType.ASSOC:
                        if (AssocLoaded)
                        {
                            assocGlobal_panel.Visible = false;
                            assocStp_comboBox.Items.Clear();
                            assoc_panel.Controls.Remove(AssocUC);
                            AssocUC = null;
                            AssocLoaded = false;
                        }
                        break;

                    case DATA_ENUM.ModuleType.HOST:
                        if (HostLoaded)
                        {
                            hostGlobal_panel.Visible = false;
                            hostStp_comboBox.Items.Clear();
                            host_panel.Controls.Remove(HostUC);
                            HostUC = null;
                            HostLoaded = false;
                        }
                        break;

                    case DATA_ENUM.ModuleType.LOOPSET:
                        if (LoopsetLoaded)
                        {
                            loopsetGlobal_panel.Visible = false;
                            loopsetStp_comboBox.Items.Clear();
                            loopset_panel.Controls.Remove(LoopsetUC);
                            LoopsetUC = null;
                            LoopsetLoaded = false;
                        }
                        break;

                    case DATA_ENUM.ModuleType.TTMAP:
                        if (ttMapLoaded)
                        {
                            ttmapGlobal_panel.Visible = false;
                            ttmapStp_comboBox.Items.Clear();
                            ttmap_panel.Controls.Remove(TTMapUC);
                            TTMapUC = null;
                            ttMapLoaded = false;
                        }
                        break;
                }
            }
        }
        #endregion

        #region [ Free STP Memory ]
        private void FreeSTPMemory()
        {
            STPsInfo = new Dictionary<DATA_ENUM.STP, Data.OST.STP_Info>();

            freeMemoryToolStripMenuItem.Enabled = false;
            loadedDataToolStripMenuItem.Enabled = false;
            generateExcelToolStripMenuItem.Enabled = false;
            loopsetsToolStripMenuItem.Enabled = false;
            buildReportToolStripMenuItem.Enabled = false;

            ResetUC();
            SetDataLoaded();

            gtaStp_comboBox.Items.Clear();
            opStp_comboBox.Items.Clear();
            gttselStp_comboBox.Items.Clear();
            gttsetStp_comboBox.Items.Clear();
            mrnsetStp_comboBox.Items.Clear();
            mapsetStp_comboBox.Items.Clear();
            dstnStp_comboBox.Items.Clear();
            slkStp_comboBox.Items.Clear();
            assocStp_comboBox.Items.Clear();
            hostStp_comboBox.Items.Clear();
            loopsetStp_comboBox.Items.Clear();
            ttmapStp_comboBox.Items.Clear();

            agreementsSearch_panel.Enabled = false;
            AuditData = null;
            auditType_comboBox.Items.Clear();
            audit_button.Enabled = false;
            audits_panel.Visible = false;
            auditDetails_panel.Visible = false;
            auditsPerformed_groupBox.Visible = false;

            GC.Collect();
        }
        #endregion

        #region [ Clear All ]

        private void ClearFiltersClick(object sender, EventArgs e)
        {
            ClearFilters();
        }

        private void ClearFilters()
        {
            switch (OstType)
            {
                case DATA_ENUM.OST_Types.All:
                    if (CheckClearUC(GtaUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.GTA, GtaUC, ref gta_panel, GtaLoaded); }
                    if (CheckClearUC(OpcodeUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.OPCODE, OpcodeUC, ref opcode_panel, OpcodeLoaded); }
                    if (CheckClearUC(GttselUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.GTTSEL, GttselUC, ref gttsel_panel, GttselLoaded); }
                    if (CheckClearUC(GttsetUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.GTTSET, GttsetUC, ref gttset_panel, GttsetLoaded); }
                    if (CheckClearUC(MrnsetUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.MRNSET, MrnsetUC, ref mrnset_panel, MrnsetLoaded); }
                    if (CheckClearUC(MapsetUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.MAPSET, MapsetUC, ref mapset_panel, MapsetLoaded); }
                    if (CheckClearUC(DstnUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.DSTN, DstnUC, ref dstn_panel, DstnLoaded); }
                    if (CheckClearUC(SlkUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.SLK, SlkUC, ref slk_panel, SlkLoaded); }
                    if (CheckClearUC(AssocUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.ASSOC, AssocUC, ref assoc_panel, AssocLoaded); }
                    if (CheckClearUC(HostUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.HOST, HostUC, ref host_panel, HostLoaded); }
                    if (CheckClearUC(LoopsetUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.LOOPSET, LoopsetUC, ref loopset_panel, LoopsetLoaded); }
                    if (CheckClearUC(TTMapUC, true)) { ClearDataUC(DATA_ENUM.ModuleType.TTMAP, TTMapUC, ref ttmap_panel, ttMapLoaded); }
                    break;

                case DATA_ENUM.OST_Types.GTA:
                    ClearDataUC(DATA_ENUM.ModuleType.GTA, GtaUC, ref gta_panel, GtaLoaded);
                    break;

                case DATA_ENUM.OST_Types.OPCODE:
                    ClearDataUC(DATA_ENUM.ModuleType.OPCODE, OpcodeUC, ref opcode_panel, OpcodeLoaded);
                    break;

                case DATA_ENUM.OST_Types.GTTSEL:
                    ClearDataUC(DATA_ENUM.ModuleType.GTTSEL, GttselUC, ref gttsel_panel, GttselLoaded);
                    break;

                case DATA_ENUM.OST_Types.GTTSET:
                    ClearDataUC(DATA_ENUM.ModuleType.GTTSET, GttsetUC, ref gttset_panel, GttsetLoaded);
                    break;

                case DATA_ENUM.OST_Types.MRNSET:
                    ClearDataUC(DATA_ENUM.ModuleType.MRNSET, MrnsetUC, ref mrnset_panel, MrnsetLoaded);
                    break;

                case DATA_ENUM.OST_Types.MAPSET:
                    ClearDataUC(DATA_ENUM.ModuleType.MAPSET, MapsetUC, ref mapset_panel, MapsetLoaded);
                    break;

                case DATA_ENUM.OST_Types.DSTN:
                    ClearDataUC(DATA_ENUM.ModuleType.DSTN, DstnUC, ref dstn_panel, DstnLoaded);
                    break;

                case DATA_ENUM.OST_Types.SLK:
                    ClearDataUC(DATA_ENUM.ModuleType.SLK, SlkUC, ref slk_panel, SlkLoaded);
                    break;

                case DATA_ENUM.OST_Types.ASSOC:
                    ClearDataUC(DATA_ENUM.ModuleType.ASSOC, AssocUC, ref assoc_panel, AssocLoaded);
                    break;

                case DATA_ENUM.OST_Types.HOST:
                    ClearDataUC(DATA_ENUM.ModuleType.HOST, HostUC, ref host_panel, HostLoaded);
                    break;

                case DATA_ENUM.OST_Types.LOOPSET:
                    ClearDataUC(DATA_ENUM.ModuleType.LOOPSET, LoopsetUC, ref loopset_panel, LoopsetLoaded);
                    break;

                case DATA_ENUM.OST_Types.TTMAP:
                    ClearDataUC(DATA_ENUM.ModuleType.TTMAP, TTMapUC, ref ttmap_panel, ttMapLoaded);
                    break;
            }            

            if (CheckClearUC(GtaUC, false) && CheckClearUC(OpcodeUC, false) && CheckClearUC(GttselUC, false) &&
                CheckClearUC(GttsetUC, false) && CheckClearUC(MrnsetUC, false) && CheckClearUC(MapsetUC, false) && CheckClearUC(DstnUC, false) && 
                CheckClearUC(SlkUC, false) && CheckClearUC(AssocUC, false) && CheckClearUC(HostUC, false) && CheckClearUC(LoopsetUC, false) && CheckClearUC(TTMapUC, false))
            {
                gtaClearAll_button.Enabled = false;
                opClearAll_button.Enabled = false;
                gttselClearAll_button.Enabled = false;
                gttsetClearAll_button.Enabled = false;
                mrnsetClearAll_button.Enabled = false;
                mapsetClearAll_button.Enabled = false;
                dstnClearAll_button.Enabled = false;
                slkClearAll_button.Enabled = false;
                assocClearAll_button.Enabled = false;
                hostClearAll_button.Enabled = false;
                loopsetClearAll_button.Enabled = false;
                ttmapClearAll_button.Enabled = false;
                ClearAll = false;
            }
        }

        private bool CheckClearUC(Base.UserControlBase uControl, bool value)
        {
            return uControl == null || uControl.CheckButtonEnabled(ClearButtonName) == value;
        }

        private void ClearDataUC(DATA_ENUM.ModuleType mType, UserControl uControl, ref Panel uPanel, bool sectionLoaded)
        {
            if (sectionLoaded)
            {
                uPanel.Controls.Remove(uControl);
                uControl = null;
                uControl = GenerateUC(mType);
                uPanel.Controls.Add(uControl);
            }
        }

        private void ClearFilter_button_Click(object sender, EventArgs e)
        {
            OstType = DATA_ENUM.OST_Types.All;
            ClearFilters();
        }
        #endregion

        #region [ OST Generate Excels ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ostType"></param>
        private void OstGenerateExcels()
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                OfficeOpenXml.ExcelPackage xlPackage = null;
                try
                {
                    xlPackage = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelPackage(FilePath);

                    try
                    {
                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.GTA)
                        {
                            if (GtaUC != null || STPsInfo[SelectedSTP].GTA_Data != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating GTA Excel Sheet");
                                if (GtaUC != null)
                                    GtaUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.GTA(xlPackage, STPsInfo[SelectedSTP].GTA_Data, Properties.Settings.Default.Complete);
                            }
                        }

                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.OPCODE)
                        {
                            if (OpcodeUC != null || STPsInfo[SelectedSTP].OpCodeData != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating OPCODE Excel Sheet");
                                if (OpcodeUC != null)
                                    OpcodeUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.OPCODE(xlPackage, STPsInfo[SelectedSTP].OpCodeData, Properties.Settings.Default.Complete);
                            }
                        }

                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.GTTSEL)
                        {
                            if (GttselUC != null || STPsInfo[SelectedSTP].GTTSelData != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating GTTSEL Excel Sheet");
                                if (GttselUC != null)
                                    GttselUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.GTTSEL(xlPackage, STPsInfo[SelectedSTP].GTTSelData);
                            }
                        }

                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.GTTSET)
                        {
                            if (GttsetUC != null || STPsInfo[SelectedSTP].GTTSetData != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating GTTSET Excel Sheet");
                                if (GttsetUC != null)
                                    GttsetUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.GTTSET(xlPackage, STPsInfo[SelectedSTP].GTTSetData, Properties.Settings.Default.Complete);
                            }
                        }

                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.MRNSET)
                        {
                            if (MrnsetUC != null || STPsInfo[SelectedSTP].MrnsetData != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating MRNSET Excel Sheet");
                                if (MrnsetUC != null)
                                    MrnsetUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.MRNSET(xlPackage, STPsInfo[SelectedSTP].MrnsetData);
                            }
                        }

                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.MAPSET)
                        {
                            if (MapsetUC != null || STPsInfo[SelectedSTP].MapsetData != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating MAPSET Excel Sheet");
                                if (MapsetUC != null)
                                    MapsetUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.MAPSET(xlPackage, STPsInfo[SelectedSTP].MapsetData);
                            }
                        }

                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.DSTN)
                        {
                            if (DstnUC != null || STPsInfo[SelectedSTP].DstnData != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating DSTN Excel Sheet");
                                if (DstnUC != null)
                                    DstnUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.DSTN(xlPackage, STPsInfo[SelectedSTP].DstnData);
                            }
                        }

                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.SLK)
                        {
                            if (SlkUC != null || STPsInfo[SelectedSTP].SlkData != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating SLK Excel Sheet");
                                if (SlkUC != null)
                                    SlkUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.SLK(xlPackage, STPsInfo[SelectedSTP].SlkData);
                            }
                        }

                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.ASSOC)
                        {
                            if (AssocUC != null || STPsInfo[SelectedSTP].AssocData != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating ASSOC Excel Sheet");
                                if (AssocUC != null)
                                    AssocUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.ASSOC(xlPackage, STPsInfo[SelectedSTP].AssocData);
                            }
                        }

                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.HOST)
                        {
                            if (HostUC != null || STPsInfo[SelectedSTP].HostData != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating HOST Excel Sheet");
                                if (HostUC != null)
                                    HostUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.HOST(xlPackage, STPsInfo[SelectedSTP].HostData);
                            }
                        }

                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.LOOPSET)
                        {
                            if (LoopsetUC != null || STPsInfo[SelectedSTP].LoopsetData != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating LOOPSET Excel Sheet");
                                if (LoopsetUC != null)
                                    LoopsetUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.LOOPSET(xlPackage, STPsInfo[SelectedSTP].LoopsetData);
                            }
                        }

                        if (OstType == DATA_ENUM.OST_Types.All || OstType == DATA_ENUM.OST_Types.TTMAP)
                        {
                            if (TTMapUC != null || STPsInfo[SelectedSTP].TTMapData != null)
                            {
                                Action_backgroundWorker.ReportProgress(0, "Generating TTMAP Excel Sheet");
                                if (TTMapUC != null)
                                    TTMapUC.GenerateExcel(xlPackage);
                                else
                                    Business.Excel.OST.TTMAP(xlPackage, STPsInfo[SelectedSTP].TTMapData);
                            }
                        }

                        xlPackage.Save();
                        xlPackage.Dispose();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                catch (IOException ioEx)
                {
                    ActionResult = new Data.ResultItem();
                    ActionResult.Result = false;
                    ActionResult.Message = "You have to close the existing file first";
                }
            }
        }
        #endregion

        #region [ Excel All Button Click ]
        private void ExcelAll_button_Click(object sender, EventArgs e)
        {
            FilePath = MLVSoft_Common.Utilities.FilesManagement.SaveFileDialog("Excel", "xlsx", "Select path and file name for Excel file");
            if (!string.IsNullOrEmpty(FilePath))
            {
                ExcelType = DATA_ENUM.ExcelType.First;
                OstType = DATA_ENUM.OST_Types.All;
                GenerateExcel(false);
            }
        }        
        #endregion

        #region [ STPs Tab Color ]
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        private void SetTabHeader(List<TabPage> pages, Color color)
        {
            foreach (TabPage item in pages)
                TabColors[item] = color;

            stps_tabControl.Invalidate();
        }

        private void stps_tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            using (Brush br = new SolidBrush(TabColors[stps_tabControl.TabPages[e.Index]]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
                SizeF sz = e.Graphics.MeasureString(stps_tabControl.TabPages[e.Index].Text, e.Font);
                e.Graphics.DrawString(stps_tabControl.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + (e.Bounds.Width - sz.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sz.Height) / 2 + 2);

                Rectangle rect = e.Bounds;
                rect.Offset(0, 1);
                rect.Inflate(2, 1);
                e.DrawFocusRectangle();
            }
        }
        #endregion

        #endregion

        #region [ --------------> Audits <-------------- ]

        #region [ CheckAuditOptions ]
        private void CheckAuditOptions()
        {
            if (STPsInfo.Keys.Count == 4)
            {
                if (auditType_comboBox.Items.Count == 0)
                    auditType_comboBox.Items.Add("All");

                if (STPsInfo[FirstLoadedSet].GTA_Data != null && !auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.GTA.ToString()))
                    auditType_comboBox.Items.Add(DATA_ENUM.ModuleType.GTA.ToString());

                if (STPsInfo[FirstLoadedSet].OpCodeData != null && !auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.OPCODE.ToString()))
                    auditType_comboBox.Items.Add(DATA_ENUM.ModuleType.OPCODE.ToString());

                if (STPsInfo[FirstLoadedSet].GTTSelData != null && !auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.GTTSEL.ToString()))
                    auditType_comboBox.Items.Add(DATA_ENUM.ModuleType.GTTSEL.ToString());

                if (STPsInfo[FirstLoadedSet].GTTSetData != null && !auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.GTTSET.ToString()))
                    auditType_comboBox.Items.Add(DATA_ENUM.ModuleType.GTTSET.ToString());

                if (STPsInfo[FirstLoadedSet].MrnsetData != null && !auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.MRNSET.ToString()))
                    auditType_comboBox.Items.Add(DATA_ENUM.ModuleType.MRNSET.ToString());

                if (STPsInfo[FirstLoadedSet].DstnData != null && !auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.DSTN.ToString()))
                    auditType_comboBox.Items.Add(DATA_ENUM.ModuleType.DSTN.ToString());

                if (STPsInfo[FirstLoadedSet].SlkData != null && !auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.SLK.ToString()))
                    auditType_comboBox.Items.Add(DATA_ENUM.ModuleType.SLK.ToString());

                if (STPsInfo[FirstLoadedSet].AssocData != null && !auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.ASSOC.ToString()))
                    auditType_comboBox.Items.Add(DATA_ENUM.ModuleType.ASSOC.ToString());

                if (STPsInfo[FirstLoadedSet].LoopsetData != null && !auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.LOOPSET.ToString()))
                    auditType_comboBox.Items.Add(DATA_ENUM.ModuleType.LOOPSET.ToString());

                if (STPsInfo[FirstLoadedSet].TTMapData != null && !auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.TTMAP.ToString()))
                    auditType_comboBox.Items.Add(DATA_ENUM.ModuleType.TTMAP.ToString());
            }
            else if (STPsInfo.Keys.Count > 0)
            {
                if (STPsInfo[FirstLoadedSet].GTA_Data == null && auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.GTA.ToString()))
                    auditType_comboBox.Items.Remove(DATA_ENUM.ModuleType.GTA.ToString());

                if (STPsInfo[FirstLoadedSet].OpCodeData == null && auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.OPCODE.ToString()))
                    auditType_comboBox.Items.Remove(DATA_ENUM.ModuleType.OPCODE.ToString());

                if (STPsInfo[FirstLoadedSet].GTTSelData == null && auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.GTTSEL.ToString()))
                    auditType_comboBox.Items.Remove(DATA_ENUM.ModuleType.GTTSEL.ToString());

                if (STPsInfo[FirstLoadedSet].GTTSetData == null && auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.GTTSET.ToString()))
                    auditType_comboBox.Items.Remove(DATA_ENUM.ModuleType.GTTSET.ToString());

                if (STPsInfo[FirstLoadedSet].MrnsetData == null && auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.MRNSET.ToString()))
                    auditType_comboBox.Items.Remove(DATA_ENUM.ModuleType.MRNSET.ToString());

                if (STPsInfo[FirstLoadedSet].DstnData == null && auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.DSTN.ToString()))
                    auditType_comboBox.Items.Remove(DATA_ENUM.ModuleType.DSTN.ToString());

                if (STPsInfo[FirstLoadedSet].SlkData == null && auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.SLK.ToString()))
                    auditType_comboBox.Items.Remove(DATA_ENUM.ModuleType.SLK.ToString());

                if (STPsInfo[FirstLoadedSet].AssocData == null && auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.ASSOC.ToString()))
                    auditType_comboBox.Items.Remove(DATA_ENUM.ModuleType.ASSOC.ToString());

                if (STPsInfo[FirstLoadedSet].LoopsetData == null && auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.LOOPSET.ToString()))
                    auditType_comboBox.Items.Remove(DATA_ENUM.ModuleType.LOOPSET.ToString());

                if (STPsInfo[FirstLoadedSet].TTMapData == null && auditType_comboBox.Items.Contains(DATA_ENUM.ModuleType.TTMAP.ToString()))
                    auditType_comboBox.Items.Remove(DATA_ENUM.ModuleType.TTMAP.ToString());
            }
            else
                auditType_comboBox.Items.Clear();

            this.auditType_comboBox.Enabled = this.auditType_comboBox.Items.Count > 0;
        }
        #endregion

        #region [ Audit Button Click ]
        private void audit_button_Click(object sender, EventArgs e)
        {
            AuditType = (DATA_ENUM.OST_Types)Enum.Parse(typeof(DATA_ENUM.OST_Types), auditType_comboBox.Text);
            OperationType = DATA_ENUM.OperationType.Audits;
            PerformAction();
        }
        #endregion

        #region [  Audit Type ComboBox Selected Index Changed ]
        private void auditType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            audit_button.Enabled = auditType_comboBox.SelectedIndex != -1;

            if (audit_button.Enabled)
            {
                AuditType = (DATA_ENUM.OST_Types)Enum.Parse(typeof(DATA_ENUM.OST_Types), auditType_comboBox.Text);

                if (AuditData != null && 
                    (AuditType == DATA_ENUM.OST_Types.All || 
                    (AuditType != DATA_ENUM.OST_Types.All && AuditData[DATA_ENUM.STP.RAT2].ContainsKey((DATA_ENUM.ModuleType)Enum.Parse(typeof(DATA_ENUM.ModuleType), auditType_comboBox.Text)))))
                {
                    ShowAuditResult();

                    if (AuditType == DATA_ENUM.OST_Types.All)
                    {
                        auditDetails_panel.Visible = false;
                        allAuditData_panel.Visible = true;   
                    }
                }
                else
                {
                    audits_panel.Visible = false;
                    auditDetails_panel.Visible = false;
                    auditsPerformed_groupBox.Visible = false;
                }
            }
        }
        #endregion

        #region [ Audit execution ]
        private void Audit()
        {
            if (AuditData == null)
                AuditData = new Dictionary<DATA_ENUM.STP, Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>>();

            switch (AuditType)
            {
                //Tomamos el primer elemento como clave para comparar con el resto
                
                case DATA_ENUM.OST_Types.All:
                    if (STPsInfo[DATA_ENUM.STP.RAT1].GTA_Data != null) { ModuleAudit(DATA_ENUM.OST_Types.GTA); }
                    if (STPsInfo[DATA_ENUM.STP.RAT1].OpCodeData != null) { ModuleAudit(DATA_ENUM.OST_Types.OPCODE); }
                    if (STPsInfo[DATA_ENUM.STP.RAT1].GTTSelData != null) { ModuleAudit(DATA_ENUM.OST_Types.GTTSEL); }
                    if (STPsInfo[DATA_ENUM.STP.RAT1].GTTSetData != null) { ModuleAudit(DATA_ENUM.OST_Types.GTTSET); }
                    if (STPsInfo[DATA_ENUM.STP.RAT1].MrnsetData != null) { ModuleAudit(DATA_ENUM.OST_Types.MRNSET); }
                    if (STPsInfo[DATA_ENUM.STP.RAT1].DstnData != null) { ModuleAudit(DATA_ENUM.OST_Types.DSTN); }
                    if (STPsInfo[DATA_ENUM.STP.RAT1].SlkData != null) { ModuleAudit(DATA_ENUM.OST_Types.SLK); }
                    if (STPsInfo[DATA_ENUM.STP.RAT1].AssocData != null) { ModuleAudit(DATA_ENUM.OST_Types.ASSOC); }
                    if (STPsInfo[DATA_ENUM.STP.RAT1].LoopsetData != null) { ModuleAudit(DATA_ENUM.OST_Types.LOOPSET); }
                    if (STPsInfo[DATA_ENUM.STP.RAT1].TTMapData != null) { ModuleAudit(DATA_ENUM.OST_Types.TTMAP); }
                    break;

                default:
                    ModuleAudit(AuditType);
                    break;
            }
        }
        #endregion

        #region [ Module Audit ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        private void ModuleAudit(DATA_ENUM.OST_Types module)
        {
            switch (module)
            {
                //Tomamos el primer elemento como clave para comparar con el resto

                #region [ GTA ]
                case DATA_ENUM.OST_Types.GTA:
                    Action_backgroundWorker.ReportProgress(0, "Performing GTA audit");
                    Dictionary<DATA_ENUM.STP, List<Data.OST.GTA_Data>> gtaAuditData = new Dictionary<DATA_ENUM.STP, List<Data.OST.GTA_Data>>();
                    foreach (KeyValuePair<DATA_ENUM.STP, Data.OST.STP_Info> item in STPsInfo)
                        gtaAuditData.Add(item.Key, item.Value.GTA_Data);

                    Dictionary<DATA_ENUM.STP, Data.Audits.AuditResult> auditGta = Business.Audit.Audits.AuditGTA(gtaAuditData);

                    foreach (DATA_ENUM.STP item in auditGta.Keys)
                    {
                        if (!AuditData.ContainsKey(item))
                            AuditData.Add(item, new Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>());

                        if (AuditData[item].ContainsKey(DATA_ENUM.ModuleType.GTA))
                            AuditData[item].Remove(DATA_ENUM.ModuleType.GTA);

                        AuditData[item].Add(DATA_ENUM.ModuleType.GTA, auditGta[item]);
                    }
                    auditGta_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                    break;
                #endregion

                #region [ OPCODE ]
                case DATA_ENUM.OST_Types.OPCODE:
                    Action_backgroundWorker.ReportProgress(0, "Performing OPCODE audit");
                    Dictionary<DATA_ENUM.STP, List<Data.OST.OPCODE_Data>> opAuditData = new Dictionary<DATA_ENUM.STP, List<Data.OST.OPCODE_Data>>();
                    foreach (KeyValuePair<DATA_ENUM.STP, Data.OST.STP_Info> item in STPsInfo)
                        opAuditData.Add(item.Key, item.Value.OpCodeData);

                    Dictionary<DATA_ENUM.STP, Data.Audits.AuditResult> auditOpcode = Business.Audit.Audits.AuditOPCODE(opAuditData);

                    foreach (DATA_ENUM.STP item in auditOpcode.Keys)
                    {
                        if (!AuditData.ContainsKey(item))
                            AuditData.Add(item, new Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>());

                        if (AuditData[item].ContainsKey(DATA_ENUM.ModuleType.OPCODE))
                            AuditData[item].Remove(DATA_ENUM.ModuleType.OPCODE);

                        AuditData[item].Add(DATA_ENUM.ModuleType.OPCODE, auditOpcode[item]);
                    }
                    auditOpcode_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                    break;
                #endregion

                #region [ GTTSEL ]
                case DATA_ENUM.OST_Types.GTTSEL:
                    Action_backgroundWorker.ReportProgress(0, "Performing GTTSEL audit");
                    Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSEL_Data>> gttselAuditData = new Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSEL_Data>>();
                    foreach (KeyValuePair<DATA_ENUM.STP, Data.OST.STP_Info> item in STPsInfo)
                        gttselAuditData.Add(item.Key, item.Value.GTTSelData);

                    Dictionary<DATA_ENUM.STP, Data.Audits.AuditResult> auditGttsel = Business.Audit.Audits.AuditGTTSEL(gttselAuditData);

                    foreach (DATA_ENUM.STP item in auditGttsel.Keys)
                    {
                        if (!AuditData.ContainsKey(item))
                            AuditData.Add(item, new Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>());

                        if (AuditData[item].ContainsKey(DATA_ENUM.ModuleType.GTTSEL))
                            AuditData[item].Remove(DATA_ENUM.ModuleType.GTTSEL);

                        AuditData[item].Add(DATA_ENUM.ModuleType.GTTSEL, auditGttsel[item]);
                    }
                    auditGttsel_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                    break;
                #endregion

                #region [ GTTSET ]
                case DATA_ENUM.OST_Types.GTTSET:
                    Action_backgroundWorker.ReportProgress(0, "Performing GTTSET audit");
                    Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSET_Data>> gttsetAuditData = new Dictionary<DATA_ENUM.STP, List<Data.OST.GTTSET_Data>>();
                    foreach (KeyValuePair<DATA_ENUM.STP, Data.OST.STP_Info> item in STPsInfo)
                        gttsetAuditData.Add(item.Key, item.Value.GTTSetData);

                    Dictionary<DATA_ENUM.STP, Data.Audits.AuditResult> auditGttset = Business.Audit.Audits.AuditGTTSET(gttsetAuditData);

                    foreach (DATA_ENUM.STP item in auditGttset.Keys)
                    {
                        if (!AuditData.ContainsKey(item))
                            AuditData.Add(item, new Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>());

                        if (AuditData[item].ContainsKey(DATA_ENUM.ModuleType.GTTSET))
                            AuditData[item].Remove(DATA_ENUM.ModuleType.GTTSET);

                        AuditData[item].Add(DATA_ENUM.ModuleType.GTTSET, auditGttset[item]);
                    }
                    auditGttset_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                    break;
                #endregion 

                #region [ MRNSET ]
                case DATA_ENUM.OST_Types.MRNSET:
                    Action_backgroundWorker.ReportProgress(0, "Performing MRNSET audit");
                    Dictionary<DATA_ENUM.STP, List<Data.OST.MRNSET_Data>> mrnsetAuditData = new Dictionary<DATA_ENUM.STP, List<Data.OST.MRNSET_Data>>();
                    foreach (KeyValuePair<DATA_ENUM.STP, Data.OST.STP_Info> item in STPsInfo)
                        mrnsetAuditData.Add(item.Key, item.Value.MrnsetData);

                    Dictionary<DATA_ENUM.STP, Data.Audits.AuditResult> auditMrnset = Business.Audit.Audits.AuditMRNSET(mrnsetAuditData);

                    foreach (DATA_ENUM.STP item in auditMrnset.Keys)
                    {
                        if (!AuditData.ContainsKey(item))
                            AuditData.Add(item, new Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>());

                        if (AuditData[item].ContainsKey(DATA_ENUM.ModuleType.MRNSET))
                            AuditData[item].Remove(DATA_ENUM.ModuleType.MRNSET);

                        AuditData[item].Add(DATA_ENUM.ModuleType.MRNSET, auditMrnset[item]);
                    }
                    auditMrnset_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                    break;
                #endregion

                #region [ DSTN ]
                case DATA_ENUM.OST_Types.DSTN:
                    Action_backgroundWorker.ReportProgress(0, "Performing DSTN audit");
                    Dictionary<DATA_ENUM.STP, List<Data.OST.DSTN_Data>> dstnAuditData = new Dictionary<DATA_ENUM.STP, List<Data.OST.DSTN_Data>>();
                    foreach (KeyValuePair<DATA_ENUM.STP, Data.OST.STP_Info> item in STPsInfo)
                        dstnAuditData.Add(item.Key, item.Value.DstnData);

                    Dictionary<DATA_ENUM.STP, Data.Audits.AuditResult> auditDstn = Business.Audit.Audits.AuditMRNSET(dstnAuditData);

                    foreach (DATA_ENUM.STP item in auditDstn.Keys)
                    {
                        if (!AuditData.ContainsKey(item))
                            AuditData.Add(item, new Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>());

                        if (AuditData[item].ContainsKey(DATA_ENUM.ModuleType.DSTN))
                            AuditData[item].Remove(DATA_ENUM.ModuleType.DSTN);

                        AuditData[item].Add(DATA_ENUM.ModuleType.DSTN, auditDstn[item]);
                    }
                    auditDstn_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                    break;
                #endregion

                #region [ SLK ]
                case DATA_ENUM.OST_Types.SLK:
                    Action_backgroundWorker.ReportProgress(0, "Performing SLK audit");
                    Dictionary<DATA_ENUM.STP, List<Data.OST.SLK_Data>> slkAuditData = new Dictionary<DATA_ENUM.STP, List<Data.OST.SLK_Data>>();
                    foreach (KeyValuePair<DATA_ENUM.STP, Data.OST.STP_Info> item in STPsInfo)
                        slkAuditData.Add(item.Key, item.Value.SlkData);

                    Dictionary<DATA_ENUM.STP, Data.Audits.AuditResult> auditSlk = Business.Audit.Audits.AuditSLK(slkAuditData);

                    foreach (DATA_ENUM.STP item in auditSlk.Keys)
                    {
                        if (!AuditData.ContainsKey(item))
                            AuditData.Add(item, new Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>());

                        if (AuditData[item].ContainsKey(DATA_ENUM.ModuleType.SLK))
                            AuditData[item].Remove(DATA_ENUM.ModuleType.SLK);

                        AuditData[item].Add(DATA_ENUM.ModuleType.SLK, auditSlk[item]);
                    }
                    auditSlk_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                    break;
                #endregion

                #region [ ASSOC ]
                case DATA_ENUM.OST_Types.ASSOC:
                    Action_backgroundWorker.ReportProgress(0, "Performing ASSOC audit");
                    Dictionary<DATA_ENUM.STP, List<Data.OST.ASSOC_Data>> assocAuditData = new Dictionary<DATA_ENUM.STP, List<Data.OST.ASSOC_Data>>();
                    foreach (KeyValuePair<DATA_ENUM.STP, Data.OST.STP_Info> item in STPsInfo)
                        assocAuditData.Add(item.Key, item.Value.AssocData);

                    Dictionary<DATA_ENUM.STP, Data.Audits.AuditResult> auditAssoc = Business.Audit.Audits.AuditASSOC(assocAuditData);

                    foreach (DATA_ENUM.STP item in auditAssoc.Keys)
                    {
                        if (!AuditData.ContainsKey(item))
                            AuditData.Add(item, new Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>());

                        if (AuditData[item].ContainsKey(DATA_ENUM.ModuleType.ASSOC))
                            AuditData[item].Remove(DATA_ENUM.ModuleType.ASSOC);

                        AuditData[item].Add(DATA_ENUM.ModuleType.ASSOC, auditAssoc[item]);
                    }
                    auditAssoc_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                    break;
                #endregion

                #region [ LOOPSET ]
                case DATA_ENUM.OST_Types.LOOPSET:
                    Action_backgroundWorker.ReportProgress(0, "Performing LOOPSET audit");
                    Dictionary<DATA_ENUM.STP, List<Data.OST.LOOPSET_Data>> loopsetAuditData = new Dictionary<DATA_ENUM.STP, List<Data.OST.LOOPSET_Data>>();
                    foreach (KeyValuePair<DATA_ENUM.STP, Data.OST.STP_Info> item in STPsInfo)
                        loopsetAuditData.Add(item.Key, item.Value.LoopsetData);

                    Dictionary<DATA_ENUM.STP, Data.Audits.AuditResult> auditLoopset = Business.Audit.Audits.AuditLOOPSET(loopsetAuditData);

                    foreach (DATA_ENUM.STP item in auditLoopset.Keys)
                    {
                        if (!AuditData.ContainsKey(item))
                            AuditData.Add(item, new Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>());

                        if (AuditData[item].ContainsKey(DATA_ENUM.ModuleType.LOOPSET))
                            AuditData[item].Remove(DATA_ENUM.ModuleType.LOOPSET);

                        AuditData[item].Add(DATA_ENUM.ModuleType.LOOPSET, auditLoopset[item]);
                    }
                    auditLoopset_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                    break;
                #endregion

                #region [ TTMAP ]
                case DATA_ENUM.OST_Types.TTMAP:
                    Action_backgroundWorker.ReportProgress(0, "Performing TTMAP audit");
                    Dictionary<DATA_ENUM.STP, List<Data.OST.TTMAP_Data>> ttmapAuditData = new Dictionary<DATA_ENUM.STP, List<Data.OST.TTMAP_Data>>();
                    foreach (KeyValuePair<DATA_ENUM.STP, Data.OST.STP_Info> item in STPsInfo)
                        ttmapAuditData.Add(item.Key, item.Value.TTMapData);

                    Dictionary<DATA_ENUM.STP, Data.Audits.AuditResult> auditTTMap = Business.Audit.Audits.AuditTTMAP(ttmapAuditData);

                    foreach (DATA_ENUM.STP item in auditTTMap.Keys)
                    {
                        if (!AuditData.ContainsKey(item))
                            AuditData.Add(item, new Dictionary<DATA_ENUM.ModuleType, Data.Audits.AuditResult>());

                        if (AuditData[item].ContainsKey(DATA_ENUM.ModuleType.TTMAP))
                            AuditData[item].Remove(DATA_ENUM.ModuleType.TTMAP);

                        AuditData[item].Add(DATA_ENUM.ModuleType.TTMAP, auditTTMap[item]);
                    }
                    auditTTMap_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                    break;
                    #endregion
            }
        }
        #endregion

        #region [ Show Audit Result ]
        private void ShowAuditResult()
        {
            auditSelectedExcel_button.Visible = false;

            if (AuditType == DATA_ENUM.OST_Types.All)
            {
                SetAuditNumbers(DATA_ENUM.ModuleType.GTA);
                auditModuleHeader_label.Visible = false;

                if (AuditData.Values.SelectMany(s => s.Values).Where(w => w.Differences.Count > 0 || w.NotInRAT1.Count > 0 || w.NotInSTP.Count > 0).Count() > 0)
                    allAuditData_panel.Visible = true;
            }
            else
            {
                auditSelectedExcel_button.Visible = SetAuditNumbers((DATA_ENUM.ModuleType)Enum.Parse(typeof(DATA_ENUM.ModuleType), auditType_comboBox.Text));
                auditModuleHeader_label.Text = auditType_comboBox.Text;
                auditModuleHeader_label.Visible = true;

                allAuditData_panel.Visible = false;

                rat2Mrat1_linkLabel.LinkArea = new LinkArea(0, rat2Mrat1_linkLabel.Text.Length);
            }

            SetLinklabelArea(new List<LinkLabel>()
                {
                    rat2Mrat1_linkLabel,
                    rat2Missing_linkLabel,
                    rat2Diff_linkLabel,
                    mil1Mrat1_linkLabel,
                    mil1Missing_linkLabel,
                    mil1Diff_linkLabel,
                    mil2Mrat1_linkLabel,
                    mil2Missing_linkLabel,
                    mil2Diff_linkLabel
                },
                AuditType != DATA_ENUM.OST_Types.All);

            allAuditResultExcel_button.Visible = AuditData.Values.SelectMany(s => s.Values).Where(w => w.Differences.Count > 0 || w.NotInRAT1.Count > 0 || w.NotInSTP.Count > 0).Count() > 0;
            audits_panel.Visible = true;
            auditsPerformed_groupBox.Visible = true;
            auditDetails_panel.Visible = false;
        }
        #endregion

        #region [ Set Audit Numbers ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mType"></param>
        /// <returns></returns>
        private bool SetAuditNumbers(DATA_ENUM.ModuleType mType)
        {
            bool hasElements, result;
            hasElements = result = false;

            hasElements = SetAuditNumbers(DATA_ENUM.STP.RAT2, mType, rat2Mrat1_linkLabel, rat2Missing_linkLabel, rat2Diff_linkLabel);
            if (hasElements)
                result = true;
            hasElements = SetAuditNumbers(DATA_ENUM.STP.MIL1, mType, mil1Mrat1_linkLabel, mil1Missing_linkLabel, mil1Diff_linkLabel);
            if (hasElements)
                result = true;
            hasElements = SetAuditNumbers(DATA_ENUM.STP.MIL2, mType, mil2Mrat1_linkLabel, mil2Missing_linkLabel, mil2Diff_linkLabel);
            if (hasElements)
                result = true;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stpType"></param>
        /// <param name="mType"></param>
        /// <param name="missingRat"></param>
        /// <param name="missingStp"></param>
        /// <param name="diffStp"></param>
        private bool SetAuditNumbers(DATA_ENUM.STP stpType, DATA_ENUM.ModuleType mType, Label missingRat, Label missingStp, Label diffStp)
        {
            string missingRat1String = "Missing in RAT1... {0}";
            string missingStpString = "Missing in {0}... {1}";
            string differenceString = "Differences....... {0}";
            bool hasElements = false;

            if (AuditType != DATA_ENUM.OST_Types.All)
            {
                if (AuditData.ContainsKey(stpType))
                {
                    if (AuditData[stpType].ContainsKey(mType))
                    {
                        missingRat.Text = string.Format(missingRat1String, AuditData[stpType][mType].NotInRAT1.Count().ToString());
                        missingStp.Text = string.Format(missingStpString, stpType.ToString(), AuditData[stpType][mType].NotInSTP.Count().ToString());
                        diffStp.Text = string.Format(differenceString, AuditData[stpType][mType].Differences.Count().ToString());
                        hasElements = ModuleAuditHasCorrections(mType, new List<DATA_ENUM.STP>() { stpType });
                    }
                    else
                    {
                        missingRat.Text = string.Format(missingRat1String, "0");
                        missingStp.Text = string.Format(missingStpString, stpType.ToString(), "0");
                        diffStp.Text = string.Format(differenceString, "0");
                    }
                }
            }
            else
            {
                if (AuditData.ContainsKey(stpType))
                {
                    int missingRat1 = AuditData[stpType].Values.SelectMany(s => s.NotInRAT1).Count();
                    int missingInStp = AuditData[stpType].Values.SelectMany(s => s.NotInSTP).Count();
                    int differences = AuditData[stpType].Values.SelectMany(s => s.Differences).Count();

                    missingRat.Text = string.Format(missingRat1String, AuditData[stpType].Values.SelectMany(s => s.NotInRAT1).Count().ToString());
                    missingStp.Text = string.Format(missingStpString, stpType.ToString(), AuditData[stpType].Values.SelectMany(s => s.NotInSTP).Count().ToString());
                    diffStp.Text = string.Format(differenceString, AuditData[stpType].Values.SelectMany(s => s.Differences).Count().ToString());
                    hasElements = (missingRat1 > 0 || missingInStp > 0 || differences> 0);
                }
            }

            return hasElements;
        }
        #endregion

        #region [ Check Corrections ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        private bool CheckCorrections(DATA_ENUM.ModuleType module)
        {
            return ModuleAuditHasCorrections(module, new List<DATA_ENUM.STP>() { DATA_ENUM.STP.RAT2, DATA_ENUM.STP.MIL1, DATA_ENUM.STP.MIL2 });
        }
        #endregion

        #region [ Module Audit Has Corrections ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="module"></param>
        /// <param name="stpValues"></param>
        /// <returns></returns>
        private bool ModuleAuditHasCorrections(DATA_ENUM.ModuleType module, List<DATA_ENUM.STP> stpValues)
        {
            //List<Data.Audits.AuditResult> modulesValues = AuditData.Values.Where(w => w.Keys.Contains(module)).SelectMany(s => s.Values).ToList();

            List<Data.Audits.AuditResult> modulesValues = AuditData.Values.Where(w => w.Keys.Contains(module)).Count() > 0 ? modulesValues = AuditData.Values.Select(s => s[module]).ToList() : null;
                        return modulesValues.SelectMany(s => s.NotInRAT1).Count() > 0 || modulesValues.SelectMany(s => s.NotInSTP).Count() > 0 || modulesValues.SelectMany(s => s.Differences).Count() > 0;
        }
        #endregion

        #region [ Audit results LinkLabels ]
        private void rat2Mrat1_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rat2Mrat1_linkLabel.Text.Substring(rat2Mrat1_linkLabel.Text.Length - 1, 1) != "0")
                SetAuditDetailsGridData(DATA_ENUM.STP.RAT2, DATA_ENUM.Audit.ResultType.NotInRAT1);
            else
                auditDetails_panel.Visible = false;
        }

        private void rat2Missing_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rat2Mrat1_linkLabel.Text.Substring(rat2Mrat1_linkLabel.Text.Length - 1, 1) != "0")
                SetAuditDetailsGridData(DATA_ENUM.STP.RAT2, DATA_ENUM.Audit.ResultType.NotInSTP);
            else
                auditDetails_panel.Visible = false;
        }

        private void rat2Diff_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rat2Diff_linkLabel.Text.Substring(rat2Diff_linkLabel.Text.Length - 1, 1) != "0")
                SetAuditDetailsGridData(DATA_ENUM.STP.RAT2, DATA_ENUM.Audit.ResultType.Differences);
            else
                auditDetails_panel.Visible = false;
        }

        private void mil1Mrat1_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (mil1Mrat1_linkLabel.Text.Substring(mil1Mrat1_linkLabel.Text.Length - 1, 1) != "0")
                SetAuditDetailsGridData(DATA_ENUM.STP.MIL1, DATA_ENUM.Audit.ResultType.NotInRAT1);
            else
                auditDetails_panel.Visible = false;
        }

        private void mil1Missing_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (mil1Missing_linkLabel.Text.Substring(mil1Missing_linkLabel.Text.Length - 1, 1) != "0")
                SetAuditDetailsGridData(DATA_ENUM.STP.MIL1, DATA_ENUM.Audit.ResultType.NotInSTP);
            else
                auditDetails_panel.Visible = false;
        }

        private void mil1Diff_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (mil1Diff_linkLabel.Text.Substring(mil1Diff_linkLabel.Text.Length - 1, 1) != "0")
                SetAuditDetailsGridData(DATA_ENUM.STP.MIL1, DATA_ENUM.Audit.ResultType.Differences);
            else
                auditDetails_panel.Visible = false;
        }

        private void mil2Mrat1_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (mil2Mrat1_linkLabel.Text.Substring(mil2Mrat1_linkLabel.Text.Length - 1, 1) != "0")
                SetAuditDetailsGridData(DATA_ENUM.STP.MIL2, DATA_ENUM.Audit.ResultType.NotInRAT1);
            else
                auditDetails_panel.Visible = false;
        }

        private void mil2Missing_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (mil2Missing_linkLabel.Text.Substring(mil2Missing_linkLabel.Text.Length - 1, 1) != "0")
                SetAuditDetailsGridData(DATA_ENUM.STP.MIL2, DATA_ENUM.Audit.ResultType.NotInSTP);
            else
                auditDetails_panel.Visible = false;
        }

        private void mil2Diff_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (mil2Diff_linkLabel.Text.Substring(mil2Diff_linkLabel.Text.Length - 1, 1) != "0")
                SetAuditDetailsGridData(DATA_ENUM.STP.MIL2, DATA_ENUM.Audit.ResultType.Differences);
            else
                auditDetails_panel.Visible = false;
        }
        #endregion

        #region [ Set Audit Details Grid Data ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stp"></param>
        /// <param name="rType"></param>
        private void SetAuditDetailsGridData(DATA_ENUM.STP stp, DATA_ENUM.Audit.ResultType rType)
        {
            if (AuditType != DATA_ENUM.OST_Types.All)
            {
                DATA_ENUM.ModuleType mType = (DATA_ENUM.ModuleType)Enum.Parse(typeof(DATA_ENUM.ModuleType), auditType_comboBox.Text);
                List<string> searchElements = null;
                DATA_ENUM.STP stpSearch = DATA_ENUM.STP.RAT1;
                DataGridViewAutoSizeColumnsMode columnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                try
                {
                    switch (rType)
                    {
                        case DATA_ENUM.Audit.ResultType.NotInRAT1:
                            searchElements = AuditData[stp][mType].NotInRAT1;
                            stpSearch = stp;
                            break;

                        case DATA_ENUM.Audit.ResultType.NotInSTP:
                            searchElements = AuditData[stp][mType].NotInSTP;
                            break;

                        case DATA_ENUM.Audit.ResultType.Differences:
                            searchElements = AuditData[stp][mType].Differences;
                            break;
                    }

                    switch (mType)
                    {
                        case DATA_ENUM.ModuleType.GTA:
                            var gtaGridElements = from t in STPsInfo[stpSearch].GTA_Data.Where(w => searchElements.Contains(w.GTA_ID))
                                                  orderby t.Table
                                                  select new { Table = t.Table, Start_GTA = t.Start_GTA, End_GTA = t.End_GTA };
                            auditDetails_dataGridView.DataSource = gtaGridElements.ToList();
                            break;

                        case DATA_ENUM.ModuleType.OPCODE:
                            var opcodeGridElements = from t in STPsInfo[stpSearch].OpCodeData.Where(w => searchElements.Contains(w.OPCODE_ID))
                                                     orderby t.Table
                                                     select new { Table = t.Table, OPCODE = t.OPCODE };
                            auditDetails_dataGridView.DataSource = opcodeGridElements.ToList();
                            break;

                        case DATA_ENUM.ModuleType.GTTSEL:
                            var gttselGridElements = from t in STPsInfo[stpSearch].GTTSelData.Where(w => searchElements.Contains(w.GTTSEL_ID))
                                                     orderby t.TT
                                                     select new { TT = t.TT, NP = t.NP, NAI = t.NAI, LSN = t.LSN };
                            auditDetails_dataGridView.DataSource = gttselGridElements.ToList();
                            break;

                        case DATA_ENUM.ModuleType.GTTSET:
                            var gttsetGridElements = from t in STPsInfo[stpSearch].GTTSetData.Where(w => searchElements.Contains(w.GTTSET_ID))
                                                     orderby t.GTTSN
                                                     select new
                                                     {
                                                         GTTSN = t.GTTSN,
                                                         TYPE = t.Type.ToString(),
                                                         CHECKM = t.CHECKMULCOMP,
                                                         SETIDX = t.SETIDX
                                                     };
                            auditDetails_dataGridView.DataSource = gttsetGridElements.ToList();
                            break;

                        case DATA_ENUM.ModuleType.MRNSET:
                            var mrnsetGridElements = from t in STPsInfo[stpSearch].MrnsetData.Where(w => searchElements.Contains(w.MRNSET_ID))
                                                     orderby t.MRNSET
                                                     select new { MRNSET = t.MRNSET, NET = t.NET, PC = t.PC, RC = t.RC, CLLI = t.CLLI };
                            auditDetails_dataGridView.DataSource = mrnsetGridElements.ToList();
                            break;

                        case DATA_ENUM.ModuleType.DSTN:
                            var dstnGridElements = from t in STPsInfo[stpSearch].DstnData.Where(w => searchElements.Contains(w.DSTN_ID))
                                                   orderby t.DPC
                                                   select new
                                                   {
                                                       DPC = t.DPC,
                                                       TYPE = t.Type.ToString(),
                                                       CLLI = t.CLLI,
                                                       LSN = t.LSN.Substring(0, t.LSN.Length - 1),
                                                       RC = t.RC,
                                                       APCI =
                                                       t.APCI
                                                   };
                            auditDetails_dataGridView.DataSource = dstnGridElements.ToList();
                            break;

                        case DATA_ENUM.ModuleType.SLK:
                            var slkGridElements = from t in STPsInfo[stpSearch].SlkData.Where(w => searchElements.Contains(w.SLK_ID))
                                                  orderby t.LOC
                                                  select new
                                                  {
                                                      LOC = t.LOC,
                                                      LINK = t.LINK,
                                                      LSN = t.LSN,
                                                      SLC = t.SLC,
                                                      TYPE = t.TYPE,
                                                      ANAME = t.ANAME
                                                  };
                            auditDetails_dataGridView.DataSource = slkGridElements.ToList();
                            columnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                            break;

                        case DATA_ENUM.ModuleType.ASSOC:
                            var assocGridElements = from t in STPsInfo[stpSearch].AssocData.Where(w => searchElements.Contains(w.ASSOC_ID))
                                                    orderby t.ANAME
                                                    select new
                                                    {
                                                        ANAME = t.ANAME,
                                                        LOC = t.LOC,
                                                        PORT = t.PORT,
                                                        ADAPTER = t.ADAPTER
                                                    };
                            auditDetails_dataGridView.DataSource = assocGridElements.ToList();
                            columnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                            break;

                        case DATA_ENUM.ModuleType.LOOPSET:
                            var loopsetGridElements = from t in STPsInfo[stpSearch].LoopsetData.Where(w => searchElements.Contains(w.LOOPSET_ID))
                                                      orderby t.Loopset
                                                      select new
                                                    {
                                                        LOOPSET = t.Loopset,
                                                        POINT_CODE = t.PointCode
                                                    };
                            auditDetails_dataGridView.DataSource = loopsetGridElements.ToList();
                            columnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                            break;

                        case DATA_ENUM.ModuleType.TTMAP:
                            var ttmapGridElements = from t in STPsInfo[stpSearch].TTMapData.Where(w => searchElements.Contains(w.TTMAP_ID))
                                                      orderby t.LSN
                                                    select new
                                                    {
                                                        LSN = t.LSN,
                                                        IO = t.IO,
                                                        ETT = t.ETT,
                                                        MTT = t.MTT
                                                      };
                            auditDetails_dataGridView.DataSource = ttmapGridElements.ToList();
                            columnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                auditDetails_dataGridView.AutoSizeColumnsMode = columnsMode;

                auditDetailsSTP_label.Text = stp.ToString();
                auditDetailsHeader_label.Text = string.Format("--> {0}{1}",
                    rType == DATA_ENUM.Audit.ResultType.Differences ? "Differences with RAT1" : "Missing records in ",
                    rType == DATA_ENUM.Audit.ResultType.Differences ? string.Empty :
                    rType == DATA_ENUM.Audit.ResultType.NotInSTP ? stp.ToString() : "RAT1");

                auditDetails_panel.Visible = true;
            }
        }
        #endregion

        #region [ Audit Details DataGridView DataBindingComplete ]
        private void auditDetails_dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < auditDetails_dataGridView.ColumnCount; i++)
            {
                auditDetails_dataGridView.Columns[i].HeaderCell.Style.BackColor = Color.FromArgb(200, 6, 27);
                auditDetails_dataGridView.Columns[i].HeaderCell.Style.ForeColor = Color.White;
                auditDetails_dataGridView.Columns[i].HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            }
            auditDetails_dataGridView.ClearSelection();
        }
        #endregion

        #region [ All Audit Excel Button Click ]
        private void AllAuditExcel(object sender, EventArgs e)
        {
            AuditType = DATA_ENUM.OST_Types.All;
            GenerateExcel(true);
        }
        #endregion

        #region [ Audit Generate Excel ]
        private void AuditGenerateExcel()
        {
            string excelBuildMessage = "Generating {0}-{1} Excel Sheet";

            OfficeOpenXml.ExcelPackage xlPackage = MLVSoft_Common.Excel.ExcelBuilder.BuildExcelPackage(FilePath);

            OfficeOpenXml.ExcelWorksheet notInRAT1workSheet = null;
            OfficeOpenXml.ExcelWorksheet notInStpworkSheet = null;

            Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet> differencesWorkSheet = null;
            Dictionary<DATA_ENUM.ModuleType, int> differencesRowIndex = null;

            List<string> notInRat1Values = null;
            List<string> notInStpValues = null;
            Dictionary<List<string>, List<string>> differencesData = null;
            List<string> commands = null;
            List<string> rollbacks = null;

            int notInRAT1RowIndex = 2;
            int notInStpRowIndex = 2;

            try
            {
                if (AuditData.Values.SelectMany(s => s.Values).SelectMany(s => s.NotInRAT1).Count() > 0)
                    notInRAT1workSheet = Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.NotInRAT1, DATA_ENUM.ModuleType.GTA);

                if (AuditData.Values.SelectMany(s => s.Values).SelectMany(s => s.NotInSTP).Count() > 0)
                    notInStpworkSheet = Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.NotInSTP, DATA_ENUM.ModuleType.GTA);

                foreach (DATA_ENUM.STP stp in AuditData.Keys)
                {
                    #region [ GTA ]
                    if ((AuditType == DATA_ENUM.OST_Types.All && CheckCorrections(DATA_ENUM.ModuleType.GTA)) || AuditType == DATA_ENUM.OST_Types.GTA)
                    {
                        Action_backgroundWorker.ReportProgress(0, string.Format(excelBuildMessage, stp.ToString(), "GTA"));

                        notInRat1Values = STPsInfo[stp].GTA_Data.Select(s => s.GTA_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.GTA].NotInRAT1).ToList();
                        if (notInRat1Values.Count > 0)
                        {
                            commands = new List<string>();
                            rollbacks = new List<string>();

                            foreach (string item in notInRat1Values)
                            {
                                string[] commandStrings = Business.Audit.Commands.GetCommand_GTA(STPsInfo[stp].GTA_Data.Where(w => w.GTA_ID == item).First());
                                commands.Add(commandStrings[0]);
                                rollbacks.Add(commandStrings[1]);
                            }
                        }
                        notInRAT1RowIndex = Business.Excel.Audits.InsertNotInRecords(notInRAT1workSheet, stp, DATA_ENUM.ModuleType.GTA, notInRat1Values.Select(s => s.Replace("|", ";")).ToList(), notInRAT1RowIndex, commands, rollbacks);

                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].GTA_Data.Select(s => s.GTA_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.GTA].NotInSTP).ToList();
                        if (notInStpValues.Count > 0)
                        {
                            commands = new List<string>();
                            rollbacks = new List<string>();

                            foreach (string item in notInStpValues)
                            {
                                string[] commandStrings = Business.Audit.Commands.GetCommand_GTA(STPsInfo[DATA_ENUM.STP.RAT1].GTA_Data.Where(w => w.GTA_ID == item).First());
                                commands.Add(commandStrings[0]);
                                rollbacks.Add(commandStrings[1]);
                            }
                        }
                        notInStpRowIndex = Business.Excel.Audits.InsertNotInRecords(notInStpworkSheet, stp, DATA_ENUM.ModuleType.GTA, notInStpValues.Select(s => s.Replace("|", ";")).ToList(), notInStpRowIndex, commands, rollbacks);

                        //Differences
                        if (AuditData[stp][DATA_ENUM.ModuleType.GTA].Differences.Count() > 0)
                        {
                            if (differencesWorkSheet == null)
                            {
                                differencesWorkSheet = new Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet>();
                                differencesRowIndex = new Dictionary<DATA_ENUM.ModuleType, int>();
                            }

                            if (!differencesWorkSheet.ContainsKey(DATA_ENUM.ModuleType.GTA))
                            {
                                differencesWorkSheet.Add(DATA_ENUM.ModuleType.GTA, Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.Differences, DATA_ENUM.ModuleType.GTA));
                                differencesRowIndex.Add(DATA_ENUM.ModuleType.GTA, 2);
                            }
                            
                            foreach (string item in AuditData[stp][DATA_ENUM.ModuleType.GTA].Differences)
                            {
                                differencesData = new Dictionary<List<string>, List<string>>();
                                differencesData.Add(
                                    STPsInfo[DATA_ENUM.STP.RAT1].GTA_Data.Where(w => w.GTA_ID == item).Select(s => s.GTA_AuditFields).First(),
                                    STPsInfo[stp].GTA_Data.Where(w => w.GTA_ID == item).Select(s => s.GTA_AuditFields).First());

                                differencesRowIndex[DATA_ENUM.ModuleType.GTA] = Business.Excel.Audits.InsertDifferencesRecords(
                                    differencesWorkSheet[DATA_ENUM.ModuleType.GTA], 
                                    stp,
                                    differencesData, 
                                    differencesRowIndex[DATA_ENUM.ModuleType.GTA]);
                            }
                        }
                    }
                    #endregion

                    #region [ OPCODE ]
                    if ((AuditType == DATA_ENUM.OST_Types.All && CheckCorrections(DATA_ENUM.ModuleType.OPCODE)) || AuditType == DATA_ENUM.OST_Types.OPCODE)
                    {
                        Action_backgroundWorker.ReportProgress(0, string.Format(excelBuildMessage, stp.ToString(), "OPCODE"));

                        notInRat1Values = STPsInfo[stp].OpCodeData.Select(s => s.OPCODE_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.OPCODE].NotInRAT1).ToList();
                        notInRAT1RowIndex = Business.Excel.Audits.InsertNotInRecords(notInRAT1workSheet, stp, DATA_ENUM.ModuleType.OPCODE, notInRat1Values.Select(s => s.Replace("|", ";")).ToList(), notInRAT1RowIndex);

                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].OpCodeData.Select(s => s.OPCODE_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.OPCODE].NotInSTP).ToList();
                        notInStpRowIndex = Business.Excel.Audits.InsertNotInRecords(notInStpworkSheet, stp, DATA_ENUM.ModuleType.OPCODE, notInStpValues.Select(s => s.Replace("|", ";")).ToList(), notInStpRowIndex);

                        //Differences
                        if (AuditData[stp][DATA_ENUM.ModuleType.OPCODE].Differences.Count() > 0)
                        {
                            if (differencesWorkSheet == null)
                            {
                                differencesWorkSheet = new Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet>();
                                differencesRowIndex = new Dictionary<DATA_ENUM.ModuleType, int>();
                            }

                            if (!differencesWorkSheet.ContainsKey(DATA_ENUM.ModuleType.OPCODE))
                            {
                                differencesWorkSheet.Add(DATA_ENUM.ModuleType.OPCODE, Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.Differences, DATA_ENUM.ModuleType.OPCODE));
                                differencesRowIndex.Add(DATA_ENUM.ModuleType.OPCODE, 2);
                            }

                            foreach (string item in AuditData[stp][DATA_ENUM.ModuleType.OPCODE].Differences)
                            {
                                differencesData = new Dictionary<List<string>, List<string>>();
                                differencesData.Add(
                                    STPsInfo[DATA_ENUM.STP.RAT1].OpCodeData.Where(w => w.OPCODE_ID == item).Select(s => s.OPCODE_AuditFields).First(),
                                    STPsInfo[stp].OpCodeData.Where(w => w.OPCODE_ID == item).Select(s => s.OPCODE_AuditFields).First());

                                differencesRowIndex[DATA_ENUM.ModuleType.OPCODE] = Business.Excel.Audits.InsertDifferencesRecords(
                                    differencesWorkSheet[DATA_ENUM.ModuleType.OPCODE],
                                    stp,
                                    differencesData,
                                    differencesRowIndex[DATA_ENUM.ModuleType.OPCODE]);
                            }
                        }

                    }
                    #endregion

                    #region [ GTTSEL ]
                    if ((AuditType == DATA_ENUM.OST_Types.All && CheckCorrections(DATA_ENUM.ModuleType.GTTSEL)) || AuditType == DATA_ENUM.OST_Types.GTTSEL)
                    {
                        Action_backgroundWorker.ReportProgress(0, string.Format(excelBuildMessage, stp.ToString(), "GTTSEL"));

                        notInRat1Values = STPsInfo[stp].GTTSelData.Select(s => s.GTTSEL_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.GTTSEL].NotInRAT1).ToList();
                        notInRat1Values = STPsInfo[stp].GTTSelData.Where(w => notInRat1Values.Contains(w.GTTSEL_ID)).Select(s => s.GTTSEL_AuditDetail).ToList();
                        notInRAT1RowIndex = Business.Excel.Audits.InsertNotInRecords(notInRAT1workSheet, stp, DATA_ENUM.ModuleType.GTTSEL, notInRat1Values.Select(s => s.Replace("|", ";")).ToList(), notInRAT1RowIndex);

                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].GTTSelData.Select(s => s.GTTSEL_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.GTTSEL].NotInSTP).ToList();
                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].GTTSelData.Where(w => notInStpValues.Contains(w.GTTSEL_ID)).Select(s => s.GTTSEL_AuditDetail).ToList();
                        notInStpRowIndex = Business.Excel.Audits.InsertNotInRecords(notInStpworkSheet, stp, DATA_ENUM.ModuleType.GTTSEL, notInStpValues.Select(s => s.Replace("|", ";")).ToList(), notInStpRowIndex);

                        //Differences
                        if (AuditData[stp][DATA_ENUM.ModuleType.GTTSEL].Differences.Count() > 0)
                        {
                            if (differencesWorkSheet == null)
                            {
                                differencesWorkSheet = new Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet>();
                                differencesRowIndex = new Dictionary<DATA_ENUM.ModuleType, int>();
                            }

                            if (!differencesWorkSheet.ContainsKey(DATA_ENUM.ModuleType.GTTSEL))
                            {
                                differencesWorkSheet.Add(DATA_ENUM.ModuleType.GTTSEL, Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.Differences, DATA_ENUM.ModuleType.GTTSEL));
                                differencesRowIndex.Add(DATA_ENUM.ModuleType.GTTSEL, 2);
                            }

                            foreach (string item in AuditData[stp][DATA_ENUM.ModuleType.GTTSEL].Differences)
                            {
                                differencesData = new Dictionary<List<string>, List<string>>();
                                differencesData.Add(
                                    STPsInfo[DATA_ENUM.STP.RAT1].GTTSelData.Where(w => w.GTTSEL_ID == item).Select(s => s.GTTSEL_AuditFields).First(),
                                    STPsInfo[stp].GTTSelData.Where(w => w.GTTSEL_ID == item).Select(s => s.GTTSEL_AuditFields).First());

                                differencesRowIndex[DATA_ENUM.ModuleType.GTTSEL] = Business.Excel.Audits.InsertDifferencesRecords(
                                    differencesWorkSheet[DATA_ENUM.ModuleType.GTTSEL],
                                    stp,
                                    differencesData,
                                    differencesRowIndex[DATA_ENUM.ModuleType.GTTSEL]);
                            }
                        }
                    }
                    #endregion

                    #region [ GTTSET ]
                    if ((AuditType == DATA_ENUM.OST_Types.All && CheckCorrections(DATA_ENUM.ModuleType.GTTSET)) || AuditType == DATA_ENUM.OST_Types.GTTSET)
                    {
                        Action_backgroundWorker.ReportProgress(0, string.Format(excelBuildMessage, stp.ToString(), "GTTSET"));

                        //NotInRAT1
                        notInRat1Values = STPsInfo[stp].GTTSetData.Select(s => s.GTTSET_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.GTTSET].NotInRAT1).ToList();
                        notInRat1Values = STPsInfo[stp].GTTSetData.Where(w => notInRat1Values.Contains(w.GTTSET_ID)).Select(s => s.GTTSET_AuditDetail).ToList();
                        notInRAT1RowIndex = Business.Excel.Audits.InsertNotInRecords(notInRAT1workSheet, stp, DATA_ENUM.ModuleType.GTTSET, notInRat1Values.Select(s => s.Replace("|", ";")).ToList(), notInRAT1RowIndex);

                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].GTTSetData.Select(s => s.GTTSET_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.GTTSET].NotInSTP).ToList();
                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].GTTSetData.Where(w => notInStpValues.Contains(w.GTTSET_ID)).Select(s => s.GTTSET_AuditDetail).ToList();
                        notInStpRowIndex = Business.Excel.Audits.InsertNotInRecords(notInStpworkSheet, stp, DATA_ENUM.ModuleType.GTTSET, notInStpValues.Select(s => s.Replace("|", ";")).ToList(), notInStpRowIndex);

                        //Differences
                        if (AuditData[stp][DATA_ENUM.ModuleType.GTTSET].Differences.Count() > 0)
                        {
                            if (differencesWorkSheet == null)
                            {
                                differencesWorkSheet = new Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet>();
                                differencesRowIndex = new Dictionary<DATA_ENUM.ModuleType, int>();
                            }

                            if (!differencesWorkSheet.ContainsKey(DATA_ENUM.ModuleType.GTTSET))
                            {
                                differencesWorkSheet.Add(DATA_ENUM.ModuleType.GTTSET, Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.Differences, DATA_ENUM.ModuleType.GTTSET));
                                differencesRowIndex.Add(DATA_ENUM.ModuleType.GTTSET, 2);
                            }

                            foreach (string item in AuditData[stp][DATA_ENUM.ModuleType.GTTSET].Differences)
                            {
                                differencesData = new Dictionary<List<string>, List<string>>();
                                differencesData.Add(
                                    STPsInfo[DATA_ENUM.STP.RAT1].GTTSetData.Where(w => w.GTTSET_ID == item).Select(s => s.GTTSET_AuditFields).First(),
                                    STPsInfo[stp].GTTSetData.Where(w => w.GTTSET_ID == item).Select(s => s.GTTSET_AuditFields).First());

                                differencesRowIndex[DATA_ENUM.ModuleType.GTTSET] = Business.Excel.Audits.InsertDifferencesRecords(
                                    differencesWorkSheet[DATA_ENUM.ModuleType.GTTSET],
                                    stp,
                                    differencesData,
                                    differencesRowIndex[DATA_ENUM.ModuleType.GTTSET]);
                            }
                        }
                    }
                    #endregion

                    #region [ MRNSET ]
                    if ((AuditType == DATA_ENUM.OST_Types.All && CheckCorrections(DATA_ENUM.ModuleType.MRNSET)) || AuditType == DATA_ENUM.OST_Types.MRNSET)
                    {
                        Action_backgroundWorker.ReportProgress(0, string.Format(excelBuildMessage, stp.ToString(), "MRNSET"));

                        notInRat1Values = STPsInfo[stp].MrnsetData.Select(s => s.MRNSET_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.MRNSET].NotInRAT1).ToList();
                        notInRat1Values = STPsInfo[stp].MrnsetData.Where(w => notInRat1Values.Contains(w.MRNSET_ID)).Select(s => s.MRNSET_Footprint).ToList();
                        notInRAT1RowIndex = Business.Excel.Audits.InsertNotInRecords(notInRAT1workSheet, stp, DATA_ENUM.ModuleType.MRNSET, notInRat1Values.Select(s => s.Replace("|", ";")).ToList(), notInRAT1RowIndex);

                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].MrnsetData.Select(s => s.MRNSET_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.MRNSET].NotInSTP).ToList();
                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].MrnsetData.Where(w => notInStpValues.Contains(w.MRNSET_ID)).Select(s => s.MRNSET_Footprint).ToList();
                        notInStpRowIndex = Business.Excel.Audits.InsertNotInRecords(notInStpworkSheet, stp, DATA_ENUM.ModuleType.MRNSET, notInStpValues.Select(s => s.Replace("|", ";")).ToList(), notInStpRowIndex);

                        //Differences
                        if (AuditData[stp][DATA_ENUM.ModuleType.MRNSET].Differences.Count() > 0)
                        {
                            if (differencesWorkSheet == null)
                            {
                                differencesWorkSheet = new Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet>();
                                differencesRowIndex = new Dictionary<DATA_ENUM.ModuleType, int>();
                            }

                            if (!differencesWorkSheet.ContainsKey(DATA_ENUM.ModuleType.MRNSET))
                            {
                                differencesWorkSheet.Add(DATA_ENUM.ModuleType.MRNSET, Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.Differences, DATA_ENUM.ModuleType.MRNSET));
                                differencesRowIndex.Add(DATA_ENUM.ModuleType.MRNSET, 2);
                            }

                            foreach (string item in AuditData[stp][DATA_ENUM.ModuleType.MRNSET].Differences)
                            {
                                differencesData = new Dictionary<List<string>, List<string>>();
                                differencesData.Add(
                                    STPsInfo[DATA_ENUM.STP.RAT1].MrnsetData.Where(w => w.MRNSET_ID == item).Select(s => s.MRNSET_AuditFields).First(),
                                    STPsInfo[stp].MrnsetData.Where(w => w.MRNSET_ID == item).Select(s => s.MRNSET_AuditFields).First());

                                differencesRowIndex[DATA_ENUM.ModuleType.MRNSET] = Business.Excel.Audits.InsertDifferencesRecords(
                                    differencesWorkSheet[DATA_ENUM.ModuleType.MRNSET],
                                    stp,
                                    differencesData,
                                    differencesRowIndex[DATA_ENUM.ModuleType.MRNSET]);
                            }
                        }
                    }
                    #endregion

                    #region [ DSTN ]
                    if ((AuditType == DATA_ENUM.OST_Types.All && CheckCorrections(DATA_ENUM.ModuleType.DSTN)) || AuditType == DATA_ENUM.OST_Types.DSTN)
                    {
                        Action_backgroundWorker.ReportProgress(0, string.Format(excelBuildMessage, stp.ToString(), "DSTN"));

                        notInRat1Values = STPsInfo[stp].DstnData.Select(s => s.DSTN_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.DSTN].NotInRAT1).ToList();
                        notInRat1Values = STPsInfo[stp].DstnData.Where(w => notInRat1Values.Contains(w.DSTN_ID)).Select(s => s.DSTN_Footprint).ToList();
                        notInRAT1RowIndex = Business.Excel.Audits.InsertNotInRecords(notInRAT1workSheet, stp, DATA_ENUM.ModuleType.DSTN, notInRat1Values.Select(s => s.Replace("|", ";")).ToList(), notInRAT1RowIndex);

                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].DstnData.Select(s => s.DSTN_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.DSTN].NotInSTP).ToList();
                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].DstnData.Where(w => notInStpValues.Contains(w.DSTN_ID)).Select(s => s.DSTN_Footprint).ToList();
                        notInStpRowIndex = Business.Excel.Audits.InsertNotInRecords(notInStpworkSheet, stp, DATA_ENUM.ModuleType.DSTN, notInStpValues.Select(s => s.Replace("|", ";")).ToList(), notInStpRowIndex);

                        //Differences
                        if (AuditData[stp][DATA_ENUM.ModuleType.DSTN].Differences.Count() > 0)
                        {
                            if (differencesWorkSheet == null)
                            {
                                differencesWorkSheet = new Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet>();
                                differencesRowIndex = new Dictionary<DATA_ENUM.ModuleType, int>();
                            }

                            if (!differencesWorkSheet.ContainsKey(DATA_ENUM.ModuleType.DSTN))
                            {
                                differencesWorkSheet.Add(DATA_ENUM.ModuleType.DSTN, Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.Differences, DATA_ENUM.ModuleType.DSTN));
                                differencesRowIndex.Add(DATA_ENUM.ModuleType.DSTN, 2);
                            }

                            foreach (string item in AuditData[stp][DATA_ENUM.ModuleType.DSTN].Differences)
                            {
                                differencesData = new Dictionary<List<string>, List<string>>();
                                differencesData.Add(
                                    STPsInfo[DATA_ENUM.STP.RAT1].DstnData.Where(w => w.DSTN_ID == item).Select(s => s.DSTN_AuditFields).First(),
                                    STPsInfo[stp].DstnData.Where(w => w.DSTN_ID == item).Select(s => s.DSTN_AuditFields).First());

                                differencesRowIndex[DATA_ENUM.ModuleType.DSTN] = Business.Excel.Audits.InsertDifferencesRecords(
                                    differencesWorkSheet[DATA_ENUM.ModuleType.DSTN],
                                    stp,
                                    differencesData,
                                    differencesRowIndex[DATA_ENUM.ModuleType.DSTN]);
                            }
                        }
                    }
                    #endregion

                    #region [ SLK ]
                    if ((AuditType == DATA_ENUM.OST_Types.All && CheckCorrections(DATA_ENUM.ModuleType.SLK)) || AuditType == DATA_ENUM.OST_Types.SLK)
                    {
                        Action_backgroundWorker.ReportProgress(0, string.Format(excelBuildMessage, stp.ToString(), "SLK"));

                        notInRat1Values = STPsInfo[stp].SlkData.Select(s => s.SLK_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.SLK].NotInRAT1).ToList();
                        notInRat1Values = STPsInfo[stp].SlkData.Where(w => notInRat1Values.Contains(w.SLK_ID)).Select(s => s.SLK_AuditDetail).ToList();
                        notInRAT1RowIndex = Business.Excel.Audits.InsertNotInRecords(notInRAT1workSheet, stp, DATA_ENUM.ModuleType.SLK, notInRat1Values.Select(s => s.Replace("|", ";")).ToList(), notInRAT1RowIndex);

                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].SlkData.Select(s => s.SLK_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.SLK].NotInSTP).ToList();
                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].SlkData.Where(w => notInStpValues.Contains(w.SLK_ID)).Select(s => s.SLK_AuditDetail).ToList();
                        notInStpRowIndex = Business.Excel.Audits.InsertNotInRecords(notInStpworkSheet, stp, DATA_ENUM.ModuleType.SLK, notInStpValues.Select(s => s.Replace("|", ";")).ToList(), notInStpRowIndex);

                        //Differences
                        if (AuditData[stp][DATA_ENUM.ModuleType.SLK].Differences.Count() > 0)
                        {
                            if (differencesWorkSheet == null)
                            {
                                differencesWorkSheet = new Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet>();
                                differencesRowIndex = new Dictionary<DATA_ENUM.ModuleType, int>();
                            }

                            if (!differencesWorkSheet.ContainsKey(DATA_ENUM.ModuleType.SLK))
                            {
                                differencesWorkSheet.Add(DATA_ENUM.ModuleType.SLK, Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.Differences, DATA_ENUM.ModuleType.SLK));
                                differencesRowIndex.Add(DATA_ENUM.ModuleType.SLK, 2);
                            }

                            foreach (string item in AuditData[stp][DATA_ENUM.ModuleType.SLK].Differences)
                            {
                                differencesData = new Dictionary<List<string>, List<string>>();
                                differencesData.Add(
                                    STPsInfo[DATA_ENUM.STP.RAT1].SlkData.Where(w => w.SLK_ID == item).Select(s => s.SLK_AuditFields).First(),
                                    STPsInfo[stp].SlkData.Where(w => w.SLK_ID == item).Select(s => s.SLK_AuditFields).First());

                                differencesRowIndex[DATA_ENUM.ModuleType.SLK] = Business.Excel.Audits.InsertDifferencesRecords(
                                    differencesWorkSheet[DATA_ENUM.ModuleType.SLK],
                                    stp,
                                    differencesData,
                                    differencesRowIndex[DATA_ENUM.ModuleType.SLK]);
                            }
                        }
                    }
                    #endregion

                    #region [ ASSOC ]
                    if ((AuditType == DATA_ENUM.OST_Types.All && CheckCorrections(DATA_ENUM.ModuleType.ASSOC)) || AuditType == DATA_ENUM.OST_Types.ASSOC)
                    {
                        Action_backgroundWorker.ReportProgress(0, string.Format(excelBuildMessage, stp.ToString(), "ASSOC"));

                        notInRat1Values = STPsInfo[stp].AssocData.Select(s => s.ASSOC_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.ASSOC].NotInRAT1).ToList();
                        notInRat1Values = STPsInfo[stp].AssocData.Where(w => notInRat1Values.Contains(w.ASSOC_ID)).Select(s => s.ASSOC_AuditDetail).ToList();
                        notInRAT1RowIndex = Business.Excel.Audits.InsertNotInRecords(notInRAT1workSheet, stp, DATA_ENUM.ModuleType.ASSOC, notInRat1Values.Select(s => s.Replace("|", ";")).ToList(), notInRAT1RowIndex);

                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].AssocData.Select(s => s.ASSOC_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.ASSOC].NotInSTP).ToList();
                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].AssocData.Where(w => notInStpValues.Contains(w.ASSOC_ID)).Select(s => s.ASSOC_AuditDetail).ToList();
                        notInStpRowIndex = Business.Excel.Audits.InsertNotInRecords(notInStpworkSheet, stp, DATA_ENUM.ModuleType.ASSOC, notInStpValues.Select(s => s.Replace("|", ";")).ToList(), notInStpRowIndex);

                        //Differences
                        if (AuditData[stp][DATA_ENUM.ModuleType.ASSOC].Differences.Count() > 0)
                        {
                            if (differencesWorkSheet == null)
                            {
                                differencesWorkSheet = new Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet>();
                                differencesRowIndex = new Dictionary<DATA_ENUM.ModuleType, int>();
                            }

                            if (!differencesWorkSheet.ContainsKey(DATA_ENUM.ModuleType.ASSOC))
                            {
                                differencesWorkSheet.Add(DATA_ENUM.ModuleType.ASSOC, Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.Differences, DATA_ENUM.ModuleType.ASSOC));
                                differencesRowIndex.Add(DATA_ENUM.ModuleType.ASSOC, 2);
                            }

                            foreach (string item in AuditData[stp][DATA_ENUM.ModuleType.ASSOC].Differences)
                            {
                                differencesData = new Dictionary<List<string>, List<string>>();
                                differencesData.Add(
                                    STPsInfo[DATA_ENUM.STP.RAT1].AssocData.Where(w => w.ASSOC_ID == item).Select(s => s.ASSOC_AuditFields).First(),
                                    STPsInfo[stp].AssocData.Where(w => w.ASSOC_ID == item).Select(s => s.ASSOC_AuditFields).First());

                                differencesRowIndex[DATA_ENUM.ModuleType.ASSOC] = Business.Excel.Audits.InsertDifferencesRecords(
                                    differencesWorkSheet[DATA_ENUM.ModuleType.ASSOC],
                                    stp,
                                    differencesData,
                                    differencesRowIndex[DATA_ENUM.ModuleType.ASSOC]);
                            }
                        }
                    }
                    #endregion

                    #region [ LOOPSET ]
                    if ((AuditType == DATA_ENUM.OST_Types.All && CheckCorrections(DATA_ENUM.ModuleType.LOOPSET)) || AuditType == DATA_ENUM.OST_Types.LOOPSET)
                    {
                        Action_backgroundWorker.ReportProgress(0, string.Format(excelBuildMessage, stp.ToString(), "LOOPSET"));

                        notInRat1Values = STPsInfo[stp].LoopsetData.Select(s => s.LOOPSET_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.LOOPSET].NotInRAT1).ToList();
                        notInRat1Values = STPsInfo[stp].LoopsetData.Where(w => notInRat1Values.Contains(w.LOOPSET_ID)).Select(s => s.LOOPSET_AuditDetail).ToList();
                        notInRAT1RowIndex = Business.Excel.Audits.InsertNotInRecords(notInRAT1workSheet, stp, DATA_ENUM.ModuleType.LOOPSET, notInRat1Values.Select(s => s.Replace("|", ";")).ToList(), notInRAT1RowIndex);

                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].LoopsetData.Select(s => s.LOOPSET_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.LOOPSET].NotInSTP).ToList();
                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].LoopsetData.Where(w => notInStpValues.Contains(w.LOOPSET_ID)).Select(s => s.LOOPSET_AuditDetail).ToList();
                        notInStpRowIndex = Business.Excel.Audits.InsertNotInRecords(notInStpworkSheet, stp, DATA_ENUM.ModuleType.LOOPSET, notInStpValues.Select(s => s.Replace("|", ";")).ToList(), notInStpRowIndex);

                        //Differences
                        if (AuditData[stp][DATA_ENUM.ModuleType.LOOPSET].Differences.Count() > 0)
                        {
                            if (differencesWorkSheet == null)
                            {
                                differencesWorkSheet = new Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet>();
                                differencesRowIndex = new Dictionary<DATA_ENUM.ModuleType, int>();
                            }

                            if (!differencesWorkSheet.ContainsKey(DATA_ENUM.ModuleType.LOOPSET))
                            {
                                differencesWorkSheet.Add(DATA_ENUM.ModuleType.LOOPSET, Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.Differences, DATA_ENUM.ModuleType.LOOPSET));
                                differencesRowIndex.Add(DATA_ENUM.ModuleType.LOOPSET, 2);
                            }

                            foreach (string item in AuditData[stp][DATA_ENUM.ModuleType.LOOPSET].Differences)
                            {
                                differencesData = new Dictionary<List<string>, List<string>>();
                                differencesData.Add(
                                    STPsInfo[DATA_ENUM.STP.RAT1].LoopsetData.Where(w => w.LOOPSET_ID == item).Select(s => s.LOOPSET_AuditFields).First(),
                                    STPsInfo[stp].LoopsetData.Where(w => w.LOOPSET_ID == item).Select(s => s.LOOPSET_AuditFields).First());

                                differencesRowIndex[DATA_ENUM.ModuleType.LOOPSET] = Business.Excel.Audits.InsertDifferencesRecords(
                                    differencesWorkSheet[DATA_ENUM.ModuleType.LOOPSET],
                                    stp,
                                    differencesData,
                                    differencesRowIndex[DATA_ENUM.ModuleType.LOOPSET]);
                            }
                        }
                    }
                    #endregion

                    #region [ TTMAP ]
                    if ((AuditType == DATA_ENUM.OST_Types.All && CheckCorrections(DATA_ENUM.ModuleType.TTMAP)) || AuditType == DATA_ENUM.OST_Types.TTMAP)
                    {
                        Action_backgroundWorker.ReportProgress(0, string.Format(excelBuildMessage, stp.ToString(), "TTMAP"));

                        notInRat1Values = STPsInfo[stp].TTMapData.Select(s => s.TTMAP_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.TTMAP].NotInRAT1).ToList();
                        notInRat1Values = STPsInfo[stp].TTMapData.Where(w => notInRat1Values.Contains(w.TTMAP_ID)).Select(s => s.TTMAP_AuditDetail).ToList();
                        notInRAT1RowIndex = Business.Excel.Audits.InsertNotInRecords(notInRAT1workSheet, stp, DATA_ENUM.ModuleType.TTMAP, notInRat1Values.Select(s => s.Replace("|", ";")).ToList(), notInRAT1RowIndex);

                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].TTMapData.Select(s => s.TTMAP_ID).ToList().Intersect(AuditData[stp][DATA_ENUM.ModuleType.TTMAP].NotInSTP).ToList();
                        notInStpValues = STPsInfo[DATA_ENUM.STP.RAT1].TTMapData.Where(w => notInStpValues.Contains(w.TTMAP_ID)).Select(s => s.TTMAP_AuditDetail).ToList();
                        notInStpRowIndex = Business.Excel.Audits.InsertNotInRecords(notInStpworkSheet, stp, DATA_ENUM.ModuleType.TTMAP, notInStpValues.Select(s => s.Replace("|", ";")).ToList(), notInStpRowIndex);

                        //Differences
                        if (AuditData[stp][DATA_ENUM.ModuleType.TTMAP].Differences.Count() > 0)
                        {
                            if (differencesWorkSheet == null)
                            {
                                differencesWorkSheet = new Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet>();
                                differencesRowIndex = new Dictionary<DATA_ENUM.ModuleType, int>();
                            }

                            if (!differencesWorkSheet.ContainsKey(DATA_ENUM.ModuleType.TTMAP))
                            {
                                differencesWorkSheet.Add(DATA_ENUM.ModuleType.TTMAP, Business.Excel.Audits.BuilAuditdWorksheet(xlPackage, DATA_ENUM.Audit.ResultType.Differences, DATA_ENUM.ModuleType.TTMAP));
                                differencesRowIndex.Add(DATA_ENUM.ModuleType.TTMAP, 2);
                            }

                            foreach (string item in AuditData[stp][DATA_ENUM.ModuleType.TTMAP].Differences)
                            {
                                differencesData = new Dictionary<List<string>, List<string>>();
                                differencesData.Add(
                                    STPsInfo[DATA_ENUM.STP.RAT1].TTMapData.Where(w => w.TTMAP_ID == item).Select(s => s.TTMAP_AuditFields).First(),
                                    STPsInfo[stp].TTMapData.Where(w => w.TTMAP_ID == item).Select(s => s.TTMAP_AuditFields).First());

                                differencesRowIndex[DATA_ENUM.ModuleType.TTMAP] = Business.Excel.Audits.InsertDifferencesRecords(
                                    differencesWorkSheet[DATA_ENUM.ModuleType.TTMAP],
                                    stp,
                                    differencesData,
                                    differencesRowIndex[DATA_ENUM.ModuleType.TTMAP]);
                            }
                        }
                    }
                    #endregion
                }

                AutofitAndFreeze(notInRAT1workSheet);
                AutofitAndFreeze(notInStpworkSheet);
                AutofitAndFreeze(differencesWorkSheet);

                xlPackage.Save();
                xlPackage.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ Autofit and Freeze ]
        private void AutofitAndFreeze(OfficeOpenXml.ExcelWorksheet workSheet)
        {
            if (workSheet != null)
            {
                workSheet.Cells.Style.Font.Size = 9;
                workSheet.Cells.AutoFitColumns();
                workSheet.View.FreezePanes(2, 1);
            }
        }

        private void AutofitAndFreeze(Dictionary<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet> workSheets)
        {
            foreach (KeyValuePair<DATA_ENUM.ModuleType, OfficeOpenXml.ExcelWorksheet> item in workSheets)
            {
                if (item.Value != null)
                {
                    item.Value.Cells.Style.Font.Size = 9;
                    item.Value.Cells.AutoFitColumns();
                    item.Value.View.FreezePanes(2, 1);
                }
            }
        }
        #endregion

        private void SetLinklabelArea(List<LinkLabel> linkLabels, bool setArea)
        {
            foreach (LinkLabel item in linkLabels)
                item.LinkArea = new LinkArea(0, setArea ? item.Text.Length : 0);
        }

        #endregion

        #region [ ----------> Advanced Search <---------- ]

        private void advancedSearch_button_Click(object sender, EventArgs e)
        {
            SearchData(advancedSearchBox_textBox.Text);
        }

        private void searchHelp_button_Click(object sender, EventArgs e)
        {
            advancedSearchBox_textBox.Text = string.Empty;
            Windows.Romina.Help showHelp = new Windows.Romina.Help();
            showHelp.Show();
        }

        #region [ SearchData ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString"></param>
        private void SearchData(string searchString)
        {
            operatorDetails_panel.Visible = false;

            if (!string.IsNullOrEmpty(searchString))
            {
                query_label.Text = string.Format("Search query: {0}", searchString);

                bool unknownSearchPattern = false;
                bool msisdnStartsW = false;
                bool ngtStartsW = false;
                DATA_ENUM.Romina.SearchType searchType = DATA_ENUM.Romina.SearchType.Generic;

                List<string> lKeyWords = new List<string>() { "TSC", "MGT", "IMSI", "NAME", "NGT", "MSISDN", "T", "MG", "I", "NA", "NG", "MS" };

                string[] items = searchString.Split(' ');

                #region [ Input parameters analysis ]
                switch (items.Count())
                {
                    case 1:
                        searchType = items[0].Substring(0, 1) == "\"" && items[0].Substring((items[0].Length - 1), 1) == "\"" ?
                            searchType = DATA_ENUM.Romina.SearchType.Specific : searchType = DATA_ENUM.Romina.SearchType.Generic;
                        break;

                    case 2:
                        if (items[0] == "-S")
                        {
                            if (items[1].Substring(0, 1) == "\"" && items[1].Substring((items[1].Length - 1), 1) == "\"")
                                unknownSearchPattern = true;
                            else
                                searchType = DATA_ENUM.Romina.SearchType.Starting;
                        }
                        else if (lKeyWords.Exists(x => x.ToString() == items[0]))
                        {
                            if (items[1].Substring(0, 1) == "\"" && items[1].Substring((items[1].Length - 1), 1) == "\"")
                                searchType = DATA_ENUM.Romina.SearchType.ByField_Specific;
                            else
                                searchType = DATA_ENUM.Romina.SearchType.ByField_Generic;
                        }
                        else
                            unknownSearchPattern = true;
                        break;

                    case 3:
                        if (lKeyWords.Exists(x => x.ToString() == items[0]))
                        {
                            if (items[1] == "-S")
                            {
                                if (items[2].Substring(0, 1) == "\"" && items[2].Substring((items[2].Length - 1), 1) == "\"")
                                    unknownSearchPattern = true;
                                else
                                    searchType = DATA_ENUM.Romina.SearchType.ByField_Starting;
                            }
                            else
                                unknownSearchPattern = true;
                        }
                        else
                            unknownSearchPattern = true;
                        break;
                }
                #endregion

                if (!unknownSearchPattern)
                {
                    Func<Data.Romina.RominaAgent, bool> predicate = null;

                    switch (searchType)
                    {
                        #region [ Specific ]
                        case DATA_ENUM.Romina.SearchType.Specific:
                            predicate = w => w.SpecificSearch(items[0].Substring(1, (items[0].Length - 2)));
                            break;
                        #endregion

                        #region [ Generic ]
                        case DATA_ENUM.Romina.SearchType.Generic:
                            predicate = w => w.StringChain().Contains(items[0].ToUpper());
                            break;
                        #endregion

                        #region [ Starting ]
                        case DATA_ENUM.Romina.SearchType.Starting:
                            predicate = w => w.StartsWithSearch(items[1].ToUpper());
                            break;
                        #endregion

                        #region [ ByField ]
                        case DATA_ENUM.Romina.SearchType.ByField_Generic:
                        case DATA_ENUM.Romina.SearchType.ByField_Specific:
                        case DATA_ENUM.Romina.SearchType.ByField_Starting:
                            switch (items[0])
                            {
                                case "TSC":
                                case "T":
                                    if (searchType == DATA_ENUM.Romina.SearchType.ByField_Generic)
                                        predicate = w => w.TSC.Contains(items[1]);
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Specific)
                                        predicate = w => w.TSC == items[1].Substring(1, (items[1].Length - 2));
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Starting)
                                        predicate = w => w.TSC.StartsWith(items[2]);
                                    break;                                    

                                case "MGT":
                                case "MG":
                                    if (searchType == DATA_ENUM.Romina.SearchType.ByField_Generic)
                                        predicate = w => w.MGT.Contains(items[1]);
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Specific)
                                        predicate = w => w.MGT == items[1].Substring(1, (items[1].Length - 2));
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Starting)
                                        predicate = w => w.MGT.StartsWith(items[2]);
                                    break;

                                case "IMSI":
                                case "I":
                                    if (searchType == DATA_ENUM.Romina.SearchType.ByField_Generic)
                                        predicate = w => w.IMSI.Contains(items[1]);
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Specific)
                                        predicate = w => w.IMSI == items[1].Substring(1, (items[1].Length - 2));
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Starting)
                                        predicate = w => w.IMSI.StartsWith(items[2]);
                                    break;

                                case "NAME":
                                case "NA":
                                    if (searchType == DATA_ENUM.Romina.SearchType.ByField_Generic)
                                        predicate = w => w.Name.Contains(items[1]);
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Specific)
                                        predicate = w => w.Name == items[1].Substring(1, (items[1].Length - 2));
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Starting)
                                        predicate = w => w.Name.StartsWith(items[2]);
                                    break;

                                case "NGT":
                                case "NG":
                                    if (searchType == DATA_ENUM.Romina.SearchType.ByField_Generic)
                                        predicate = w => w.NGT.Contains(items[1]);
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Specific)
                                        predicate = w => w.NGT.Contains(items[1].Substring(1, (items[1].Length - 2)));
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Starting)
                                        ngtStartsW = true;
                                    break;

                                case "MSISDN":
                                case "MS":
                                    if (searchType == DATA_ENUM.Romina.SearchType.ByField_Generic)
                                        predicate = w => w.MSISDNs.Contains(items[1]);
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Specific)
                                        predicate = w => w.MSISDNs.Contains(items[1].Substring(1, (items[1].Length - 2)));
                                    else if (searchType == DATA_ENUM.Romina.SearchType.ByField_Starting)
                                        msisdnStartsW = true;
                                    break;
                            }
                            break;
                            #endregion
                    }

                    if (msisdnStartsW || ngtStartsW)
                    {
                        var search = msisdnStartsW ? RominaData.Where(w => MLVSoft_Common.Utilities.General.ListStartsWithString(w.MSISDNs, items[2])) :
                            RominaData.Where(w => MLVSoft_Common.Utilities.General.ListStartsWithString(w.NGT, items[2]));

                        if (search.Count() > 0)
                            FillSearchDataGridView(search);
                        else
                        {
                            advancedSearchResult_dataGridView.DataSource = null;
                            elementsFound_label.Text = "No elements found";
                            elementsFound_label.Text = "Number of elements found: 0";
                            operatorDetails_panel.Visible = false;
                        }
                    }
                    else
                    {
                        var search = RominaData.Where(predicate);

                        if (search.Count() > 0)
                            FillSearchDataGridView(search);
                        else
                        {
                            advancedSearchResult_dataGridView.DataSource = null;
                            elementsFound_label.Text = "No elements found";
                            elementsFound_label.Text = "Number of elements found: 0";
                            operatorDetails_panel.Visible = false;
                        }
                    }

                    advancedSearchData_panel.Visible = true;
                }
                else
                {
                    ShowMessage(unkownSearch_label, "Unkown search pattern", true, 459, 22, 194, 23);
                    advancedSearchResult_dataGridView.DataSource = null;
                    elementsFound_label.Text = "No elements found";
                    elementsFound_label.Text = "Number of elements found: 0";
                    operatorDetails_panel.Visible = false;
                }
            }
            else
                advancedSearchData_panel.Visible = false;

            advancedSearchBox_textBox.Text = string.Empty;
            advancedSearchBox_textBox.Focus();
        }
        #endregion

        #region [ Fill Search Data GridView ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchResult"></param>
        private void FillSearchDataGridView(IEnumerable<Data.Romina.RominaAgent> searchResult)
        {
            try
            {
                var gridColumns = from t in searchResult
                                  orderby t.TSC
                                  select new
                                  {
                                      Type = t.Type,
                                      TSC = t.TSC,
                                      Country = t.Country,
                                      Name = t.Name,
                                      IMSI = t.IMSI,
                                      MGT = t.MGT
                                  };

                advancedSearchResult_dataGridView.DataSource = gridColumns.ToList();
                advancedSearchResult_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                elementsFound_label.Text = string.Format("Number of elements found: {0}", searchResult.Count().ToString());
                unkownSearch_label.Visible = false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ Search_textBox_KeyDown ]
        void Search_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool search = true;

                string searchData = advancedSearchBox_textBox.Text.Trim();

                if (string.IsNullOrEmpty(searchData))
                    search = false;
                else if (searchData.Contains(" ") && searchData.Split(' ').Length < 2)
                    search = false;

                if (search)
                    SearchData(advancedSearchBox_textBox.Text);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        #endregion        

        #region [ Search DataGridView DataBindingComplete ]
        private void advancedSearchResult_dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            base.SetGridStyle(advancedSearchResult_dataGridView);
            advancedSearchResult_dataGridView.ClearSelection();
        }
        #endregion

        #region [ Load Operator Details in Grid selection ]
        private void advancedSearchResult_dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool mgtExists = false;
            Data.OST.GTA_Data gtaSelectedItem = null;

            operatorDetails_panel.Visible = true;
            operatorOST_groupBox.Visible = false;
            operatorClli_linkLabel.Text = string.Empty;
            asMgtUpperrange_pictureBox.BackgroundImage = Properties.Resources.Unchecked_small;
            operatorDpcs_listBox.Items.Clear();

            Data.Romina.RominaAgent rominaAgent = RominaData.Where(w => w.TSC == advancedSearchResult_dataGridView.CurrentRow.Cells[1].Value.ToString()).First();

            operatorType_linkLabel.Text = rominaAgent.Type.ToString();
            operatorTSC_linkLabel.Text = rominaAgent.TSC;
            operatorCountry_linkLabel.Text = rominaAgent.Country;
            operatorName_linkLabel.Text = rominaAgent.Name;
            operatorImsi_linkLabel.Text = rominaAgent.IMSI;
            operatorMGT_linkLabel.Text = rominaAgent.MGT;

            operatorNGT_listBox.Enabled = rominaAgent.NGT.Count > 0;
            operatorNGT_listBox.Enabled = rominaAgent.MSISDNs.Count > 0;

            operatorNGT_listBox.Items.Clear();
            if (rominaAgent.NGT.Count > 0)
                operatorNGT_listBox.Items.AddRange(rominaAgent.NGT.ToArray());

            operatorMSISDN_listBox.Items.Clear();
            if (rominaAgent.MSISDNs.Count > 0)
                operatorMSISDN_listBox.Items.AddRange(rominaAgent.MSISDNs.ToArray());
            
            // STP Info <----------------------------------
            if (STPsInfo != null && STPsInfo.Keys.Count > 0)
            {
                asSubranges_panel.Visible = false;
                var gtaData = STPsInfo.First().Value.GTA_Data;

                if(gtaData != null && gtaData.Count > 0)
                {
                    var gtaInfo = gtaData.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == rominaAgent.MGT);
                    mgtExists = gtaInfo != null && gtaInfo.Count() > 0;

                    if(mgtExists)
                        gtaSelectedItem = gtaInfo.FirstOrDefault();
                    else
                    {
                        //List<string> np7Gtas = gtaData.Where(w => w.Table == "cdrohubr7").Select(s => s.Start_GTA).ToList();
                        ////Subranges------------
                        //asSubranges_panel.Visible = np7Gtas.Any(f => f.StartsWith(rominaAgent.MGT));

                        //if (!asSubranges_panel.Visible && np7Gtas.Any(f => rominaAgent.MGT.StartsWith(f)))
                        //{
                        //    //Buscamos rangos superiores que contengan el MGT
                        //    for (int i = rominaAgent.MGT.Length - 1; i > 0; i--)
                        //    {
                        //        if (gtaData.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == rominaAgent.MGT.Substring(0, i)).Count() > 0)
                        //        {
                        //            mgtExists = true;
                        //            gtaSelectedItem = gtaData.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == rominaAgent.MGT.Substring(0, i)).First();
                        //            break;
                        //        }
                        //    }
                        //    asMgtUpperrange_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                        //}


                        List<string> np7Gtas = gtaData.Where(w => w.Table == "cdrohubr7").Select(s => s.Start_GTA).ToList();

                        if (np7Gtas.Any(f => rominaAgent.MGT.StartsWith(f)))
                        {
                            //Buscamos rangos superiores que contengan el MGT
                            for (int i = rominaAgent.MGT.Length - 1; i > 0; i--)
                            {
                                if (gtaData.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == rominaAgent.MGT.Substring(0, i)).Count() > 0)
                                {
                                    mgtExists = true;
                                    gtaSelectedItem = gtaData.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == rominaAgent.MGT.Substring(0, i)).First();
                                    asMgtUpperrange_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                                    break;
                                }
                            }
                        }
                        else 
                            asSubranges_panel.Visible = np7Gtas.Any(f => f.StartsWith(rominaAgent.MGT));


                    }

                    if(mgtExists)
                    {
                        operatorMrnset_linkLabel.Text = gtaSelectedItem.MRNSET;
                        operatorItupc_linkLabel.Text = gtaSelectedItem.ITU_PC;
                        operatorLoopset_linkLabel.Text = gtaSelectedItem.LOOPSET;

                        var mrnsetData = STPsInfo.First().Value.MrnsetData;
                        var dstnData = STPsInfo.First().Value.DstnData;

                        if ((mrnsetData != null && mrnsetData.Count > 0) && (dstnData != null && dstnData.Count() > 0))
                        {
                            var mrnsetInfo = mrnsetData.Where(w => w.MRNSET == gtaSelectedItem.MRNSET);

                            operatorDpcs_listBox.Enabled = mrnsetInfo.Count() > 0;
                            operatorClli_linkLabel.Enabled = mrnsetInfo.Count() > 0;

                            operatorOST_groupBox.Visible = true;

                            if (mrnsetInfo != null && mrnsetInfo.Count() > 0)
                            {
                                operatorDpcs_listBox.Items.Clear();
                                operatorDpcs_listBox.Items.AddRange(mrnsetInfo.Select(s => s.PC).ToArray());
                            }
                        }
                    }
                    else
                    {
                        operatorMrnset_linkLabel.Text = string.Empty;
                        operatorItupc_linkLabel.Text = string.Empty;
                        operatorLoopset_linkLabel.Text = string.Empty;
                    }
                }
            }
        }
        #endregion

        #region [ Advance Search Operator DPCs Selection ]
        private void operatorDpcs_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (operatorDpcs_listBox.Items.Count > 0 && !string.IsNullOrEmpty(operatorDpcs_listBox.Text))
            {
                if (STPsInfo.First().Value.DstnData != null)
                {
                    //Si tenemos cargados los datos de DSTN cogemos el valor directamente de ahí
                    operatorClli_linkLabel.Text = STPsInfo.First().Value.DstnData.Where(w => w.DPC == operatorDpcs_listBox.Text).First().CLLI;
                }
                else
                {
                    //En caso contrario buscamos el valor en la parte de MRNSET en caso de estar cargada
                    Data.OST.GTA_Data gtaSelectedItem = null;

                    var gtaInfo = STPsInfo.First().Value.GTA_Data.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == operatorMGT_linkLabel.Text);
                    if (gtaInfo != null && gtaInfo.Count() > 0)
                        gtaSelectedItem = STPsInfo.First().Value.GTA_Data.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == operatorMGT_linkLabel.Text).First();
                    else
                    {
                        for (int i = operatorMGT_linkLabel.Text.Length - 1; i > 0; i--)
                        {
                            if (STPsInfo.First().Value.GTA_Data.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == operatorMGT_linkLabel.Text.Substring(0, i)).Count() > 0)
                            {
                                gtaSelectedItem = STPsInfo.First().Value.GTA_Data.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == operatorMGT_linkLabel.Text.Substring(0, i)).First();
                                break;
                            }
                        }
                    }

                    if (gtaSelectedItem != null)
                    {
                        string mrnset = gtaSelectedItem.MRNSET;
                        operatorClli_linkLabel.Text = STPsInfo.First().Value.MrnsetData.Where(w => w.MRNSET == mrnset && w.PC == operatorDpcs_listBox.Text).First().CLLI;
                    }
                }
            }
        }
        #endregion

        #region [ Link Labels clicked ]

        
        #endregion

        public void CopyValuesClipboard(ListBox listbox)
        {
            if (listbox.Items.Count > 0)
            {
                Business.Utilities.CopyListboxElementsToClipboard(listbox.Items);
                MessageBox.Show("Elements copied to clipboard", "Operation completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region [ ----------------> Operator <---------------- ]

        private void operatorSource_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            operatorSearch_button.Enabled = operatorSource_comboBox.SelectedIndex != -1 && !string.IsNullOrEmpty(operatorSource_comboBox.Text);
        }

        #region [ Search Button ]
        private void operatorSearch_button_Click(object sender, EventArgs e)
        {
            operatorInfo_panel.Visible = false;
            operatorDetailsSTP_groupBox.Visible = false;
            operatorDetailsAgreements_groupBox.Visible = false;
            operatorDocuments_groupBox.Visible = false;
            opDetailsStpDpcClli_linkLabel.Text = string.Empty;

            if (string.IsNullOrEmpty(operatorTscSearch_textBox.Text) && string.IsNullOrEmpty(operatorMgtSearch_textBox.Text) && string.IsNullOrEmpty(operatorImsiSearch_textBox.Text))
            {
                ShowMessage(operatorErrorMessage_label, "TSC, MGT or IMSI has to be filled", true, showOpErrorMessageLeft, showOpErrorMessageTop, 200, 23);
            }
            else
            {
                OperationType = DATA_ENUM.OperationType.SearchOperator;
                PerformAction();
            }
        }
        #endregion

        #region [ Search Operator ]
        public void SearchOperator(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                operatorSearch_button.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        
        private void SearchOperator()
        {
            bool mgtExists = false;
            Data.OST.GTA_Data gtaSelectedItem = null;
            ActionResult = new Data.ResultItem() { Result = true };

            try
            {
                Action_backgroundWorker.ReportProgress(0, "Searching Romina Data");

                var predicate = PredicateBuilder.New<Data.Romina.RominaAgent>();
                
                if(!string.IsNullOrEmpty(operatorTscSearch_textBox.Text))
                    predicate = predicate.And(w => w.TSC == operatorTscSearch_textBox.Text);

                if (!string.IsNullOrEmpty(operatorMgtSearch_textBox.Text))
                    predicate = predicate.And(w => w.MGT == operatorMgtSearch_textBox.Text);

                if (!string.IsNullOrEmpty(operatorImsiSearch_textBox.Text))
                    predicate = predicate.And(w => w.IMSI == operatorImsiSearch_textBox.Text);

                var search = RominaData.Where(predicate);

                if (search.Count() > 0)
                {
                    Data.Romina.RominaAgent rominaSearch = search.First();

                    OperatorData = new Data.OperatorData()
                    {
                        TSC = rominaSearch.TSC,
                        MGT = rominaSearch.MGT,
                        Name = rominaSearch.Name,
                        Country = rominaSearch.Country,
                        IMSI = rominaSearch.IMSI,
                        Type = rominaSearch.Type,
                        NGT = rominaSearch.NGT,
                        MSISDNs = rominaSearch.MSISDNs,
                        UpperSubRange = DATA_ENUM.RangeType.None
                    };

                    //-------------------------------------------------------------------------
                    Action_backgroundWorker.ReportProgress(0, "Searching OST data");
                    if (STPsInfo != null && STPsInfo.Keys.Count > 0)
                    {
                        var gtaData = STPsInfo.First().Value.GTA_Data;

                        if (gtaData != null && gtaData.Count > 0)
                        {
                            var gtaInfo = gtaData.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == OperatorData.MGT);
                            mgtExists = gtaInfo != null && gtaInfo.Count() > 0;

                            if (mgtExists)
                                gtaSelectedItem = gtaInfo.FirstOrDefault();
                            else
                            {
                                List<string> np7Gtas = gtaData.Where(w => w.Table == "cdrohubr7").Select(s => s.Start_GTA).ToList();
                                
                                if (np7Gtas.Any(f => OperatorData.MGT.StartsWith(f)))
                                {
                                    //Buscamos rangos superiores que contengan el MGT
                                    for (int i = OperatorData.MGT.Length - 1; i > 0; i--)
                                    {
                                        if (gtaData.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == OperatorData.MGT.Substring(0, i)).Count() > 0)
                                        {
                                            mgtExists = true;
                                            gtaSelectedItem = gtaData.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == OperatorData.MGT.Substring(0, i)).First();
                                            OperatorData.UpperSubRange = DATA_ENUM.RangeType.Upper_range;
                                            break;
                                        }
                                    }
                                }
                                else if (np7Gtas.Any(f => f.StartsWith(OperatorData.MGT)))
                                    OperatorData.UpperSubRange = DATA_ENUM.RangeType.Sub_range;
                            }

                            if (mgtExists)
                            {
                                OperatorData.MRNSET = gtaSelectedItem.MRNSET;
                                OperatorData.ITU_PC = gtaSelectedItem.ITU_PC;
                                OperatorData.LOOPSET = gtaSelectedItem.LOOPSET;
                                OperatorData.OPTSN = gtaSelectedItem.OPTSN;

                                var mrnsetData = STPsInfo.First().Value.MrnsetData;
                                var dstnData = STPsInfo.First().Value.DstnData;

                                if ((mrnsetData != null && mrnsetData.Count > 0) && (dstnData != null && dstnData.Count() > 0))
                                {
                                    var mrnsetInfo = mrnsetData.Where(w => w.MRNSET == gtaSelectedItem.MRNSET);

                                    if (mrnsetInfo != null && mrnsetInfo.Count() > 0)
                                    {
                                        OperatorData.MRNSET_DPCs = new Dictionary<string, string>();
                                        foreach (string item in mrnsetInfo.Select(s => s.PC))
                                        {
                                            if (STPsInfo.First().Value.DstnData != null) ////Si tenemos cargados los datos de DSTN cogemos el valor directamente de ahí
                                                OperatorData.MRNSET_DPCs.Add(item, STPsInfo.First().Value.DstnData.Where(w => w.DPC == item).First().CLLI);
                                            else //En caso contrario buscamos el valor en la parte de MRNSET en caso de estar cargada
                                                OperatorData.ITU_PC_CLLI = STPsInfo.First().Value.MrnsetData.Where(w => w.MRNSET == item && w.PC == OperatorData.ITU_PC).First().CLLI;
                                        }
                                    }
                                }
                            }

                            Action_backgroundWorker.ReportProgress(0, "Searching Agreements");
                            //NP7 Agreements
                            var homeTable = STPsInfo.First().Value.GTA_Data.Where(w => w.Table.ToUpper() == string.Format("CG{0}N7", OperatorData.TSC) && w.ACTSN != "actdisc");
                            if(homeTable.Count() > 0)
                            {
                                List<string> cgMgts = homeTable.Select(s => s.Start_GTA).ToList();
                                OperatorData.HomeAgreements = new List<string>();
                                OperatorData.HomeAgreements.AddRange(RominaData.Where(w => !string.IsNullOrEmpty(w.TSC) && (cgMgts.Any(f => f.StartsWith(w.MGT)) || cgMgts.Any(f => w.MGT.StartsWith(f)))).Select(s => s.TSC.ToUpper()).Distinct().ToArray());
                            }

                            var cgTables = STPsInfo.First().Value.GTA_Data.Where(w => w.Table.ToUpper().StartsWith("CG") && w.Table.Length == 9 && w.Table.ToUpper().Substring(7, 2) == "N7" && w.ACTSN != "actdisc");
                            var visitedTable = cgTables.Where(w => w.Start_GTA == OperatorData.MGT || OperatorData.MGT.StartsWith(w.Start_GTA) || w.Start_GTA.StartsWith(OperatorData.MGT));
                            if (visitedTable.Count() > 0)
                            {
                                List<string> cgOps = visitedTable.Select(s => s.Table.Substring(2, 5).ToUpper()).ToList();
                                OperatorData.VisitedAgreements = new List<string>();
                                OperatorData.VisitedAgreements.AddRange(cgOps.Distinct());
                            }
                        }
                    }
                }
                else
                {
                    ActionResult.Result = false;
                    ActionResult.Message = "No operator found with search criteria";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ Show Operator Result ]
        private void ShowOperatorResult()
        {
            try
            {
                if (ActionResult.Result)
                {
                    operatorDetailsTsc_linkLabel.Text = OperatorData.TSC;
                    operatorDetailsImsi_linkLabel.Text = OperatorData.IMSI;
                    operatorDetailsMgt_linkLabel.Text = OperatorData.MGT;
                    operatorDetailsName_linkLabel.Text = OperatorData.Name;
                    operatorDetailsCountry_linkLabel.Text = OperatorData.Country;
                    operatorDetailsType_linkLabel.Text = OperatorData.Type.ToString();

                    operatorDetailsNgt_listBox.Items.Clear();
                    if (OperatorData.NGT != null && OperatorData.NGT.Count > 0)
                    {
                        operatorDetailsNgt_listBox.Items.AddRange(OperatorData.NGT.ToArray());
                        operatorDetailsNgt_listBox.Enabled = true;
                    }
                    else
                        operatorDetailsNgt_listBox.Enabled = false;

                    operatorDetailsMsisdn_listBox.Items.Clear();
                    if (OperatorData.MSISDNs != null && OperatorData.MSISDNs.Count > 0)
                    {
                        operatorDetailsMsisdn_listBox.Items.AddRange(OperatorData.MSISDNs.ToArray());
                        operatorDetailsMsisdn_listBox.Enabled = true;
                    }
                    else
                        operatorDetailsMsisdn_listBox.Enabled = false;

                    opSubranges_panel.Visible = OperatorData.UpperSubRange == DATA_ENUM.RangeType.Sub_range;

                    if (!string.IsNullOrEmpty(OperatorData.MRNSET))
                    {
                        operatorDetailsSTP_groupBox.Visible = true;

                        opDetailsStpMrnset_linkLabel.Text = OperatorData.MRNSET;
                        opDetailsStpPc_linkLabel.Text = OperatorData.ITU_PC;
                        opDetailsStpLoopset_linkLabel.Text = OperatorData.LOOPSET;
                        opDetailsStpOptsn_linkLabel.Text = OperatorData.OPTSN;

                        opUpperRange_panel.Visible = OperatorData.UpperSubRange != DATA_ENUM.RangeType.None;
                        opDetailsStpUpperSubRange_label.Text = OperatorData.UpperSubRange.ToString().Replace("_", " ");

                        if (OperatorData.MRNSET_DPCs != null && OperatorData.MRNSET_DPCs.Keys.Count > 0)
                        {
                            opDetailsStpDpcs_listBox.Items.Clear();
                            opDetailsStpDpcs_listBox.Items.AddRange(OperatorData.MRNSET_DPCs.Keys.ToArray());
                        }
                        else
                            operatorClli_linkLabel.Text = OperatorData.ITU_PC_CLLI;

                        if((OperatorData.HomeAgreements != null && OperatorData.HomeAgreements.Count > 0) || (OperatorData.VisitedAgreements != null && OperatorData.VisitedAgreements.Count > 0))
                        {
                            operatorDetailsAgreements_groupBox.Visible = true;
                            operatorHome_listBox.Items.Clear();
                            operatorVisited_listBox.Items.Clear();

                            if (OperatorData.HomeAgreements != null && OperatorData.HomeAgreements.Count > 0)
                            {
                                OperatorData.HomeAgreements.Sort();
                                operatorHome_listBox.Items.AddRange(OperatorData.HomeAgreements.ToArray());
                                opHomeElements_label.Text = string.Format("{0} {1}", OperatorData.HomeAgreements.Count.ToString(), OperatorData.HomeAgreements.Count > 1 ? "agreements" : "agreement");
                            }

                            if (OperatorData.VisitedAgreements != null && OperatorData.VisitedAgreements.Count > 0)
                            {
                                OperatorData.VisitedAgreements.Sort();
                                operatorVisited_listBox.Items.AddRange(OperatorData.VisitedAgreements.ToArray());
                                opVisitedElements_label.Text = string.Format("{0} {1}", OperatorData.VisitedAgreements.Count.ToString(), OperatorData.VisitedAgreements.Count > 1 ? "agreements" : "agreement");
                            }
                        }

                        operatorDocuments_groupBox.Visible = true;
                    }

                    operatorTscSearch_textBox.Text = string.Empty;
                    operatorMgtSearch_textBox.Text = string.Empty;
                    operatorImsiSearch_textBox.Text = string.Empty;
                    operatorInfo_panel.Visible = true;
                }
                else
                    ShowMessage(operatorErrorMessage_label, ActionResult.Message, true, showOpErrorMessageLeft, showOpErrorMessageTop, 200, 23);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ Operator DPCs Selection ]
        private void opDetailsStpDpcs_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (opDetailsStpDpcs_listBox.Items.Count > 0 && !string.IsNullOrEmpty(opDetailsStpDpcs_listBox.Text))
            {
                if (STPsInfo.First().Value.DstnData != null)
                {
                    //Si tenemos cargados los datos de DSTN cogemos el valor directamente de ahí
                    opDetailsStpDpcClli_linkLabel.Text = STPsInfo.First().Value.DstnData.Where(w => w.DPC == opDetailsStpDpcs_listBox.Text).First().CLLI;
                }
                else
                {
                    //En caso contrario buscamos el valor en la parte de MRNSET en caso de estar cargada
                    Data.OST.GTA_Data gtaSelectedItem = null;

                    var gtaInfo = STPsInfo.First().Value.GTA_Data.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == operatorMGT_linkLabel.Text);
                    if (gtaInfo != null && gtaInfo.Count() > 0)
                        gtaSelectedItem = STPsInfo.First().Value.GTA_Data.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == operatorMGT_linkLabel.Text).First();
                    else
                    {
                        for (int i = operatorMGT_linkLabel.Text.Length - 1; i > 0; i--)
                        {
                            if (STPsInfo.First().Value.GTA_Data.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == operatorDetailsMgt_linkLabel.Text.Substring(0, i)).Count() > 0)
                            {
                                gtaSelectedItem = STPsInfo.First().Value.GTA_Data.Where(w => w.Table == "cdrohubr7" && w.Start_GTA == operatorDetailsMgt_linkLabel.Text.Substring(0, i)).First();
                                break;
                            }
                        }
                    }

                    if (gtaSelectedItem != null)
                    {
                        string mrnset = gtaSelectedItem.MRNSET;
                        operatorClli_linkLabel.Text = STPsInfo.First().Value.MrnsetData.Where(w => w.MRNSET == mrnset && w.PC == opDetailsStpDpcs_listBox.Text).First().CLLI;
                    }
                }
            }
        }
        #endregion

        #region [ Documents ]
        private void opPdf_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void opXml_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void opXml_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void opIr21_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        #endregion

        #region [ Links Clicked ]
        private void OperatorDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(((LinkLabel)sender).Text);
        }

        private void operatorHeaderNGT_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyClipboardListBoxElements(operatorNGT_listBox);
        }

        private void operatorHeaderMSISDN_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyClipboardListBoxElements(operatorMSISDN_listBox);
        }

        private void operatorHeaderDpc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyClipboardListBoxElements(operatorDpcs_listBox);
        }

        private void operatorVisitedList_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyClipboardListBoxElements(operatorVisited_listBox);
        }

        private void operatorHomeList_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyClipboardListBoxElements(operatorHome_listBox);
        }

        private void operatorNp1Routing_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyClipboardListBoxElements(opDetailsStpNp1Routing_listBox);
        }

        private void operatorDPCsList_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyClipboardListBoxElements(opDetailsStpDpcs_listBox);
        }

        private void operatorMsisdnList_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyClipboardListBoxElements(operatorDetailsMsisdn_listBox);
        }

        private void operatorNGtList_linkLabell_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyClipboardListBoxElements(operatorDetailsNgt_listBox);
        }
        #endregion

        #endregion

        #region [ --------------> Agreements <-------------- ]

        #region [ Agreements Search Button ]
        private void agreementsSearch_button_Click(object sender, EventArgs e)
        {
            agreementsDetails_panel.Visible = false;
            agreementsRightArrow_pictureBox.Visible = false;

            bool search = false;
            TextBox txtBoxFocus = null;
            string errorMessage = null;

            //---------------- >Validation <----------------
            if (string.IsNullOrEmpty(agreementsTsc1_textBox.Text))
            {
                txtBoxFocus = agreementsTsc1_textBox;
                errorMessage = "TSC1 value is mandatory";
            }
            else if (string.IsNullOrEmpty(agreementsTsc2_textBox.Text))
            {
                txtBoxFocus = agreementsTsc2_textBox;
                errorMessage = "TSC2 value is mandatory";
            }
            else if (agreementsTsc1_textBox.Text == agreementsTsc2_textBox.Text)
            {
                txtBoxFocus = agreementsTsc1_textBox;
                errorMessage = "Values cannot be the same";
            }
            else
                search = true;
            

            if(search)
            {
                DATA_ENUM.RangeType tsc1Range = DATA_ENUM.RangeType.None;
                DATA_ENUM.RangeType tsc2Range = DATA_ENUM.RangeType.None;
                bool tsc1tsc2Agreement = false;
                bool tsc2tsc1Agreement = false;
                string tsc1Mgt = null;
                string tsc2Mgt = null;

                try
                {
                    ActionResult = new Data.ResultItem() { Result = true };

                    var tsc1Data = RominaData.Where(w => w.TSC == agreementsTsc1_textBox.Text);
                    var tsc2Data = RominaData.Where(w => w.TSC == agreementsTsc2_textBox.Text);

                    if (tsc1Data.Count() == 0)
                    {
                        ActionResult.Result = false;
                        ActionResult.Message = "TSC1 not found in Romina";
                        txtBoxFocus = agreementsTsc1_textBox;
                    }
                    else if (tsc2Data.Count() == 0)
                    {
                        ActionResult.Result = false;
                        ActionResult.Message = "TSC2 not found in Romina";
                        txtBoxFocus = agreementsTsc2_textBox;
                    }

                    if (ActionResult.Result)
                    {
                        tsc2Mgt = tsc2Data.First().MGT;

                        var cgTableTsc1 = STPsInfo.First().Value.GTA_Data.Where(w => w.Table.ToUpper() == string.Format("CG{0}N7", agreementsTsc1_textBox.Text) && w.ACTSN != "actdisc");
                        if (cgTableTsc1.Count() > 0)
                        {
                            List<string> cgMgts = cgTableTsc1.Select(s => s.Start_GTA).ToList();

                            if (!cgMgts.Contains(tsc2Mgt))
                            {
                                if (cgMgts.Any(f => tsc2Mgt.StartsWith(f)))
                                    tsc1Range = DATA_ENUM.RangeType.Upper_range;
                                else if (cgMgts.Any(f => f.StartsWith(tsc2Mgt)))
                                    tsc1Range = DATA_ENUM.RangeType.Sub_range;
                            }
                            else
                                tsc1tsc2Agreement = true;
                        }

                        tsc1Mgt = tsc1Data.First().MGT;

                        var cgTableTsc2 = STPsInfo.First().Value.GTA_Data.Where(w => w.Table.ToUpper() == string.Format("CG{0}N7", agreementsTsc2_textBox.Text) && w.ACTSN != "actdisc");
                        if (cgTableTsc2.Count() > 0)
                        {
                            List<string> cgMgts = cgTableTsc2.Select(s => s.Start_GTA).ToList();

                            if (!cgMgts.Contains(tsc1Mgt))
                            {
                                if (cgMgts.Any(o => o.StartsWith(tsc1Mgt)))
                                    tsc2Range = DATA_ENUM.RangeType.Sub_range;
                                else if (cgMgts.Any(o => tsc1Mgt.StartsWith(o)))
                                    tsc2Range = DATA_ENUM.RangeType.Upper_range;
                            }
                            else
                                tsc2tsc1Agreement = true;
                        }

                        AgreementsResult = Tuple.Create(tsc1tsc2Agreement, tsc2tsc1Agreement, tsc1Range, tsc2Range);
                        ShowAgreementsResult();
                    }
                    else
                    {
                        ShowMessage(agreementsSearchMessage_label, ActionResult.Message, true, 56, 158, 194, 23);
                        txtBoxFocus.Focus();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                ShowMessage(agreementsSearchMessage_label, errorMessage, true, 56, 158, 194, 23);
                txtBoxFocus.Focus();
            }            
        }
        #endregion        

        #region [ Show Agreements Result ]
        private void ShowAgreementsResult()
        {
            tsc1RangeType_label.Visible = false;
            tsc2RangeType_label.Visible = false;
            tsc1RangeType_pictureBox.Visible = false;
            tsc2RangeType_pictureBox.Visible = false;

            if (ActionResult.Result)
            {
                tsc1Home_label.Text = agreementsTsc1_textBox.Text;
                tsc2Visited_label.Text = agreementsTsc2_textBox.Text;

                tsc2Home_label.Text = agreementsTsc2_textBox.Text;
                tsc1Visited_label.Text = agreementsTsc1_textBox.Text;

                if (AgreementsResult.Item1)
                    tsc1tsc2_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                else if(AgreementsResult.Item3 != DATA_ENUM.RangeType.None)
                {
                    tsc1tsc2_pictureBox.BackgroundImage = Properties.Resources.questionMark;
                    tsc1RangeType_label.Text = AgreementsResult.Item3.ToString().Replace("_", "");
                    tsc1RangeType_label.Visible = true;
                    tsc1RangeType_pictureBox.Visible = true;
                }
                else
                    tsc1tsc2_pictureBox.BackgroundImage = Properties.Resources.notOpened;

                if (AgreementsResult.Item2)
                    tsc2tsc1_pictureBox.BackgroundImage = Properties.Resources.Checked_small;
                else if (AgreementsResult.Item4 != DATA_ENUM.RangeType.None)
                {
                    tsc2tsc1_pictureBox.BackgroundImage = Properties.Resources.questionMark;
                    tsc2RangeType_label.Text = AgreementsResult.Item4.ToString().Replace("_", "");
                    tsc2RangeType_label.Visible = true;
                    tsc2RangeType_pictureBox.Visible = true;
                }
                else
                    tsc2tsc1_pictureBox.BackgroundImage = Properties.Resources.notOpened;

                agreementsDetails_panel.Visible = true;
                agreementsRightArrow_pictureBox.Visible = true;

                agreementsTsc1_textBox.Enabled = false;
                agreementsTsc2_textBox.Enabled = false;
                agreementsSearch_button.Enabled = false;
                agreementsNewSearch_linkLabel.Visible = true;
            }
            else
                ShowMessage(agreementsSearchMessage_label, ActionResult.Message, true, 56, 132, 194, 23);
        }
        #endregion

        #region [ New Search ]
        private void agreementsNewSearch_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            agreementsTsc1_textBox.Text = string.Empty;
            agreementsTsc2_textBox.Text = string.Empty;

            agreementsTsc1_textBox.Enabled = true;
            agreementsTsc2_textBox.Enabled = true;
            agreementsSearch_button.Enabled = true;
            agreementsNewSearch_linkLabel.Visible = false;
            agreementsDetails_panel.Visible = false;
            agreementsRightArrow_pictureBox.Visible = false;

            agreementsTsc1_textBox.Focus();
        }
        #endregion

        public void SearchAgreements(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                agreementsSearch_button.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        #endregion


        #region [ Loopsets Audit ]
        private void loopsetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationType = DATA_ENUM.OperationType.AuditLoopsets;
            PerformAction();
        }

        /// <summary>
        /// 
        /// </summary>
        private void AuditLoopsets()
        {
            try
            {
                Action_backgroundWorker.ReportProgress(0, "Performing Loopsets audit");

                LoopsetInfo = new List<Data.Audits.LoopsetData>();

                //Cases in which the record doesn't have a loopset <-----------------
                List<Data.OST.GTA_Data> noLoopset = STPsInfo[0].GTA_Data.Where(w => w.LOOPSET == "none" && !string.IsNullOrEmpty(w.LOOPSET) && w.ITU_PC != "s-00000" && w.ITU_PC != "none").ToList();

                foreach (Data.OST.GTA_Data gtaData in noLoopset)
                {
                    var loopetSearch = STPsInfo[0].LoopsetData.Where(w => w.PointCode == gtaData.ITU_PC);

                    if (loopetSearch.Count() > 0)
                    {
                        LoopsetInfo.Add(new Data.Audits.LoopsetData()
                        {
                            Table = gtaData.Table,
                            Gta = gtaData.Start_GTA,
                            End_Gta = gtaData.Start_GTA != gtaData.End_GTA ? gtaData.End_GTA : string.Empty,
                            DPC = gtaData.ITU_PC,
                            Loopset = gtaData.LOOPSET,
                            Suggested_Loopset = loopetSearch.FirstOrDefault().Loopset
                        });
                    }
                }

                //Incorrect Loopset <-----------------
                List<Data.OST.GTA_Data> hasLoopset = STPsInfo[0].GTA_Data.Where(w => w.LOOPSET != "none" && !string.IsNullOrEmpty(w.LOOPSET)).ToList();
                string suggestedLoopset = string.Empty;

                foreach (Data.OST.GTA_Data gtaData in hasLoopset)
                {
                    var loopetSearch = STPsInfo[0].LoopsetData.Where(w => w.PointCode == gtaData.ITU_PC);

                    if (loopetSearch.Count() > 0)
                    {
                        suggestedLoopset = loopetSearch.FirstOrDefault().Loopset;

                        if (suggestedLoopset != gtaData.LOOPSET)
                        {
                            LoopsetInfo.Add(new Data.Audits.LoopsetData()
                            {
                                Table = gtaData.Table,
                                Gta = gtaData.Start_GTA,
                                End_Gta = gtaData.Start_GTA != gtaData.End_GTA ? gtaData.End_GTA : string.Empty,
                                DPC = gtaData.ITU_PC,
                                Loopset = gtaData.LOOPSET,
                                Suggested_Loopset = suggestedLoopset
                            });
                        }
                    }
                }

                if (LoopsetInfo.Count == 0)
                    ShowMessage(MessageTimer_label, "No loopset inconsistencies found.", false, showMessageLeft, showMessageTop, 304, 26);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void ListBox_linkLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBoxSender = ((ListBox)sender);

            if (listBoxSender.Items.Count > 0 && !string.IsNullOrEmpty(listBoxSender.Items[0].ToString()) && !string.IsNullOrEmpty(listBoxSender.Text))
            {
                Clipboard.SetText(listBoxSender.Text);
                MessageBox.Show("Data copied to clipboard", "Operation completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listBoxSender.SelectedIndex = -1;
        }

        private void CopyClipboardListBoxElements(ListBox listbox)
        {
            if (listbox.Enabled && listbox.Items.Count > 0 && !string.IsNullOrEmpty(listbox.Items[0].ToString()))
            {
                CopyValuesClipboard(listbox);
                listbox.SelectedIndex = -1;
            }
        }

        private void loadSTPRominaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoadRominaData())
            {
                OperationType = DATA_ENUM.OperationType.ImportSTP;
                ImportMode = DATA_ENUM.ImportMode.All;
                PerformAction();
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Windows.About aboutWindow = new Windows.About();
            aboutWindow.ShowDialog();
        }

        private void mTPConnectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.Audits.MTP_Connections mtpConn = new Windows.Audits.MTP_Connections();
            mtpConn.ShowDialog();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\Help\\VRS Engineering Tool User Manual.pdf");
        }
    }
}