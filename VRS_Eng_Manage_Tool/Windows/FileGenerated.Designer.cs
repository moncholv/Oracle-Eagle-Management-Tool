namespace VRS_Eng_Manage_Tool.Windows
{
    partial class FileGenerated
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileGenerated));
            this.GeneratedFile_linkLabel = new System.Windows.Forms.LinkLabel();
            this.GeneratedFileHeader_label = new System.Windows.Forms.Label();
            this.close_button = new System.Windows.Forms.Button();
            this.folder_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GeneratedFile_linkLabel
            // 
            this.GeneratedFile_linkLabel.AutoSize = true;
            this.GeneratedFile_linkLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneratedFile_linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.GeneratedFile_linkLabel.Location = new System.Drawing.Point(29, 46);
            this.GeneratedFile_linkLabel.Name = "GeneratedFile_linkLabel";
            this.GeneratedFile_linkLabel.Size = new System.Drawing.Size(64, 15);
            this.GeneratedFile_linkLabel.TabIndex = 362;
            this.GeneratedFile_linkLabel.TabStop = true;
            this.GeneratedFile_linkLabel.Text = "linkLabel1";
            this.GeneratedFile_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GeneratedFile_linkLabel_LinkClicked);
            // 
            // GeneratedFileHeader_label
            // 
            this.GeneratedFileHeader_label.AutoSize = true;
            this.GeneratedFileHeader_label.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneratedFileHeader_label.ForeColor = System.Drawing.Color.Black;
            this.GeneratedFileHeader_label.Location = new System.Drawing.Point(27, 25);
            this.GeneratedFileHeader_label.Name = "GeneratedFileHeader_label";
            this.GeneratedFileHeader_label.Size = new System.Drawing.Size(114, 15);
            this.GeneratedFileHeader_label.TabIndex = 363;
            this.GeneratedFileHeader_label.Text = "Generated file path:";
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(919, 94);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(90, 33);
            this.close_button.TabIndex = 364;
            this.close_button.Text = "Close";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // folder_button
            // 
            this.folder_button.FlatAppearance.BorderSize = 0;
            this.folder_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.folder_button.Image = global::VRS_Eng_Manage_Tool.Properties.Resources.folder_button;
            this.folder_button.Location = new System.Drawing.Point(144, 20);
            this.folder_button.Name = "folder_button";
            this.folder_button.Size = new System.Drawing.Size(30, 25);
            this.folder_button.TabIndex = 365;
            this.folder_button.UseVisualStyleBackColor = true;
            this.folder_button.Click += new System.EventHandler(this.folder_button_Click);
            // 
            // FileGenerated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 150);
            this.Controls.Add(this.folder_button);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.GeneratedFile_linkLabel);
            this.Controls.Add(this.GeneratedFileHeader_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1053, 189);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1053, 189);
            this.Name = "FileGenerated";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Generated";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel GeneratedFile_linkLabel;
        private System.Windows.Forms.Label GeneratedFileHeader_label;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button folder_button;
    }
}