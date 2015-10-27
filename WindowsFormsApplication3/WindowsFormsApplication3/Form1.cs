using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value > progressBar1.Minimum)
            {
                progressBar1.Value--;
            }
        }



        private void progressBar2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < ((ProgressBar)sender).Width / 2)
            {
                if (((ProgressBar)sender).Value > ((ProgressBar)sender).Minimum)
                {
                    ((ProgressBar)sender).Value--;
                }
            }

            if (e.X > ((ProgressBar)sender).Width / 2)
            {
                if (((ProgressBar)sender).Value < ((ProgressBar)sender).Maximum)
                {
                    ((ProgressBar)sender).Value++;
                }
            }
        }

        private void progressBar3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < ((((ProgressBar)sender).Width / ((ProgressBar)sender).Maximum) * ((ProgressBar)sender).Value))
            {
                if (((ProgressBar)sender).Value > ((ProgressBar)sender).Minimum)
                {
                    ((ProgressBar)sender).Value--;
                }
            }

            if (e.X > ((((ProgressBar)sender).Width / ((ProgressBar)sender).Maximum) * ((ProgressBar)sender).Value))
            {
                if (((ProgressBar)sender).Value < ((ProgressBar)sender).Maximum)
                {
                    ((ProgressBar)sender).Value++;
                }

            }
        }

        private void progressBar4_MouseClick(object sender, MouseEventArgs e)
        {
            ((ProgressBar)sender).Value = (int)Math.Ceiling((((double)e.X) *   ((ProgressBar)sender).Maximum)/((ProgressBar)sender).Width);

        }
    }
}

