using System;
using System.Windows.Forms;

namespace algoritmos
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();

            // Enlazar el menú Ayuda al abrir el formulario de ayuda
            this.ayudaToolStripMenuItem.Click += AyudaToolStripMenuItem_Click;
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

        }

        private void circunferencia3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sutherlandHodgmanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void recorteDeLíneasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void floodFillRecursivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCircunferencia1 form4 = frmCircunferencia1.ObtenerInstancia();
            ShowSingletonForm(form4);
        }

        private void boundaryFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCircunferencia2 form5 = frmCircunferencia2.ObtenerInstancia();
            ShowSingletonForm(form5);
        }

        private void floodFillRecursivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCircunferencia3 form6 = frmCircunferencia3.ObtenerInstancia();
            ShowSingletonForm(form6);
        }

        private void recorteDeLíneasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPoligonoRelleno form8 = frmPoligonoRelleno.ObtenerInstancia();
            ShowSingletonForm(form8);
        }

        private void sutherlandHodgmanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRecorte form7 = frmRecorte.ObtenerInstancia();
            ShowSingletonForm(form7);
        }

        // Nuevo handler: abre la ventana de ayuda con la información de cada formulario
        private void AyudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAyuda())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
