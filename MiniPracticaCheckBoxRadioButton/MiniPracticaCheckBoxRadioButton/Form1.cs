using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPracticaCheckBoxRadioButton
{
    public partial class Form1 : Form
    {
        protected Random random = new Random(new Random(new Random(new Random(new Random(new Random().Next()).Next()).Next()).Next()).Next());
        protected int contador=0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

   
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;

                checkBox3.Checked = false;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;

                checkBox3.Checked = false;

            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;

                checkBox2.Checked = false;

            }
        }

        private void checkBox4_click(object sender, EventArgs e)
        {

            if (!checkBox4.Checked)
            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
            }
            
        }
        private void checkBox5_click(object sender, EventArgs e)
        {
            if (!checkBox5.Checked)
            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox6.Checked = false;
            }
        }
        private void checkBox6_click(object sender, EventArgs e)
        {
            if (!checkBox6.Checked)
            {
                checkBox6.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contador++;
            CheckBox nuevoCheckBox = new CheckBox();
            nuevoCheckBox.Location = new Point(random.Next(0,this.Width),random.Next(0,this.Height));
            nuevoCheckBox.Size = new Size(69, 17);
            nuevoCheckBox.TabIndex = 2;
            nuevoCheckBox.Text = contador+ "";
            nuevoCheckBox.UseVisualStyleBackColor = true;
            this.Controls.Add(nuevoCheckBox);
           


             foreach (Object checkcajita in Controls)
            { 
                if(checkcajita is CheckBox) { 
                 ((CheckBox)checkcajita).Checked = false;
                }
            }




        }
    }
}
