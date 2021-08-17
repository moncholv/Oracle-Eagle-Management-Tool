namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    partial class GTA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GTA));
            this.gtaItuSearch_textBox = new System.Windows.Forms.TextBox();
            this.gtaItu_listBox = new System.Windows.Forms.ListBox();
            this.gtaActsnSearch_textBox = new System.Windows.Forms.TextBox();
            this.gtaActsn_listBox = new System.Windows.Forms.ListBox();
            this.gtaCdselidSearch_textBox = new System.Windows.Forms.TextBox();
            this.gtaCdselid_listBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gtaOptsnSearch_textBox = new System.Windows.Forms.TextBox();
            this.gtaOptsn_listBox = new System.Windows.Forms.ListBox();
            this.gtaLoopsetSearch_textBox = new System.Windows.Forms.TextBox();
            this.gtaLoopset_listBox = new System.Windows.Forms.ListBox();
            this.gtaMrnsetSearch_textBox = new System.Windows.Forms.TextBox();
            this.gtaMrnset_listBox = new System.Windows.Forms.ListBox();
            this.gtaSearch_textBox = new System.Windows.Forms.TextBox();
            this.gta_listBox = new System.Windows.Forms.ListBox();
            this.search_dataGridView = new System.Windows.Forms.DataGridView();
            this.gtaTableSearch_textBox = new System.Windows.Forms.TextBox();
            this.gtaTable_listBox = new System.Windows.Forms.ListBox();
            this.gtaItuClear_button = new System.Windows.Forms.Button();
            this.gtaActsnClear_button = new System.Windows.Forms.Button();
            this.gtaClear_button = new System.Windows.Forms.Button();
            this.gtaTableClear_button = new System.Windows.Forms.Button();
            this.gtaMrnsetClear_button = new System.Windows.Forms.Button();
            this.gtaCdselidClear_button = new System.Windows.Forms.Button();
            this.gtaOptsnClear_button = new System.Windows.Forms.Button();
            this.gtaLoopsetClear_Clear_button = new System.Windows.Forms.Button();
            this.numRecords_label = new System.Windows.Forms.Label();
            this.gtaTable_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gta_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gtaItupc_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gtaOptsn_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gtaLoopset_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gtaMrnset_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gtaActsn_linkLabel = new System.Windows.Forms.LinkLabel();
            this.clear_button = new System.Windows.Forms.Button();
            this.excel_button = new System.Windows.Forms.Button();
            this.gtaMapset_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gtaMapsetClear_button = new System.Windows.Forms.Button();
            this.gtaMapsetSearch_textBox = new System.Windows.Forms.TextBox();
            this.gtaMapset_listBox = new System.Windows.Forms.ListBox();
            this.gtaSsn_linkLabel = new System.Windows.Forms.LinkLabel();
            this.gtaSsnClear_button = new System.Windows.Forms.Button();
            this.gtaSsnSearch_textBox = new System.Windows.Forms.TextBox();
            this.gtaSsn_listBox = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gtaItuSearch_textBox
            // 
            this.gtaItuSearch_textBox.Location = new System.Drawing.Point(245, 16);
            this.gtaItuSearch_textBox.Name = "gtaItuSearch_textBox";
            this.gtaItuSearch_textBox.Size = new System.Drawing.Size(43, 20);
            this.gtaItuSearch_textBox.TabIndex = 332;
            this.gtaItuSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gtaItu_listBox
            // 
            this.gtaItu_listBox.FormattingEnabled = true;
            this.gtaItu_listBox.Location = new System.Drawing.Point(245, 41);
            this.gtaItu_listBox.Name = "gtaItu_listBox";
            this.gtaItu_listBox.Size = new System.Drawing.Size(71, 69);
            this.gtaItu_listBox.TabIndex = 331;
            this.gtaItu_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gtaActsnSearch_textBox
            // 
            this.gtaActsnSearch_textBox.Location = new System.Drawing.Point(792, 16);
            this.gtaActsnSearch_textBox.Name = "gtaActsnSearch_textBox";
            this.gtaActsnSearch_textBox.Size = new System.Drawing.Size(52, 20);
            this.gtaActsnSearch_textBox.TabIndex = 327;
            this.gtaActsnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gtaActsn_listBox
            // 
            this.gtaActsn_listBox.FormattingEnabled = true;
            this.gtaActsn_listBox.Location = new System.Drawing.Point(792, 41);
            this.gtaActsn_listBox.Name = "gtaActsn_listBox";
            this.gtaActsn_listBox.Size = new System.Drawing.Size(80, 69);
            this.gtaActsn_listBox.TabIndex = 326;
            this.gtaActsn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gtaCdselidSearch_textBox
            // 
            this.gtaCdselidSearch_textBox.Location = new System.Drawing.Point(721, 16);
            this.gtaCdselidSearch_textBox.Name = "gtaCdselidSearch_textBox";
            this.gtaCdselidSearch_textBox.Size = new System.Drawing.Size(35, 20);
            this.gtaCdselidSearch_textBox.TabIndex = 319;
            this.gtaCdselidSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gtaCdselid_listBox
            // 
            this.gtaCdselid_listBox.FormattingEnabled = true;
            this.gtaCdselid_listBox.Location = new System.Drawing.Point(721, 41);
            this.gtaCdselid_listBox.Name = "gtaCdselid_listBox";
            this.gtaCdselid_listBox.Size = new System.Drawing.Size(63, 69);
            this.gtaCdselid_listBox.TabIndex = 318;
            this.gtaCdselid_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(719, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 12);
            this.label3.TabIndex = 317;
            this.label3.Text = "CDSELID";
            // 
            // gtaOptsnSearch_textBox
            // 
            this.gtaOptsnSearch_textBox.Location = new System.Drawing.Point(617, 16);
            this.gtaOptsnSearch_textBox.Name = "gtaOptsnSearch_textBox";
            this.gtaOptsnSearch_textBox.Size = new System.Drawing.Size(68, 20);
            this.gtaOptsnSearch_textBox.TabIndex = 316;
            this.gtaOptsnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gtaOptsn_listBox
            // 
            this.gtaOptsn_listBox.FormattingEnabled = true;
            this.gtaOptsn_listBox.Location = new System.Drawing.Point(617, 41);
            this.gtaOptsn_listBox.Name = "gtaOptsn_listBox";
            this.gtaOptsn_listBox.Size = new System.Drawing.Size(96, 69);
            this.gtaOptsn_listBox.TabIndex = 315;
            this.gtaOptsn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gtaLoopsetSearch_textBox
            // 
            this.gtaLoopsetSearch_textBox.Location = new System.Drawing.Point(536, 16);
            this.gtaLoopsetSearch_textBox.Name = "gtaLoopsetSearch_textBox";
            this.gtaLoopsetSearch_textBox.Size = new System.Drawing.Size(45, 20);
            this.gtaLoopsetSearch_textBox.TabIndex = 313;
            this.gtaLoopsetSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gtaLoopset_listBox
            // 
            this.gtaLoopset_listBox.FormattingEnabled = true;
            this.gtaLoopset_listBox.Location = new System.Drawing.Point(536, 41);
            this.gtaLoopset_listBox.Name = "gtaLoopset_listBox";
            this.gtaLoopset_listBox.Size = new System.Drawing.Size(73, 69);
            this.gtaLoopset_listBox.TabIndex = 312;
            this.gtaLoopset_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gtaMrnsetSearch_textBox
            // 
            this.gtaMrnsetSearch_textBox.Location = new System.Drawing.Point(324, 16);
            this.gtaMrnsetSearch_textBox.Name = "gtaMrnsetSearch_textBox";
            this.gtaMrnsetSearch_textBox.Size = new System.Drawing.Size(38, 20);
            this.gtaMrnsetSearch_textBox.TabIndex = 310;
            this.gtaMrnsetSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gtaMrnset_listBox
            // 
            this.gtaMrnset_listBox.FormattingEnabled = true;
            this.gtaMrnset_listBox.Location = new System.Drawing.Point(324, 41);
            this.gtaMrnset_listBox.Name = "gtaMrnset_listBox";
            this.gtaMrnset_listBox.Size = new System.Drawing.Size(66, 69);
            this.gtaMrnset_listBox.TabIndex = 309;
            this.gtaMrnset_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gtaSearch_textBox
            // 
            this.gtaSearch_textBox.Location = new System.Drawing.Point(111, 16);
            this.gtaSearch_textBox.Name = "gtaSearch_textBox";
            this.gtaSearch_textBox.Size = new System.Drawing.Size(98, 20);
            this.gtaSearch_textBox.TabIndex = 307;
            this.gtaSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gta_listBox
            // 
            this.gta_listBox.FormattingEnabled = true;
            this.gta_listBox.Location = new System.Drawing.Point(111, 41);
            this.gta_listBox.Name = "gta_listBox";
            this.gta_listBox.Size = new System.Drawing.Size(126, 69);
            this.gta_listBox.TabIndex = 306;
            this.gta_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // search_dataGridView
            // 
            this.search_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.search_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.search_dataGridView.Location = new System.Drawing.Point(3, 120);
            this.search_dataGridView.Name = "search_dataGridView";
            this.search_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.search_dataGridView.Size = new System.Drawing.Size(870, 343);
            this.search_dataGridView.TabIndex = 304;
            // 
            // gtaTableSearch_textBox
            // 
            this.gtaTableSearch_textBox.Location = new System.Drawing.Point(3, 16);
            this.gtaTableSearch_textBox.Name = "gtaTableSearch_textBox";
            this.gtaTableSearch_textBox.Size = new System.Drawing.Size(72, 20);
            this.gtaTableSearch_textBox.TabIndex = 303;
            this.gtaTableSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gtaTable_listBox
            // 
            this.gtaTable_listBox.FormattingEnabled = true;
            this.gtaTable_listBox.Location = new System.Drawing.Point(3, 41);
            this.gtaTable_listBox.Name = "gtaTable_listBox";
            this.gtaTable_listBox.Size = new System.Drawing.Size(100, 69);
            this.gtaTable_listBox.TabIndex = 302;
            this.gtaTable_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gtaItuClear_button
            // 
            this.gtaItuClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gtaItuClear_button.BackgroundImage")));
            this.gtaItuClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gtaItuClear_button.Enabled = false;
            this.gtaItuClear_button.Location = new System.Drawing.Point(294, 15);
            this.gtaItuClear_button.Name = "gtaItuClear_button";
            this.gtaItuClear_button.Size = new System.Drawing.Size(22, 22);
            this.gtaItuClear_button.TabIndex = 333;
            this.gtaItuClear_button.UseVisualStyleBackColor = true;
            this.gtaItuClear_button.Click += new System.EventHandler(this.gtaItuClear_button_Click);
            // 
            // gtaActsnClear_button
            // 
            this.gtaActsnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gtaActsnClear_button.BackgroundImage")));
            this.gtaActsnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gtaActsnClear_button.Enabled = false;
            this.gtaActsnClear_button.Location = new System.Drawing.Point(850, 15);
            this.gtaActsnClear_button.Name = "gtaActsnClear_button";
            this.gtaActsnClear_button.Size = new System.Drawing.Size(22, 22);
            this.gtaActsnClear_button.TabIndex = 328;
            this.gtaActsnClear_button.UseVisualStyleBackColor = true;
            this.gtaActsnClear_button.Click += new System.EventHandler(this.gtaActsnClear_button_Click);
            // 
            // gtaClear_button
            // 
            this.gtaClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gtaClear_button.BackgroundImage")));
            this.gtaClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gtaClear_button.Enabled = false;
            this.gtaClear_button.Location = new System.Drawing.Point(215, 15);
            this.gtaClear_button.Name = "gtaClear_button";
            this.gtaClear_button.Size = new System.Drawing.Size(22, 22);
            this.gtaClear_button.TabIndex = 325;
            this.gtaClear_button.UseVisualStyleBackColor = true;
            this.gtaClear_button.Click += new System.EventHandler(this.gtaClear_button_Click);
            // 
            // gtaTableClear_button
            // 
            this.gtaTableClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gtaTableClear_button.BackgroundImage")));
            this.gtaTableClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gtaTableClear_button.Enabled = false;
            this.gtaTableClear_button.Location = new System.Drawing.Point(81, 15);
            this.gtaTableClear_button.Name = "gtaTableClear_button";
            this.gtaTableClear_button.Size = new System.Drawing.Size(22, 22);
            this.gtaTableClear_button.TabIndex = 324;
            this.gtaTableClear_button.UseVisualStyleBackColor = true;
            this.gtaTableClear_button.Click += new System.EventHandler(this.gtaTableClear_button_Click);
            // 
            // gtaMrnsetClear_button
            // 
            this.gtaMrnsetClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gtaMrnsetClear_button.BackgroundImage")));
            this.gtaMrnsetClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gtaMrnsetClear_button.Enabled = false;
            this.gtaMrnsetClear_button.Location = new System.Drawing.Point(368, 15);
            this.gtaMrnsetClear_button.Name = "gtaMrnsetClear_button";
            this.gtaMrnsetClear_button.Size = new System.Drawing.Size(22, 22);
            this.gtaMrnsetClear_button.TabIndex = 323;
            this.gtaMrnsetClear_button.UseVisualStyleBackColor = true;
            this.gtaMrnsetClear_button.Click += new System.EventHandler(this.gtaMrnsetClear_button_Click);
            // 
            // gtaCdselidClear_button
            // 
            this.gtaCdselidClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gtaCdselidClear_button.BackgroundImage")));
            this.gtaCdselidClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gtaCdselidClear_button.Enabled = false;
            this.gtaCdselidClear_button.Location = new System.Drawing.Point(762, 15);
            this.gtaCdselidClear_button.Name = "gtaCdselidClear_button";
            this.gtaCdselidClear_button.Size = new System.Drawing.Size(22, 22);
            this.gtaCdselidClear_button.TabIndex = 322;
            this.gtaCdselidClear_button.UseVisualStyleBackColor = true;
            this.gtaCdselidClear_button.Click += new System.EventHandler(this.gtaCdselidClear_button_Click);
            // 
            // gtaOptsnClear_button
            // 
            this.gtaOptsnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gtaOptsnClear_button.BackgroundImage")));
            this.gtaOptsnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gtaOptsnClear_button.Enabled = false;
            this.gtaOptsnClear_button.Location = new System.Drawing.Point(691, 15);
            this.gtaOptsnClear_button.Name = "gtaOptsnClear_button";
            this.gtaOptsnClear_button.Size = new System.Drawing.Size(22, 22);
            this.gtaOptsnClear_button.TabIndex = 321;
            this.gtaOptsnClear_button.UseVisualStyleBackColor = true;
            this.gtaOptsnClear_button.Click += new System.EventHandler(this.gtaOptsnClear_button_Click);
            // 
            // gtaLoopsetClear_Clear_button
            // 
            this.gtaLoopsetClear_Clear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gtaLoopsetClear_Clear_button.BackgroundImage")));
            this.gtaLoopsetClear_Clear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gtaLoopsetClear_Clear_button.Enabled = false;
            this.gtaLoopsetClear_Clear_button.Location = new System.Drawing.Point(587, 15);
            this.gtaLoopsetClear_Clear_button.Name = "gtaLoopsetClear_Clear_button";
            this.gtaLoopsetClear_Clear_button.Size = new System.Drawing.Size(22, 22);
            this.gtaLoopsetClear_Clear_button.TabIndex = 320;
            this.gtaLoopsetClear_Clear_button.UseVisualStyleBackColor = true;
            this.gtaLoopsetClear_Clear_button.Click += new System.EventHandler(this.gtaLoopsetClear_Clear_button_Click);
            // 
            // numRecords_label
            // 
            this.numRecords_label.AutoSize = true;
            this.numRecords_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRecords_label.Location = new System.Drawing.Point(171, 0);
            this.numRecords_label.Name = "numRecords_label";
            this.numRecords_label.Size = new System.Drawing.Size(111, 12);
            this.numRecords_label.TabIndex = 334;
            this.numRecords_label.Text = "Number of records: 15000";
            this.numRecords_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gtaTable_linkLabel
            // 
            this.gtaTable_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gtaTable_linkLabel.AutoSize = true;
            this.gtaTable_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gtaTable_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gtaTable_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaTable_linkLabel.Location = new System.Drawing.Point(1, 2);
            this.gtaTable_linkLabel.Name = "gtaTable_linkLabel";
            this.gtaTable_linkLabel.Size = new System.Drawing.Size(34, 12);
            this.gtaTable_linkLabel.TabIndex = 342;
            this.gtaTable_linkLabel.TabStop = true;
            this.gtaTable_linkLabel.Text = "TABLE";
            this.gtaTable_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaTable_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gtaTable_linkLabel_LinkClicked);
            // 
            // gta_linkLabel
            // 
            this.gta_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gta_linkLabel.AutoSize = true;
            this.gta_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gta_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gta_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gta_linkLabel.Location = new System.Drawing.Point(109, 2);
            this.gta_linkLabel.Name = "gta_linkLabel";
            this.gta_linkLabel.Size = new System.Drawing.Size(24, 12);
            this.gta_linkLabel.TabIndex = 343;
            this.gta_linkLabel.TabStop = true;
            this.gta_linkLabel.Text = "GTA";
            this.gta_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gta_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gta_linkLabel_LinkClicked);
            // 
            // gtaItupc_linkLabel
            // 
            this.gtaItupc_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gtaItupc_linkLabel.AutoSize = true;
            this.gtaItupc_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gtaItupc_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gtaItupc_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaItupc_linkLabel.Location = new System.Drawing.Point(243, 2);
            this.gtaItupc_linkLabel.Name = "gtaItupc_linkLabel";
            this.gtaItupc_linkLabel.Size = new System.Drawing.Size(35, 12);
            this.gtaItupc_linkLabel.TabIndex = 344;
            this.gtaItupc_linkLabel.TabStop = true;
            this.gtaItupc_linkLabel.Text = "ITU PC";
            this.gtaItupc_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaItupc_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gtaItupc_linkLabel_LinkClicked);
            // 
            // gtaOptsn_linkLabel
            // 
            this.gtaOptsn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gtaOptsn_linkLabel.AutoSize = true;
            this.gtaOptsn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gtaOptsn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gtaOptsn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaOptsn_linkLabel.Location = new System.Drawing.Point(615, 2);
            this.gtaOptsn_linkLabel.Name = "gtaOptsn_linkLabel";
            this.gtaOptsn_linkLabel.Size = new System.Drawing.Size(36, 12);
            this.gtaOptsn_linkLabel.TabIndex = 347;
            this.gtaOptsn_linkLabel.TabStop = true;
            this.gtaOptsn_linkLabel.Text = "OPTSN";
            this.gtaOptsn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaOptsn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gtaOptsn_linkLabel_LinkClicked);
            // 
            // gtaLoopset_linkLabel
            // 
            this.gtaLoopset_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gtaLoopset_linkLabel.AutoSize = true;
            this.gtaLoopset_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gtaLoopset_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gtaLoopset_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaLoopset_linkLabel.Location = new System.Drawing.Point(534, 2);
            this.gtaLoopset_linkLabel.Name = "gtaLoopset_linkLabel";
            this.gtaLoopset_linkLabel.Size = new System.Drawing.Size(47, 12);
            this.gtaLoopset_linkLabel.TabIndex = 346;
            this.gtaLoopset_linkLabel.TabStop = true;
            this.gtaLoopset_linkLabel.Text = "LOOPSET";
            this.gtaLoopset_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaLoopset_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gtaLoopset_linkLabel_LinkClicked);
            // 
            // gtaMrnset_linkLabel
            // 
            this.gtaMrnset_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gtaMrnset_linkLabel.AutoSize = true;
            this.gtaMrnset_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gtaMrnset_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gtaMrnset_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaMrnset_linkLabel.Location = new System.Drawing.Point(322, 2);
            this.gtaMrnset_linkLabel.Name = "gtaMrnset_linkLabel";
            this.gtaMrnset_linkLabel.Size = new System.Drawing.Size(45, 12);
            this.gtaMrnset_linkLabel.TabIndex = 345;
            this.gtaMrnset_linkLabel.TabStop = true;
            this.gtaMrnset_linkLabel.Text = "MRNSET";
            this.gtaMrnset_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaMrnset_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gtaMrnset_linkLabel_LinkClicked);
            // 
            // gtaActsn_linkLabel
            // 
            this.gtaActsn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gtaActsn_linkLabel.AutoSize = true;
            this.gtaActsn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gtaActsn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gtaActsn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaActsn_linkLabel.Location = new System.Drawing.Point(790, 2);
            this.gtaActsn_linkLabel.Name = "gtaActsn_linkLabel";
            this.gtaActsn_linkLabel.Size = new System.Drawing.Size(37, 12);
            this.gtaActsn_linkLabel.TabIndex = 348;
            this.gtaActsn_linkLabel.TabStop = true;
            this.gtaActsn_linkLabel.Text = "ACTSN";
            this.gtaActsn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaActsn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gtaActsn_linkLabel_LinkClicked);
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
            this.clear_button.TabIndex = 350;
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
            this.excel_button.TabIndex = 349;
            this.excel_button.Text = "  Generate Section Excel";
            this.excel_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.excel_button.UseVisualStyleBackColor = false;
            this.excel_button.Click += new System.EventHandler(this.excel_button_Click);
            // 
            // gtaMapset_linkLabel
            // 
            this.gtaMapset_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gtaMapset_linkLabel.AutoSize = true;
            this.gtaMapset_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gtaMapset_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gtaMapset_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaMapset_linkLabel.Location = new System.Drawing.Point(396, 2);
            this.gtaMapset_linkLabel.Name = "gtaMapset_linkLabel";
            this.gtaMapset_linkLabel.Size = new System.Drawing.Size(44, 12);
            this.gtaMapset_linkLabel.TabIndex = 354;
            this.gtaMapset_linkLabel.TabStop = true;
            this.gtaMapset_linkLabel.Text = "MAPSET";
            this.gtaMapset_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaMapset_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gtaMapset_linkLabel_LinkClicked);
            // 
            // gtaMapsetClear_button
            // 
            this.gtaMapsetClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gtaMapsetClear_button.BackgroundImage")));
            this.gtaMapsetClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gtaMapsetClear_button.Enabled = false;
            this.gtaMapsetClear_button.Location = new System.Drawing.Point(442, 15);
            this.gtaMapsetClear_button.Name = "gtaMapsetClear_button";
            this.gtaMapsetClear_button.Size = new System.Drawing.Size(22, 22);
            this.gtaMapsetClear_button.TabIndex = 353;
            this.gtaMapsetClear_button.UseVisualStyleBackColor = true;
            this.gtaMapsetClear_button.Click += new System.EventHandler(this.gtaMapsetClear_button_Click);
            // 
            // gtaMapsetSearch_textBox
            // 
            this.gtaMapsetSearch_textBox.Location = new System.Drawing.Point(398, 16);
            this.gtaMapsetSearch_textBox.Name = "gtaMapsetSearch_textBox";
            this.gtaMapsetSearch_textBox.Size = new System.Drawing.Size(38, 20);
            this.gtaMapsetSearch_textBox.TabIndex = 352;
            this.gtaMapsetSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gtaMapset_listBox
            // 
            this.gtaMapset_listBox.FormattingEnabled = true;
            this.gtaMapset_listBox.Location = new System.Drawing.Point(398, 41);
            this.gtaMapset_listBox.Name = "gtaMapset_listBox";
            this.gtaMapset_listBox.Size = new System.Drawing.Size(66, 69);
            this.gtaMapset_listBox.TabIndex = 351;
            this.gtaMapset_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // gtaSsn_linkLabel
            // 
            this.gtaSsn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.gtaSsn_linkLabel.AutoSize = true;
            this.gtaSsn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.gtaSsn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.gtaSsn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaSsn_linkLabel.Location = new System.Drawing.Point(470, 2);
            this.gtaSsn_linkLabel.Name = "gtaSsn_linkLabel";
            this.gtaSsn_linkLabel.Size = new System.Drawing.Size(24, 12);
            this.gtaSsn_linkLabel.TabIndex = 358;
            this.gtaSsn_linkLabel.TabStop = true;
            this.gtaSsn_linkLabel.Text = "SSN";
            this.gtaSsn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.gtaSsn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gtaSsn_linkLabel_LinkClicked);
            // 
            // gtaSsnClear_button
            // 
            this.gtaSsnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gtaSsnClear_button.BackgroundImage")));
            this.gtaSsnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gtaSsnClear_button.Enabled = false;
            this.gtaSsnClear_button.Location = new System.Drawing.Point(506, 15);
            this.gtaSsnClear_button.Name = "gtaSsnClear_button";
            this.gtaSsnClear_button.Size = new System.Drawing.Size(22, 22);
            this.gtaSsnClear_button.TabIndex = 357;
            this.gtaSsnClear_button.UseVisualStyleBackColor = true;
            this.gtaSsnClear_button.Click += new System.EventHandler(this.gtaSsnClear_button_Click);
            // 
            // gtaSsnSearch_textBox
            // 
            this.gtaSsnSearch_textBox.Location = new System.Drawing.Point(472, 16);
            this.gtaSsnSearch_textBox.Name = "gtaSsnSearch_textBox";
            this.gtaSsnSearch_textBox.Size = new System.Drawing.Size(28, 20);
            this.gtaSsnSearch_textBox.TabIndex = 356;
            this.gtaSsnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // gtaSsn_listBox
            // 
            this.gtaSsn_listBox.FormattingEnabled = true;
            this.gtaSsn_listBox.Location = new System.Drawing.Point(472, 41);
            this.gtaSsn_listBox.Name = "gtaSsn_listBox";
            this.gtaSsn_listBox.Size = new System.Drawing.Size(56, 69);
            this.gtaSsn_listBox.TabIndex = 355;
            this.gtaSsn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.numRecords_label);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(587, 464);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(285, 29);
            this.flowLayoutPanel1.TabIndex = 359;
            // 
            // GTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gtaSsn_linkLabel);
            this.Controls.Add(this.gtaSsnClear_button);
            this.Controls.Add(this.gtaSsnSearch_textBox);
            this.Controls.Add(this.gtaSsn_listBox);
            this.Controls.Add(this.gtaMapset_linkLabel);
            this.Controls.Add(this.gtaMapsetClear_button);
            this.Controls.Add(this.gtaMapsetSearch_textBox);
            this.Controls.Add(this.gtaMapset_listBox);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.gtaActsn_linkLabel);
            this.Controls.Add(this.gtaOptsn_linkLabel);
            this.Controls.Add(this.gtaLoopset_linkLabel);
            this.Controls.Add(this.gtaMrnset_linkLabel);
            this.Controls.Add(this.gtaItupc_linkLabel);
            this.Controls.Add(this.gta_linkLabel);
            this.Controls.Add(this.gtaTable_linkLabel);
            this.Controls.Add(this.gtaItuClear_button);
            this.Controls.Add(this.gtaItuSearch_textBox);
            this.Controls.Add(this.gtaItu_listBox);
            this.Controls.Add(this.gtaActsnClear_button);
            this.Controls.Add(this.gtaActsnSearch_textBox);
            this.Controls.Add(this.gtaActsn_listBox);
            this.Controls.Add(this.gtaClear_button);
            this.Controls.Add(this.gtaTableClear_button);
            this.Controls.Add(this.gtaMrnsetClear_button);
            this.Controls.Add(this.gtaCdselidClear_button);
            this.Controls.Add(this.gtaOptsnClear_button);
            this.Controls.Add(this.gtaLoopsetClear_Clear_button);
            this.Controls.Add(this.gtaCdselidSearch_textBox);
            this.Controls.Add(this.gtaCdselid_listBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gtaOptsnSearch_textBox);
            this.Controls.Add(this.gtaOptsn_listBox);
            this.Controls.Add(this.gtaLoopsetSearch_textBox);
            this.Controls.Add(this.gtaLoopset_listBox);
            this.Controls.Add(this.gtaMrnsetSearch_textBox);
            this.Controls.Add(this.gtaMrnset_listBox);
            this.Controls.Add(this.gtaSearch_textBox);
            this.Controls.Add(this.gta_listBox);
            this.Controls.Add(this.search_dataGridView);
            this.Controls.Add(this.gtaTableSearch_textBox);
            this.Controls.Add(this.gtaTable_listBox);
            this.Name = "GTA";
            this.Size = new System.Drawing.Size(876, 502);
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gtaItuClear_button;
        private System.Windows.Forms.TextBox gtaItuSearch_textBox;
        private System.Windows.Forms.ListBox gtaItu_listBox;
        private System.Windows.Forms.Button gtaActsnClear_button;
        private System.Windows.Forms.TextBox gtaActsnSearch_textBox;
        private System.Windows.Forms.ListBox gtaActsn_listBox;
        private System.Windows.Forms.Button gtaClear_button;
        private System.Windows.Forms.Button gtaTableClear_button;
        private System.Windows.Forms.Button gtaMrnsetClear_button;
        private System.Windows.Forms.Button gtaCdselidClear_button;
        private System.Windows.Forms.Button gtaOptsnClear_button;
        private System.Windows.Forms.Button gtaLoopsetClear_Clear_button;
        private System.Windows.Forms.TextBox gtaCdselidSearch_textBox;
        private System.Windows.Forms.ListBox gtaCdselid_listBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox gtaOptsnSearch_textBox;
        private System.Windows.Forms.ListBox gtaOptsn_listBox;
        private System.Windows.Forms.TextBox gtaLoopsetSearch_textBox;
        private System.Windows.Forms.ListBox gtaLoopset_listBox;
        private System.Windows.Forms.TextBox gtaMrnsetSearch_textBox;
        private System.Windows.Forms.ListBox gtaMrnset_listBox;
        private System.Windows.Forms.TextBox gtaSearch_textBox;
        private System.Windows.Forms.ListBox gta_listBox;
        private System.Windows.Forms.DataGridView search_dataGridView;
        private System.Windows.Forms.TextBox gtaTableSearch_textBox;
        private System.Windows.Forms.ListBox gtaTable_listBox;
        private System.Windows.Forms.Label numRecords_label;
        private System.Windows.Forms.LinkLabel gtaTable_linkLabel;
        private System.Windows.Forms.LinkLabel gta_linkLabel;
        private System.Windows.Forms.LinkLabel gtaItupc_linkLabel;
        private System.Windows.Forms.LinkLabel gtaOptsn_linkLabel;
        private System.Windows.Forms.LinkLabel gtaLoopset_linkLabel;
        private System.Windows.Forms.LinkLabel gtaMrnset_linkLabel;
        private System.Windows.Forms.LinkLabel gtaActsn_linkLabel;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.LinkLabel gtaMapset_linkLabel;
        private System.Windows.Forms.Button gtaMapsetClear_button;
        private System.Windows.Forms.TextBox gtaMapsetSearch_textBox;
        private System.Windows.Forms.ListBox gtaMapset_listBox;
        private System.Windows.Forms.LinkLabel gtaSsn_linkLabel;
        private System.Windows.Forms.Button gtaSsnClear_button;
        private System.Windows.Forms.TextBox gtaSsnSearch_textBox;
        private System.Windows.Forms.ListBox gtaSsn_listBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
