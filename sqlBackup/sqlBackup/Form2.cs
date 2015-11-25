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
using System.Net.Sockets;
using System.Net.Mail;
using System.IO;
using System.Diagnostics;
using sqlBackup;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace BackUpDb
{
    public partial class Form2 : Form
    {
        Form3 form3 = null;
        SendEmail mail = null;
        private Form1 connectForm = null;
        private DownloadDb downloadDB;
        private string local_path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\sqlbackup\\";
        public Form2()
        {
            InitializeComponent();
        }
        Boolean success = false;
        String response = null;
        public Form2(Form callingForm)
        {
            connectForm = callingForm as Form1;
            InitializeComponent();
        }
        private void SchedulecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SchedulecheckBox.Checked)
            {
                ScheduleLabel.Enabled = true;
                ScheduleTime.Enabled = true;
                
            } else
            {
                ScheduleLabel.Enabled = false;
                ScheduleTime.Enabled = false;
            }
        }

        private void emailnotcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (emailnotcheckBox.Checked)
            {
                if ((this.connectForm.getConnection) || (this.connectForm.getConnection2))//elexnos an einai sundedemenos me to server prepei na mpei pantou sxedon
                {
                   
                        emailLabel.Enabled = true;
                        emailtextBox.Enabled = true;
                        
                }
            } else
            {
                emailLabel.Enabled = false;
                emailtextBox.Enabled = false;
            }
        }

        private void Runbutton_Click(object sender, EventArgs e)
        {
            if ((((this.connectForm.getConnection) || (this.connectForm.getConnection2))) && (success))
            {
                if (emailnotcheckBox.Checked)
                {
                    mail = new SendEmail(emailtextBox.Text,response);
                    mail.PrepareEmail();
                    mail.setEmail();
                    
                }
                form3 = new Form3(this);
                form3.Visible = true;
            }
        }

        private void Form2_Click(object sender, EventArgs e)
        {
           
            
        }


        private void Form2_Load(object sender, EventArgs e)
        {

            if ((this.connectForm.getConnection)||(this.connectForm.getConnection2))
            {
                tbLocalDest.Text = local_path;
                String conn = null;
                DataTable dt = new DataTable();
                // Connection string me ta pedia pou edwse o xrhsths 
                if ((this.connectForm.getConnection))
                {
                     conn = "server=" + connectForm.getHostname +
                        ";user=" + connectForm.getUsername + ";pwd=" + connectForm.getPassword + ";";
                }
                else if((this.connectForm.getConnection2))
                {
                    conn = "server=" + connectForm.getHostname2 +
                       ";user=" + connectForm.getUsername2 + ";pwd=" + connectForm.getPassword2 + ";";
                }
                try
                {

                    MySqlConnection mysqlconn = new MySqlConnection(conn);
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = mysqlconn;
                    mysqlconn.Open();
                    // query gia na emfanisei ths baseis
                    cmd.CommandText = "show databases;";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                DatabasesCheckedListBox.Visible = true;
                foreach (DataRow row in dt.Rows)
                {
                    DatabasesCheckedListBox.Items.Add(row[0]);
                }
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void getBackuplinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MessageBox.Show(local_path.ToString());
            
            // get number of selected databases from checklistBox
            int selectedDbNum = DatabasesCheckedListBox.CheckedItems.Count;

            //array with selected databases number length, for store all selected databases
            string[] dbForBackup = new string[selectedDbNum];
            //get names of selected databases
            int i = 0;
            foreach (object itemChecked in DatabasesCheckedListBox.CheckedItems)
            {
                dbForBackup[i] = itemChecked.ToString();
                i++;
            }
           
            // change the databaseName with yours
            downloadDB = new DownloadDb(connectForm.getHostname, connectForm.getUsername, connectForm.getPassword, dbForBackup, local_path);
            
            //check the response of backupdb() method, if true successed, else failed
            response = downloadDB.backupdb();
            MessageBox.Show(response);
            
            if (response.Equals("Backup completed successfully!"))
            {
                success = true;
                Console.WriteLine(success);
            }            
        }

        public string LocalPath
        {
            get { return local_path; }
            set { local_path = value; }
        }

        private void bChangeLocalDest_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderChoose = new FolderBrowserDialog();
            DialogResult result = folderChoose.ShowDialog();
            if(result == DialogResult.OK)
            {
                local_path = folderChoose.SelectedPath;
                tbLocalDest.Text = folderChoose.SelectedPath;
            }
        }
        public bool getConnection//stelnei sthn forma 2 an to connection me ton server exei ginei
        {
            get { return connectForm.getConnection; }
        }
        public string getHostname
        {
            get { return connectForm.getHostname; }
        }
        public string getUsername
        {
            get { return connectForm.getUsername; }
        }
        public string getPassword
        {
            get { return connectForm.getPassword; }
        }
        public bool getConnection2
        {//stelnei sthn forma2 ta stoixeia tou xrhsth otan kanei connect apo to Load
            get { return connectForm.getConnection2; }
        }
        public string getHostname2
        {
            get { return connectForm.getHostname2; }
        }
        public string getUsername2
        {
            get { return connectForm.getUsername2; }
        }
        public string getPassword2
        {
            get { return connectForm.getPassword2; }
        }
        //gia tis baseis kai einai geniko 
        public string getTime
        {
            get { return downloadDB.getTime; }
        }
        public string getDate
        {
            get { return downloadDB.getDate; }
        }
        public string[] getDBBackedUp
        {
            get { return downloadDB.getDbBackedUp; }
        }
    }
}
