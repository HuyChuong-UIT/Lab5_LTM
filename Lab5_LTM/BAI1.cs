using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace Lab5_LTM
{
    public partial class BAI1 : Form
    {
        public BAI1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            using (SmtpClient smtp = new SmtpClient("127.0.0.1"))
            {
                string mailFrom = tbFrom.Text.Trim();
                string mailTo = tbTo.Text.Trim();
                string password = tbPassword.Text.Trim();
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
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
    }
}
