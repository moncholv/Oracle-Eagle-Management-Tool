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
    public partial class MRNSET : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;
        public List<Data.OST.MRNSET_Data> FilteredData { get; set; }
        List<Data.OST.MRNSET_Data> MrnsetData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opcodeInfo"></param>
        public MRNSET(List<Data.OST.MRNSET_Data> mrnsetInfo, bool completeData)
        {
            InitializeComponent();
            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            MrnsetData = mrnsetInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.MRNSET>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_MRNSET filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                mrnset_listBox.Items.Clear();
                dataList = filterResult.MrnsetInfo.Where(w => w.MRNSET != null).Select(s => s.MRNSET).Distinct().ToList();
                dataList.Sort();
                mrnset_listBox.Items.AddRange(dataList.ToArray());

                mrnsetNet_listBox.Items.Clear();
                dataList = filterResult.MrnsetInfo.Where(w => w.NET != null).Select(s => s.NET).Distinct().ToList();
                dataList.Sort();
                mrnsetNet_listBox.Items.AddRange(dataList.ToArray());

                mrnsetPc_listBox.Items.Clear();
                dataList = filterResult.MrnsetInfo.Where(w => w.PC != null).Select(s => s.PC).Distinct().ToList();
                dataList.Sort();
                mrnsetPc_listBox.Items.AddRange(dataList.ToArray());

                mrnsetRc_listBox.Items.Clear();
                dataList = filterResult.MrnsetInfo.Select(s => s.RC.ToString()).Distinct().ToList();
                dataList.Sort();
                mrnsetRc_listBox.Items.AddRange(dataList.ToArray());

                mrnsetDpc_listBox.Items.Clear();
                dataList = filterResult.MrnsetInfo.Where(w => w.DPC_Decimal != null).Select(s => s.DPC_Decimal).Distinct().ToList();
                dataList.Sort();
                mrnsetDpc_listBox.Items.AddRange(dataList.ToArray());

                mrnsetClli_listBox.Items.Clear();
                dataList = filterResult.MrnsetInfo.Where(w => w.CLLI != null).Select(s => s.CLLI).Distinct().ToList();
                dataList.Sort();
                mrnsetClli_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.MrnsetInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.MRNSET_Data> filteredData)
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
        private Data.Predicates.PredicateResult_MRNSET GetFilteredData()
        {
            Data.Predicates.PredicateResult_MRNSET filterResult = new Data.Predicates.PredicateResult_MRNSET();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.MrnsetInfo = MrnsetData.Where(predicate).ToList();
                else
                    filterResult.MrnsetInfo = MrnsetData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ Get Predicate ]
        private ExpressionStarter<Data.OST.MRNSET_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.MRNSET_Data>();

            try
            {
                if (mrnset_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.MRNSET != null && w.MRNSET == mrnset_listBox.Text);
                else if (!string.IsNullOrEmpty(mrnsetSearch_textBox.Text))
                {
                    EnableButton(mrnsetClear_button, true);

                    if (UTILS.StartsWith(mrnsetSearch_textBox.Text))
                        predicate = predicate.And(w => w.MRNSET != null && w.MRNSET.ToUpper().StartsWith(UTILS.GetStartText(mrnsetSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.MRNSET != null && w.MRNSET.ToUpper().Contains(mrnsetSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(mrnsetClear_button, false);

                if (mrnsetNet_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.NET != null && w.NET == mrnsetNet_listBox.Text);
                else if (!string.IsNullOrEmpty(mrnsetNetSearch_textBox.Text))
                {
                    EnableButton(mrnsetNetClear_button, true);

                    if (UTILS.StartsWith(mrnsetNetSearch_textBox.Text))
                        predicate = predicate.And(w => w.NET != null && w.NET.ToUpper().StartsWith(UTILS.GetStartText(mrnsetNetSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.NET != null && w.NET.ToUpper().Contains(mrnsetNetSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(mrnsetNetClear_button, false);

                if (mrnsetPc_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.PC != null && w.PC == mrnsetPc_listBox.Text);
                else if (!string.IsNullOrEmpty(mrnsetPcSearch_textBox.Text))
                {
                    EnableButton(mrnsetPcClear_button, true);

                    if (UTILS.StartsWith(mrnsetPcSearch_textBox.Text))
                        predicate = predicate.And(w => w.PC != null && w.PC.StartsWith(UTILS.GetStartText(mrnsetPcSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.PC != null && w.PC.Contains(mrnsetPcSearch_textBox.Text));
                }
                else
                    EnableButton(mrnsetPcClear_button, false);

                if (mrnsetDpc_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.DPC_Decimal != null && w.DPC_Decimal == mrnsetDpc_listBox.Text);
                else if (!string.IsNullOrEmpty(mrnsetDpcSearch_textBox.Text))
                {
                    EnableButton(mrnsetDpcClear_button, true);

                    if (UTILS.StartsWith(mrnsetDpcSearch_textBox.Text))
                        predicate = predicate.And(w => w.DPC_Decimal != null && w.DPC_Decimal.StartsWith(UTILS.GetStartText(mrnsetDpcSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.DPC_Decimal != null && w.DPC_Decimal.Contains(mrnsetDpcSearch_textBox.Text));
                }
                else
                    EnableButton(mrnsetDpcClear_button, false);

                if (mrnsetRc_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.RC != null && w.RC == int.Parse(mrnsetRc_listBox.Text));
                else if (!string.IsNullOrEmpty(mrnsetRcSearch_textBox.Text))
                {
                    EnableButton(mrnsetRcClear_button, true);

                    if (UTILS.StartsWith(mrnsetRcSearch_textBox.Text))
                        predicate = predicate.And(w => w.RC.ToString().StartsWith(UTILS.GetStartText(mrnsetRcSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.RC.ToString().Contains(mrnsetRcSearch_textBox.Text));
                }
                else
                    EnableButton(mrnsetRcClear_button, false);

                if (mrnsetClli_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.CLLI != null && w.CLLI == mrnsetClli_listBox.Text);
                else if (!string.IsNullOrEmpty(mrnsetClliSearch_textBox.Text))
                {
                    EnableButton(mrnsetClliClear_button, true);

                    if (UTILS.StartsWith(mrnsetClliSearch_textBox.Text))
                        predicate = predicate.And(w => w.CLLI != null && w.CLLI.ToUpper().StartsWith(UTILS.GetStartText(mrnsetClliSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.CLLI != null && w.CLLI.ToUpper().Contains(mrnsetClliSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(mrnsetClliClear_button, false);
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
            Data.Predicates.PredicateResult_MRNSET filterResult = new Data.Predicates.PredicateResult_MRNSET();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.MrnsetInfo = MrnsetData.Where(predicate).ToList();
                else
                    filterResult.MrnsetInfo = MrnsetData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.MRNSET])
                {
                    dataList = filterResult.MrnsetInfo.Where(w => w.MRNSET != null).Select(s => s.MRNSET).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mrnset_listBox.SelectedIndex != -1;
                    mrnset_listBox.Items.Clear();
                    mrnset_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mrnsetClear_button, true);
                        mrnsetSearch_textBox.Enabled = false;
                        mrnsetSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.MRNSET] = true;
                        mrnset_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.NET])
                {
                    dataList = filterResult.MrnsetInfo.Where(w => w.NET != null).Select(s => s.NET).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mrnsetNet_listBox.SelectedIndex != -1;
                    mrnsetNet_listBox.Items.Clear();
                    mrnsetNet_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mrnsetNetClear_button, true);
                        mrnsetNetSearch_textBox.Enabled = false;
                        mrnsetNetSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.NET] = true;
                        mrnsetNet_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.PC])
                {
                    dataList = filterResult.MrnsetInfo.Where(w => w.PC != null).Select(s => s.PC).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mrnsetPc_listBox.SelectedIndex != -1;
                    mrnsetPc_listBox.Items.Clear();
                    mrnsetPc_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mrnsetPcClear_button, true);
                        mrnsetPcSearch_textBox.Enabled = false;
                        mrnsetPcSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.PC] = true;
                        mrnsetPc_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.RC])
                {
                    dataList = filterResult.MrnsetInfo.Select(s => s.RC.ToString()).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mrnsetRc_listBox.SelectedIndex != -1;
                    mrnsetRc_listBox.Items.Clear();
                    mrnsetRc_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mrnsetRcClear_button, true);
                        mrnsetRcSearch_textBox.Enabled = false;
                        mrnsetRcSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.RC] = true;
                        mrnsetRc_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.DPC_Decimal])
                {
                    dataList = filterResult.MrnsetInfo.Where(w => w.DPC_Decimal != null).Select(s => s.DPC_Decimal).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mrnsetDpc_listBox.SelectedIndex != -1;
                    mrnsetDpc_listBox.Items.Clear();
                    mrnsetDpc_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mrnsetDpcClear_button, true);
                        mrnsetDpcSearch_textBox.Enabled = false;
                        mrnsetDpcSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.DPC_Decimal] = true;
                        mrnsetDpc_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.CLLI])
                {
                    dataList = filterResult.MrnsetInfo.Where(w => w.CLLI != null).Select(s => s.CLLI).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = mrnsetClli_listBox.SelectedIndex != -1;
                    mrnsetClli_listBox.Items.Clear();
                    mrnsetClli_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(mrnsetClliClear_button, true);
                        mrnsetClliSearch_textBox.Enabled = false;
                        mrnsetClliSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.CLLI] = true;
                        mrnsetClli_listBox.SelectedIndex = 0;
                    }
                }                

                LoadFilteredGrid(filterResult.MrnsetInfo);
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
            mrnsetSearch_textBox.Text = string.Empty;
            mrnsetSearch_textBox.Enabled = true;
            mrnset_listBox.SelectedIndex = -1;
            FilterData();
            //opMrnsetSearch_textBox.Focus();
        }

        private void mrnsetNetClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.NET] = false;
            mrnsetNetSearch_textBox.Text = string.Empty;
            mrnsetNetSearch_textBox.Enabled = true;
            mrnsetNet_listBox.SelectedIndex = -1;
            FilterData();
            //opcodeSearch_textBox.Focus();
        }

        private void mrnsetPcClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.PC] = false;
            mrnsetPcSearch_textBox.Text = string.Empty;
            mrnsetPcSearch_textBox.Enabled = true;
            mrnsetPc_listBox.SelectedIndex = -1;
            FilterData();
            //opItuSearch_textBox.Focus();
        }

        private void mrnsetRcClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.RC] = false;
            mrnsetRcSearch_textBox.Text = string.Empty;
            mrnsetRcSearch_textBox.Enabled = true;
            mrnsetRc_listBox.SelectedIndex = -1;
            FilterData();
            //opCdselidSearch_textBox.Focus();
        }

        private void mrnsetDpcClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.DPC_Decimal] = false;
            mrnsetDpcSearch_textBox.Text = string.Empty;
            mrnsetDpcSearch_textBox.Enabled = true;
            mrnsetDpc_listBox.SelectedIndex = -1;
            FilterData();
            //opLoopsetSearch_textBox.Focus();
        }

        private void mrnsetClliClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.MRNSET.CLLI] = false;
            mrnsetClliSearch_textBox.Text = string.Empty;
            mrnsetClliSearch_textBox.Enabled = true;
            mrnsetClli_listBox.SelectedIndex = -1;
            FilterData();
            //opOptsnSearch_textBox.Focus();
        }
        #endregion
        
        #region [ Generate Excel ]
        private void excel_button_Click(object sender, EventArgs e)
        {
            GenerateExcelClicked(null, null);
        }

        public void GenerateExcel(OfficeOpenXml.ExcelPackage xlPackage)
        {
            Business.Excel.OST.MRNSET(xlPackage, FilteredData);
        }
        #endregion

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {   
            var gridColumns = from t in FilteredData
                              orderby t.MRNSET
                              select new
                              {
                                  MRNSET = t.MRNSET,
                                  NET = t.NET,
                                  PC = t.PC,
                                  DPC_Decimal = t.DPC_Decimal,
                                  RC = t.RC,
                                  CLLI = t.CLLI
                              };

            return gridColumns.ToList();
        }
        #endregion

        #region [ Link Labels ]
        private void mrnset_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(mrnset_listBox);
        }

        private void mrnsetPc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(mrnsetPc_listBox);
        }        

        private void mrnsetRc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(mrnsetRc_listBox);
        }

        private void mrnsetDpc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(mrnsetDpc_listBox);
        }

        private void mrnsetClli_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(mrnsetClli_listBox);
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