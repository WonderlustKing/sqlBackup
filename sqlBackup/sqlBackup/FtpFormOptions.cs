using BackUpDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace sqlBackup
{
    public partial class FtpFormOptions : Form
    {
        private string host;
        private string username;
        private string password;
        private Form2 mainPanel = null;

        public FtpFormOptions()
        {
            InitializeComponent();
        }
        public FtpFormOptions(Form callingForm)
        {
            mainPanel = callingForm as Form2;
            InitializeComponent();
        }
        public FtpFormOptions(Form callingForm, string host, string username,string password)
        {
            mainPanel = callingForm as Form2;
            this.host = host;
            this.username = username;
            this.password = password;
            InitializeComponent();
            tbHost.Text = host;
            tbUsername.Text = username;
            tbPasswd.Text = password;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            host = tbHost.Text;
            username = tbUsername.Text;
            password = tbPasswd.Text;
            this.mainPanel.FTPHost = host;
            this.mainPanel.FTPusername = username;
            this.mainPanel.FTPpasswd = password;
            this.Visible = false;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            host = null;
            username = null;
            password = null;
            this.Visible = false;
        }

        public string getHost
        {
            get { return host; }
        }

        public string getUsername
        {
            get { return username; }
        }
        public string getPassword
        {
            get { return password; }
        }

        private void bTestConn_Click(object sender, EventArgs e)
        {
            if (tbHost.Text != "" && tbUsername.Text != "")
            {
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create("ftp://" + tbHost.Text);

                ftp.Credentials = new NetworkCredential(tbUsername.Text, tbPasswd.Text);
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                try
                {
                    WebResponse response = ftp.GetResponse();
                    MessageBox.Show("Connection test completed success!");

                    //set your flag
                }
                catch (WebException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else MessageBox.Show("Host address and Username fields cant be empty");
        }
    }
}
