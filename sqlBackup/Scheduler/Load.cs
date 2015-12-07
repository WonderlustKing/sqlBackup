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
        private String ftpusername;
        //SendEmail mail = null;
        private String email;
        private String ftppassword;
        private String ftphostname;
        private List<String> dbBackUp = new List<string>();
        StringBuilder stringsave = null;
        public Load(/*String hostname, String port, String username, String password*/)
        {
            
            //setHostname(hostname, port);
            //setUsername(username);
            //setPassword(password);

        }
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
        public String getFtpusername()
        {
            return this.ftpusername;
        }
        public String getFtppassworde()
        {
            return this.ftppassword;
        }
        public String getFtphostname()
        {
            return this.ftphostname;
        }
        public String getEmaiil()
        {
            return email;
        }
        public void setbackup(String backname)
        {
            this.dbBackUp.Add(backname);
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
                
                string schedulefile = null;
                string[] dirs = Directory.GetFiles(@"C:\\Users\\Bill\\Documents\\GitHubVisualStudio\\sqlBackup\\sqlBackup\\sqlBackup\\ScheduleFile\\");
                foreach (string dir in dirs)
                {
                    stringsave = new StringBuilder();
                    string[] pin = getbackup();
                    for (int k = 0; k < pin.Length; k++){
                        Console.WriteLine(pin[k].ToString());
                    }

                    schedulefile = dir;
                    tcpclnt = new TcpClient();
                    StreamReader readfromLoad = new StreamReader(schedulefile);
                    ConnectToServer connection = new ConnectToServer();
                    //connection.setHostname(readfromLoad.ReadLine(), readfromLoad.ReadLine());
                    //connection.setUsername(readfromLoad.ReadLine());
                    //connection.setPassword(readfromLoad.ReadLine());
                    setTime(readfromLoad.ReadLine());
                    
                    
                    setHostname(readfromLoad.ReadLine(), readfromLoad.ReadLine());
                    
                    setUsername(readfromLoad.ReadLine());
                    
                    setPassword(readfromLoad.ReadLine());
                    setFtpHostname(readfromLoad.ReadLine());
                    setFtpusername(readfromLoad.ReadLine());
                    setFtppassword(readfromLoad.ReadLine());
                    setEmail(readfromLoad.ReadLine());
                    int i = 0;
                    {

                        setbackup(readfromLoad.ReadLine());
                        i++;

                    } while (!(readfromLoad.EndOfStream));

                    for (int k = 0; k < pin.Length; k++)
                    {
                        Console.WriteLine(pin[k].ToString());
                    }

                    tcpclnt.Connect(hostname, Convert.ToInt32(port));
                    if (tcpclnt.Connected)
                    {
                        BackupDb back = new BackupDb(getHostname(),getUsername(),getPassword(),getbackup(), @"C:\Users\Bill\AppData\Roaming\sqlbackup\", getFtphostname(),getFtpusername(),getFtppassworde());
                        back.downloadDb();
                        tcpclnt.Close();

                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public Boolean Connected()
        {
            return tcpclnt.Connected;
        }
    }
 }

