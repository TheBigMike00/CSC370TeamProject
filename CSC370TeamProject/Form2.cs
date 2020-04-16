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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(myGlobals.usrFilePath != null)
            {
                usrFileNameTB.Text = myGlobals.usrFilePath;
            }
        }

        private void form2_saveButton_Click(object sender, EventArgs e)
        {
            myGlobals.usrFilePath = usrFileNameTB.Text;
            this.Close();
        }
    }
}
