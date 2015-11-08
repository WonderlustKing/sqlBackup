using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace BackUpDb
{
    class Save
    {
        
        private String hostname;
        private String port;
        private String username;
        private String password;
        StringBuilder stringsave = new StringBuilder();
        public Save(String hostname, String port,String username,String password)
        {
            setHostname(hostname, port);
            setUsername(username);
            setPassword(password);
            
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
        override
        public String ToString()
        {   
            return Convert.ToString(stringsave);
        }
        Boolean uparxei = false;//flag an uparxei idi auto to save se arxeio
        StringBuilder folderpath = new StringBuilder();
        public void SaveME()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            String getpath = folder.SelectedPath;
            Console.WriteLine(getpath);
            Boolean flag2 = false;//flag an ola pane kala kai ginei to save
            folderpath.Append(getpath + "/" + getHostname() + ".txt");//onoma tou arxeiou pou tha ginei to save
            StreamWriter writter = null;
            if (File.Exists(Convert.ToString(folderpath)))
            {//elenxo an to arxeio uparxei
                writter = new StreamWriter(Convert.ToString(folderpath)); //antikeimeno gia na grapsw sto arxeio to opio kai ftiaxnw
                writter.WriteLine(getHostname());
                writter.WriteLine(getPort());
                writter.WriteLine(getUsername());
                writter.WriteLine(getPassword());
                writter.Close();
                uparxei = true;
                flag2 = true;
            }
            else
            {
                writter = new StreamWriter(Convert.ToString(folderpath));//antikeimeno gia na grapsw sto arxeio to opio kai ftiaxnw
                writter.WriteLine(getHostname());
                writter.WriteLine(getPort());
                writter.WriteLine(getUsername());
                writter.WriteLine(getPassword());
                writter.Close();
                flag2 = true;
            }
            if (flag2)//an ginoun ola swsta uparxei den euparxei to arxeio emfanizw ena messagebox gia na to gnwrizei o xrhsths
            {              
                MessageBox.Show("ΤΟ αρχείο αποθηκεύτηκε :" + Convert.ToString(folderpath));
            }

        }
        public Boolean Exist()
        {
            return uparxei;
        }
        public String PathToShow()
        {
            return Convert.ToString(folderpath);
        }
    }
}
