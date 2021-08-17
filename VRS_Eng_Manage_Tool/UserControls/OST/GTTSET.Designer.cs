namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    partial class GTTSET
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GTTSET));
            this.gttsetCheckSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttsetCheck_listBox = new System.Windows.Forms.ListBox();
            this.gttsetNdgtSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttsetNdgt_listBox = new System.Windows.Forms.ListBox();
            this.gttsetSxudtSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttsetSxudt_listBox = new System.Windows.Forms.ListBox();
            this.gttsetIdxSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttsetIdx_listBox = new System.Windows.Forms.ListBox();
            this.gttsetSettypeSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttsetSettype_listBox = new System.Windows.Forms.ListBox();
            this.search_dataGridView = new System.Windows.Forms.DataGridView();
            this.gttsetsnSearch_textBox = new System.Windows.Forms.TextBox();
            this.gttsetsn_listBox = new System.Windows.Forms.ListBox();
            this.numRecords_label = new System.Windows.Forms.Label();
            this.gttsetCheckClear_button = new System.Windows.Forms.Button();
            this.gttsetSettypeClear_button = new System.Windows.Forms.Button();
            this.gttsetsnClear_button = new System.Windows.Forms.Button();
            this.gttsetIdxClear_button = new System.Windows.Forms.Button();
            this.gttsetNdgtClear_button = new System.Windows.Forms.Button();
            this.gttsetSxudtClear_button = new System.Windows.Forms.Button();
            this.gttsetGttsn_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gttsetSettype_linkLabel = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.gttsetSetidx_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gttsetNdgt_linkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.clear_button = new System.Windows.Forms.Button();
            this.excel_button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gttsetCheckSearch_textBox
            // 
            this.gttsetCheckSearch_textBox.Location = new System.Drawing.Point(290, 16);
            this.gttsetCheckSearch_textBox.Name = "gttsetCheckSearch_textBox";
            this.gttsetCheckSearch_textBox.Size = new System.Drawing.Size(75, 20);
            this.gttsetCheckSearch_textBox.TabIndex = 332;
            // 
            // gttsetCheck_listBox
            // 
            this.gttsetCheck_listBox.FormattingEnabled = true;
            this.gttsetCheck_listBox.Location = new System.Drawing.Point(290, 41);
            this.gttsetCheck_listBox.Name = "gttsetCheck_listBox";
            this.gttsetCheck_listBox.Size = new System.Drawing.Size(103, 69);
            this.gttsetCheck_listBox.TabIndex = 331;
            this.gttsetCheck_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttsetNdgtSearch_textBox
            // 
            this.gttsetNdgtSearch_textBox.Location = new System.Drawing.Point(620, 16);
            this.gttsetNdgtSearch_textBox.Name = "gttsetNdgtSearch_textBox";
            this.gttsetNdgtSearch_textBox.Size = new System.Drawing.Size(156, 20);
            this.gttsetNdgtSearch_textBox.TabIndex = 316;
            this.gttsetNdgtSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttsetNdgt_listBox
            // 
            this.gttsetNdgt_listBox.FormattingEnabled = true;
            this.gttsetNdgt_listBox.Location = new System.Drawing.Point(620, 41);
            this.gttsetNdgt_listBox.Name = "gttsetNdgt_listBox";
            this.gttsetNdgt_listBox.Size = new System.Drawing.Size(184, 69);
            this.gttsetNdgt_listBox.TabIndex = 315;
            this.gttsetNdgt_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttsetSxudtSearch_textBox
            // 
            this.gttsetSxudtSearch_textBox.Location = new System.Drawing.Point(521, 16);
            this.gttsetSxudtSearch_textBox.Name = "gttsetSxudtSearch_textBox";
            this.gttsetSxudtSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.gttsetSxudtSearch_textBox.TabIndex = 313;
            this.gttsetSxudtSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttsetSxudt_listBox
            // 
            this.gttsetSxudt_listBox.FormattingEnabled = true;
            this.gttsetSxudt_listBox.Location = new System.Drawing.Point(521, 41);
            this.gttsetSxudt_listBox.Name = "gttsetSxudt_listBox";
            this.gttsetSxudt_listBox.Size = new System.Drawing.Size(83, 69);
            this.gttsetSxudt_listBox.TabIndex = 312;
            this.gttsetSxudt_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttsetIdxSearch_textBox
            // 
            this.gttsetIdxSearch_textBox.Location = new System.Drawing.Point(408, 16);
            this.gttsetIdxSearch_textBox.Name = "gttsetIdxSearch_textBox";
            this.gttsetIdxSearch_textBox.Size = new System.Drawing.Size(66, 20);
            this.gttsetIdxSearch_textBox.TabIndex = 310;
            this.gttsetIdxSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttsetIdx_listBox
            // 
            this.gttsetIdx_listBox.FormattingEnabled = true;
            this.gttsetIdx_listBox.Location = new System.Drawing.Point(408, 41);
            this.gttsetIdx_listBox.Name = "gttsetIdx_listBox";
            this.gttsetIdx_listBox.Size = new System.Drawing.Size(94, 69);
            this.gttsetIdx_listBox.TabIndex = 309;
            this.gttsetIdx_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gttsetSettypeSearch_textBox
            // 
            this.gttsetSettypeSearch_textBox.Location = new System.Drawing.Point(149, 16);
            this.gttsetSettypeSearch_textBox.Name = "gttsetSettypeSearch_textBox";
            this.gttsetSettypeSearch_textBox.Size = new System.Drawing.Size(98, 20);
            this.gttsetSettypeSearch_textBox.TabIndex = 307;
            this.gttsetSettypeSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttsetSettype_listBox
            // 
            this.gttsetSettype_listBox.FormattingEnabled = true;
            this.gttsetSettype_listBox.Location = new System.Drawing.Point(149, 41);
            this.gttsetSettype_listBox.Name = "gttsetSettype_listBox";
            this.gttsetSettype_listBox.Size = new System.Drawing.Size(126, 69);
            this.gttsetSettype_listBox.TabIndex = 306;
            this.gttsetSettype_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // search_dataGridView
            // 
            this.search_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.search_dataGridView.Location = new System.Drawing.Point(3, 120);
            this.search_dataGridView.Name = "search_dataGridView";
            this.search_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.search_dataGridView.Size = new System.Drawing.Size(870, 343);
            this.search_dataGridView.TabIndex = 304;
            this.search_dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.search_dataGridView_DataBindingComplete);
            // 
            // gttsetsnSearch_textBox
            // 
            this.gttsetsnSearch_textBox.Location = new System.Drawing.Point(3, 16);
            this.gttsetsnSearch_textBox.Name = "gttsetsnSearch_textBox";
            this.gttsetsnSearch_textBox.Size = new System.Drawing.Size(101, 20);
            this.gttsetsnSearch_textBox.TabIndex = 303;
            this.gttsetsnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gttsetsn_listBox
            // 
            this.gttsetsn_listBox.FormattingEnabled = true;
            this.gttsetsn_listBox.Location = new System.Drawing.Point(3, 41);
            this.gttsetsn_listBox.Name = "gttsetsn_listBox";
            this.gttsetsn_listBox.Size = new System.Drawing.Size(128, 69);
            this.gttsetsn_listBox.TabIndex = 302;
            this.gttsetsn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // numRecords_label
            // 
            this.numRecords_label.AutoSize = true;
            this.numRecords_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRecords_label.Location = new System.Drawing.Point(218, 0);
            this.numRecords_label.Name = "numRecords_label";
            this.numRecords_label.Size = new System.Drawing.Size(111, 12);
            this.numRecords_label.TabIndex = 334;
            this.numRecords_label.Text = "Number of records: 15000";
            this.numRecords_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gttsetCheckClear_button
            // 
            this.gttsetCheckClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttsetCheckClear_button.BackgroundImage")));
            this.gttsetCheckClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttsetCheckClear_button.Enabled = false;
            this.gttsetCheckClear_button.Location = new System.Drawing.Point(371, 15);
            this.gttsetCheckClear_button.Name = "gttsetCheckClear_button";
            this.gttsetCheckClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttsetCheckClear_button.TabIndex = 333;
            this.gttsetCheckClear_button.UseVisualStyleBackColor = true;
            this.gttsetCheckClear_button.Click += new System.EventHandler(this.gttsetCheckClear_button_Click);
            // 
            // gttsetSettypeClear_button
            // 
            this.gttsetSettypeClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttsetSettypeClear_button.BackgroundImage")));
            this.gttsetSettypeClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttsetSettypeClear_button.Enabled = false;
            this.gttsetSettypeClear_button.Location = new System.Drawing.Point(253, 14);
            this.gttsetSettypeClear_button.Name = "gttsetSettypeClear_button";
            this.gttsetSettypeClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttsetSettypeClear_button.TabIndex = 325;
            this.gttsetSettypeClear_button.UseVisualStyleBackColor = true;
            this.gttsetSettypeClear_button.Click += new System.EventHandler(this.gttsetSettypeClear_button_Click);
            // 
            // gttsetsnClear_button
            // 
            this.gttsetsnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttsetsnClear_button.BackgroundImage")));
            this.gttsetsnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttsetsnClear_button.Enabled = false;
            this.gttsetsnClear_button.Location = new System.Drawing.Point(110, 14);
            this.gttsetsnClear_button.Name = "gttsetsnClear_button";
            this.gttsetsnClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttsetsnClear_button.TabIndex = 324;
            this.gttsetsnClear_button.UseVisualStyleBackColor = true;
            this.gttsetsnClear_button.Click += new System.EventHandler(this.gttsetsnClear_button_Click);
            // 
            // gttsetIdxClear_button
            // 
            this.gttsetIdxClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttsetIdxClear_button.BackgroundImage")));
            this.gttsetIdxClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttsetIdxClear_button.Enabled = false;
            this.gttsetIdxClear_button.Location = new System.Drawing.Point(480, 15);
            this.gttsetIdxClear_button.Name = "gttsetIdxClear_button";
            this.gttsetIdxClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttsetIdxClear_button.TabIndex = 323;
            this.gttsetIdxClear_button.UseVisualStyleBackColor = true;
            this.gttsetIdxClear_button.Click += new System.EventHandler(this.gttsetIdxClear_button_Click);
            // 
            // gttsetNdgtClear_button
            // 
            this.gttsetNdgtClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttsetNdgtClear_button.BackgroundImage")));
            this.gttsetNdgtClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttsetNdgtClear_button.Enabled = false;
            this.gttsetNdgtClear_button.Location = new System.Drawing.Point(782, 15);
            this.gttsetNdgtClear_button.Name = "gttsetNdgtClear_button";
            this.gttsetNdgtClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttsetNdgtClear_button.TabIndex = 321;
            this.gttsetNdgtClear_button.UseVisualStyleBackColor = true;
            this.gttsetNdgtClear_button.Click += new System.EventHandler(this.gttsetNdgtClear_button_Click);
            // 
            // gttsetSxudtClear_button
            // 
            this.gttsetSxudtClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gttsetSxudtClear_button.BackgroundImage")));
            this.gttsetSxudtClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gttsetSxudtClear_button.Enabled = false;
            this.gttsetSxudtClear_button.Location = new System.Drawing.Point(583, 15);
            this.gttsetSxudtClear_button.Name = "gttsetSxudtClear_button";
            this.gttsetSxudtClear_button.Size = new System.Drawing.Size(22, 22);
            this.gttsetSxudtClear_button.TabIndex = 320;
            this.gttsetSxudtClear_button.UseVisualStyleBackColor = true;
            this.gttsetSxudtClear_button.Click += new System.EventHandler(this.gttsetSxudtClear_button_Click);
            // 
            // gttsetGttsn_linkLabel
            // 
            this.gttsetGttsn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttsetGttsn_linkLabel.AutoSize = true;
            this.gttsetGttsn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttsetGttsn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttsetGttsn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttsetGttsn_linkLabel.Location = new System.Drawing.Point(1, 2);
            this.gttsetGttsn_linkLabel.Name = "gttsetGttsn_linkLabel";
            this.gttsetGttsn_linkLabel.Size = new System.Drawing.Size(35, 12);
            this.gttsetGttsn_linkLabel.TabIndex = 342;
            this.gttsetGttsn_linkLabel.TabStop = true;
            this.gttsetGttsn_linkLabel.Text = "GTTSN";
            this.gttsetGttsn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttsetGttsn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttsetGttsn_linkLabel_LinkClicked);
            // 
            // gttsetSettype_linkLabel
            // 
            this.gttsetSettype_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttsetSettype_linkLabel.AutoSize = true;
            this.gttsetSettype_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttsetSettype_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttsetSettype_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttsetSettype_linkLabel.Location = new System.Drawing.Point(147, 2);
            this.gttsetSettype_linkLabel.Name = "gttsetSettype_linkLabel";
            this.gttsetSettype_linkLabel.Size = new System.Drawing.Size(44, 12);
            this.gttsetSettype_linkLabel.TabIndex = 343;
            this.gttsetSettype_linkLabel.TabStop = true;
            this.gttsetSettype_linkLabel.Text = "SETTYPE";
            this.gttsetSettype_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttsetSettype_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttsetSettype_linkLabel_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(288, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 12);
            this.label5.TabIndex = 330;
            this.label5.Text = "CHECKMULCOMP";
            // 
            // gttsetSetidx_linkLabel
            // 
            this.gttsetSetidx_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttsetSetidx_linkLabel.AutoSize = true;
            this.gttsetSetidx_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttsetSetidx_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttsetSetidx_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttsetSetidx_linkLabel.Location = new System.Drawing.Point(406, 2);
            this.gttsetSetidx_linkLabel.Name = "gttsetSetidx_linkLabel";
            this.gttsetSetidx_linkLabel.Size = new System.Drawing.Size(38, 12);
            this.gttsetSetidx_linkLabel.TabIndex = 345;
            this.gttsetSetidx_linkLabel.TabStop = true;
            this.gttsetSetidx_linkLabel.Text = "SETIDX";
            this.gttsetSetidx_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttsetSetidx_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttsetSetidx_linkLabel_LinkClicked);
            // 
            // gttsetNdgt_linkLabel
            // 
            this.gttsetNdgt_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gttsetNdgt_linkLabel.AutoSize = true;
            this.gttsetNdgt_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gttsetNdgt_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gttsetNdgt_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gttsetNdgt_linkLabel.Location = new System.Drawing.Point(618, 2);
            this.gttsetNdgt_linkLabel.Name = "gttsetNdgt_linkLabel";
            this.gttsetNdgt_linkLabel.Size = new System.Drawing.Size(31, 12);
            this.gttsetNdgt_linkLabel.TabIndex = 347;
            this.gttsetNdgt_linkLabel.TabStop = true;
            this.gttsetNdgt_linkLabel.Text = "NDGT";
            this.gttsetNdgt_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gttsetNdgt_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gttsetNdgt_linkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(519, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 348;
            this.label1.Text = "SXUDT";
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(540, 466);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(332, 35);
            this.flowLayoutPanel1.TabIndex = 355;
            // 
            // GTTSET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gttsetNdgt_linkLabel);
            this.Controls.Add(this.gttsetSetidx_linkLabel);
            this.Controls.Add(this.gttsetSettype_linkLabel);
            this.Controls.Add(this.gttsetGttsn_linkLabel);
            this.Controls.Add(this.gttsetCheckClear_button);
            this.Controls.Add(this.gttsetCheckSearch_textBox);
            this.Controls.Add(this.gttsetCheck_listBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gttsetSettypeClear_button);
            this.Controls.Add(this.gttsetsnClear_button);
            this.Controls.Add(this.gttsetIdxClear_button);
            this.Controls.Add(this.gttsetNdgtClear_button);
            this.Controls.Add(this.gttsetSxudtClear_button);
            this.Controls.Add(this.gttsetNdgtSearch_textBox);
            this.Controls.Add(this.gttsetNdgt_listBox);
            this.Controls.Add(this.gttsetSxudtSearch_textBox);
            this.Controls.Add(this.gttsetSxudt_listBox);
            this.Controls.Add(this.gttsetIdxSearch_textBox);
            this.Controls.Add(this.gttsetIdx_listBox);
            this.Controls.Add(this.gttsetSettypeSearch_textBox);
            this.Controls.Add(this.gttsetSettype_listBox);
            this.Controls.Add(this.search_dataGridView);
            this.Controls.Add(this.gttsetsnSearch_textBox);
            this.Controls.Add(this.gttsetsn_listBox);
            this.Name = "GTTSET";
            this.Size = new System.Drawing.Size(876, 502);
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gttsetCheckClear_button;
        private System.Windows.Forms.TextBox gttsetCheckSearch_textBox;
        private System.Windows.Forms.ListBox gttsetCheck_listBox;
        private System.Windows.Forms.Button gttsetSettypeClear_button;
        private System.Windows.Forms.Button gttsetsnClear_button;
        private System.Windows.Forms.Button gttsetIdxClear_button;
        private System.Windows.Forms.Button gttsetNdgtClear_button;
        private System.Windows.Forms.Button gttsetSxudtClear_button;
        private System.Windows.Forms.TextBox gttsetNdgtSearch_textBox;
        private System.Windows.Forms.ListBox gttsetNdgt_listBox;
        private System.Windows.Forms.TextBox gttsetSxudtSearch_textBox;
        private System.Windows.Forms.ListBox gttsetSxudt_listBox;
        private System.Windows.Forms.TextBox gttsetIdxSearch_textBox;
        private System.Windows.Forms.ListBox gttsetIdx_listBox;
        private System.Windows.Forms.TextBox gttsetSettypeSearch_textBox;
        private System.Windows.Forms.ListBox gttsetSettype_listBox;
        private System.Windows.Forms.DataGridView search_dataGridView;
        private System.Windows.Forms.TextBox gttsetsnSearch_textBox;
        private System.Windows.Forms.ListBox gttsetsn_listBox;
        private System.Windows.Forms.Label numRecords_label;
        private System.Windows.Forms.LinkLabel gttsetGttsn_linkLabel;
        private System.Windows.Forms.LinkLabel gttsetSettype_linkLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel gttsetSetidx_linkLabel;
        private System.Windows.Forms.LinkLabel gttsetNdgt_linkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
