namespace VRS_Eng_Manage_Tool.UserControls.OST
{
    partial class TTMAP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TTMAP));
            this.ttmapIo_linkLabel = new System.Windows.Forms.LinkLabel();
            this.ttmapIo_listBox = new System.Windows.Forms.ListBox();
            this.ttmapIoSearch_textBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.numRecords_label = new System.Windows.Forms.Label();
            this.ttmapMtt_linkLabel = new System.Windows.Forms.LinkLabel();
            this.ttmapEtt_linkLabel = new System.Windows.Forms.LinkLabel();
            this.ttmapLsn_linkLabel = new System.Windows.Forms.LinkLabel();
            this.search_dataGridView = new System.Windows.Forms.DataGridView();
            this.ttmapLsn_listBox = new System.Windows.Forms.ListBox();
            this.ttmapLsnSearch_textBox = new System.Windows.Forms.TextBox();
            this.ttmapEtt_listBox = new System.Windows.Forms.ListBox();
            this.ttmapEttSearch_textBox = new System.Windows.Forms.TextBox();
            this.ttmapMtt_listBox = new System.Windows.Forms.ListBox();
            this.ttmapMttSearch_textBox = new System.Windows.Forms.TextBox();
            this.ttmapIoClear_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.excel_button = new System.Windows.Forms.Button();
            this.ttmapLsnClear_button = new System.Windows.Forms.Button();
            this.ttmapMttClear_button = new System.Windows.Forms.Button();
            this.ttmapEttClear_button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ttmapIo_linkLabel
            // 
            this.ttmapIo_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.ttmapIo_linkLabel.AutoSize = true;
            this.ttmapIo_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.ttmapIo_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ttmapIo_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.ttmapIo_linkLabel.Location = new System.Drawing.Point(121, 2);
            this.ttmapIo_linkLabel.Name = "ttmapIo_linkLabel";
            this.ttmapIo_linkLabel.Size = new System.Drawing.Size(15, 12);
            this.ttmapIo_linkLabel.TabIndex = 379;
            this.ttmapIo_linkLabel.TabStop = true;
            this.ttmapIo_linkLabel.Text = "IO";
            this.ttmapIo_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.ttmapIo_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ttmapIo_linkLabel_LinkClicked);
            // 
            // ttmapIo_listBox
            // 
            this.ttmapIo_listBox.FormattingEnabled = true;
            this.ttmapIo_listBox.Location = new System.Drawing.Point(123, 41);
            this.ttmapIo_listBox.Name = "ttmapIo_listBox";
            this.ttmapIo_listBox.Size = new System.Drawing.Size(62, 69);
            this.ttmapIo_listBox.TabIndex = 376;
            this.ttmapIo_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // ttmapIoSearch_textBox
            // 
            this.ttmapIoSearch_textBox.Location = new System.Drawing.Point(123, 16);
            this.ttmapIoSearch_textBox.Name = "ttmapIoSearch_textBox";
            this.ttmapIoSearch_textBox.Size = new System.Drawing.Size(34, 20);
            this.ttmapIoSearch_textBox.TabIndex = 377;
            this.ttmapIoSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.numRecords_label);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(313, 465);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(321, 36);
            this.flowLayoutPanel1.TabIndex = 375;
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
            // ttmapMtt_linkLabel
            // 
            this.ttmapMtt_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.ttmapMtt_linkLabel.AutoSize = true;
            this.ttmapMtt_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.ttmapMtt_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ttmapMtt_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.ttmapMtt_linkLabel.Location = new System.Drawing.Point(303, 2);
            this.ttmapMtt_linkLabel.Name = "ttmapMtt_linkLabel";
            this.ttmapMtt_linkLabel.Size = new System.Drawing.Size(24, 12);
            this.ttmapMtt_linkLabel.TabIndex = 372;
            this.ttmapMtt_linkLabel.TabStop = true;
            this.ttmapMtt_linkLabel.Text = "MTT";
            this.ttmapMtt_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.ttmapMtt_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ttmapMtt_linkLabel_LinkClicked);
            // 
            // ttmapEtt_linkLabel
            // 
            this.ttmapEtt_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.ttmapEtt_linkLabel.AutoSize = true;
            this.ttmapEtt_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.ttmapEtt_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ttmapEtt_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.ttmapEtt_linkLabel.Location = new System.Drawing.Point(201, 2);
            this.ttmapEtt_linkLabel.Name = "ttmapEtt_linkLabel";
            this.ttmapEtt_linkLabel.Size = new System.Drawing.Size(21, 12);
            this.ttmapEtt_linkLabel.TabIndex = 371;
            this.ttmapEtt_linkLabel.TabStop = true;
            this.ttmapEtt_linkLabel.Text = "ETT";
            this.ttmapEtt_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.ttmapEtt_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ttmapEtt_linkLabel_LinkClicked);
            // 
            // ttmapLsn_linkLabel
            // 
            this.ttmapLsn_linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            this.ttmapLsn_linkLabel.AutoSize = true;
            this.ttmapLsn_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.ttmapLsn_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.ttmapLsn_linkLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.ttmapLsn_linkLabel.Location = new System.Drawing.Point(1, 2);
            this.ttmapLsn_linkLabel.Name = "ttmapLsn_linkLabel";
            this.ttmapLsn_linkLabel.Size = new System.Drawing.Size(23, 12);
            this.ttmapLsn_linkLabel.TabIndex = 370;
            this.ttmapLsn_linkLabel.TabStop = true;
            this.ttmapLsn_linkLabel.Text = "LSN";
            this.ttmapLsn_linkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.ttmapLsn_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ttmapLsn_linkLabel_LinkClicked);
            // 
            // search_dataGridView
            // 
            this.search_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.search_dataGridView.Location = new System.Drawing.Point(2, 120);
            this.search_dataGridView.Name = "search_dataGridView";
            this.search_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.search_dataGridView.Size = new System.Drawing.Size(634, 343);
            this.search_dataGridView.TabIndex = 360;
            this.search_dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.search_dataGridView_DataBindingComplete);
            // 
            // ttmapLsn_listBox
            // 
            this.ttmapLsn_listBox.FormattingEnabled = true;
            this.ttmapLsn_listBox.Location = new System.Drawing.Point(3, 41);
            this.ttmapLsn_listBox.Name = "ttmapLsn_listBox";
            this.ttmapLsn_listBox.Size = new System.Drawing.Size(101, 69);
            this.ttmapLsn_listBox.TabIndex = 361;
            this.ttmapLsn_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // ttmapLsnSearch_textBox
            // 
            this.ttmapLsnSearch_textBox.Location = new System.Drawing.Point(3, 16);
            this.ttmapLsnSearch_textBox.Name = "ttmapLsnSearch_textBox";
            this.ttmapLsnSearch_textBox.Size = new System.Drawing.Size(73, 20);
            this.ttmapLsnSearch_textBox.TabIndex = 362;
            this.ttmapLsnSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // ttmapEtt_listBox
            // 
            this.ttmapEtt_listBox.FormattingEnabled = true;
            this.ttmapEtt_listBox.Location = new System.Drawing.Point(203, 41);
            this.ttmapEtt_listBox.Name = "ttmapEtt_listBox";
            this.ttmapEtt_listBox.Size = new System.Drawing.Size(82, 69);
            this.ttmapEtt_listBox.TabIndex = 363;
            this.ttmapEtt_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // ttmapEttSearch_textBox
            // 
            this.ttmapEttSearch_textBox.Location = new System.Drawing.Point(203, 16);
            this.ttmapEttSearch_textBox.Name = "ttmapEttSearch_textBox";
            this.ttmapEttSearch_textBox.Size = new System.Drawing.Size(54, 20);
            this.ttmapEttSearch_textBox.TabIndex = 364;
            this.ttmapEttSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // ttmapMtt_listBox
            // 
            this.ttmapMtt_listBox.FormattingEnabled = true;
            this.ttmapMtt_listBox.Location = new System.Drawing.Point(305, 41);
            this.ttmapMtt_listBox.Name = "ttmapMtt_listBox";
            this.ttmapMtt_listBox.Size = new System.Drawing.Size(82, 69);
            this.ttmapMtt_listBox.TabIndex = 365;
            this.ttmapMtt_listBox.SelectedIndexChanged += new System.EventHandler(this.Filter_listBox_SelectedIndexChanged);
            // 
            // ttmapMttSearch_textBox
            // 
            this.ttmapMttSearch_textBox.Location = new System.Drawing.Point(305, 16);
            this.ttmapMttSearch_textBox.Name = "ttmapMttSearch_textBox";
            this.ttmapMttSearch_textBox.Size = new System.Drawing.Size(54, 20);
            this.ttmapMttSearch_textBox.TabIndex = 366;
            this.ttmapMttSearch_textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_textBox_KeyUp);
            // 
            // ttmapIoClear_button
            // 
            this.ttmapIoClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ttmapIoClear_button.BackgroundImage")));
            this.ttmapIoClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ttmapIoClear_button.Enabled = false;
            this.ttmapIoClear_button.Location = new System.Drawing.Point(163, 15);
            this.ttmapIoClear_button.Name = "ttmapIoClear_button";
            this.ttmapIoClear_button.Size = new System.Drawing.Size(22, 22);
            this.ttmapIoClear_button.TabIndex = 378;
            this.ttmapIoClear_button.UseVisualStyleBackColor = true;
            this.ttmapIoClear_button.Click += new System.EventHandler(this.ttmapIoClear_button_Click);
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
            this.clear_button.TabIndex = 374;
            this.clear_button.Text = "  Clear Section Filter";
            this.clear_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clear_button.UseVisualStyleBackColor = false;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click_1);
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
            this.excel_button.TabIndex = 373;
            this.excel_button.Text = "  Generate Section Excel";
            this.excel_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.excel_button.UseVisualStyleBackColor = false;
            this.excel_button.Click += new System.EventHandler(this.excel_button_Click);
            // 
            // ttmapLsnClear_button
            // 
            this.ttmapLsnClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ttmapLsnClear_button.BackgroundImage")));
            this.ttmapLsnClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ttmapLsnClear_button.Enabled = false;
            this.ttmapLsnClear_button.Location = new System.Drawing.Point(82, 15);
            this.ttmapLsnClear_button.Name = "ttmapLsnClear_button";
            this.ttmapLsnClear_button.Size = new System.Drawing.Size(22, 22);
            this.ttmapLsnClear_button.TabIndex = 369;
            this.ttmapLsnClear_button.UseVisualStyleBackColor = true;
            this.ttmapLsnClear_button.Click += new System.EventHandler(this.ttmapLsnClear_button_Click);
            // 
            // ttmapMttClear_button
            // 
            this.ttmapMttClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ttmapMttClear_button.BackgroundImage")));
            this.ttmapMttClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ttmapMttClear_button.Enabled = false;
            this.ttmapMttClear_button.Location = new System.Drawing.Point(365, 16);
            this.ttmapMttClear_button.Name = "ttmapMttClear_button";
            this.ttmapMttClear_button.Size = new System.Drawing.Size(22, 22);
            this.ttmapMttClear_button.TabIndex = 368;
            this.ttmapMttClear_button.UseVisualStyleBackColor = true;
            this.ttmapMttClear_button.Click += new System.EventHandler(this.ttmapMttClear_button_Click);
            // 
            // ttmapEttClear_button
            // 
            this.ttmapEttClear_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ttmapEttClear_button.BackgroundImage")));
            this.ttmapEttClear_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ttmapEttClear_button.Enabled = false;
            this.ttmapEttClear_button.Location = new System.Drawing.Point(263, 15);
            this.ttmapEttClear_button.Name = "ttmapEttClear_button";
            this.ttmapEttClear_button.Size = new System.Drawing.Size(22, 22);
            this.ttmapEttClear_button.TabIndex = 367;
            this.ttmapEttClear_button.UseVisualStyleBackColor = true;
            this.ttmapEttClear_button.Click += new System.EventHandler(this.ttmapEttClear_button_Click);
            // 
            // TTMAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ttmapIo_linkLabel);
            this.Controls.Add(this.ttmapIo_listBox);
            this.Controls.Add(this.ttmapIoSearch_textBox);
            this.Controls.Add(this.ttmapIoClear_button);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.ttmapMtt_linkLabel);
            this.Controls.Add(this.ttmapEtt_linkLabel);
            this.Controls.Add(this.ttmapLsn_linkLabel);
            this.Controls.Add(this.search_dataGridView);
            this.Controls.Add(this.ttmapLsn_listBox);
            this.Controls.Add(this.ttmapLsnSearch_textBox);
            this.Controls.Add(this.ttmapLsnClear_button);
            this.Controls.Add(this.ttmapEtt_listBox);
            this.Controls.Add(this.ttmapMttClear_button);
            this.Controls.Add(this.ttmapEttSearch_textBox);
            this.Controls.Add(this.ttmapEttClear_button);
            this.Controls.Add(this.ttmapMtt_listBox);
            this.Controls.Add(this.ttmapMttSearch_textBox);
            this.Name = "TTMAP";
            this.Size = new System.Drawing.Size(876, 502);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.search_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel ttmapIo_linkLabel;
        private System.Windows.Forms.ListBox ttmapIo_listBox;
        private System.Windows.Forms.TextBox ttmapIoSearch_textBox;
        private System.Windows.Forms.Button ttmapIoClear_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label numRecords_label;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.LinkLabel ttmapMtt_linkLabel;
        private System.Windows.Forms.LinkLabel ttmapEtt_linkLabel;
        private System.Windows.Forms.LinkLabel ttmapLsn_linkLabel;
        private System.Windows.Forms.DataGridView search_dataGridView;
        private System.Windows.Forms.ListBox ttmapLsn_listBox;
        private System.Windows.Forms.TextBox ttmapLsnSearch_textBox;
        private System.Windows.Forms.Button ttmapLsnClear_button;
        private System.Windows.Forms.ListBox ttmapEtt_listBox;
        private System.Windows.Forms.Button ttmapMttClear_button;
        private System.Windows.Forms.TextBox ttmapEttSearch_textBox;
        private System.Windows.Forms.Button ttmapEttClear_button;
        private System.Windows.Forms.ListBox ttmapMtt_listBox;
        private System.Windows.Forms.TextBox ttmapMttSearch_textBox;
    }
}
