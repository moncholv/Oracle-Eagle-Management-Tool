namespace VRS_Eng_Manage_Tool.Windows
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.Ok_button = new System.Windows.Forms.Button();
            this.About_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_button
            // 
            this.Ok_button.Location = new System.Drawing.Point(130, 79);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(63, 23);
            this.Ok_button.TabIndex = 5;
            this.Ok_button.Text = "OK";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // About_label
            // 
            this.About_label.AutoSize = true;
            this.About_label.Location = new System.Drawing.Point(71, 27);
            this.About_label.Name = "About_label";
            this.About_label.Size = new System.Drawing.Size(225, 39);
            this.About_label.TabIndex = 4;
            this.About_label.Text = "Vodafone Roaming Services Engineering Tool\r\nVersion 0.0.0.0\r\nRLV";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::VRS_Eng_Manage_Tool.Properties.Resources.VRS_eng_tool;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(25, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 125);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.About_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(339, 164);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(339, 164);
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About VRS Engineering Tool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Ok_button;
        private System.Windows.Forms.Label About_label;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}