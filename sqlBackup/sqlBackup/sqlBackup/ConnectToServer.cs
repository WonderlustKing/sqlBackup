using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpDb
{
    class ConnectToServer
    {
        StringBuilder connectstring = new StringBuilder();
        private String hostname = null;
        private String databasename = null;
        private String username = null;
        private String password = null;
        private String port = null;
        private Boolean flag = false;
        public void setHostname(String hostname, String port)
        {
            this.hostname = hostname;
            this.port = port;
            connectstring.Append( this.hostname + ":" + this.port + ";");
        }
        public void setUsername(String username)
        {
            this.username = username;
            connectstring.Append( this.username + ";");
        }
        public void setPassword(String password)
        {
            this.password = password;
            connectstring.Append( this.password + ";");
        }
        public Boolean isConnected()
        {
            return flag;
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
            String str = Convert.ToString(connectstring);
            return str;
        }
    }
}
