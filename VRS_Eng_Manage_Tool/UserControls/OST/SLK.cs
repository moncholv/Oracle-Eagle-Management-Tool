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
    public partial class SLK : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;
        public List<Data.OST.SLK_Data> FilteredData { get; set; }
        List<Data.OST.SLK_Data> SlkData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slkInfo"></param>
        /// <param name="completeData"></param>
        public SLK(List<Data.OST.SLK_Data> slkInfo, bool completeData)
        {
            InitializeComponent();
            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            SlkData = slkInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.SLK>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_SLK filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                slkLoc_listBox.Items.Clear();
                dataList = filterResult.SlkInfo.Where(w => w.LOC != null).Select(s => s.LOC).Distinct().ToList();
                dataList.Sort();
                slkLoc_listBox.Items.AddRange(dataList.ToArray());

                slkLink_listBox.Items.Clear();
                dataList = filterResult.SlkInfo.Where(w => w.LINK != null).Select(s => s.LINK).Distinct().ToList();
                dataList.Sort();
                slkLink_listBox.Items.AddRange(dataList.ToArray());

                slkLsn_listBox.Items.Clear();
                dataList = filterResult.SlkInfo.Where(w => w.LSN != null).Select(s => s.LSN).Distinct().ToList();
                dataList.Sort();
                slkLsn_listBox.Items.AddRange(dataList.ToArray());

                slkSlc_listBox.Items.Clear();
                dataList = filterResult.SlkInfo.Where(w => w.SLC != null).Select(s => s.SLC).Distinct().ToList();
                dataList.Sort();
                slkSlc_listBox.Items.AddRange(dataList.ToArray());

                slkType_listBox.Items.Clear();
                dataList = filterResult.SlkInfo.Where(w => w.TYPE != null).Select(s => s.TYPE).Distinct().ToList();
                dataList.Sort();
                slkType_listBox.Items.AddRange(dataList.ToArray());

                slkAname_listBox.Items.Clear();
                dataList = filterResult.SlkInfo.Where(w => w.ANAME != null).Select(s => s.ANAME).Distinct().ToList();
                dataList.Sort();
                slkAname_listBox.Items.AddRange(dataList.ToArray());

                slkKtps_listBox.Items.Clear();
                dataList = filterResult.SlkInfo.Where(w => w.SLKTPS != null).Select(s => s.SLKTPS).Distinct().ToList();
                dataList.Sort();
                slkKtps_listBox.Items.AddRange(dataList.ToArray());

                slkMax_listBox.Items.Clear();
                dataList = filterResult.SlkInfo.Where(w => w.MAXSLKTPS != null).Select(s => s.MAXSLKTPS).Distinct().ToList();
                dataList.Sort();
                slkMax_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.SlkInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.SLK_Data> filteredData)
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
        private Data.Predicates.PredicateResult_SLK GetFilteredData()
        {
            Data.Predicates.PredicateResult_SLK filterResult = new Data.Predicates.PredicateResult_SLK();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.SlkInfo = SlkData.Where(predicate).ToList();
                else
                    filterResult.SlkInfo = SlkData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ GetPredicate ]
        private ExpressionStarter<Data.OST.SLK_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.SLK_Data>();

            try
            {
                if (slkLoc_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LOC != null && w.LOC == slkLoc_listBox.Text);
                else if (!string.IsNullOrEmpty(slkLocSearch_textBox.Text))
                {
                    EnableButton(slkLocClear_button, true);

                    if (UTILS.StartsWith(slkLocSearch_textBox.Text))
                        predicate = predicate.And(w => w.LOC != null && w.LOC.ToUpper().StartsWith(UTILS.GetStartText(slkLocSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LOC != null && w.LOC.ToUpper().Contains(slkLocSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(slkLocClear_button, false);

                if (slkLink_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LINK != null && w.LINK == slkLink_listBox.Text);
                else if (!string.IsNullOrEmpty(slkLinkSearch_textBox.Text))
                {
                    EnableButton(slkLinkClear_button, true);

                    if (UTILS.StartsWith(slkLinkSearch_textBox.Text))
                        predicate = predicate.And(w => w.LINK != null && w.LINK.ToUpper().StartsWith(UTILS.GetStartText(slkLinkSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LINK != null && w.LINK.ToUpper().Contains(slkLinkSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(slkLinkClear_button, false);

                if (slkLsn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LSN != null && w.LSN == slkLsn_listBox.Text);
                else if (!string.IsNullOrEmpty(slkLsnSearch_textBox.Text))
                {
                    EnableButton(slkLsnClear_button, true);

                    if (UTILS.StartsWith(slkLsnSearch_textBox.Text))
                        predicate = predicate.And(w => w.LSN != null && w.LSN.ToUpper().StartsWith(UTILS.GetStartText(slkLsnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LSN != null && w.LSN.ToUpper().Contains(slkLsnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(slkLsnClear_button, false);

                if (slkSlc_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.SLC != null && w.SLC == slkSlc_listBox.Text);
                else if (!string.IsNullOrEmpty(slkSlcSearch_textBox.Text))
                {
                    EnableButton(slkSlcClear_button, true);

                    if (UTILS.StartsWith(slkSlcSearch_textBox.Text))
                        predicate = predicate.And(w => w.SLC.ToString().ToUpper().StartsWith(UTILS.GetStartText(slkSlcSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.SLC.ToString().ToUpper().Contains(slkSlcSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(slkSlcClear_button, false);

                if (slkType_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.TYPE != null && w.TYPE == slkType_listBox.Text);
                else if (!string.IsNullOrEmpty(slkTypeSearch_textBox.Text))
                {
                    EnableButton(slkTypeClear_button, true);

                    if (UTILS.StartsWith(slkTypeSearch_textBox.Text))
                        predicate = predicate.And(w => w.TYPE != null && w.TYPE.ToUpper().StartsWith(UTILS.GetStartText(slkTypeSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.TYPE != null && w.TYPE.ToUpper().Contains(slkTypeSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(slkTypeClear_button, false);

                if (slkAname_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.ANAME != null && w.ANAME == slkAname_listBox.Text);
                else if (!string.IsNullOrEmpty(slkAnameSearch_textBox.Text))
                {
                    EnableButton(slkAnameClear_button, true);

                    if (UTILS.StartsWith(slkAnameSearch_textBox.Text))
                        predicate = predicate.And(w => w.ANAME != null && w.ANAME.ToUpper().StartsWith(UTILS.GetStartText(slkAnameSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.ANAME != null && w.ANAME.ToUpper().Contains(slkAnameSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(slkAnameClear_button, false);

                if (slkKtps_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.SLKTPS != null && w.SLKTPS == slkKtps_listBox.Text);
                else if (!string.IsNullOrEmpty(slkKtpsSearch_textBox.Text))
                {
                    EnableButton(slkKtpsClear_button, true);

                    if (UTILS.StartsWith(slkKtpsSearch_textBox.Text))
                        predicate = predicate.And(w => w.SLKTPS != null && w.SLKTPS.ToUpper().StartsWith(UTILS.GetStartText(slkKtpsSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.SLKTPS != null && w.SLKTPS.ToUpper().Contains(slkKtpsSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(slkKtpsClear_button, false);

                if (slkMax_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.MAXSLKTPS != null && w.MAXSLKTPS == slkMax_listBox.Text);
                else if (!string.IsNullOrEmpty(slkMaxSearch_textBox.Text))
                {
                    EnableButton(slkMaxClear_button, true);

                    if (UTILS.StartsWith(slkMaxSearch_textBox.Text))
                        predicate = predicate.And(w => w.MAXSLKTPS != null && w.MAXSLKTPS.ToUpper().StartsWith(UTILS.GetStartText(slkMaxSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.MAXSLKTPS != null && w.MAXSLKTPS.ToUpper().Contains(slkMaxSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(slkMaxClear_button, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return predicate;
        }
        #endregion

        #region [ FilterData ]
        private void FilterData()
        {
            bool itemSelected = false;
            List<string> dataList = null;
            Data.Predicates.PredicateResult_SLK filterResult = new Data.Predicates.PredicateResult_SLK();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.SlkInfo = SlkData.Where(predicate).ToList();
                else
                    filterResult.SlkInfo = SlkData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.LOC])
                {
                    dataList = filterResult.SlkInfo.Where(w => w.LOC != null).Select(s => s.LOC).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = slkLoc_listBox.SelectedIndex != -1;
                    slkLoc_listBox.Items.Clear();
                    slkLoc_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(slkLocClear_button, true);
                        slkLocSearch_textBox.Enabled = false;
                        slkLocSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.LOC] = true;
                        slkLoc_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.LINK])
                {
                    dataList = filterResult.SlkInfo.Where(w => w.LINK != null).Select(s => s.LINK).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = slkLink_listBox.SelectedIndex != -1;
                    slkLink_listBox.Items.Clear();
                    slkLink_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(slkLinkClear_button, true);
                        slkLinkSearch_textBox.Enabled = false;
                        slkLinkSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.LINK] = true;
                        slkLink_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.LSN])
                {
                    dataList = filterResult.SlkInfo.Where(w => w.LSN != null).Select(s => s.LSN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = slkLsn_listBox.SelectedIndex != -1;
                    slkLsn_listBox.Items.Clear();
                    slkLsn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(slkLsnClear_button, true);
                        slkLsnSearch_textBox.Enabled = false;
                        slkLsnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.LSN] = true;
                        slkLsn_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.SLC])
                {
                    dataList = filterResult.SlkInfo.Where(w => w.SLC != null).Select(s => s.SLC).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = slkSlc_listBox.SelectedIndex != -1;
                    slkSlc_listBox.Items.Clear();
                    slkSlc_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(slkSlcClear_button, true);
                        slkSlcSearch_textBox.Enabled = false;
                        slkSlcSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.SLC] = true;
                        slkSlc_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.TYPE])
                {
                    dataList = filterResult.SlkInfo.Where(w => w.TYPE != null).Select(s => s.TYPE).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = slkType_listBox.SelectedIndex != -1;
                    slkType_listBox.Items.Clear();
                    slkType_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(slkTypeClear_button, true);
                        slkTypeSearch_textBox.Enabled = false;
                        slkTypeSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.TYPE] = true;
                        slkType_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.ANAME])
                {
                    dataList = filterResult.SlkInfo.Where(w => w.ANAME != null).Select(s => s.ANAME).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = slkAname_listBox.SelectedIndex != -1;
                    slkAname_listBox.Items.Clear();
                    slkAname_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(slkAnameClear_button, true);
                        slkAnameSearch_textBox.Enabled = false;
                        slkAnameSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.ANAME] = true;
                        slkAname_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.SLKTPS])
                {
                    dataList = filterResult.SlkInfo.Where(w => w.SLKTPS != null).Select(s => s.SLKTPS).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = slkKtps_listBox.SelectedIndex != -1;
                    slkKtps_listBox.Items.Clear();
                    slkKtps_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(slkKtpsClear_button, true);
                        slkKtpsSearch_textBox.Enabled = false;
                        slkKtpsSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.SLKTPS] = true;
                        slkKtps_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.MAXSLKTPS])
                {
                    dataList = filterResult.SlkInfo.Where(w => w.MAXSLKTPS != null).Select(s => s.MAXSLKTPS).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = slkMax_listBox.SelectedIndex != -1;
                    slkMax_listBox.Items.Clear();
                    slkMax_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(slkMaxClear_button, true);
                        slkMaxSearch_textBox.Enabled = false;
                        slkMaxSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.MAXSLKTPS] = true;
                        slkMax_listBox.SelectedIndex = 0;
                    }
                }

                LoadFilteredGrid(filterResult.SlkInfo);
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
        private void slkLocClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.LOC] = false;
            slkLocSearch_textBox.Text = string.Empty;
            slkLocSearch_textBox.Enabled = true;
            slkLoc_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void slkLinkClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.LINK] = false;
            slkLinkSearch_textBox.Text = string.Empty;
            slkLinkSearch_textBox.Enabled = true;
            slkLink_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void slkLsnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.LSN] = false;
            slkLsnSearch_textBox.Text = string.Empty;
            slkLsnSearch_textBox.Enabled = true;
            slkLsn_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void slkSlcClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.SLC] = false;
            slkSlcSearch_textBox.Text = string.Empty;
            slkSlcSearch_textBox.Enabled = true;
            slkSlc_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void slkTypeClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.TYPE] = false;
            slkTypeSearch_textBox.Text = string.Empty;
            slkTypeSearch_textBox.Enabled = true;
            slkType_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void slkAnameClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.ANAME] = false;
            slkAnameSearch_textBox.Text = string.Empty;
            slkAnameSearch_textBox.Enabled = true;
            slkAname_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void slkKtpsClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.SLKTPS] = false;
            slkKtpsSearch_textBox.Text = string.Empty;
            slkKtpsSearch_textBox.Enabled = true;
            slkKtps_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void slkMaxClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.SLK.MAXSLKTPS] = false;
            slkMaxSearch_textBox.Text = string.Empty;
            slkMaxSearch_textBox.Enabled = true;
            slkMax_listBox.SelectedIndex = -1;
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
            Business.Excel.OST.SLK(xlPackage, FilteredData);
        }
        #endregion

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {   
            var gridColumns = from t in FilteredData
                              orderby t.LOC
                              select new
                              {
                                  LOC = t.LOC,
                                  LINK = t.LINK,
                                  LSN = t.LSN,
                                  SLC = t.SLC,
                                  TYPE = t.TYPE,
                                  ANAME = t.ANAME,
                                  SLKTPS = t.SLKTPS,
                                  MAXSLKTPS = t.MAXSLKTPS
                              };

            return gridColumns.ToList();
        }
        #endregion

        #region [ Link Labels ]
        private void slkLoc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(slkLoc_listBox);
        }

        private void slkLink_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(slkLink_listBox);
        }

        private void slkLsn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(slkLsn_listBox);
        }

        private void slkSlc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(slkSlc_listBox);
        }

        private void slkAname_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(slkAname_listBox);
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