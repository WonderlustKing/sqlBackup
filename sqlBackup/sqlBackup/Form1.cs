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
            connectstring = new StringBuilder();
            if ((hostnametextbox.Text != "") && (porttextbox.Text != ""))
            {//prepei na dwsei hostname

                conser.setHostname(hostnametextbox.Text, porttextbox.Text);

            }
            if (usernametextbox.Text != "")
            {//prepei na dwsei username 

                conser.setUsername(usernametextbox.Text);

            }
            if (passwordtextbox.Text != "")
            {// prepei na dwsei pass
                conser.setPassword(passwordtextbox.Text);
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
                else if (save.Saved())
                {
                    savedlabel.Text = "Saved To ->";
                    wheresaved.Text = save.PathToShow();
                }
                else
                    SaveCheckBox.Checked = false;
            }
            
        }
        Load loadfile = new Load();
        //otan o xrhsths thelei na fortosei ena save pou exei kanei
        private void LoadButton_Click(object sender, EventArgs e)
        {

            loadfile.LoadFromFile();
            if (loadfile.Connected())
            {
                Form2 forma2 = new Form2(this);
                forma2.Visible = true;
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
        public string getPort
        {
            get { return porttextbox.Text; }
        }
        public bool getConnection2 {//stelnei sthn forma2 ta stoixeia tou xrhsth otan kanei connect apo to Load
            get { return loadfile.Connected(); }
        }
        public string getHostname2
        {
            get { return loadfile.getHostname(); }
        }
        public string getUsername2
        {
            get { return loadfile.getUsername(); }
        }
        public string getPassword2
        {
            get { return loadfile.getPassword(); }
        }
        public string getPort2
        {
            get { return loadfile.getPort(); }
        }
    }
}