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

namespace BackUpDb
{
    public partial class Form2 : Form
    {
        Form3 form3 = new Form3();
        SendEmail mail = null;
        public Form2()
        {
            InitializeComponent();
        }
        private Form1 connectForm = null;       
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
            Backup();
        }

        private void Backup()
        {
            try {
                string databaseName = "theatrodb";
                DateTime backupTime = DateTime.Now;

                int year = backupTime.Year;
                int month = backupTime.Month;

                int day = backupTime.Day;
                int hour = backupTime.Hour;

                int minute = backupTime.Minute;
                int second = backupTime.Second;

                int ms = backupTime.Millisecond;
                String tmestr = backupTime.ToString();

                //change path and name for the backup file 
                tmestr = "C:\\Users\\chris\\" + databaseName + year + "-" + month + "-" + day + "-" + hour + ".sql";

                StreamWriter file = new StreamWriter(tmestr);
                ProcessStartInfo proc = new ProcessStartInfo();

                //change the credentials 
                string cmd = string.Format(@"-h{0} -u{1} -p{2} --opt --databases {3}","yourhost","your_username","your_password","your_database");
                
                //also if your mysqldump path is different from mine change it to
                proc.FileName = "C:\\xampp\\mysql\\bin\\mysqldump";

                proc.RedirectStandardInput = false;
                proc.RedirectStandardOutput = true;

                proc.Arguments = cmd;

                proc.UseShellExecute = false;
                Process p = Process.Start(proc);

                string res;
                res = p.StandardOutput.ReadToEnd();

                file.WriteLine(res);
                p.WaitForExit();
                file.Close();

                MessageBox.Show("Database Backup has been completed successfully!");
                
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
