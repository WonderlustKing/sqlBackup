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
            }
            try
            {
                tcpclnt.Connect(conser.getHostname(), Convert.ToInt32(conser.getPort()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (tcpclnt.Connected) {
                Form2 forma2 = new Form2(this);
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
        //gia to Save otan to remember me einai pathmeno
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
        //otan o xrhsths thelei na fortosei ena save pou exei kanei
        private void LoadButton_Click(object sender, EventArgs e)
        {
            Load loadfile = new Load();
            loadfile.LoadFromFile();
            if (loadfile.Connected())
            {
                this.Visible = false;
            }
         }
        public bool getConnection//stelnei sthn forma 2 an to connection me ton server exei ginei
        {
            get { return tcpclnt.Connected; }
        }
        public string getHostname
        {
            get { return hostnametextbox.Text; }
        }
        public string getUsername
        {
            get { return usernametextbox.Text; }
        }
        public string getPassword
        {
            get { return passwordtextbox.Text; }
        }
        
    }
}