//CSC370 Team Project Final Sprint; Justin J, Derek R, Mike B; 5/12/2020
//Purpose: Create an application which allows the user to input up to 4 separate stocks
//and track the profile's total value. Catch common user input errors and handle 
//accordingly. Allow option to save/open stock history.
//Known Bugs: 1) The application will sometimes throw an error on input due to an API restriction where the user can only
//                 make up to 5 retrieval calls at a time.
//
//Sprint 5 Specs Completed: 
//      1.) - implement the “what if” option that allows the client to track stocks not in the portfolio 
//              - see the entirety of form3
//      2.) consider security for the app
//              - a general design of user authentification has been created if the client 
//                  so desires to have it implimented. (Not currently implemented in code -> Form4 design
//              - additionally, the internal excel sheets are marked as read-only to prevent as many 
//                  external conflicts as possible
//      3.) consider maintenance for the app
//              - Code is commented through its entirety with meaningful comments
//              - known bugs are listed in the comments above
//      4.) consider an additional feature/function (the team will specify a realistic option)
//              - a chart is created in the 'What If?' page which shows the selected stock's "Week at a Glance"
//              - 'My Profile' & 'What If?' both include a Percent change of their respective fields
//              - Certain labels found in form2 & form3 will change color based upon whether they have gained/lost money
//              - Both of the above features are those which are not listed as official specifications.


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
using ServiceStack;
using ServiceStack.Text;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace CSC370TeamProject
{
    public partial class StockProfile : Form
    {
        //Global array of stocks allows for easier access to stock information throghout the program.
        Stock[] myStocks = new Stock[4];
        public StockProfile()
        {
            InitializeComponent();
            if (myGlobals.isDataLoaded != true)
                myGlobals.isDataLoaded = false;
            if(myGlobals.isDataLoaded)
            {
                loadSavedStocksToolStripMenuItem.PerformClick();
            }

        }

        public void AlphaVantageStocksDemo(Excel excel)
        {
            int stockNum = 0;
            try
            {
                string apiKey = "S5TJJRN8PSP31YVU"; // enter your API key here
                for (int i = 0; i < 4; i++)
                {
                    if (myStocks[i].getName() == null)
                        continue;

                    //accesses the value of the stock with appreviation 'symbol' 
                    stockNum++;
                    var symbol = myStocks[i].getName().ToUpper();
                    var dailyPrices = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={apiKey}&datatype=csv"
                                        .GetStringFromUrl().FromCsv<List<AlphaVantageData>>();
                    dailyPrices.PrintDump();
                    
                    //grabs the min and max values of the stock for a given day and produces the average
                    //which is used thoughout the program.
                    var maxPrice = dailyPrices.Max(u => u.Close);
                    var minPrice = dailyPrices.Min(u => u.Close);
                    double average = Math.Round((double)((maxPrice + minPrice) / 2), 2);
                    myStocks[i].setCurrentPrice(average);
                    excel.writeToCell(i + 2, 3, Convert.ToString(myStocks[i].getCurrentPrice()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on input for stock number " + stockNum + ", ensure all stocks symbols are entered correctly\n\nNote: " +
                    "this error may also be caused by an internal timing restriction. Please wait approximately 60 seconds and attempt to " +
                    "add stocks again. Sorry for the annoyance.", "Error");
            }
            if (myStocks[0].getName() == null && myStocks[1].getName() == null && myStocks[2].getName() == null && myStocks[3].getName() == null)
            {
                MessageBox.Show("No stocks were entered. Please enter a stock and its quantity.", "No Inputs");
            }
        }

        public void defineLabels(Excel excel)
        {
            //if/else statements used to correctly fill the 'totalvalue' labels
            //and catch an 'error' when the user decides to leave text boxes empty
            if (stock1TB.Text != "")
            {
                totalvalue1Label.Text = "$" + String.Format("{0:0.00}", (myStocks[0].getTotal()));
                currentvalue1Label.Text = "$" + String.Format("{0:0.00}", (myStocks[0].getCurrentPrice()));
                excel.writeToCell(2, 4, String.Format("{0:0.00}", Convert.ToString(myStocks[0].getTotal())));
            }
            if (stock2TB.Text != "")
            {
                totalvalue2Label.Text = "$" + String.Format("{0:0.00}", (myStocks[1].getTotal()));
                currentvalue2Label.Text = "$" + String.Format("{0:0.00}", (myStocks[1].getCurrentPrice()));
                excel.writeToCell(3, 4, String.Format("{0:0.00}", Convert.ToString(myStocks[1].getTotal())));
            }
            if (stock3TB.Text != "")
            {
                totalvalue3Label.Text = "$" + String.Format("{0:0.00}", (myStocks[2].getTotal()));
                currentvalue3Label.Text = "$" + String.Format("{0:0.00}", (myStocks[2].getCurrentPrice()));
                excel.writeToCell(4, 4, String.Format("{0:0.00}", Convert.ToString(myStocks[2].getTotal())));
            }
            if (stock4TB.Text != "")
            {
                totalvalue4Label.Text = "$" + String.Format("{0:0.00}", (myStocks[3].getTotal()));
                currentvalue4Label.Text = "$" + String.Format("{0:0.00}", (myStocks[3].getCurrentPrice()));
                excel.writeToCell(5, 4, String.Format("{0:0.00}", Convert.ToString(myStocks[3].getTotal())));
            }
            profiletotalLabel.Text = "Profile Total: $" + String.Format("{0:0.00}", getProfileTotal(excel));
        }

        public void updateWorkingData(Excel excel)
        {
            try
            {
                //ensures values exist before assigning to stock array and excel sheet.
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
                    excel.writeToCell(2, 1, "");
                    excel.writeToCell(2, 2, "");
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
                    excel.writeToCell(3,2, "");
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
                    excel.writeToCell(4,2, "");
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
                    excel.writeToCell(5,2, "");
                }
            }
            catch(Exception ex)
            {
                //notifies about user input errors, such as when decimals are entered in the quantity section
                MessageBox.Show("All stock quantities must be integers. (No decimals)", "Error On Input");
            }

            for (int index = 0; index < 4; index++)
            {
                    myStocks[index] = (new Stock(excel.readCell(index + 2, 1), Convert.ToInt32(excel.readCell(index + 2, 2))));
            }
        }

        public double getProfileTotal(Excel excel)
        {
            //provides convenient access to the profile total throughout the program
            double valToReturn = 0;
            for (int i = 2; i < 6; i++)
            {
                valToReturn += Convert.ToDouble(excel.readCell(i, 4));
            }
            return valToReturn;
        }

        public void ClearData(Excel excel)
        {
            //gives us ability to essentially 'reset' the internal excel sheet. 
            for (int x = 2; x<6; x++)
            {
                for(int y = 1; y<5; y++)
                {
                    excel.writeToCell(x, y, "");
                }
            }
        }

        public void transferDataToUser(Excel usrExcel, Excel excel)
        {
            //This is where the main benefit of the internal excel sheet comes in. The method
            //looks in an excel sheet to find the next empty set of cells and copies the current 
            //internal excel sheet to the provided tree. This method aids in saving the current portfolio 
            //in a user excel.
            int counter = 1;
            while (usrExcel.readCell(counter, 1) != null)
                counter += 10;
            

            usrExcel.writeToCell(counter, 1, DateTime.Now.ToString());
            for(int i = 1 + counter; i< 6 + counter; i++)
            {
                    for (int k = 1; k < 5; k++)
                    {
                        usrExcel.writeToCell(i, k, excel.readCell(i-(counter), k));
                    }
            }
            usrExcel.writeToCell(counter + 7, 1, "Total Portfolio: ");
            usrExcel.writeToCell(counter + 7, 2, Convert.ToString(getProfileTotal(excel)));
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            Excel excel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "MyData.xlsx", 1);
            ClearData(excel);
            updateWorkingData(excel);
            AlphaVantageStocksDemo(excel);
            defineLabels(excel);
            excel.Save();
            excel.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //saves data to the user's historical excel sheet 
            Excel usrExcel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "UserData.xlsx", 1);
            Excel excel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "MyData.xlsx", 1);
            transferDataToUser(usrExcel, excel);
            usrExcel.Save();
            usrExcel.Close();
            excel.Save();
            excel.Close();
            myGlobals.isDataLoaded = true;
            MessageBox.Show("Profile Saved Successfully", "Success");

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + "UserData.xlsx");
            if (fi.Exists)
            {
                //                                                   
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + "UserData.xlsx");
            }
            else
            {
                MessageBox.Show("Unable to locate file", "Error Locating File");
            }
        }

        public void recordHistoricalVals()
        {
            //Both the user excel and historcal data excel sheets are needed to transfer the data
            Excel usrExcel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "UserData.xlsx", 1);
            Excel histExcel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "HistoricalProfileValues.xlsx", 1);
            myGlobals.historicVals = new ArrayList();
            myGlobals.historicTimestamps = new ArrayList();
            myGlobals.historicVals.Clear();
            myGlobals.historicTimestamps.Clear();
            //track used to navigate the horizontal variable of the excels
            //counter used to navigate from save to save
            int track = 2;
            int counter = 1;
            while (usrExcel.readCell(counter, 1) != null)
            {
                counter += 10;
                if (usrExcel.readCell(counter + 7, 2) != null)
                {
                    myGlobals.historicVals.Add(usrExcel.readCell(counter + 7, 2));
                    histExcel.writeToCell(track, 1, Convert.ToString(track-2));
                    histExcel.writeToCell(track, 2, usrExcel.readCell(counter + 7, 2));
                    track++;
                }
            }
            usrExcel.Close();
            histExcel.Save();
            histExcel.Close();
        }

        private void myProfileButton_Click(object sender, EventArgs e)
        {
            Excel excel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "MyData.xlsx", 1);
            recordHistoricalVals();
            excel.Save();
            excel.Close();
            this.Hide();
            Form2 myProfile = new Form2();
            myProfile.ShowDialog();
            this.Close();
        }

        private void loadSavedStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //goal is to grab the last save from user excel and dump data into internal working data 
            Excel usrExcel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "UserData.xlsx", 1);
            Excel excel = new Excel(System.AppDomain.CurrentDomain.BaseDirectory + "MyData.xlsx", 1);
            //navigates to most recent save
            int counter = 1;
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
            for (int i = 2 + counter; i < 6 + counter; i++)
            {
                for (int k = 1; k < 5; k++)
                {
                    excel.writeToCell(i - (counter), k, usrExcel.readCell(i, k));
                }
            }
            //now that the data is fetched the output must be displayed
            stock1TB.Text = excel.readCell(2, 1);
            stock2TB.Text = excel.readCell(3, 1);
            stock3TB.Text = excel.readCell(4, 1);
            stock4TB.Text = excel.readCell(5, 1);
            quantity1TB.Text = excel.readCell(2, 2);
            quantity2TB.Text = excel.readCell(3, 2);
            quantity3TB.Text = excel.readCell(4, 2);
            quantity4TB.Text = excel.readCell(5, 2);


            usrExcel.Save();
            usrExcel.Close();
            ClearData(excel);
            updateWorkingData(excel);
            AlphaVantageStocksDemo(excel);
            defineLabels(excel);
            excel.Save();
            excel.Close();
            myGlobals.isDataLoaded = true;
        }

        private void whatIfButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 whatIf = new Form3();
            whatIf.ShowDialog();
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Inputs:\nTo save stocks to your profile, enter valid stock symbols in the 'Stock' " +
                "field and its corresponding quantity in the 'Quantity' field.\nThe 'File' Menu has three (3) options which are " +
                "as follows:\n'Save': Saves the current portfolio's data\n'Load Saved Data': Loads the most recent save of the portfolio" +
                "\n'Open Excel': Opens all previous saves as an Excel file.\nUse the 'My Profile' and 'What If?' buttons" +
                " to navigate to other features of the application.\n\nOutputs:\nThe application will automatically " +
                "fetch the stocks' prices and calcuate the portfolio total in real time.\n\nNote: The applicaiton" +
                " is only capable of fetctching five (5) stock prices per minute- globally.", "Help");
        }
    }

    public class AlphaVantageData
    {
        //getters and setters for easy future access
        public DateTime Timestamp { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
    }

    public class Stock
    {
        //stock class allows for creation of stock objects for easy access to 
        //various information about the stocks.
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
        //class which allows for the creation and management of excel files
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

        public Excel()
        {

        }

        public string readCell(int x, int y)
        {
            return Convert.ToString(ws.Cells[x, y].Value2);
        }

        public void writeToCell(int x, int y, string newVal)
        {
            ws.Cells[x, y].Value2 = newVal;
        }

        public void CreateNewFile()
        {
            this.wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            this.ws = wb.Worksheets[1];
        }

        public void CreateNewSheet()
        {
            Worksheet tempSheet = wb.Worksheets.Add(After: ws);
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
public static class myGlobals
{
    public static ArrayList historicVals;
    public static ArrayList historicTimestamps;
    public static bool isDataLoaded;
}
