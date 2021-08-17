namespace VRS_Eng_Manage_Tool.Windows.Audits
{
    partial class Loopsets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loopsets));
            this.loopsetsData_dataGridView = new System.Windows.Forms.DataGridView();
            this.excel_button = new System.Windows.Forms.Button();
            this.fileGenerated_panel = new System.Windows.Forms.Panel();
            this.closeFileGenerated_button = new System.Windows.Forms.Button();
            this.folder_button = new System.Windows.Forms.Button();
            this.generatedFile_linkLabel = new System.Windows.Forms.LinkLabel();
            this.GeneratedFileHeader_label = new System.Windows.Forms.Label();
            this.close_button = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loopsetsData_dataGridView)).BeginInit();
            this.fileGenerated_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loopsetsData_dataGridView
            // 
            this.loopsetsData_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loopsetsData_dataGridView.Location = new System.Drawing.Point(28, 56);
            this.loopsetsData_dataGridView.Name = "loopsetsData_dataGridView";
            this.loopsetsData_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.loopsetsData_dataGridView.Size = new System.Drawing.Size(673, 220);
            this.loopsetsData_dataGridView.TabIndex = 266;
            // 
            // excel_button
            // 
            this.excel_button.BackColor = System.Drawing.Color.Transparent;
            this.excel_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.excel_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excel_button.Image = global::VRS_Eng_Manage_Tool.Properties.Resources.Excel_button;
            this.excel_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.excel_button.Location = new System.Drawing.Point(593, 25);
            this.excel_button.Name = "excel_button";
            this.excel_button.Size = new System.Drawing.Size(108, 25);
            this.excel_button.TabIndex = 354;
            this.excel_button.Text = "  Generate Excel";
            this.excel_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.excel_button.UseVisualStyleBackColor = false;
            this.excel_button.Click += new System.EventHandler(this.excel_button_Click);
            // 
            // fileGenerated_panel
            // 
            this.fileGenerated_panel.Controls.Add(this.closeFileGenerated_button);
            this.fileGenerated_panel.Controls.Add(this.folder_button);
            this.fileGenerated_panel.Controls.Add(this.generatedFile_linkLabel);
            this.fileGenerated_panel.Controls.Add(this.GeneratedFileHeader_label);
            this.fileGenerated_panel.Location = new System.Drawing.Point(28, 316);
            this.fileGenerated_panel.Name = "fileGenerated_panel";
            this.fileGenerated_panel.Size = new System.Drawing.Size(673, 38);
            this.fileGenerated_panel.TabIndex = 403;
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
            this.closeFileGenerated_button.Click += new System.EventHandler(this.closeFileGenerated_button_Click);
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
            this.folder_button.Click += new System.EventHandler(this.folder_button_Click);
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
            this.generatedFile_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.generatedFile_linkLabel_LinkClicked);
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
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.Color.Transparent;
            this.close_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_button.Location = new System.Drawing.Point(630, 291);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(71, 25);
            this.close_button.TabIndex = 404;
            this.close_button.Text = "Close";
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(25, 37);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(146, 13);
            this.label39.TabIndex = 405;
            this.label39.Text = "LOOPSETS AUDIT RESULT";
            // 
            // Loopsets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 365);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.fileGenerated_panel);
            this.Controls.Add(this.excel_button);
            this.Controls.Add(this.loopsetsData_dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(752, 404);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(752, 404);
            this.Name = "Loopsets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loopsets Audit";
            ((System.ComponentModel.ISupportInitialize)(this.loopsetsData_dataGridView)).EndInit();
            this.fileGenerated_panel.ResumeLayout(false);
            this.fileGenerated_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView loopsetsData_dataGridView;
        private System.Windows.Forms.Button excel_button;
        private System.Windows.Forms.Panel fileGenerated_panel;
        private System.Windows.Forms.Button closeFileGenerated_button;
        private System.Windows.Forms.Button folder_button;
        private System.Windows.Forms.LinkLabel generatedFile_linkLabel;
        private System.Windows.Forms.Label GeneratedFileHeader_label;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Label label39;
    }
}