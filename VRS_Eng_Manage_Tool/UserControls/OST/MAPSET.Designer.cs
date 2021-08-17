namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    partial class MAPSET
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAPSET));
            this.numRecords_label = new System.Windows.Forms.Label();
            this.mapsetMultClear_button = new System.Windows.Forms.Button();
            this.mapsetMultSearch_textBox = new System.Windows.Forms.TextBox();
            this.mapsetMult_listBox = new System.Windows.Forms.ListBox();
            this.mapsetSsnClear_button = new System.Windows.Forms.Button();
            this.mapsetClear_button = new System.Windows.Forms.Button();
            this.mapsetRcClear_button = new System.Windows.Forms.Button();
            this.mapsetPcnClear_button = new System.Windows.Forms.Button();
            this.mapsetRcSearch_textBox = new System.Windows.Forms.TextBox();
            this.mapsetRc_listBox = new System.Windows.Forms.ListBox();
            this.mapsetPcnSearch_textBox = new System.Windows.Forms.TextBox();
            this.mapsetPcn_listBox = new System.Windows.Forms.ListBox();
            this.mapsetSearch_textBox = new System.Windows.Forms.TextBox();
            this.mapset_listBox = new System.Windows.Forms.ListBox();
            this.mapsetSsnSearch_textBox = new System.Windows.Forms.TextBox();
            this.mapsetSsn_listBox = new System.Windows.Forms.ListBox();
            this.search_dataGridView = new System.Windows.Forms.DataGridView();
            this.mapset_linkLabel = new System.Windows.Forms.LinkLabel();
            this.mapsetMult_linkLabel = new System.Windows.Forms.LinkLabel();
            this.mapsetRc_linkLabel = new System.Windows.Forms.LinkLabel();
            this.mapsetPcn_linkLabel = new System.Windows.Forms.LinkLabel();
            this.clear_button = new System.Windows.Forms.Button();
            this.excel_button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mapsetMatePcnSearch_textBox = new System.Windows.Forms.TextBox();
            this.mapsetMatePcn_listBox = new System.Windows.Forms.ListBox();
            this.mapsetMatePcnClear_button = new System.Windows.Forms.Button();
            this.mapsetMatePcn_linkLabel = new System.Windows.Forms.LinkLabel();
            this.mapsetSsn_linkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numRecords_label
            // 
            this.numRecords_label.AutoSize = true;
            this.numRecords_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRecords_label.Location = new System.Drawing.Point(207, 0);
            this.numRecords_label.Name = "numRecords_label";
            this.numRecords_label.Size = new System.Drawing.Size(111, 12);
            this.numRecords_label.TabIndex = 335;
            this.numRecords_label.Text = "Number of records: 15000";
            this.numRecords_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mapsetMultClear_button
            // 
            this.mapsetMultClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mapsetMultClear_button.BackgroundImage")));
            this.mapsetMultClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapsetMultClear_button.Enabled = false;
            this.mapsetMultClear_button.Location = new System.Drawing.Point(556, 15);
            this.mapsetMultClear_button.Name = "mapsetMultClear_button";
            this.mapsetMultClear_button.Size = new System.Drawing.Size(22, 22);
            this.mapsetMultClear_button.TabIndex = 300;
            this.mapsetMultClear_button.UseVisualStyleBackColor = true;
            this.mapsetMultClear_button.Click += new System.EventHandler(this.mapsetMultClear_button_Click);
            // 
            // mapsetMultSearch_textBox
            // 
            this.mapsetMultSearch_textBox.Location = new System.Drawing.Point(494, 16);
            this.mapsetMultSearch_textBox.Name = "mapsetMultSearch_textBox";
            this.mapsetMultSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.mapsetMultSearch_textBox.TabIndex = 299;
            this.mapsetMultSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mapsetMult_listBox
            // 
            this.mapsetMult_listBox.FormattingEnabled = true;
            this.mapsetMult_listBox.Location = new System.Drawing.Point(494, 41);
            this.mapsetMult_listBox.Name = "mapsetMult_listBox";
            this.mapsetMult_listBox.Size = new System.Drawing.Size(84, 69);
            this.mapsetMult_listBox.TabIndex = 298;
            this.mapsetMult_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // mapsetSsnClear_button
            // 
            this.mapsetSsnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mapsetSsnClear_button.BackgroundImage")));
            this.mapsetSsnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapsetSsnClear_button.Enabled = false;
            this.mapsetSsnClear_button.Location = new System.Drawing.Point(361, 13);
            this.mapsetSsnClear_button.Name = "mapsetSsnClear_button";
            this.mapsetSsnClear_button.Size = new System.Drawing.Size(22, 22);
            this.mapsetSsnClear_button.TabIndex = 292;
            this.mapsetSsnClear_button.UseVisualStyleBackColor = true;
            this.mapsetSsnClear_button.Click += new System.EventHandler(this.mapsetSsnClear_button_Click);
            // 
            // mapsetClear_button
            // 
            this.mapsetClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mapsetClear_button.BackgroundImage")));
            this.mapsetClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapsetClear_button.Enabled = false;
            this.mapsetClear_button.Location = new System.Drawing.Point(65, 15);
            this.mapsetClear_button.Name = "mapsetClear_button";
            this.mapsetClear_button.Size = new System.Drawing.Size(22, 22);
            this.mapsetClear_button.TabIndex = 290;
            this.mapsetClear_button.UseVisualStyleBackColor = true;
            this.mapsetClear_button.Click += new System.EventHandler(this.mapsetClear_button_Click);
            // 
            // mapsetRcClear_button
            // 
            this.mapsetRcClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mapsetRcClear_button.BackgroundImage")));
            this.mapsetRcClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapsetRcClear_button.Enabled = false;
            this.mapsetRcClear_button.Location = new System.Drawing.Point(452, 14);
            this.mapsetRcClear_button.Name = "mapsetRcClear_button";
            this.mapsetRcClear_button.Size = new System.Drawing.Size(22, 22);
            this.mapsetRcClear_button.TabIndex = 289;
            this.mapsetRcClear_button.UseVisualStyleBackColor = true;
            this.mapsetRcClear_button.Click += new System.EventHandler(this.mapsetRcClear_button_Click);
            // 
            // mapsetPcnClear_button
            // 
            this.mapsetPcnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mapsetPcnClear_button.BackgroundImage")));
            this.mapsetPcnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapsetPcnClear_button.Enabled = false;
            this.mapsetPcnClear_button.Location = new System.Drawing.Point(167, 15);
            this.mapsetPcnClear_button.Name = "mapsetPcnClear_button";
            this.mapsetPcnClear_button.Size = new System.Drawing.Size(22, 22);
            this.mapsetPcnClear_button.TabIndex = 287;
            this.mapsetPcnClear_button.UseVisualStyleBackColor = true;
            this.mapsetPcnClear_button.Click += new System.EventHandler(this.mapsetPcnClear_button_Click);
            // 
            // mapsetRcSearch_textBox
            // 
            this.mapsetRcSearch_textBox.Location = new System.Drawing.Point(402, 15);
            this.mapsetRcSearch_textBox.Name = "mapsetRcSearch_textBox";
            this.mapsetRcSearch_textBox.Size = new System.Drawing.Size(44, 20);
            this.mapsetRcSearch_textBox.TabIndex = 283;
            this.mapsetRcSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mapsetRc_listBox
            // 
            this.mapsetRc_listBox.FormattingEnabled = true;
            this.mapsetRc_listBox.Location = new System.Drawing.Point(402, 40);
            this.mapsetRc_listBox.Name = "mapsetRc_listBox";
            this.mapsetRc_listBox.Size = new System.Drawing.Size(72, 69);
            this.mapsetRc_listBox.TabIndex = 282;
            this.mapsetRc_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // mapsetPcnSearch_textBox
            // 
            this.mapsetPcnSearch_textBox.Location = new System.Drawing.Point(107, 16);
            this.mapsetPcnSearch_textBox.Name = "mapsetPcnSearch_textBox";
            this.mapsetPcnSearch_textBox.Size = new System.Drawing.Size(54, 20);
            this.mapsetPcnSearch_textBox.TabIndex = 277;
            this.mapsetPcnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mapsetPcn_listBox
            // 
            this.mapsetPcn_listBox.FormattingEnabled = true;
            this.mapsetPcn_listBox.Location = new System.Drawing.Point(107, 41);
            this.mapsetPcn_listBox.Name = "mapsetPcn_listBox";
            this.mapsetPcn_listBox.Size = new System.Drawing.Size(82, 69);
            this.mapsetPcn_listBox.TabIndex = 276;
            this.mapsetPcn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // mapsetSearch_textBox
            // 
            this.mapsetSearch_textBox.Location = new System.Drawing.Point(3, 16);
            this.mapsetSearch_textBox.Name = "mapsetSearch_textBox";
            this.mapsetSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.mapsetSearch_textBox.TabIndex = 274;
            this.mapsetSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mapset_listBox
            // 
            this.mapset_listBox.FormattingEnabled = true;
            this.mapset_listBox.Location = new System.Drawing.Point(3, 41);
            this.mapset_listBox.Name = "mapset_listBox";
            this.mapset_listBox.Size = new System.Drawing.Size(84, 69);
            this.mapset_listBox.TabIndex = 273;
            this.mapset_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // mapsetSsnSearch_textBox
            // 
            this.mapsetSsnSearch_textBox.Location = new System.Drawing.Point(312, 15);
            this.mapsetSsnSearch_textBox.Name = "mapsetSsnSearch_textBox";
            this.mapsetSsnSearch_textBox.Size = new System.Drawing.Size(43, 20);
            this.mapsetSsnSearch_textBox.TabIndex = 268;
            this.mapsetSsnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mapsetSsn_listBox
            // 
            this.mapsetSsn_listBox.FormattingEnabled = true;
            this.mapsetSsn_listBox.Location = new System.Drawing.Point(312, 40);
            this.mapsetSsn_listBox.Name = "mapsetSsn_listBox";
            this.mapsetSsn_listBox.Size = new System.Drawing.Size(71, 69);
            this.mapsetSsn_listBox.TabIndex = 267;
            this.mapsetSsn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // search_dataGridView
            // 
            this.search_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.search_dataGridView.Location = new System.Drawing.Point(2, 120);
            this.search_dataGridView.Name = "search_dataGridView";
            this.search_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.search_dataGridView.Size = new System.Drawing.Size(634, 343);
            this.search_dataGridView.TabIndex = 265;
            this.search_dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.search_dataGridView_DataBindingComplete);
            // 
            // mapset_linkLabel
            // 
            this.mapset_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.mapset_linkLabel.AutoSize = true;
            this.mapset_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.mapset_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.mapset_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.mapset_linkLabel.Location = new System.Drawing.Point(1, 2);
            this.mapset_linkLabel.Name = "mapset_linkLabel";
            this.mapset_linkLabel.Size = new System.Drawing.Size(44, 12);
            this.mapset_linkLabel.TabIndex = 338;
            this.mapset_linkLabel.TabStop = true;
            this.mapset_linkLabel.Text = "MAPSET";
            this.mapset_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.mapset_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mapset_linkLabel_LinkClicked);
            // 
            // mapsetMult_linkLabel
            // 
            this.mapsetMult_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.mapsetMult_linkLabel.AutoSize = true;
            this.mapsetMult_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.mapsetMult_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.mapsetMult_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.mapsetMult_linkLabel.Location = new System.Drawing.Point(492, 2);
            this.mapsetMult_linkLabel.Name = "mapsetMult_linkLabel";
            this.mapsetMult_linkLabel.Size = new System.Drawing.Size(31, 12);
            this.mapsetMult_linkLabel.TabIndex = 343;
            this.mapsetMult_linkLabel.TabStop = true;
            this.mapsetMult_linkLabel.Text = "MULT";
            this.mapsetMult_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.mapsetMult_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mapsetMult_linkLabel_LinkClicked);
            // 
            // mapsetRc_linkLabel
            // 
            this.mapsetRc_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.mapsetRc_linkLabel.AutoSize = true;
            this.mapsetRc_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.mapsetRc_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.mapsetRc_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.mapsetRc_linkLabel.Location = new System.Drawing.Point(400, 1);
            this.mapsetRc_linkLabel.Name = "mapsetRc_linkLabel";
            this.mapsetRc_linkLabel.Size = new System.Drawing.Size(19, 12);
            this.mapsetRc_linkLabel.TabIndex = 344;
            this.mapsetRc_linkLabel.TabStop = true;
            this.mapsetRc_linkLabel.Text = "RC";
            this.mapsetRc_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.mapsetRc_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mapsetRc_linkLabel_LinkClicked);
            // 
            // mapsetPcn_linkLabel
            // 
            this.mapsetPcn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.mapsetPcn_linkLabel.AutoSize = true;
            this.mapsetPcn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.mapsetPcn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.mapsetPcn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.mapsetPcn_linkLabel.Location = new System.Drawing.Point(105, 2);
            this.mapsetPcn_linkLabel.Name = "mapsetPcn_linkLabel";
            this.mapsetPcn_linkLabel.Size = new System.Drawing.Size(25, 12);
            this.mapsetPcn_linkLabel.TabIndex = 345;
            this.mapsetPcn_linkLabel.TabStop = true;
            this.mapsetPcn_linkLabel.Text = "PCN";
            this.mapsetPcn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.mapsetPcn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mapsetPcn_linkLabel_LinkClicked);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(313, 465);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(321, 36);
            this.flowLayoutPanel1.TabIndex = 355;
            // 
            // mapsetMatePcnSearch_textBox
            // 
            this.mapsetMatePcnSearch_textBox.Location = new System.Drawing.Point(209, 16);
            this.mapsetMatePcnSearch_textBox.Name = "mapsetMatePcnSearch_textBox";
            this.mapsetMatePcnSearch_textBox.Size = new System.Drawing.Size(54, 20);
            this.mapsetMatePcnSearch_textBox.TabIndex = 280;
            this.mapsetMatePcnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mapsetMatePcn_listBox
            // 
            this.mapsetMatePcn_listBox.FormattingEnabled = true;
            this.mapsetMatePcn_listBox.Location = new System.Drawing.Point(209, 41);
            this.mapsetMatePcn_listBox.Name = "mapsetMatePcn_listBox";
            this.mapsetMatePcn_listBox.Size = new System.Drawing.Size(82, 69);
            this.mapsetMatePcn_listBox.TabIndex = 279;
            this.mapsetMatePcn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // mapsetMatePcnClear_button
            // 
            this.mapsetMatePcnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mapsetMatePcnClear_button.BackgroundImage")));
            this.mapsetMatePcnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapsetMatePcnClear_button.Enabled = false;
            this.mapsetMatePcnClear_button.Location = new System.Drawing.Point(269, 16);
            this.mapsetMatePcnClear_button.Name = "mapsetMatePcnClear_button";
            this.mapsetMatePcnClear_button.Size = new System.Drawing.Size(22, 22);
            this.mapsetMatePcnClear_button.TabIndex = 288;
            this.mapsetMatePcnClear_button.UseVisualStyleBackColor = true;
            this.mapsetMatePcnClear_button.Click += new System.EventHandler(this.mapsetMatePcnClear_button_Click);
            // 
            // mapsetMatePcn_linkLabel
            // 
            this.mapsetMatePcn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.mapsetMatePcn_linkLabel.AutoSize = true;
            this.mapsetMatePcn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.mapsetMatePcn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.mapsetMatePcn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.mapsetMatePcn_linkLabel.Location = new System.Drawing.Point(207, 2);
            this.mapsetMatePcn_linkLabel.Name = "mapsetMatePcn_linkLabel";
            this.mapsetMatePcn_linkLabel.Size = new System.Drawing.Size(49, 12);
            this.mapsetMatePcn_linkLabel.TabIndex = 346;
            this.mapsetMatePcn_linkLabel.TabStop = true;
            this.mapsetMatePcn_linkLabel.Text = "Mate PCN";
            this.mapsetMatePcn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.mapsetMatePcn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mapsetMatePcn_linkLabel_LinkClicked);
            // 
            // mapsetSsn_linkLabel
            // 
            this.mapsetSsn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.mapsetSsn_linkLabel.AutoSize = true;
            this.mapsetSsn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.mapsetSsn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.mapsetSsn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.mapsetSsn_linkLabel.Location = new System.Drawing.Point(311, 1);
            this.mapsetSsn_linkLabel.Name = "mapsetSsn_linkLabel";
            this.mapsetSsn_linkLabel.Size = new System.Drawing.Size(24, 12);
            this.mapsetSsn_linkLabel.TabIndex = 347;
            this.mapsetSsn_linkLabel.TabStop = true;
            this.mapsetSsn_linkLabel.Text = "SSN";
            this.mapsetSsn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.mapsetSsn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mapsetSsn_linkLabel_LinkClicked);
            // 
            // MAPSET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.mapsetSsn_linkLabel);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.mapsetMatePcn_linkLabel);
            this.Controls.Add(this.mapsetPcn_linkLabel);
            this.Controls.Add(this.mapsetRc_linkLabel);
            this.Controls.Add(this.mapsetMult_linkLabel);
            this.Controls.Add(this.mapset_linkLabel);
            this.Controls.Add(this.mapsetMultClear_button);
            this.Controls.Add(this.mapsetMultSearch_textBox);
            this.Controls.Add(this.mapsetMult_listBox);
            this.Controls.Add(this.search_dataGridView);
            this.Controls.Add(this.mapsetSsn_listBox);
            this.Controls.Add(this.mapsetSsnSearch_textBox);
            this.Controls.Add(this.mapsetSsnClear_button);
            this.Controls.Add(this.mapset_listBox);
            this.Controls.Add(this.mapsetSearch_textBox);
            this.Controls.Add(this.mapsetClear_button);
            this.Controls.Add(this.mapsetRcClear_button);
            this.Controls.Add(this.mapsetPcn_listBox);
            this.Controls.Add(this.mapsetMatePcnClear_button);
            this.Controls.Add(this.mapsetPcnSearch_textBox);
            this.Controls.Add(this.mapsetPcnClear_button);
            this.Controls.Add(this.mapsetRcSearch_textBox);
            this.Controls.Add(this.mapsetMatePcn_listBox);
            this.Controls.Add(this.mapsetRc_listBox);
            this.Controls.Add(this.mapsetMatePcnSearch_textBox);
            this.Name = "MAPSET";
            this.Size = new System.Drawing.Size(876, 502);
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button mapsetMultClear_button;
        private System.Windows.Forms.TextBox mapsetMultSearch_textBox;
        private System.Windows.Forms.ListBox mapsetMult_listBox;
        private System.Windows.Forms.Button mapsetSsnClear_button;
        private System.Windows.Forms.Button mapsetClear_button;
        private System.Windows.Forms.Button mapsetRcClear_button;
        private System.Windows.Forms.Button mapsetPcnClear_button;
        private System.Windows.Forms.TextBox mapsetRcSearch_textBox;
        private System.Windows.Forms.ListBox mapsetRc_listBox;
        private System.Windows.Forms.TextBox mapsetPcnSearch_textBox;
        private System.Windows.Forms.ListBox mapsetPcn_listBox;
        private System.Windows.Forms.TextBox mapsetSearch_textBox;
        private System.Windows.Forms.ListBox mapset_listBox;
        private System.Windows.Forms.TextBox mapsetSsnSearch_textBox;
        private System.Windows.Forms.ListBox mapsetSsn_listBox;
        private System.Windows.Forms.DataGridView search_dataGridView;
        private System.Windows.Forms.Label numRecords_label;
        private System.Windows.Forms.LinkLabel mapset_linkLabel;
        private System.Windows.Forms.LinkLabel mapsetMult_linkLabel;
        private System.Windows.Forms.LinkLabel mapsetRc_linkLabel;
        private System.Windows.Forms.LinkLabel mapsetPcn_linkLabel;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox mapsetMatePcnSearch_textBox;
        private System.Windows.Forms.ListBox mapsetMatePcn_listBox;
        private System.Windows.Forms.Button mapsetMatePcnClear_button;
        private System.Windows.Forms.LinkLabel mapsetMatePcn_linkLabel;
        private System.Windows.Forms.LinkLabel mapsetSsn_linkLabel;
    }
}
