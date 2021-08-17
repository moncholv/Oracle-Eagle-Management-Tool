namespace VRS_Eng_Manage_Tool.Windows.STP_Data
{
    partial class LoadedData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadedData));
            this.close_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.stp_groupBox = new System.Windows.Forms.GroupBox();
            this.stpMil2_checkBox = new System.Windows.Forms.CheckBox();
            this.stpMil1_checkBox = new System.Windows.Forms.CheckBox();
            this.stpRat2_checkBox = new System.Windows.Forms.CheckBox();
            this.stpRat1_checkBox = new System.Windows.Forms.CheckBox();
            this.type_groupBox = new System.Windows.Forms.GroupBox();
            this.host_checkBox = new System.Windows.Forms.CheckBox();
            this.assoc_checkBox = new System.Windows.Forms.CheckBox();
            this.slk_checkBox = new System.Windows.Forms.CheckBox();
            this.dstn_checkBox = new System.Windows.Forms.CheckBox();
            this.mrnset_checkBox = new System.Windows.Forms.CheckBox();
            this.opcode_checkBox = new System.Windows.Forms.CheckBox();
            this.gta_checkBox = new System.Windows.Forms.CheckBox();
            this.gttset_checkBox = new System.Windows.Forms.CheckBox();
            this.gttsel_checkBox = new System.Windows.Forms.CheckBox();
            this.stp_groupBox.SuspendLayout();
            this.type_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(208, 310);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(96, 27);
            this.close_button.TabIndex = 14;
            this.close_button.Text = "Cancel";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 27);
            this.button1.TabIndex = 15;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stp_groupBox
            // 
            this.stp_groupBox.Controls.Add(this.stpMil2_checkBox);
            this.stp_groupBox.Controls.Add(this.stpMil1_checkBox);
            this.stp_groupBox.Controls.Add(this.stpRat2_checkBox);
            this.stp_groupBox.Controls.Add(this.stpRat1_checkBox);
            this.stp_groupBox.Location = new System.Drawing.Point(36, 28);
            this.stp_groupBox.Name = "stp_groupBox";
            this.stp_groupBox.Size = new System.Drawing.Size(304, 63);
            this.stp_groupBox.TabIndex = 6;
            this.stp_groupBox.TabStop = false;
            this.stp_groupBox.Text = " STP ";
            // 
            // stpMil2_checkBox
            // 
            this.stpMil2_checkBox.AutoSize = true;
            this.stpMil2_checkBox.Enabled = false;
            this.stpMil2_checkBox.Location = new System.Drawing.Point(234, 26);
            this.stpMil2_checkBox.Name = "stpMil2_checkBox";
            this.stpMil2_checkBox.Size = new System.Drawing.Size(50, 17);
            this.stpMil2_checkBox.TabIndex = 3;
            this.stpMil2_checkBox.Text = "MIL2";
            this.stpMil2_checkBox.UseVisualStyleBackColor = true;
            this.stpMil2_checkBox.CheckedChanged += new System.EventHandler(this.stp_checkBox_CheckedChanged);
            // 
            // stpMil1_checkBox
            // 
            this.stpMil1_checkBox.AutoSize = true;
            this.stpMil1_checkBox.Enabled = false;
            this.stpMil1_checkBox.Location = new System.Drawing.Point(164, 26);
            this.stpMil1_checkBox.Name = "stpMil1_checkBox";
            this.stpMil1_checkBox.Size = new System.Drawing.Size(50, 17);
            this.stpMil1_checkBox.TabIndex = 2;
            this.stpMil1_checkBox.Text = "MIL1";
            this.stpMil1_checkBox.UseVisualStyleBackColor = true;
            this.stpMil1_checkBox.CheckedChanged += new System.EventHandler(this.stp_checkBox_CheckedChanged);
            // 
            // stpRat2_checkBox
            // 
            this.stpRat2_checkBox.AutoSize = true;
            this.stpRat2_checkBox.Enabled = false;
            this.stpRat2_checkBox.Location = new System.Drawing.Point(94, 26);
            this.stpRat2_checkBox.Name = "stpRat2_checkBox";
            this.stpRat2_checkBox.Size = new System.Drawing.Size(54, 17);
            this.stpRat2_checkBox.TabIndex = 1;
            this.stpRat2_checkBox.Text = "RAT2";
            this.stpRat2_checkBox.UseVisualStyleBackColor = true;
            this.stpRat2_checkBox.CheckedChanged += new System.EventHandler(this.stp_checkBox_CheckedChanged);
            // 
            // stpRat1_checkBox
            // 
            this.stpRat1_checkBox.AutoSize = true;
            this.stpRat1_checkBox.Enabled = false;
            this.stpRat1_checkBox.Location = new System.Drawing.Point(24, 26);
            this.stpRat1_checkBox.Name = "stpRat1_checkBox";
            this.stpRat1_checkBox.Size = new System.Drawing.Size(54, 17);
            this.stpRat1_checkBox.TabIndex = 0;
            this.stpRat1_checkBox.Text = "RAT1";
            this.stpRat1_checkBox.UseVisualStyleBackColor = true;
            this.stpRat1_checkBox.CheckedChanged += new System.EventHandler(this.stp_checkBox_CheckedChanged);
            // 
            // type_groupBox
            // 
            this.type_groupBox.Controls.Add(this.host_checkBox);
            this.type_groupBox.Controls.Add(this.assoc_checkBox);
            this.type_groupBox.Controls.Add(this.slk_checkBox);
            this.type_groupBox.Controls.Add(this.dstn_checkBox);
            this.type_groupBox.Controls.Add(this.mrnset_checkBox);
            this.type_groupBox.Controls.Add(this.opcode_checkBox);
            this.type_groupBox.Controls.Add(this.gta_checkBox);
            this.type_groupBox.Controls.Add(this.gttset_checkBox);
            this.type_groupBox.Controls.Add(this.gttsel_checkBox);
            this.type_groupBox.Location = new System.Drawing.Point(36, 118);
            this.type_groupBox.Name = "type_groupBox";
            this.type_groupBox.Size = new System.Drawing.Size(304, 159);
            this.type_groupBox.TabIndex = 7;
            this.type_groupBox.TabStop = false;
            this.type_groupBox.Text = " Sections Loaded ";
            // 
            // host_checkBox
            // 
            this.host_checkBox.AutoSize = true;
            this.host_checkBox.Enabled = false;
            this.host_checkBox.Location = new System.Drawing.Point(218, 110);
            this.host_checkBox.Name = "host_checkBox";
            this.host_checkBox.Size = new System.Drawing.Size(56, 17);
            this.host_checkBox.TabIndex = 8;
            this.host_checkBox.Text = "HOST";
            this.host_checkBox.UseVisualStyleBackColor = true;
            // 
            // assoc_checkBox
            // 
            this.assoc_checkBox.AutoSize = true;
            this.assoc_checkBox.Enabled = false;
            this.assoc_checkBox.Location = new System.Drawing.Point(125, 110);
            this.assoc_checkBox.Name = "assoc_checkBox";
            this.assoc_checkBox.Size = new System.Drawing.Size(62, 17);
            this.assoc_checkBox.TabIndex = 7;
            this.assoc_checkBox.Text = "ASSOC";
            this.assoc_checkBox.UseVisualStyleBackColor = true;
            // 
            // slk_checkBox
            // 
            this.slk_checkBox.AutoSize = true;
            this.slk_checkBox.Enabled = false;
            this.slk_checkBox.Location = new System.Drawing.Point(32, 110);
            this.slk_checkBox.Name = "slk_checkBox";
            this.slk_checkBox.Size = new System.Drawing.Size(46, 17);
            this.slk_checkBox.TabIndex = 6;
            this.slk_checkBox.Text = "SLK";
            this.slk_checkBox.UseVisualStyleBackColor = true;
            // 
            // dstn_checkBox
            // 
            this.dstn_checkBox.AutoSize = true;
            this.dstn_checkBox.Enabled = false;
            this.dstn_checkBox.Location = new System.Drawing.Point(218, 73);
            this.dstn_checkBox.Name = "dstn_checkBox";
            this.dstn_checkBox.Size = new System.Drawing.Size(56, 17);
            this.dstn_checkBox.TabIndex = 5;
            this.dstn_checkBox.Text = "DSTN";
            this.dstn_checkBox.UseVisualStyleBackColor = true;
            // 
            // mrnset_checkBox
            // 
            this.mrnset_checkBox.AutoSize = true;
            this.mrnset_checkBox.Enabled = false;
            this.mrnset_checkBox.Location = new System.Drawing.Point(125, 73);
            this.mrnset_checkBox.Name = "mrnset_checkBox";
            this.mrnset_checkBox.Size = new System.Drawing.Size(72, 17);
            this.mrnset_checkBox.TabIndex = 4;
            this.mrnset_checkBox.Text = "MRNSET";
            this.mrnset_checkBox.UseVisualStyleBackColor = true;
            // 
            // opcode_checkBox
            // 
            this.opcode_checkBox.AutoSize = true;
            this.opcode_checkBox.Enabled = false;
            this.opcode_checkBox.Location = new System.Drawing.Point(32, 73);
            this.opcode_checkBox.Name = "opcode_checkBox";
            this.opcode_checkBox.Size = new System.Drawing.Size(71, 17);
            this.opcode_checkBox.TabIndex = 3;
            this.opcode_checkBox.Text = "OPCODE";
            this.opcode_checkBox.UseVisualStyleBackColor = true;
            // 
            // gta_checkBox
            // 
            this.gta_checkBox.AutoSize = true;
            this.gta_checkBox.Enabled = false;
            this.gta_checkBox.Location = new System.Drawing.Point(218, 36);
            this.gta_checkBox.Name = "gta_checkBox";
            this.gta_checkBox.Size = new System.Drawing.Size(48, 17);
            this.gta_checkBox.TabIndex = 2;
            this.gta_checkBox.Text = "GTA";
            this.gta_checkBox.UseVisualStyleBackColor = true;
            // 
            // gttset_checkBox
            // 
            this.gttset_checkBox.AutoSize = true;
            this.gttset_checkBox.Enabled = false;
            this.gttset_checkBox.Location = new System.Drawing.Point(125, 36);
            this.gttset_checkBox.Name = "gttset_checkBox";
            this.gttset_checkBox.Size = new System.Drawing.Size(69, 17);
            this.gttset_checkBox.TabIndex = 1;
            this.gttset_checkBox.Text = "GTTSET";
            this.gttset_checkBox.UseVisualStyleBackColor = true;
            // 
            // gttsel_checkBox
            // 
            this.gttsel_checkBox.AutoSize = true;
            this.gttsel_checkBox.Enabled = false;
            this.gttsel_checkBox.Location = new System.Drawing.Point(32, 36);
            this.gttsel_checkBox.Name = "gttsel_checkBox";
            this.gttsel_checkBox.Size = new System.Drawing.Size(68, 17);
            this.gttsel_checkBox.TabIndex = 0;
            this.gttsel_checkBox.Text = "GTTSEL";
            this.gttsel_checkBox.UseVisualStyleBackColor = true;
            // 
            // LoadedData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 370);
            this.Controls.Add(this.type_groupBox);
            this.Controls.Add(this.stp_groupBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.close_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(396, 409);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(396, 409);
            this.Name = "LoadedData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "STPs Loaded Data";
            this.stp_groupBox.ResumeLayout(false);
            this.stp_groupBox.PerformLayout();
            this.type_groupBox.ResumeLayout(false);
            this.type_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox stp_groupBox;
        private System.Windows.Forms.CheckBox stpMil2_checkBox;
        private System.Windows.Forms.CheckBox stpMil1_checkBox;
        private System.Windows.Forms.CheckBox stpRat2_checkBox;
        private System.Windows.Forms.CheckBox stpRat1_checkBox;
        private System.Windows.Forms.GroupBox type_groupBox;
        private System.Windows.Forms.CheckBox gta_checkBox;
        private System.Windows.Forms.CheckBox gttset_checkBox;
        private System.Windows.Forms.CheckBox gttsel_checkBox;
        private System.Windows.Forms.CheckBox dstn_checkBox;
        private System.Windows.Forms.CheckBox mrnset_checkBox;
        private System.Windows.Forms.CheckBox opcode_checkBox;
        private System.Windows.Forms.CheckBox host_checkBox;
        private System.Windows.Forms.CheckBox assoc_checkBox;
        private System.Windows.Forms.CheckBox slk_checkBox;
    }
}