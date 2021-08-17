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
    public partial class GTTSET : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;
        public List<Data.OST.GTTSET_Data> FilteredData { get; set; }
        List<Data.OST.GTTSET_Data> GttsetData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gttsetInfo"></param>
        /// <param name="selectedSTP"></param>
        public GTTSET(List<Data.OST.GTTSET_Data> gttsetInfo, bool completeData)
        {
            InitializeComponent();
            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            GttsetData = gttsetInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.GTTSET>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_GTTSET filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                dataList = filterResult.GttsetInfo.Where(w => w.GTTSN != null).Select(s => s.GTTSN).Distinct().ToList();
                dataList.Sort();
                gttsetsn_listBox.Items.Clear();
                gttsetsn_listBox.Items.AddRange(dataList.ToArray());

                gttsetSettype_listBox.Items.Clear();
                dataList = filterResult.GttsetInfo.Select(s => s.Type.ToString()).Distinct().ToList();
                dataList.Sort();
                gttsetSettype_listBox.Items.AddRange(dataList.ToArray());

                gttsetCheck_listBox.Items.Clear();
                dataList = filterResult.GttsetInfo.Where(w => w.CHECKMULCOMP != null).Select(s => s.CHECKMULCOMP).Distinct().ToList();
                dataList.Sort();
                gttsetCheck_listBox.Items.AddRange(dataList.ToArray());

                gttsetIdx_listBox.Items.Clear();
                dataList = filterResult.GttsetInfo.Where(w => w.SETIDX != null).Select(s => s.SETIDX).Distinct().ToList();
                dataList.Sort();
                gttsetIdx_listBox.Items.AddRange(dataList.ToArray());

                gttsetSxudt_listBox.Items.Clear();
                dataList = filterResult.GttsetInfo.Where(w => w.SXUDT != null).Select(s => s.SXUDT).Distinct().ToList();
                dataList.Sort();
                gttsetSxudt_listBox.Items.AddRange(dataList.ToArray());

                gttsetNdgt_listBox.Items.Clear();
                dataList = filterResult.GttsetInfo.Where(w => w.NDGT != null).Select(s => s.NDGT).Distinct().ToList();
                dataList.Sort();
                gttsetNdgt_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.GttsetInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.GTTSET_Data> filteredData = null)
        {
            FilteredData = filteredData;

            try
            {
                //search_dataGridView.Width = CompleteData ? 870 : 801;
                search_dataGridView.DataSource = GetGridColumns();
                search_dataGridView.AutoSizeColumnsMode = CompleteData ? DataGridViewAutoSizeColumnsMode.AllCells : DataGridViewAutoSizeColumnsMode.Fill;
                numRecords_label.Text = filteredData != null ? string.Format("{0} {1}", "Number of records:", filteredData.Count.ToString("#,##0")) : string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [ GetFilteredData ]
        /// <summary>
        /// 
        /// </summary>
        /// <returns>PredicateResult_OpCode</returns>
        private Data.Predicates.PredicateResult_GTTSET GetFilteredData()
        {
            Data.Predicates.PredicateResult_GTTSET filterResult = new Data.Predicates.PredicateResult_GTTSET();
            var predicate = GetPredicate();            

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.GttsetInfo = GttsetData.Where(predicate).ToList();
                else
                    filterResult.GttsetInfo = GttsetData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ Get Predicate ]
        private ExpressionStarter<Data.OST.GTTSET_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.GTTSET_Data>();

            try
            {
                if (gttsetsn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.GTTSN != null && w.GTTSN == gttsetsn_listBox.Text);
                else if (!string.IsNullOrEmpty(gttsetsnSearch_textBox.Text))
                {
                    EnableButton(gttsetsnClear_button, true);

                    if (UTILS.StartsWith(gttsetsnSearch_textBox.Text))
                        predicate = predicate.And(w => w.GTTSN != null && w.GTTSN.ToUpper().StartsWith(UTILS.GetStartText(gttsetsnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.GTTSN != null && w.GTTSN.ToUpper().Contains(gttsetsnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttsetsnClear_button, false);

                if (gttsetSettype_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.Type.ToString() == gttsetSettype_listBox.Text);
                else if (!string.IsNullOrEmpty(gttsetSettypeSearch_textBox.Text))
                {
                    EnableButton(gttsetSettypeClear_button, true);

                    if (UTILS.StartsWith(gttsetSettypeSearch_textBox.Text))
                        predicate = predicate.And(w => w.Type.ToString().ToUpper().StartsWith(UTILS.GetStartText(gttsetSettypeSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.Type.ToString().ToUpper().Contains(gttsetSettypeSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttsetSettypeClear_button, false);

                if (gttsetCheck_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.CHECKMULCOMP != null && w.CHECKMULCOMP == gttsetCheck_listBox.Text);
                else if (!string.IsNullOrEmpty(gttsetCheckSearch_textBox.Text))
                {
                    EnableButton(gttsetCheckClear_button, true);

                    if (UTILS.StartsWith(gttsetCheckSearch_textBox.Text))
                        predicate = predicate.And(w => w.CHECKMULCOMP != null && w.CHECKMULCOMP.ToUpper().StartsWith(UTILS.GetStartText(gttsetCheckSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.CHECKMULCOMP != null && w.CHECKMULCOMP.ToUpper().Contains(gttsetCheckSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttsetCheckClear_button, false);

                if (gttsetIdx_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.SETIDX != null && w.SETIDX == gttsetIdx_listBox.Text);
                else if (!string.IsNullOrEmpty(gttsetIdxSearch_textBox.Text))
                {
                    EnableButton(gttsetIdxClear_button, true);

                    if (UTILS.StartsWith(gttsetIdxSearch_textBox.Text))
                        predicate = predicate.And(w => w.SETIDX != null && w.SETIDX.ToUpper().StartsWith(UTILS.GetStartText(gttsetIdxSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.SETIDX != null && w.SETIDX.ToUpper().Contains(gttsetIdxSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttsetIdxClear_button, false);

                if (gttsetSxudt_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.SXUDT != null && w.SXUDT == gttsetSxudt_listBox.Text);
                else if (!string.IsNullOrEmpty(gttsetSxudtSearch_textBox.Text))
                {
                    EnableButton(gttsetSxudtClear_button, true);

                    if (UTILS.StartsWith(gttsetSxudtSearch_textBox.Text))
                        predicate = predicate.And(w => w.SXUDT != null && w.SXUDT.ToUpper().StartsWith(UTILS.GetStartText(gttsetSxudtSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.SXUDT != null && w.SXUDT.ToUpper().Contains(gttsetSxudtSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttsetSxudtClear_button, false);

                if (gttsetNdgt_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.NDGT != null && w.NDGT == gttsetNdgt_listBox.Text);
                else if (!string.IsNullOrEmpty(gttsetNdgtSearch_textBox.Text))
                {
                    EnableButton(gttsetNdgtClear_button, true);

                    if (UTILS.StartsWith(gttsetNdgtSearch_textBox.Text))
                        predicate = predicate.And(w => w.NDGT != null && w.NDGT.ToUpper().StartsWith(UTILS.GetStartText(gttsetNdgtSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.NDGT != null && w.NDGT.ToUpper().Contains(gttsetNdgtSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttsetNdgtClear_button, false);
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
            Data.Predicates.PredicateResult_GTTSET filterResult = new Data.Predicates.PredicateResult_GTTSET();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.GttsetInfo = GttsetData.Where(predicate).ToList();
                else
                    filterResult.GttsetInfo = GttsetData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.GTTSN])
                {
                    dataList = filterResult.GttsetInfo.Where(w => w.GTTSN != null).Select(s => s.GTTSN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttsetsn_listBox.SelectedIndex != -1;
                    gttsetsn_listBox.Items.Clear();
                    gttsetsn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttsetsnClear_button, true);
                        gttsetsnSearch_textBox.Enabled = false;
                        gttsetsnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.GTTSN] = true;
                        gttsetsn_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.TYPE])
                {
                    dataList = filterResult.GttsetInfo.Select(s => s.Type.ToString()).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttsetSettype_listBox.SelectedIndex != -1;
                    gttsetSettype_listBox.Items.Clear();
                    gttsetSettype_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttsetSettypeClear_button, true);
                        gttsetSettypeSearch_textBox.Enabled = false;
                        gttsetSettypeSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.TYPE] = true;
                        gttsetSettype_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.CHECKMULCOMP])
                {
                    dataList = filterResult.GttsetInfo.Where(w => w.CHECKMULCOMP != null).Select(s => s.CHECKMULCOMP).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttsetCheck_listBox.SelectedIndex != -1;
                    gttsetCheck_listBox.Items.Clear();
                    gttsetCheck_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttsetCheckClear_button, true);
                        gttsetCheckSearch_textBox.Enabled = false;
                        gttsetCheckSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.CHECKMULCOMP] = true;
                        gttsetCheck_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.SETIDX])
                {
                    dataList = filterResult.GttsetInfo.Where(w => w.SETIDX != null).Select(s => s.SETIDX).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttsetIdx_listBox.SelectedIndex != -1;
                    gttsetIdx_listBox.Items.Clear();
                    gttsetIdx_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttsetIdxClear_button, true);
                        gttsetIdxSearch_textBox.Enabled = false;
                        gttsetIdxSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.SETIDX] = true;
                        gttsetIdx_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.SXUDT])
                {
                    dataList = filterResult.GttsetInfo.Where(w => w.SXUDT != null).Select(s => s.SXUDT).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttsetSxudt_listBox.SelectedIndex != -1;
                    gttsetSxudt_listBox.Items.Clear();
                    gttsetSxudt_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttsetSxudtClear_button, true);
                        gttsetSxudtSearch_textBox.Enabled = false;
                        gttsetSxudtSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.SXUDT] = true;
                        gttsetSxudt_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.NDGT])
                {
                    dataList = filterResult.GttsetInfo.Where(w => w.NDGT != null).Select(s => s.NDGT).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttsetNdgt_listBox.SelectedIndex != -1;
                    gttsetNdgt_listBox.Items.Clear();
                    gttsetNdgt_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttsetNdgtClear_button, true);
                        gttsetNdgtSearch_textBox.Enabled = false;
                        gttsetNdgtSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.NDGT] = true;
                        gttsetNdgt_listBox.SelectedIndex = 0;
                    }
                }
                
                LoadFilteredGrid(filterResult.GttsetInfo);
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
        private void gttsetsnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.GTTSN] = false;
            gttsetsnSearch_textBox.Text = string.Empty;
            gttsetsnSearch_textBox.Enabled = true;
            gttsetsn_listBox.SelectedIndex = -1;
            FilterData();
            gttsetsnSearch_textBox.Focus();
        }

        private void gttsetSettypeClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.TYPE] = false;
            gttsetSettypeSearch_textBox.Text = string.Empty;
            gttsetSettypeSearch_textBox.Enabled = true;
            gttsetSettype_listBox.SelectedIndex = -1;
            FilterData();
            gttsetSettypeSearch_textBox.Focus();
        }

        private void gttsetCheckClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.CHECKMULCOMP] = false;
            gttsetCheckSearch_textBox.Text = string.Empty;
            gttsetCheckSearch_textBox.Enabled = true;
            gttsetCheck_listBox.SelectedIndex = -1;
            FilterData();
            gttsetCheckSearch_textBox.Focus();
        }

        private void gttsetIdxClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.SETIDX] = false;
            gttsetIdxSearch_textBox.Text = string.Empty;
            gttsetIdxSearch_textBox.Enabled = true;
            gttsetIdx_listBox.SelectedIndex = -1;
            FilterData();
            gttsetIdxSearch_textBox.Focus();
        }

        private void gttsetSxudtClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.SXUDT] = false;
            gttsetSxudtSearch_textBox.Text = string.Empty;
            gttsetSxudtSearch_textBox.Enabled = true;
            gttsetSxudt_listBox.SelectedIndex = -1;
            FilterData();
            gttsetSxudtSearch_textBox.Focus();
        }

        private void gttsetNdgtClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSET.NDGT] = false;
            gttsetNdgtSearch_textBox.Text = string.Empty;
            gttsetNdgtSearch_textBox.Enabled = true;
            gttsetNdgt_listBox.SelectedIndex = -1;
            FilterData();
            gttsetNdgtSearch_textBox.Focus();
        }
        #endregion
        
        #region [ Generate Excel ]
        private void excel_button_Click(object sender, EventArgs e)
        {
            GenerateExcelClicked(null, null);
        }

        public void GenerateExcel(OfficeOpenXml.ExcelPackage xlPackage)
        {
            Business.Excel.OST.GTTSET(xlPackage, FilteredData, CompleteData);
        }
        #endregion

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {
            if (CompleteData)
            {
                var gridColumns = from t in FilteredData
                                  orderby t.GTTSN
                                  select new
                                  {
                                      GTTSN = t.GTTSN,
                                      NETDOM = t.NETDOM,
                                      SETTYPE = t.Type.ToString(),
                                      NPSN = t.NPSN,
                                      CHECKMULCOMP = t.CHECKMULCOMP,
                                      SETIDX = t.SETIDX,
                                      MEASRQD = t.MEASRQD,
                                      SXUDT = t.SXUDT,
                                      NDGT = t.NDGT
                                  };

                return gridColumns.ToList();
            }
            else
            {
                var gridColumns = from t in FilteredData
                                  orderby t.GTTSN
                                  select new
                                  {
                                      GTTSN = t.GTTSN,
                                      SETTYPE = t.Type.ToString(),
                                      CHECKMULCOMP = t.CHECKMULCOMP,
                                      SETIDX = t.SETIDX,
                                      SXUDT = t.SXUDT,
                                      NDGT = t.NDGT
                                  };

                return gridColumns.ToList();
            }
        }
        #endregion

        #region [ Link Labels ]
        private void gttsetGttsn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttsetsn_listBox);
        }

        private void gttsetSettype_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttsetSettype_listBox);
        }

        private void gttsetSetidx_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttsetIdx_listBox);
        }

        private void gttsetNdgt_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttsetNdgt_listBox);
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