namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    partial class DSTN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSTN));
            this.numRecords_label = new System.Windows.Forms.Label();
            this.dstnDpcDecClear_button = new System.Windows.Forms.Button();
            this.dstnDpcDecSearch_textBox = new System.Windows.Forms.TextBox();
            this.dstnDpcDec_listBox = new System.Windows.Forms.ListBox();
            this.dstnDpcClear_button = new System.Windows.Forms.Button();
            this.dstnTypeClear_button = new System.Windows.Forms.Button();
            this.dstnClliClear_button = new System.Windows.Forms.Button();
            this.dstnApciClear_button = new System.Windows.Forms.Button();
            this.dstnLsnClear_button = new System.Windows.Forms.Button();
            this.dstnClliSearch_textBox = new System.Windows.Forms.TextBox();
            this.dstnClli_listBox = new System.Windows.Forms.ListBox();
            this.dstnApciSearch_textBox = new System.Windows.Forms.TextBox();
            this.dstnApci_listBox = new System.Windows.Forms.ListBox();
            this.dstnLsnSearch_textBox = new System.Windows.Forms.TextBox();
            this.dstnLsn_listBox = new System.Windows.Forms.ListBox();
            this.dstnTypeSearch_textBox = new System.Windows.Forms.TextBox();
            this.dstnType_listBox = new System.Windows.Forms.ListBox();
            this.dstnType_label = new System.Windows.Forms.Label();
            this.dstnDpcSearch_textBox = new System.Windows.Forms.TextBox();
            this.dstnDpc_listBox = new System.Windows.Forms.ListBox();
            this.search_dataGridView = new System.Windows.Forms.DataGridView();
            this.dstnRcClear_button = new System.Windows.Forms.Button();
            this.dstnRcSearch_textBox = new System.Windows.Forms.TextBox();
            this.dstnRc_listBox = new System.Windows.Forms.ListBox();
            this.dstnApciDecClear_button = new System.Windows.Forms.Button();
            this.dstnApciDec_listBox = new System.Windows.Forms.ListBox();
            this.dstnApciDecSearch_textBox = new System.Windows.Forms.TextBox();
            this.dstnDpc_linkLabel = new System.Windows.Forms.LinkLabel();
            this.dstnDpcDec_linkLabel = new System.Windows.Forms.LinkLabel();
            this.dstnClli_linkLabel = new System.Windows.Forms.LinkLabel();
            this.dstnLsn_linkLabel = new System.Windows.Forms.LinkLabel();
            this.dstnRc_linkLabel = new System.Windows.Forms.LinkLabel();
            this.dstnApci_linkLabel = new System.Windows.Forms.LinkLabel();
            this.dstnApciDec_linkLabel = new System.Windows.Forms.LinkLabel();
            this.clear_button = new System.Windows.Forms.Button();
            this.excel_button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numRecords_label
            // 
            this.numRecords_label.AutoSize = true;
            this.numRecords_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRecords_label.Location = new System.Drawing.Point(159, 0);
            this.numRecords_label.Name = "numRecords_label";
            this.numRecords_label.Size = new System.Drawing.Size(111, 12);
            this.numRecords_label.TabIndex = 335;
            this.numRecords_label.Text = "Number of records: 15000";
            this.numRecords_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dstnDpcDecClear_button
            // 
            this.dstnDpcDecClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dstnDpcDecClear_button.BackgroundImage")));
            this.dstnDpcDecClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dstnDpcDecClear_button.Enabled = false;
            this.dstnDpcDecClear_button.Location = new System.Drawing.Point(259, 16);
            this.dstnDpcDecClear_button.Name = "dstnDpcDecClear_button";
            this.dstnDpcDecClear_button.Size = new System.Drawing.Size(22, 22);
            this.dstnDpcDecClear_button.TabIndex = 300;
            this.dstnDpcDecClear_button.UseVisualStyleBackColor = true;
            this.dstnDpcDecClear_button.Click += new System.EventHandler(this.dstnDpcDecClear_button_Click);
            // 
            // dstnDpcDecSearch_textBox
            // 
            this.dstnDpcDecSearch_textBox.Location = new System.Drawing.Point(204, 17);
            this.dstnDpcDecSearch_textBox.Name = "dstnDpcDecSearch_textBox";
            this.dstnDpcDecSearch_textBox.Size = new System.Drawing.Size(49, 20);
            this.dstnDpcDecSearch_textBox.TabIndex = 299;
            this.dstnDpcDecSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // dstnDpcDec_listBox
            // 
            this.dstnDpcDec_listBox.FormattingEnabled = true;
            this.dstnDpcDec_listBox.Location = new System.Drawing.Point(204, 42);
            this.dstnDpcDec_listBox.Name = "dstnDpcDec_listBox";
            this.dstnDpcDec_listBox.Size = new System.Drawing.Size(77, 69);
            this.dstnDpcDec_listBox.TabIndex = 298;
            this.dstnDpcDec_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // dstnDpcClear_button
            // 
            this.dstnDpcClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dstnDpcClear_button.BackgroundImage")));
            this.dstnDpcClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dstnDpcClear_button.Enabled = false;
            this.dstnDpcClear_button.Location = new System.Drawing.Point(163, 15);
            this.dstnDpcClear_button.Name = "dstnDpcClear_button";
            this.dstnDpcClear_button.Size = new System.Drawing.Size(22, 22);
            this.dstnDpcClear_button.TabIndex = 292;
            this.dstnDpcClear_button.UseVisualStyleBackColor = true;
            this.dstnDpcClear_button.Click += new System.EventHandler(this.dstnDpcClear_button_Click);
            // 
            // dstnTypeClear_button
            // 
            this.dstnTypeClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dstnTypeClear_button.BackgroundImage")));
            this.dstnTypeClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dstnTypeClear_button.Enabled = false;
            this.dstnTypeClear_button.Location = new System.Drawing.Point(67, 16);
            this.dstnTypeClear_button.Name = "dstnTypeClear_button";
            this.dstnTypeClear_button.Size = new System.Drawing.Size(22, 22);
            this.dstnTypeClear_button.TabIndex = 290;
            this.dstnTypeClear_button.UseVisualStyleBackColor = true;
            this.dstnTypeClear_button.Click += new System.EventHandler(this.dstnTypeClear_button_Click);
            // 
            // dstnClliClear_button
            // 
            this.dstnClliClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dstnClliClear_button.BackgroundImage")));
            this.dstnClliClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dstnClliClear_button.Enabled = false;
            this.dstnClliClear_button.Location = new System.Drawing.Point(388, 16);
            this.dstnClliClear_button.Name = "dstnClliClear_button";
            this.dstnClliClear_button.Size = new System.Drawing.Size(22, 22);
            this.dstnClliClear_button.TabIndex = 289;
            this.dstnClliClear_button.UseVisualStyleBackColor = true;
            this.dstnClliClear_button.Click += new System.EventHandler(this.dstnClliClear_button_Click);
            // 
            // dstnApciClear_button
            // 
            this.dstnApciClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dstnApciClear_button.BackgroundImage")));
            this.dstnApciClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dstnApciClear_button.Enabled = false;
            this.dstnApciClear_button.Location = new System.Drawing.Point(692, 16);
            this.dstnApciClear_button.Name = "dstnApciClear_button";
            this.dstnApciClear_button.Size = new System.Drawing.Size(22, 22);
            this.dstnApciClear_button.TabIndex = 288;
            this.dstnApciClear_button.UseVisualStyleBackColor = true;
            this.dstnApciClear_button.Click += new System.EventHandler(this.dstnApciClear_button_Click);
            // 
            // dstnLsnClear_button
            // 
            this.dstnLsnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dstnLsnClear_button.BackgroundImage")));
            this.dstnLsnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dstnLsnClear_button.Enabled = false;
            this.dstnLsnClear_button.Location = new System.Drawing.Point(501, 16);
            this.dstnLsnClear_button.Name = "dstnLsnClear_button";
            this.dstnLsnClear_button.Size = new System.Drawing.Size(22, 22);
            this.dstnLsnClear_button.TabIndex = 287;
            this.dstnLsnClear_button.UseVisualStyleBackColor = true;
            this.dstnLsnClear_button.Click += new System.EventHandler(this.dstnLsnClear_button_Click);
            // 
            // dstnClliSearch_textBox
            // 
            this.dstnClliSearch_textBox.Location = new System.Drawing.Point(302, 17);
            this.dstnClliSearch_textBox.Name = "dstnClliSearch_textBox";
            this.dstnClliSearch_textBox.Size = new System.Drawing.Size(80, 20);
            this.dstnClliSearch_textBox.TabIndex = 283;
            this.dstnClliSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // dstnClli_listBox
            // 
            this.dstnClli_listBox.FormattingEnabled = true;
            this.dstnClli_listBox.Location = new System.Drawing.Point(302, 42);
            this.dstnClli_listBox.Name = "dstnClli_listBox";
            this.dstnClli_listBox.Size = new System.Drawing.Size(108, 69);
            this.dstnClli_listBox.TabIndex = 282;
            this.dstnClli_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // dstnApciSearch_textBox
            // 
            this.dstnApciSearch_textBox.Location = new System.Drawing.Point(634, 17);
            this.dstnApciSearch_textBox.Name = "dstnApciSearch_textBox";
            this.dstnApciSearch_textBox.Size = new System.Drawing.Size(54, 20);
            this.dstnApciSearch_textBox.TabIndex = 280;
            this.dstnApciSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // dstnApci_listBox
            // 
            this.dstnApci_listBox.FormattingEnabled = true;
            this.dstnApci_listBox.Location = new System.Drawing.Point(634, 42);
            this.dstnApci_listBox.Name = "dstnApci_listBox";
            this.dstnApci_listBox.Size = new System.Drawing.Size(82, 69);
            this.dstnApci_listBox.TabIndex = 279;
            this.dstnApci_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // dstnLsnSearch_textBox
            // 
            this.dstnLsnSearch_textBox.Location = new System.Drawing.Point(430, 17);
            this.dstnLsnSearch_textBox.Name = "dstnLsnSearch_textBox";
            this.dstnLsnSearch_textBox.Size = new System.Drawing.Size(66, 20);
            this.dstnLsnSearch_textBox.TabIndex = 277;
            this.dstnLsnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // dstnLsn_listBox
            // 
            this.dstnLsn_listBox.FormattingEnabled = true;
            this.dstnLsn_listBox.Location = new System.Drawing.Point(430, 42);
            this.dstnLsn_listBox.Name = "dstnLsn_listBox";
            this.dstnLsn_listBox.Size = new System.Drawing.Size(95, 69);
            this.dstnLsn_listBox.TabIndex = 276;
            this.dstnLsn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // dstnTypeSearch_textBox
            // 
            this.dstnTypeSearch_textBox.Location = new System.Drawing.Point(5, 17);
            this.dstnTypeSearch_textBox.Name = "dstnTypeSearch_textBox";
            this.dstnTypeSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.dstnTypeSearch_textBox.TabIndex = 274;
            this.dstnTypeSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // dstnType_listBox
            // 
            this.dstnType_listBox.FormattingEnabled = true;
            this.dstnType_listBox.Location = new System.Drawing.Point(5, 42);
            this.dstnType_listBox.Name = "dstnType_listBox";
            this.dstnType_listBox.Size = new System.Drawing.Size(84, 69);
            this.dstnType_listBox.TabIndex = 273;
            this.dstnType_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // dstnType_label
            // 
            this.dstnType_label.AutoSize = true;
            this.dstnType_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dstnType_label.Location = new System.Drawing.Point(3, 3);
            this.dstnType_label.Name = "dstnType_label";
            this.dstnType_label.Size = new System.Drawing.Size(25, 12);
            this.dstnType_label.TabIndex = 272;
            this.dstnType_label.Text = "Type";
            // 
            // dstnDpcSearch_textBox
            // 
            this.dstnDpcSearch_textBox.Location = new System.Drawing.Point(107, 17);
            this.dstnDpcSearch_textBox.Name = "dstnDpcSearch_textBox";
            this.dstnDpcSearch_textBox.Size = new System.Drawing.Size(50, 20);
            this.dstnDpcSearch_textBox.TabIndex = 268;
            this.dstnDpcSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // dstnDpc_listBox
            // 
            this.dstnDpc_listBox.FormattingEnabled = true;
            this.dstnDpc_listBox.Location = new System.Drawing.Point(107, 42);
            this.dstnDpc_listBox.Name = "dstnDpc_listBox";
            this.dstnDpc_listBox.Size = new System.Drawing.Size(78, 69);
            this.dstnDpc_listBox.TabIndex = 267;
            this.dstnDpc_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // search_dataGridView
            // 
            this.search_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.search_dataGridView.Location = new System.Drawing.Point(4, 121);
            this.search_dataGridView.Name = "search_dataGridView";
            this.search_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.search_dataGridView.Size = new System.Drawing.Size(814, 343);
            this.search_dataGridView.TabIndex = 265;
            this.search_dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.search_dataGridView_DataBindingComplete);
            // 
            // dstnRcClear_button
            // 
            this.dstnRcClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dstnRcClear_button.BackgroundImage")));
            this.dstnRcClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dstnRcClear_button.Enabled = false;
            this.dstnRcClear_button.Location = new System.Drawing.Point(594, 16);
            this.dstnRcClear_button.Name = "dstnRcClear_button";
            this.dstnRcClear_button.Size = new System.Drawing.Size(22, 22);
            this.dstnRcClear_button.TabIndex = 339;
            this.dstnRcClear_button.UseVisualStyleBackColor = true;
            this.dstnRcClear_button.Click += new System.EventHandler(this.dstnRcClear_button_Click);
            // 
            // dstnRcSearch_textBox
            // 
            this.dstnRcSearch_textBox.Location = new System.Drawing.Point(544, 17);
            this.dstnRcSearch_textBox.Name = "dstnRcSearch_textBox";
            this.dstnRcSearch_textBox.Size = new System.Drawing.Size(44, 20);
            this.dstnRcSearch_textBox.TabIndex = 338;
            // 
            // dstnRc_listBox
            // 
            this.dstnRc_listBox.FormattingEnabled = true;
            this.dstnRc_listBox.Location = new System.Drawing.Point(544, 42);
            this.dstnRc_listBox.Name = "dstnRc_listBox";
            this.dstnRc_listBox.Size = new System.Drawing.Size(72, 69);
            this.dstnRc_listBox.TabIndex = 337;
            this.dstnRc_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // dstnApciDecClear_button
            // 
            this.dstnApciDecClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dstnApciDecClear_button.BackgroundImage")));
            this.dstnApciDecClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dstnApciDecClear_button.Enabled = false;
            this.dstnApciDecClear_button.Location = new System.Drawing.Point(795, 16);
            this.dstnApciDecClear_button.Name = "dstnApciDecClear_button";
            this.dstnApciDecClear_button.Size = new System.Drawing.Size(22, 22);
            this.dstnApciDecClear_button.TabIndex = 343;
            this.dstnApciDecClear_button.UseVisualStyleBackColor = true;
            this.dstnApciDecClear_button.Click += new System.EventHandler(this.dstnApciDecClear_button_Click);
            // 
            // dstnApciDec_listBox
            // 
            this.dstnApciDec_listBox.FormattingEnabled = true;
            this.dstnApciDec_listBox.Location = new System.Drawing.Point(736, 42);
            this.dstnApciDec_listBox.Name = "dstnApciDec_listBox";
            this.dstnApciDec_listBox.Size = new System.Drawing.Size(82, 69);
            this.dstnApciDec_listBox.TabIndex = 341;
            this.dstnApciDec_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // dstnApciDecSearch_textBox
            // 
            this.dstnApciDecSearch_textBox.Location = new System.Drawing.Point(736, 17);
            this.dstnApciDecSearch_textBox.Name = "dstnApciDecSearch_textBox";
            this.dstnApciDecSearch_textBox.Size = new System.Drawing.Size(54, 20);
            this.dstnApciDecSearch_textBox.TabIndex = 342;
            // 
            // dstnDpc_linkLabel
            // 
            this.dstnDpc_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.dstnDpc_linkLabel.AutoSize = true;
            this.dstnDpc_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.dstnDpc_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dstnDpc_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnDpc_linkLabel.Location = new System.Drawing.Point(105, 3);
            this.dstnDpc_linkLabel.Name = "dstnDpc_linkLabel";
            this.dstnDpc_linkLabel.Size = new System.Drawing.Size(25, 12);
            this.dstnDpc_linkLabel.TabIndex = 344;
            this.dstnDpc_linkLabel.TabStop = true;
            this.dstnDpc_linkLabel.Text = "DPC";
            this.dstnDpc_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnDpc_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dstnDpc_linkLabel_LinkClicked);
            // 
            // dstnDpcDec_linkLabel
            // 
            this.dstnDpcDec_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.dstnDpcDec_linkLabel.AutoSize = true;
            this.dstnDpcDec_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.dstnDpcDec_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dstnDpcDec_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnDpcDec_linkLabel.Location = new System.Drawing.Point(202, 3);
            this.dstnDpcDec_linkLabel.Name = "dstnDpcDec_linkLabel";
            this.dstnDpcDec_linkLabel.Size = new System.Drawing.Size(44, 12);
            this.dstnDpcDec_linkLabel.TabIndex = 345;
            this.dstnDpcDec_linkLabel.TabStop = true;
            this.dstnDpcDec_linkLabel.Text = "DPC Dec";
            this.dstnDpcDec_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnDpcDec_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dstnDpcDec_linkLabel_LinkClicked);
            // 
            // dstnClli_linkLabel
            // 
            this.dstnClli_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.dstnClli_linkLabel.AutoSize = true;
            this.dstnClli_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.dstnClli_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dstnClli_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnClli_linkLabel.Location = new System.Drawing.Point(300, 3);
            this.dstnClli_linkLabel.Name = "dstnClli_linkLabel";
            this.dstnClli_linkLabel.Size = new System.Drawing.Size(25, 12);
            this.dstnClli_linkLabel.TabIndex = 346;
            this.dstnClli_linkLabel.TabStop = true;
            this.dstnClli_linkLabel.Text = "CLLI";
            this.dstnClli_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnClli_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dstnClli_linkLabel_LinkClicked);
            // 
            // dstnLsn_linkLabel
            // 
            this.dstnLsn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.dstnLsn_linkLabel.AutoSize = true;
            this.dstnLsn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.dstnLsn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dstnLsn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnLsn_linkLabel.Location = new System.Drawing.Point(427, 3);
            this.dstnLsn_linkLabel.Name = "dstnLsn_linkLabel";
            this.dstnLsn_linkLabel.Size = new System.Drawing.Size(23, 12);
            this.dstnLsn_linkLabel.TabIndex = 347;
            this.dstnLsn_linkLabel.TabStop = true;
            this.dstnLsn_linkLabel.Text = "LSN";
            this.dstnLsn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnLsn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dstnLsn_linkLabel_LinkClicked);
            // 
            // dstnRc_linkLabel
            // 
            this.dstnRc_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.dstnRc_linkLabel.AutoSize = true;
            this.dstnRc_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.dstnRc_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dstnRc_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnRc_linkLabel.Location = new System.Drawing.Point(542, 3);
            this.dstnRc_linkLabel.Name = "dstnRc_linkLabel";
            this.dstnRc_linkLabel.Size = new System.Drawing.Size(19, 12);
            this.dstnRc_linkLabel.TabIndex = 348;
            this.dstnRc_linkLabel.TabStop = true;
            this.dstnRc_linkLabel.Text = "RC";
            this.dstnRc_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnRc_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dstnRc_linkLabel_LinkClicked);
            // 
            // dstnApci_linkLabel
            // 
            this.dstnApci_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.dstnApci_linkLabel.AutoSize = true;
            this.dstnApci_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.dstnApci_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dstnApci_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnApci_linkLabel.Location = new System.Drawing.Point(632, 3);
            this.dstnApci_linkLabel.Name = "dstnApci_linkLabel";
            this.dstnApci_linkLabel.Size = new System.Drawing.Size(28, 12);
            this.dstnApci_linkLabel.TabIndex = 349;
            this.dstnApci_linkLabel.TabStop = true;
            this.dstnApci_linkLabel.Text = "APCI";
            this.dstnApci_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnApci_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dstnApci_linkLabel_LinkClicked);
            // 
            // dstnApciDec_linkLabel
            // 
            this.dstnApciDec_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.dstnApciDec_linkLabel.AutoSize = true;
            this.dstnApciDec_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.dstnApciDec_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.dstnApciDec_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnApciDec_linkLabel.Location = new System.Drawing.Point(734, 3);
            this.dstnApciDec_linkLabel.Name = "dstnApciDec_linkLabel";
            this.dstnApciDec_linkLabel.Size = new System.Drawing.Size(47, 12);
            this.dstnApciDec_linkLabel.TabIndex = 350;
            this.dstnApciDec_linkLabel.TabStop = true;
            this.dstnApciDec_linkLabel.Text = "APCI Dec";
            this.dstnApciDec_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.dstnApciDec_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dstnApciDec_linkLabel_LinkClicked);
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
            this.clear_button.TabIndex = 354;
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
            this.excel_button.TabIndex = 353;
            this.excel_button.Text = "  Generate Section Excel";
            this.excel_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.excel_button.UseVisualStyleBackColor = false;
            this.excel_button.Click += new System.EventHandler(this.excel_button_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.numRecords_label);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(544, 466);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(273, 35);
            this.flowLayoutPanel1.TabIndex = 355;
            // 
            // DSTN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.dstnApciDec_linkLabel);
            this.Controls.Add(this.dstnApci_linkLabel);
            this.Controls.Add(this.dstnRc_linkLabel);
            this.Controls.Add(this.dstnLsn_linkLabel);
            this.Controls.Add(this.dstnClli_linkLabel);
            this.Controls.Add(this.dstnDpcDec_linkLabel);
            this.Controls.Add(this.dstnDpc_linkLabel);
            this.Controls.Add(this.dstnApciDecClear_button);
            this.Controls.Add(this.dstnApciDec_listBox);
            this.Controls.Add(this.dstnApciDecSearch_textBox);
            this.Controls.Add(this.dstnRcClear_button);
            this.Controls.Add(this.dstnRcSearch_textBox);
            this.Controls.Add(this.dstnRc_listBox);
            this.Controls.Add(this.dstnDpcDecClear_button);
            this.Controls.Add(this.dstnDpcDecSearch_textBox);
            this.Controls.Add(this.dstnDpcDec_listBox);
            this.Controls.Add(this.search_dataGridView);
            this.Controls.Add(this.dstnDpc_listBox);
            this.Controls.Add(this.dstnDpcSearch_textBox);
            this.Controls.Add(this.dstnType_label);
            this.Controls.Add(this.dstnDpcClear_button);
            this.Controls.Add(this.dstnType_listBox);
            this.Controls.Add(this.dstnTypeSearch_textBox);
            this.Controls.Add(this.dstnTypeClear_button);
            this.Controls.Add(this.dstnClliClear_button);
            this.Controls.Add(this.dstnLsn_listBox);
            this.Controls.Add(this.dstnApciClear_button);
            this.Controls.Add(this.dstnLsnSearch_textBox);
            this.Controls.Add(this.dstnLsnClear_button);
            this.Controls.Add(this.dstnClliSearch_textBox);
            this.Controls.Add(this.dstnApci_listBox);
            this.Controls.Add(this.dstnClli_listBox);
            this.Controls.Add(this.dstnApciSearch_textBox);
            this.Name = "DSTN";
            this.Size = new System.Drawing.Size(876, 502);
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button dstnDpcDecClear_button;
        private System.Windows.Forms.TextBox dstnDpcDecSearch_textBox;
        private System.Windows.Forms.ListBox dstnDpcDec_listBox;
        private System.Windows.Forms.Button dstnDpcClear_button;
        private System.Windows.Forms.Button dstnTypeClear_button;
        private System.Windows.Forms.Button dstnClliClear_button;
        private System.Windows.Forms.Button dstnApciClear_button;
        private System.Windows.Forms.Button dstnLsnClear_button;
        private System.Windows.Forms.TextBox dstnClliSearch_textBox;
        private System.Windows.Forms.ListBox dstnClli_listBox;
        private System.Windows.Forms.TextBox dstnApciSearch_textBox;
        private System.Windows.Forms.ListBox dstnApci_listBox;
        private System.Windows.Forms.TextBox dstnLsnSearch_textBox;
        private System.Windows.Forms.ListBox dstnLsn_listBox;
        private System.Windows.Forms.TextBox dstnTypeSearch_textBox;
        private System.Windows.Forms.ListBox dstnType_listBox;
        private System.Windows.Forms.Label dstnType_label;
        private System.Windows.Forms.TextBox dstnDpcSearch_textBox;
        private System.Windows.Forms.ListBox dstnDpc_listBox;
        private System.Windows.Forms.DataGridView search_dataGridView;
        private System.Windows.Forms.Label numRecords_label;
        private System.Windows.Forms.Button dstnRcClear_button;
        private System.Windows.Forms.TextBox dstnRcSearch_textBox;
        private System.Windows.Forms.ListBox dstnRc_listBox;
        private System.Windows.Forms.Button dstnApciDecClear_button;
        private System.Windows.Forms.ListBox dstnApciDec_listBox;
        private System.Windows.Forms.TextBox dstnApciDecSearch_textBox;
        private System.Windows.Forms.LinkLabel dstnDpc_linkLabel;
        private System.Windows.Forms.LinkLabel dstnDpcDec_linkLabel;
        private System.Windows.Forms.LinkLabel dstnClli_linkLabel;
        private System.Windows.Forms.LinkLabel dstnLsn_linkLabel;
        private System.Windows.Forms.LinkLabel dstnRc_linkLabel;
        private System.Windows.Forms.LinkLabel dstnApci_linkLabel;
        private System.Windows.Forms.LinkLabel dstnApciDec_linkLabel;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
