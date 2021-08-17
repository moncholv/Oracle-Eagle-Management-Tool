namespace VRS_Eng_Manage_Tool.Windows.SFTP
{
    partial class SelectionSTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionSTP));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.allStps_checkBox = new System.Windows.Forms.CheckBox();
            this.MIL2_checkBox = new System.Windows.Forms.CheckBox();
            this.MIL1_checkBox = new System.Windows.Forms.CheckBox();
            this.RAT2_checkBox = new System.Windows.Forms.CheckBox();
            this.RAT1_checkBox = new System.Windows.Forms.CheckBox();
            this.Accept_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.allStps_checkBox);
            this.groupBox1.Controls.Add(this.MIL2_checkBox);
            this.groupBox1.Controls.Add(this.MIL1_checkBox);
            this.groupBox1.Controls.Add(this.RAT2_checkBox);
            this.groupBox1.Controls.Add(this.RAT1_checkBox);
            this.groupBox1.Location = new System.Drawing.Point(30, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // allStps_checkBox
            // 
            this.allStps_checkBox.AutoSize = true;
            this.allStps_checkBox.Location = new System.Drawing.Point(9, 0);
            this.allStps_checkBox.Name = "allStps_checkBox";
            this.allStps_checkBox.Size = new System.Drawing.Size(52, 17);
            this.allStps_checkBox.TabIndex = 0;
            this.allStps_checkBox.Text = "STPs";
            this.allStps_checkBox.UseVisualStyleBackColor = true;
            this.allStps_checkBox.CheckedChanged += new System.EventHandler(this.allStps_checkBox_CheckedChanged);
            // 
            // MIL2_checkBox
            // 
            this.MIL2_checkBox.AutoSize = true;
            this.MIL2_checkBox.Location = new System.Drawing.Point(251, 33);
            this.MIL2_checkBox.Name = "MIL2_checkBox";
            this.MIL2_checkBox.Size = new System.Drawing.Size(50, 17);
            this.MIL2_checkBox.TabIndex = 4;
            this.MIL2_checkBox.Text = "MIL2";
            this.MIL2_checkBox.UseVisualStyleBackColor = true;
            // 
            // MIL1_checkBox
            // 
            this.MIL1_checkBox.AutoSize = true;
            this.MIL1_checkBox.Location = new System.Drawing.Point(177, 33);
            this.MIL1_checkBox.Name = "MIL1_checkBox";
            this.MIL1_checkBox.Size = new System.Drawing.Size(50, 17);
            this.MIL1_checkBox.TabIndex = 3;
            this.MIL1_checkBox.Text = "MIL1";
            this.MIL1_checkBox.UseVisualStyleBackColor = true;
            // 
            // RAT2_checkBox
            // 
            this.RAT2_checkBox.AutoSize = true;
            this.RAT2_checkBox.Location = new System.Drawing.Point(102, 33);
            this.RAT2_checkBox.Name = "RAT2_checkBox";
            this.RAT2_checkBox.Size = new System.Drawing.Size(54, 17);
            this.RAT2_checkBox.TabIndex = 2;
            this.RAT2_checkBox.Text = "RAT2";
            this.RAT2_checkBox.UseVisualStyleBackColor = true;
            // 
            // RAT1_checkBox
            // 
            this.RAT1_checkBox.AutoSize = true;
            this.RAT1_checkBox.Location = new System.Drawing.Point(28, 33);
            this.RAT1_checkBox.Name = "RAT1_checkBox";
            this.RAT1_checkBox.Size = new System.Drawing.Size(54, 17);
            this.RAT1_checkBox.TabIndex = 1;
            this.RAT1_checkBox.Text = "RAT1";
            this.RAT1_checkBox.UseVisualStyleBackColor = true;
            // 
            // Accept_button
            // 
            this.Accept_button.Location = new System.Drawing.Point(111, 106);
            this.Accept_button.Name = "Accept_button";
            this.Accept_button.Size = new System.Drawing.Size(75, 23);
            this.Accept_button.TabIndex = 1;
            this.Accept_button.Text = "Accept";
            this.Accept_button.UseVisualStyleBackColor = true;
            this.Accept_button.Click += new System.EventHandler(this.Accept_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(206, 106);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.TabIndex = 2;
            this.Cancel_button.Text = "Cancel";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // SelectionSTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 149);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Accept_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(406, 188);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(406, 188);
            this.Name = "SelectionSTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select STP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox MIL2_checkBox;
        private System.Windows.Forms.CheckBox MIL1_checkBox;
        private System.Windows.Forms.CheckBox RAT2_checkBox;
        private System.Windows.Forms.CheckBox RAT1_checkBox;
        private System.Windows.Forms.Button Accept_button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.CheckBox allStps_checkBox;
    }
}