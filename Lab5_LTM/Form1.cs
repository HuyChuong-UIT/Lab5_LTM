using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_LTM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BAI2 bai2 = new BAI2();
            bai2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BAI3 bai3 = new BAI3();
            bai3.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BAI1 bai1 = new BAI1();
            bai1.Show();
        }
    }
}
