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
    public partial class HOST : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;
        public List<Data.OST.HOST_Data> FilteredData { get; set; }
        List<Data.OST.HOST_Data> HostData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opcodeInfo"></param>
        public HOST(List<Data.OST.HOST_Data> hostInfo, bool completeData)
        {
            InitializeComponent();
            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            HostData = hostInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.HOST>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_HOST filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                hostType_listBox.Items.Clear();
                dataList = filterResult.HostInfo.Select(s => s.Type.ToString()).Distinct().ToList();
                dataList.Sort();
                hostType_listBox.Items.AddRange(dataList.ToArray());

                hostLoc_listBox.Items.Clear();
                dataList = filterResult.HostInfo.Where(w => w.LOC != null).Select(s => s.LOC).Distinct().ToList();
                dataList.Sort();
                hostLoc_listBox.Items.AddRange(dataList.ToArray());

                hostIp_listBox.Items.Clear();
                dataList = filterResult.HostInfo.Where(w => w.IPADDR != null).Select(s => s.IPADDR).Distinct().ToList();
                dataList.Sort();
                hostIp_listBox.Items.AddRange(dataList.ToArray());

                host_listBox.Items.Clear();
                dataList = filterResult.HostInfo.Where(w => w.HOST != null).Select(s => s.HOST).Distinct().ToList();
                dataList.Sort();
                host_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.HostInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.HOST_Data> filteredData)
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
        private Data.Predicates.PredicateResult_HOST GetFilteredData()
        {
            Data.Predicates.PredicateResult_HOST filterResult = new Data.Predicates.PredicateResult_HOST();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.HostInfo = HostData.Where(predicate).ToList();
                else
                    filterResult.HostInfo = HostData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ GetPredicate ]
        private ExpressionStarter<Data.OST.HOST_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.HOST_Data>();

            try
            {
                if (hostType_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.Type.ToString() == hostType_listBox.Text);
                else if (!string.IsNullOrEmpty(hostTypeSearch_textBox.Text))
                {
                    EnableButton(hostTypeClear_button, true);

                    if (UTILS.StartsWith(hostTypeSearch_textBox.Text))
                        predicate = predicate.And(w => w.Type.ToString().ToUpper().StartsWith(UTILS.GetStartText(hostTypeSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.Type.ToString().ToUpper().Contains(hostTypeSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(hostTypeClear_button, false);

                if (hostLoc_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LOC != null && w.LOC == hostLoc_listBox.Text);
                else if (!string.IsNullOrEmpty(hostLocSearch_textBox.Text))
                {
                    EnableButton(hostLocClear_button, true);

                    if (UTILS.StartsWith(hostLocSearch_textBox.Text))
                        predicate = predicate.And(w => w.LOC != null && w.LOC.ToUpper().StartsWith(UTILS.GetStartText(hostLocSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LOC != null && w.LOC.ToUpper().Contains(hostLocSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(hostLocClear_button, false);

                if (hostIp_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.IPADDR != null && w.IPADDR == hostIp_listBox.Text);
                else if (!string.IsNullOrEmpty(hostIpSearch_textBox.Text))
                {
                    EnableButton(hostIpClear_button, true);

                    if (UTILS.StartsWith(hostIpSearch_textBox.Text))
                        predicate = predicate.And(w => w.IPADDR != null && w.IPADDR.StartsWith(UTILS.GetStartText(hostIpSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.IPADDR != null && w.IPADDR.Contains(hostIpSearch_textBox.Text));
                }
                else
                    EnableButton(hostIpClear_button, false);

                if (host_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.HOST != null && w.HOST == host_listBox.Text);
                else if (!string.IsNullOrEmpty(hostSearch_textBox.Text))
                {
                    EnableButton(hostClear_button, true);

                    if (UTILS.StartsWith(hostSearch_textBox.Text))
                        predicate = predicate.And(w => w.HOST != null && w.HOST.ToUpper().StartsWith(UTILS.GetStartText(hostSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.HOST != null && w.HOST.ToUpper().Contains(hostSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(hostClear_button, false);
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
            Data.Predicates.PredicateResult_HOST filterResult = new Data.Predicates.PredicateResult_HOST();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.HostInfo = HostData.Where(predicate).ToList();
                else
                    filterResult.HostInfo = HostData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.HOST.Type])
                {
                    dataList = filterResult.HostInfo.Select(s => s.Type.ToString()).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = hostType_listBox.SelectedIndex != -1;
                    hostType_listBox.Items.Clear();
                    hostType_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(hostTypeClear_button, true);
                        hostTypeSearch_textBox.Enabled = false;
                        hostTypeSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.HOST.Type] = true;
                        hostType_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.HOST.LOC])
                {
                    dataList = filterResult.HostInfo.Where(w => w.LOC != null).Select(s => s.LOC).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = hostLoc_listBox.SelectedIndex != -1;
                    hostLoc_listBox.Items.Clear();
                    hostLoc_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(hostLocClear_button, true);
                        hostLocSearch_textBox.Enabled = false;
                        hostLocSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.HOST.LOC] = true;
                        hostLoc_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.HOST.IPADDR])
                {
                    dataList = filterResult.HostInfo.Where(w => w.IPADDR != null).Select(s => s.IPADDR).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = hostIp_listBox.SelectedIndex != -1;
                    hostIp_listBox.Items.Clear();
                    hostIp_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(hostIpClear_button, true);
                        hostIpSearch_textBox.Enabled = false;
                        hostIpSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.HOST.IPADDR] = true;
                        hostIp_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.HOST.HOST])
                {
                    dataList = filterResult.HostInfo.Where(w => w.HOST != null).Select(s => s.HOST).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = host_listBox.SelectedIndex != -1;
                    host_listBox.Items.Clear();
                    host_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(hostClear_button, true);
                        hostSearch_textBox.Enabled = false;
                        hostSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.HOST.HOST] = true;
                        host_listBox.SelectedIndex = 0;
                    }
                }            

                LoadFilteredGrid(filterResult.HostInfo);
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
        private void mrnsetClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.MRNSET] = false;
            hostTypeSearch_textBox.Text = string.Empty;
            hostTypeSearch_textBox.Enabled = true;
            hostType_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void mrnsetNetClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.NET] = false;
            hostLocSearch_textBox.Text = string.Empty;
            hostLocSearch_textBox.Enabled = true;
            hostLoc_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void mrnsetPcClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.PC] = false;
            hostIpSearch_textBox.Text = string.Empty;
            hostIpSearch_textBox.Enabled = true;
            hostIp_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void mrnsetRcClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.RC] = false;
            hostSearch_textBox.Text = string.Empty;
            hostSearch_textBox.Enabled = true;
            host_listBox.SelectedIndex = -1;
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
            Business.Excel.OST.HOST(xlPackage, FilteredData);
        }
        #endregion

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {   
            var gridColumns = from t in FilteredData
                              orderby t.Type.ToString()
                              select new
                              {
                                  Type = t.Type,
                                  LOC = t.LOC,
                                  IPADDR = t.IPADDR,
                                  HOST = t.HOST
                              };

            return gridColumns.ToList();
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