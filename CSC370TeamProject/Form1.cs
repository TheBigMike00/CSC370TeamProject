using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlphaVantage.Net.Stocks;
using AlphaVantage.Net.Stocks.TimeSeries;

namespace CSC370TeamProject
{
    public partial class StockProfile : Form
    {

        /*Test for api working
         * Derek R. Michael B. Justin J. 
         * used Alpha Vantage Api
         * Code from https://github.com/LutsenkoKirill/AlphaVantage.Net
        */

        string[] stocks = new string[4];
        int[] quantities = new int[4];
        double[] currPrice = new double[4]; 

        public StockProfile()
        {
            InitializeComponent();

        }

        public async Task AlphaVantageStocksDemo()
        {
            string apiKey = "S5TJJRN8PSP31YVU"; // enter your API key here

            var client = new AlphaVantageStocksClient(apiKey);
            for (int i = 0; i < 4; i++)
            {
                // retrieve daily time series for stocks of Apple Inc.:
                if(stocks[i] == null)
                {
                    continue;
                }
                StockTimeSeries timeSeries = await client.RequestDailyTimeSeriesAsync(stocks[i].ToString(),
                    TimeSeriesSize.Compact, adjusted: false);

                foreach (var dataPoint in timeSeries.DataPoints)
                {
                    //Console.WriteLine($"{dataPoint.Time}: {dataPoint.ClosingPrice}");
                    currPrice[i] = (double)(dataPoint.ClosingPrice);
                    Console.WriteLine(currPrice[i]);
                    //Break used to only acess one data entry or else gets past 100 days
                    break;
                }
            }
        }

        public void defineLabels()
        {
            if (stock1TB.Text != null)
            {
                totalvalue1Label.Text = "$" + (quantities[0] * currPrice[0]);
            }
            else { currPrice[0] = 0; }
            if (stock2TB.Text != null)
            {
                totalvalue2Label.Text = "$" + (quantities[1] * currPrice[1]);
            }
            else { currPrice[1] = 0; }
            if (stock3TB.Text != null)
            {
                totalvalue3Label.Text = "$" + (quantities[2] * currPrice[2]);
            }
            else { currPrice[2] = 0; }
            if (stock4TB.Text != null)
            {
                totalvalue4Label.Text = "$" + (quantities[3] * currPrice[3]);
            }
            else { currPrice[3] = 0; }
            profiletotalLabel.Text = "Profile Total: $" + getProfileTotal();
        }

        public void fillArrayLists()
        {
            try
            {
                if (stock1TB.Text != null && quantity1TB.Text != null)
                {
                    stocks[0] = (stock1TB.Text);
                    quantities[0] = Convert.ToInt32(quantity1TB.Text);
                }
                if (stock2TB.Text != null && quantity2TB.Text != null)
                {
                    stocks[1] = (stock2TB.Text);
                    quantities[1] = Convert.ToInt32(quantity2TB.Text);
                }
                if (stock3TB.Text != null && quantity3TB.Text != null)
                {
                    stocks[2] = (stock3TB.Text);
                    quantities[2] = Convert.ToInt32(quantity3TB.Text);
                }
                if (stock4TB.Text != null && quantity4TB.Text != null)
                {
                    stocks[3] = (stock4TB.Text);
                    quantities[3] = Convert.ToInt32(quantity4TB.Text);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please double check inputs. Ensure stock" +
                    " symbols are typed correctly and entered stocks have a quantitiy.", "Error On Input");
            }
        }

        public double getProfileTotal()
        {
            double valToReturn = 0;
            for (int i = 0; i < 4; i++)
            {
                valToReturn += (quantities[i] * currPrice[i]);
            }
            return valToReturn;
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            fillArrayLists();
            _ = AlphaVantageStocksDemo();
            defineLabels();
        }
    }
}
