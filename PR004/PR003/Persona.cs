﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace PR003
{
    class Persona
    {
        public Button boton;
        protected Point posicion;
        public Image imagen = Properties.Resources.duckFLIES;
        protected int velocidadAndar = 1;
        protected int velocidadCorrer = 5;
        protected int tamanio=25;
        protected int vista = 100;
        public Persona(Point posicion,Button boton)
        {
            this.posicion = posicion;
            this.boton = boton;
            boton.Location = posicion;
            boton.Width = tamanio;
            boton.Height = tamanio;
            boton.BackgroundImageLayout = ImageLayout.Zoom;
            boton.FlatAppearance.BorderSize = 0;
            boton.Cursor = Cursors.Cross;
            boton.FlatStyle = FlatStyle.Flat;
            boton.BackgroundImage = imagen;
         
        }
        public void crecer()
        {
            //si no aumentamos la vista a la vez que el tamanio,al final el boton se dejaria de mover
            tamanio++;
            boton.Width = tamanio;
            boton.Height = tamanio;
            vista++;

        }
        private double distancia(Point a,Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
public void huir(MouseEventArgs e,Point puntoAntiguoRaton,int heightForm,int widthForm)
        {
            int pixlMovimiento = 0;//Cantidad de pixeles que se va a mover por cada movimiento del ratón.
            Point nuevoPunto = new Point(posicion.X, posicion.Y);
        

            if (Math.Abs(posicion.X - e.X) < Math.Abs(posicion.X - puntoAntiguoRaton.X) ||
                Math.Abs(posicion.Y - e.Y) < Math.Abs(posicion.Y - puntoAntiguoRaton.Y)) /*se comprueba que el ratón se haya acercado a la persona*/
            {

                if (!puntoAntiguoRaton.Equals(e.Location))/*se comprueba que el ratón se haya movido*/
                {
                    /* dependiendo de la distancia,se cambia lo que se mueve*/
                    if (distancia(posicion, e.Location) > vista)
                    {
                        pixlMovimiento = 0;
                    }
                    if (distancia(posicion, e.Location) < vista)
                    {
                        pixlMovimiento = velocidadAndar;
                    }
                    if (distancia(posicion, e.Location) < vista/2)
                    {
                        pixlMovimiento = velocidadCorrer;
                    }
                    
                    /* Se comprueba la posición del ratón con respecto al botón para que se mueva huyendo de él*/
                    if (posicion.X > e.Location.X)
                    {
                        nuevoPunto.X = nuevoPunto.X + pixlMovimiento;

                    }
                    else
                    {
                        nuevoPunto.X = nuevoPunto.X - pixlMovimiento;
                    }
                    if (posicion.Y > e.Location.Y)
                    {
                        nuevoPunto.Y = nuevoPunto.Y + pixlMovimiento;

                    }
                    else
                    {
                        nuevoPunto.Y = nuevoPunto.Y - 1;
                    }
                    if (nuevoPunto.X > 10 && nuevoPunto.Y > 10 && nuevoPunto.Y < heightForm - 10 - tamanio && nuevoPunto.X < widthForm - 10 - tamanio)
                    {
                        posicion = nuevoPunto;
                        boton.Location = posicion;
                    }

                }
          
            }
            

        }
    }

}

