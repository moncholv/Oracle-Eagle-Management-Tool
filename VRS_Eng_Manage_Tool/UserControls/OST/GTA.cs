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
    public partial class GTA : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;
        public List<Data.OST.GTA_Data> FilteredData { get; set; }
        List<Data.OST.GTA_Data> GtaData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stpsInfo"></param>
        /// <param name="selectedSTP"></param>
        public GTA(List<Data.OST.GTA_Data> gtaInfo, bool completeData)
        {
            InitializeComponent();

            search_dataGridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(search_dataGridView_DataBindingComplete);
            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            GtaData = gtaInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.GTA>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_GTA filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                dataList = filterResult.GtaInfo.Where(w => w.Table != null).Select(s => s.Table).Distinct().ToList();
                dataList.Sort();
                gtaTable_listBox.Items.Clear();
                gtaTable_listBox.Items.AddRange(dataList.ToArray());

                gta_listBox.Items.Clear();
                dataList = filterResult.GtaInfo.Where(w => w.Start_GTA != null).Select(s => s.Start_GTA).Distinct().ToList();
                dataList.Sort();
                gta_listBox.Items.AddRange(dataList.ToArray());

                gtaItu_listBox.Items.Clear();
                dataList = filterResult.GtaInfo.Where(w => w.ITU_PC != null).Select(s => s.ITU_PC).Distinct().ToList();
                dataList.Sort();
                gtaItu_listBox.Items.AddRange(dataList.ToArray());

                gtaMrnset_listBox.Items.Clear();
                dataList = filterResult.GtaInfo.Where(w => w.MRNSET != null).Select(s => s.MRNSET).Distinct().ToList();
                dataList.Sort();
                gtaMrnset_listBox.Items.AddRange(dataList.ToArray());

                gtaMapset_listBox.Items.Clear();
                dataList = filterResult.GtaInfo.Where(w => w.MAPSET != null).Select(s => s.MAPSET).Distinct().ToList();
                dataList.Sort();
                gtaMapset_listBox.Items.AddRange(dataList.ToArray());

                gtaSsn_listBox.Items.Clear();
                dataList = filterResult.GtaInfo.Where(w => w.SSN != null).Select(s => s.SSN).Distinct().ToList();
                dataList.Sort();
                gtaSsn_listBox.Items.AddRange(dataList.ToArray());

                gtaLoopset_listBox.Items.Clear();
                dataList = filterResult.GtaInfo.Where(w => w.LOOPSET != null).Select(s => s.LOOPSET).Distinct().ToList();
                dataList.Sort();
                gtaLoopset_listBox.Items.AddRange(dataList.ToArray());

                gtaOptsn_listBox.Items.Clear();
                dataList = filterResult.GtaInfo.Where(w => w.OPTSN != null).Select(s => s.OPTSN).Distinct().ToList();
                dataList.Sort();
                gtaOptsn_listBox.Items.AddRange(dataList.ToArray());

                gtaCdselid_listBox.Items.Clear();
                dataList = filterResult.GtaInfo.Where(w => w.CDSELID != null).Select(s => s.CDSELID).Distinct().ToList();
                dataList.Sort();
                gtaCdselid_listBox.Items.AddRange(dataList.ToArray());

                gtaActsn_listBox.Items.Clear();
                dataList = filterResult.GtaInfo.Where(w => w.ACTSN != null).Select(s => s.ACTSN).Distinct().ToList();
                dataList.Sort();
                gtaActsn_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.GtaInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.GTA_Data> filteredData = null)
        {
            FilteredData = filteredData;

            try
            {
                search_dataGridView.DataSource = GetGridColumns();
                search_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
        private Data.Predicates.PredicateResult_GTA GetFilteredData()
        {
            Data.Predicates.PredicateResult_GTA filterResult = new Data.Predicates.PredicateResult_GTA();
            var predicate = GetPredicate();            

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.GtaInfo = GtaData.Where(predicate).ToList();
                else
                    filterResult.GtaInfo = GtaData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ GetPredicate ]
        private ExpressionStarter<Data.OST.GTA_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.GTA_Data>();

            try
            {
                if (gtaTable_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.Table != null && w.Table == gtaTable_listBox.Text);
                else if (!string.IsNullOrEmpty(gtaTableSearch_textBox.Text))
                {
                    EnableButton(gtaTableClear_button, true);

                    if (UTILS.StartsWith(gtaTableSearch_textBox.Text))
                        predicate = predicate.And(w => w.Table != null && w.Table.ToUpper().StartsWith(UTILS.GetStartText(gtaTableSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.Table != null && w.Table.ToUpper().Contains(gtaTableSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gtaTableClear_button, false);

                if (gta_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.Start_GTA != null && w.Start_GTA == gta_listBox.Text);
                else if (!string.IsNullOrEmpty(gtaSearch_textBox.Text))
                {
                    EnableButton(gtaClear_button, true);

                    if (UTILS.StartsWith(gtaSearch_textBox.Text))
                        predicate = predicate.And(w => w.Start_GTA != null && w.Start_GTA.ToUpper().StartsWith(UTILS.GetStartText(gtaSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.Start_GTA != null && w.Start_GTA.ToUpper().Contains(gtaSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gtaClear_button, false);

                if (gtaItu_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.ITU_PC != null && w.ITU_PC == gtaItu_listBox.Text);
                else if (!string.IsNullOrEmpty(gtaItuSearch_textBox.Text))
                {
                    EnableButton(gtaItuClear_button, true);

                    if (UTILS.StartsWith(gtaItuSearch_textBox.Text))
                        predicate = predicate.And(w => w.ITU_PC != null && w.ITU_PC.ToUpper().StartsWith(UTILS.GetStartText(gtaItuSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.ITU_PC != null && w.ITU_PC.ToUpper().Contains(gtaItuSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gtaItuClear_button, false);

                if (gtaMrnset_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.MRNSET != null && w.MRNSET == gtaMrnset_listBox.Text);
                else if (!string.IsNullOrEmpty(gtaMrnsetSearch_textBox.Text))
                {
                    EnableButton(gtaMrnsetClear_button, true);

                    if (UTILS.StartsWith(gtaMrnsetSearch_textBox.Text))
                        predicate = predicate.And(w => w.MRNSET != null && w.MRNSET.ToUpper().StartsWith(UTILS.GetStartText(gtaMrnsetSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.MRNSET != null && w.MRNSET.ToUpper().Contains(gtaMrnsetSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gtaMrnsetClear_button, false);

                if (gtaMapset_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.MAPSET != null && w.MAPSET == gtaMapset_listBox.Text);
                else if (!string.IsNullOrEmpty(gtaMapsetSearch_textBox.Text))
                {
                    EnableButton(gtaMapsetClear_button, true);

                    if (UTILS.StartsWith(gtaMapsetSearch_textBox.Text))
                        predicate = predicate.And(w => w.MAPSET != null && w.MAPSET.ToUpper().StartsWith(UTILS.GetStartText(gtaMapsetSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.MAPSET != null && w.MAPSET.ToUpper().Contains(gtaMapsetSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gtaMapsetClear_button, false);

                if (gtaSsn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.SSN != null && w.SSN == gtaSsn_listBox.Text);
                else if (!string.IsNullOrEmpty(gtaSsnSearch_textBox.Text))
                {
                    EnableButton(gtaSsnClear_button, true);

                    if (UTILS.StartsWith(gtaSsnSearch_textBox.Text))
                        predicate = predicate.And(w => w.SSN != null && w.SSN.ToUpper().StartsWith(UTILS.GetStartText(gtaSsnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.SSN != null && w.SSN.ToUpper().Contains(gtaSsnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gtaSsnClear_button, false);

                if (gtaLoopset_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LOOPSET != null && w.LOOPSET == gtaLoopset_listBox.Text);
                else if (!string.IsNullOrEmpty(gtaLoopsetSearch_textBox.Text))
                {
                    EnableButton(gtaLoopsetClear_Clear_button, true);

                    if (UTILS.StartsWith(gtaLoopsetSearch_textBox.Text))
                        predicate = predicate.And(w => w.LOOPSET != null && w.LOOPSET.ToUpper().StartsWith(UTILS.GetStartText(gtaLoopsetSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LOOPSET != null && w.LOOPSET.ToUpper().Contains(gtaLoopsetSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gtaLoopsetClear_Clear_button, false);

                if (gtaOptsn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.OPTSN != null && w.OPTSN == gtaOptsn_listBox.Text);
                else if (!string.IsNullOrEmpty(gtaOptsnSearch_textBox.Text))
                {
                    EnableButton(gtaOptsnClear_button, true);

                    if (UTILS.StartsWith(gtaOptsnSearch_textBox.Text))
                        predicate = predicate.And(w => w.OPTSN != null && w.OPTSN.ToUpper().StartsWith(UTILS.GetStartText(gtaOptsnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.OPTSN != null && w.OPTSN.ToUpper().Contains(gtaOptsnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gtaOptsnClear_button, false);

                if (gtaCdselid_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.CDSELID != null && w.CDSELID == gtaCdselid_listBox.Text);
                else if (!string.IsNullOrEmpty(gtaCdselidSearch_textBox.Text))
                {
                    EnableButton(gtaCdselidClear_button, true);

                    if (UTILS.StartsWith(gtaCdselidSearch_textBox.Text))
                        predicate = predicate.And(w => w.CDSELID != null && w.CDSELID.ToUpper().StartsWith(UTILS.GetStartText(gtaCdselidSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.CDSELID != null && w.CDSELID.ToUpper().Contains(gtaCdselidSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gtaCdselidClear_button, false);

                if (gtaActsn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.ACTSN != null && w.ACTSN == gtaActsn_listBox.Text);
                else if (!string.IsNullOrEmpty(gtaActsnSearch_textBox.Text))
                {
                    EnableButton(gtaActsnClear_button, true);

                    if (UTILS.StartsWith(gtaActsnSearch_textBox.Text))
                        predicate = predicate.And(w => w.ACTSN != null && w.ACTSN.ToUpper().StartsWith(UTILS.GetStartText(gtaActsnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.ACTSN != null && w.ACTSN.ToUpper().Contains(gtaActsnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gtaActsnClear_button, false);
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
            Data.Predicates.PredicateResult_GTA filterResult = new Data.Predicates.PredicateResult_GTA();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.GtaInfo = GtaData.Where(predicate).ToList();
                else
                    filterResult.GtaInfo = GtaData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.TABLE])
                {
                    dataList = filterResult.GtaInfo.Where(w => w.Table != null).Select(s => s.Table).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gtaTable_listBox.SelectedIndex != -1;
                    gtaTable_listBox.Items.Clear();
                    gtaTable_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gtaTableClear_button, true);
                        gtaTableSearch_textBox.Enabled = false;
                        gtaTableSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.TABLE] = true;
                        gtaTable_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.GTA])
                {
                    dataList = filterResult.GtaInfo.Where(w => w.Start_GTA != null).Select(s => s.Start_GTA).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gta_listBox.SelectedIndex != -1;
                    gta_listBox.Items.Clear();
                    gta_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gtaClear_button, true);
                        gtaSearch_textBox.Enabled = false;
                        gtaSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.GTA] = true;
                        gta_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.ITUPC])
                {
                    dataList = filterResult.GtaInfo.Where(w => w.ITU_PC != null).Select(s => s.ITU_PC).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gtaItu_listBox.SelectedIndex != -1;
                    gtaItu_listBox.Items.Clear();
                    gtaItu_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gtaItuClear_button, true);
                        gtaItuSearch_textBox.Enabled = false;
                        gtaItuSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.ITUPC] = true;
                        gtaItu_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.MRNSET])
                {
                    dataList = filterResult.GtaInfo.Where(w => w.MRNSET != null).Select(s => s.MRNSET).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gtaMrnset_listBox.SelectedIndex != -1;
                    gtaMrnset_listBox.Items.Clear();
                    gtaMrnset_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gtaMrnsetClear_button, true);
                        gtaMrnsetSearch_textBox.Enabled = false;
                        gtaMrnsetSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.MRNSET] = true;
                        gtaMrnset_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.MAPSET])
                {
                    dataList = filterResult.GtaInfo.Where(w => w.MAPSET != null).Select(s => s.MAPSET).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gtaMapset_listBox.SelectedIndex != -1;
                    gtaMapset_listBox.Items.Clear();
                    gtaMapset_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gtaMapsetClear_button, true);
                        gtaMapsetSearch_textBox.Enabled = false;
                        gtaMapsetSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.MAPSET] = true;
                        gtaMapset_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.SSN])
                {
                    dataList = filterResult.GtaInfo.Where(w => w.SSN != null).Select(s => s.SSN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gtaSsn_listBox.SelectedIndex != -1;
                    gtaSsn_listBox.Items.Clear();
                    gtaSsn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gtaSsnClear_button, true);
                        gtaSsnSearch_textBox.Enabled = false;
                        gtaSsnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.SSN] = true;
                        gtaSsn_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.LOOPSET])
                {
                    dataList = filterResult.GtaInfo.Where(w => w.LOOPSET != null).Select(s => s.LOOPSET).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gtaLoopset_listBox.SelectedIndex != -1;
                    gtaLoopset_listBox.Items.Clear();
                    gtaLoopset_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gtaLoopsetClear_Clear_button, true);
                        gtaLoopsetSearch_textBox.Enabled = false;
                        gtaLoopsetSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.LOOPSET] = true;
                        gtaLoopset_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.OPTSN])
                {
                    dataList = filterResult.GtaInfo.Where(w => w.OPTSN != null).Select(s => s.OPTSN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gtaOptsn_listBox.SelectedIndex != -1;
                    gtaOptsn_listBox.Items.Clear();
                    gtaOptsn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gtaOptsnClear_button, true);
                        gtaOptsnSearch_textBox.Enabled = false;
                        gtaOptsnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.OPTSN] = true;
                        gtaOptsn_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.CDSELID])
                {
                    dataList = filterResult.GtaInfo.Where(w => w.CDSELID != null).Select(s => s.CDSELID).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gtaCdselid_listBox.SelectedIndex != -1;
                    gtaCdselid_listBox.Items.Clear();
                    gtaCdselid_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gtaCdselidClear_button, true);
                        gtaCdselidSearch_textBox.Enabled = false;
                        gtaCdselidSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.CDSELID] = true;
                        gtaCdselid_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.ACTSN])
                {
                    dataList = filterResult.GtaInfo.Where(w => w.ACTSN != null).Select(s => s.ACTSN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gtaActsn_listBox.SelectedIndex != -1;
                    gtaActsn_listBox.Items.Clear();
                    gtaActsn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gtaActsnClear_button, true);
                        gtaActsnSearch_textBox.Enabled = false;
                        gtaActsnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.ACTSN] = true;
                        gtaActsn_listBox.SelectedIndex = 0;
                    }
                }

                LoadFilteredGrid(filterResult.GtaInfo);
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
        private void gtaTableClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.TABLE] = false;
            gtaTableSearch_textBox.Text = string.Empty;
            gtaTableSearch_textBox.Enabled = true;
            gtaTable_listBox.SelectedIndex = -1;
            FilterData();
            gtaTableSearch_textBox.Focus();
        }

        private void gtaClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.GTA] = false;
            gtaSearch_textBox.Text = string.Empty;
            gtaSearch_textBox.Enabled = true;
            gta_listBox.SelectedIndex = -1;
            FilterData();
            gtaSearch_textBox.Focus();
        }

        private void gtaItuClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.ITUPC] = false;
            gtaItuSearch_textBox.Text = string.Empty;
            gtaItuSearch_textBox.Enabled = true;
            gtaItu_listBox.SelectedIndex = -1;
            FilterData();
            gtaItuSearch_textBox.Focus();
        }

        private void gtaMrnsetClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.MRNSET] = false;
            gtaMrnsetSearch_textBox.Text = string.Empty;
            gtaMrnsetSearch_textBox.Enabled = true;
            gtaMrnset_listBox.SelectedIndex = -1;
            FilterData();
            gtaMrnsetSearch_textBox.Focus();
        }

        private void gtaMapsetClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.MAPSET] = false;
            gtaMapsetSearch_textBox.Text = string.Empty;
            gtaMapsetSearch_textBox.Enabled = true;
            gtaMapset_listBox.SelectedIndex = -1;
            FilterData();
            gtaMapsetSearch_textBox.Focus();
        }

        private void gtaSsnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.SSN] = false;
            gtaSsnSearch_textBox.Text = string.Empty;
            gtaSsnSearch_textBox.Enabled = true;
            gtaSsn_listBox.SelectedIndex = -1;
            FilterData();
            gtaSsnSearch_textBox.Focus();
        }

        private void gtaLoopsetClear_Clear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.LOOPSET] = false;
            gtaLoopsetSearch_textBox.Text = string.Empty;
            gtaLoopsetSearch_textBox.Enabled = true;
            gtaLoopset_listBox.SelectedIndex = -1;
            FilterData();
            gtaLoopsetSearch_textBox.Focus();
        }

        private void gtaOptsnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.OPTSN] = false;
            gtaOptsnSearch_textBox.Text = string.Empty;
            gtaOptsnSearch_textBox.Enabled = true;
            gtaOptsn_listBox.SelectedIndex = -1;
            FilterData();
            gtaOptsnSearch_textBox.Focus();
        }

        private void gtaCdselidClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.CDSELID] = false;
            gtaCdselidSearch_textBox.Text = string.Empty;
            gtaCdselidSearch_textBox.Enabled = true;
            gtaCdselid_listBox.SelectedIndex = -1;
            FilterData();
            gtaCdselidSearch_textBox.Focus();
        }

        private void gtaActsnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTA.ACTSN] = false;
            gtaActsnSearch_textBox.Text = string.Empty;
            gtaActsnSearch_textBox.Enabled = true;
            gtaActsn_listBox.SelectedIndex = -1;
            FilterData();
            gtaActsnSearch_textBox.Focus();
        }
        #endregion
        
        #region [ Generate Excel ]
        private void excel_button_Click(object sender, EventArgs e)
        {
            GenerateExcelClicked(null, null);
        }

        public void GenerateExcel(OfficeOpenXml.ExcelPackage xlPackage)
        {
            Business.Excel.OST.GTA(xlPackage, FilteredData, CompleteData);
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
                                      Start_GTA = t.Start_GTA,
                                      End_GTA = t.End_GTA,
                                      XLAT = t.XLAT,
                                      RI = t.RI,
                                      ITU_PC = t.ITU_PC,
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
                                      Start_GTA = t.Start_GTA,
                                      End_GTA = t.End_GTA,
                                      XLAT = t.XLAT,
                                      RI = t.RI,
                                      ITU_PC = t.ITU_PC,
                                      MRNSET = t.MRNSET,
                                      MAPSET = t.MAPSET,
                                      SSN = t.SSN,
                                      GTMODID = t.GTMODID,
                                      LOOPSET = t.LOOPSET,
                                      FALLBACK = t.FALLBACK,
                                      OPTSN = t.OPTSN,
                                      CDSELID = t.CDSELID,
                                      ACTSN = t.ACTSN
                                  };

                return gridColumns.ToList();
            }
        }
        #endregion

        #region [ Link Labels ]
        private void gtaTable_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gtaTable_listBox);
        }

        private void gta_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gta_listBox);
        }

        private void gtaItupc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gtaItu_listBox);
        }

        private void gtaMrnset_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gtaMrnset_listBox);
        }

        private void gtaMapset_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gtaMapset_listBox);
        }

        private void gtaSsn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gtaSsn_listBox);
        }

        private void gtaLoopset_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gtaLoopset_listBox);
        }

        private void gtaOptsn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gtaOptsn_listBox);
        }

        private void gtaActsn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gtaActsn_listBox);
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
            SetGridStyle(search_dataGridView);
            search_dataGridView.ClearSelection();
        }
        #endregion

        //public void SetGridStyle(DataGridView dgView)
        //{
        //    for (int i = 0; i < dgView.ColumnCount; i++)
        //    {
        //        dgView.Columns[i].HeaderCell.Style.BackColor = Color.FromArgb(200, 6, 27);
        //        dgView.Columns[i].HeaderCell.Style.ForeColor = Color.White;
        //        dgView.Columns[i].HeaderCell.Style.Font = new Font("Tahoma", 7.25F, FontStyle.Bold);
        //    }
        //}
    }
}