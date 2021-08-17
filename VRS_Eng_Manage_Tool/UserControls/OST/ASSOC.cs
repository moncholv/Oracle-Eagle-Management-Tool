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
    public partial class ASSOC : Base.UserControlBase
    {
        public event EventHandler ClearAllPerformed;
        public event EventHandler ClearAllClicked;
        public event EventHandler ShowMessageRaised;
        public event EventHandler GenerateExcelClicked;
        public List<Data.OST.ASSOC_Data> FilteredData { get; set; }
        List<Data.OST.ASSOC_Data> AssocData { get; set; }

        #region [ Constructor ]
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stpsInfo"></param>
        /// <param name="selectedSTP"></param>
        public ASSOC(List<Data.OST.ASSOC_Data> assocInfo, bool completeData)
        {
            InitializeComponent();
            search_dataGridView.EnableHeadersVisualStyles = false;

            ButtonEnabled = Properties.Resources.clear_button;
            ButtonDisabled = Properties.Resources.clear_button_disabled;

            AssocData = assocInfo;
            CompleteData = completeData;

            FilterInfo();
            InitItemSelected<DATA_ENUM.ItemsSelected.ASSOC>();
        }
        #endregion

        #region [ FilterInfo ]
        private void FilterInfo()
        {
            Data.Predicates.PredicateResult_ASSOC filterResult = null;
            List<string> dataList = null;

            try
            {
                filterResult = GetFilteredData();

                dataList = filterResult.AssocInfo.Where(w => w.ANAME != null).Select(s => s.ANAME).Distinct().ToList();
                dataList.Sort();
                assocAname_listBox.Items.Clear();
                assocAname_listBox.Items.AddRange(dataList.ToArray());

                assocLoc_listBox.Items.Clear();
                dataList = filterResult.AssocInfo.Where(w => w.LOC != null).Select(s => s.LOC).Distinct().ToList();
                dataList.Sort();
                assocLoc_listBox.Items.AddRange(dataList.ToArray());

                assocPort_listBox.Items.Clear();
                dataList = filterResult.AssocInfo.Where(w => w.PORT != null).Select(s => s.PORT).Distinct().ToList();
                dataList.Sort();
                assocPort_listBox.Items.AddRange(dataList.ToArray());

                assocAdapter_listBox.Items.Clear();
                dataList = filterResult.AssocInfo.Where(w => w.ADAPTER != null).Select(s => s.ADAPTER).Distinct().ToList();
                dataList.Sort();
                assocAdapter_listBox.Items.AddRange(dataList.ToArray());

                assocLhost_listBox.Items.Clear();
                dataList = filterResult.AssocInfo.Where(w => w.LHOST != null).Select(s => s.LHOST).Distinct().ToList();
                dataList.Sort();
                assocLhost_listBox.Items.AddRange(dataList.ToArray());

                assocLocalip_listBox.Items.Clear();
                dataList = filterResult.AssocInfo.Where(w => w.LOCAL_IP != null).Select(s => s.LOCAL_IP).Distinct().ToList();
                dataList.Sort();
                assocLocalip_listBox.Items.AddRange(dataList.ToArray());

                assocLport_listBox.Items.Clear();
                dataList = filterResult.AssocInfo.Where(w => w.LPORT != null).Select(s => s.LPORT).Distinct().ToList();
                dataList.Sort();
                assocLport_listBox.Items.AddRange(dataList.ToArray());

                assocRhost_listBox.Items.Clear();
                dataList = filterResult.AssocInfo.Where(w => w.RHOST != null).Select(s => s.RHOST).Distinct().ToList();
                dataList.Sort();
                assocRhost_listBox.Items.AddRange(dataList.ToArray());

                assocRemoteip_listBox.Items.Clear();
                dataList = filterResult.AssocInfo.Where(w => w.REMOTE_IP != null).Select(s => s.REMOTE_IP).Distinct().ToList();
                dataList.Sort();
                assocRemoteip_listBox.Items.AddRange(dataList.ToArray());

                LoadFilteredGrid(filterResult.AssocInfo);
            }
            catch (Exception ex)
            {
                ShowMessageRaised(new Data.MessageItem(ex.Message, true, ErrorTop, ErrorLeft, ErrorWidth, ErrorHeight), null);
            }
        }
        #endregion

        #region [ LoadFilteredGrid ]
        private void LoadFilteredGrid(List<Data.OST.ASSOC_Data> filteredData = null)
        {
            FilteredData = filteredData;

            try
            {
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns>PredicateResult_OpCode</returns>
        private Data.Predicates.PredicateResult_ASSOC GetFilteredData()
        {
            Data.Predicates.PredicateResult_ASSOC filterResult = new Data.Predicates.PredicateResult_ASSOC();
            var predicate = GetPredicate();            

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.AssocInfo = AssocData.Where(predicate).ToList();
                else
                    filterResult.AssocInfo = AssocData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return filterResult;
        }
        #endregion

        #region [ GetPredicate ]
        private ExpressionStarter<Data.OST.ASSOC_Data> GetPredicate()
        {
            var predicate = PredicateBuilder.New<Data.OST.ASSOC_Data>();

            try
            {
                if (assocAname_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.ANAME != null && w.ANAME == assocAname_listBox.Text);
                else if (!string.IsNullOrEmpty(assocAnameSearch_textBox.Text))
                {
                    EnableButton(assocAnameClear_button, true);

                    if (UTILS.StartsWith(assocAnameSearch_textBox.Text))
                        predicate = predicate.And(w => w.ANAME != null && w.ANAME.ToUpper().StartsWith(UTILS.GetStartText(assocAnameSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.ANAME != null && w.ANAME.ToUpper().Contains(assocAnameSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(assocAnameClear_button, false);

                if (assocLoc_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LOC != null && w.LOC == assocLoc_listBox.Text);
                else if (!string.IsNullOrEmpty(assocLocSearch_textBox.Text))
                {
                    EnableButton(assocLocClear_button, true);

                    if (UTILS.StartsWith(assocLocSearch_textBox.Text))
                        predicate = predicate.And(w => w.LOC != null && w.LOC.ToUpper().StartsWith(UTILS.GetStartText(assocLocSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LOC != null && w.LOC.ToUpper().Contains(assocLocSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(assocLocClear_button, false);

                if (assocPort_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.PORT != null && w.PORT == assocPort_listBox.Text);
                else if (!string.IsNullOrEmpty(assocPortSearch_textBox.Text))
                {
                    EnableButton(assocPortClear_button, true);

                    if (UTILS.StartsWith(assocPortSearch_textBox.Text))
                        predicate = predicate.And(w => w.PORT != null && w.PORT.ToUpper().StartsWith(UTILS.GetStartText(assocPortSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.PORT != null && w.PORT.ToUpper().Contains(assocPortSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(assocPortClear_button, false);

                if (assocAdapter_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.ADAPTER != null && w.ADAPTER == assocAdapter_listBox.Text);
                else if (!string.IsNullOrEmpty(assocAdapterSearch_textBox.Text))
                {
                    EnableButton(assocAdapterClear_button, true);

                    if (UTILS.StartsWith(assocAdapterSearch_textBox.Text))
                        predicate = predicate.And(w => w.ADAPTER != null && w.ADAPTER.ToUpper().StartsWith(UTILS.GetStartText(assocAdapterSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.ADAPTER != null && w.ADAPTER.ToUpper().Contains(assocAdapterSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(assocAdapterClear_button, false);

                if (assocLhost_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LHOST != null && w.LHOST == assocLhost_listBox.Text);
                else if (!string.IsNullOrEmpty(assocLhostSearch_textBox.Text))
                {
                    EnableButton(assocLhostClear_Clear_button, true);

                    if (UTILS.StartsWith(assocLhostSearch_textBox.Text))
                        predicate = predicate.And(w => w.LHOST != null && w.LHOST.ToUpper().StartsWith(UTILS.GetStartText(assocLhostSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LHOST != null && w.LHOST.ToUpper().Contains(assocLhostSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(assocLhostClear_Clear_button, false);

                if (assocLocalip_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LOCAL_IP != null && w.LOCAL_IP == assocLocalip_listBox.Text);
                else if (!string.IsNullOrEmpty(assocLocalipSearch_textBox.Text))
                {
                    EnableButton(assocLocalipClear_button, true);

                    if (UTILS.StartsWith(assocLocalipSearch_textBox.Text))
                        predicate = predicate.And(w => w.LOCAL_IP != null && w.LOCAL_IP.ToUpper().StartsWith(UTILS.GetStartText(assocLocalipSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LOCAL_IP != null && w.LOCAL_IP.ToUpper().Contains(assocLocalipSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(assocLocalipClear_button, false);

                if (assocLport_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.LPORT != null && w.LPORT == assocLport_listBox.Text);
                else if (!string.IsNullOrEmpty(assocLportSearch_textBox.Text))
                {
                    EnableButton(assocLportClear_button, true);

                    if (UTILS.StartsWith(assocLportSearch_textBox.Text))
                        predicate = predicate.And(w => w.LPORT != null && w.LPORT.ToUpper().StartsWith(UTILS.GetStartText(assocLportSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.LPORT != null && w.LPORT.ToUpper().Contains(assocLportSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(assocLportClear_button, false);

                if (assocRhost_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.RHOST != null && w.RHOST == assocRhost_listBox.Text);
                else if (!string.IsNullOrEmpty(assocRhostSearch_textBox.Text))
                {
                    EnableButton(assocRhostClear_button, true);

                    if (UTILS.StartsWith(assocRhostSearch_textBox.Text))
                        predicate = predicate.And(w => w.RHOST != null && w.RHOST.ToUpper().StartsWith(UTILS.GetStartText(assocRhostSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.RHOST != null && w.RHOST.ToUpper().Contains(assocRhostSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(assocRhostClear_button, false);

                if (assocRemoteip_listBox.SelectedIndex != -1)
                    predicate = predicate.And(w => w.REMOTE_IP != null && w.REMOTE_IP == assocRemoteip_listBox.Text);
                else if (!string.IsNullOrEmpty(assocRemoteipSearch_textBox.Text))
                {
                    EnableButton(assocRemoteipClear_button, true);

                    if (UTILS.StartsWith(assocRemoteipSearch_textBox.Text))
                        predicate = predicate.And(w => w.REMOTE_IP != null && w.REMOTE_IP.ToUpper().StartsWith(UTILS.GetStartText(assocRemoteipSearch_textBox.Text.ToUpper())));
                    else
                        predicate = predicate.And(w => w.REMOTE_IP != null && w.REMOTE_IP.ToUpper().Contains(assocRemoteipSearch_textBox.Text.ToUpper()));
                }
                else
                    EnableButton(assocRemoteipClear_button, false);
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
            Data.Predicates.PredicateResult_ASSOC filterResult = new Data.Predicates.PredicateResult_ASSOC();
            var predicate = GetPredicate();

            try
            {
                filterResult.Started = predicate.IsStarted;
                if (filterResult.Started)
                    filterResult.AssocInfo = AssocData.Where(predicate).ToList();
                else
                    filterResult.AssocInfo = AssocData;

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.ANAME])
                {
                    dataList = filterResult.AssocInfo.Where(w => w.ANAME != null).Select(s => s.ANAME).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = assocAname_listBox.SelectedIndex != -1;
                    assocAname_listBox.Items.Clear();
                    assocAname_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(assocAnameClear_button, true);
                        assocAnameSearch_textBox.Enabled = false;
                        assocAnameSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.ANAME] = true;
                        assocAname_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LOC])
                {
                    dataList = filterResult.AssocInfo.Where(w => w.LOC != null).Select(s => s.LOC).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = assocLoc_listBox.SelectedIndex != -1;
                    assocLoc_listBox.Items.Clear();
                    assocLoc_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(assocLocClear_button, true);
                        assocLocSearch_textBox.Enabled = false;
                        assocLocSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LOC] = true;
                        assocLoc_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.PORT])
                {
                    dataList = filterResult.AssocInfo.Where(w => w.PORT != null).Select(s => s.PORT).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = assocPort_listBox.SelectedIndex != -1;
                    assocPort_listBox.Items.Clear();
                    assocPort_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(assocPortClear_button, true);
                        assocPortSearch_textBox.Enabled = false;
                        assocPortSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.PORT] = true;
                        assocPort_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.ADAPTER])
                {
                    dataList = filterResult.AssocInfo.Where(w => w.ADAPTER != null).Select(s => s.ADAPTER).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = assocAdapter_listBox.SelectedIndex != -1;
                    assocAdapter_listBox.Items.Clear();
                    assocAdapter_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(assocAdapterClear_button, true);
                        assocAdapterSearch_textBox.Enabled = false;
                        assocAdapterSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.ADAPTER] = true;
                        assocAdapter_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LHOST])
                {
                    dataList = filterResult.AssocInfo.Where(w => w.LHOST != null).Select(s => s.LHOST).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = assocLhost_listBox.SelectedIndex != -1;
                    assocLhost_listBox.Items.Clear();
                    assocLhost_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(assocLhostClear_Clear_button, true);
                        assocLhostSearch_textBox.Enabled = false;
                        assocLhostSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LHOST] = true;
                        assocLhost_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LOCAL_IP])
                {
                    dataList = filterResult.AssocInfo.Where(w => w.LOCAL_IP != null).Select(s => s.LOCAL_IP).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = assocLocalip_listBox.SelectedIndex != -1;
                    assocLocalip_listBox.Items.Clear();
                    assocLocalip_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(assocLocalipClear_button, true);
                        assocLocalipSearch_textBox.Enabled = false;
                        assocLocalipSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LOCAL_IP] = true;
                        assocLocalip_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LPORT])
                {
                    dataList = filterResult.AssocInfo.Where(w => w.LPORT != null).Select(s => s.LPORT).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = assocLport_listBox.SelectedIndex != -1;
                    assocLport_listBox.Items.Clear();
                    assocLport_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(assocLportClear_button, true);
                        assocLportSearch_textBox.Enabled = false;
                        assocLportSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LPORT] = true;
                        assocLport_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.RHOST])
                {
                    dataList = filterResult.AssocInfo.Where(w => w.RHOST != null).Select(s => s.RHOST).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = assocRhost_listBox.SelectedIndex != -1;
                    assocRhost_listBox.Items.Clear();
                    assocRhost_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(assocRhostClear_button, true);
                        assocRhostSearch_textBox.Enabled = false;
                        assocRhostSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.RHOST] = true;
                        assocRhost_listBox.SelectedIndex = 0;
                    }
                }

                if (!ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.REMOTE_IP])
                {
                    dataList = filterResult.AssocInfo.Where(w => w.REMOTE_IP != null).Select(s => s.REMOTE_IP).Distinct().ToList();
                    dataList.Sort();
                    itemSelected = assocRemoteip_listBox.SelectedIndex != -1;
                    assocRemoteip_listBox.Items.Clear();
                    assocRemoteip_listBox.Items.AddRange(dataList.ToArray());
                    if (itemSelected)
                    {
                        EnableButton(assocRemoteipClear_button, true);
                        assocRemoteipSearch_textBox.Enabled = false;
                        assocRemoteipSearch_textBox.Text = string.Empty;
                        ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.REMOTE_IP] = true;
                        assocRemoteip_listBox.SelectedIndex = 0;
                    }
                }

                LoadFilteredGrid(filterResult.AssocInfo);
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
        private void assocAnameClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.ANAME] = false;
            assocAnameSearch_textBox.Text = string.Empty;
            assocAnameSearch_textBox.Enabled = true;
            assocAname_listBox.SelectedIndex = -1;
            FilterData();
            assocAnameSearch_textBox.Focus();
        }

        private void assocLocClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LOC] = false;
            assocLocSearch_textBox.Text = string.Empty;
            assocLocSearch_textBox.Enabled = true;
            assocLoc_listBox.SelectedIndex = -1;
            FilterData();
            assocLocSearch_textBox.Focus();
        }

        private void assocPortClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.PORT] = false;
            assocPortSearch_textBox.Text = string.Empty;
            assocPortSearch_textBox.Enabled = true;
            assocPort_listBox.SelectedIndex = -1;
            FilterData();
            assocPortSearch_textBox.Focus();
        }

        private void assocAdapterClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.ADAPTER] = false;
            assocAdapterSearch_textBox.Text = string.Empty;
            assocAdapterSearch_textBox.Enabled = true;
            assocAdapter_listBox.SelectedIndex = -1;
            FilterData();
            assocAdapterSearch_textBox.Focus();
        }

        private void assocLhostClear_Clear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LHOST] = false;
            assocLhostSearch_textBox.Text = string.Empty;
            assocLhostSearch_textBox.Enabled = true;
            assocLhost_listBox.SelectedIndex = -1;
            FilterData();
            assocLhostSearch_textBox.Focus();
        }

        private void assocLocalipClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LOCAL_IP] = false;
            assocLocalipSearch_textBox.Text = string.Empty;
            assocLocalipSearch_textBox.Enabled = true;
            assocLocalip_listBox.SelectedIndex = -1;
            FilterData();
            assocLocalipSearch_textBox.Focus();
        }

        private void assocLportClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.LPORT] = false;
            assocLportSearch_textBox.Text = string.Empty;
            assocLportSearch_textBox.Enabled = true;
            assocLport_listBox.SelectedIndex = -1;
            FilterData();
            assocLportSearch_textBox.Focus();
        }

        private void assocRhostClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.RHOST] = false;
            assocRhostSearch_textBox.Text = string.Empty;
            assocRhostSearch_textBox.Enabled = true;
            assocRhost_listBox.SelectedIndex = -1;
            FilterData();
            assocRhostSearch_textBox.Focus();
        }

        private void assocRemoteipClear_button_Click(object sender, EventArgs e)
        {
            ItemSelected[(int)DATA_ENUM.ItemsSelected.ASSOC.REMOTE_IP] = false;
            assocRemoteipSearch_textBox.Text = string.Empty;
            assocRemoteipSearch_textBox.Enabled = true;
            assocRemoteip_listBox.SelectedIndex = -1;
            FilterData();
            assocRemoteipSearch_textBox.Focus();
        }
        #endregion
        
        #region [ Generate Excel ]
        private void excel_button_Click(object sender, EventArgs e)
        {
            GenerateExcelClicked(null, null);
        }

        public void GenerateExcel(OfficeOpenXml.ExcelPackage xlPackage)
        {
            Business.Excel.OST.ASSOC(xlPackage, FilteredData);
        }
        #endregion

        #region [ Get Grid Columns ]
        private dynamic GetGridColumns()
        {
            var gridColumns = from t in FilteredData
                              orderby t.PORT, t.LOC
                              select new
                              {
                                  ANAME = t.ANAME,
                                  LOC = t.LOC,
                                  PORT = t.PORT,
                                  ADAPTER = t.ADAPTER,
                                  LHOST = t.LHOST,
                                  ALHOST = t.ALHOST,
                                  LOCAL_IP = t.LOCAL_IP,
                                  ALOCAL_IP = t.ALOCAL_IP,
                                  LPORT = t.LPORT,
                                  RHOST = t.RHOST,
                                  ARHOST = t.ARHOST,
                                  REMOTE_IP = t.REMOTE_IP,
                                  AREMOTE_IP = t.AREMOTE_IP,
                                  RPORT = t.RPORT
                              };

            return gridColumns.ToList();
        }
        #endregion

        #region [ Link Labels ]
        private void assocAname_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(assocAname_listBox);
        }

        private void assocLoc_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(assocLoc_listBox);
        }

        private void assocLhost_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(assocLhost_listBox);
        }

        private void assocLocalIp_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(assocLocalip_listBox);
        }

        private void assocLport_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(assocLport_listBox);
        }

        private void assocRhost_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(assocRhost_listBox);
        }

        private void assocRemoteIp_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyValuesClipboard(assocRemoteip_listBox);
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