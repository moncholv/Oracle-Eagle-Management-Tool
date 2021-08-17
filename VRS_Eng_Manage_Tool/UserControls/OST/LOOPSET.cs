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
    public partial class LOOPSET : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;
        public List<Data.OST.LOOPSET_Data> FilteredData { get; set; }
        List<Data.OST.LOOPSET_Data> LoopsetData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loopsetInfo"></param>
        public LOOPSET(List<Data.OST.LOOPSET_Data> loopsetInfo, bool completeData)
        {
            InitializeComponent();
            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            LoopsetData = loopsetInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.LOOPSET>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_LOOPSET filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                loopset_listBox.Items.Clear();
                dataList = filterResult.LoopsetInfo.Where(w => w.Loopset != null).Select(s => s.Loopset).Distinct().ToList();
                dataList.Sort();
                loopset_listBox.Items.AddRange(dataList.ToArray());

                loopsetMode_listBox.Items.Clear();
                dataList = filterResult.LoopsetInfo.Where(w => w.Mode != null).Select(s => s.Mode.ToString()).Distinct().ToList();
                dataList.Sort();
                loopsetMode_listBox.Items.AddRange(dataList.ToArray());

                loopsetPointCodes_listBox.Items.Clear();
                dataList = filterResult.LoopsetInfo.Where(w => w.PointCode != null).Select(s => s.PointCode).Distinct().ToList();
                dataList.Sort();
                loopsetPointCodes_listBox.Items.AddRange(dataList.ToArray());

                loopsetType_listBox.Items.Clear();
                dataList = filterResult.LoopsetInfo.Where(w => w.Type.ToString() != null).Select(s => s.Type.ToString()).Distinct().ToList();
                dataList.Sort();
                loopsetType_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.LoopsetInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.LOOPSET_Data> filteredData)
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
        private Data.Predicates.PredicateResult_LOOPSET GetFilteredData()
        {
            Data.Predicates.PredicateResult_LOOPSET filterResult = new Data.Predicates.PredicateResult_LOOPSET();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.LoopsetInfo = LoopsetData.Where(predicate).ToList();
                else
                    filterResult.LoopsetInfo = LoopsetData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ Get Predicate ]
        private ExpressionStarter<Data.OST.LOOPSET_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.LOOPSET_Data>();

            try
            {
                if (loopset_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.Loopset != null && w.Loopset == loopset_listBox.Text);
                else if (!string.IsNullOrEmpty(loopsetSearch_textBox.Text))
                {
                    EnableButton(loopsetClear_button, true);

                    if (UTILS.StartsWith(loopsetSearch_textBox.Text))
                        predicate = predicate.And(w => w.Loopset != null && w.Loopset.ToUpper().StartsWith(UTILS.GetStartText(loopsetSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.Loopset != null && w.Loopset.ToUpper().Contains(loopsetSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(loopsetClear_button, false);

                if (loopsetMode_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.Mode != null && w.Mode == loopsetMode_listBox.Text);
                else if (!string.IsNullOrEmpty(loopsetModeSearch_textBox.Text))
                {
                    EnableButton(loopsetModeClear_button, true);

                    if (UTILS.StartsWith(loopsetModeSearch_textBox.Text))
                        predicate = predicate.And(w => w.Mode != null && w.Mode.StartsWith(UTILS.GetStartText(loopsetModeSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.Mode != null && w.Mode.Contains(loopsetModeSearch_textBox.Text));
                }
                else
                    EnableButton(loopsetModeClear_button, false);

                if (loopsetPointCodes_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.PointCode != null && w.PointCode == loopsetPointCodes_listBox.Text);
                else if (!string.IsNullOrEmpty(loopsetPointCodesSearch_textBox.Text))
                {
                    EnableButton(loopsetPointCodesClear_button, true);

                    if (UTILS.StartsWith(loopsetPointCodesSearch_textBox.Text))
                        predicate = predicate.And(w => w.PointCode != null && w.PointCode.StartsWith(UTILS.GetStartText(loopsetPointCodesSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.PointCode != null && w.PointCode.Contains(loopsetPointCodesSearch_textBox.Text));
                }
                else
                    EnableButton(loopsetPointCodesClear_button, false);

                if (loopsetType_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.Type.ToString() != null && w.Type.ToString() == loopsetType_listBox.Text);
                else if (!string.IsNullOrEmpty(loopsetTypeSearch_textBox.Text))
                {
                    EnableButton(loopsetTypeClear_button, true);

                    if (UTILS.StartsWith(loopsetTypeSearch_textBox.Text))
                        predicate = predicate.And(w => w.Type.ToString() != null && w.Type.ToString().ToUpper().StartsWith(UTILS.GetStartText(loopsetTypeSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.Type.ToString() != null && w.Type.ToString().ToUpper().Contains(loopsetTypeSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(loopsetTypeClear_button, false);
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
            Data.Predicates.PredicateResult_LOOPSET filterResult = new Data.Predicates.PredicateResult_LOOPSET();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.LoopsetInfo = LoopsetData.Where(predicate).ToList();
                else
                    filterResult.LoopsetInfo = LoopsetData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.Loopset])
                {
                    dataList = filterResult.LoopsetInfo.Where(w => w.Loopset != null).Select(s => s.Loopset).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = loopset_listBox.SelectedIndex != -1;
                    loopset_listBox.Items.Clear();
                    loopset_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(loopsetClear_button, true);
                        loopsetSearch_textBox.Enabled = false;
                        loopsetSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.Loopset] = true;
                        loopset_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.Mode])
                {
                    dataList = filterResult.LoopsetInfo.Where(w => w.Mode != null).Select(s => s.Mode).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = loopsetMode_listBox.SelectedIndex != -1;
                    loopsetMode_listBox.Items.Clear();
                    loopsetMode_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(loopsetModeClear_button, true);
                        loopsetModeSearch_textBox.Enabled = false;
                        loopsetModeSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.Mode] = true;
                        loopsetMode_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.PointCode])
                {
                    dataList = filterResult.LoopsetInfo.Where(w => w.PointCode != null).Select(s => s.PointCode).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = loopsetPointCodes_listBox.SelectedIndex != -1;
                    loopsetPointCodes_listBox.Items.Clear();
                    loopsetPointCodes_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(loopsetPointCodesClear_button, true);
                        loopsetPointCodesSearch_textBox.Enabled = false;
                        loopsetPointCodesSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.PointCode] = true;
                        loopsetPointCodes_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.Type])
                {
                    dataList = filterResult.LoopsetInfo.Select(s => s.Type.ToString()).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = loopsetType_listBox.SelectedIndex != -1;
                    loopsetType_listBox.Items.Clear();
                    loopsetType_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(loopsetTypeClear_button, true);
                        loopsetTypeSearch_textBox.Enabled = false;
                        loopsetTypeSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.Type] = true;
                        loopsetType_listBox.SelectedIndex = 0;
                    }
                }

                LoadFilteredGrid(filterResult.LoopsetInfo);
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
        private void loopsetClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.Loopset] = false;
            loopsetSearch_textBox.Text = string.Empty;
            loopsetSearch_textBox.Enabled = true;
            loopset_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void loopsetModeClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.Mode] = false;
            loopsetModeSearch_textBox.Text = string.Empty;
            loopsetModeSearch_textBox.Enabled = true;
            loopsetMode_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void loopsetPcnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.PointCode] = false;
            loopsetPointCodesSearch_textBox.Text = string.Empty;
            loopsetPointCodesSearch_textBox.Enabled = true;
            loopsetPointCodes_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void loopsetTypeClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.LOOPSET.Type] = false;
            loopsetTypeSearch_textBox.Text = string.Empty;
            loopsetTypeSearch_textBox.Enabled = true;
            loopsetType_listBox.SelectedIndex = -1;
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
            Business.Excel.OST.LOOPSET(xlPackage, FilteredData);
        }
        #endregion

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {   
            var gridColumns = from t in FilteredData
                              orderby t.Loopset
                              select new
                              {
                                  LOOPSET = t.Loopset,
                                  Mode = t.Mode.ToString(),
                                  Point_Code = t.PointCode,
                                  Type = t.Type.ToString()
                              };

            return gridColumns.ToList();
        }
        #endregion

        #region [ Link Labels ]
        private void loopset_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(loopset_listBox);
        }

        private void loopsetMode_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(loopsetMode_listBox);
        }

        private void loopsetPointCodes_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(loopsetPointCodes_listBox);
        }

        private void loopsetType_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(loopsetType_listBox);
        }
        #endregion

        #region [ Clear Filters ]
        private void clear_button_Click(object sender, EventArgs e)
        {
            ClearAllClicked(null, null);
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