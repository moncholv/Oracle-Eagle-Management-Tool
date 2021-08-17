namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    partial class GTTSEL
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GTTSEL));
            this.numRecords_label = new System.Windows.Forms.Label();
            this.gttselNaiClear_button = new System.Windows.Forms.Button();
            this.gttselNaiSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttselNai_listBox = new System.Windows.Forms.ListBox();
            this.gttselNpClear_button = new System.Windows.Forms.Button();
            this.gttselTtClear_button = new System.Windows.Forms.Button();
            this.gttselSelidClear_button = new System.Windows.Forms.Button();
            this.gttselCdpaClear_button = new System.Windows.Forms.Button();
            this.gttselLsnClear_button = new System.Windows.Forms.Button();
            this.gttselCdpaSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttselCdpa_listBox = new System.Windows.Forms.ListBox();
            this.gttselLsnSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttselLsn_listBox = new System.Windows.Forms.ListBox();
            this.gttselSelidSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttselSelid_listBox = new System.Windows.Forms.ListBox();
            this.gttselSelid_label = new System.Windows.Forms.Label();
            this.gttselNpSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttselNp_listBox = new System.Windows.Forms.ListBox();
            this.search_dataGridView = new System.Windows.Forms.DataGridView();
            this.gttselTtSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttselTt_listBox = new System.Windows.Forms.ListBox();
            this.gttselTt_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gttselNp_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gttselNai_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gttselLsn_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gttselCdpa_linkLabel = new System.Windows.Forms.LinkLabel();
            this.clear_button = new System.Windows.Forms.Button();
            this.excel_button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gttselMsgType_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gttselMsgType_listBox = new System.Windows.Forms.ListBox();
            this.gttselMsgTypeSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttselMsgTypeClear_button = new System.Windows.Forms.Button();
            this.gttselInt_listBox = new System.Windows.Forms.ListBox();
            this.gttselIntSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttselIntClear_button = new System.Windows.Forms.Button();
            this.gttselNats_listBox = new System.Windows.Forms.ListBox();
            this.gttselNatsSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttselNatsClear_button = new System.Windows.Forms.Button();
            this.gttselInt_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gttselNats_linkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numRecords_label
            // 
            this.numRecords_label.AutoSize = true;
            this.numRecords_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRecords_label.Location = new System.Drawing.Point(322, 0);
            this.numRecords_label.Name = "numRecords_label";
            this.numRecords_label.Size = new System.Drawing.Size(111, 12);
            this.numRecords_label.TabIndex = 335;
            this.numRecords_label.Text = "Number of records: 15000";
            this.numRecords_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gttselNaiClear_button
            // 
            this.gttselNaiClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttselNaiClear_button.BackgroundImage")));
            this.gttselNaiClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttselNaiClear_button.Enabled = false;
            this.gttselNaiClear_button.Location = new System.Drawing.Point(331, 15);
            this.gttselNaiClear_button.Name = "gttselNaiClear_button";
            this.gttselNaiClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttselNaiClear_button.TabIndex = 300;
            this.gttselNaiClear_button.UseVisualStyleBackColor = true;
            this.gttselNaiClear_button.Click += new System.EventHandler(this.gttselNaiClear_button_Click);
            // 
            // gttselNaiSearch_textBox
            // 
            this.gttselNaiSearch_textBox.Location = new System.Drawing.Point(269, 16);
            this.gttselNaiSearch_textBox.Name = "gttselNaiSearch_textBox";
            this.gttselNaiSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.gttselNaiSearch_textBox.TabIndex = 299;
            this.gttselNaiSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttselNai_listBox
            // 
            this.gttselNai_listBox.FormattingEnabled = true;
            this.gttselNai_listBox.Location = new System.Drawing.Point(269, 41);
            this.gttselNai_listBox.Name = "gttselNai_listBox";
            this.gttselNai_listBox.Size = new System.Drawing.Size(84, 69);
            this.gttselNai_listBox.TabIndex = 298;
            this.gttselNai_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttselNpClear_button
            // 
            this.gttselNpClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttselNpClear_button.BackgroundImage")));
            this.gttselNpClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttselNpClear_button.Enabled = false;
            this.gttselNpClear_button.Location = new System.Drawing.Point(230, 14);
            this.gttselNpClear_button.Name = "gttselNpClear_button";
            this.gttselNpClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttselNpClear_button.TabIndex = 292;
            this.gttselNpClear_button.UseVisualStyleBackColor = true;
            this.gttselNpClear_button.Click += new System.EventHandler(this.gttselNpClear_button_Click);
            // 
            // gttselTtClear_button
            // 
            this.gttselTtClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttselTtClear_button.BackgroundImage")));
            this.gttselTtClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttselTtClear_button.Enabled = false;
            this.gttselTtClear_button.Location = new System.Drawing.Point(521, 15);
            this.gttselTtClear_button.Name = "gttselTtClear_button";
            this.gttselTtClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttselTtClear_button.TabIndex = 291;
            this.gttselTtClear_button.UseVisualStyleBackColor = true;
            this.gttselTtClear_button.Click += new System.EventHandler(this.gttselTtClear_button_Click);
            // 
            // gttselSelidClear_button
            // 
            this.gttselSelidClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttselSelidClear_button.BackgroundImage")));
            this.gttselSelidClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttselSelidClear_button.Enabled = false;
            this.gttselSelidClear_button.Location = new System.Drawing.Point(431, 15);
            this.gttselSelidClear_button.Name = "gttselSelidClear_button";
            this.gttselSelidClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttselSelidClear_button.TabIndex = 290;
            this.gttselSelidClear_button.UseVisualStyleBackColor = true;
            this.gttselSelidClear_button.Click += new System.EventHandler(this.gttselSelidClear_button_Click);
            // 
            // gttselCdpaClear_button
            // 
            this.gttselCdpaClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttselCdpaClear_button.BackgroundImage")));
            this.gttselCdpaClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttselCdpaClear_button.Enabled = false;
            this.gttselCdpaClear_button.Location = new System.Drawing.Point(847, 16);
            this.gttselCdpaClear_button.Name = "gttselCdpaClear_button";
            this.gttselCdpaClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttselCdpaClear_button.TabIndex = 288;
            this.gttselCdpaClear_button.UseVisualStyleBackColor = true;
            this.gttselCdpaClear_button.Click += new System.EventHandler(this.gttselCdpaClear_button_Click);
            // 
            // gttselLsnClear_button
            // 
            this.gttselLsnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttselLsnClear_button.BackgroundImage")));
            this.gttselLsnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttselLsnClear_button.Enabled = false;
            this.gttselLsnClear_button.Location = new System.Drawing.Point(730, 15);
            this.gttselLsnClear_button.Name = "gttselLsnClear_button";
            this.gttselLsnClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttselLsnClear_button.TabIndex = 287;
            this.gttselLsnClear_button.UseVisualStyleBackColor = true;
            this.gttselLsnClear_button.Click += new System.EventHandler(this.gttselLsnClear_button_Click);
            // 
            // gttselCdpaSearch_textBox
            // 
            this.gttselCdpaSearch_textBox.Location = new System.Drawing.Point(769, 16);
            this.gttselCdpaSearch_textBox.Name = "gttselCdpaSearch_textBox";
            this.gttselCdpaSearch_textBox.Size = new System.Drawing.Size(72, 20);
            this.gttselCdpaSearch_textBox.TabIndex = 280;
            this.gttselCdpaSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttselCdpa_listBox
            // 
            this.gttselCdpa_listBox.FormattingEnabled = true;
            this.gttselCdpa_listBox.Location = new System.Drawing.Point(769, 41);
            this.gttselCdpa_listBox.Name = "gttselCdpa_listBox";
            this.gttselCdpa_listBox.Size = new System.Drawing.Size(100, 69);
            this.gttselCdpa_listBox.TabIndex = 279;
            this.gttselCdpa_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttselLsnSearch_textBox
            // 
            this.gttselLsnSearch_textBox.Location = new System.Drawing.Point(651, 16);
            this.gttselLsnSearch_textBox.Name = "gttselLsnSearch_textBox";
            this.gttselLsnSearch_textBox.Size = new System.Drawing.Size(73, 20);
            this.gttselLsnSearch_textBox.TabIndex = 277;
            this.gttselLsnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttselLsn_listBox
            // 
            this.gttselLsn_listBox.FormattingEnabled = true;
            this.gttselLsn_listBox.Location = new System.Drawing.Point(651, 41);
            this.gttselLsn_listBox.Name = "gttselLsn_listBox";
            this.gttselLsn_listBox.Size = new System.Drawing.Size(101, 69);
            this.gttselLsn_listBox.TabIndex = 276;
            this.gttselLsn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttselSelidSearch_textBox
            // 
            this.gttselSelidSearch_textBox.Location = new System.Drawing.Point(369, 16);
            this.gttselSelidSearch_textBox.Name = "gttselSelidSearch_textBox";
            this.gttselSelidSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.gttselSelidSearch_textBox.TabIndex = 274;
            this.gttselSelidSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttselSelid_listBox
            // 
            this.gttselSelid_listBox.FormattingEnabled = true;
            this.gttselSelid_listBox.Location = new System.Drawing.Point(369, 41);
            this.gttselSelid_listBox.Name = "gttselSelid_listBox";
            this.gttselSelid_listBox.Size = new System.Drawing.Size(84, 69);
            this.gttselSelid_listBox.TabIndex = 273;
            this.gttselSelid_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttselSelid_label
            // 
            this.gttselSelid_label.AutoSize = true;
            this.gttselSelid_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gttselSelid_label.Location = new System.Drawing.Point(367, 2);
            this.gttselSelid_label.Name = "gttselSelid_label";
            this.gttselSelid_label.Size = new System.Drawing.Size(32, 12);
            this.gttselSelid_label.TabIndex = 272;
            this.gttselSelid_label.Text = "SELID";
            // 
            // gttselNpSearch_textBox
            // 
            this.gttselNpSearch_textBox.Location = new System.Drawing.Point(181, 16);
            this.gttselNpSearch_textBox.Name = "gttselNpSearch_textBox";
            this.gttselNpSearch_textBox.Size = new System.Drawing.Size(43, 20);
            this.gttselNpSearch_textBox.TabIndex = 268;
            this.gttselNpSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttselNp_listBox
            // 
            this.gttselNp_listBox.FormattingEnabled = true;
            this.gttselNp_listBox.Location = new System.Drawing.Point(181, 41);
            this.gttselNp_listBox.Name = "gttselNp_listBox";
            this.gttselNp_listBox.Size = new System.Drawing.Size(71, 69);
            this.gttselNp_listBox.TabIndex = 267;
            this.gttselNp_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // search_dataGridView
            // 
            this.search_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.search_dataGridView.Location = new System.Drawing.Point(3, 120);
            this.search_dataGridView.Name = "search_dataGridView";
            this.search_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.search_dataGridView.Size = new System.Drawing.Size(870, 343);
            this.search_dataGridView.TabIndex = 265;
            this.search_dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.search_dataGridView_DataBindingComplete);
            // 
            // gttselTtSearch_textBox
            // 
            this.gttselTtSearch_textBox.Location = new System.Drawing.Point(470, 16);
            this.gttselTtSearch_textBox.Name = "gttselTtSearch_textBox";
            this.gttselTtSearch_textBox.Size = new System.Drawing.Size(45, 20);
            this.gttselTtSearch_textBox.TabIndex = 19;
            this.gttselTtSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttselTt_listBox
            // 
            this.gttselTt_listBox.FormattingEnabled = true;
            this.gttselTt_listBox.Location = new System.Drawing.Point(470, 41);
            this.gttselTt_listBox.Name = "gttselTt_listBox";
            this.gttselTt_listBox.Size = new System.Drawing.Size(73, 69);
            this.gttselTt_listBox.TabIndex = 18;
            this.gttselTt_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttselTt_linkLabel
            // 
            this.gttselTt_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttselTt_linkLabel.AutoSize = true;
            this.gttselTt_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttselTt_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttselTt_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselTt_linkLabel.Location = new System.Drawing.Point(468, 2);
            this.gttselTt_linkLabel.Name = "gttselTt_linkLabel";
            this.gttselTt_linkLabel.Size = new System.Drawing.Size(15, 12);
            this.gttselTt_linkLabel.TabIndex = 343;
            this.gttselTt_linkLabel.TabStop = true;
            this.gttselTt_linkLabel.Text = "TT";
            this.gttselTt_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselTt_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttselTt_linkLabel_LinkClicked);
            // 
            // gttselNp_linkLabel
            // 
            this.gttselNp_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttselNp_linkLabel.AutoSize = true;
            this.gttselNp_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttselNp_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttselNp_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselNp_linkLabel.Location = new System.Drawing.Point(179, 2);
            this.gttselNp_linkLabel.Name = "gttselNp_linkLabel";
            this.gttselNp_linkLabel.Size = new System.Drawing.Size(18, 12);
            this.gttselNp_linkLabel.TabIndex = 344;
            this.gttselNp_linkLabel.TabStop = true;
            this.gttselNp_linkLabel.Text = "NP";
            this.gttselNp_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselNp_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttselNp_linkLabel_LinkClicked);
            // 
            // gttselNai_linkLabel
            // 
            this.gttselNai_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttselNai_linkLabel.AutoSize = true;
            this.gttselNai_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttselNai_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttselNai_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselNai_linkLabel.Location = new System.Drawing.Point(267, 2);
            this.gttselNai_linkLabel.Name = "gttselNai_linkLabel";
            this.gttselNai_linkLabel.Size = new System.Drawing.Size(22, 12);
            this.gttselNai_linkLabel.TabIndex = 345;
            this.gttselNai_linkLabel.TabStop = true;
            this.gttselNai_linkLabel.Text = "NAI";
            this.gttselNai_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselNai_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttselNai_linkLabel_LinkClicked);
            // 
            // gttselLsn_linkLabel
            // 
            this.gttselLsn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttselLsn_linkLabel.AutoSize = true;
            this.gttselLsn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttselLsn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttselLsn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselLsn_linkLabel.Location = new System.Drawing.Point(649, 2);
            this.gttselLsn_linkLabel.Name = "gttselLsn_linkLabel";
            this.gttselLsn_linkLabel.Size = new System.Drawing.Size(23, 12);
            this.gttselLsn_linkLabel.TabIndex = 346;
            this.gttselLsn_linkLabel.TabStop = true;
            this.gttselLsn_linkLabel.Text = "LSN";
            this.gttselLsn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselLsn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttselLsn_linkLabel_LinkClicked);
            // 
            // gttselCdpa_linkLabel
            // 
            this.gttselCdpa_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttselCdpa_linkLabel.AutoSize = true;
            this.gttselCdpa_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttselCdpa_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttselCdpa_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselCdpa_linkLabel.Location = new System.Drawing.Point(767, 2);
            this.gttselCdpa_linkLabel.Name = "gttselCdpa_linkLabel";
            this.gttselCdpa_linkLabel.Size = new System.Drawing.Size(68, 12);
            this.gttselCdpa_linkLabel.TabIndex = 347;
            this.gttselCdpa_linkLabel.TabStop = true;
            this.gttselCdpa_linkLabel.Text = "CDPA GTTSET";
            this.gttselCdpa_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselCdpa_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttselCdpa_linkLabel_LinkClicked);
            // 
            // clear_button
            // 
            this.clear_button.BackColor = System.Drawing.Color.Transparent;
            this.clear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clear_button.Enabled = false;
            this.clear_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_button.Image = global::VRS_Eng_Manage_Tool.Properties.Resources.clear_button;
            this.clear_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clear_button.Location = new System.Drawing.Point(3, 468);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(125, 25);
            this.clear_button.TabIndex = 352;
            this.clear_button.Text = "  Clear Section Filter";
            this.clear_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clear_button.UseVisualStyleBackColor = false;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // excel_button
            // 
            this.excel_button.BackColor = System.Drawing.Color.Transparent;
            this.excel_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.excel_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excel_button.Image = global::VRS_Eng_Manage_Tool.Properties.Resources.Excel_button;
            this.excel_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.excel_button.Location = new System.Drawing.Point(134, 468);
            this.excel_button.Name = "excel_button";
            this.excel_button.Size = new System.Drawing.Size(148, 25);
            this.excel_button.TabIndex = 351;
            this.excel_button.Text = "  Generate Section Excel";
            this.excel_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.excel_button.UseVisualStyleBackColor = false;
            this.excel_button.Click += new System.EventHandler(this.excel_button_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.numRecords_label);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(436, 464);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(436, 37);
            this.flowLayoutPanel1.TabIndex = 353;
            // 
            // gttselMsgType_linkLabel
            // 
            this.gttselMsgType_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttselMsgType_linkLabel.AutoSize = true;
            this.gttselMsgType_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttselMsgType_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttselMsgType_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselMsgType_linkLabel.Location = new System.Drawing.Point(1, 2);
            this.gttselMsgType_linkLabel.Name = "gttselMsgType_linkLabel";
            this.gttselMsgType_linkLabel.Size = new System.Drawing.Size(49, 12);
            this.gttselMsgType_linkLabel.TabIndex = 357;
            this.gttselMsgType_linkLabel.TabStop = true;
            this.gttselMsgType_linkLabel.Text = "MSGTYPE";
            this.gttselMsgType_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselMsgType_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttselMsgType_linkLabel_LinkClicked);
            // 
            // gttselMsgType_listBox
            // 
            this.gttselMsgType_listBox.FormattingEnabled = true;
            this.gttselMsgType_listBox.Location = new System.Drawing.Point(3, 41);
            this.gttselMsgType_listBox.Name = "gttselMsgType_listBox";
            this.gttselMsgType_listBox.Size = new System.Drawing.Size(73, 69);
            this.gttselMsgType_listBox.TabIndex = 354;
            this.gttselMsgType_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttselMsgTypeSearch_textBox
            // 
            this.gttselMsgTypeSearch_textBox.Location = new System.Drawing.Point(3, 16);
            this.gttselMsgTypeSearch_textBox.Name = "gttselMsgTypeSearch_textBox";
            this.gttselMsgTypeSearch_textBox.Size = new System.Drawing.Size(45, 20);
            this.gttselMsgTypeSearch_textBox.TabIndex = 355;
            this.gttselMsgTypeSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttselMsgTypeClear_button
            // 
            this.gttselMsgTypeClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttselMsgTypeClear_button.BackgroundImage")));
            this.gttselMsgTypeClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttselMsgTypeClear_button.Enabled = false;
            this.gttselMsgTypeClear_button.Location = new System.Drawing.Point(54, 15);
            this.gttselMsgTypeClear_button.Name = "gttselMsgTypeClear_button";
            this.gttselMsgTypeClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttselMsgTypeClear_button.TabIndex = 356;
            this.gttselMsgTypeClear_button.UseVisualStyleBackColor = true;
            this.gttselMsgTypeClear_button.Click += new System.EventHandler(this.gttselMsgTypeClear_button_Click);
            // 
            // gttselInt_listBox
            // 
            this.gttselInt_listBox.FormattingEnabled = true;
            this.gttselInt_listBox.Location = new System.Drawing.Point(92, 41);
            this.gttselInt_listBox.Name = "gttselInt_listBox";
            this.gttselInt_listBox.Size = new System.Drawing.Size(73, 69);
            this.gttselInt_listBox.TabIndex = 358;
            this.gttselInt_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttselIntSearch_textBox
            // 
            this.gttselIntSearch_textBox.Location = new System.Drawing.Point(92, 16);
            this.gttselIntSearch_textBox.Name = "gttselIntSearch_textBox";
            this.gttselIntSearch_textBox.Size = new System.Drawing.Size(45, 20);
            this.gttselIntSearch_textBox.TabIndex = 359;
            this.gttselIntSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttselIntClear_button
            // 
            this.gttselIntClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttselIntClear_button.BackgroundImage")));
            this.gttselIntClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttselIntClear_button.Enabled = false;
            this.gttselIntClear_button.Location = new System.Drawing.Point(143, 15);
            this.gttselIntClear_button.Name = "gttselIntClear_button";
            this.gttselIntClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttselIntClear_button.TabIndex = 360;
            this.gttselIntClear_button.UseVisualStyleBackColor = true;
            this.gttselIntClear_button.Click += new System.EventHandler(this.gttselIntClear_button_Click);
            // 
            // gttselNats_listBox
            // 
            this.gttselNats_listBox.FormattingEnabled = true;
            this.gttselNats_listBox.Location = new System.Drawing.Point(560, 41);
            this.gttselNats_listBox.Name = "gttselNats_listBox";
            this.gttselNats_listBox.Size = new System.Drawing.Size(73, 69);
            this.gttselNats_listBox.TabIndex = 361;
            this.gttselNats_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttselNatsSearch_textBox
            // 
            this.gttselNatsSearch_textBox.Location = new System.Drawing.Point(560, 16);
            this.gttselNatsSearch_textBox.Name = "gttselNatsSearch_textBox";
            this.gttselNatsSearch_textBox.Size = new System.Drawing.Size(45, 20);
            this.gttselNatsSearch_textBox.TabIndex = 362;
            this.gttselNatsSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttselNatsClear_button
            // 
            this.gttselNatsClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttselNatsClear_button.BackgroundImage")));
            this.gttselNatsClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttselNatsClear_button.Enabled = false;
            this.gttselNatsClear_button.Location = new System.Drawing.Point(611, 15);
            this.gttselNatsClear_button.Name = "gttselNatsClear_button";
            this.gttselNatsClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttselNatsClear_button.TabIndex = 363;
            this.gttselNatsClear_button.UseVisualStyleBackColor = true;
            this.gttselNatsClear_button.Click += new System.EventHandler(this.gttselNatsClear_button_Click);
            // 
            // gttselInt_linkLabel
            // 
            this.gttselInt_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttselInt_linkLabel.AutoSize = true;
            this.gttselInt_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttselInt_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttselInt_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselInt_linkLabel.Location = new System.Drawing.Point(90, 2);
            this.gttselInt_linkLabel.Name = "gttselInt_linkLabel";
            this.gttselInt_linkLabel.Size = new System.Drawing.Size(20, 12);
            this.gttselInt_linkLabel.TabIndex = 364;
            this.gttselInt_linkLabel.TabStop = true;
            this.gttselInt_linkLabel.Text = "INT";
            this.gttselInt_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselInt_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttselInt_linkLabel_LinkClicked);
            // 
            // gttselNats_linkLabel
            // 
            this.gttselNats_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttselNats_linkLabel.AutoSize = true;
            this.gttselNats_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttselNats_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttselNats_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselNats_linkLabel.Location = new System.Drawing.Point(558, 2);
            this.gttselNats_linkLabel.Name = "gttselNats_linkLabel";
            this.gttselNats_linkLabel.Size = new System.Drawing.Size(30, 12);
            this.gttselNats_linkLabel.TabIndex = 365;
            this.gttselNats_linkLabel.TabStop = true;
            this.gttselNats_linkLabel.Text = "NATS";
            this.gttselNats_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttselNats_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttselNats_linkLabel_LinkClicked);
            // 
            // GTTSEL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gttselNats_linkLabel);
            this.Controls.Add(this.gttselInt_linkLabel);
            this.Controls.Add(this.gttselNats_listBox);
            this.Controls.Add(this.gttselNatsSearch_textBox);
            this.Controls.Add(this.gttselNatsClear_button);
            this.Controls.Add(this.gttselInt_listBox);
            this.Controls.Add(this.gttselIntSearch_textBox);
            this.Controls.Add(this.gttselIntClear_button);
            this.Controls.Add(this.gttselMsgType_linkLabel);
            this.Controls.Add(this.gttselMsgType_listBox);
            this.Controls.Add(this.gttselMsgTypeSearch_textBox);
            this.Controls.Add(this.gttselMsgTypeClear_button);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.gttselCdpa_linkLabel);
            this.Controls.Add(this.gttselLsn_linkLabel);
            this.Controls.Add(this.gttselNai_linkLabel);
            this.Controls.Add(this.gttselNp_linkLabel);
            this.Controls.Add(this.gttselTt_linkLabel);
            this.Controls.Add(this.gttselNaiClear_button);
            this.Controls.Add(this.gttselNaiSearch_textBox);
            this.Controls.Add(this.gttselTt_listBox);
            this.Controls.Add(this.gttselNai_listBox);
            this.Controls.Add(this.gttselTtSearch_textBox);
            this.Controls.Add(this.search_dataGridView);
            this.Controls.Add(this.gttselNp_listBox);
            this.Controls.Add(this.gttselNpSearch_textBox);
            this.Controls.Add(this.gttselSelid_label);
            this.Controls.Add(this.gttselNpClear_button);
            this.Controls.Add(this.gttselSelid_listBox);
            this.Controls.Add(this.gttselTtClear_button);
            this.Controls.Add(this.gttselSelidSearch_textBox);
            this.Controls.Add(this.gttselSelidClear_button);
            this.Controls.Add(this.gttselLsn_listBox);
            this.Controls.Add(this.gttselCdpaClear_button);
            this.Controls.Add(this.gttselLsnSearch_textBox);
            this.Controls.Add(this.gttselLsnClear_button);
            this.Controls.Add(this.gttselCdpa_listBox);
            this.Controls.Add(this.gttselCdpaSearch_textBox);
            this.Name = "GTTSEL";
            this.Size = new System.Drawing.Size(876, 502);
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button gttselNaiClear_button;
        private System.Windows.Forms.TextBox gttselNaiSearch_textBox;
        private System.Windows.Forms.ListBox gttselNai_listBox;
        private System.Windows.Forms.Button gttselNpClear_button;
        private System.Windows.Forms.Button gttselTtClear_button;
        private System.Windows.Forms.Button gttselSelidClear_button;
        private System.Windows.Forms.Button gttselCdpaClear_button;
        private System.Windows.Forms.Button gttselLsnClear_button;
        private System.Windows.Forms.TextBox gttselCdpaSearch_textBox;
        private System.Windows.Forms.ListBox gttselCdpa_listBox;
        private System.Windows.Forms.TextBox gttselLsnSearch_textBox;
        private System.Windows.Forms.ListBox gttselLsn_listBox;
        private System.Windows.Forms.TextBox gttselSelidSearch_textBox;
        private System.Windows.Forms.ListBox gttselSelid_listBox;
        private System.Windows.Forms.Label gttselSelid_label;
        private System.Windows.Forms.TextBox gttselNpSearch_textBox;
        private System.Windows.Forms.ListBox gttselNp_listBox;
        private System.Windows.Forms.DataGridView search_dataGridView;
        private System.Windows.Forms.TextBox gttselTtSearch_textBox;
        private System.Windows.Forms.ListBox gttselTt_listBox;
        private System.Windows.Forms.Label numRecords_label;
        private System.Windows.Forms.LinkLabel gttselTt_linkLabel;
        private System.Windows.Forms.LinkLabel gttselNp_linkLabel;
        private System.Windows.Forms.LinkLabel gttselNai_linkLabel;
        private System.Windows.Forms.LinkLabel gttselLsn_linkLabel;
        private System.Windows.Forms.LinkLabel gttselCdpa_linkLabel;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel gttselMsgType_linkLabel;
        private System.Windows.Forms.ListBox gttselMsgType_listBox;
        private System.Windows.Forms.TextBox gttselMsgTypeSearch_textBox;
        private System.Windows.Forms.Button gttselMsgTypeClear_button;
        private System.Windows.Forms.ListBox gttselInt_listBox;
        private System.Windows.Forms.TextBox gttselIntSearch_textBox;
        private System.Windows.Forms.Button gttselIntClear_button;
        private System.Windows.Forms.ListBox gttselNats_listBox;
        private System.Windows.Forms.TextBox gttselNatsSearch_textBox;
        private System.Windows.Forms.Button gttselNatsClear_button;
        private System.Windows.Forms.LinkLabel gttselInt_linkLabel;
        private System.Windows.Forms.LinkLabel gttselNats_linkLabel;
    }
}
