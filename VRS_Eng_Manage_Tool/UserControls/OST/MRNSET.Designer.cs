namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    partial class MRNSET
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MRNSET));
            this.numRecords_label = new System.Windows.Forms.Label();
            this.mrnsetPcClear_button = new System.Windows.Forms.Button();
            this.mrnsetPcSearch_textBox = new System.Windows.Forms.TextBox();
            this.mrnsetPc_listBox = new System.Windows.Forms.ListBox();
            this.mrnsetNetClear_button = new System.Windows.Forms.Button();
            this.mrnsetClear_button = new System.Windows.Forms.Button();
            this.mrnsetRcClear_button = new System.Windows.Forms.Button();
            this.mrnsetClliClear_button = new System.Windows.Forms.Button();
            this.mrnsetDpcClear_button = new System.Windows.Forms.Button();
            this.mrnsetRcSearch_textBox = new System.Windows.Forms.TextBox();
            this.mrnsetRc_listBox = new System.Windows.Forms.ListBox();
            this.mrnsetClliSearch_textBox = new System.Windows.Forms.TextBox();
            this.mrnsetClli_listBox = new System.Windows.Forms.ListBox();
            this.mrnsetDpcSearch_textBox = new System.Windows.Forms.TextBox();
            this.mrnsetDpc_listBox = new System.Windows.Forms.ListBox();
            this.mrnsetSearch_textBox = new System.Windows.Forms.TextBox();
            this.mrnset_listBox = new System.Windows.Forms.ListBox();
            this.mrnsetNetSearch_textBox = new System.Windows.Forms.TextBox();
            this.mrnsetNet_listBox = new System.Windows.Forms.ListBox();
            this.opcodeHeader_label = new System.Windows.Forms.Label();
            this.search_dataGridView = new System.Windows.Forms.DataGridView();
            this.mrnset_linkLabel = new System.Windows.Forms.LinkLabel();
            this.mrnsetPc_linkLabel = new System.Windows.Forms.LinkLabel();
            this.mrnsetRc_linkLabel = new System.Windows.Forms.LinkLabel();
            this.mrnsetDpc_linkLabel = new System.Windows.Forms.LinkLabel();
            this.mrnsetClli_linkLabel = new System.Windows.Forms.LinkLabel();
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
            this.numRecords_label.Location = new System.Drawing.Point(207, 0);
            this.numRecords_label.Name = "numRecords_label";
            this.numRecords_label.Size = new System.Drawing.Size(111, 12);
            this.numRecords_label.TabIndex = 335;
            this.numRecords_label.Text = "Number of records: 15000";
            this.numRecords_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mrnsetPcClear_button
            // 
            this.mrnsetPcClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mrnsetPcClear_button.BackgroundImage")));
            this.mrnsetPcClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mrnsetPcClear_button.Enabled = false;
            this.mrnsetPcClear_button.Location = new System.Drawing.Point(257, 15);
            this.mrnsetPcClear_button.Name = "mrnsetPcClear_button";
            this.mrnsetPcClear_button.Size = new System.Drawing.Size(22, 22);
            this.mrnsetPcClear_button.TabIndex = 300;
            this.mrnsetPcClear_button.UseVisualStyleBackColor = true;
            this.mrnsetPcClear_button.Click += new System.EventHandler(this.mrnsetPcClear_button_Click);
            // 
            // mrnsetPcSearch_textBox
            // 
            this.mrnsetPcSearch_textBox.Location = new System.Drawing.Point(195, 16);
            this.mrnsetPcSearch_textBox.Name = "mrnsetPcSearch_textBox";
            this.mrnsetPcSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.mrnsetPcSearch_textBox.TabIndex = 299;
            this.mrnsetPcSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mrnsetPc_listBox
            // 
            this.mrnsetPc_listBox.FormattingEnabled = true;
            this.mrnsetPc_listBox.Location = new System.Drawing.Point(195, 41);
            this.mrnsetPc_listBox.Name = "mrnsetPc_listBox";
            this.mrnsetPc_listBox.Size = new System.Drawing.Size(84, 69);
            this.mrnsetPc_listBox.TabIndex = 298;
            this.mrnsetPc_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // mrnsetNetClear_button
            // 
            this.mrnsetNetClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mrnsetNetClear_button.BackgroundImage")));
            this.mrnsetNetClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mrnsetNetClear_button.Enabled = false;
            this.mrnsetNetClear_button.Location = new System.Drawing.Point(154, 14);
            this.mrnsetNetClear_button.Name = "mrnsetNetClear_button";
            this.mrnsetNetClear_button.Size = new System.Drawing.Size(22, 22);
            this.mrnsetNetClear_button.TabIndex = 292;
            this.mrnsetNetClear_button.UseVisualStyleBackColor = true;
            this.mrnsetNetClear_button.Click += new System.EventHandler(this.mrnsetNetClear_button_Click);
            // 
            // mrnsetClear_button
            // 
            this.mrnsetClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mrnsetClear_button.BackgroundImage")));
            this.mrnsetClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mrnsetClear_button.Enabled = false;
            this.mrnsetClear_button.Location = new System.Drawing.Point(65, 15);
            this.mrnsetClear_button.Name = "mrnsetClear_button";
            this.mrnsetClear_button.Size = new System.Drawing.Size(22, 22);
            this.mrnsetClear_button.TabIndex = 290;
            this.mrnsetClear_button.UseVisualStyleBackColor = true;
            this.mrnsetClear_button.Click += new System.EventHandler(this.mrnsetClear_button_Click);
            // 
            // mrnsetRcClear_button
            // 
            this.mrnsetRcClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mrnsetRcClear_button.BackgroundImage")));
            this.mrnsetRcClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mrnsetRcClear_button.Enabled = false;
            this.mrnsetRcClear_button.Location = new System.Drawing.Point(350, 15);
            this.mrnsetRcClear_button.Name = "mrnsetRcClear_button";
            this.mrnsetRcClear_button.Size = new System.Drawing.Size(22, 22);
            this.mrnsetRcClear_button.TabIndex = 289;
            this.mrnsetRcClear_button.UseVisualStyleBackColor = true;
            this.mrnsetRcClear_button.Click += new System.EventHandler(this.mrnsetRcClear_button_Click);
            // 
            // mrnsetClliClear_button
            // 
            this.mrnsetClliClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mrnsetClliClear_button.BackgroundImage")));
            this.mrnsetClliClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mrnsetClliClear_button.Enabled = false;
            this.mrnsetClliClear_button.Location = new System.Drawing.Point(614, 15);
            this.mrnsetClliClear_button.Name = "mrnsetClliClear_button";
            this.mrnsetClliClear_button.Size = new System.Drawing.Size(22, 22);
            this.mrnsetClliClear_button.TabIndex = 288;
            this.mrnsetClliClear_button.UseVisualStyleBackColor = true;
            this.mrnsetClliClear_button.Click += new System.EventHandler(this.mrnsetClliClear_button_Click);
            // 
            // mrnsetDpcClear_button
            // 
            this.mrnsetDpcClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mrnsetDpcClear_button.BackgroundImage")));
            this.mrnsetDpcClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mrnsetDpcClear_button.Enabled = false;
            this.mrnsetDpcClear_button.Location = new System.Drawing.Point(482, 15);
            this.mrnsetDpcClear_button.Name = "mrnsetDpcClear_button";
            this.mrnsetDpcClear_button.Size = new System.Drawing.Size(22, 22);
            this.mrnsetDpcClear_button.TabIndex = 287;
            this.mrnsetDpcClear_button.UseVisualStyleBackColor = true;
            this.mrnsetDpcClear_button.Click += new System.EventHandler(this.mrnsetDpcClear_button_Click);
            // 
            // mrnsetRcSearch_textBox
            // 
            this.mrnsetRcSearch_textBox.Location = new System.Drawing.Point(300, 16);
            this.mrnsetRcSearch_textBox.Name = "mrnsetRcSearch_textBox";
            this.mrnsetRcSearch_textBox.Size = new System.Drawing.Size(44, 20);
            this.mrnsetRcSearch_textBox.TabIndex = 283;
            this.mrnsetRcSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mrnsetRc_listBox
            // 
            this.mrnsetRc_listBox.FormattingEnabled = true;
            this.mrnsetRc_listBox.Location = new System.Drawing.Point(300, 41);
            this.mrnsetRc_listBox.Name = "mrnsetRc_listBox";
            this.mrnsetRc_listBox.Size = new System.Drawing.Size(72, 69);
            this.mrnsetRc_listBox.TabIndex = 282;
            this.mrnsetRc_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // mrnsetClliSearch_textBox
            // 
            this.mrnsetClliSearch_textBox.Location = new System.Drawing.Point(526, 16);
            this.mrnsetClliSearch_textBox.Name = "mrnsetClliSearch_textBox";
            this.mrnsetClliSearch_textBox.Size = new System.Drawing.Size(82, 20);
            this.mrnsetClliSearch_textBox.TabIndex = 280;
            this.mrnsetClliSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mrnsetClli_listBox
            // 
            this.mrnsetClli_listBox.FormattingEnabled = true;
            this.mrnsetClli_listBox.Location = new System.Drawing.Point(526, 41);
            this.mrnsetClli_listBox.Name = "mrnsetClli_listBox";
            this.mrnsetClli_listBox.Size = new System.Drawing.Size(109, 69);
            this.mrnsetClli_listBox.TabIndex = 279;
            this.mrnsetClli_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // mrnsetDpcSearch_textBox
            // 
            this.mrnsetDpcSearch_textBox.Location = new System.Drawing.Point(394, 16);
            this.mrnsetDpcSearch_textBox.Name = "mrnsetDpcSearch_textBox";
            this.mrnsetDpcSearch_textBox.Size = new System.Drawing.Size(82, 20);
            this.mrnsetDpcSearch_textBox.TabIndex = 277;
            this.mrnsetDpcSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mrnsetDpc_listBox
            // 
            this.mrnsetDpc_listBox.FormattingEnabled = true;
            this.mrnsetDpc_listBox.Location = new System.Drawing.Point(394, 41);
            this.mrnsetDpc_listBox.Name = "mrnsetDpc_listBox";
            this.mrnsetDpc_listBox.Size = new System.Drawing.Size(110, 69);
            this.mrnsetDpc_listBox.TabIndex = 276;
            this.mrnsetDpc_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // mrnsetSearch_textBox
            // 
            this.mrnsetSearch_textBox.Location = new System.Drawing.Point(3, 16);
            this.mrnsetSearch_textBox.Name = "mrnsetSearch_textBox";
            this.mrnsetSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.mrnsetSearch_textBox.TabIndex = 274;
            this.mrnsetSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mrnset_listBox
            // 
            this.mrnset_listBox.FormattingEnabled = true;
            this.mrnset_listBox.Location = new System.Drawing.Point(3, 41);
            this.mrnset_listBox.Name = "mrnset_listBox";
            this.mrnset_listBox.Size = new System.Drawing.Size(84, 69);
            this.mrnset_listBox.TabIndex = 273;
            this.mrnset_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // mrnsetNetSearch_textBox
            // 
            this.mrnsetNetSearch_textBox.Location = new System.Drawing.Point(105, 16);
            this.mrnsetNetSearch_textBox.Name = "mrnsetNetSearch_textBox";
            this.mrnsetNetSearch_textBox.Size = new System.Drawing.Size(43, 20);
            this.mrnsetNetSearch_textBox.TabIndex = 268;
            this.mrnsetNetSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // mrnsetNet_listBox
            // 
            this.mrnsetNet_listBox.FormattingEnabled = true;
            this.mrnsetNet_listBox.Location = new System.Drawing.Point(105, 41);
            this.mrnsetNet_listBox.Name = "mrnsetNet_listBox";
            this.mrnsetNet_listBox.Size = new System.Drawing.Size(71, 69);
            this.mrnsetNet_listBox.TabIndex = 267;
            this.mrnsetNet_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // opcodeHeader_label
            // 
            this.opcodeHeader_label.AutoSize = true;
            this.opcodeHeader_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcodeHeader_label.Location = new System.Drawing.Point(103, 2);
            this.opcodeHeader_label.Name = "opcodeHeader_label";
            this.opcodeHeader_label.Size = new System.Drawing.Size(23, 12);
            this.opcodeHeader_label.TabIndex = 266;
            this.opcodeHeader_label.Text = "NET";
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
            // mrnset_linkLabel
            // 
            this.mrnset_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.mrnset_linkLabel.AutoSize = true;
            this.mrnset_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.mrnset_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.mrnset_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.mrnset_linkLabel.Location = new System.Drawing.Point(1, 2);
            this.mrnset_linkLabel.Name = "mrnset_linkLabel";
            this.mrnset_linkLabel.Size = new System.Drawing.Size(45, 12);
            this.mrnset_linkLabel.TabIndex = 338;
            this.mrnset_linkLabel.TabStop = true;
            this.mrnset_linkLabel.Text = "MRNSET";
            this.mrnset_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.mrnset_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mrnset_linkLabel_LinkClicked);
            // 
            // mrnsetPc_linkLabel
            // 
            this.mrnsetPc_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.mrnsetPc_linkLabel.AutoSize = true;
            this.mrnsetPc_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.mrnsetPc_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.mrnsetPc_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.mrnsetPc_linkLabel.Location = new System.Drawing.Point(193, 2);
            this.mrnsetPc_linkLabel.Name = "mrnsetPc_linkLabel";
            this.mrnsetPc_linkLabel.Size = new System.Drawing.Size(18, 12);
            this.mrnsetPc_linkLabel.TabIndex = 343;
            this.mrnsetPc_linkLabel.TabStop = true;
            this.mrnsetPc_linkLabel.Text = "PC";
            this.mrnsetPc_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.mrnsetPc_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mrnsetPc_linkLabel_LinkClicked);
            // 
            // mrnsetRc_linkLabel
            // 
            this.mrnsetRc_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.mrnsetRc_linkLabel.AutoSize = true;
            this.mrnsetRc_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.mrnsetRc_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.mrnsetRc_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.mrnsetRc_linkLabel.Location = new System.Drawing.Point(298, 2);
            this.mrnsetRc_linkLabel.Name = "mrnsetRc_linkLabel";
            this.mrnsetRc_linkLabel.Size = new System.Drawing.Size(19, 12);
            this.mrnsetRc_linkLabel.TabIndex = 344;
            this.mrnsetRc_linkLabel.TabStop = true;
            this.mrnsetRc_linkLabel.Text = "RC";
            this.mrnsetRc_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.mrnsetRc_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mrnsetRc_linkLabel_LinkClicked);
            // 
            // mrnsetDpc_linkLabel
            // 
            this.mrnsetDpc_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.mrnsetDpc_linkLabel.AutoSize = true;
            this.mrnsetDpc_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.mrnsetDpc_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.mrnsetDpc_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.mrnsetDpc_linkLabel.Location = new System.Drawing.Point(392, 2);
            this.mrnsetDpc_linkLabel.Name = "mrnsetDpc_linkLabel";
            this.mrnsetDpc_linkLabel.Size = new System.Drawing.Size(61, 12);
            this.mrnsetDpc_linkLabel.TabIndex = 345;
            this.mrnsetDpc_linkLabel.TabStop = true;
            this.mrnsetDpc_linkLabel.Text = "DPC Decimal";
            this.mrnsetDpc_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.mrnsetDpc_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mrnsetDpc_linkLabel_LinkClicked);
            // 
            // mrnsetClli_linkLabel
            // 
            this.mrnsetClli_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.mrnsetClli_linkLabel.AutoSize = true;
            this.mrnsetClli_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.mrnsetClli_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.mrnsetClli_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.mrnsetClli_linkLabel.Location = new System.Drawing.Point(524, 2);
            this.mrnsetClli_linkLabel.Name = "mrnsetClli_linkLabel";
            this.mrnsetClli_linkLabel.Size = new System.Drawing.Size(25, 12);
            this.mrnsetClli_linkLabel.TabIndex = 346;
            this.mrnsetClli_linkLabel.TabStop = true;
            this.mrnsetClli_linkLabel.Text = "CLLI";
            this.mrnsetClli_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.mrnsetClli_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mrnsetClli_linkLabel_LinkClicked);
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
            // MRNSET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.mrnsetClli_linkLabel);
            this.Controls.Add(this.mrnsetDpc_linkLabel);
            this.Controls.Add(this.mrnsetRc_linkLabel);
            this.Controls.Add(this.mrnsetPc_linkLabel);
            this.Controls.Add(this.mrnset_linkLabel);
            this.Controls.Add(this.mrnsetPcClear_button);
            this.Controls.Add(this.mrnsetPcSearch_textBox);
            this.Controls.Add(this.mrnsetPc_listBox);
            this.Controls.Add(this.search_dataGridView);
            this.Controls.Add(this.opcodeHeader_label);
            this.Controls.Add(this.mrnsetNet_listBox);
            this.Controls.Add(this.mrnsetNetSearch_textBox);
            this.Controls.Add(this.mrnsetNetClear_button);
            this.Controls.Add(this.mrnset_listBox);
            this.Controls.Add(this.mrnsetSearch_textBox);
            this.Controls.Add(this.mrnsetClear_button);
            this.Controls.Add(this.mrnsetRcClear_button);
            this.Controls.Add(this.mrnsetDpc_listBox);
            this.Controls.Add(this.mrnsetClliClear_button);
            this.Controls.Add(this.mrnsetDpcSearch_textBox);
            this.Controls.Add(this.mrnsetDpcClear_button);
            this.Controls.Add(this.mrnsetRcSearch_textBox);
            this.Controls.Add(this.mrnsetClli_listBox);
            this.Controls.Add(this.mrnsetRc_listBox);
            this.Controls.Add(this.mrnsetClliSearch_textBox);
            this.Name = "MRNSET";
            this.Size = new System.Drawing.Size(876, 502);
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button mrnsetPcClear_button;
        private System.Windows.Forms.TextBox mrnsetPcSearch_textBox;
        private System.Windows.Forms.ListBox mrnsetPc_listBox;
        private System.Windows.Forms.Button mrnsetNetClear_button;
        private System.Windows.Forms.Button mrnsetClear_button;
        private System.Windows.Forms.Button mrnsetRcClear_button;
        private System.Windows.Forms.Button mrnsetClliClear_button;
        private System.Windows.Forms.Button mrnsetDpcClear_button;
        private System.Windows.Forms.TextBox mrnsetRcSearch_textBox;
        private System.Windows.Forms.ListBox mrnsetRc_listBox;
        private System.Windows.Forms.TextBox mrnsetClliSearch_textBox;
        private System.Windows.Forms.ListBox mrnsetClli_listBox;
        private System.Windows.Forms.TextBox mrnsetDpcSearch_textBox;
        private System.Windows.Forms.ListBox mrnsetDpc_listBox;
        private System.Windows.Forms.TextBox mrnsetSearch_textBox;
        private System.Windows.Forms.ListBox mrnset_listBox;
        private System.Windows.Forms.TextBox mrnsetNetSearch_textBox;
        private System.Windows.Forms.ListBox mrnsetNet_listBox;
        private System.Windows.Forms.Label opcodeHeader_label;
        private System.Windows.Forms.DataGridView search_dataGridView;
        private System.Windows.Forms.Label numRecords_label;
        private System.Windows.Forms.LinkLabel mrnset_linkLabel;
        private System.Windows.Forms.LinkLabel mrnsetPc_linkLabel;
        private System.Windows.Forms.LinkLabel mrnsetRc_linkLabel;
        private System.Windows.Forms.LinkLabel mrnsetDpc_linkLabel;
        private System.Windows.Forms.LinkLabel mrnsetClli_linkLabel;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
