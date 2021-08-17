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
    public partial class TTMAP : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;
        public List<Data.OST.TTMAP_Data> FilteredData { get; set; }
        List<Data.OST.TTMAP_Data> TTMapData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ttmapInfo"></param>
        public TTMAP(List<Data.OST.TTMAP_Data> ttmapInfo, bool completeData)
        {
            InitializeComponent();

            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            TTMapData = ttmapInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.TTMAP>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_TTMAP filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                ttmapLsn_listBox.Items.Clear();
                dataList = filterResult.TTMapInfo.Where(w => w.LSN != null).Select(s => s.LSN).Distinct().ToList();
                dataList.Sort();
                ttmapLsn_listBox.Items.AddRange(dataList.ToArray());

                ttmapIo_listBox.Items.Clear();
                dataList = filterResult.TTMapInfo.Where(w => w.IO != null).Select(s => s.IO.ToString()).Distinct().ToList();
                dataList.Sort();
                ttmapIo_listBox.Items.AddRange(dataList.ToArray());

                ttmapEtt_listBox.Items.Clear();
                dataList = filterResult.TTMapInfo.Where(w => w.ETT != null).Select(s => s.ETT).Distinct().ToList();
                dataList.Sort();
                ttmapEtt_listBox.Items.AddRange(dataList.ToArray());

                ttmapMtt_listBox.Items.Clear();
                dataList = filterResult.TTMapInfo.Where(w => w.MTT.ToString() != null).Select(s => s.MTT.ToString()).Distinct().ToList();
                dataList.Sort();
                ttmapMtt_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.TTMapInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.TTMAP_Data> filteredData)
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
        private Data.Predicates.PredicateResult_TTMAP GetFilteredData()
        {
            Data.Predicates.PredicateResult_TTMAP filterResult = new Data.Predicates.PredicateResult_TTMAP();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.TTMapInfo = TTMapData.Where(predicate).ToList();
                else
                    filterResult.TTMapInfo = TTMapData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ Get Predicate ]
        private ExpressionStarter<Data.OST.TTMAP_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.TTMAP_Data>();

            try
            {
                if (ttmapLsn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LSN != null && w.LSN == ttmapLsn_listBox.Text);
                else if (!string.IsNullOrEmpty(ttmapLsnSearch_textBox.Text))
                {
                    EnableButton(ttmapLsnClear_button, true);

                    if (UTILS.StartsWith(ttmapLsnSearch_textBox.Text))
                        predicate = predicate.And(w => w.LSN != null && w.LSN.ToUpper().StartsWith(UTILS.GetStartText(ttmapLsnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LSN != null && w.LSN.ToUpper().Contains(ttmapLsnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(ttmapLsnClear_button, false);

                if (ttmapIo_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.IO != null && w.IO == ttmapIo_listBox.Text);
                else if (!string.IsNullOrEmpty(ttmapIoSearch_textBox.Text))
                {
                    EnableButton(ttmapIoClear_button, true);

                    if (UTILS.StartsWith(ttmapIoSearch_textBox.Text))
                        predicate = predicate.And(w => w.IO != null && w.IO.ToUpper().StartsWith(UTILS.GetStartText(ttmapIoSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.IO != null && w.IO.ToUpper().Contains(ttmapIoSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(ttmapIoClear_button, false);

                if (ttmapEtt_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.ETT != null && w.ETT == ttmapEtt_listBox.Text);
                else if (!string.IsNullOrEmpty(ttmapEttSearch_textBox.Text))
                {
                    EnableButton(ttmapEttClear_button, true);

                    if (UTILS.StartsWith(ttmapEttSearch_textBox.Text))
                        predicate = predicate.And(w => w.ETT != null && w.ETT.StartsWith(UTILS.GetStartText(ttmapEttSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.ETT != null && w.ETT.Contains(ttmapEttSearch_textBox.Text));
                }
                else
                    EnableButton(ttmapEttClear_button, false);

                if (ttmapMtt_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.MTT.ToString() != null && w.MTT.ToString() == ttmapMtt_listBox.Text);
                else if (!string.IsNullOrEmpty(ttmapMttSearch_textBox.Text))
                {
                    EnableButton(ttmapMttClear_button, true);

                    if (UTILS.StartsWith(ttmapMttSearch_textBox.Text))
                        predicate = predicate.And(w => w.MTT.ToString() != null && w.MTT.ToString().ToUpper().StartsWith(UTILS.GetStartText(ttmapMttSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.MTT.ToString() != null && w.MTT.ToString().ToUpper().Contains(ttmapMttSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(ttmapMttClear_button, false);
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
            Data.Predicates.PredicateResult_TTMAP filterResult = new Data.Predicates.PredicateResult_TTMAP();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.TTMapInfo = TTMapData.Where(predicate).ToList();
                else
                    filterResult.TTMapInfo = TTMapData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.LSN])
                {
                    dataList = filterResult.TTMapInfo.Where(w => w.LSN != null).Select(s => s.LSN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = ttmapLsn_listBox.SelectedIndex != -1;
                    ttmapLsn_listBox.Items.Clear();
                    ttmapLsn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(ttmapLsnClear_button, true);
                        ttmapLsnSearch_textBox.Enabled = false;
                        ttmapLsnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.LSN] = true;
                        ttmapLsn_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.IO])
                {
                    dataList = filterResult.TTMapInfo.Where(w => w.IO != null).Select(s => s.IO).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = ttmapIo_listBox.SelectedIndex != -1;
                    ttmapIo_listBox.Items.Clear();
                    ttmapIo_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(ttmapIoClear_button, true);
                        ttmapIoSearch_textBox.Enabled = false;
                        ttmapIoSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.IO] = true;
                        ttmapIo_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.ETT])
                {
                    dataList = filterResult.TTMapInfo.Where(w => w.ETT != null).Select(s => s.ETT).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = ttmapEtt_listBox.SelectedIndex != -1;
                    ttmapEtt_listBox.Items.Clear();
                    ttmapEtt_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(ttmapEttClear_button, true);
                        ttmapEttSearch_textBox.Enabled = false;
                        ttmapEttSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.ETT] = true;
                        ttmapEtt_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.MTT])
                {
                    dataList = filterResult.TTMapInfo.Where(w => w.MTT != null).Select(s => s.MTT).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = ttmapMtt_listBox.SelectedIndex != -1;
                    ttmapMtt_listBox.Items.Clear();
                    ttmapMtt_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(ttmapMttClear_button, true);
                        ttmapMttSearch_textBox.Enabled = false;
                        ttmapMttSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.MTT] = true;
                        ttmapMtt_listBox.SelectedIndex = 0;
                    }
                }

                LoadFilteredGrid(filterResult.TTMapInfo);
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
        private void ttmapLsnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.LSN] = false;
            ttmapLsnSearch_textBox.Text = string.Empty;
            ttmapLsnSearch_textBox.Enabled = true;
            ttmapLsn_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void ttmapIoClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.IO] = false;
            ttmapIoSearch_textBox.Text = string.Empty;
            ttmapIoSearch_textBox.Enabled = true;
            ttmapIo_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void ttmapEttClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.ETT] = false;
            ttmapEttSearch_textBox.Text = string.Empty;
            ttmapEttSearch_textBox.Enabled = true;
            ttmapEtt_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void ttmapMttClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.TTMAP.MTT] = false;
            ttmapMttSearch_textBox.Text = string.Empty;
            ttmapMttSearch_textBox.Enabled = true;
            ttmapMtt_listBox.SelectedIndex = -1;
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
            Business.Excel.OST.TTMAP(xlPackage, FilteredData);
        }
        #endregion

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {
            var gridColumns = from t in FilteredData
                              orderby t.LSN
                              select new
                              {
                                  LSN = t.LSN,
                                  IO = t.IO,
                                  ETT = t.ETT,
                                  MTT = t.MTT
                              };

            return gridColumns.ToList();
        }
        #endregion

        #region [ Link Labels ]
        private void ttmapLsn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(ttmapLsn_listBox);
        }

        private void ttmapIo_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(ttmapIo_listBox);
        }

        private void ttmapEtt_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(ttmapEtt_listBox);
        }

        private void ttmapMtt_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(ttmapMtt_listBox);
        }
        #endregion

        #region [ Clear Filters ]
        private void clear_button_Click_1(object sender, EventArgs e)
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