namespace VRS_Eng_Manage_Tool.Windows.SFTP
{
    partial class Downloads
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Downloads));
            this.SftpStatus_textBox = new System.Windows.Forms.TextBox();
            this.Close_button = new System.Windows.Forms.Button();
            this.DownloadFilesStatus_label = new System.Windows.Forms.Label();
            this.DownloadFiles_button = new System.Windows.Forms.Button();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.User_Label = new System.Windows.Forms.Label();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SftpStatus_textBox
            // 
            this.SftpStatus_textBox.Location = new System.Drawing.Point(33, 62);
            this.SftpStatus_textBox.Multiline = true;
            this.SftpStatus_textBox.Name = "SftpStatus_textBox";
            this.SftpStatus_textBox.ReadOnly = true;
            this.SftpStatus_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SftpStatus_textBox.Size = new System.Drawing.Size(470, 395);
            this.SftpStatus_textBox.TabIndex = 4;
            // 
            // Close_button
            // 
            this.Close_button.Location = new System.Drawing.Point(399, 463);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(104, 30);
            this.Close_button.TabIndex = 3;
            this.Close_button.Text = "Close";
            this.Close_button.UseVisualStyleBackColor = true;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // DownloadFilesStatus_label
            // 
            this.DownloadFilesStatus_label.AutoSize = true;
            this.DownloadFilesStatus_label.Location = new System.Drawing.Point(382, 46);
            this.DownloadFilesStatus_label.Name = "DownloadFilesStatus_label";
            this.DownloadFilesStatus_label.Size = new System.Drawing.Size(121, 13);
            this.DownloadFilesStatus_label.TabIndex = 5;
            this.DownloadFilesStatus_label.Text = "Downloading file 1 of 98";
            this.DownloadFilesStatus_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.DownloadFilesStatus_label.Visible = false;
            // 
            // DownloadFiles_button
            // 
            this.DownloadFiles_button.Location = new System.Drawing.Point(33, 463);
            this.DownloadFiles_button.Name = "DownloadFiles_button";
            this.DownloadFiles_button.Size = new System.Drawing.Size(104, 30);
            this.DownloadFiles_button.TabIndex = 2;
            this.DownloadFiles_button.Text = "Download Files";
            this.DownloadFiles_button.UseVisualStyleBackColor = true;
            this.DownloadFiles_button.Click += new System.EventHandler(this.DownloadFiles_button_Click);
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(65, 22);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(89, 20);
            this.username_textBox.TabIndex = 0;
            // 
            // User_Label
            // 
            this.User_Label.AutoSize = true;
            this.User_Label.Location = new System.Drawing.Point(30, 25);
            this.User_Label.Name = "User_Label";
            this.User_Label.Size = new System.Drawing.Size(29, 13);
            this.User_Label.TabIndex = 4;
            this.User_Label.Text = "User";
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(234, 22);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(129, 20);
            this.Password_textBox.TabIndex = 1;
            this.Password_textBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Password";
            // 
            // Downloads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 523);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.User_Label);
            this.Controls.Add(this.DownloadFiles_button);
            this.Controls.Add(this.DownloadFilesStatus_label);
            this.Controls.Add(this.Close_button);
            this.Controls.Add(this.SftpStatus_textBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 562);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 562);
            this.Name = "Downloads";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Downloads";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SftpStatus_textBox;
        private System.Windows.Forms.Button Close_button;
        private System.Windows.Forms.Label DownloadFilesStatus_label;
        private System.Windows.Forms.Button DownloadFiles_button;
        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.Label User_Label;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Label label1;
    }
}