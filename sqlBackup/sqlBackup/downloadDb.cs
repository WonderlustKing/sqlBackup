using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace sqlBackup
{
    class DownloadDb
    {
        private string hostname;
        private string username;
        private string password;
        private string[] dbname;
        private int numsOfDatabases;
        // mysqldump.exe path
        private string mysqldump = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName+"\\mysqldump";
        // user application path for sqlbackup(where everything will be saved here)
        private string user_path;

        public DownloadDb()
        {

        }
        public DownloadDb(string hostname,string username,string password, string[] dbname, string user_path)
        {
            this.hostname = hostname;
            this.password = password;
            this.username = username;
            this.dbname = dbname;
            this.user_path = user_path;
            numsOfDatabases = dbname.Length;
        }

        // backup a database
        public string backupdb()
        {
            if (numsOfDatabases > 0)
            {
                try
                {
                    System.
                    // DateTime object to take the date that backup has been complete
                    DateTime backupTime = DateTime.Now;

                    int year = backupTime.Year;
                    int month = backupTime.Month;

                    int day = backupTime.Day;
                    int hour = backupTime.Hour;

                    int minute = backupTime.Minute;
                    int second = backupTime.Second;

                    int ms = backupTime.Millisecond;
                    String tmestr = backupTime.ToString();

                    // check if sqlBackup directory exist in user application path, if not create it
                    System.IO.FileInfo check_app_path = new System.IO.FileInfo(user_path);
                    check_app_path.Directory.Create();

                    // name of subfolder for this backup
                    string backup_subfolder = user_path + "\\" + "SqlBackup_" + day + "-" + month + "-" + year + "-" + hour + "_" + minute + "\\";

                    // check if subfolder directory exists, if not create it
                    System.IO.FileInfo create_subfolder = new System.IO.FileInfo(backup_subfolder);
                    create_subfolder.Directory.Create();

                    //get each selected database backup 
                    for (int i = 0; i < numsOfDatabases; i++)
                    {
                        // directory of backup(database) file
                        tmestr = backup_subfolder + dbname[i] + ".sql";

                        StreamWriter file = new StreamWriter(tmestr);
                        // start a new proc
                        ProcessStartInfo proc = new ProcessStartInfo();

                        // arguments for the proc, arguments for backup the database
                        string cmd = string.Format(@"-h{0} -u{1} -p{2} --opt --databases {3}", hostname, username, password, dbname[i]);

                        // set the mysqldump path as the proc filename, need for the success complete of below arguments  
                        proc.FileName = mysqldump;

                        proc.RedirectStandardInput = false;
                        proc.RedirectStandardOutput = true;

                        proc.Arguments = cmd;

                        proc.UseShellExecute = false;
                        Process p = Process.Start(proc);

                        string res;
                        // read the output of proc
                        res = p.StandardOutput.ReadToEnd();

                        // write the output in file 
                        file.WriteLine(res);
                        p.WaitForExit();
                        file.Close();
                    }


                    return "Backup completed successfully!";

                }
                catch (IOException e)
                {
                    return "Backup failed, an IO error has occured";
                }
            }
            else return "Please first select database(s) for backup";
        }

        public string getPath()
        {
            return mysqldump;
        }
    
    }
    
}
