namespace VRS_Eng_Manage_Tool.Windows.SFTP
{
    partial class SFTP_values
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFTP_values));
            this.RemoteServer_Label = new System.Windows.Forms.Label();
            this.RemoteServer_textBox = new System.Windows.Forms.TextBox();
            this.RemotePath_textBox = new System.Windows.Forms.TextBox();
            this.RemotePath_label = new System.Windows.Forms.Label();
            this.LocalPath_label = new System.Windows.Forms.Label();
            this.Accept_button = new System.Windows.Forms.Button();
            this.Close_button = new System.Windows.Forms.Button();
            this.LocalPathValue_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RemoteServer_Label
            // 
            this.RemoteServer_Label.AutoSize = true;
            this.RemoteServer_Label.Location = new System.Drawing.Point(34, 33);
            this.RemoteServer_Label.Name = "RemoteServer_Label";
            this.RemoteServer_Label.Size = new System.Drawing.Size(78, 13);
            this.RemoteServer_Label.TabIndex = 0;
            this.RemoteServer_Label.Text = "Remote Server";
            // 
            // RemoteServer_textBox
            // 
            this.RemoteServer_textBox.Location = new System.Drawing.Point(118, 30);
            this.RemoteServer_textBox.Name = "RemoteServer_textBox";
            this.RemoteServer_textBox.Size = new System.Drawing.Size(129, 20);
            this.RemoteServer_textBox.TabIndex = 1;
            // 
            // RemotePath_textBox
            // 
            this.RemotePath_textBox.Location = new System.Drawing.Point(118, 67);
            this.RemotePath_textBox.Multiline = true;
            this.RemotePath_textBox.Name = "RemotePath_textBox";
            this.RemotePath_textBox.Size = new System.Drawing.Size(550, 36);
            this.RemotePath_textBox.TabIndex = 3;
            // 
            // RemotePath_label
            // 
            this.RemotePath_label.AutoSize = true;
            this.RemotePath_label.Location = new System.Drawing.Point(34, 70);
            this.RemotePath_label.Name = "RemotePath_label";
            this.RemotePath_label.Size = new System.Drawing.Size(69, 13);
            this.RemotePath_label.TabIndex = 2;
            this.RemotePath_label.Text = "Remote Path";
            // 
            // LocalPath_label
            // 
            this.LocalPath_label.AutoSize = true;
            this.LocalPath_label.Location = new System.Drawing.Point(34, 123);
            this.LocalPath_label.Name = "LocalPath_label";
            this.LocalPath_label.Size = new System.Drawing.Size(58, 13);
            this.LocalPath_label.TabIndex = 4;
            this.LocalPath_label.Text = "Local Path";
            // 
            // Accept_button
            // 
            this.Accept_button.Location = new System.Drawing.Point(268, 181);
            this.Accept_button.Name = "Accept_button";
            this.Accept_button.Size = new System.Drawing.Size(75, 23);
            this.Accept_button.TabIndex = 10;
            this.Accept_button.Text = "Accept";
            this.Accept_button.UseVisualStyleBackColor = true;
            this.Accept_button.Click += new System.EventHandler(this.Accept_button_Click);
            // 
            // Close_button
            // 
            this.Close_button.Location = new System.Drawing.Point(363, 181);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(75, 23);
            this.Close_button.TabIndex = 11;
            this.Close_button.Text = "Close";
            this.Close_button.UseVisualStyleBackColor = true;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // LocalPathValue_label
            // 
            this.LocalPathValue_label.BackColor = System.Drawing.SystemColors.Window;
            this.LocalPathValue_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LocalPathValue_label.Location = new System.Drawing.Point(118, 123);
            this.LocalPathValue_label.Name = "LocalPathValue_label";
            this.LocalPathValue_label.Size = new System.Drawing.Size(550, 34);
            this.LocalPathValue_label.TabIndex = 12;
            this.LocalPathValue_label.Click += new System.EventHandler(this.LocalPathValue_label_Click);
            // 
            // SFTP_values
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 235);
            this.Controls.Add(this.Close_button);
            this.Controls.Add(this.Accept_button);
            this.Controls.Add(this.LocalPath_label);
            this.Controls.Add(this.RemotePath_textBox);
            this.Controls.Add(this.RemotePath_label);
            this.Controls.Add(this.RemoteServer_textBox);
            this.Controls.Add(this.RemoteServer_Label);
            this.Controls.Add(this.LocalPathValue_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(729, 274);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(729, 274);
            this.Name = "SFTP_values";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SFTP Values";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RemoteServer_Label;
        private System.Windows.Forms.TextBox RemoteServer_textBox;
        private System.Windows.Forms.TextBox RemotePath_textBox;
        private System.Windows.Forms.Label RemotePath_label;
        private System.Windows.Forms.Label LocalPath_label;
        private System.Windows.Forms.Button Accept_button;
        private System.Windows.Forms.Button Close_button;
        private System.Windows.Forms.Label LocalPathValue_label;
    }
}