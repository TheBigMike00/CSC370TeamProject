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

            //checks to see if data was loaded in Form1 
            //yes->load data in this form automatically
            //no->keep data blank until user wished to load it
            dateCreatedLabel.Visible = false;
            dateCreatedTB.Visible = false;
            if (myGlobals.isDataLoaded)
            {
                Excel usrExcel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "UserData.xlsx", 1);
                loadChart();
                defineLabels(usrExcel);
                usrExcel.Save();
                usrExcel.Close();
            }
            
        }

        public void loadChart()
        {
            //create a new general line chart which will be used to map the profile value over time.
            Excel histExcel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "HistoricalProfileValues.xlsx", 1);
            var myChart = historicValChart.ChartAreas[0];
            myChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            myChart.AxisX.LabelStyle.Format = "";
            myChart.AxisY.LabelStyle.Format = "";
            myChart.AxisX.LabelStyle.IsEndLabelVisible = true;

            myChart.AxisX.Title = "Recent Save";
            myChart.AxisY.Title = "Value ($USD)";

            myChart.AxisX.Minimum = 0;
            myChart.AxisY.Minimum = 0;

            double max = 0;
            for (int i = 0; i<myGlobals.historicVals.Count-1; i++)
            {
                if(Convert.ToDouble(myGlobals.historicVals[i]) > max)
                {
                    max = Convert.ToDouble(myGlobals.historicVals[i]);
                }
            }
            historicValChart.Series[0].IsVisibleInLegend = false;
            historicValChart.Series.Add("Value");
            historicValChart.Series["Value"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            double currentV = Convert.ToDouble(myGlobals.historicVals[myGlobals.historicVals.Count - 1]);
            double initialV = Convert.ToDouble(myGlobals.historicVals[0]);
            //Additional feature-> color coded labels
            if (currentV >= initialV)
            {
                historicValChart.Series["Value"].Color = Color.Green;
            }
            else
            {
                historicValChart.Series["Value"].Color = Color.Red;
            }

            if (myGlobals.historicVals.Count >= 5)
            {
                historicValChart.Series["Value"].Points.AddXY(0, myGlobals.historicVals[myGlobals.historicVals.Count-5]);
                historicValChart.Series["Value"].Points.AddXY(1, myGlobals.historicVals[myGlobals.historicVals.Count - 4]);
                historicValChart.Series["Value"].Points.AddXY(2, myGlobals.historicVals[myGlobals.historicVals.Count - 3]);
                historicValChart.Series["Value"].Points.AddXY(3, myGlobals.historicVals[myGlobals.historicVals.Count - 2]);
                historicValChart.Series["Value"].Points.AddXY(4, myGlobals.historicVals[myGlobals.historicVals.Count - 1]);
            }
            else
            {
                for (int i = 0; i < myGlobals.historicVals.Count; i++)
                {
                    historicValChart.Series["Value"].Points.AddXY(i, myGlobals.historicVals[i]);
                }
            }


            histExcel.Save();
            histExcel.Close();
        }

        public void defineLabels(Excel usrExcel)
        {
            //update the outputs of the entire form
            initialInvestmentTB.Text = "$" + Convert.ToString(myGlobals.historicVals[0]);
            double currentV = Convert.ToDouble(myGlobals.historicVals[myGlobals.historicVals.Count - 1]);
            double initialV = Convert.ToDouble(myGlobals.historicVals[0]);
            if(currentV >= initialV)
            {
                currProfileValueLabel.ForeColor = System.Drawing.Color.Green;
                percentChangeLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                currProfileValueLabel.ForeColor = System.Drawing.Color.Red;
                percentChangeLabel.ForeColor = System.Drawing.Color.Red;
            }
            currProfileValueLabel.Text = "$" + Convert.ToString(myGlobals.historicVals[myGlobals.historicVals.Count - 1]);
            percentChangeLabel.Text = String.Format("{0:0.00}", Convert.ToString(((currentV - initialV) / initialV) * 100));
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
            //if statements used to check if current data is already loaded
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
                loadChart();
            }
            else
            {
                MessageBox.Show("Data Up to Date", "Notice");
            }
            myGlobals.isDataLoaded = true;
            usrExcel.Save();
            excel.Save();
            usrExcel.Close();
            excel.Close();
        }

        private void whatIfButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 whatIf = new Form3();
            whatIf.ShowDialog();
            this.Close();
        }
    }
}
