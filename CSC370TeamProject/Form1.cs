//CSC370 Team Project Sprint1; Justin J, Derek R, Mike B; 4/7/2020
//Purpose: Create an application which allows the user to input up to 4 separate stocks
//and track the profile's total value. Catch common user input errors and handle 
//accordingly. 
//API Implementation reference: https://github.com/LutsenkoKirill/AlphaVantage.Net
//Known Bugs: 1) sometimes there is a delay for the API to retieve the stock prices which 
//              cause some stocks to display correctly and others  to remain at current price
//          2) The try-catch to catch when an invalid stock name is inputed sometimes fires
//              even if all names are valid
//          3) Occasional unexpexted freezes of the app after an extended period of time.
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
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;


namespace CSC370TeamProject
{
    public partial class StockProfile : Form
    {
        Excel excel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "MyData.xlsx", 1);
        Stock[] myStocks = new Stock[4];

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
                // retrieve daily time series for given stocks
                if (myStocks[i].getName() == null)
                {
                    continue;
                }
                StockTimeSeries timeSeries = await client.RequestDailyTimeSeriesAsync(myStocks[i].getName(),
                    TimeSeriesSize.Compact, adjusted: false);

                foreach (var dataPoint in timeSeries.DataPoints)
                {
                    myStocks[i].setCurrentPrice((double)(dataPoint.ClosingPrice));
                    //Break used to only acess one data entry or else gets past 100 days
                    break;
                }
                excel.writeToCell(i + 2, 3, Convert.ToString(myStocks[i].getCurrentPrice()));
            }
            

        }

        public void defineLabels()
        {
            //if/else statements used to correctly fill the 'totalvalue' labels
            //and catch an 'error' when the user decides to leave text boxes empty
            if (stock1TB.Text != "")
            {
                totalvalue1Label.Text = "$" + (myStocks[0].getTotal());
                excel.writeToCell(2, 4, Convert.ToString(myStocks[0].getTotal()));
            }
            if (stock2TB.Text != "")
            {
                totalvalue2Label.Text = "$" + (myStocks[1].getTotal());
                excel.writeToCell(3, 4, Convert.ToString(myStocks[1].getTotal()));
            }
            if (stock3TB.Text != "")
            {
                totalvalue3Label.Text = "$" + (myStocks[2].getTotal());
                excel.writeToCell(4, 4, Convert.ToString(myStocks[2].getTotal()));
            }
            if (stock4TB.Text != "")
            {
                totalvalue4Label.Text = "$" + (myStocks[3].getTotal());
                excel.writeToCell(5, 4, Convert.ToString(myStocks[3].getTotal()));
            }
            profiletotalLabel.Text = "Profile Total: $" + getProfileTotal();
        }

        public void updateWorkingData()
        {
            try
            {
                //ensures values exist before assigning to arrays
                //otherwise hardcodes known values which are dealt with throughout the 
                //the program to avoid fatal errors
                if (stock1TB.Text != "" && quantity1TB.Text != "")
                {
                    excel.writeToCell(2,1, stock1TB.Text);
                    if (Convert.ToInt32(quantity1TB.Text) < 0)
                    {
                        MessageBox.Show("Error on input. Ensure the first stock's quantity is non-negative.", "Error");
                        excel.writeToCell(2, 2, "0");
                    }
                    else
                        excel.writeToCell(2,2, quantity1TB.Text);
                } 
                else
                {
                    excel.writeToCell(2,1, "");
                    excel.writeToCell(2,2, "0");
                }

                if (stock2TB.Text != "" && quantity2TB.Text != "")
                {
                    excel.writeToCell(3,1, stock2TB.Text);
                    if (Convert.ToInt32(quantity2TB.Text) < 0)
                    {
                        MessageBox.Show("Error on input. Ensure the second stock's quantity is non-negative.", "Error");
                        excel.writeToCell(3, 2, "0");
                    }
                    else
                        excel.writeToCell(3,2, quantity2TB.Text);
                }
                else
                {
                    excel.writeToCell(3,1, "");
                    excel.writeToCell(3,2, "0");
                }

                if (stock3TB.Text != "" && quantity3TB.Text != "")
                {
                    excel.writeToCell(4,1, stock3TB.Text);
                    if (Convert.ToInt32(quantity3TB.Text) < 0)
                    {
                        MessageBox.Show("Error on input. Ensure the third stock's quantity is non-negative.", "Error");
                        excel.writeToCell(4, 2, "0");
                    }
                    else
                        excel.writeToCell(4,2, quantity3TB.Text);
                }
                else
                {
                    excel.writeToCell(4,1, "");
                    excel.writeToCell(4,2, "0");
                }

                if (stock4TB.Text != "" && quantity4TB.Text != "")
                {
                    excel.writeToCell(5,1, stock4TB.Text);
                    if (Convert.ToInt32(quantity4TB.Text) < 0)
                    {
                        MessageBox.Show("Error on input. Ensure the fourth stock's quantity is non-negative.", "Error");
                        excel.writeToCell(5, 2, "0");
                    }
                    else
                        excel.writeToCell(5,2, quantity4TB.Text);
                }
                else
                {
                    excel.writeToCell(5,1, "");
                    excel.writeToCell(5,2, "0");
                }
            }
            catch(Exception ex)
            {
                //notifies about user input errors, such as when decimals are entered in the quantity section
                MessageBox.Show("Please double check inputs. Ensure stock" +
                    " symbols are typed correctly and entered stocks have a valid quantitiy.", "Error On Input");
            }

            for (int index = 0; index < 4; index++)
            {
                    myStocks[index] = (new Stock(excel.readCell(index + 2, 1), Convert.ToInt32(excel.readCell(index + 2, 2))));
            }
        }

        public double getProfileTotal()
        {
            double valToReturn = 0;
            for (int i = 2; i < 6; i++)
            {
                valToReturn += Convert.ToDouble(excel.readCell(i, 4));
            }
            return valToReturn;
        }

        public void ClearData()
        {
            for(int x = 2; x<6; x++)
            {
                for(int y = 1; y<5; y++)
                {
                    excel.writeToCell(x, y, "");
                }
            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            ClearData();
            updateWorkingData();
            AlphaVantageStocksDemo();
            defineLabels();
            excel.Close();
        }
    }

    public class Stock
    {
        private string name;
        private int quantity;
        private double currPrice;

        public Stock(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }

        public string getName()
        {
            return name;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public void setCurrentPrice(double price)
        {
            this.currPrice = price;
        }

        public double getCurrentPrice()
        {
            return currPrice;
        }

        public double getTotal()
        {
            return quantity * currPrice;
        }
    }

    public class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public string readCell(int x, int y)
        {
            return Convert.ToString(ws.Cells[x, y].Value2);
        }

        public void writeToCell(int x, int y, string newVal)
        {
            ws.Cells[x, y].Value2 = newVal;
        }

        public void Save()
        {
            wb.Save();
        }

        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }

        public void Close()
        {
            wb.Close();
            excel.Quit();
        }
    }
}