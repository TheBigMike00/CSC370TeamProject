using AlphaVantage.Net.Stocks;
using AlphaVantage.Net.Stocks.TimeSeries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC370TeamProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            chart1.Series[0].IsVisibleInLegend = false;
            resultsLabelContext.Visible = false;
            valuePlusMinusLabel.Visible = false;
            percentChangeLabel.Visible = false;
        }

        public async void loadChart()
        {
            var myChart = chart1.ChartAreas[0];
            myChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            myChart.AxisX.LabelStyle.Format = "";
            myChart.AxisY.LabelStyle.Format = "";
            myChart.AxisX.LabelStyle.IsEndLabelVisible = true;

            myChart.AxisX.Title = "Day";
            myChart.AxisY.Title = "Value ($USD)";

            //myChart.AxisX.Minimum = 0;
            //myChart.AxisY.Minimum = 0;


            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series.Clear();
            chart1.Series.Add("Value");
            chart1.Series["Value"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartExists = true;

            double[] stockVal = new double[7];
            string apiKey = "S5TJJRN8PSP31YVU"; // enter your API key here
            var client = new AlphaVantageStocksClient(apiKey);
            try
            {
                // retrieve daily time series for given stocks
                //ultimately storing the current price in 'stockVal' array
                StockTimeSeries timeSeries = await client.RequestDailyTimeSeriesAsync(stockSymbolTB.Text,
                        TimeSeriesSize.Compact, adjusted: false);
                // retrieve daily time series for given stocks
                if (stockSymbolTB.Text != null)
                {
                    int count = 0;
                    foreach (var dataPoint in timeSeries.DataPoints)
                    {
                        if (count < 7)
                        {
                            stockVal[count] = (double)(dataPoint.ClosingPrice);
                        }
                        count++;
                        if (count == 7)
                        {
                            //Break used when array is filled
                            break;
                        }
                    }
                }
                //Notify user when a stock name was entered incorrectly
            }
            catch (Exception e)
            {
                MessageBox.Show("Stock Symbol Entered Incorrectly", "Warning");
            }
        
            for (int i = 0; i < stockVal.Length; i++)
            {
                chart1.Series["Value"].Points.AddXY(i, stockVal[i]);
            }
            

        }

        private void myStocksButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockProfile myStocks = new StockProfile();
            myStocks.ShowDialog();
            this.Close();
        }

        private void myProfileButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 myProfile = new Form2();
            myProfile.ShowDialog();
            this.Close();
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            int quantity;
            double currVal = 0;
            double pastVal = 0;
            if(stockSymbolTB.Text == null || quantityTB.Text == null)
            {
                MessageBox.Show("Please enter both a Stock Symbol and quantity.", "Empty Inputs");
            }
            else if(int.TryParse(quantityTB.Text, out quantity))
            {
                try
                {
                    string apiKey = "S5TJJRN8PSP31YVU"; // enter your API key here
                    var client = new AlphaVantageStocksClient(apiKey);
                    // retrieve daily time series for given stocks
                    //ultimately storing the current price in 'stockVal' array
                    StockTimeSeries timeSeries = await client.RequestDailyTimeSeriesAsync(stockSymbolTB.Text,
                            TimeSeriesSize.Compact, adjusted: false);
                    // retrieve daily time series for given stocks
                    if (stockSymbolTB.Text != null)
                    {
                        int count = 0;
                        foreach (var dataPoint in timeSeries.DataPoints)
                        {
                            if (count == 0)
                            {
                                currVal = (double)(dataPoint.ClosingPrice);
                            }
                            if(count == 90)
                            {
                                pastVal = (double)(dataPoint.ClosingPrice);
                            }
                            count++;
                        }
                    }
                    //Notify user when a stock name was entered incorrectly
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Stock Symbol Entered Incorrectly", "Warning");
                    return;
                }
                loadChart();

                resultsLabelContext.Text = quantity + " Shares of " + stockSymbolTB.Text + " 3 Months Ago";
                valuePlusMinusLabel.Text = "Impact on Portfolio: " + Convert.ToString(currVal - pastVal);
                percentChangeLabel.Text = "Percent Change: " + Convert.ToString(((currVal - pastVal) / pastVal) * 100);

                if (currVal >= pastVal)
                {
                    resultsLabelContext.ForeColor = System.Drawing.Color.Green;
                    valuePlusMinusLabel.ForeColor = System.Drawing.Color.Green;
                    percentChangeLabel.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    resultsLabelContext.ForeColor = System.Drawing.Color.Red;
                    valuePlusMinusLabel.ForeColor = System.Drawing.Color.Red;
                    percentChangeLabel.ForeColor = System.Drawing.Color.Red;
                }
                resultsLabelContext.Visible = true;
                valuePlusMinusLabel.Visible = true;
                percentChangeLabel.Visible = true;
            }
            else
            {
                MessageBox.Show("Please ensure the quantity field is entered as an integer (no decimals).", "Error on Input");
            }
        }
    }
}
