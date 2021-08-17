namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    partial class OPCODE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OPCODE));
            this.numRecords_label = new System.Windows.Forms.Label();
            this.opItuClear_button = new System.Windows.Forms.Button();
            this.opItuSearch_textBox = new System.Windows.Forms.TextBox();
            this.opItu_listBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.opActsnClear_button = new System.Windows.Forms.Button();
            this.opActsnSearch_textBox = new System.Windows.Forms.TextBox();
            this.opActsn_listBox = new System.Windows.Forms.ListBox();
            this.opcodeClear_button = new System.Windows.Forms.Button();
            this.opTableClear_button = new System.Windows.Forms.Button();
            this.opMrnsetClear_button = new System.Windows.Forms.Button();
            this.opCdselidClear_button = new System.Windows.Forms.Button();
            this.opOptsnClear_button = new System.Windows.Forms.Button();
            this.opLoopsetClear_button = new System.Windows.Forms.Button();
            this.opCdselidSearch_textBox = new System.Windows.Forms.TextBox();
            this.opCdselid_listBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.opOptsnSearch_textBox = new System.Windows.Forms.TextBox();
            this.opOptsn_listBox = new System.Windows.Forms.ListBox();
            this.opLoopsetSearch_textBox = new System.Windows.Forms.TextBox();
            this.opLoopset_listBox = new System.Windows.Forms.ListBox();
            this.opMrnsetSearch_textBox = new System.Windows.Forms.TextBox();
            this.opMrnset_listBox = new System.Windows.Forms.ListBox();
            this.opcodeSearch_textBox = new System.Windows.Forms.TextBox();
            this.opcode_listBox = new System.Windows.Forms.ListBox();
            this.search_dataGridView = new System.Windows.Forms.DataGridView();
            this.opTableSearch_textBox = new System.Windows.Forms.TextBox();
            this.opTable_listBox = new System.Windows.Forms.ListBox();
            this.opItupc_linkLabel = new System.Windows.Forms.LinkLabel();
            this.opcode_linkLabel = new System.Windows.Forms.LinkLabel();
            this.opTable_linkLabel = new System.Windows.Forms.LinkLabel();
            this.opMrnset_linkLabel = new System.Windows.Forms.LinkLabel();
            this.opLoopset_linkLabel = new System.Windows.Forms.LinkLabel();
            this.opOptsn_linkLabel = new System.Windows.Forms.LinkLabel();
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
            this.numRecords_label.Location = new System.Drawing.Point(233, 0);
            this.numRecords_label.Name = "numRecords_label";
            this.numRecords_label.Size = new System.Drawing.Size(111, 12);
            this.numRecords_label.TabIndex = 335;
            this.numRecords_label.Text = "Number of records: 15000";
            this.numRecords_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // opItuClear_button
            // 
            this.opItuClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opItuClear_button.BackgroundImage")));
            this.opItuClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opItuClear_button.Enabled = false;
            this.opItuClear_button.Location = new System.Drawing.Point(299, 15);
            this.opItuClear_button.Name = "opItuClear_button";
            this.opItuClear_button.Size = new System.Drawing.Size(22, 22);
            this.opItuClear_button.TabIndex = 300;
            this.opItuClear_button.UseVisualStyleBackColor = true;
            this.opItuClear_button.Click += new System.EventHandler(this.opItuClear_button_Click);
            // 
            // opItuSearch_textBox
            // 
            this.opItuSearch_textBox.Location = new System.Drawing.Point(237, 16);
            this.opItuSearch_textBox.Name = "opItuSearch_textBox";
            this.opItuSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.opItuSearch_textBox.TabIndex = 299;
            this.opItuSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // opItu_listBox
            // 
            this.opItu_listBox.FormattingEnabled = true;
            this.opItu_listBox.Location = new System.Drawing.Point(237, 41);
            this.opItu_listBox.Name = "opItu_listBox";
            this.opItu_listBox.Size = new System.Drawing.Size(84, 69);
            this.opItu_listBox.TabIndex = 298;
            this.opItu_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(779, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 296;
            this.label4.Text = "ACTSN";
            // 
            // opActsnClear_button
            // 
            this.opActsnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opActsnClear_button.BackgroundImage")));
            this.opActsnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opActsnClear_button.Enabled = false;
            this.opActsnClear_button.Location = new System.Drawing.Point(852, 15);
            this.opActsnClear_button.Name = "opActsnClear_button";
            this.opActsnClear_button.Size = new System.Drawing.Size(22, 22);
            this.opActsnClear_button.TabIndex = 295;
            this.opActsnClear_button.UseVisualStyleBackColor = true;
            this.opActsnClear_button.Click += new System.EventHandler(this.opActsnClear_button_Click);
            // 
            // opActsnSearch_textBox
            // 
            this.opActsnSearch_textBox.Location = new System.Drawing.Point(781, 16);
            this.opActsnSearch_textBox.Name = "opActsnSearch_textBox";
            this.opActsnSearch_textBox.Size = new System.Drawing.Size(65, 20);
            this.opActsnSearch_textBox.TabIndex = 294;
            this.opActsnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // opActsn_listBox
            // 
            this.opActsn_listBox.FormattingEnabled = true;
            this.opActsn_listBox.Location = new System.Drawing.Point(781, 41);
            this.opActsn_listBox.Name = "opActsn_listBox";
            this.opActsn_listBox.Size = new System.Drawing.Size(92, 69);
            this.opActsn_listBox.TabIndex = 293;
            this.opActsn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // opcodeClear_button
            // 
            this.opcodeClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opcodeClear_button.BackgroundImage")));
            this.opcodeClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opcodeClear_button.Enabled = false;
            this.opcodeClear_button.Location = new System.Drawing.Point(198, 14);
            this.opcodeClear_button.Name = "opcodeClear_button";
            this.opcodeClear_button.Size = new System.Drawing.Size(22, 22);
            this.opcodeClear_button.TabIndex = 292;
            this.opcodeClear_button.UseVisualStyleBackColor = true;
            this.opcodeClear_button.Click += new System.EventHandler(this.opcodeClear_button_Click);
            // 
            // opTableClear_button
            // 
            this.opTableClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opTableClear_button.BackgroundImage")));
            this.opTableClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opTableClear_button.Enabled = false;
            this.opTableClear_button.Location = new System.Drawing.Point(110, 14);
            this.opTableClear_button.Name = "opTableClear_button";
            this.opTableClear_button.Size = new System.Drawing.Size(22, 22);
            this.opTableClear_button.TabIndex = 291;
            this.opTableClear_button.UseVisualStyleBackColor = true;
            this.opTableClear_button.Click += new System.EventHandler(this.opTableClear_button_Click);
            // 
            // opMrnsetClear_button
            // 
            this.opMrnsetClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opMrnsetClear_button.BackgroundImage")));
            this.opMrnsetClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opMrnsetClear_button.Enabled = false;
            this.opMrnsetClear_button.Location = new System.Drawing.Point(399, 15);
            this.opMrnsetClear_button.Name = "opMrnsetClear_button";
            this.opMrnsetClear_button.Size = new System.Drawing.Size(22, 22);
            this.opMrnsetClear_button.TabIndex = 290;
            this.opMrnsetClear_button.UseVisualStyleBackColor = true;
            this.opMrnsetClear_button.Click += new System.EventHandler(this.opMrnsetClear_button_Click);
            // 
            // opCdselidClear_button
            // 
            this.opCdselidClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opCdselidClear_button.BackgroundImage")));
            this.opCdselidClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opCdselidClear_button.Enabled = false;
            this.opCdselidClear_button.Location = new System.Drawing.Point(740, 15);
            this.opCdselidClear_button.Name = "opCdselidClear_button";
            this.opCdselidClear_button.Size = new System.Drawing.Size(22, 22);
            this.opCdselidClear_button.TabIndex = 289;
            this.opCdselidClear_button.UseVisualStyleBackColor = true;
            this.opCdselidClear_button.Click += new System.EventHandler(this.opCdselidClear_button_Click);
            // 
            // opOptsnClear_button
            // 
            this.opOptsnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opOptsnClear_button.BackgroundImage")));
            this.opOptsnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opOptsnClear_button.Enabled = false;
            this.opOptsnClear_button.Location = new System.Drawing.Point(651, 15);
            this.opOptsnClear_button.Name = "opOptsnClear_button";
            this.opOptsnClear_button.Size = new System.Drawing.Size(22, 22);
            this.opOptsnClear_button.TabIndex = 288;
            this.opOptsnClear_button.UseVisualStyleBackColor = true;
            this.opOptsnClear_button.Click += new System.EventHandler(this.opOptsnClear_button_Click);
            // 
            // opLoopsetClear_button
            // 
            this.opLoopsetClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("opLoopsetClear_button.BackgroundImage")));
            this.opLoopsetClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.opLoopsetClear_button.Enabled = false;
            this.opLoopsetClear_button.Location = new System.Drawing.Point(525, 15);
            this.opLoopsetClear_button.Name = "opLoopsetClear_button";
            this.opLoopsetClear_button.Size = new System.Drawing.Size(22, 22);
            this.opLoopsetClear_button.TabIndex = 287;
            this.opLoopsetClear_button.UseVisualStyleBackColor = true;
            this.opLoopsetClear_button.Click += new System.EventHandler(this.opLoopsetClear_button_Click);
            // 
            // opCdselidSearch_textBox
            // 
            this.opCdselidSearch_textBox.Location = new System.Drawing.Point(690, 16);
            this.opCdselidSearch_textBox.Name = "opCdselidSearch_textBox";
            this.opCdselidSearch_textBox.Size = new System.Drawing.Size(44, 20);
            this.opCdselidSearch_textBox.TabIndex = 283;
            this.opCdselidSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // opCdselid_listBox
            // 
            this.opCdselid_listBox.FormattingEnabled = true;
            this.opCdselid_listBox.Location = new System.Drawing.Point(690, 41);
            this.opCdselid_listBox.Name = "opCdselid_listBox";
            this.opCdselid_listBox.Size = new System.Drawing.Size(72, 69);
            this.opCdselid_listBox.TabIndex = 282;
            this.opCdselid_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(688, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 12);
            this.label3.TabIndex = 281;
            this.label3.Text = "CDSELID";
            // 
            // opOptsnSearch_textBox
            // 
            this.opOptsnSearch_textBox.Location = new System.Drawing.Point(563, 16);
            this.opOptsnSearch_textBox.Name = "opOptsnSearch_textBox";
            this.opOptsnSearch_textBox.Size = new System.Drawing.Size(82, 20);
            this.opOptsnSearch_textBox.TabIndex = 280;
            this.opOptsnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // opOptsn_listBox
            // 
            this.opOptsn_listBox.FormattingEnabled = true;
            this.opOptsn_listBox.Location = new System.Drawing.Point(563, 41);
            this.opOptsn_listBox.Name = "opOptsn_listBox";
            this.opOptsn_listBox.Size = new System.Drawing.Size(109, 69);
            this.opOptsn_listBox.TabIndex = 279;
            this.opOptsn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // opLoopsetSearch_textBox
            // 
            this.opLoopsetSearch_textBox.Location = new System.Drawing.Point(437, 16);
            this.opLoopsetSearch_textBox.Name = "opLoopsetSearch_textBox";
            this.opLoopsetSearch_textBox.Size = new System.Drawing.Size(82, 20);
            this.opLoopsetSearch_textBox.TabIndex = 277;
            this.opLoopsetSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // opLoopset_listBox
            // 
            this.opLoopset_listBox.FormattingEnabled = true;
            this.opLoopset_listBox.Location = new System.Drawing.Point(437, 41);
            this.opLoopset_listBox.Name = "opLoopset_listBox";
            this.opLoopset_listBox.Size = new System.Drawing.Size(110, 69);
            this.opLoopset_listBox.TabIndex = 276;
            this.opLoopset_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // opMrnsetSearch_textBox
            // 
            this.opMrnsetSearch_textBox.Location = new System.Drawing.Point(337, 16);
            this.opMrnsetSearch_textBox.Name = "opMrnsetSearch_textBox";
            this.opMrnsetSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.opMrnsetSearch_textBox.TabIndex = 274;
            this.opMrnsetSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // opMrnset_listBox
            // 
            this.opMrnset_listBox.FormattingEnabled = true;
            this.opMrnset_listBox.Location = new System.Drawing.Point(337, 41);
            this.opMrnset_listBox.Name = "opMrnset_listBox";
            this.opMrnset_listBox.Size = new System.Drawing.Size(84, 69);
            this.opMrnset_listBox.TabIndex = 273;
            this.opMrnset_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // opcodeSearch_textBox
            // 
            this.opcodeSearch_textBox.Location = new System.Drawing.Point(149, 16);
            this.opcodeSearch_textBox.Name = "opcodeSearch_textBox";
            this.opcodeSearch_textBox.Size = new System.Drawing.Size(43, 20);
            this.opcodeSearch_textBox.TabIndex = 268;
            this.opcodeSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // opcode_listBox
            // 
            this.opcode_listBox.FormattingEnabled = true;
            this.opcode_listBox.Location = new System.Drawing.Point(149, 41);
            this.opcode_listBox.Name = "opcode_listBox";
            this.opcode_listBox.Size = new System.Drawing.Size(71, 69);
            this.opcode_listBox.TabIndex = 267;
            this.opcode_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
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
            // opTableSearch_textBox
            // 
            this.opTableSearch_textBox.Location = new System.Drawing.Point(3, 16);
            this.opTableSearch_textBox.Name = "opTableSearch_textBox";
            this.opTableSearch_textBox.Size = new System.Drawing.Size(101, 20);
            this.opTableSearch_textBox.TabIndex = 19;
            this.opTableSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // opTable_listBox
            // 
            this.opTable_listBox.FormattingEnabled = true;
            this.opTable_listBox.Location = new System.Drawing.Point(3, 41);
            this.opTable_listBox.Name = "opTable_listBox";
            this.opTable_listBox.Size = new System.Drawing.Size(128, 69);
            this.opTable_listBox.TabIndex = 18;
            this.opTable_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // opItupc_linkLabel
            // 
            this.opItupc_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.opItupc_linkLabel.AutoSize = true;
            this.opItupc_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.opItupc_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.opItupc_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.opItupc_linkLabel.Location = new System.Drawing.Point(235, 2);
            this.opItupc_linkLabel.Name = "opItupc_linkLabel";
            this.opItupc_linkLabel.Size = new System.Drawing.Size(35, 12);
            this.opItupc_linkLabel.TabIndex = 339;
            this.opItupc_linkLabel.TabStop = true;
            this.opItupc_linkLabel.Text = "ITU PC";
            this.opItupc_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.opItupc_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.opItupc_linkLabel_LinkClicked);
            // 
            // opcode_linkLabel
            // 
            this.opcode_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.opcode_linkLabel.AutoSize = true;
            this.opcode_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.opcode_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.opcode_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.opcode_linkLabel.Location = new System.Drawing.Point(147, 2);
            this.opcode_linkLabel.Name = "opcode_linkLabel";
            this.opcode_linkLabel.Size = new System.Drawing.Size(45, 12);
            this.opcode_linkLabel.TabIndex = 340;
            this.opcode_linkLabel.TabStop = true;
            this.opcode_linkLabel.Text = "OPCODE";
            this.opcode_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.opcode_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.opcode_linkLabel_LinkClicked);
            // 
            // opTable_linkLabel
            // 
            this.opTable_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.opTable_linkLabel.AutoSize = true;
            this.opTable_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.opTable_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.opTable_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.opTable_linkLabel.Location = new System.Drawing.Point(1, 2);
            this.opTable_linkLabel.Name = "opTable_linkLabel";
            this.opTable_linkLabel.Size = new System.Drawing.Size(34, 12);
            this.opTable_linkLabel.TabIndex = 341;
            this.opTable_linkLabel.TabStop = true;
            this.opTable_linkLabel.Text = "TABLE";
            this.opTable_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.opTable_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.opTable_linkLabel_LinkClicked);
            // 
            // opMrnset_linkLabel
            // 
            this.opMrnset_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.opMrnset_linkLabel.AutoSize = true;
            this.opMrnset_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.opMrnset_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.opMrnset_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.opMrnset_linkLabel.Location = new System.Drawing.Point(335, 2);
            this.opMrnset_linkLabel.Name = "opMrnset_linkLabel";
            this.opMrnset_linkLabel.Size = new System.Drawing.Size(45, 12);
            this.opMrnset_linkLabel.TabIndex = 342;
            this.opMrnset_linkLabel.TabStop = true;
            this.opMrnset_linkLabel.Text = "MRNSET";
            this.opMrnset_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.opMrnset_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.opMrnset_linkLabel_LinkClicked);
            // 
            // opLoopset_linkLabel
            // 
            this.opLoopset_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.opLoopset_linkLabel.AutoSize = true;
            this.opLoopset_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.opLoopset_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.opLoopset_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.opLoopset_linkLabel.Location = new System.Drawing.Point(435, 2);
            this.opLoopset_linkLabel.Name = "opLoopset_linkLabel";
            this.opLoopset_linkLabel.Size = new System.Drawing.Size(47, 12);
            this.opLoopset_linkLabel.TabIndex = 343;
            this.opLoopset_linkLabel.TabStop = true;
            this.opLoopset_linkLabel.Text = "LOOPSET";
            this.opLoopset_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.opLoopset_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.opLoopset_linkLabel_LinkClicked);
            // 
            // opOptsn_linkLabel
            // 
            this.opOptsn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.opOptsn_linkLabel.AutoSize = true;
            this.opOptsn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.opOptsn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.opOptsn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.opOptsn_linkLabel.Location = new System.Drawing.Point(561, 2);
            this.opOptsn_linkLabel.Name = "opOptsn_linkLabel";
            this.opOptsn_linkLabel.Size = new System.Drawing.Size(36, 12);
            this.opOptsn_linkLabel.TabIndex = 344;
            this.opOptsn_linkLabel.TabStop = true;
            this.opOptsn_linkLabel.Text = "OPTSN";
            this.opOptsn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.opOptsn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.opOptsn_linkLabel_LinkClicked);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(525, 466);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(347, 35);
            this.flowLayoutPanel1.TabIndex = 353;
            // 
            // OPCODE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.opOptsn_linkLabel);
            this.Controls.Add(this.opLoopset_linkLabel);
            this.Controls.Add(this.opMrnset_linkLabel);
            this.Controls.Add(this.opTable_linkLabel);
            this.Controls.Add(this.opcode_linkLabel);
            this.Controls.Add(this.opItupc_linkLabel);
            this.Controls.Add(this.opItuClear_button);
            this.Controls.Add(this.opItuSearch_textBox);
            this.Controls.Add(this.opTable_listBox);
            this.Controls.Add(this.opItu_listBox);
            this.Controls.Add(this.opTableSearch_textBox);
            this.Controls.Add(this.search_dataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.opActsnClear_button);
            this.Controls.Add(this.opcode_listBox);
            this.Controls.Add(this.opActsnSearch_textBox);
            this.Controls.Add(this.opcodeSearch_textBox);
            this.Controls.Add(this.opActsn_listBox);
            this.Controls.Add(this.opcodeClear_button);
            this.Controls.Add(this.opMrnset_listBox);
            this.Controls.Add(this.opTableClear_button);
            this.Controls.Add(this.opMrnsetSearch_textBox);
            this.Controls.Add(this.opMrnsetClear_button);
            this.Controls.Add(this.opCdselidClear_button);
            this.Controls.Add(this.opLoopset_listBox);
            this.Controls.Add(this.opOptsnClear_button);
            this.Controls.Add(this.opLoopsetSearch_textBox);
            this.Controls.Add(this.opLoopsetClear_button);
            this.Controls.Add(this.opCdselidSearch_textBox);
            this.Controls.Add(this.opOptsn_listBox);
            this.Controls.Add(this.opCdselid_listBox);
            this.Controls.Add(this.opOptsnSearch_textBox);
            this.Controls.Add(this.label3);
            this.Name = "OPCODE";
            this.Size = new System.Drawing.Size(876, 502);
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button opItuClear_button;
        private System.Windows.Forms.TextBox opItuSearch_textBox;
        private System.Windows.Forms.ListBox opItu_listBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button opActsnClear_button;
        private System.Windows.Forms.TextBox opActsnSearch_textBox;
        private System.Windows.Forms.ListBox opActsn_listBox;
        private System.Windows.Forms.Button opcodeClear_button;
        private System.Windows.Forms.Button opTableClear_button;
        private System.Windows.Forms.Button opMrnsetClear_button;
        private System.Windows.Forms.Button opCdselidClear_button;
        private System.Windows.Forms.Button opOptsnClear_button;
        private System.Windows.Forms.Button opLoopsetClear_button;
        private System.Windows.Forms.TextBox opCdselidSearch_textBox;
        private System.Windows.Forms.ListBox opCdselid_listBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox opOptsnSearch_textBox;
        private System.Windows.Forms.ListBox opOptsn_listBox;
        private System.Windows.Forms.TextBox opLoopsetSearch_textBox;
        private System.Windows.Forms.ListBox opLoopset_listBox;
        private System.Windows.Forms.TextBox opMrnsetSearch_textBox;
        private System.Windows.Forms.ListBox opMrnset_listBox;
        private System.Windows.Forms.TextBox opcodeSearch_textBox;
        private System.Windows.Forms.ListBox opcode_listBox;
        private System.Windows.Forms.DataGridView search_dataGridView;
        private System.Windows.Forms.TextBox opTableSearch_textBox;
        private System.Windows.Forms.ListBox opTable_listBox;
        private System.Windows.Forms.Label numRecords_label;
        private System.Windows.Forms.LinkLabel opItupc_linkLabel;
        private System.Windows.Forms.LinkLabel opcode_linkLabel;
        private System.Windows.Forms.LinkLabel opTable_linkLabel;
        private System.Windows.Forms.LinkLabel opMrnset_linkLabel;
        private System.Windows.Forms.LinkLabel opLoopset_linkLabel;
        private System.Windows.Forms.LinkLabel opOptsn_linkLabel;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
