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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            
            ArrayList lista = crealistasRadioButton(sender);
            int posicionSender=lista.IndexOf(sender);
            ((RadioButton)sender).Checked = true;
            foreach (RadioButton boton in lista)
            {
                if (lista.IndexOf(boton)<posicionSender) {
                    boton.Checked = true;
                }
                if (lista.IndexOf(boton) > posicionSender)
                {
                    boton.Checked = false;
                }
            }

            
            

        }
        private ArrayList crealistasRadioButton(Object sender)
        {
            ArrayList lista = new ArrayList();
            foreach (Object panelhijo in ((RadioButton)sender).Parent.Parent.Controls)
            {

                if (panelhijo is Panel)
                {
                    foreach (Object radiobuttons in ((Panel)panelhijo).Controls)
                    {
                        if (radiobuttons is RadioButton)
                        {
                            lista.Add(radiobuttons);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
