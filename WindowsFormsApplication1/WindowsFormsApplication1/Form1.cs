using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            button1.Location = new Point(rnd.Next(0, this.Height - button1.Height), rnd.Next(0, this.Width - button1.Width));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Width = button1.Width / 2;
            button1.Height = button1.Height / 2;
            /* timer1.Interval = timer1.Interval/2;/*

            /* timer1.Enabled = false;
             MessageBox.Show("Has ganado");
             button1.Enabled = false;*/


        }
    }
}
