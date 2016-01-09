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
using Microsoft.Win32.TaskScheduler;
using System.Security.Principal;


namespace BackUpDb
{
    public partial class Form2 : Form
    {
        Form3 form3 = null;
        SendEmail mail = null;
        private Form1 connectForm = null;
        private BackupDb backupDB;
        private FtpFormOptions ftpOptions;
        private bool uploadToFTP = false;
        private string ftpHost;
        private string ftpUsername;
        private string ftpPassword;
        private string port;
        private string local_path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\sqlbackup\\";
        private string schedulefile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+ "\\ScheduleFile\\";
        private string schedulerexe = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Scheduler\\bin\\Debug\\Scheduler.exe";
        int counter = 1;

        Save saveschedulefile = null;

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
            this.FormClosing += Form1_FormClosing;
        }
        private void SchedulecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SchedulecheckBox.Checked)
            {

                SetSchedulebutton.Visible = true;
                ScheduleLabel.Enabled = true;
                ScheduleTime.Enabled = true;
                
            } else
            {
                SetSchedulebutton.Visible = false;
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

            
            
                if ((((this.connectForm.getConnection) || (this.connectForm.getConnection2))))
                {
                string path2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\CurrentFile.txt";
                MessageBox.Show(path2);
                string path =(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +@"\sqlBackup\ScheduleFile\");
               StreamWriter write = new StreamWriter(path2);
                write.Write(path);
               write.Close();
                try
                    {
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

                        if (SchedulecheckBox.Checked)
                        {
                            TimeSpan time = ScheduleTime.Value.TimeOfDay;

                            if (this.connectForm.getConnection)
                            {
                                saveschedulefile = new Save(time, this.connectForm.getHostname, this.connectForm.getPort, connectForm.getUsername, connectForm.getPassword, this.FTPHost, this.FTPusername, this.FTPpasswd, emailtextBox.Text, dbForBackup);
                                saveschedulefile.ScheduleFile(schedulefile);
                                ErrorScheduleLabel.Text = "Schedule completed sucessfully";
                            }
                            else if (this.connectForm.getConnection2)
                            {
                                saveschedulefile = new Save(time, this.connectForm.getHostname2, this.connectForm.getPort2, this.connectForm.getUsername2, this.connectForm.getPassword2, this.FTPHost, this.FTPusername, this.FTPpasswd, emailtextBox.Text, dbForBackup);
                                saveschedulefile.ScheduleFile(schedulefile);
                                ErrorScheduleLabel.Text = "Schedule completed sucessfully";

                            }
                        }

                    }
                    catch (Exception x)
                    {
                        ErrorScheduleLabel.Text = "Choose a database first";
                    }

                try
                {

                    //MessageBox.Show(Convert.ToString(IsUserAdministrator()));
                    TimeSpan time = ScheduleTime.Value.TimeOfDay;
                    using (TaskService ts = new TaskService())
                    {
                        TaskDefinition td = ts.NewTask();

                        //δημηουργια ονοματος και description για το schedule
                        td.RegistrationInfo.Description = "This task will backup the database that the user has chosen ";
                        td.Principal.DisplayName = "sqlBckup" + counter;
                        td.Principal.RunLevel = TaskRunLevel.Highest;

                        //δημιουργια triiger ο οποίος θα τρέχει κάθε μέρα
                        DailyTrigger dt = new DailyTrigger();
                        dt.StartBoundary = DateTime.Today + TimeSpan.FromHours(Convert.ToDouble(time.Hours)) + TimeSpan.FromMinutes(Convert.ToDouble(time.Minutes));
                        dt.DaysInterval = 1;
                        dt.Enabled = true;

                        td.Triggers.Add(dt);

                        //προσθεση ρυθμiσeων για το πως θα τρέχει το schedule
                        td.Settings.MultipleInstances = TaskInstancesPolicy.Parallel;
                        td.Settings.ExecutionTimeLimit = TimeSpan.FromHours(23);
                        td.Settings.DisallowStartIfOnBatteries = false;
                        td.Settings.WakeToRun = true;
                        td.Settings.Hidden = true;
                        td.Settings.StartWhenAvailable = true;
                        td.Settings.Priority = ProcessPriorityClass.High;

                        //προσθηκη exe action που δείχνει πιο exe θα τρεχει οταν ερθει η ωρα του schedule
                        td.Actions.Add(new ExecAction(schedulerexe, null, null));

                        //ExecAction et = new ExecAction(schedulerexe, null, null);
                        //td.Actions.Add(et);



                        //δημιουργία του schedule

                        ts.RootFolder.RegisterTaskDefinition("sqlBackup" + counter, td);

                        counter++;

                        ErrorScheduleLabel.Text = "Schedule sucessfull created";
                    }
                }
                catch (Exception exk) {
                    MessageBox.Show(exk.Source);
                    MessageBox.Show(exk.Message);
                    MessageBox.Show(exk.StackTrace);
                }

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
            get { return backupDB.getTime; }
        }
        public string getDate
        {
            get { return backupDB.getDate; }
        }
        public string[] getDBBackedUp
        {
            get { return backupDB.getDbBackedUp; }
        }

        public string FTPHost
        {
            get { return ftpHost; }
            set { ftpHost = value; }
        }

        public string FTPusername
        {
            get { return ftpUsername; }
            set { ftpUsername = value; }
        }
        public string FTPpasswd
        {
            get { return ftpPassword; }
            set { ftpPassword = value; }
        }

        public string getPort
        {
            get { return port; }
            set { port = value; }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(ftpOptions == null)
            {
                ftpOptions = new FtpFormOptions(this);
                ftpOptions.Visible = true;
            }
            else
            {
                ftpOptions = new FtpFormOptions(this,ftpHost,ftpUsername,ftpPassword);
                ftpOptions.Visible = true;
            }
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Console.WriteLine(this.DialogResult);
                if (this.DialogResult == DialogResult.None)
                {
                    
                    Application.Exit();
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if((this.connectForm.getConnection) || (this.connectForm.getConnection2))
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

                // check if upload to ftp is checked and initialize the backupDB object with suitable constructor
                if (cbUploadFtp.Checked)
                {
                    uploadToFTP = true;
                    backupDB = new BackupDb(connectForm.getHostname, connectForm.getUsername, connectForm.getPassword, dbForBackup, local_path, ftpHost, ftpUsername, ftpPassword);
                }
                else
                {
                    uploadToFTP = false;
                    backupDB = new BackupDb(connectForm.getHostname, connectForm.getUsername, connectForm.getPassword, dbForBackup, local_path);
                }
                //check the response of backupdb() method, if true successed, else failed
                response = backupDB.downloadDb();
                MessageBox.Show(response);

                if (response.Equals("Backup completed successfully!"))
                {
                    success = true;
                    
                }

                if(success)
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
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ScheduleTime_ValueChanged(object sender, EventArgs e)
        {

        }
        /*
        public bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            return isAdmin;
        }
        */
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void logFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}
