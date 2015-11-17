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

namespace BackUpDb
{
    public partial class Form2 : Form
    {
        Form3 form3 = new Form3();
        SendEmail mail = null;
        private Form1 connectForm = null;
        private DownloadDb downloadDB;
        public Form2()
        {
            InitializeComponent();
        }
            
        public Form2(Form callingForm)
        {
            connectForm = callingForm as Form1;
            // change the databaseName with yours
            downloadDB = new DownloadDb(connectForm.getHostname,connectForm.getUsername,connectForm.getPassword,"databaseName");
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
                if (this.connectForm.getConnection)//elexnos an einai sundedemenos me to server prepei na mpei pantou sxedon
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
            if (this.connectForm.getConnection)
            {
                form3.Visible = true;
               // mail = new SendEmail(emailtextBox.Text);
               // mail.PrepareEmail();
               // mail.setEmail();
            }
        }

        private void Form2_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (this.connectForm.getConnection)//elexnos an einai sundedemenos me to server prepei na mpei pantou sxedon
            {

            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void getBackuplinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //check the response of backupdb() method, if true successed, else failed
            Boolean flag = downloadDB.backupdb();
            if (flag) MessageBox.Show("Backup has successfully completed!");
            else MessageBox.Show("An error has occured, backup failed");
        }

       
    }
}
