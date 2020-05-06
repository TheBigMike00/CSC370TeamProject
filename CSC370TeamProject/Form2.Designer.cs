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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.myStocksButton = new System.Windows.Forms.Button();
            this.myProfileButton = new System.Windows.Forms.Button();
            this.whatIfButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSavedDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historicValChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateCreatedLabel = new System.Windows.Forms.Label();
            this.dateCreatedTB = new System.Windows.Forms.TextBox();
            this.initialInvestmentLabel = new System.Windows.Forms.Label();
            this.initialInvestmentTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currProfileValueLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.percentChangeLabel = new System.Windows.Forms.Label();
            this.openExcelOfDataButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historicValChart)).BeginInit();
            this.SuspendLayout();
            // 
            // myStocksButton
            // 
            this.myStocksButton.Location = new System.Drawing.Point(250, 50);
            this.myStocksButton.Name = "myStocksButton";
            this.myStocksButton.Size = new System.Drawing.Size(100, 45);
            this.myStocksButton.TabIndex = 0;
            this.myStocksButton.Text = "My Stocks";
            this.myStocksButton.UseVisualStyleBackColor = true;
            this.myStocksButton.Click += new System.EventHandler(this.myStocksButton_Click);
            // 
            // myProfileButton
            // 
            this.myProfileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.myProfileButton.Location = new System.Drawing.Point(350, 50);
            this.myProfileButton.Name = "myProfileButton";
            this.myProfileButton.Size = new System.Drawing.Size(100, 45);
            this.myProfileButton.TabIndex = 1;
            this.myProfileButton.Text = "My Profile";
            this.myProfileButton.UseVisualStyleBackColor = false;
            // 
            // whatIfButton
            // 
            this.whatIfButton.Location = new System.Drawing.Point(450, 50);
            this.whatIfButton.Name = "whatIfButton";
            this.whatIfButton.Size = new System.Drawing.Size(100, 45);
            this.whatIfButton.TabIndex = 2;
            this.whatIfButton.Text = "What If?";
            this.whatIfButton.UseVisualStyleBackColor = true;
            this.whatIfButton.Click += new System.EventHandler(this.whatIfButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSavedDataToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadSavedDataToolStripMenuItem
            // 
            this.loadSavedDataToolStripMenuItem.Name = "loadSavedDataToolStripMenuItem";
            this.loadSavedDataToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
            this.loadSavedDataToolStripMenuItem.Text = "Load Saved Data";
            this.loadSavedDataToolStripMenuItem.Click += new System.EventHandler(this.loadSavedDataToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // historicValChart
            // 
            chartArea1.Name = "ChartArea1";
            this.historicValChart.ChartAreas.Add(chartArea1);
            this.historicValChart.Location = new System.Drawing.Point(350, 112);
            this.historicValChart.Name = "historicValChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.historicValChart.Series.Add(series1);
            this.historicValChart.Size = new System.Drawing.Size(420, 275);
            this.historicValChart.TabIndex = 4;
            this.historicValChart.Text = "chart1";
            // 
            // dateCreatedLabel
            // 
            this.dateCreatedLabel.AutoSize = true;
            this.dateCreatedLabel.Location = new System.Drawing.Point(12, 129);
            this.dateCreatedLabel.Name = "dateCreatedLabel";
            this.dateCreatedLabel.Size = new System.Drawing.Size(113, 20);
            this.dateCreatedLabel.TabIndex = 5;
            this.dateCreatedLabel.Text = "Date Created: ";
            // 
            // dateCreatedTB
            // 
            this.dateCreatedTB.Location = new System.Drawing.Point(122, 126);
            this.dateCreatedTB.Name = "dateCreatedTB";
            this.dateCreatedTB.ReadOnly = true;
            this.dateCreatedTB.Size = new System.Drawing.Size(168, 26);
            this.dateCreatedTB.TabIndex = 6;
            this.dateCreatedTB.Text = "No Saved Data";
            // 
            // initialInvestmentLabel
            // 
            this.initialInvestmentLabel.AutoSize = true;
            this.initialInvestmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.initialInvestmentLabel.Location = new System.Drawing.Point(12, 168);
            this.initialInvestmentLabel.Name = "initialInvestmentLabel";
            this.initialInvestmentLabel.Size = new System.Drawing.Size(119, 18);
            this.initialInvestmentLabel.TabIndex = 7;
            this.initialInvestmentLabel.Text = "Initial Investment:";
            // 
            // initialInvestmentTB
            // 
            this.initialInvestmentTB.Location = new System.Drawing.Point(137, 164);
            this.initialInvestmentTB.Name = "initialInvestmentTB";
            this.initialInvestmentTB.ReadOnly = true;
            this.initialInvestmentTB.Size = new System.Drawing.Size(157, 26);
            this.initialInvestmentTB.TabIndex = 8;
            this.initialInvestmentTB.Text = "No Saved Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(34, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Current Profile Value";
            // 
            // currProfileValueLabel
            // 
            this.currProfileValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.currProfileValueLabel.ForeColor = System.Drawing.Color.Black;
            this.currProfileValueLabel.Location = new System.Drawing.Point(10, 255);
            this.currProfileValueLabel.Name = "currProfileValueLabel";
            this.currProfileValueLabel.Size = new System.Drawing.Size(282, 30);
            this.currProfileValueLabel.TabIndex = 10;
            this.currProfileValueLabel.Text = "No Saved Data";
            this.currProfileValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(58, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "Percent Change";
            // 
            // percentChangeLabel
            // 
            this.percentChangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.percentChangeLabel.Location = new System.Drawing.Point(23, 361);
            this.percentChangeLabel.Name = "percentChangeLabel";
            this.percentChangeLabel.Size = new System.Drawing.Size(250, 30);
            this.percentChangeLabel.TabIndex = 12;
            this.percentChangeLabel.Text = "No Saved Data";
            this.percentChangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openExcelOfDataButton
            // 
            this.openExcelOfDataButton.Location = new System.Drawing.Point(475, 405);
            this.openExcelOfDataButton.Name = "openExcelOfDataButton";
            this.openExcelOfDataButton.Size = new System.Drawing.Size(191, 33);
            this.openExcelOfDataButton.TabIndex = 13;
            this.openExcelOfDataButton.Text = "Open Excel of Data";
            this.openExcelOfDataButton.UseVisualStyleBackColor = true;
            this.openExcelOfDataButton.Click += new System.EventHandler(this.openExcelOfDataButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.openExcelOfDataButton);
            this.Controls.Add(this.percentChangeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currProfileValueLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.initialInvestmentTB);
            this.Controls.Add(this.initialInvestmentLabel);
            this.Controls.Add(this.dateCreatedTB);
            this.Controls.Add(this.dateCreatedLabel);
            this.Controls.Add(this.historicValChart);
            this.Controls.Add(this.whatIfButton);
            this.Controls.Add(this.myProfileButton);
            this.Controls.Add(this.myStocksButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "MyProfile";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historicValChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button myStocksButton;
        private System.Windows.Forms.Button myProfileButton;
        private System.Windows.Forms.Button whatIfButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart historicValChart;
        private System.Windows.Forms.Label dateCreatedLabel;
        private System.Windows.Forms.TextBox dateCreatedTB;
        private System.Windows.Forms.Label initialInvestmentLabel;
        private System.Windows.Forms.TextBox initialInvestmentTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currProfileValueLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label percentChangeLabel;
        private System.Windows.Forms.Button openExcelOfDataButton;
        private System.Windows.Forms.ToolStripMenuItem loadSavedDataToolStripMenuItem;
    }
}