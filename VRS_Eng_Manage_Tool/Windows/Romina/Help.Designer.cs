namespace VRS_Eng_Manage_Tool.Windows.Romina
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.HelpInfo_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HelpInfo_label
            // 
            this.HelpInfo_label.AutoSize = true;
            this.HelpInfo_label.Location = new System.Drawing.Point(31, 21);
            this.HelpInfo_label.Name = "HelpInfo_label";
            this.HelpInfo_label.Size = new System.Drawing.Size(35, 13);
            this.HelpInfo_label.TabIndex = 0;
            this.HelpInfo_label.Text = "label1";
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 626);
            this.Controls.Add(this.HelpInfo_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(557, 665);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(557, 665);
            this.Name = "Help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Search Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HelpInfo_label;
    }
}