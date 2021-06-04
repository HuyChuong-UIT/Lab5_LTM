using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using MailKit;
using System.Net.Mail;
using System.Net;
using System.Threading;
namespace Lab5_LTM
{
    public partial class Main3 : Form
    {
        public Main3()
        {
            InitializeComponent();
            ReceiveMail();
        }
        private void ReceiveMail()
        {
            using (var emailClient = new ImapClient())
            {
                try
                {
                    emailClient.Connect("127.0.0.1", 143, 0);
                    emailClient.Authenticate(BAI3.user, BAI3.password);
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
                    Thread.Sleep(500);
                   
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            button3.Visible = true;
            listView1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SmtpClient smtp = new SmtpClient("127.0.0.1"))
            {
                string mailFrom = BAI3.user;
                string mailTo = tbTo.Text.Trim();
                string password = BAI3.password;
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

        private void button3_Click(object sender, EventArgs e)
        {
            tbTo.Text = "";
            tbSubject.Text = "";
            richTextBox1.Text = "";
            groupBox1.Visible = false;
            button3.Visible = false;
            listView1.Visible = true;
        }
    }
}
