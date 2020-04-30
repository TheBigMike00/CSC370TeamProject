using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC370TeamProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if (myGlobals.isDataLoaded)
            {
                Excel usrExcel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "UserData.xlsx", 1);
                loadChart();
                defineLabels(usrExcel);
            }
            
        }

        public void loadChart()
        {
            Excel histExcel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "HistoricalProfileValues.xlsx", 1);
            var myChart = historicValChart.ChartAreas[0];
            myChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            myChart.AxisX.LabelStyle.Format = "";
            myChart.AxisY.LabelStyle.Format = "";
            myChart.AxisX.LabelStyle.IsEndLabelVisible = true;

            myChart.AxisX.Minimum = 0;
            myChart.AxisY.Minimum = 0;

            myChart.AxisY.Interval = 250;

            historicValChart.Series[0].IsVisibleInLegend = false;
            historicValChart.Series.Add("Value");
            historicValChart.Series["Value"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            historicValChart.Series["Value"].Color = Color.Green;

            if (myGlobals.historicVals.Count >= 5)
            {
                historicValChart.Series["Value"].Points.AddXY(1, myGlobals.historicVals[myGlobals.historicVals.Count-5]);
                historicValChart.Series["Value"].Points.AddXY(1, myGlobals.historicVals[myGlobals.historicVals.Count - 4]);
                historicValChart.Series["Value"].Points.AddXY(1, myGlobals.historicVals[myGlobals.historicVals.Count - 3]);
                historicValChart.Series["Value"].Points.AddXY(1, myGlobals.historicVals[myGlobals.historicVals.Count - 2]);
                historicValChart.Series["Value"].Points.AddXY(1, myGlobals.historicVals[myGlobals.historicVals.Count - 1]);
            }
            else
            {
                for (int i = 1; i < myGlobals.historicVals.Count; i++)
                {
                    historicValChart.Series["Value"].Points.AddXY(i, myGlobals.historicVals[i]);
                }
            }


            histExcel.Save();
            histExcel.Close();
        }

        public void defineLabels(Excel usrExcel)
        {
            dateCreatedTB.Text = Convert.ToString(myGlobals.historicTimestamps[0]);
            initialInvestmentTB.Text = "$" + Convert.ToString(myGlobals.historicVals[0]);
            currProfileValueLabel.Text = "$" + Convert.ToString(myGlobals.historicVals[myGlobals.historicVals.Count - 1]);
            double currentV = Convert.ToDouble(myGlobals.historicVals[myGlobals.historicVals.Count - 1]);
            double initialV = Convert.ToDouble(myGlobals.historicVals[0]);
            percentChangeLabel.Text = Convert.ToString((currentV - initialV)/initialV );
        }

        private void myStocksButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockProfile myStocks = new StockProfile();
            myStocks.ShowDialog();
            this.Close();
        }

        private void openExcelOfDataButton_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + "HistoricalProfileValues.xlsx");
            if (fi.Exists)
            {
                //                                                   
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "HistoricalProfileValues.xlsx");
            }
            else
            {
                MessageBox.Show("Unable to locate file", "Error Locating File");
            }
        }

        private void loadSavedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel usrExcel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "UserData.xlsx", 1);
            Excel excel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "MyData.xlsx", 1);
            int counter = 1;
            if (myGlobals.isDataLoaded != true)
            {
                while (usrExcel.readCell(counter, 1) != null)
                    counter += 10;

                counter -= 10;
                if (usrExcel.readCell(counter + 2, 1) == null)
                {
                    myGlobals.isDataLoaded = false;
                    MessageBox.Show("There is no data saved. Please enter stocks and save to access in the future.", "Error");
                    usrExcel.Save();
                    usrExcel.Close();
                    excel.Save();
                    excel.Close();
                    return;
                }
                defineLabels(usrExcel);
            }
            else
            {
                MessageBox.Show("Data Up to Date", "Notice");
            }
            usrExcel.Save();
            excel.Save();
            usrExcel.Close();
            excel.Close();
        }
    }
}
