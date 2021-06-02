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

namespace Lab5_LTM
{
    public partial class BAI2 : Form
    {
        public BAI2()
        {
            InitializeComponent();
        }

        private void BAI2_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using( var emailClient = new ImapClient())
            {
                try
                {

                    emailClient.Connect("127.0.0.1", 143,0);
                    emailClient.Authenticate(tbEmail.Text, tbPassword.Text);
                    var inbox = emailClient.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    for (int i = 0; i < inbox.Count; i++)
                    {
                        var message = inbox.GetMessage(i);
                        ListViewItem lvi = new ListViewItem();
                       
                        lvi.SubItems.Add(message.From.ToString());
                        lvi.SubItems.Add(message.Date.Date.ToString());
                        listView1.Items.Add(message.Subject);
                        listView1.Items.Add(lvi);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
