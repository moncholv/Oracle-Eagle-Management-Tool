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
    public partial class GTTSEL : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;
        public List<Data.OST.GTTSEL_Data> FilteredData { get; set; }
        List<Data.OST.GTTSEL_Data> GttselData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opcodeInfo"></param>
        public GTTSEL(List<Data.OST.GTTSEL_Data> gttselInfo, bool completeData)
        {
            InitializeComponent();
            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            GttselData = gttselInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.GTTSEL>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_GTTSEL filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                dataList = filterResult.GttselInfo.Where(w => w.MSGTYPE != null).Select(s => s.MSGTYPE).Distinct().ToList();
                dataList.Sort();
                gttselMsgType_listBox.Items.Clear();
                gttselMsgType_listBox.Items.AddRange(dataList.ToArray());

                dataList = filterResult.GttselInfo.Where(w => w.TT != null).Select(s => s.TT).Distinct().ToList();
                dataList.Sort();
                gttselTt_listBox.Items.Clear();
                gttselTt_listBox.Items.AddRange(dataList.ToArray());

                dataList = filterResult.GttselInfo.Where(w => w.INT != null).Select(s => s.INT).Distinct().ToList();
                dataList.Sort();
                gttselInt_listBox.Items.Clear();
                gttselInt_listBox.Items.AddRange(dataList.ToArray());

                gttselNp_listBox.Items.Clear();
                dataList = filterResult.GttselInfo.Where(w => w.NP != null).Select(s => s.NP).Distinct().ToList();
                dataList.Sort();
                gttselNp_listBox.Items.AddRange(dataList.ToArray());

                gttselNai_listBox.Items.Clear();
                dataList = filterResult.GttselInfo.Where(w => w.NAI != null).Select(s => s.NAI).Distinct().ToList();
                dataList.Sort();
                gttselNai_listBox.Items.AddRange(dataList.ToArray());

                dataList = filterResult.GttselInfo.Where(w => w.NATS != null).Select(s => s.NATS).Distinct().ToList();
                dataList.Sort();
                gttselNats_listBox.Items.Clear();
                gttselNats_listBox.Items.AddRange(dataList.ToArray());

                gttselSelid_listBox.Items.Clear();
                dataList = filterResult.GttselInfo.Where(w => w.SELID != null).Select(s => s.SELID).Distinct().ToList();
                dataList.Sort();
                gttselSelid_listBox.Items.AddRange(dataList.ToArray());

                gttselLsn_listBox.Items.Clear();
                dataList = filterResult.GttselInfo.Where(w => w.LSN != null).Select(s => s.LSN).Distinct().ToList();
                dataList.Sort();
                gttselLsn_listBox.Items.AddRange(dataList.ToArray());

                gttselCdpa_listBox.Items.Clear();
                dataList = filterResult.GttselInfo.Where(w => w.CDPA_GTTSET != null).Select(s => s.CDPA_GTTSET).Distinct().ToList();
                dataList.Sort();
                gttselCdpa_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.GttselInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.GTTSEL_Data> filteredData)
        {
            FilteredData = filteredData;

            try
            {
                //search_dataGridView.Width = CompleteData ? 870 : 711;
                search_dataGridView.DataSource = GetGridColumns();
                search_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                numRecords_label.Text = filteredData != null ? string.Format("{0} {1}", "Number of records:", filteredData.Count.ToString("#,##0")) : string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion        

        #region [ GetFilteredData ]
        private Data.Predicates.PredicateResult_GTTSEL GetFilteredData()
        {
            Data.Predicates.PredicateResult_GTTSEL filterResult = new Data.Predicates.PredicateResult_GTTSEL();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.GttselInfo = GttselData.Where(predicate).ToList();
                else
                    filterResult.GttselInfo = GttselData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ Get Predicate ]
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ExpressionStarter<Data.OST.GTTSEL_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.GTTSEL_Data>();

            try
            {
                if (gttselMsgType_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.MSGTYPE != null && w.MSGTYPE == gttselMsgType_listBox.Text);
                else if (!string.IsNullOrEmpty(gttselMsgTypeSearch_textBox.Text))
                {
                    EnableButton(gttselMsgTypeClear_button, true);

                    if (UTILS.StartsWith(gttselMsgTypeSearch_textBox.Text))
                        predicate = predicate.And(w => w.MSGTYPE != null && w.MSGTYPE.ToUpper().StartsWith(UTILS.GetStartText(gttselMsgTypeSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.MSGTYPE != null && w.MSGTYPE.ToUpper().Contains(gttselMsgTypeSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttselMsgTypeClear_button, false);

                if (gttselTt_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.TT != null && w.TT == gttselTt_listBox.Text);
                else if (!string.IsNullOrEmpty(gttselTtSearch_textBox.Text))
                {
                    EnableButton(gttselTtClear_button, true);

                    if (UTILS.StartsWith(gttselTtSearch_textBox.Text))
                        predicate = predicate.And(w => w.TT != null && w.TT.ToUpper().StartsWith(UTILS.GetStartText(gttselTtSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.TT != null && w.TT.ToUpper().Contains(gttselTtSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttselTtClear_button, false);

                if (gttselInt_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.INT != null && w.INT == gttselInt_listBox.Text);
                else if (!string.IsNullOrEmpty(gttselIntSearch_textBox.Text))
                {
                    EnableButton(gttselIntClear_button, true);

                    if (UTILS.StartsWith(gttselIntSearch_textBox.Text))
                        predicate = predicate.And(w => w.INT != null && w.INT.ToUpper().StartsWith(UTILS.GetStartText(gttselIntSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.INT != null && w.INT.ToUpper().Contains(gttselIntSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttselIntClear_button, false);

                if (gttselNp_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.NP != null && w.NP == gttselNp_listBox.Text);
                else if (!string.IsNullOrEmpty(gttselNpSearch_textBox.Text))
                {
                    EnableButton(gttselNpClear_button, true);

                    if (UTILS.StartsWith(gttselNpSearch_textBox.Text))
                        predicate = predicate.And(w => w.NP != null && w.NP.ToUpper().StartsWith(UTILS.GetStartText(gttselNpSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.NP != null && w.NP.ToUpper().Contains(gttselNpSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttselNpClear_button, false);

                if (gttselNai_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.NAI != null && w.NAI == gttselNai_listBox.Text);
                else if (!string.IsNullOrEmpty(gttselNaiSearch_textBox.Text))
                {
                    EnableButton(gttselNaiClear_button, true);

                    if (UTILS.StartsWith(gttselNaiSearch_textBox.Text))
                        predicate = predicate.And(w => w.NAI != null && w.NAI.ToUpper().StartsWith(UTILS.GetStartText(gttselNaiSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.NAI != null && w.NAI.ToUpper().Contains(gttselNaiSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttselNaiClear_button, false);

                if (gttselNats_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.NATS != null && w.NATS == gttselNats_listBox.Text);
                else if (!string.IsNullOrEmpty(gttselNatsSearch_textBox.Text))
                {
                    EnableButton(gttselNatsClear_button, true);

                    if (UTILS.StartsWith(gttselNatsSearch_textBox.Text))
                        predicate = predicate.And(w => w.NATS != null && w.NATS.ToUpper().StartsWith(UTILS.GetStartText(gttselNatsSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.NATS != null && w.NATS.ToUpper().Contains(gttselNatsSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttselNatsClear_button, false);

                if (gttselSelid_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.SELID != null && w.SELID == gttselSelid_listBox.Text);
                else if (!string.IsNullOrEmpty(gttselSelidSearch_textBox.Text))
                {
                    EnableButton(gttselSelidClear_button, true);

                    if (UTILS.StartsWith(gttselSelidSearch_textBox.Text))
                        predicate = predicate.And(w => w.SELID != null && w.SELID.ToUpper().StartsWith(UTILS.GetStartText(gttselSelidSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.SELID != null && w.SELID.ToUpper().Contains(gttselSelidSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttselSelidClear_button, false);

                if (gttselLsn_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LSN != null && w.LSN == gttselLsn_listBox.Text);
                else if (!string.IsNullOrEmpty(gttselLsnSearch_textBox.Text))
                {
                    EnableButton(gttselLsnClear_button, true);

                    if (UTILS.StartsWith(gttselLsnSearch_textBox.Text))
                        predicate = predicate.And(w => w.LSN != null && w.LSN.ToUpper().StartsWith(UTILS.GetStartText(gttselLsnSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LSN != null && w.LSN.ToUpper().Contains(gttselLsnSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttselLsnClear_button, false);

                if (gttselCdpa_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.CDPA_GTTSET != null && w.CDPA_GTTSET == gttselCdpa_listBox.Text);
                else if (!string.IsNullOrEmpty(gttselCdpaSearch_textBox.Text))
                {
                    EnableButton(gttselCdpaClear_button, true);

                    if (UTILS.StartsWith(gttselCdpaSearch_textBox.Text))
                        predicate = predicate.And(w => w.CDPA_GTTSET != null && w.CDPA_GTTSET.ToUpper().StartsWith(UTILS.GetStartText(gttselCdpaSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.CDPA_GTTSET != null && w.CDPA_GTTSET.ToUpper().Contains(gttselCdpaSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(gttselCdpaClear_button, false);
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
            Data.Predicates.PredicateResult_GTTSEL filterResult = new Data.Predicates.PredicateResult_GTTSEL();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.GttselInfo = GttselData.Where(predicate).ToList();
                else
                    filterResult.GttselInfo = GttselData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.MSGTYPE])
                {
                    dataList = filterResult.GttselInfo.Where(w => w.MSGTYPE != null).Select(s => s.MSGTYPE).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttselMsgType_listBox.SelectedIndex != -1;
                    gttselMsgType_listBox.Items.Clear();
                    gttselMsgType_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttselMsgTypeClear_button, true);
                        gttselMsgTypeSearch_textBox.Enabled = false;
                        gttselMsgTypeSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.MSGTYPE] = true;
                        gttselMsgType_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.TT])
                {
                    dataList = filterResult.GttselInfo.Where(w => w.TT != null).Select(s => s.TT).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttselTt_listBox.SelectedIndex != -1;
                    gttselTt_listBox.Items.Clear();
                    gttselTt_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttselTtClear_button, true);
                        gttselTtSearch_textBox.Enabled = false;
                        gttselTtSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.TT] = true;
                        gttselTt_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.INT])
                {
                    dataList = filterResult.GttselInfo.Where(w => w.INT != null).Select(s => s.INT).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttselInt_listBox.SelectedIndex != -1;
                    gttselInt_listBox.Items.Clear();
                    gttselInt_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttselIntClear_button, true);
                        gttselIntSearch_textBox.Enabled = false;
                        gttselIntSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.INT] = true;
                        gttselInt_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.NP])
                {
                    dataList = filterResult.GttselInfo.Where(w => w.NP != null).Select(s => s.NP).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttselNp_listBox.SelectedIndex != -1;
                    gttselNp_listBox.Items.Clear();
                    gttselNp_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttselNpClear_button, true);
                        gttselNpSearch_textBox.Enabled = false;
                        gttselNpSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.NP] = true;
                        gttselNp_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.NAI])
                {
                    dataList = filterResult.GttselInfo.Where(w => w.NAI != null).Select(s => s.NAI).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttselNai_listBox.SelectedIndex != -1;
                    gttselNai_listBox.Items.Clear();
                    gttselNai_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttselNaiClear_button, true);
                        gttselNaiSearch_textBox.Enabled = false;
                        gttselNaiSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.NAI] = true;
                        gttselNai_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.NATS])
                {
                    dataList = filterResult.GttselInfo.Where(w => w.NATS != null).Select(s => s.NATS).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttselNats_listBox.SelectedIndex != -1;
                    gttselNats_listBox.Items.Clear();
                    gttselNats_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttselNatsClear_button, true);
                        gttselNatsSearch_textBox.Enabled = false;
                        gttselNatsSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.NATS] = true;
                        gttselNats_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.SELID])
                {
                    dataList = filterResult.GttselInfo.Where(w => w.SELID != null).Select(s => s.SELID).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttselSelid_listBox.SelectedIndex != -1;
                    gttselSelid_listBox.Items.Clear();
                    gttselSelid_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttselSelidClear_button, true);
                        gttselSelidSearch_textBox.Enabled = false;
                        gttselSelidSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.SELID] = true;
                        gttselSelid_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.LSN])
                {
                    dataList = filterResult.GttselInfo.Where(w => w.LSN != null).Select(s => s.LSN).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttselLsn_listBox.SelectedIndex != -1;
                    gttselLsn_listBox.Items.Clear();
                    gttselLsn_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttselLsnClear_button, true);
                        gttselLsnSearch_textBox.Enabled = false;
                        gttselLsnSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.LSN] = true;
                        gttselLsn_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.CDPA_GTTSET])
                {
                    dataList = filterResult.GttselInfo.Where(w => w.CDPA_GTTSET != null).Select(s => s.CDPA_GTTSET).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = gttselCdpa_listBox.SelectedIndex != -1;
                    gttselCdpa_listBox.Items.Clear();
                    gttselCdpa_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(gttselCdpaClear_button, true);
                        gttselCdpaSearch_textBox.Enabled = false;
                        gttselCdpaSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.CDPA_GTTSET] = true;
                        gttselCdpa_listBox.SelectedIndex = 0;
                    }
                }

                LoadFilteredGrid(filterResult.GttselInfo);
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
        private void gttselMsgTypeClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.MSGTYPE] = false;
            gttselMsgTypeSearch_textBox.Text = string.Empty;
            gttselMsgTypeSearch_textBox.Enabled = true;
            gttselMsgType_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void gttselTtClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.TT] = false;
            gttselTtSearch_textBox.Text = string.Empty;
            gttselTtSearch_textBox.Enabled = true;
            gttselTt_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void gttselIntClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.INT] = false;
            gttselIntSearch_textBox.Text = string.Empty;
            gttselIntSearch_textBox.Enabled = true;
            gttselInt_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void gttselNpClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.NP] = false;
            gttselNpSearch_textBox.Text = string.Empty;
            gttselNpSearch_textBox.Enabled = true;
            gttselNp_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void gttselNaiClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.NAI] = false;
            gttselNaiSearch_textBox.Text = string.Empty;
            gttselNaiSearch_textBox.Enabled = true;
            gttselNai_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void gttselNatsClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.NATS] = false;
            gttselNatsSearch_textBox.Text = string.Empty;
            gttselNatsSearch_textBox.Enabled = true;
            gttselNats_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void gttselSelidClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.SELID] = false;
            gttselSelidSearch_textBox.Text = string.Empty;
            gttselSelidSearch_textBox.Enabled = true;
            gttselSelid_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void gttselLsnClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.LSN] = false;
            gttselLsnSearch_textBox.Text = string.Empty;
            gttselLsnSearch_textBox.Enabled = true;
            gttselLsn_listBox.SelectedIndex = -1;
            FilterData();
        }

        private void gttselCdpaClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.GTTSEL.CDPA_GTTSET] = false;
            gttselCdpaSearch_textBox.Text = string.Empty;
            gttselCdpaSearch_textBox.Enabled = true;
            gttselCdpa_listBox.SelectedIndex = -1;
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
            Business.Excel.OST.GTTSEL(xlPackage, FilteredData);
        }
        #endregion

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {
            if (CompleteData)
            {
                var gridColumns = from t in FilteredData
                                  orderby t.TT
                                  select new
                                  {
                                      MSGTYPE = t.MSGTYPE,
                                      ANSI = t.ANSI,
                                      INT = t.INT,
                                      NAT = t.NAT,
                                      N24 = t.N24,
                                      INTS = t.INTS,
                                      NATS = t.NATS,
                                      TT = t.TT,
                                      NP = t.NP,
                                      NAI = t.NAI,
                                      SSN = t.SSN,
                                      SELID = t.SELID,
                                      LSN = t.LSN,
                                      CDPA_GTTSET = t.CDPA_GTTSET,
                                      CGPA_GTTSET = t.CGPA_GTTSET                                      
                                  };

                return gridColumns.ToList();
            }
            else
            {
                var gridColumns = from t in FilteredData
                                  orderby t.TT
                                  select new
                                  {
                                      MSGTYPE = t.MSGTYPE,
                                      INT = t.INT,
                                      NAT = t.NAT,
                                      ANSI = t.ANSI,
                                      N24 = t.N24,
                                      INTS = t.INTS,
                                      NATS = t.NATS,
                                      TT = t.TT,
                                      NP = t.NP,
                                      NAI = t.NAI,
                                      SELID = t.SELID,
                                      LSN = t.LSN,
                                      CDPA_GTTSET = t.CDPA_GTTSET
                                  };

                return gridColumns.ToList();
            }
        }
        #endregion

        #region [ Link Labels ]
        private void gttselMsgType_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttselMsgType_listBox);
        }

        private void gttselTt_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttselTt_listBox);
        }

        private void gttselNp_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttselNp_listBox);
        }

        private void gttselNai_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttselNai_listBox);
        }

        private void gttselLsn_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttselLsn_listBox);
        }

        private void gttselCdpa_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttselCdpa_listBox);
        }

        private void gttselInt_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttselInt_listBox);
        }

        private void gttselNats_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(gttselNats_listBox);
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