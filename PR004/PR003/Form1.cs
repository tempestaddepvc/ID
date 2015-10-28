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
using System.Collections;
using System.Windows.Forms;
namespace PR003
{
    public partial class Form1 : Form
    {
        
        Point puntoAntiguoRaton = new Point();
        bool primeraVezParaTodo=true;
        ArrayList personas = new ArrayList();
        Random rdm = new Random();
       


        public Form1()
        {
            InitializeComponent();

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
            foreach (Persona personita in personas)
            {
                personita.huir(e,puntoAntiguoRaton, Height,Width);
            }
            puntoAntiguoRaton.X = e.X;
            puntoAntiguoRaton.Y = e.Y;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fabricaDePersonas();


        }
        public void fabricaDePersonas()
        {
        
            Button botondepersona = new Button();
            this.Controls.Add(botondepersona);
            botondepersona.Click += new EventHandler(this.clickEnPersona);
            personas.Add(new Persona(new Point(rdm.Next(50,this.Width - 50), rdm.Next(50,this.Height - 50)),botondepersona));

        }
        public void clickEnPersona(Object sender,System.EventArgs e)
        {       
            int i = 0;
            foreach (Persona personita in personas) //busca en que posición del array de personas está y la borra de él
            {
               
                if (sender == personita.boton)
                {
                 Console.Beep(200,200);
                    personita.boton.Dispose();


                }
                i++;
            }
            
            personas.Remove(i);

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (Persona personita in personas)
            {
                personita.crecer();
            }
        
        }
    }
}
