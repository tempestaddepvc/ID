﻿using System;
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
            int pixlMovimiento=0;
            Point nuevoPunto = new Point(button1.Location.X, button1.Location.Y);
            if (primeraVezParaTodo)
            {
                primeraVezParaTodo = false;
                puntoAntiguoRaton.X = e.X;
                puntoAntiguoRaton.Y = e.Y;
          
            }

            if(Math.Abs( button1.Location.X - e.X) < Math.Abs(button1.Location.X - puntoAntiguoRaton.X) || Math.Abs(button1.Location.Y - e.Y) < Math.Abs(button1.Location.Y - puntoAntiguoRaton.Y)) {

            if (!puntoAntiguoRaton.Equals(e.Location)) { 

            if(distancia2Puntos(button1.Location,e.Location) > 100)
                    {
                        pixlMovimiento = 0;
                    }
                    if (distancia2Puntos(button1.Location, e.Location) < 100)
                    {
                        pixlMovimiento = 1;
                    }
                    if (distancia2Puntos(button1.Location, e.Location) < 50)
                    {
                        pixlMovimiento = 100;
                    }


                    if (button1.Location.X > e.Location.X)
            {
                nuevoPunto.X = nuevoPunto.X + pixlMovimiento;

            }
            else
            {
                nuevoPunto.X = nuevoPunto.X - pixlMovimiento;
            }
            if (button1.Location.Y > e.Location.Y)
            {
                nuevoPunto.Y = nuevoPunto.Y + pixlMovimiento;

            }
            else
            {
                nuevoPunto.Y = nuevoPunto.Y - 1;
            }
            if (nuevoPunto.X > 10 && nuevoPunto.Y> 10 && nuevoPunto.Y<this.Height -10 - button1.Height && nuevoPunto.X <this.Width -10 -button1.Width) { 
            button1.Location = nuevoPunto;
             }
                }
                puntoAntiguoRaton.X = e.X;
                puntoAntiguoRaton.Y = e.Y;
            }

        }
    }
}
