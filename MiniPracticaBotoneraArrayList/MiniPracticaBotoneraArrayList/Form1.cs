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

namespace MiniPracticaBotoneraArrayList
{
    public partial class Form1 : Form
    {
        private ArrayList arraylist = new ArrayList();
        private int posicionEnArrayList = 0;



        public Form1()
        {
            InitializeComponent();
            arraylist.Add("");
        }


        private void modoEdicion()
        {
            textBox1.ReadOnly = false;
            button1.Visible = true;
            buttonCancelar.Visible = true;
            buttonAnterior.Visible = false;
            buttonBorrar.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            buttonSiguiente.Visible = false;
            if (arraylist.Count == 1)
            {
                buttonCancelar.Visible = false;
            }
        }
        private void modoVision()
        {
            textBox1.Text = (String)arraylist[posicionEnArrayList];
            textBox1.ReadOnly = true;
            button1.Visible = false;
            buttonCancelar.Visible = false;
            buttonAnterior.Visible = true;
            buttonBorrar.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            buttonSiguiente.Visible = true;
            comprobarBotonesMovimiento();
        }

        private void button_nuevo(object sender, EventArgs e)
        {
            nuevo();
          


        }
        private void nuevo()
        {
            textBox1.ResetText();
            posicionEnArrayList = arraylist.Count;
            arraylist.Add("");
            modoEdicion();
        }
        private void button_guardar(object sender, EventArgs e)
        {
      
                arraylist[posicionEnArrayList] = textBox1.Text;
                modoVision();
            
        }

        private void button_cancelar(object sender, EventArgs e)
        {
            if (arraylist[posicionEnArrayList] == "")
            {
                arraylist.RemoveAt(posicionEnArrayList);

            }
            posicionEnArrayList = 0;
            modoVision();
        }

        private void button_anterior(object sender, EventArgs e)
        {
            posicionEnArrayList -= 1;
            textBox1.Text = (String)arraylist[posicionEnArrayList];
            comprobarBotonesMovimiento();
        }

        private void button_siguiente(object sender, EventArgs e)
        {
            posicionEnArrayList += 1;
            textBox1.Text = (String)arraylist[posicionEnArrayList];
            comprobarBotonesMovimiento();

        }

        private void button_modificar(object sender, EventArgs e)
        {
            modoEdicion();
        }
        private void comprobarBotonesMovimiento()
        {
            if (posicionEnArrayList == (arraylist.Count - 1))
            {
                buttonSiguiente.Visible = false;
            }
            else
            {
                buttonSiguiente.Visible = true;
            }
            if (posicionEnArrayList == 0)
            {
                buttonAnterior.Visible = false;
            }
            else
            {
                buttonAnterior.Visible = true;
            }
        }

        private void button_borrar(object sender, EventArgs e)
        {
            arraylist.RemoveAt(posicionEnArrayList);
            textBox1.ResetText();
            posicionEnArrayList = 0;
            if (arraylist.Count ==0)
            {
                nuevo();
            }
            else
            {
                modoVision();
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
    }

}