using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using MailKit.Net.Imap;

namespace Lab5_LTM
{
    public partial class BAI3 : Form
    {
        public static string user = "";
        public static string password = "";
        public BAI3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            user = tbEmail.Text.Trim();
            password = tbPassword.Text.Trim();
            var emailClient = new ImapClient();
            try
            {
                emailClient.Connect("127.0.0.1", 143, 0);
                emailClient.Authenticate(BAI3.user, BAI3.password);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Main3 main = new Main3();
            main.Show();
            this.Close();
            
           
           
        }
     
    }
}
