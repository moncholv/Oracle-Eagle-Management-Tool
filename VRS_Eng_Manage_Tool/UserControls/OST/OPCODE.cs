using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LinqKit;

using DATA_ENUM = VRS_Eng_Manage_Tool.Data.Enum;
using UTILS = VRS_Eng_Manage_Tool.Business.Utilities;
using System.Drawing;

namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    public partial class OPCODE : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;

        public List<Data.OST.OPCODE_Data> FilteredData { get; set; }
        List<Data.OST.OPCODE_Data> OpcodeData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opcodeInfo"></param>
        public OPCODE(List<Data.OST.OPCODE_Data> opcodeInfo, bool completeData)
        {
            InitializeComponent();
            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            OpcodeData = opcodeInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.OPCODE>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_OPCODE filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                dataList = filterResult.OpCodeInfo.Where(w => w.Table != null).Select(s => s.Table).Distinct().ToList();
                dataList.Sort();
                opTable_listBox.Items.Clear();
                opTable_listBox.Items.AddRange(dataList.ToArray());

                opcode_listBox.Items.Clear();
                dataList = filterResult.OpCodeInfo.Where(w => w.OPCODE != null).Select(s => s.OPCODE).Distinct().ToList();
                dataList.Sort();
                opcode_listBox.Items.AddRange(dataList.ToArray());

                opItu_listBox.Items.Clear();
                dataList = filterResult.OpCodeInfo.Where(w => w.ITUPC != null).Select(s => s.ITUPC).Distinct().ToList();
                dataList.Sort();
                opItu_listBox.Items.AddRange(dataList.ToArray());

                opMrnset_listBox.Items.Clear();
                dataList = filterResult.OpCodeInfo.Where(w => w.MRNSET != null).Select(s => s.MRNSET).Distinct().ToList();
                dataList.Sort();
                opMrnset_listBox.Items.AddRange(dataList.ToArray());

                opLoopset_listBox.Items.Clear();
                dataList = filterResult.OpCodeInfo.Where(w => w.LOOPSET != null).Select(s => s.LOOPSET).Distinct().ToList();
                dataList.Sort();
                opLoopset_listBox.Items.AddRange(dataList.ToArray());

                opOptsn_listBox.Items.Clear();
                dataList = filterResult.OpCodeInfo.Where(w => w.OPTSN != null).Select(s => s.OPTSN).Distinct().ToList();
                dataList.Sort();
                opOptsn_listBox.Items.AddRange(dataList.ToArray());

                opCdselid_listBox.Items.Clear();
                dataList = filterResult.OpCodeInfo.Where(w => w.CDSELID != null).Select(s => s.CDSELID).Distinct().ToList();
                dataList.Sort();
                opCdselid_listBox.Items.AddRange(dataList.ToArray());

                opActsn_listBox.Items.Clear();
                dataList = filterResult.OpCodeInfo.Where(w => w.ACTSN != null).Select(s => s.ACTSN).Distinct().ToList();
                dataList.Sort();
                opActsn_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.OpCodeInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.OPCODE_Data> filteredData)
        {
            FilteredData = filteredData;

            try
            {
                search_dataGridView.DataSource = GetGridColumns();
                search_dataGridView.AutoSizeColumnsMode = CompleteData ? DataGridViewAutoSizeColumnsMode.DisplayedCells : DataGridViewAutoSizeColumnsMode.Fill;
                numRecords_label.Text = filteredData != null ? string.Format("{0} {1}", "Number of records:", filteredData.Count.ToString("#,##0")) : string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion        

        #region [ GetFilteredData ]
        private Data.Predicates.PredicateResult_OPCODE GetFilteredData()
        {
            Data.Predicates.PredicateResult_OPCODE filterResult = new Data.Predicates.PredicateResult_OPCODE();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.OpCodeInfo = OpcodeData.Where(predicate).ToList();
                else
                    filterResult.OpCodeInfo = OpcodeData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ Get Predicate ]
        private ExpressionStarter<Data.OST.OPCODE_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.OPCODE_Data>();

            try
            {
                if (opTable_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.Table != null && w.Table == opTable_listBox.Text);
                else if (!string.IsNullOrEmpty(opTableSearch_textBox.Text))
                {
                    EnableButton(opTableClear_button, true);

                    if (UTILS.StartsWith(opTableSearch_textBox.Text))
                        predicate = predicate.And(w => w.Table != null && w.Table.ToUpper().StartsWith(UTILS.GetStartText(opTableSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.Table != null && w.Table.ToUpper().Contains(opTableSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(opTableClear_button, false);

                if (opcode_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.OPCODE != null && w.OPCODE == opcode_listBox.Text);
                else if (!string.IsNullOrEmpty(opcodeSearch_textBox.Text))
                {
                    EnableButton(opcodeClear_button, true);

                    if (UTILS.StartsWith(opcodeSearch_textBox.Text))
                        predicate = predicate.And(w => w.OPCODE != null && w.OPCODE.ToUpper().StartsWith(UTILS.GetStartText(opcodeSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.OPCODE != null && w.OPCODE.ToUpper().Contains(opcodeSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(opcodeClear_button, false);

                if (opItu_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.ITUPC != null && w.ITUPC == opItu_listBox.Text);
                else if (!string.IsNullOrEmpty(opItuSearch_textBox.Text))
                {
                    EnableButton(opItuClear_button, true);

                    if (UTILS.StartsWith(opItuSearch_textBox.Text))
                        predicate = predicate.And(w => w.ITUPC != null && w.ITUPC.StartsWith(UTILS.GetStartText(opItuSearch_textBox.Text)));
                    else
                        predicate = predicate.And(w => w.ITUPC != null && w.ITUPC.Contains(opItuSearch_textBox.Text));
                }
                else
                    EnableButton(opItuClear_button, false);

                if (opMrnset_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.MRNSET != null && w.MRNSET == opMrnset_listBox.Text);
                else if (!string.IsNullOrEmpty(opMrnsetSearch_textBox.Text))
                {
                    EnableButton(opMrnsetClear_button, true);

                    if (UTILS.StartsWith(opMrnsetSearch_textBox.Text))
                        predicate = predicate.And(w => w.MRNSET != null && w.MRNSET.ToUpper().StartsWith(UTILS.GetStartText(opMrnsetSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.MRNSET != null && w.MRNSET.ToUpper().Contains(opMrnsetSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(opMrnsetClear_button, false);

                if (opLoopset_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LOOPSET != null && w.LOOPSET == opLoopset_listBox.Text);
                else if (!string.IsNullOrEmpty(opLoopsetSearch_textBox.Text))
                {
                    EnableButton(opLoopsetClear_button, true);

                    if (UTILS.StartsWith(opLoopsetSearch_textBox.Text))
                        predicate = predicate.And(w => w.LOOPSET != null && w.LOOPSET.ToUpper().StartsWith(UTILS.GetStartText(opLoopsetSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LOOPSET != null && w.LOOPSET.ToUpper().Contains(opLoopsetSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(opLoopsetClear_button, false);

                if (opOptsn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.OPTSN != null && w.OPTSN == opOptsn_listBox.Text);
                else if (!string.IsNullOrEmpty(opOptsnSearch_textBox.Text))
                {
                    EnableButton(opOptsnClear_button, true);

                    if (UTILS.StartsWith(opOptsnSearch_textBox.Text))
                        predicate = predicate.And(w => w.OPTSN != null && w.OPTSN.ToUpper().StartsWith(UTILS.GetStartText(opOptsnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.OPTSN != null && w.OPTSN.ToUpper().Contains(opOptsnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(opOptsnClear_button, false);

                if (opCdselid_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.CDSELID != null && w.CDSELID == opCdselid_listBox.Text);
                else if (!string.IsNullOrEmpty(opCdselidSearch_textBox.Text))
                {
                    EnableButton(opCdselidClear_button, true);

                    if (UTILS.StartsWith(opCdselidSearch_textBox.Text))
                        predicate = predicate.And(w => w.CDSELID != null && w.CDSELID.ToUpper().StartsWith(UTILS.GetStartText(opCdselidSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.CDSELID != null && w.CDSELID.ToUpper().Contains(opCdselidSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(opCdselidClear_button, false);

                if (opActsn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.ACTSN != null && w.ACTSN == opActsn_listBox.Text);
                else if (!string.IsNullOrEmpty(opActsnSearch_textBox.Text))
                {
                    EnableButton(opActsnClear_button, true);

                    if (UTILS.StartsWith(opActsnSearch_textBox.Text))
                        predicate = predicate.And(w => w.ACTSN != null && w.ACTSN.ToUpper().StartsWith(UTILS.GetStartText(opActsnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.ACTSN != null && w.ACTSN.ToUpper().Contains(opActsnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(opActsnClear_button, false);
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
            Data.Predicates.PredicateResult_OPCODE filterResult = new Data.Predicates.PredicateResult_OPCODE();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.OpCodeInfo = OpcodeData.Where(predicate).ToList();
                else
                    filterResult.OpCodeInfo = OpcodeData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.TABLE])
                {
                    dataList = filterResult.OpCodeInfo.Where(w => w.Table != null).Select(s => s.Table).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = opTable_listBox.SelectedIndex != -1;
                    opTable_listBox.Items.Clear();
                    opTable_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(opTableClear_button, true);
                        opTableSearch_textBox.Enabled = false;
                        opTableSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.TABLE] = true;
                        opTable_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.OPCODE])
                {
                    dataList = filterResult.OpCodeInfo.Where(w => w.OPCODE != null).Select(s => s.OPCODE).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = opcode_listBox.SelectedIndex != -1;
                    opcode_listBox.Items.Clear();
                    opcode_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(opcodeClear_button, true);
                        opcodeSearch_textBox.Enabled = false;
                        opcodeSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.OPCODE] = true;
                        opcode_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.ITUPC])
                {
                    dataList = filterResult.OpCodeInfo.Where(w => w.ITUPC != null).Select(s => s.ITUPC).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = opItu_listBox.SelectedIndex != -1;
                    opItu_listBox.Items.Clear();
                    opItu_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(opItuClear_button, true);
                        opItuSearch_textBox.Enabled = false;
                        opItuSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.ITUPC] = true;
                        opItu_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.MRNSET])
                {
                    dataList = filterResult.OpCodeInfo.Where(w => w.MRNSET != null).Select(s => s.MRNSET).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = opMrnset_listBox.SelectedIndex != -1;
                    opMrnset_listBox.Items.Clear();
                    opMrnset_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(opMrnsetClear_button, true);
                        opMrnsetSearch_textBox.Enabled = false;
                        opMrnsetSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.MRNSET] = true;
                        opMrnset_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.LOOPSET])
                {
                    dataList = filterResult.OpCodeInfo.Where(w => w.LOOPSET != null).Select(s => s.LOOPSET).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = opLoopset_listBox.SelectedIndex != -1;
                    opLoopset_listBox.Items.Clear();
                    opLoopset_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(opLoopsetClear_button, true);
                        opLoopsetSearch_textBox.Enabled = false;
                        opLoopsetSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.LOOPSET] = true;
                        opLoopset_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.OPTSN])
                {
                    dataList = filterResult.OpCodeInfo.Where(w => w.OPTSN != null).Select(s => s.OPTSN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = opOptsn_listBox.SelectedIndex != -1;
                    opOptsn_listBox.Items.Clear();
                    opOptsn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(opOptsnClear_button, true);
                        opOptsnSearch_textBox.Enabled = false;
                        opOptsnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.OPTSN] = true;
                        opOptsn_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.CDSELID])
                {
                    dataList = filterResult.OpCodeInfo.Where(w => w.CDSELID != null).Select(s => s.CDSELID).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = opCdselid_listBox.SelectedIndex != -1;
                    opCdselid_listBox.Items.Clear();
                    opCdselid_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(opCdselidClear_button, true);
                        opCdselidSearch_textBox.Enabled = false;
                        opCdselidSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.CDSELID] = true;
                        opCdselid_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.ACTSN])
                {
                    dataList = filterResult.OpCodeInfo.Where(w => w.ACTSN != null).Select(s => s.ACTSN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = opActsn_listBox.SelectedIndex != -1;
                    opActsn_listBox.Items.Clear();
                    opActsn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(opActsnClear_button, true);
                        opActsnSearch_textBox.Enabled = false;
                        opActsnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.ACTSN] = true;
                        opActsn_listBox.SelectedIndex = 0;
                    }
                }

                LoadFilteredGrid(filterResult.OpCodeInfo);
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
        private void opTableClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.TABLE] = false;
            opTableSearch_textBox.Text = string.Empty;
            opTableSearch_textBox.Enabled = true;
            opTable_listBox.SelectedIndex = -1;
            FilterData();
            //opTableSearch_textBox.Focus();
        }

        private void opcodeClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.OPCODE] = false;
            opcodeSearch_textBox.Text = string.Empty;
            opcodeSearch_textBox.Enabled = true;
            opcode_listBox.SelectedIndex = -1;
            FilterData();
            //opcodeSearch_textBox.Focus();
        }

        private void opItuClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.ITUPC] = false;
            opItuSearch_textBox.Text = string.Empty;
            opItuSearch_textBox.Enabled = true;
            opItu_listBox.SelectedIndex = -1;
            FilterData();
            //opItuSearch_textBox.Focus();
        }

        private void opMrnsetClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.MRNSET] = false;
            opMrnsetSearch_textBox.Text = string.Empty;
            opMrnsetSearch_textBox.Enabled = true;
            opMrnset_listBox.SelectedIndex = -1;
            FilterData();
            //opMrnsetSearch_textBox.Focus();
        }

        private void opLoopsetClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.LOOPSET] = false;
            opLoopsetSearch_textBox.Text = string.Empty;
            opLoopsetSearch_textBox.Enabled = true;
            opLoopset_listBox.SelectedIndex = -1;
            FilterData();
            //opLoopsetSearch_textBox.Focus();
        }

        private void opOptsnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.OPTSN] = false;
            opOptsnSearch_textBox.Text = string.Empty;
            opOptsnSearch_textBox.Enabled = true;
            opOptsn_listBox.SelectedIndex = -1;
            FilterData();
            //opOptsnSearch_textBox.Focus();
        }

        private void opCdselidClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.CDSELID] = false;
            opCdselidSearch_textBox.Text = string.Empty;
            opCdselidSearch_textBox.Enabled = true;
            opCdselid_listBox.SelectedIndex = -1;
            FilterData();
            //opCdselidSearch_textBox.Focus();
        }

        private void opActsnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.OPCODE.ACTSN] = false;
            opActsnSearch_textBox.Text = string.Empty;
            opActsnSearch_textBox.Enabled = true;
            opActsn_listBox.SelectedIndex = -1;
            FilterData();
            //opActsnSearch_textBox.Focus();
        }
        #endregion
        
        #region [ Generate Excel ]
        private void excel_button_Click(object sender, EventArgs e)
        {
            GenerateExcelClicked(null, null);
        }

        public void GenerateExcel(OfficeOpenXml.ExcelPackage xlPackage)
        {
            Business.Excel.OST.OPCODE(xlPackage, FilteredData, CompleteData);
        }
        #endregion

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {
            if (CompleteData)
            {
                var gridColumns = from t in FilteredData
                                  orderby t.Table
                                  select new
                                  {
                                      Table = t.Table,
                                      ACN = t.ACN,
                                      OPCODE = t.OPCODE,
                                      PKGTYPE = t.PKGTYPE,
                                      XLAT = t.XLAT,
                                      RI = t.RI,
                                      ITU_PC = t.ITUPC,
                                      MRNSET = t.MRNSET,
                                      MAPSET = t.MAPSET,
                                      SSN = t.SSN,
                                      CCGT = t.CCGT,
                                      CGGTMOD = t.CGGTMOD,
                                      GTMODID = t.GTMODID,
                                      TESTMODE = t.TESTMODE,
                                      LOOPSET = t.LOOPSET,
                                      FALLBACK = t.FALLBACK,
                                      OPTSN = t.OPTSN,
                                      CDSELID = t.CDSELID,
                                      ACTSN = t.ACTSN
                                  };

                return gridColumns.ToList();
            }
            else
            {
                var gridColumns = from t in FilteredData
                                  orderby t.Table
                                  select new
                                  {
                                      Table = t.Table,
                                      OPCODE = t.OPCODE,
                                      ITU_PC = t.ITUPC,
                                      MRNSET = t.MRNSET,
                                      GTMODID = t.GTMODID,
                                      LOOPSET = t.LOOPSET,
                                      OPTSN = t.OPTSN,
                                      CDSELID = t.CDSELID,
                                      ACTSN = t.ACTSN
                                  };

                return gridColumns.ToList();
            }
        }
        #endregion

        #region [ Link Labels ]
        private void opTable_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(opTable_listBox);
        }

        private void opcode_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(opcode_listBox);
        }

        private void opItupc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(opItu_listBox);
        }

        private void opMrnset_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(opMrnset_listBox);
        }

        private void opLoopset_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(opLoopset_listBox);
        }

        private void opOptsn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(opOptsn_listBox);
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