namespace CSC370TeamProject
{
    partial class Form2
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
            this.form2_saveButton = new System.Windows.Forms.Button();
            this.saveInfoLabel = new System.Windows.Forms.Label();
            this.saveInfoLabel2 = new System.Windows.Forms.Label();
            this.usrFileNameTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // form2_saveButton
            // 
            this.form2_saveButton.Location = new System.Drawing.Point(117, 150);
            this.form2_saveButton.Name = "form2_saveButton";
            this.form2_saveButton.Size = new System.Drawing.Size(153, 39);
            this.form2_saveButton.TabIndex = 0;
            this.form2_saveButton.Text = "Save";
            this.form2_saveButton.UseVisualStyleBackColor = true;
            this.form2_saveButton.Click += new System.EventHandler(this.form2_saveButton_Click);
            // 
            // saveInfoLabel
            // 
            this.saveInfoLabel.AutoSize = true;
            this.saveInfoLabel.Location = new System.Drawing.Point(98, 9);
            this.saveInfoLabel.Name = "saveInfoLabel";
            this.saveInfoLabel.Size = new System.Drawing.Size(196, 20);
            this.saveInfoLabel.TabIndex = 1;
            this.saveInfoLabel.Text = "Enter Name for Excel File. ";
            // 
            // saveInfoLabel2
            // 
            this.saveInfoLabel2.AutoSize = true;
            this.saveInfoLabel2.Location = new System.Drawing.Point(44, 110);
            this.saveInfoLabel2.Name = "saveInfoLabel2";
            this.saveInfoLabel2.Size = new System.Drawing.Size(337, 20);
            this.saveInfoLabel2.TabIndex = 2;
            this.saveInfoLabel2.Text = "This file will be saved to your documents folder.";
            // 
            // usrFileNameTB
            // 
            this.usrFileNameTB.Location = new System.Drawing.Point(117, 61);
            this.usrFileNameTB.Name = "usrFileNameTB";
            this.usrFileNameTB.Size = new System.Drawing.Size(153, 26);
            this.usrFileNameTB.TabIndex = 3;
            // 
            // Form2
            // 
            this.AcceptButton = this.form2_saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 228);
            this.Controls.Add(this.usrFileNameTB);
            this.Controls.Add(this.saveInfoLabel2);
            this.Controls.Add(this.saveInfoLabel);
            this.Controls.Add(this.form2_saveButton);
            this.Name = "Form2";
            this.Text = "Save/Save As";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button form2_saveButton;
        private System.Windows.Forms.Label saveInfoLabel;
        private System.Windows.Forms.Label saveInfoLabel2;
        private System.Windows.Forms.TextBox usrFileNameTB;
    }
}