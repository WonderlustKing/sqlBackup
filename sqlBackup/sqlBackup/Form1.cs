using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace BackUpDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        StringBuilder connectstring;
        ConnectToServer conser = new ConnectToServer();
        TcpClient tcpclnt = new TcpClient();
        private void connectButton_Click(object sender, EventArgs e)
        { 
            
            {
                connectstring = new StringBuilder();
                if (hostnametextbox.Text != "")
                {//prepei na dwsei hostname
                    conser.setHostname(hostnametextbox.Text, porttextbox.Text);
                }
                else
                {
                    MessageBox.Show("Insert Hostname to Continue");//msgbox an den dwsei host
                }
                if (usernametextbox.Text != "")
                {//prepei na dwsei username 
                    conser.setUsername(usernametextbox.Text);
                }
                else
                {
                    MessageBox.Show("Insert username to Continue");//msgbox an den dwsei username
                }
                if (passwordtextbox.Text != "")
                {// prepei na dwsei pass
                    conser.setPassword(passwordtextbox.Text);
                }
                else
                {
                    MessageBox.Show("Insert password to Continue");//msgbox an den dwsei pass
                }
                     
            }
            tcpclnt.Connect(conser.getHostname(),Convert.ToInt32(conser.getPort()));
            if (tcpclnt.Connected) {
                Form2 forma2 = new Form2();
                this.Visible = false;
                forma2.Visible = true;
            }
            else
            {
                porttextbox.Text = "3306";
                hostnametextbox.Text = null;
                porttextbox.Text = null;
                usernametextbox.Text = null;
                passwordtextbox.Text = null;
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            
        Application.Exit();
        }

        private void SaveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
            if (SaveCheckBox.Checked)
            {               
                Save save = new Save(hostnametextbox.Text, porttextbox.Text, usernametextbox.Text, passwordtextbox.Text);
                save.SaveME();
                if (save.Exist())
                {
                    savedlabel.Text = "Already Exist";
                    wheresaved.Text = save.PathToShow();
                }
                else
                {
                    savedlabel.Text = "Saved To ->";
                    wheresaved.Text = save.PathToShow();
                }              
            }
            else
            {
                SaveCheckBox.Checked = false;
            }
        }
    }
}