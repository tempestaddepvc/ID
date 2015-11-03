using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ficha_Ragnarok_Online
{
    public partial class Form1 : Form
    {
        private String avatarPath = "..\\..\\elementosVisuales\\avatar\\male\\";
        private int avatarWidth = 200;
        private int avatarHeight = 200;
        private const int LIMPIAR = 0;
        private const int ALEATORIO = 1;
        private const int ERROR = 2;
        
        private const String MSG_ERROR_CARACTERISTICAS = "¡No tienes suficientes puntos!";
        private const String MSG_LIMPIAR_CARACTERISTICAS = "Se han limpiado los puntos asignados";
        private const String MSG_ALEATORIO_CARACTERISTICAS = "Se han repartido los puntos aleatoriamente";
        public Form1()
        {
            InitializeComponent();
            characterImage.BackgroundImage = new Bitmap("..\\..\\elementosVisuales\\localizacion\\Eimburg.jpg");
            cmboxPrimerJob.SelectedIndex = 0;
            cmboxSegundoTrabajo.SelectedIndex = 0;
            cmboxLocalizacion.SelectedIndex = 0;
            lblSexo.Image = new Bitmap("..\\..\\elementosVisuales\\iconos sexo\\Hombre.gif");
            nudNivel.Tag = 1;  //El valor del tag de los NumericUpDown es su antiguo valor;
            nudJob1.Tag = 1;  //Se ha hecho así para poder reciclar métodos entre ellos
            nudJob2.Tag = 1;
            panelNivelStats.Tag = 0; //El valor del tag de los paneles de stats y los dos trabajos son los puntos restantes a distribuir
            panelPrimerTrabajo.Tag = 0;//se ha hecho así para poder reciclar métodos entre ellos
            panelSegundoTrabajo.Tag = 0;
            nudFuerza.Tag = 1;
            nudAgilidad.Tag = 1;
            nudDestreza.Tag = 1;
            nudInteligencia.Tag = 1;
            nudSuerte.Tag = 1;
            nudVitalidad.Tag = 1;

            panelHabilidad1PrimerTrabajo.Tag = 0; //En el tag del panel se guardan los puntos antiguos de cada skill
            panelHabilidad2PrimerTrabajo.Tag = 0;
            panelHabilidad3PrimerTrabajo.Tag = 0;
            panelHabilidad4PrimerTrabajo.Tag = 0;
            panelHabilidad1SegundoTrabajo.Tag = 0;
            panelHabilidad2SegundoTrabajo.Tag = 0;
            panelHabilidad3SegundoTrabajo.Tag = 0;
            panelHabilidad4SegundoTrabajo.Tag = 0;
            lblJob1Skill1.Tag = 0; //En el tag de la equiqueta se guardan los puntos nuevos de cada skill
            lblJob1Skill2.Tag = 0;
            lblJob1Skill3.Tag = 0;
            lblJob1Skill4.Tag = 0;
            lblJob2Skill1.Tag = 0;
            lblJob2Skill2.Tag = 0;
            lblJob2Skill3.Tag = 0;
            lblJob2Skill4.Tag = 0;
            pictureBox9.Parent = characterImage;
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Location = new Point(25, 45);         

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lblMsgNivel_Click(object sender, EventArgs e)
        {

        }
        private void nudFuerza_ValueChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void comboCambiarLocalizacion(object sender, EventArgs e)
        {
            characterImage.BackgroundImage = new Bitmap("..\\..\\elementosVisuales\\localizacion\\" + cmboxLocalizacion.Text + ".jpg");
        }
        private void cambiarAvatar()
        {
            PictureBox pictureAuxiliar;
            if (rdbtnAdulto.Checked)
            {
                pictureBox9.Image = null;
                pictureAuxiliar = characterImage;
            }
            else
            {
                characterImage.Image = null;
                pictureAuxiliar = pictureBox9;
            }
            if (cmboxSegundoTrabajo.SelectedIndex != 0)
            {
                pictureAuxiliar.Image = new Bitmap(new Bitmap(avatarPath + "segundoJob\\" + cmboxSegundoTrabajo.Text + ".gif"),avatarWidth,avatarHeight);
            }
            else
            {

                pictureAuxiliar.Image = new Bitmap(new Bitmap(avatarPath + "primerJob\\" + cmboxPrimerJob.Text + ".gif"), avatarWidth, avatarHeight);
            }
          
        }
        private void rdbtnHombre_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnHombre.Checked)
            {
                avatarPath = "..\\..\\elementosVisuales\\avatar\\male\\";
                cambiarAvatar();
                lblSexo.Image = new Bitmap("..\\..\\elementosVisuales\\iconos sexo\\Hombre.gif");
            }

        }
        private void rdbtnMujer_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbtnMujer.Checked)
            {
                avatarPath = "..\\..\\elementosVisuales\\avatar\\female\\";
                cambiarAvatar();
                lblSexo.Image = new Bitmap("..\\..\\elementosVisuales\\iconos sexo\\Mujer.gif");
            }
        }
        private void rdbtnEdadAdulto(object sender, EventArgs e)
        {
            avatarWidth = 200;
            avatarHeight = 200;
            cambiarAvatar();
        }
        private void rdbtnEdadNinio(object sender, EventArgs e)
        {
            avatarWidth = 150;
            avatarHeight = 130;
            cambiarAvatar();
        }
        private void progressbarNivelClick(object sender, MouseEventArgs e)
        {
            bool aux = true;
            ((ProgressBar)sender).Value = (int)Math.Ceiling((((double)e.X + 1) * ((ProgressBar)sender).Maximum) / ((ProgressBar)sender).Width);//Se pone el valor donde se pinche con el raton en la progressbar
            for (int i = 0; i < ((Panel)((ProgressBar)sender).Parent).Controls.Count && aux; i++)//Le pone el mismo valor que tiene al primer NumericUpDown hermano que encuentre
            {
                if (((Panel)((ProgressBar)sender).Parent).Controls[i] is NumericUpDown)
                {
                    if (((NumericUpDown)((Panel)((ProgressBar)sender).Parent).Controls[i]).Value != ((ProgressBar)sender).Value)
                    { //Si tienen el mismo valor no se cambia
                        ((NumericUpDown)((Panel)((ProgressBar)sender).Parent).Controls[i]).Value = ((ProgressBar)sender).Value;
                    }
                    aux = false;
                }
            }

        }
        private void nudNivel_valueChanged(object sender, EventArgs e)
        {
            bool aux = true;
            for (int i = 0; i < ((Panel)((NumericUpDown)sender).Parent).Controls.Count && aux; i++)//Le pone el mismo valor que tiene a la primera progressbar hermana que encuentre
            {
                if (((Panel)((NumericUpDown)sender).Parent).Controls[i] is ProgressBar)
                {
                    if (((ProgressBar)((Panel)((NumericUpDown)sender).Parent).Controls[i]).Value != (int)(((NumericUpDown)sender).Value))
                    { //Si tienen el mismo valor no se cambia
                        ((ProgressBar)((Panel)((NumericUpDown)sender).Parent).Controls[i]).Value = (int)(((NumericUpDown)sender).Value);
                    }
                    aux = false;
                }
            }
            // ((Panel)((Panel)((NumericUpDown)sender).Parent).Parent).Tag = (int)((Panel)((NumericUpDown)sender).Parent).Parent.Tag + ((int)((NumericUpDown)sender).Value) - (int)((NumericUpDown)sender).Tag; //Se cambian los puntos restantes por:puntos restantes + nivel actual - nivel antiguo
            diferentesAccionesNudProgressbar(((Panel)((Panel)((NumericUpDown)sender).Parent).Parent),(NumericUpDown)sender);

            ((NumericUpDown)sender).Tag = ((int)((NumericUpDown)sender).Value);
            escribirPuntosRestantes(((Panel)((Panel)((NumericUpDown)sender).Parent).Parent));
        }
        private void escribirPuntosRestantes(Panel panel)
        {
            if (panel == panelNivelStats)
            {
                lblNumPuntosRestantesStats.Text = ((int)panel.Tag) + "";
            }
            if (panel == panelPrimerTrabajo)
            {
                lblNumPuntosRestantesJob1.Text = ((int)panel.Tag) + "";
            }
            if (panel == panelSegundoTrabajo)
            {
                lblNumPuntosRestantesJob2.Text = ((int)panel.Tag) + "";
            }
        }
        private void ndStats_changed(object sender, EventArgs e)
        {
            if ((((int)((Panel)((NumericUpDown)sender).Parent).Tag) - ((int)((NumericUpDown)sender).Value) + ((int)((NumericUpDown)sender).Tag)) >= 0)
            { //entra si teniendo en cuenta el cambio en la característica,los puntos restantes no son negativos
                ((Panel)((NumericUpDown)sender).Parent).Tag = ((int)((Panel)((NumericUpDown)sender).Parent).Tag) - ((int)((NumericUpDown)sender).Value) + ((int)((NumericUpDown)sender).Tag);//Se cambian los puntos restantes por:puntos restantes - puntos caracterista nuevos + puntos caracteristica antiguos
                ((NumericUpDown)sender).Tag = ((int)((NumericUpDown)sender).Value);
                escribirPuntosRestantes(((Panel)((NumericUpDown)sender).Parent));
            }
            else
            {
                escribirAvisosCaracteristicas(((Panel)((NumericUpDown)sender).Parent), ERROR);
                ((NumericUpDown)sender).Value = ((int)((NumericUpDown)sender).Tag);
            }
        }
        private void escribirAvisosCaracteristicas(Panel panel, int clave)
        {
            Label auxiliar = new Label();
            if (panel == panelNivelStats)
            {
                auxiliar = lblMsgStats;

            }
            else if (panel == panelPrimerTrabajo)
            {
                auxiliar = lblMsgJob1Skills;

            }
            else if (panel == panelSegundoTrabajo)
            {
                auxiliar = lblMsgJob2Skills;

            }
            if (clave == LIMPIAR)
            {
                avisoCaracteristicasLimpiar(auxiliar);
            }
            else if (clave == ERROR)
            {
                avisoCaracteristicasError(auxiliar);
            }
            else if (clave == ALEATORIO)
            {
                avisoCaracteristicasAleatorio(auxiliar);
            }

        }
        private void timerAvisosCaracteristicas_Tick(object sender, EventArgs e)
        {
            lblMsgJob2Skills.Visible = false;
            lblMsgJob1Skills.Visible = false;
            lblMsgStats.Visible = false;
            ((System.Windows.Forms.Timer)sender).Stop();
        }
        private void btnLimpiarStats_Click(object sender, EventArgs e)
        {
            foreach (Object item in (((Panel)((Button)sender).Parent).Controls))
            {
                if (item is NumericUpDown)
                {
                    ((NumericUpDown)item).Value = 1;
                }
            }
            escribirAvisosCaracteristicas(((Panel)((Button)sender).Parent), LIMPIAR);
        }
        private void avisoCaracteristicasError(Label label)
        {
            label.ForeColor = Color.Red;
            label.Text = MSG_ERROR_CARACTERISTICAS;
            label.Visible = true;
            timerAvisosCaracteristicas.Start();
        }
        private void avisoCaracteristicasAleatorio(Label label)
        {
            label.ForeColor = Color.Green;
            label.Text = MSG_ALEATORIO_CARACTERISTICAS;
            label.Visible = true;
            timerAvisosCaracteristicas.Start();
        }
        private void avisoCaracteristicasLimpiar(Label label)
        {
            label.ForeColor = Color.Green;
            label.Text = MSG_LIMPIAR_CARACTERISTICAS;
            label.Visible = true;
            timerAvisosCaracteristicas.Start();
        }
        private void btnAlAzarStats_Click(object sender, EventArgs e)
        {
            ArrayList arrayStats = new ArrayList();
            Random rnd = new Random();
            if ((int)((Panel)((Button)sender).Parent).Tag > 0)
            {

                foreach (Object item in (((Panel)((Button)sender).Parent).Controls))
                {
                    if (item is NumericUpDown)
                    {
                        arrayStats.Add(((NumericUpDown)item));
                    }
                }
                while ((int)((Panel)((Button)sender).Parent).Tag > 0)
                {
                    ((NumericUpDown)arrayStats[rnd.Next(arrayStats.Count)]).Value = ((NumericUpDown)arrayStats[rnd.Next(arrayStats.Count)]).Value + 1;
                }
                escribirAvisosCaracteristicas(((Panel)((Button)sender).Parent), ALEATORIO);
            }
            else
            {
                escribirAvisosCaracteristicas(((Panel)((Button)sender).Parent), ERROR);
            }
        }
        private void cmboxPrimerJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmboxSegundoTrabajo.Items.Clear();
            cmboxSegundoTrabajo.Items.Add("Sin seleccionar");
            cmboxSegundoTrabajo.SelectedIndex = 0;
            if (cmboxPrimerJob.Text == "Sin seleccionar")
            {



            }
            else
            {
                if (cmboxPrimerJob.Text == "Acólito")
                {
                    cmboxSegundoTrabajo.Items.Add("Cura");
                    cmboxSegundoTrabajo.Items.Add("Monje");
                }
                else if (cmboxPrimerJob.Text == "Arquero")
                {
                    cmboxSegundoTrabajo.Items.Add("Cazador");
                    cmboxSegundoTrabajo.Items.Add("Gitano");
                }
                else if (cmboxPrimerJob.Text == "Espadachín")
                {
                    cmboxSegundoTrabajo.Items.Add("Caballero");
                    cmboxSegundoTrabajo.Items.Add("Paladín");
                }
                else if (cmboxPrimerJob.Text == "Ladrón")
                {
                    cmboxSegundoTrabajo.Items.Add("Asesino");
                    cmboxSegundoTrabajo.Items.Add("Pícaro");
                }
                else if (cmboxPrimerJob.Text == "Mago")
                {
                    cmboxSegundoTrabajo.Items.Add("Hechicero");
                    cmboxSegundoTrabajo.Items.Add("Profesor");
                }
                else if (cmboxPrimerJob.Text == "Mercader")
                {
                    cmboxSegundoTrabajo.Items.Add("Alquimista");
                    cmboxSegundoTrabajo.Items.Add("Herrero");
                }
                else if (cmboxPrimerJob.Text == "Taekwondista")
                {
                    cmboxSegundoTrabajo.Items.Add("Enlazador de almas");
                    cmboxSegundoTrabajo.Items.Add("Gladiador de las estrellas");
                }
            }


        }
        private void cmboxSegundoTrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiarAvatar();
        }
        private void checkBoxClick(object sender, EventArgs e)
        {
            Label lblAux = new Label();
            Panel panelDeSkill = ((Panel)((CheckBox)sender).Parent);
            Panel panelDeTrabajo = ((Panel)((Panel)((CheckBox)sender).Parent).Parent);
            CheckBox checkboxAux = new CheckBox();
            foreach (Object item in panelDeSkill.Controls)
            {
                if (item is Label)
                {
                    lblAux = ((Label)item);

                }
            }

            if (((CheckBox)sender).Checked)
            {
                lblAux.Tag = ((CheckBox)sender).TabIndex;
            }
            else
            {
                lblAux.Tag = ((CheckBox)sender).TabIndex - 1;
            }

            if ((((int)panelDeTrabajo.Tag) - ((int)lblAux.Tag) + ((int)panelDeSkill.Tag)) >= 0)
            {
                if (!((CheckBox)sender).Checked)
                {
                    ((CheckBox)sender).Checked = false;
                    foreach (Object item in ((Panel)((CheckBox)sender).Parent).Controls)
                    {
                        if (item is CheckBox)
                        {
                            if ((((CheckBox)sender).TabIndex) < (((CheckBox)item).TabIndex) && (((CheckBox)item).Checked))
                            {
                                ((CheckBox)item).Checked = false;
                            }
                        }
                    }
                }
                else
                {
                    ((CheckBox)sender).Checked = true;
                    foreach (Object item in ((Panel)((CheckBox)sender).Parent).Controls)
                    {
                        if (item is CheckBox)
                        {
                            if ((((CheckBox)sender).TabIndex) > (((CheckBox)item).TabIndex) && !(((CheckBox)item).Checked))
                            {
                                ((CheckBox)item).Checked = true;
                            }
                        }
                    }
                }
                panelDeTrabajo.Tag = ((int)panelDeTrabajo.Tag - ((int)lblAux.Tag) + ((int)panelDeSkill.Tag));
                panelDeSkill.Tag = ((int)lblAux.Tag);
                escribirPuntosRestantes(panelDeTrabajo);
            }
            else
            {
                escribirAvisosCaracteristicas(panelDeTrabajo, ERROR);
                ((CheckBox)sender).Checked = false;
            }
        }
        private void btnLimpiarSkills_click(object sender, EventArgs e)
        {
            Panel panelTrabajo = ((Panel)((Button)sender).Parent);
            foreach (Object panel in panelTrabajo.Controls)
            {
                if (panel is Panel)
                {
                    if (((Panel)panel).Tag is int)
                    {
                        panelTrabajo.Tag = ((int)panelTrabajo.Tag) + ((int)((Panel)panel).Tag);
                        ((Panel)panel).Tag = 0;
                        foreach (Object item in ((Panel)panel).Controls)
                        {
                            if (item is CheckBox)
                            {
                                ((CheckBox)item).Checked = false;
                            }
                        }
                    }

                }
            }

            escribirPuntosRestantes(panelTrabajo);
            escribirAvisosCaracteristicas(panelTrabajo, LIMPIAR);

        }
        private void btnAlAzarSkills_click(object sender, EventArgs e)
        {
            Panel panelTrabajo = ((Panel)((Button)sender).Parent);
            ArrayList paneles = new ArrayList();
            Random rnd = new Random();
            int numpaneles;
            int auxRandom;
            if (((int)panelTrabajo.Tag) == 0)
            {
                escribirAvisosCaracteristicas(panelTrabajo, ERROR);
            }
            else{ foreach (Object panel in panelTrabajo.Controls)
            {
                if (panel is Panel)
                {
                    if (((Panel)panel).Tag is int)
                    {
                        if (((int)(((Panel)panel).Tag)) != 5)
                        {
                            paneles.Add(panel);
                        }
                    }
                }
            }

            while (((int)panelTrabajo.Tag) != 0)
            {
                numpaneles = paneles.Count;
                auxRandom = rnd.Next(numpaneles);
                ((Panel)paneles[auxRandom]).Tag = ((int)((Panel)paneles[auxRandom]).Tag) + 1;
                panelTrabajo.Tag = ((int)panelTrabajo.Tag) - 1;
                foreach (Object item in ((Panel)paneles[auxRandom]).Controls)
                {
                    if (item is CheckBox)
                    {
                        if (((CheckBox)item).TabIndex == ((int)((Panel)paneles[auxRandom]).Tag))
                        {
                            ((CheckBox)item).Checked = true;
                        }
                    }
                }


            }
            escribirPuntosRestantes(panelTrabajo);
            escribirAvisosCaracteristicas(panelTrabajo, ALEATORIO);
        }
        }
        private void diferentesAccionesNudProgressbar(Panel panel,NumericUpDown sender)
        {
            if (panel== panelPrimerTrabajo || panel == panelSegundoTrabajo || panel==panelNivelStats)
            {
                panel.Tag = (int)panel.Tag + ((int)sender.Value) - (int)sender.Tag; //Se cambian los puntos restantes por:puntos restantes + nivel actual - nivel antiguo
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void lblNombre_Click(object sender, EventArgs e)
        {

        }
      
    }
}