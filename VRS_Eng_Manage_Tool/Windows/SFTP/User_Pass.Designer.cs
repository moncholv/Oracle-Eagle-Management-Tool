namespace VRS_Eng_Manage_Tool.Windows.SFTP
{
    partial class User_Pass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Pass));
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.User_Label = new System.Windows.Forms.Label();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Accept_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(94, 28);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(129, 20);
            this.username_textBox.TabIndex = 3;
            // 
            // User_Label
            // 
            this.User_Label.AutoSize = true;
            this.User_Label.Location = new System.Drawing.Point(26, 31);
            this.User_Label.Name = "User_Label";
            this.User_Label.Size = new System.Drawing.Size(29, 13);
            this.User_Label.TabIndex = 2;
            this.User_Label.Text = "User";
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(94, 63);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(129, 20);
            this.Password_textBox.TabIndex = 5;
            this.Password_textBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Password";
            // 
            // Accept_button
            // 
            this.Accept_button.Location = new System.Drawing.Point(92, 108);
            this.Accept_button.Name = "Accept_button";
            this.Accept_button.Size = new System.Drawing.Size(75, 23);
            this.Accept_button.TabIndex = 11;
            this.Accept_button.Text = "Accept";
            this.Accept_button.UseVisualStyleBackColor = true;
            this.Accept_button.Click += new System.EventHandler(this.Accept_button_Click);
            // 
            // User_Pass
            // 
            this.AcceptButton = this.Accept_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 156);
            this.Controls.Add(this.Accept_button);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.User_Label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(277, 195);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(277, 195);
            this.Name = "User_Pass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SFTP Authorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.Label User_Label;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Accept_button;
    }
}