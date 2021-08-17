namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    partial class SLK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SLK));
            this.numRecords_label = new System.Windows.Forms.Label();
            this.slkLsnClear_button = new System.Windows.Forms.Button();
            this.slkLsnSearch_textBox = new System.Windows.Forms.TextBox();
            this.slkLsn_listBox = new System.Windows.Forms.ListBox();
            this.slkLinkClear_button = new System.Windows.Forms.Button();
            this.slkLocClear_button = new System.Windows.Forms.Button();
            this.slkSlcClear_button = new System.Windows.Forms.Button();
            this.slkKtpsClear_button = new System.Windows.Forms.Button();
            this.slkTypeClear_button = new System.Windows.Forms.Button();
            this.slkSlcSearch_textBox = new System.Windows.Forms.TextBox();
            this.slkSlc_listBox = new System.Windows.Forms.ListBox();
            this.slkKtpsSearch_textBox = new System.Windows.Forms.TextBox();
            this.slkKtps_listBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.slkTypeSearch_textBox = new System.Windows.Forms.TextBox();
            this.slkType_listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.slkLocSearch_textBox = new System.Windows.Forms.TextBox();
            this.slkLoc_listBox = new System.Windows.Forms.ListBox();
            this.slkLinkSearch_textBox = new System.Windows.Forms.TextBox();
            this.slkLink_listBox = new System.Windows.Forms.ListBox();
            this.search_dataGridView = new System.Windows.Forms.DataGridView();
            this.slkAnameClear_button = new System.Windows.Forms.Button();
            this.slkAnameSearch_textBox = new System.Windows.Forms.TextBox();
            this.slkAname_listBox = new System.Windows.Forms.ListBox();
            this.slkMaxClear_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.slkMax_listBox = new System.Windows.Forms.ListBox();
            this.slkMaxSearch_textBox = new System.Windows.Forms.TextBox();
            this.slkLoc_linkLabel = new System.Windows.Forms.LinkLabel();
            this.slkLink_linkLabel = new System.Windows.Forms.LinkLabel();
            this.slkLsn_linkLabel = new System.Windows.Forms.LinkLabel();
            this.slkSlc_linkLabel = new System.Windows.Forms.LinkLabel();
            this.slkAname_linkLabel = new System.Windows.Forms.LinkLabel();
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
            this.numRecords_label.Location = new System.Drawing.Point(317, 0);
            this.numRecords_label.Name = "numRecords_label";
            this.numRecords_label.Size = new System.Drawing.Size(111, 12);
            this.numRecords_label.TabIndex = 335;
            this.numRecords_label.Text = "Number of records: 15000";
            this.numRecords_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slkLsnClear_button
            // 
            this.slkLsnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("slkLsnClear_button.BackgroundImage")));
            this.slkLsnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.slkLsnClear_button.Enabled = false;
            this.slkLsnClear_button.Location = new System.Drawing.Point(290, 15);
            this.slkLsnClear_button.Name = "slkLsnClear_button";
            this.slkLsnClear_button.Size = new System.Drawing.Size(22, 22);
            this.slkLsnClear_button.TabIndex = 300;
            this.slkLsnClear_button.UseVisualStyleBackColor = true;
            this.slkLsnClear_button.Click += new System.EventHandler(this.slkLsnClear_button_Click);
            // 
            // slkLsnSearch_textBox
            // 
            this.slkLsnSearch_textBox.Location = new System.Drawing.Point(195, 16);
            this.slkLsnSearch_textBox.Name = "slkLsnSearch_textBox";
            this.slkLsnSearch_textBox.Size = new System.Drawing.Size(89, 20);
            this.slkLsnSearch_textBox.TabIndex = 299;
            this.slkLsnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // slkLsn_listBox
            // 
            this.slkLsn_listBox.FormattingEnabled = true;
            this.slkLsn_listBox.Location = new System.Drawing.Point(195, 41);
            this.slkLsn_listBox.Name = "slkLsn_listBox";
            this.slkLsn_listBox.Size = new System.Drawing.Size(117, 69);
            this.slkLsn_listBox.TabIndex = 298;
            this.slkLsn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // slkLinkClear_button
            // 
            this.slkLinkClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("slkLinkClear_button.BackgroundImage")));
            this.slkLinkClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.slkLinkClear_button.Enabled = false;
            this.slkLinkClear_button.Location = new System.Drawing.Point(154, 14);
            this.slkLinkClear_button.Name = "slkLinkClear_button";
            this.slkLinkClear_button.Size = new System.Drawing.Size(22, 22);
            this.slkLinkClear_button.TabIndex = 292;
            this.slkLinkClear_button.UseVisualStyleBackColor = true;
            this.slkLinkClear_button.Click += new System.EventHandler(this.slkLinkClear_button_Click);
            // 
            // slkLocClear_button
            // 
            this.slkLocClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("slkLocClear_button.BackgroundImage")));
            this.slkLocClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.slkLocClear_button.Enabled = false;
            this.slkLocClear_button.Location = new System.Drawing.Point(65, 15);
            this.slkLocClear_button.Name = "slkLocClear_button";
            this.slkLocClear_button.Size = new System.Drawing.Size(22, 22);
            this.slkLocClear_button.TabIndex = 290;
            this.slkLocClear_button.UseVisualStyleBackColor = true;
            this.slkLocClear_button.Click += new System.EventHandler(this.slkLocClear_button_Click);
            // 
            // slkSlcClear_button
            // 
            this.slkSlcClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("slkSlcClear_button.BackgroundImage")));
            this.slkSlcClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.slkSlcClear_button.Enabled = false;
            this.slkSlcClear_button.Location = new System.Drawing.Point(382, 15);
            this.slkSlcClear_button.Name = "slkSlcClear_button";
            this.slkSlcClear_button.Size = new System.Drawing.Size(22, 22);
            this.slkSlcClear_button.TabIndex = 289;
            this.slkSlcClear_button.UseVisualStyleBackColor = true;
            this.slkSlcClear_button.Click += new System.EventHandler(this.slkSlcClear_button_Click);
            // 
            // slkKtpsClear_button
            // 
            this.slkKtpsClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("slkKtpsClear_button.BackgroundImage")));
            this.slkKtpsClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.slkKtpsClear_button.Enabled = false;
            this.slkKtpsClear_button.Location = new System.Drawing.Point(730, 15);
            this.slkKtpsClear_button.Name = "slkKtpsClear_button";
            this.slkKtpsClear_button.Size = new System.Drawing.Size(22, 22);
            this.slkKtpsClear_button.TabIndex = 288;
            this.slkKtpsClear_button.UseVisualStyleBackColor = true;
            this.slkKtpsClear_button.Click += new System.EventHandler(this.slkKtpsClear_button_Click);
            // 
            // slkTypeClear_button
            // 
            this.slkTypeClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("slkTypeClear_button.BackgroundImage")));
            this.slkTypeClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.slkTypeClear_button.Enabled = false;
            this.slkTypeClear_button.Location = new System.Drawing.Point(485, 16);
            this.slkTypeClear_button.Name = "slkTypeClear_button";
            this.slkTypeClear_button.Size = new System.Drawing.Size(22, 22);
            this.slkTypeClear_button.TabIndex = 287;
            this.slkTypeClear_button.UseVisualStyleBackColor = true;
            this.slkTypeClear_button.Click += new System.EventHandler(this.slkTypeClear_button_Click);
            // 
            // slkSlcSearch_textBox
            // 
            this.slkSlcSearch_textBox.Location = new System.Drawing.Point(332, 16);
            this.slkSlcSearch_textBox.Name = "slkSlcSearch_textBox";
            this.slkSlcSearch_textBox.Size = new System.Drawing.Size(44, 20);
            this.slkSlcSearch_textBox.TabIndex = 283;
            this.slkSlcSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // slkSlc_listBox
            // 
            this.slkSlc_listBox.FormattingEnabled = true;
            this.slkSlc_listBox.Location = new System.Drawing.Point(332, 41);
            this.slkSlc_listBox.Name = "slkSlc_listBox";
            this.slkSlc_listBox.Size = new System.Drawing.Size(72, 69);
            this.slkSlc_listBox.TabIndex = 282;
            this.slkSlc_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // slkKtpsSearch_textBox
            // 
            this.slkKtpsSearch_textBox.Location = new System.Drawing.Point(683, 16);
            this.slkKtpsSearch_textBox.Name = "slkKtpsSearch_textBox";
            this.slkKtpsSearch_textBox.Size = new System.Drawing.Size(41, 20);
            this.slkKtpsSearch_textBox.TabIndex = 280;
            this.slkKtpsSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // slkKtps_listBox
            // 
            this.slkKtps_listBox.FormattingEnabled = true;
            this.slkKtps_listBox.Location = new System.Drawing.Point(683, 41);
            this.slkKtps_listBox.Name = "slkKtps_listBox";
            this.slkKtps_listBox.Size = new System.Drawing.Size(69, 69);
            this.slkKtps_listBox.TabIndex = 279;
            this.slkKtps_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(681, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 12);
            this.label2.TabIndex = 278;
            this.label2.Text = "SLKTPS";
            // 
            // slkTypeSearch_textBox
            // 
            this.slkTypeSearch_textBox.Location = new System.Drawing.Point(425, 16);
            this.slkTypeSearch_textBox.Name = "slkTypeSearch_textBox";
            this.slkTypeSearch_textBox.Size = new System.Drawing.Size(54, 20);
            this.slkTypeSearch_textBox.TabIndex = 277;
            this.slkTypeSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // slkType_listBox
            // 
            this.slkType_listBox.FormattingEnabled = true;
            this.slkType_listBox.Location = new System.Drawing.Point(425, 41);
            this.slkType_listBox.Name = "slkType_listBox";
            this.slkType_listBox.Size = new System.Drawing.Size(95, 69);
            this.slkType_listBox.TabIndex = 276;
            this.slkType_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(422, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 12);
            this.label1.TabIndex = 275;
            this.label1.Text = "Type";
            // 
            // slkLocSearch_textBox
            // 
            this.slkLocSearch_textBox.Location = new System.Drawing.Point(3, 16);
            this.slkLocSearch_textBox.Name = "slkLocSearch_textBox";
            this.slkLocSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.slkLocSearch_textBox.TabIndex = 274;
            this.slkLocSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // slkLoc_listBox
            // 
            this.slkLoc_listBox.FormattingEnabled = true;
            this.slkLoc_listBox.Location = new System.Drawing.Point(3, 41);
            this.slkLoc_listBox.Name = "slkLoc_listBox";
            this.slkLoc_listBox.Size = new System.Drawing.Size(84, 69);
            this.slkLoc_listBox.TabIndex = 273;
            this.slkLoc_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // slkLinkSearch_textBox
            // 
            this.slkLinkSearch_textBox.Location = new System.Drawing.Point(105, 16);
            this.slkLinkSearch_textBox.Name = "slkLinkSearch_textBox";
            this.slkLinkSearch_textBox.Size = new System.Drawing.Size(43, 20);
            this.slkLinkSearch_textBox.TabIndex = 268;
            this.slkLinkSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // slkLink_listBox
            // 
            this.slkLink_listBox.FormattingEnabled = true;
            this.slkLink_listBox.Location = new System.Drawing.Point(105, 41);
            this.slkLink_listBox.Name = "slkLink_listBox";
            this.slkLink_listBox.Size = new System.Drawing.Size(71, 69);
            this.slkLink_listBox.TabIndex = 267;
            this.slkLink_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // search_dataGridView
            // 
            this.search_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.search_dataGridView.Location = new System.Drawing.Point(3, 120);
            this.search_dataGridView.Name = "search_dataGridView";
            this.search_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.search_dataGridView.Size = new System.Drawing.Size(854, 343);
            this.search_dataGridView.TabIndex = 265;
            this.search_dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.search_dataGridView_DataBindingComplete);
            // 
            // slkAnameClear_button
            // 
            this.slkAnameClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("slkAnameClear_button.BackgroundImage")));
            this.slkAnameClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.slkAnameClear_button.Enabled = false;
            this.slkAnameClear_button.Location = new System.Drawing.Point(644, 15);
            this.slkAnameClear_button.Name = "slkAnameClear_button";
            this.slkAnameClear_button.Size = new System.Drawing.Size(22, 22);
            this.slkAnameClear_button.TabIndex = 339;
            this.slkAnameClear_button.UseVisualStyleBackColor = true;
            this.slkAnameClear_button.Click += new System.EventHandler(this.slkAnameClear_button_Click);
            // 
            // slkAnameSearch_textBox
            // 
            this.slkAnameSearch_textBox.Location = new System.Drawing.Point(540, 16);
            this.slkAnameSearch_textBox.Name = "slkAnameSearch_textBox";
            this.slkAnameSearch_textBox.Size = new System.Drawing.Size(98, 20);
            this.slkAnameSearch_textBox.TabIndex = 338;
            this.slkAnameSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // slkAname_listBox
            // 
            this.slkAname_listBox.FormattingEnabled = true;
            this.slkAname_listBox.Location = new System.Drawing.Point(540, 41);
            this.slkAname_listBox.Name = "slkAname_listBox";
            this.slkAname_listBox.Size = new System.Drawing.Size(126, 69);
            this.slkAname_listBox.TabIndex = 337;
            this.slkAname_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // slkMaxClear_button
            // 
            this.slkMaxClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("slkMaxClear_button.BackgroundImage")));
            this.slkMaxClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.slkMaxClear_button.Enabled = false;
            this.slkMaxClear_button.Location = new System.Drawing.Point(832, 15);
            this.slkMaxClear_button.Name = "slkMaxClear_button";
            this.slkMaxClear_button.Size = new System.Drawing.Size(22, 22);
            this.slkMaxClear_button.TabIndex = 343;
            this.slkMaxClear_button.UseVisualStyleBackColor = true;
            this.slkMaxClear_button.Click += new System.EventHandler(this.slkMaxClear_button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(771, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 12);
            this.label6.TabIndex = 340;
            this.label6.Text = "MAXSLKTPS";
            // 
            // slkMax_listBox
            // 
            this.slkMax_listBox.FormattingEnabled = true;
            this.slkMax_listBox.Location = new System.Drawing.Point(773, 41);
            this.slkMax_listBox.Name = "slkMax_listBox";
            this.slkMax_listBox.Size = new System.Drawing.Size(82, 69);
            this.slkMax_listBox.TabIndex = 341;
            this.slkMax_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // slkMaxSearch_textBox
            // 
            this.slkMaxSearch_textBox.Location = new System.Drawing.Point(773, 16);
            this.slkMaxSearch_textBox.Name = "slkMaxSearch_textBox";
            this.slkMaxSearch_textBox.Size = new System.Drawing.Size(54, 20);
            this.slkMaxSearch_textBox.TabIndex = 342;
            this.slkMaxSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // slkLoc_linkLabel
            // 
            this.slkLoc_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.slkLoc_linkLabel.AutoSize = true;
            this.slkLoc_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.slkLoc_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.slkLoc_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.slkLoc_linkLabel.Location = new System.Drawing.Point(1, 2);
            this.slkLoc_linkLabel.Name = "slkLoc_linkLabel";
            this.slkLoc_linkLabel.Size = new System.Drawing.Size(24, 12);
            this.slkLoc_linkLabel.TabIndex = 344;
            this.slkLoc_linkLabel.TabStop = true;
            this.slkLoc_linkLabel.Text = "LOC";
            this.slkLoc_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.slkLoc_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.slkLoc_linkLabel_LinkClicked);
            // 
            // slkLink_linkLabel
            // 
            this.slkLink_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.slkLink_linkLabel.AutoSize = true;
            this.slkLink_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.slkLink_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.slkLink_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.slkLink_linkLabel.Location = new System.Drawing.Point(103, 2);
            this.slkLink_linkLabel.Name = "slkLink_linkLabel";
            this.slkLink_linkLabel.Size = new System.Drawing.Size(26, 12);
            this.slkLink_linkLabel.TabIndex = 345;
            this.slkLink_linkLabel.TabStop = true;
            this.slkLink_linkLabel.Text = "LINK";
            this.slkLink_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.slkLink_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.slkLink_linkLabel_LinkClicked);
            // 
            // slkLsn_linkLabel
            // 
            this.slkLsn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.slkLsn_linkLabel.AutoSize = true;
            this.slkLsn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.slkLsn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.slkLsn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.slkLsn_linkLabel.Location = new System.Drawing.Point(193, 2);
            this.slkLsn_linkLabel.Name = "slkLsn_linkLabel";
            this.slkLsn_linkLabel.Size = new System.Drawing.Size(23, 12);
            this.slkLsn_linkLabel.TabIndex = 346;
            this.slkLsn_linkLabel.TabStop = true;
            this.slkLsn_linkLabel.Text = "LSN";
            this.slkLsn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.slkLsn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.slkLsn_linkLabel_LinkClicked);
            // 
            // slkSlc_linkLabel
            // 
            this.slkSlc_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.slkSlc_linkLabel.AutoSize = true;
            this.slkSlc_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.slkSlc_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.slkSlc_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.slkSlc_linkLabel.Location = new System.Drawing.Point(330, 2);
            this.slkSlc_linkLabel.Name = "slkSlc_linkLabel";
            this.slkSlc_linkLabel.Size = new System.Drawing.Size(23, 12);
            this.slkSlc_linkLabel.TabIndex = 347;
            this.slkSlc_linkLabel.TabStop = true;
            this.slkSlc_linkLabel.Text = "SLC";
            this.slkSlc_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.slkSlc_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.slkSlc_linkLabel_LinkClicked);
            // 
            // slkAname_linkLabel
            // 
            this.slkAname_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.slkAname_linkLabel.AutoSize = true;
            this.slkAname_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.slkAname_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.slkAname_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.slkAname_linkLabel.Location = new System.Drawing.Point(538, 2);
            this.slkAname_linkLabel.Name = "slkAname_linkLabel";
            this.slkAname_linkLabel.Size = new System.Drawing.Size(41, 12);
            this.slkAname_linkLabel.TabIndex = 348;
            this.slkAname_linkLabel.TabStop = true;
            this.slkAname_linkLabel.Text = "ANAME";
            this.slkAname_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.slkAname_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.slkAname_linkLabel_LinkClicked);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(425, 466);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(431, 35);
            this.flowLayoutPanel1.TabIndex = 355;
            // 
            // SLK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.slkAname_linkLabel);
            this.Controls.Add(this.slkSlc_linkLabel);
            this.Controls.Add(this.slkLsn_linkLabel);
            this.Controls.Add(this.slkLink_linkLabel);
            this.Controls.Add(this.slkLoc_linkLabel);
            this.Controls.Add(this.slkMaxClear_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.slkMax_listBox);
            this.Controls.Add(this.slkMaxSearch_textBox);
            this.Controls.Add(this.slkAnameClear_button);
            this.Controls.Add(this.slkAnameSearch_textBox);
            this.Controls.Add(this.slkAname_listBox);
            this.Controls.Add(this.slkLsnClear_button);
            this.Controls.Add(this.slkLsnSearch_textBox);
            this.Controls.Add(this.slkLsn_listBox);
            this.Controls.Add(this.search_dataGridView);
            this.Controls.Add(this.slkLink_listBox);
            this.Controls.Add(this.slkLinkSearch_textBox);
            this.Controls.Add(this.slkLinkClear_button);
            this.Controls.Add(this.slkLoc_listBox);
            this.Controls.Add(this.slkLocSearch_textBox);
            this.Controls.Add(this.slkLocClear_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slkSlcClear_button);
            this.Controls.Add(this.slkType_listBox);
            this.Controls.Add(this.slkKtpsClear_button);
            this.Controls.Add(this.slkTypeSearch_textBox);
            this.Controls.Add(this.slkTypeClear_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.slkSlcSearch_textBox);
            this.Controls.Add(this.slkKtps_listBox);
            this.Controls.Add(this.slkSlc_listBox);
            this.Controls.Add(this.slkKtpsSearch_textBox);
            this.Name = "SLK";
            this.Size = new System.Drawing.Size(876, 502);
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button slkLsnClear_button;
        private System.Windows.Forms.TextBox slkLsnSearch_textBox;
        private System.Windows.Forms.ListBox slkLsn_listBox;
        private System.Windows.Forms.Button slkLinkClear_button;
        private System.Windows.Forms.Button slkLocClear_button;
        private System.Windows.Forms.Button slkSlcClear_button;
        private System.Windows.Forms.Button slkKtpsClear_button;
        private System.Windows.Forms.Button slkTypeClear_button;
        private System.Windows.Forms.TextBox slkSlcSearch_textBox;
        private System.Windows.Forms.ListBox slkSlc_listBox;
        private System.Windows.Forms.TextBox slkKtpsSearch_textBox;
        private System.Windows.Forms.ListBox slkKtps_listBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox slkTypeSearch_textBox;
        private System.Windows.Forms.ListBox slkType_listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox slkLocSearch_textBox;
        private System.Windows.Forms.ListBox slkLoc_listBox;
        private System.Windows.Forms.TextBox slkLinkSearch_textBox;
        private System.Windows.Forms.ListBox slkLink_listBox;
        private System.Windows.Forms.DataGridView search_dataGridView;
        private System.Windows.Forms.Label numRecords_label;
        private System.Windows.Forms.Button slkAnameClear_button;
        private System.Windows.Forms.TextBox slkAnameSearch_textBox;
        private System.Windows.Forms.ListBox slkAname_listBox;
        private System.Windows.Forms.Button slkMaxClear_button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox slkMax_listBox;
        private System.Windows.Forms.TextBox slkMaxSearch_textBox;
        private System.Windows.Forms.LinkLabel slkLoc_linkLabel;
        private System.Windows.Forms.LinkLabel slkLink_linkLabel;
        private System.Windows.Forms.LinkLabel slkLsn_linkLabel;
        private System.Windows.Forms.LinkLabel slkSlc_linkLabel;
        private System.Windows.Forms.LinkLabel slkAname_linkLabel;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
