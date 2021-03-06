﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace BackUpDb
{
    class Load
    {
        private String hostname;
        private String port;
        private String username;
        private String password;
        StringBuilder stringsave = new StringBuilder();
        public Load(/*String hostname, String port, String username, String password*/)
        {
            //setHostname(hostname, port);
            //setUsername(username);
            //setPassword(password);

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
        TcpClient tcpclnt = new TcpClient();
        public void LoadFromFile()
        {
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.ShowDialog();
                String filename = openfile.FileName;
                StreamReader readfromLoad = new StreamReader(filename);
                ConnectToServer connection = new ConnectToServer();
                //connection.setHostname(readfromLoad.ReadLine(), readfromLoad.ReadLine());
                //connection.setUsername(readfromLoad.ReadLine());
                //connection.setPassword(readfromLoad.ReadLine());
                setHostname(readfromLoad.ReadLine(), readfromLoad.ReadLine());
                setUsername(readfromLoad.ReadLine());
                setPassword(readfromLoad.ReadLine());
                tcpclnt.Connect(this.hostname, Convert.ToInt32(this.port));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Boolean Connected()
        {
            return tcpclnt.Connected;
        }
    }
 }

