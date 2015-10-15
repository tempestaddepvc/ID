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
        protected CheckBox auxiliar;
       public panelConCheckBoxes(Panel panel)
        {
            this.panel = panel;
            for (int i = 0; i < 5; i++)
            {
                auxiliar = new CheckBox();
                auxiliar.Location = new System.Drawing.Point(10*i,0);
                /*checkboxes.AddLast(auxiliar);*/
                panel.Controls.Add(auxiliar);

            }

        }

    }
}
