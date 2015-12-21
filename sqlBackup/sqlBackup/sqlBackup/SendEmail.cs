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


namespace BackUpDb
{
    class SendEmail
    {
        SmtpClient client = new SmtpClient("smtp.mail.yahoo.com", 587);
        private String whereisgoes = null;
        private String response = null;
        public SendEmail(String whereitgoes,String response)
        {
            this.whereisgoes = whereitgoes;
            this.response = response;
        }
        public void PrepareEmail()
        {
            try
            {

                client.Credentials = new NetworkCredential("backupforyou@yahoo.com", "pei3Gizi");
                client.EnableSsl = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void setEmail()
        {
            client.Send("backupforyou@yahoo.com", this.whereisgoes, "About Your Last Back Up Action",this.response);
        }
        
    }
}
    
