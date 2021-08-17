using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LinqKit;

using DATA_ENUM = VRS_Eng_Manage_Tool.Data.Enum;
using UTILS = VRS_Eng_Manage_Tool.Business.Utilities;

namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    public partial class DSTN : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;
        public List<Data.OST.DSTN_Data> FilteredData { get; set; }
        List<Data.OST.DSTN_Data> DstnData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opcodeInfo"></param>
        public DSTN(List<Data.OST.DSTN_Data> dstnInfo, bool completeData)
        {
            InitializeComponent();
            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            DstnData = dstnInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.DSTN>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_DSTN filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                dstnType_listBox.Items.Clear();
                dataList = filterResult.DstnInfo.Select(s => s.Type.ToString()).Distinct().ToList();
                dataList.Sort();
                dstnType_listBox.Items.AddRange(dataList.ToArray());

                dstnDpc_listBox.Items.Clear();
                dataList = filterResult.DstnInfo.Where(w => w.DPC != null).Select(s => s.DPC).Distinct().ToList();
                dataList.Sort();
                dstnDpc_listBox.Items.AddRange(dataList.ToArray());

                dstnDpcDec_listBox.Items.Clear();
                dataList = filterResult.DstnInfo.Where(w => w.DPC_Dec != null).Select(s => s.DPC_Dec).Distinct().ToList();
                dataList.Sort();
                dstnDpcDec_listBox.Items.AddRange(dataList.ToArray());

                dstnClli_listBox.Items.Clear();
                dataList = filterResult.DstnInfo.Select(s => s.CLLI).Distinct().ToList();
                dataList.Sort();
                dstnClli_listBox.Items.AddRange(dataList.ToArray());

                dstnLsn_listBox.Items.Clear();
                dataList = filterResult.DstnInfo.Where(w => w.LSN != null).Select(s => s.LSN).Distinct().ToList();
                dataList.Sort();
                dstnLsn_listBox.Items.AddRange(dataList.ToArray());

                dstnRc_listBox.Items.Clear();
                dataList = filterResult.DstnInfo.Where(w => w.RC != null).Select(s => s.RC).Distinct().ToList();
                dataList.Sort();
                dstnRc_listBox.Items.AddRange(dataList.ToArray());

                dstnApci_listBox.Items.Clear();
                dataList = filterResult.DstnInfo.Where(w => w.APCI != null).Select(s => s.APCI).Distinct().ToList();
                dataList.Sort();
                dstnApci_listBox.Items.AddRange(dataList.ToArray());

                dstnApciDec_listBox.Items.Clear();
                dataList = filterResult.DstnInfo.Where(w => w.APCI_Dec != null).Select(s => s.APCI_Dec).Distinct().ToList();
                dataList.Sort();
                dstnApciDec_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.DstnInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.DSTN_Data> filteredData)
        {
            FilteredData = filteredData;

            try
            {
                search_dataGridView.DataSource = GetGridColumns();
                search_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                numRecords_label.Text = filteredData != null ? string.Format("{0} {1}", "Number of records:", filteredData.Count.ToString("#,##0")) : string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion        

        #region [ GetFilteredData ]
        private Data.Predicates.PredicateResult_DSTN GetFilteredData()
        {
            Data.Predicates.PredicateResult_DSTN filterResult = new Data.Predicates.PredicateResult_DSTN();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.DstnInfo = DstnData.Where(predicate).ToList();
                else
                    filterResult.DstnInfo = DstnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ Get Predicate ]
        private ExpressionStarter<Data.OST.DSTN_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.DSTN_Data>();

            try
            {
                if (dstnType_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.Type.ToString() == dstnType_listBox.Text);
                else if (!string.IsNullOrEmpty(dstnTypeSearch_textBox.Text))
                {
                    EnableButton(dstnTypeClear_button, true);

                    if (UTILS.StartsWith(dstnTypeSearch_textBox.Text))
                        predicate = predicate.And(w => w.Type.ToString().ToUpper().StartsWith(UTILS.GetStartText(dstnTypeSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.Type.ToString().ToUpper().Contains(dstnTypeSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(dstnTypeClear_button, false);

                if (dstnDpc_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.DPC != null && w.DPC == dstnDpc_listBox.Text);
                else if (!string.IsNullOrEmpty(dstnDpcSearch_textBox.Text))
                {
                    EnableButton(dstnDpcClear_button, true);

                    if (UTILS.StartsWith(dstnDpcSearch_textBox.Text))
                        predicate = predicate.And(w => w.DPC != null && w.DPC.StartsWith(UTILS.GetStartText(dstnDpcSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.DPC != null && w.DPC.Contains(dstnDpcSearch_textBox.Text));
                }
                else
                    EnableButton(dstnDpcClear_button, false);

                if (dstnDpcDec_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.DPC_Dec != null && w.DPC_Dec == dstnDpcDec_listBox.Text);
                else if (!string.IsNullOrEmpty(dstnDpcDecSearch_textBox.Text))
                {
                    EnableButton(dstnDpcDecClear_button, true);

                    if (UTILS.StartsWith(dstnDpcDecSearch_textBox.Text))
                        predicate = predicate.And(w => w.DPC_Dec != null && w.DPC_Dec.StartsWith(UTILS.GetStartText(dstnDpcDecSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.DPC_Dec != null && w.DPC_Dec.Contains(dstnDpcDecSearch_textBox.Text));
                }
                else
                    EnableButton(dstnDpcDecClear_button, false);

                if (dstnLsn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LSN != null && w.LSN == dstnLsn_listBox.Text);
                else if (!string.IsNullOrEmpty(dstnLsnSearch_textBox.Text))
                {
                    EnableButton(dstnLsnClear_button, true);

                    if (UTILS.StartsWith(dstnLsnSearch_textBox.Text))
                        predicate = predicate.And(w => w.LSN != null && w.LSN.ToUpper().StartsWith(UTILS.GetStartText(dstnLsnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LSN != null && w.LSN.ToUpper().Contains(dstnLsnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(dstnLsnClear_button, false);

                if (dstnClli_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.CLLI != null && w.CLLI == dstnClli_listBox.Text);
                else if (!string.IsNullOrEmpty(dstnClliSearch_textBox.Text))
                {
                    EnableButton(dstnClliClear_button, true);

                    if (UTILS.StartsWith(dstnClliSearch_textBox.Text))
                        predicate = predicate.And(w => w.CLLI != null && w.CLLI.ToUpper().StartsWith(UTILS.GetStartText(dstnClliSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.CLLI != null && w.CLLI.ToUpper().Contains(dstnClliSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(dstnClliClear_button, false);

                if (dstnRc_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.RC.ToString() == dstnRc_listBox.Text);
                else if (!string.IsNullOrEmpty(dstnRcSearch_textBox.Text))
                {
                    EnableButton(dstnRcClear_button, true);

                    if (UTILS.StartsWith(dstnRcSearch_textBox.Text))
                        predicate = predicate.And(w => w.RC != null && w.RC.StartsWith(UTILS.GetStartText(dstnClliSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.RC != null && w.RC.Contains(dstnClliSearch_textBox.Text));
                }
                else
                    EnableButton(dstnRcClear_button, false);

                if (dstnApci_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.APCI != null && w.APCI == dstnApci_listBox.Text);
                else if (!string.IsNullOrEmpty(dstnApciSearch_textBox.Text))
                {
                    EnableButton(dstnApciClear_button, true);

                    if (UTILS.StartsWith(dstnApciSearch_textBox.Text))
                        predicate = predicate.And(w => w.APCI != null && w.APCI.StartsWith(UTILS.GetStartText(dstnApciSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.APCI != null && w.APCI.Contains(dstnApciSearch_textBox.Text));
                }
                else
                    EnableButton(dstnApciClear_button, false);

                if (dstnApciDec_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.APCI_Dec != null && w.APCI_Dec == dstnApciDec_listBox.Text);
                else if (!string.IsNullOrEmpty(dstnApciDecSearch_textBox.Text))
                {
                    EnableButton(dstnApciDecClear_button, true);

                    if (UTILS.StartsWith(dstnApciDecSearch_textBox.Text))
                        predicate = predicate.And(w => w.APCI_Dec != null && w.APCI_Dec.StartsWith(UTILS.GetStartText(dstnApciDecSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.APCI_Dec != null && w.APCI_Dec.Contains(dstnApciDecSearch_textBox.Text));
                }
                else
                    EnableButton(dstnApciDecClear_button, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return predicate;
        }
        #endregion

        #region [ Filter Data ]
        private void FilterData()
        {
            bool itemSelected = false;
            List<string> dataList = null;
            Data.Predicates.PredicateResult_DSTN filterResult = new Data.Predicates.PredicateResult_DSTN();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.DstnInfo = DstnData.Where(predicate).ToList();
                else
                    filterResult.DstnInfo = DstnData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.TYPE])
                {
                    dataList = filterResult.DstnInfo.Select(s => s.Type.ToString()).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = dstnType_listBox.SelectedIndex != -1;
                    dstnType_listBox.Items.Clear();
                    dstnType_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(dstnTypeClear_button, true);
                        dstnTypeSearch_textBox.Enabled = false;
                        dstnTypeSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.TYPE] = true;
                        dstnType_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.DPC])
                {
                    dataList = filterResult.DstnInfo.Where(w => w.DPC != null).Select(s => s.DPC).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = dstnDpc_listBox.SelectedIndex != -1;
                    dstnDpc_listBox.Items.Clear();
                    dstnDpc_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(dstnDpcClear_button, true);
                        dstnDpcSearch_textBox.Enabled = false;
                        dstnDpcSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.DPC] = true;
                        dstnDpc_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.DPC_Dec])
                {
                    dataList = filterResult.DstnInfo.Where(w => w.DPC_Dec != null).Select(s => s.DPC_Dec).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = dstnDpcDec_listBox.SelectedIndex != -1;
                    dstnDpcDec_listBox.Items.Clear();
                    dstnDpcDec_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(dstnDpcDecClear_button, true);
                        dstnDpcDecSearch_textBox.Enabled = false;
                        dstnDpcDecSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.DPC_Dec] = true;
                        dstnDpcDec_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.CLLI])
                {
                    dataList = filterResult.DstnInfo.Where(w => w.CLLI != null).Select(s => s.CLLI).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = dstnClli_listBox.SelectedIndex != -1;
                    dstnClli_listBox.Items.Clear();
                    dstnClli_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(dstnClliClear_button, true);
                        dstnClliSearch_textBox.Enabled = false;
                        dstnClliSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.CLLI] = true;
                        dstnClli_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.LSN])
                {
                    dataList = filterResult.DstnInfo.Where(w => w.LSN != null).Select(s => s.LSN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = dstnLsn_listBox.SelectedIndex != -1;
                    dstnLsn_listBox.Items.Clear();
                    dstnLsn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(dstnLsnClear_button, true);
                        dstnLsnSearch_textBox.Enabled = false;
                        dstnLsnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.LSN] = true;
                        dstnLsn_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.RC])
                {
                    dataList = filterResult.DstnInfo.Where(w => w.RC != null).Select(s => s.RC).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = dstnRc_listBox.SelectedIndex != -1;
                    dstnRc_listBox.Items.Clear();
                    dstnRc_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(dstnRcClear_button, true);
                        dstnRcSearch_textBox.Enabled = false;
                        dstnRcSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.RC] = true;
                        dstnRc_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.APCI])
                {
                    dataList = filterResult.DstnInfo.Where(w => w.APCI != null).Select(s => s.APCI).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = dstnApci_listBox.SelectedIndex != -1;
                    dstnApci_listBox.Items.Clear();
                    dstnApci_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(dstnApciClear_button, true);
                        dstnApciSearch_textBox.Enabled = false;
                        dstnApciSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.APCI] = true;
                        dstnApci_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.APCI_Dec])
                {
                    dataList = filterResult.DstnInfo.Where(w => w.APCI_Dec != null).Select(s => s.APCI_Dec).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = dstnApciDec_listBox.SelectedIndex != -1;
                    dstnApciDec_listBox.Items.Clear();
                    dstnApciDec_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(dstnApciDecClear_button, true);
                        dstnApciDecSearch_textBox.Enabled = false;
                        dstnApciDecSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.APCI_Dec] = true;
                        dstnApciDec_listBox.SelectedIndex = 0;
                    }
                }

                LoadFilteredGrid(filterResult.DstnInfo);
                ClearAllPerformed(filterResult.Started, null);
                clear_button.Enabled = filterResult.Started;
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion        


        #region [ ListBox Selected Index Changed ]
        private void Filter_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        #endregion

        #region [ Search textBox KeyUp ]
        private void Search_textBox_KeyUp(object sender, KeyEventArgs e)
        {
            FilterData();
        }
        #endregion
        
        #region [ Clear Buttons ]
        private void dstnTypeClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.TYPE] = false;
            dstnTypeSearch_textBox.Text = string.Empty;
            dstnTypeSearch_textBox.Enabled = true;
            dstnType_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void dstnDpcClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.DPC] = false;
            dstnDpcSearch_textBox.Text = string.Empty;
            dstnDpcSearch_textBox.Enabled = true;
            dstnDpc_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void dstnDpcDecClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.DPC_Dec] = false;
            dstnDpcDecSearch_textBox.Text = string.Empty;
            dstnDpcDecSearch_textBox.Enabled = true;
            dstnDpcDec_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void dstnClliClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.CLLI] = false;
            dstnClliSearch_textBox.Text = string.Empty;
            dstnClliSearch_textBox.Enabled = true;
            dstnClli_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void dstnLsnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.LSN] = false;
            dstnLsnSearch_textBox.Text = string.Empty;
            dstnLsnSearch_textBox.Enabled = true;
            dstnLsn_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void dstnRcClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.RC] = false;
            dstnRcSearch_textBox.Text = string.Empty;
            dstnRcSearch_textBox.Enabled = true;
            dstnRc_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void dstnApciClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.APCI] = false;
            dstnApciSearch_textBox.Text = string.Empty;
            dstnApciSearch_textBox.Enabled = true;
            dstnApci_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void dstnApciDecClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.DSTN.APCI_Dec] = false;
            dstnApciDecSearch_textBox.Text = string.Empty;
            dstnApciDecSearch_textBox.Enabled = true;
            dstnApciDec_listBox.SelectedIndex = -1;
            FilterData();
        }
        #endregion
        
        #region [ Generate Excel ]
        private void excel_button_Click(object sender, EventArgs e)
        {
            GenerateExcelClicked(null, null);
        }

        public void GenerateExcel(OfficeOpenXml.ExcelPackage xlPackage)
        {
            Business.Excel.OST.DSTN(xlPackage, FilteredData);
        }
        #endregion

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {   
            var gridColumns = from t in FilteredData
                              orderby t.Type.ToString()
                              select new
                              {
                                  TYPE = t.Type.ToString(),
                                  DPC = t.DPC,
                                  DPC_Dec = t.DPC_Dec,
                                  CLLI = t.CLLI,
                                  LSN = t.LSN,
                                  RC = t.RC,
                                  APCI = t.APCI,
                                  APCI_DEC = t.APCI_Dec
                              };

            return gridColumns.ToList();
        }
        #endregion

        #region [ Link Labels ]
        private void dstnDpc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(dstnDpc_listBox);
        }

        private void dstnDpcDec_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(dstnDpcDec_listBox);
        }

        private void dstnClli_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(dstnClli_listBox);
        }

        private void dstnLsn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(dstnLsn_listBox);
        }

        private void dstnRc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(dstnRc_listBox);
        }

        private void dstnApci_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(dstnApci_listBox);
        }

        private void dstnApciDec_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(dstnApciDec_listBox);
        }
        #endregion

        #region [ Clear Filters ]
        private void clear_button_Click(object sender, EventArgs e)
        {
            ClearAllClicked(null, null);
        }

        public bool CheckClearButton
        {
            get { return clear_button.Enabled; }
        }
        #endregion

        #region [  Search DataGridView DataBindingComplete ]
        private void search_dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            base.SetGridStyle(search_dataGridView);
            search_dataGridView.ClearSelection();
        }
        #endregion
    }
}