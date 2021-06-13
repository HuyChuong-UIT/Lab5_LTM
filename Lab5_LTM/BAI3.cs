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
using MailKit;

namespace Lab5_LTM
{
    public partial class BAI3 : Form
    {
        private string user = "";
        private string password = "";
        public BAI3()
        {
            InitializeComponent();
            listView1.Visible = false;
            gBNewMessage.Visible = false;
            btnNewMail.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            user = tbEmail.Text.Trim();
            password = tbPassword.Text.Trim();
            
            using (var emailClient = new ImapClient())
            {
                try
                {
                    emailClient.Connect("127.0.0.1", 143, 0);
                    emailClient.Authenticate(user,password);
                    var inbox = emailClient.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    for (int i = 0; i < inbox.Count; i++)
                    {
                        var message = inbox.GetMessage(i);
                        ListViewItem lvi = new ListViewItem(message.Subject);
                        lvi.SubItems.Add(message.From.ToString());
                        lvi.SubItems.Add(message.Date.Date.ToString());
                        listView1.Items.Add(lvi);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            listView1.Visible = true;
            btnSend.Visible = true;


        }

      
        private void button3_Click(object sender, EventArgs e)
        {
            gBNewMessage.Visible = false;
            listView1.Visible = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            using (SmtpClient smtp = new SmtpClient("127.0.0.1"))
            {
                string mailFrom = user;
                string mailTo = tbTo.Text.Trim();
                var basicCredential = new NetworkCredential(mailFrom, password);
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress(mailFrom);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = basicCredential;
                    message.From = fromAddress;
                    message.Subject = tbSubject.Text.Trim();
                    message.IsBodyHtml = true;
                    message.Body = richTextBox1.Text;
                    message.To.Add(mailTo);
                    try
                    {
                        smtp.Send(message);
                        MessageBox.Show("Send successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void btnNewMail_Click(object sender, EventArgs e)
        {
            gBNewMessage.Visible = true;
            listView1.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
