//CSC370 Team Project Sprint1; Justin J, Derek R, Mike B; 4/7/2020
//Purpose: Create an application which allows the user to input up to 4 separate stocks
//and track the profile's total value. Catch common user input errors and handle 
//accordingly. 
//API Implementation reference: https://github.com/LutsenkoKirill/AlphaVantage.Net
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
        //3 arrays which will keep track of stock names, quantities, and prices
        //throughout the project
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
            try
            { 
                for (int i = 0; i < 4; i++)
                {
                        // retrieve daily time series for given stocks
                        //ultimately storing the current price in 'currPrice' array
                        if (stocks[i] == null)
                        {
                            continue;
                        }
                        StockTimeSeries timeSeries = await client.RequestDailyTimeSeriesAsync(stocks[i],
                            TimeSeriesSize.Compact, adjusted: false);

                        foreach (var dataPoint in timeSeries.DataPoints)
                        {
                            currPrice[i] = (double)(dataPoint.ClosingPrice);
                            //Break used to only acess one data entry or else gets past 100 days
                            break;
                        }
                }
            }
            //Notify user when a stock name was entered incorrectly
            catch (Exception e)
            {
                MessageBox.Show("Please ensure all stock names are entered correctly", "Warning");
            }
        }

        public void defineLabels()
        {
            //if/else statements used to correctly fill the 'totalvalue' labels
            //and catch an 'error' when the user decides to leave text boxes empty
            if (stock1TB.Text != "")
            {
                totalvalue1Label.Text = "$" + (quantities[0] * currPrice[0]);
            }
            else { currPrice[0] = 0; }
            if (stock2TB.Text != "")
            {
                totalvalue2Label.Text = "$" + (quantities[1] * currPrice[1]);
            }
            else { currPrice[1] = 0; }
            if (stock3TB.Text != "")
            {
                totalvalue3Label.Text = "$" + (quantities[2] * currPrice[2]);
            }
            else { currPrice[2] = 0; }
            if (stock4TB.Text != "")
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
                //ensures values exist before assigning to arrays
                //otherwise hardcodes known values which are dealt with throughout the 
                //the program to avoid fatal errors
                if (stock1TB.Text != "" && quantity1TB.Text != "")
                {
                    stocks[0] = (stock1TB.Text);
                    quantities[0] = Convert.ToInt32(quantity1TB.Text);
                } 
                else
                {
                    stocks[0] = null;
                    quantities[0] = 0;
                }

                if (stock2TB.Text != "" && quantity2TB.Text != "")
                {
                    stocks[1] = (stock2TB.Text);
                    quantities[1] = Convert.ToInt32(quantity2TB.Text);
                }
                else
                {
                    stocks[1] = null;
                    quantities[1] = 0;
                }

                if (stock3TB.Text != "" && quantity3TB.Text != "")
                {
                    stocks[2] = (stock3TB.Text);
                    quantities[2] = Convert.ToInt32(quantity3TB.Text);
                }
                else
                {
                    stocks[2] = null;
                    quantities[2] = 0;
                }

                if (stock4TB.Text != "" && quantity4TB.Text != "")
                {
                    stocks[3] = (stock4TB.Text);
                    quantities[3] = Convert.ToInt32(quantity4TB.Text);
                }
                else
                {
                    stocks[3] = null;
                    quantities[3] = 0;
                }
            }
            catch(Exception ex)
            {
                //notifies about user input errors, such as when decimals are entered in the quantity section
                MessageBox.Show("Please double check inputs. Ensure stock" +
                    " symbols are typed correctly and entered stocks have a valid quantitiy.", "Error On Input");
            }

            //ensures there are no negative quantities and notifies user if negatives are discovered.
            for(int i = 0; i<4; i++)
            {
                if(quantities[i]<0)
                {
                    quantities[i] = 0;
                    MessageBox.Show("Quantity must be non-negative.", "Quantity Error");
                }
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
            AlphaVantageStocksDemo();
            defineLabels();
        }
    }
}