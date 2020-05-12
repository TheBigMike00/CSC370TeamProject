namespace CSC370TeamProject
{
    partial class Form3
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.myStocksButton = new System.Windows.Forms.Button();
            this.myProfileButton = new System.Windows.Forms.Button();
            this.whatIfButton = new System.Windows.Forms.Button();
            this.stocksymbolLabel = new System.Windows.Forms.Label();
            this.stockSymbolTB = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.quantityTB = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchButton = new System.Windows.Forms.Button();
            this.resultsLabelContext = new System.Windows.Forms.Label();
            this.valuePlusMinusLabel = new System.Windows.Forms.Label();
            this.percentChangeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.myProfileButton.Location = new System.Drawing.Point(350, 50);
            this.myProfileButton.Name = "myProfileButton";
            this.myProfileButton.Size = new System.Drawing.Size(100, 45);
            this.myProfileButton.TabIndex = 1;
            this.myProfileButton.Text = "My Profile";
            this.myProfileButton.UseVisualStyleBackColor = true;
            this.myProfileButton.Click += new System.EventHandler(this.myProfileButton_Click);
            // 
            // whatIfButton
            // 
            this.whatIfButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.whatIfButton.Location = new System.Drawing.Point(450, 50);
            this.whatIfButton.Name = "whatIfButton";
            this.whatIfButton.Size = new System.Drawing.Size(100, 45);
            this.whatIfButton.TabIndex = 2;
            this.whatIfButton.Text = "What If?";
            this.whatIfButton.UseVisualStyleBackColor = false;
            // 
            // stocksymbolLabel
            // 
            this.stocksymbolLabel.AutoSize = true;
            this.stocksymbolLabel.Location = new System.Drawing.Point(12, 139);
            this.stocksymbolLabel.Name = "stocksymbolLabel";
            this.stocksymbolLabel.Size = new System.Drawing.Size(153, 20);
            this.stocksymbolLabel.TabIndex = 3;
            this.stocksymbolLabel.Text = "Enter Stock Symbol:";
            // 
            // stockSymbolTB
            // 
            this.stockSymbolTB.Location = new System.Drawing.Point(167, 136);
            this.stockSymbolTB.Name = "stockSymbolTB";
            this.stockSymbolTB.Size = new System.Drawing.Size(100, 26);
            this.stockSymbolTB.TabIndex = 4;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(350, 139);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(414, 236);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label2.Location = new System.Drawing.Point(479, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Stock Value This Week";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(89, 189);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(76, 20);
            this.quantityLabel.TabIndex = 7;
            this.quantityLabel.Text = "Quantity: ";
            // 
            // quantityTB
            // 
            this.quantityTB.Location = new System.Drawing.Point(167, 189);
            this.quantityTB.Name = "quantityTB";
            this.quantityTB.Size = new System.Drawing.Size(100, 26);
            this.quantityTB.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(93, 240);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(133, 42);
            this.searchButton.TabIndex = 10;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // resultsLabelContext
            // 
            this.resultsLabelContext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.resultsLabelContext.Location = new System.Drawing.Point(52, 324);
            this.resultsLabelContext.Name = "resultsLabelContext";
            this.resultsLabelContext.Size = new System.Drawing.Size(251, 39);
            this.resultsLabelContext.TabIndex = 11;
            this.resultsLabelContext.Text = "x Shares of y 3 Months Ago";
            // 
            // valuePlusMinusLabel
            // 
            this.valuePlusMinusLabel.AutoSize = true;
            this.valuePlusMinusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.valuePlusMinusLabel.Location = new System.Drawing.Point(31, 363);
            this.valuePlusMinusLabel.Name = "valuePlusMinusLabel";
            this.valuePlusMinusLabel.Size = new System.Drawing.Size(223, 22);
            this.valuePlusMinusLabel.TabIndex = 12;
            this.valuePlusMinusLabel.Text = "Impact on Portfolio:            ";
            // 
            // percentChangeLabel
            // 
            this.percentChangeLabel.AutoSize = true;
            this.percentChangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.percentChangeLabel.Location = new System.Drawing.Point(27, 400);
            this.percentChangeLabel.Name = "percentChangeLabel";
            this.percentChangeLabel.Size = new System.Drawing.Size(150, 22);
            this.percentChangeLabel.TabIndex = 13;
            this.percentChangeLabel.Text = "Percent Change: ";
            // 
            // Form3
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.percentChangeLabel);
            this.Controls.Add(this.valuePlusMinusLabel);
            this.Controls.Add(this.resultsLabelContext);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.quantityTB);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.stockSymbolTB);
            this.Controls.Add(this.stocksymbolLabel);
            this.Controls.Add(this.whatIfButton);
            this.Controls.Add(this.myProfileButton);
            this.Controls.Add(this.myStocksButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.Text = "What If?";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button myStocksButton;
        private System.Windows.Forms.Button myProfileButton;
        private System.Windows.Forms.Button whatIfButton;
        private System.Windows.Forms.Label stocksymbolLabel;
        private System.Windows.Forms.TextBox stockSymbolTB;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.TextBox quantityTB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label resultsLabelContext;
        private System.Windows.Forms.Label valuePlusMinusLabel;
        private System.Windows.Forms.Label percentChangeLabel;
    }
}