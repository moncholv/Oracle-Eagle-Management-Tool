namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    partial class HOST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HOST));
            this.numRecords_label = new System.Windows.Forms.Label();
            this.hostIpClear_button = new System.Windows.Forms.Button();
            this.hostIpSearch_textBox = new System.Windows.Forms.TextBox();
            this.hostIp_listBox = new System.Windows.Forms.ListBox();
            this.hostLocClear_button = new System.Windows.Forms.Button();
            this.hostTypeClear_button = new System.Windows.Forms.Button();
            this.hostClear_button = new System.Windows.Forms.Button();
            this.hostSearch_textBox = new System.Windows.Forms.TextBox();
            this.host_listBox = new System.Windows.Forms.ListBox();
            this.hostTypeSearch_textBox = new System.Windows.Forms.TextBox();
            this.hostType_listBox = new System.Windows.Forms.ListBox();
            this.opcode_Mnrset_label = new System.Windows.Forms.Label();
            this.hostLocSearch_textBox = new System.Windows.Forms.TextBox();
            this.hostLoc_listBox = new System.Windows.Forms.ListBox();
            this.search_dataGridView = new System.Windows.Forms.DataGridView();
            this.mrnset_linkLabel = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
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
            this.numRecords_label.Location = new System.Drawing.Point(281, 0);
            this.numRecords_label.Name = "numRecords_label";
            this.numRecords_label.Size = new System.Drawing.Size(111, 12);
            this.numRecords_label.TabIndex = 335;
            this.numRecords_label.Text = "Number of records: 15000";
            this.numRecords_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hostIpClear_button
            // 
            this.hostIpClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hostIpClear_button.BackgroundImage")));
            this.hostIpClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hostIpClear_button.Enabled = false;
            this.hostIpClear_button.Location = new System.Drawing.Point(359, 16);
            this.hostIpClear_button.Name = "hostIpClear_button";
            this.hostIpClear_button.Size = new System.Drawing.Size(22, 22);
            this.hostIpClear_button.TabIndex = 300;
            this.hostIpClear_button.UseVisualStyleBackColor = true;
            this.hostIpClear_button.Click += new System.EventHandler(this.mrnsetPcClear_button_Click);
            // 
            // hostIpSearch_textBox
            // 
            this.hostIpSearch_textBox.Location = new System.Drawing.Point(269, 17);
            this.hostIpSearch_textBox.Name = "hostIpSearch_textBox";
            this.hostIpSearch_textBox.Size = new System.Drawing.Size(84, 20);
            this.hostIpSearch_textBox.TabIndex = 299;
            this.hostIpSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // hostIp_listBox
            // 
            this.hostIp_listBox.FormattingEnabled = true;
            this.hostIp_listBox.Location = new System.Drawing.Point(269, 42);
            this.hostIp_listBox.Name = "hostIp_listBox";
            this.hostIp_listBox.Size = new System.Drawing.Size(112, 69);
            this.hostIp_listBox.TabIndex = 298;
            this.hostIp_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // hostLocClear_button
            // 
            this.hostLocClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hostLocClear_button.BackgroundImage")));
            this.hostLocClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hostLocClear_button.Enabled = false;
            this.hostLocClear_button.Location = new System.Drawing.Point(227, 16);
            this.hostLocClear_button.Name = "hostLocClear_button";
            this.hostLocClear_button.Size = new System.Drawing.Size(22, 22);
            this.hostLocClear_button.TabIndex = 292;
            this.hostLocClear_button.UseVisualStyleBackColor = true;
            this.hostLocClear_button.Click += new System.EventHandler(this.mrnsetNetClear_button_Click);
            // 
            // hostTypeClear_button
            // 
            this.hostTypeClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hostTypeClear_button.BackgroundImage")));
            this.hostTypeClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hostTypeClear_button.Enabled = false;
            this.hostTypeClear_button.Location = new System.Drawing.Point(67, 16);
            this.hostTypeClear_button.Name = "hostTypeClear_button";
            this.hostTypeClear_button.Size = new System.Drawing.Size(22, 22);
            this.hostTypeClear_button.TabIndex = 290;
            this.hostTypeClear_button.UseVisualStyleBackColor = true;
            this.hostTypeClear_button.Click += new System.EventHandler(this.mrnsetClear_button_Click);
            // 
            // hostClear_button
            // 
            this.hostClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hostClear_button.BackgroundImage")));
            this.hostClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hostClear_button.Enabled = false;
            this.hostClear_button.Location = new System.Drawing.Point(509, 16);
            this.hostClear_button.Name = "hostClear_button";
            this.hostClear_button.Size = new System.Drawing.Size(22, 22);
            this.hostClear_button.TabIndex = 289;
            this.hostClear_button.UseVisualStyleBackColor = true;
            this.hostClear_button.Click += new System.EventHandler(this.mrnsetRcClear_button_Click);
            // 
            // hostSearch_textBox
            // 
            this.hostSearch_textBox.Location = new System.Drawing.Point(401, 17);
            this.hostSearch_textBox.Name = "hostSearch_textBox";
            this.hostSearch_textBox.Size = new System.Drawing.Size(102, 20);
            this.hostSearch_textBox.TabIndex = 283;
            this.hostSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // host_listBox
            // 
            this.host_listBox.FormattingEnabled = true;
            this.host_listBox.Location = new System.Drawing.Point(401, 42);
            this.host_listBox.Name = "host_listBox";
            this.host_listBox.Size = new System.Drawing.Size(130, 69);
            this.host_listBox.TabIndex = 282;
            this.host_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // hostTypeSearch_textBox
            // 
            this.hostTypeSearch_textBox.Location = new System.Drawing.Point(5, 17);
            this.hostTypeSearch_textBox.Name = "hostTypeSearch_textBox";
            this.hostTypeSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.hostTypeSearch_textBox.TabIndex = 274;
            this.hostTypeSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // hostType_listBox
            // 
            this.hostType_listBox.FormattingEnabled = true;
            this.hostType_listBox.Location = new System.Drawing.Point(5, 42);
            this.hostType_listBox.Name = "hostType_listBox";
            this.hostType_listBox.Size = new System.Drawing.Size(84, 69);
            this.hostType_listBox.TabIndex = 273;
            this.hostType_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // opcode_Mnrset_label
            // 
            this.opcode_Mnrset_label.AutoSize = true;
            this.opcode_Mnrset_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcode_Mnrset_label.Location = new System.Drawing.Point(3, 3);
            this.opcode_Mnrset_label.Name = "opcode_Mnrset_label";
            this.opcode_Mnrset_label.Size = new System.Drawing.Size(25, 12);
            this.opcode_Mnrset_label.TabIndex = 272;
            this.opcode_Mnrset_label.Text = "Type";
            // 
            // hostLocSearch_textBox
            // 
            this.hostLocSearch_textBox.Location = new System.Drawing.Point(107, 17);
            this.hostLocSearch_textBox.Name = "hostLocSearch_textBox";
            this.hostLocSearch_textBox.Size = new System.Drawing.Size(114, 20);
            this.hostLocSearch_textBox.TabIndex = 268;
            this.hostLocSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // hostLoc_listBox
            // 
            this.hostLoc_listBox.FormattingEnabled = true;
            this.hostLoc_listBox.Location = new System.Drawing.Point(107, 42);
            this.hostLoc_listBox.Name = "hostLoc_listBox";
            this.hostLoc_listBox.Size = new System.Drawing.Size(142, 69);
            this.hostLoc_listBox.TabIndex = 267;
            this.hostLoc_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // search_dataGridView
            // 
            this.search_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.search_dataGridView.Location = new System.Drawing.Point(4, 121);
            this.search_dataGridView.Name = "search_dataGridView";
            this.search_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.search_dataGridView.Size = new System.Drawing.Size(720, 343);
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
            this.mrnset_linkLabel.Location = new System.Drawing.Point(105, 3);
            this.mrnset_linkLabel.Name = "mrnset_linkLabel";
            this.mrnset_linkLabel.Size = new System.Drawing.Size(24, 12);
            this.mrnset_linkLabel.TabIndex = 339;
            this.mrnset_linkLabel.TabStop = true;
            this.mrnset_linkLabel.Text = "LOC";
            this.mrnset_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkLabel1.Location = new System.Drawing.Point(267, 3);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(42, 12);
            this.linkLabel1.TabIndex = 340;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "IPADDR";
            this.linkLabel1.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkLabel2.Location = new System.Drawing.Point(399, 3);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(30, 12);
            this.linkLabel2.TabIndex = 341;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "HOST";
            this.linkLabel2.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(328, 465);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(395, 34);
            this.flowLayoutPanel1.TabIndex = 355;
            // 
            // HOST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.mrnset_linkLabel);
            this.Controls.Add(this.hostIpClear_button);
            this.Controls.Add(this.hostIpSearch_textBox);
            this.Controls.Add(this.hostIp_listBox);
            this.Controls.Add(this.search_dataGridView);
            this.Controls.Add(this.hostLoc_listBox);
            this.Controls.Add(this.hostLocSearch_textBox);
            this.Controls.Add(this.opcode_Mnrset_label);
            this.Controls.Add(this.hostLocClear_button);
            this.Controls.Add(this.hostType_listBox);
            this.Controls.Add(this.hostTypeSearch_textBox);
            this.Controls.Add(this.hostTypeClear_button);
            this.Controls.Add(this.hostClear_button);
            this.Controls.Add(this.hostSearch_textBox);
            this.Controls.Add(this.host_listBox);
            this.Name = "HOST";
            this.Size = new System.Drawing.Size(876, 502);
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button hostIpClear_button;
        private System.Windows.Forms.TextBox hostIpSearch_textBox;
        private System.Windows.Forms.ListBox hostIp_listBox;
        private System.Windows.Forms.Button hostLocClear_button;
        private System.Windows.Forms.Button hostTypeClear_button;
        private System.Windows.Forms.Button hostClear_button;
        private System.Windows.Forms.TextBox hostSearch_textBox;
        private System.Windows.Forms.ListBox host_listBox;
        private System.Windows.Forms.TextBox hostTypeSearch_textBox;
        private System.Windows.Forms.ListBox hostType_listBox;
        private System.Windows.Forms.Label opcode_Mnrset_label;
        private System.Windows.Forms.TextBox hostLocSearch_textBox;
        private System.Windows.Forms.ListBox hostLoc_listBox;
        private System.Windows.Forms.DataGridView search_dataGridView;
        private System.Windows.Forms.Label numRecords_label;
        private System.Windows.Forms.LinkLabel mrnset_linkLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
