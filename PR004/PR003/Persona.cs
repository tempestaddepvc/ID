using System;
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
       /* protected Button boton; */
        protected Point posicion;
        protected Image imagen;
        protected int velocidad;
        protected int tamanio;
        protected int vista;
        public Persona(Point posicion,int tamanio)
        {
            /*this.boton = new Button();
            this.boton.Location = posicion;
            this.boton.Width = tamanio;
            this.boton.Height = tamanio;*/
            this.posicion = posicion;
          
          
            this.tamanio = tamanio;
            
        }
        private double distancia(Point a,Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
        public void huir(object sender, MouseEventArgs e,Point puntoAntiguoRaton,int heightForm,int widthForm,Button button1)
        {
            int pixlMovimiento = 0;
            Point nuevoPunto = new Point(posicion.X, posicion.Y);
        

            if (Math.Abs(posicion.X - e.X) < Math.Abs(posicion.X - puntoAntiguoRaton.X) || Math.Abs(posicion.Y - e.Y) < Math.Abs(posicion.Y - puntoAntiguoRaton.Y))
            {

                if (!puntoAntiguoRaton.Equals(e.Location))
                {

                    if (distancia(posicion, e.Location) > 100)
                    {
                        pixlMovimiento = 0;
                    }
                    if (distancia(posicion, e.Location) < 100)
                    {
                        pixlMovimiento = 1;
                    }
                    if (distancia(posicion, e.Location) < 50)
                    {
                        pixlMovimiento = 100;
                    }


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
                        button1.Location = posicion;
                    }

                }
          
            }
            

        }
    }



}

