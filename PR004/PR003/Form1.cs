using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR003
{
    public partial class Form1 : Form
    {
        Point puntoAntiguoRaton = new Point();
        bool primeraVezParaTodo=true;
        private static Point caca = new Point(100, 100);
        Persona personita = new Persona(caca, 50);


        public Form1()
        {
            InitializeComponent();

        }
        
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private double distancia2Puntos(Point a,Point b)
        {
         return Math.Sqrt(Math.Pow(a.X - b.X,2) + Math.Pow(a.Y - b.Y,2));
         
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (primeraVezParaTodo)
            {
                primeraVezParaTodo = false;
                puntoAntiguoRaton.X = e.X;
                puntoAntiguoRaton.Y = e.Y;
          
            }
            personita.huir(sender, e, puntoAntiguoRaton, this.Height, this.Width,button1);
            puntoAntiguoRaton.X = e.X;
            puntoAntiguoRaton.Y = e.Y;

        }
    }
}
