namespace VRS_Eng_Manage_Tool.Windows.Reports
{
    partial class RTMT_keys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RTMT_keys));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipbbKeys_textBox = new System.Windows.Forms.TextBox();
            this.internalKeys_textBox = new System.Windows.Forms.TextBox();
            this.save_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.carrierKeys_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IPBB keys";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Internal keys";
            // 
            // ipbbKeys_textBox
            // 
            this.ipbbKeys_textBox.Location = new System.Drawing.Point(177, 49);
            this.ipbbKeys_textBox.Multiline = true;
            this.ipbbKeys_textBox.Name = "ipbbKeys_textBox";
            this.ipbbKeys_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ipbbKeys_textBox.Size = new System.Drawing.Size(88, 192);
            this.ipbbKeys_textBox.TabIndex = 2;
            // 
            // internalKeys_textBox
            // 
            this.internalKeys_textBox.Location = new System.Drawing.Point(46, 49);
            this.internalKeys_textBox.Multiline = true;
            this.internalKeys_textBox.Name = "internalKeys_textBox";
            this.internalKeys_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.internalKeys_textBox.Size = new System.Drawing.Size(88, 102);
            this.internalKeys_textBox.TabIndex = 3;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(274, 281);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(88, 30);
            this.save_button.TabIndex = 0;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.accept_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(372, 281);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(88, 30);
            this.cancel_button.TabIndex = 1;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // carrierKeys_textBox
            // 
            this.carrierKeys_textBox.Location = new System.Drawing.Point(310, 49);
            this.carrierKeys_textBox.Multiline = true;
            this.carrierKeys_textBox.Name = "carrierKeys_textBox";
            this.carrierKeys_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.carrierKeys_textBox.Size = new System.Drawing.Size(150, 192);
            this.carrierKeys_textBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(307, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Carrier keys";
            // 
            // RTMT_keys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 348);
            this.Controls.Add(this.carrierKeys_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.internalKeys_textBox);
            this.Controls.Add(this.ipbbKeys_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(525, 387);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(525, 387);
            this.Name = "RTMT_keys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RTMT Keys";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipbbKeys_textBox;
        private System.Windows.Forms.TextBox internalKeys_textBox;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.TextBox carrierKeys_textBox;
        private System.Windows.Forms.Label label3;
    }
}