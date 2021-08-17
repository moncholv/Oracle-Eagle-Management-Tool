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
    public partial class MAPSET : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;
        public List<Data.OST.MAPSET_Data> FilteredData { get; set; }
        List<Data.OST.MAPSET_Data> MapsetData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapsetInfo"></param>
        public MAPSET(List<Data.OST.MAPSET_Data> mapsetInfo, bool completeData)
        {
            InitializeComponent();
            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            MapsetData = mapsetInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.MAPSET>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_MAPSET filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                mapset_listBox.Items.Clear();
                dataList = filterResult.MapsetInfo.Where(w => w.MAPSET != null).Select(s => s.MAPSET).Distinct().ToList();
                dataList.Sort();
                mapset_listBox.Items.AddRange(dataList.ToArray());

                mapsetSsn_listBox.Items.Clear();
                dataList = filterResult.MapsetInfo.Where(w => w.SSN != null).Select(s => s.SSN).Distinct().ToList();
                dataList.Sort();
                mapsetSsn_listBox.Items.AddRange(dataList.ToArray());

                mapsetMult_listBox.Items.Clear();
                dataList = filterResult.MapsetInfo.Where(w => w.MULT != null).Select(s => s.MULT).Distinct().ToList();
                dataList.Sort();
                mapsetMult_listBox.Items.AddRange(dataList.ToArray());

                mapsetRc_listBox.Items.Clear();
                dataList = filterResult.MapsetInfo.Select(s => s.RC.ToString()).Distinct().ToList();
                dataList.Sort();
                mapsetRc_listBox.Items.AddRange(dataList.ToArray());

                mapsetPcn_listBox.Items.Clear();
                dataList = filterResult.MapsetInfo.Where(w => w.PCN != null).Select(s => s.PCN).Distinct().ToList();
                dataList.Sort();
                mapsetPcn_listBox.Items.AddRange(dataList.ToArray());

                mapsetMatePcn_listBox.Items.Clear();
                dataList = filterResult.MapsetInfo.Where(w => w.Mate_PCN != null).Select(s => s.Mate_PCN).Distinct().ToList();
                dataList.Sort();
                mapsetMatePcn_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.MapsetInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.MAPSET_Data> filteredData)
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
        private Data.Predicates.PredicateResult_MAPSET GetFilteredData()
        {
            Data.Predicates.PredicateResult_MAPSET filterResult = new Data.Predicates.PredicateResult_MAPSET();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.MapsetInfo = MapsetData.Where(predicate).ToList();
                else
                    filterResult.MapsetInfo = MapsetData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ Get Predicate ]
        private ExpressionStarter<Data.OST.MAPSET_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.MAPSET_Data>();

            try
            {
                if (mapset_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.MAPSET != null && w.MAPSET == mapset_listBox.Text);
                else if (!string.IsNullOrEmpty(mapsetSearch_textBox.Text))
                {
                    EnableButton(mapsetClear_button, true);

                    if (UTILS.StartsWith(mapsetSearch_textBox.Text))
                        predicate = predicate.And(w => w.MAPSET != null && w.MAPSET.ToUpper().StartsWith(UTILS.GetStartText(mapsetSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.MAPSET != null && w.MAPSET.ToUpper().Contains(mapsetSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(mapsetClear_button, false);

                if (mapsetSsn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.SSN != null && w.SSN == mapsetSsn_listBox.Text);
                else if (!string.IsNullOrEmpty(mapsetSsnSearch_textBox.Text))
                {
                    EnableButton(mapsetSsnClear_button, true);

                    if (UTILS.StartsWith(mapsetSsnSearch_textBox.Text))
                        predicate = predicate.And(w => w.SSN != null && w.SSN.ToUpper().StartsWith(UTILS.GetStartText(mapsetSsnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.SSN != null && w.SSN.ToUpper().Contains(mapsetSsnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(mapsetSsnClear_button, false);

                if (mapsetMult_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.MULT != null && w.MULT == mapsetMult_listBox.Text);
                else if (!string.IsNullOrEmpty(mapsetMultSearch_textBox.Text))
                {
                    EnableButton(mapsetMultClear_button, true);

                    if (UTILS.StartsWith(mapsetMultSearch_textBox.Text))
                        predicate = predicate.And(w => w.MULT != null && w.MULT.StartsWith(UTILS.GetStartText(mapsetMultSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.MULT != null && w.MULT.Contains(mapsetMultSearch_textBox.Text));
                }
                else
                    EnableButton(mapsetMultClear_button, false);

                if (mapsetPcn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.PCN != null && w.PCN == mapsetPcn_listBox.Text);
                else if (!string.IsNullOrEmpty(mapsetPcnSearch_textBox.Text))
                {
                    EnableButton(mapsetPcnClear_button, true);

                    if (UTILS.StartsWith(mapsetPcnSearch_textBox.Text))
                        predicate = predicate.And(w => w.PCN != null && w.PCN.StartsWith(UTILS.GetStartText(mapsetPcnSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.PCN != null && w.PCN.Contains(mapsetPcnSearch_textBox.Text));
                }
                else
                    EnableButton(mapsetPcnClear_button, false);

                if (mapsetRc_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.RC == int.Parse(mapsetRc_listBox.Text));
                else if (!string.IsNullOrEmpty(mapsetRcSearch_textBox.Text))
                {
                    EnableButton(mapsetRcClear_button, true);

                    if (UTILS.StartsWith(mapsetRcSearch_textBox.Text))
                        predicate = predicate.And(w => w.RC.ToString().StartsWith(UTILS.GetStartText(mapsetRcSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.RC.ToString().Contains(mapsetRcSearch_textBox.Text));
                }
                else
                    EnableButton(mapsetRcClear_button, false);

                if (mapsetMatePcn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.Mate_PCN != null && w.Mate_PCN == mapsetMatePcn_listBox.Text);
                else if (!string.IsNullOrEmpty(mapsetMatePcnSearch_textBox.Text))
                {
                    EnableButton(mapsetMatePcnClear_button, true);

                    if (UTILS.StartsWith(mapsetMatePcnSearch_textBox.Text))
                        predicate = predicate.And(w => w.Mate_PCN != null && w.Mate_PCN.ToUpper().StartsWith(UTILS.GetStartText(mapsetMatePcnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.Mate_PCN != null && w.Mate_PCN.ToUpper().Contains(mapsetMatePcnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(mapsetMatePcnClear_button, false);
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
            Data.Predicates.PredicateResult_MAPSET filterResult = new Data.Predicates.PredicateResult_MAPSET();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.MapsetInfo = MapsetData.Where(predicate).ToList();
                else
                    filterResult.MapsetInfo = MapsetData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.MAPSET])
                {
                    dataList = filterResult.MapsetInfo.Where(w => w.MAPSET != null).Select(s => s.MAPSET).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mapset_listBox.SelectedIndex != -1;
                    mapset_listBox.Items.Clear();
                    mapset_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mapsetClear_button, true);
                        mapsetSearch_textBox.Enabled = false;
                        mapsetSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.MAPSET] = true;
                        mapset_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.PCN])
                {
                    dataList = filterResult.MapsetInfo.Where(w => w.PCN != null).Select(s => s.PCN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mapsetPcn_listBox.SelectedIndex != -1;
                    mapsetPcn_listBox.Items.Clear();
                    mapsetPcn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mapsetPcnClear_button, true);
                        mapsetPcnSearch_textBox.Enabled = false;
                        mapsetPcnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.PCN] = true;
                        mapsetPcn_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.Mate_PCN])
                {
                    dataList = filterResult.MapsetInfo.Where(w => w.Mate_PCN != null).Select(s => s.Mate_PCN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mapsetMatePcn_listBox.SelectedIndex != -1;
                    mapsetMatePcn_listBox.Items.Clear();
                    mapsetMatePcn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mapsetMatePcnClear_button, true);
                        mapsetMatePcnSearch_textBox.Enabled = false;
                        mapsetMatePcnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.Mate_PCN] = true;
                        mapsetMatePcn_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.SSN])
                {
                    dataList = filterResult.MapsetInfo.Where(w => w.SSN != null).Select(s => s.SSN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mapsetSsn_listBox.SelectedIndex != -1;
                    mapsetSsn_listBox.Items.Clear();
                    mapsetSsn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mapsetSsnClear_button, true);
                        mapsetSsnSearch_textBox.Enabled = false;
                        mapsetSsnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.SSN] = true;
                        mapsetSsn_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.RC])
                {
                    dataList = filterResult.MapsetInfo.Select(s => s.RC.ToString()).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mapsetRc_listBox.SelectedIndex != -1;
                    mapsetRc_listBox.Items.Clear();
                    mapsetRc_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mapsetRcClear_button, true);
                        mapsetRcSearch_textBox.Enabled = false;
                        mapsetRcSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.RC] = true;
                        mapsetRc_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.MULT])
                {
                    dataList = filterResult.MapsetInfo.Where(w => w.MULT != null).Select(s => s.MULT).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mapsetMult_listBox.SelectedIndex != -1;
                    mapsetMult_listBox.Items.Clear();
                    mapsetMult_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mapsetMultClear_button, true);
                        mapsetMultSearch_textBox.Enabled = false;
                        mapsetMultSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.MULT] = true;
                        mapsetMult_listBox.SelectedIndex = 0;
                    }
                }

                LoadFilteredGrid(filterResult.MapsetInfo);
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
        private void mapsetClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.MAPSET] = false;
            mapsetSearch_textBox.Text = string.Empty;
            mapsetSearch_textBox.Enabled = true;
            mapset_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void mapsetPcnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.PCN] = false;
            mapsetPcnSearch_textBox.Text = string.Empty;
            mapsetPcnSearch_textBox.Enabled = true;
            mapsetPcn_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void mapsetMatePcnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.Mate_PCN] = false;
            mapsetMatePcnSearch_textBox.Text = string.Empty;
            mapsetMatePcnSearch_textBox.Enabled = true;
            mapsetMatePcn_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void mapsetSsnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.SSN] = false;
            mapsetSsnSearch_textBox.Text = string.Empty;
            mapsetSsnSearch_textBox.Enabled = true;
            mapsetSsn_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void mapsetRcClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.RC] = false;
            mapsetRcSearch_textBox.Text = string.Empty;
            mapsetRcSearch_textBox.Enabled = true;
            mapsetRc_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void mapsetMultClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MAPSET.MULT] = false;
            mapsetMultSearch_textBox.Text = string.Empty;
            mapsetMultSearch_textBox.Enabled = true;
            mapsetMult_listBox.SelectedIndex = -1;
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
            Business.Excel.OST.MAPSET(xlPackage, FilteredData);
        }
        #endregion

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {   
            var gridColumns = from t in FilteredData
                              orderby t.MAPSET
                              select new
                              {
                                  MAPSET = t.MAPSET,
                                  PCN = t.PCN,
                                  Mate_PCN = t.Mate_PCN,
                                  SSN = t.SSN,
                                  RC = t.RC,
                                  MULT = t.MULT
                              };

            return gridColumns.ToList();
        }
        #endregion

        #region [ Link Labels ]
        private void mapset_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(mapset_listBox);
        }

        private void mapsetPcn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(mapsetPcn_listBox);
        }

        private void mapsetMatePcn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(mapsetMatePcn_listBox);
        }

        private void mapsetRc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(mapsetRc_listBox);
        }

        private void mapsetSsn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(mapsetSsn_listBox);
        }

        private void mapsetMult_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(mapsetMult_listBox);
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