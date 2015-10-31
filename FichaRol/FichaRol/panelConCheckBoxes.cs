using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FichaRol
{
    class panelConCheckBoxes
    {
        protected Panel panel;
        protected LinkedList<CheckBox> checkboxes;
        protected int longitudArray;
        protected CheckBox[] arrayCB;
        

        public panelConCheckBoxes(Panel panel,int longitudArray)
        {
            this.longitudArray = longitudArray;
            this.panel = panel;
            arrayCB = new CheckBox[longitudArray];
            /* for (int i = 0; i < 5; i++)
             {
                 arrayCB[i] = new CheckBox();
                 arrayCB[i].Location= new System.Drawing.Point(10*i,0);

                 panel.Controls.Add(arrayCB[i]);

             }*/
          /*  panel.Controls.Add(new CheckBox()); */

        }

    }
}
