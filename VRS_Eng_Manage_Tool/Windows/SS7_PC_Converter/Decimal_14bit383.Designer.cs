namespace VRS_Eng_Manage_Tool.Windows.SS7_PC_Converter
{
    partial class Decimal_14bit383
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Decimal_14bit383));
            this.pcValue_textBox = new System.Windows.Forms.TextBox();
            this.User_Label = new System.Windows.Forms.Label();
            this.Convert_button = new System.Windows.Forms.Button();
            this.copyToClipboard_linkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.resultValue_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pcValue_textBox
            // 
            this.pcValue_textBox.Location = new System.Drawing.Point(50, 65);
            this.pcValue_textBox.MaxLength = 5;
            this.pcValue_textBox.Name = "pcValue_textBox";
            this.pcValue_textBox.Size = new System.Drawing.Size(58, 20);
            this.pcValue_textBox.TabIndex = 0;
            this.pcValue_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // User_Label
            // 
            this.User_Label.AutoSize = true;
            this.User_Label.Location = new System.Drawing.Point(49, 49);
            this.User_Label.Name = "User_Label";
            this.User_Label.Size = new System.Drawing.Size(59, 13);
            this.User_Label.TabIndex = 4;
            this.User_Label.Text = "Point Code";
            // 
            // Convert_button
            // 
            this.Convert_button.Location = new System.Drawing.Point(43, 105);
            this.Convert_button.Name = "Convert_button";
            this.Convert_button.Size = new System.Drawing.Size(75, 23);
            this.Convert_button.TabIndex = 1;
            this.Convert_button.Text = "Convert";
            this.Convert_button.UseVisualStyleBackColor = true;
            this.Convert_button.Click += new System.EventHandler(this.Convert_button_Click);
            // 
            // copyToClipboard_linkLabel
            // 
            this.copyToClipboard_linkLabel.AutoSize = true;
            this.copyToClipboard_linkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyToClipboard_linkLabel.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.copyToClipboard_linkLabel.Location = new System.Drawing.Point(38, 184);
            this.copyToClipboard_linkLabel.Name = "copyToClipboard_linkLabel";
            this.copyToClipboard_linkLabel.Size = new System.Drawing.Size(90, 13);
            this.copyToClipboard_linkLabel.TabIndex = 3;
            this.copyToClipboard_linkLabel.TabStop = true;
            this.copyToClipboard_linkLabel.Text = "Copy to Clipboard";
            this.copyToClipboard_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.copyToClipboard_linkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Conversion";
            // 
            // resultValue_textBox
            // 
            this.resultValue_textBox.BackColor = System.Drawing.SystemColors.Window;
            this.resultValue_textBox.Location = new System.Drawing.Point(50, 161);
            this.resultValue_textBox.Name = "resultValue_textBox";
            this.resultValue_textBox.ReadOnly = true;
            this.resultValue_textBox.Size = new System.Drawing.Size(58, 20);
            this.resultValue_textBox.TabIndex = 2;
            this.resultValue_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Decimal --> 14 bit (3-8-3)";
            // 
            // Decimal_14bit383
            // 
            this.AcceptButton = this.Convert_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 234);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.copyToClipboard_linkLabel);
            this.Controls.Add(this.resultValue_textBox);
            this.Controls.Add(this.Convert_button);
            this.Controls.Add(this.pcValue_textBox);
            this.Controls.Add(this.User_Label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(181, 273);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(181, 273);
            this.Name = "Decimal_14bit383";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SS7 PC Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pcValue_textBox;
        private System.Windows.Forms.Label User_Label;
        private System.Windows.Forms.Button Convert_button;
        private System.Windows.Forms.LinkLabel copyToClipboard_linkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox resultValue_textBox;
        private System.Windows.Forms.Label label2;
    }
}