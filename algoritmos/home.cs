using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace algoritmos
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }


        // Método de ayuda para simplificar el código
        private void ShowSingletonForm(Form form)
        {
            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            form.Show();
            form.BringToFront();
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDDA form1 = frmDDA.ObtenerInstancia();
            ShowSingletonForm(form1);
        }

        private void bresenhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBresenham form2 = frmBresenham.ObtenerInstancia();
            ShowSingletonForm(form2);
        }

        private void puntoMedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuntoMedio form3 = frmPuntoMedio.ObtenerInstancia();
            ShowSingletonForm(form3);
        }

        private void circunferencia1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCircunferencia1 form4 = frmCircunferencia1.ObtenerInstancia();
            ShowSingletonForm(form4);
        }

        private void circunferencia2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCircunferencia2 form5 = frmCircunferencia2.ObtenerInstancia();
            ShowSingletonForm(form5);
        }

        private void circunferencia3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCircunferencia3 form6 = frmCircunferencia3.ObtenerInstancia();
            ShowSingletonForm(form6);
        }

        private void sutherlandHodgmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecorte form7 = frmRecorte.ObtenerInstancia();
            ShowSingletonForm(form7);
        }
    }
}
