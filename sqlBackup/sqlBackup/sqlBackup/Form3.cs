using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackUpDb
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private Form2 connectform2 = null;
        public Form3(Form2 callingForm2)
        {
            connectform2 = callingForm2 as Form2;
            InitializeComponent();
        }
        Boolean flag = false;
        private void Form3_Load(object sender, EventArgs e)
        {
            int lenght = connectform2.getDBBackedUp.Length;
            StringBuilder databases = new StringBuilder();
            for(int i = 0; i < lenght; i++)
            {
                if (i == lenght - 1)
                {
                    if ((i % 2 == 0) && (i != 0))
                    {
                        flag = true;
                        databases.Append( "\n" + "                        " + connectform2.getDBBackedUp[i]);
                    }
                    else
                    {
                        if (flag)
                        {
                            databases.Append(connectform2.getDBBackedUp[i]);
                        }
                        else
                        {
                            databases.Append(connectform2.getDBBackedUp[i]);
                        }
                    }
                }   
                else
                {
                    if ((i % 2 == 0) && (i != 0))
                    {
                        flag = true;
                        databases.Append( "\n" + "                        " + connectform2.getDBBackedUp[i] +",");
                    }
                    else
                    {
                        if (flag)
                        {
                            databases.Append(connectform2.getDBBackedUp[i]);
                        }
                        else
                        {
                            databases.Append(connectform2.getDBBackedUp[i]+",");
                        }
                    }
                }                
            }
            if (connectform2.getConnection)
            {
                
                label1.Text = "Hostname: " + connectform2.getHostname + "\n" +
                              "Username: "  +connectform2.getUsername + "\n" +
                             "DataBase(s): "+Convert.ToString(databases) + "\n" + "Day: " + connectform2.getDate + "\n" + "Time: " + connectform2.getTime;
            }
            else
            {
                label1.Text = "Hostname: " + connectform2.getHostname2 + "\n" +
                              "Username: " + connectform2.getUsername2 + "\n" +
                             "DataBase(s): " + Convert.ToString(databases) + "\n" + "Day: "+connectform2.getDate + "\n" + "Time: " + connectform2.getTime;
            }
            
        }
    }
}
