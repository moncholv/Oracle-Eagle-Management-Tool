namespace VRS_Eng_Manage_Tool.Windows.Audits
{
    partial class MTP_Connections
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MTP_Connections));
            this.label30 = new System.Windows.Forms.Label();
            this.operatorSource_comboBox = new System.Windows.Forms.ComboBox();
            this.operatorSearch_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.fileGenerated_panel = new System.Windows.Forms.Panel();
            this.closeFileGenerated_button = new System.Windows.Forms.Button();
            this.folder_button = new System.Windows.Forms.Button();
            this.generatedFile_linkLabel = new System.Windows.Forms.LinkLabel();
            this.GeneratedFileHeader_label = new System.Windows.Forms.Label();
            this.excel_button = new System.Windows.Forms.Button();
            this.loopsetsData_dataGridView = new System.Windows.Forms.DataGridView();
            this.fileGenerated_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loopsetsData_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(40, 39);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(37, 13);
            this.label30.TabIndex = 313;
            this.label30.Text = "Carrier";
            // 
            // operatorSource_comboBox
            // 
            this.operatorSource_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operatorSource_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operatorSource_comboBox.FormattingEnabled = true;
            this.operatorSource_comboBox.Location = new System.Drawing.Point(79, 35);
            this.operatorSource_comboBox.Name = "operatorSource_comboBox";
            this.operatorSource_comboBox.Size = new System.Drawing.Size(125, 21);
            this.operatorSource_comboBox.TabIndex = 314;
            this.operatorSource_comboBox.SelectedIndexChanged += new System.EventHandler(this.operatorSource_comboBox_SelectedIndexChanged);
            // 
            // operatorSearch_button
            // 
            this.operatorSearch_button.Enabled = false;
            this.operatorSearch_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operatorSearch_button.Location = new System.Drawing.Point(215, 35);
            this.operatorSearch_button.Name = "operatorSearch_button";
            this.operatorSearch_button.Size = new System.Drawing.Size(69, 21);
            this.operatorSearch_button.TabIndex = 318;
            this.operatorSearch_button.Text = "Search";
            this.operatorSearch_button.UseVisualStyleBackColor = true;
            // 
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.Color.Transparent;
            this.close_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_button.Location = new System.Drawing.Point(645, 297);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(71, 25);
            this.close_button.TabIndex = 408;
            this.close_button.Text = "Close";
            this.close_button.UseVisualStyleBackColor = false;
            // 
            // fileGenerated_panel
            // 
            this.fileGenerated_panel.Controls.Add(this.closeFileGenerated_button);
            this.fileGenerated_panel.Controls.Add(this.folder_button);
            this.fileGenerated_panel.Controls.Add(this.generatedFile_linkLabel);
            this.fileGenerated_panel.Controls.Add(this.GeneratedFileHeader_label);
            this.fileGenerated_panel.Location = new System.Drawing.Point(43, 322);
            this.fileGenerated_panel.Name = "fileGenerated_panel";
            this.fileGenerated_panel.Size = new System.Drawing.Size(673, 38);
            this.fileGenerated_panel.TabIndex = 407;
            this.fileGenerated_panel.Visible = false;
            // 
            // closeFileGenerated_button
            // 
            this.closeFileGenerated_button.BackgroundImage = global::VRS_Eng_Manage_Tool.Properties.Resources.close_10;
            this.closeFileGenerated_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeFileGenerated_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeFileGenerated_button.FlatAppearance.BorderSize = 0;
            this.closeFileGenerated_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeFileGenerated_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.closeFileGenerated_button.Location = new System.Drawing.Point(100, 5);
            this.closeFileGenerated_button.Name = "closeFileGenerated_button";
            this.closeFileGenerated_button.Size = new System.Drawing.Size(12, 12);
            this.closeFileGenerated_button.TabIndex = 367;
            this.closeFileGenerated_button.UseVisualStyleBackColor = true;
            // 
            // folder_button
            // 
            this.folder_button.BackgroundImage = global::VRS_Eng_Manage_Tool.Properties.Resources.folder_button_10;
            this.folder_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.folder_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.folder_button.FlatAppearance.BorderSize = 0;
            this.folder_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.folder_button.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.folder_button.Location = new System.Drawing.Point(82, 6);
            this.folder_button.Name = "folder_button";
            this.folder_button.Size = new System.Drawing.Size(12, 10);
            this.folder_button.TabIndex = 366;
            this.folder_button.UseVisualStyleBackColor = true;
            // 
            // generatedFile_linkLabel
            // 
            this.generatedFile_linkLabel.AutoSize = true;
            this.generatedFile_linkLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.generatedFile_linkLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generatedFile_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.generatedFile_linkLabel.Location = new System.Drawing.Point(4, 18);
            this.generatedFile_linkLabel.Name = "generatedFile_linkLabel";
            this.generatedFile_linkLabel.Size = new System.Drawing.Size(54, 14);
            this.generatedFile_linkLabel.TabIndex = 365;
            this.generatedFile_linkLabel.TabStop = true;
            this.generatedFile_linkLabel.Text = "linkLabel1";
            // 
            // GeneratedFileHeader_label
            // 
            this.GeneratedFileHeader_label.AutoSize = true;
            this.GeneratedFileHeader_label.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneratedFileHeader_label.ForeColor = System.Drawing.Color.Black;
            this.GeneratedFileHeader_label.Location = new System.Drawing.Point(3, 3);
            this.GeneratedFileHeader_label.Name = "GeneratedFileHeader_label";
            this.GeneratedFileHeader_label.Size = new System.Drawing.Size(75, 14);
            this.GeneratedFileHeader_label.TabIndex = 364;
            this.GeneratedFileHeader_label.Text = "Generated file";
            // 
            // excel_button
            // 
            this.excel_button.BackColor = System.Drawing.Color.Transparent;
            this.excel_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.excel_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excel_button.Image = global::VRS_Eng_Manage_Tool.Properties.Resources.Excel_button;
            this.excel_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.excel_button.Location = new System.Drawing.Point(608, 30);
            this.excel_button.Name = "excel_button";
            this.excel_button.Size = new System.Drawing.Size(108, 25);
            this.excel_button.TabIndex = 406;
            this.excel_button.Text = "  Generate Excel";
            this.excel_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.excel_button.UseVisualStyleBackColor = false;
            // 
            // loopsetsData_dataGridView
            // 
            this.loopsetsData_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loopsetsData_dataGridView.Location = new System.Drawing.Point(43, 69);
            this.loopsetsData_dataGridView.Name = "loopsetsData_dataGridView";
            this.loopsetsData_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.loopsetsData_dataGridView.Size = new System.Drawing.Size(673, 220);
            this.loopsetsData_dataGridView.TabIndex = 405;
            // 
            // MTP_Connections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 371);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.fileGenerated_panel);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.loopsetsData_dataGridView);
            this.Controls.Add(this.operatorSearch_button);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.operatorSource_comboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(777, 410);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(777, 410);
            this.Name = "MTP_Connections";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MTP Connections";
            this.fileGenerated_panel.ResumeLayout(false);
            this.fileGenerated_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loopsetsData_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox operatorSource_comboBox;
        private System.Windows.Forms.Button operatorSearch_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Panel fileGenerated_panel;
        private System.Windows.Forms.Button closeFileGenerated_button;
        private System.Windows.Forms.Button folder_button;
        private System.Windows.Forms.LinkLabel generatedFile_linkLabel;
        private System.Windows.Forms.Label GeneratedFileHeader_label;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.DataGridView loopsetsData_dataGridView;
    }
}