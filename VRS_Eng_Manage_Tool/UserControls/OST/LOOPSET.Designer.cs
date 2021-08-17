namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    partial class LOOPSET
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOOPSET));
            this.numRecords_label = new System.Windows.Forms.Label();
            this.loopsetClear_button = new System.Windows.Forms.Button();
            this.loopsetPointCodesClear_button = new System.Windows.Forms.Button();
            this.loopsetPointCodesSearch_textBox = new System.Windows.Forms.TextBox();
            this.loopsetPointCodes_listBox = new System.Windows.Forms.ListBox();
            this.loopsetSearch_textBox = new System.Windows.Forms.TextBox();
            this.loopset_listBox = new System.Windows.Forms.ListBox();
            this.search_dataGridView = new System.Windows.Forms.DataGridView();
            this.loopset_linkLabel = new System.Windows.Forms.LinkLabel();
            this.loopsetPointCodes_linkLabel = new System.Windows.Forms.LinkLabel();
            this.clear_button = new System.Windows.Forms.Button();
            this.excel_button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.loopsetTypeSearch_textBox = new System.Windows.Forms.TextBox();
            this.loopsetType_listBox = new System.Windows.Forms.ListBox();
            this.loopsetTypeClear_button = new System.Windows.Forms.Button();
            this.loopsetType_linkLabel = new System.Windows.Forms.LinkLabel();
            this.loopsetMode_linkLabel = new System.Windows.Forms.LinkLabel();
            this.loopsetMode_listBox = new System.Windows.Forms.ListBox();
            this.loopsetModeSearch_textBox = new System.Windows.Forms.TextBox();
            this.loopsetModeClear_button = new System.Windows.Forms.Button();
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
            // loopsetClear_button
            // 
            this.loopsetClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loopsetClear_button.BackgroundImage")));
            this.loopsetClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loopsetClear_button.Enabled = false;
            this.loopsetClear_button.Location = new System.Drawing.Point(65, 15);
            this.loopsetClear_button.Name = "loopsetClear_button";
            this.loopsetClear_button.Size = new System.Drawing.Size(22, 22);
            this.loopsetClear_button.TabIndex = 290;
            this.loopsetClear_button.UseVisualStyleBackColor = true;
            this.loopsetClear_button.Click += new System.EventHandler(this.loopsetClear_button_Click);
            // 
            // loopsetPointCodesClear_button
            // 
            this.loopsetPointCodesClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loopsetPointCodesClear_button.BackgroundImage")));
            this.loopsetPointCodesClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loopsetPointCodesClear_button.Enabled = false;
            this.loopsetPointCodesClear_button.Location = new System.Drawing.Point(269, 15);
            this.loopsetPointCodesClear_button.Name = "loopsetPointCodesClear_button";
            this.loopsetPointCodesClear_button.Size = new System.Drawing.Size(22, 22);
            this.loopsetPointCodesClear_button.TabIndex = 287;
            this.loopsetPointCodesClear_button.UseVisualStyleBackColor = true;
            this.loopsetPointCodesClear_button.Click += new System.EventHandler(this.loopsetPcnClear_button_Click);
            // 
            // loopsetPointCodesSearch_textBox
            // 
            this.loopsetPointCodesSearch_textBox.Location = new System.Drawing.Point(209, 16);
            this.loopsetPointCodesSearch_textBox.Name = "loopsetPointCodesSearch_textBox";
            this.loopsetPointCodesSearch_textBox.Size = new System.Drawing.Size(54, 20);
            this.loopsetPointCodesSearch_textBox.TabIndex = 277;
            this.loopsetPointCodesSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // loopsetPointCodes_listBox
            // 
            this.loopsetPointCodes_listBox.FormattingEnabled = true;
            this.loopsetPointCodes_listBox.Location = new System.Drawing.Point(209, 41);
            this.loopsetPointCodes_listBox.Name = "loopsetPointCodes_listBox";
            this.loopsetPointCodes_listBox.Size = new System.Drawing.Size(82, 69);
            this.loopsetPointCodes_listBox.TabIndex = 276;
            this.loopsetPointCodes_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // loopsetSearch_textBox
            // 
            this.loopsetSearch_textBox.Location = new System.Drawing.Point(3, 16);
            this.loopsetSearch_textBox.Name = "loopsetSearch_textBox";
            this.loopsetSearch_textBox.Size = new System.Drawing.Size(56, 20);
            this.loopsetSearch_textBox.TabIndex = 274;
            this.loopsetSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // loopset_listBox
            // 
            this.loopset_listBox.FormattingEnabled = true;
            this.loopset_listBox.Location = new System.Drawing.Point(3, 41);
            this.loopset_listBox.Name = "loopset_listBox";
            this.loopset_listBox.Size = new System.Drawing.Size(84, 69);
            this.loopset_listBox.TabIndex = 273;
            this.loopset_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
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
            // loopset_linkLabel
            // 
            this.loopset_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.loopset_linkLabel.AutoSize = true;
            this.loopset_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.loopset_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.loopset_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.loopset_linkLabel.Location = new System.Drawing.Point(1, 2);
            this.loopset_linkLabel.Name = "loopset_linkLabel";
            this.loopset_linkLabel.Size = new System.Drawing.Size(47, 12);
            this.loopset_linkLabel.TabIndex = 338;
            this.loopset_linkLabel.TabStop = true;
            this.loopset_linkLabel.Text = "LOOPSET";
            this.loopset_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.loopset_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.loopset_linkLabel_LinkClicked);
            // 
            // loopsetPointCodes_linkLabel
            // 
            this.loopsetPointCodes_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.loopsetPointCodes_linkLabel.AutoSize = true;
            this.loopsetPointCodes_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.loopsetPointCodes_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.loopsetPointCodes_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.loopsetPointCodes_linkLabel.Location = new System.Drawing.Point(207, 2);
            this.loopsetPointCodes_linkLabel.Name = "loopsetPointCodes_linkLabel";
            this.loopsetPointCodes_linkLabel.Size = new System.Drawing.Size(25, 12);
            this.loopsetPointCodes_linkLabel.TabIndex = 345;
            this.loopsetPointCodes_linkLabel.TabStop = true;
            this.loopsetPointCodes_linkLabel.Text = "PCN";
            this.loopsetPointCodes_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.loopsetPointCodes_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.loopsetPointCodes_linkLabel_LinkClicked);
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
            // loopsetTypeSearch_textBox
            // 
            this.loopsetTypeSearch_textBox.Location = new System.Drawing.Point(311, 16);
            this.loopsetTypeSearch_textBox.Name = "loopsetTypeSearch_textBox";
            this.loopsetTypeSearch_textBox.Size = new System.Drawing.Size(54, 20);
            this.loopsetTypeSearch_textBox.TabIndex = 280;
            this.loopsetTypeSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // loopsetType_listBox
            // 
            this.loopsetType_listBox.FormattingEnabled = true;
            this.loopsetType_listBox.Location = new System.Drawing.Point(311, 41);
            this.loopsetType_listBox.Name = "loopsetType_listBox";
            this.loopsetType_listBox.Size = new System.Drawing.Size(82, 69);
            this.loopsetType_listBox.TabIndex = 279;
            this.loopsetType_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // loopsetTypeClear_button
            // 
            this.loopsetTypeClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loopsetTypeClear_button.BackgroundImage")));
            this.loopsetTypeClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loopsetTypeClear_button.Enabled = false;
            this.loopsetTypeClear_button.Location = new System.Drawing.Point(371, 16);
            this.loopsetTypeClear_button.Name = "loopsetTypeClear_button";
            this.loopsetTypeClear_button.Size = new System.Drawing.Size(22, 22);
            this.loopsetTypeClear_button.TabIndex = 288;
            this.loopsetTypeClear_button.UseVisualStyleBackColor = true;
            this.loopsetTypeClear_button.Click += new System.EventHandler(this.loopsetTypeClear_button_Click);
            // 
            // loopsetType_linkLabel
            // 
            this.loopsetType_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.loopsetType_linkLabel.AutoSize = true;
            this.loopsetType_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.loopsetType_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.loopsetType_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.loopsetType_linkLabel.Location = new System.Drawing.Point(309, 2);
            this.loopsetType_linkLabel.Name = "loopsetType_linkLabel";
            this.loopsetType_linkLabel.Size = new System.Drawing.Size(25, 12);
            this.loopsetType_linkLabel.TabIndex = 346;
            this.loopsetType_linkLabel.TabStop = true;
            this.loopsetType_linkLabel.Text = "Type";
            this.loopsetType_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.loopsetType_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.loopsetType_linkLabel_LinkClicked);
            // 
            // loopsetMode_linkLabel
            // 
            this.loopsetMode_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.loopsetMode_linkLabel.AutoSize = true;
            this.loopsetMode_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.loopsetMode_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.loopsetMode_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.loopsetMode_linkLabel.Location = new System.Drawing.Point(104, 2);
            this.loopsetMode_linkLabel.Name = "loopsetMode_linkLabel";
            this.loopsetMode_linkLabel.Size = new System.Drawing.Size(29, 12);
            this.loopsetMode_linkLabel.TabIndex = 359;
            this.loopsetMode_linkLabel.TabStop = true;
            this.loopsetMode_linkLabel.Text = "Mode";
            this.loopsetMode_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.loopsetMode_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.loopsetMode_linkLabel_LinkClicked);
            // 
            // loopsetMode_listBox
            // 
            this.loopsetMode_listBox.FormattingEnabled = true;
            this.loopsetMode_listBox.Location = new System.Drawing.Point(106, 41);
            this.loopsetMode_listBox.Name = "loopsetMode_listBox";
            this.loopsetMode_listBox.Size = new System.Drawing.Size(82, 69);
            this.loopsetMode_listBox.TabIndex = 356;
            this.loopsetMode_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // loopsetModeSearch_textBox
            // 
            this.loopsetModeSearch_textBox.Location = new System.Drawing.Point(106, 16);
            this.loopsetModeSearch_textBox.Name = "loopsetModeSearch_textBox";
            this.loopsetModeSearch_textBox.Size = new System.Drawing.Size(54, 20);
            this.loopsetModeSearch_textBox.TabIndex = 357;
            this.loopsetModeSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // loopsetModeClear_button
            // 
            this.loopsetModeClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loopsetModeClear_button.BackgroundImage")));
            this.loopsetModeClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loopsetModeClear_button.Enabled = false;
            this.loopsetModeClear_button.Location = new System.Drawing.Point(166, 15);
            this.loopsetModeClear_button.Name = "loopsetModeClear_button";
            this.loopsetModeClear_button.Size = new System.Drawing.Size(22, 22);
            this.loopsetModeClear_button.TabIndex = 358;
            this.loopsetModeClear_button.UseVisualStyleBackColor = true;
            this.loopsetModeClear_button.Click += new System.EventHandler(this.loopsetModeClear_button_Click);
            // 
            // LOOPSET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loopsetMode_linkLabel);
            this.Controls.Add(this.loopsetMode_listBox);
            this.Controls.Add(this.loopsetModeSearch_textBox);
            this.Controls.Add(this.loopsetModeClear_button);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.loopsetType_linkLabel);
            this.Controls.Add(this.loopsetPointCodes_linkLabel);
            this.Controls.Add(this.loopset_linkLabel);
            this.Controls.Add(this.search_dataGridView);
            this.Controls.Add(this.loopset_listBox);
            this.Controls.Add(this.loopsetSearch_textBox);
            this.Controls.Add(this.loopsetClear_button);
            this.Controls.Add(this.loopsetPointCodes_listBox);
            this.Controls.Add(this.loopsetTypeClear_button);
            this.Controls.Add(this.loopsetPointCodesSearch_textBox);
            this.Controls.Add(this.loopsetPointCodesClear_button);
            this.Controls.Add(this.loopsetType_listBox);
            this.Controls.Add(this.loopsetTypeSearch_textBox);
            this.Name = "LOOPSET";
            this.Size = new System.Drawing.Size(876, 502);
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loopsetClear_button;
        private System.Windows.Forms.Button loopsetPointCodesClear_button;
        private System.Windows.Forms.TextBox loopsetPointCodesSearch_textBox;
        private System.Windows.Forms.ListBox loopsetPointCodes_listBox;
        private System.Windows.Forms.TextBox loopsetSearch_textBox;
        private System.Windows.Forms.ListBox loopset_listBox;
        private System.Windows.Forms.DataGridView search_dataGridView;
        private System.Windows.Forms.Label numRecords_label;
        private System.Windows.Forms.LinkLabel loopset_linkLabel;
        private System.Windows.Forms.LinkLabel loopsetPointCodes_linkLabel;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox loopsetTypeSearch_textBox;
        private System.Windows.Forms.ListBox loopsetType_listBox;
        private System.Windows.Forms.Button loopsetTypeClear_button;
        private System.Windows.Forms.LinkLabel loopsetType_linkLabel;
        private System.Windows.Forms.LinkLabel loopsetMode_linkLabel;
        private System.Windows.Forms.ListBox loopsetMode_listBox;
        private System.Windows.Forms.TextBox loopsetModeSearch_textBox;
        private System.Windows.Forms.Button loopsetModeClear_button;
    }
}
