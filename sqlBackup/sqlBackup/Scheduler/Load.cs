using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using sqlBackup;
namespace BackUpDb
{
    class Load
    {

        private String time;
        private String hostname;
        private String port;
        private String username;
        private String password;
        private String ftphostname;
        private String ftpusername;
        private String ftppassword;
        private String email;
        private List<String> dbBackUp = new List<string>();
        private string local_path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\sqlbackup\\";
        private string local_path2 =  Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CurrentFile.txt";
        StringBuilder stringsave = null;

        public Load(/*String hostname, String port, String username, String password*/)
        {

            //setHostname(hostname, port);
            //setUsername(username);
            //setPassword(password);

        }

        //set mathodoi
        public void setTime(String time)
        {
            this.time = time;
        }

        public void setHostname(String hostname, String port)
        {
            this.hostname = hostname;
            this.port = port;
            stringsave.Append(this.hostname + "\n" + this.port + "\n");
        }

        public void setUsername(String username)
        {
            this.username = username;
            stringsave.Append(this.username + "\n");
        }

        public void setPassword(String password)
        {
            this.password = password;
            stringsave.Append(this.password);
        }

        public void setFtpHostname(String ftphostname)
        {
            this.ftphostname = ftphostname;
        }

        public void setFtpusername(String ftpusername)
        {
            this.ftpusername = ftpusername;
        }

        public void setFtppassword(String ftppassworde)
        {
            this.ftppassword = ftppassworde;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public void setbackup(String backname)
        {
            this.dbBackUp.Add(backname);
        }

        //get methodoi

        public String getTime()
        {
            return time;
        }

        public String getHostname()
        {

            return this.hostname;
        }

        public String getPort()
        {

            return this.port;
        }

        public String getUsername()
        {

            return this.username;
        }

        public String getPassword()
        {

            return this.password;
        }

        public String getFtphostname()
        {
            return this.ftphostname;
        }

        public String getFtpusername()
        {
            return this.ftpusername;
        }

        public String getFtppassword()
        {
            return this.ftppassword;
        }

        public String getEmaiil()
        {
            return email;
        }

        public String[] getbackup()
        {
            return this.dbBackUp.ToArray();
        }

        override
        public String ToString()
        {
            return Convert.ToString(stringsave);
        }

        TcpClient tcpclnt = null;
        
        public void LoadFromFile()
        {
            
            try
            {
                StreamReader read = new StreamReader(local_path2);
                string schedulefile = null;
                string setpath = read.ReadLine();
                Directory.SetCurrentDirectory(setpath);
                string schedulefile2 = Directory.GetCurrentDirectory();
                //orismos tou path pou einai to arxeio p tha diabazoume
                string[] dirs = Directory.GetFiles(schedulefile2);
                //trexei gia osa arxeia exei o fakelos
                foreach (string dir in dirs)
                {
                    if (dbBackUp.Any()) {
                        dbBackUp.Clear();
                    }
                    stringsave = new StringBuilder();
                    schedulefile = dir;
                    tcpclnt = new TcpClient();
                    //anoigma tou areiou
                    StreamReader readfromLoad = new StreamReader(schedulefile);
                    ConnectToServer connection = new ConnectToServer();
                    
                    //diabasma apo arxeio
                    setTime(readfromLoad.ReadLine());
                    setHostname(readfromLoad.ReadLine(), readfromLoad.ReadLine());
                    setUsername(readfromLoad.ReadLine());
                    setPassword(readfromLoad.ReadLine());
                    setFtpHostname(readfromLoad.ReadLine());
                    setFtpusername(readfromLoad.ReadLine());
                    setFtppassword(readfromLoad.ReadLine());
                    setEmail(readfromLoad.ReadLine());
                    int i = 0;
                    do{

                        setbackup(readfromLoad.ReadLine());
                        i++;
                    } while (!(readfromLoad.EndOfStream)) ;
                    tcpclnt.Connect(hostname, Convert.ToInt32(port));
                    if (tcpclnt.Connected)
                    {
                        BackupDb back = new BackupDb(getHostname(), getUsername(), getPassword(), getbackup(), @local_path, getFtphostname(), getFtpusername(), getFtppassword());
                        back.downloadDb();
                        tcpclnt.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.Source);
                Application.Exit();
            }
        }
        public Boolean Connected()
        {
            return tcpclnt.Connected;
        }
    }
}

