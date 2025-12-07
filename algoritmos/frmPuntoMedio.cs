using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace algoritmos
{
    public partial class frmPuntoMedio : Form
    {
        private static frmPuntoMedio instancia;

        // Instancias de cPixel y CPuntoMedio
        private cPixel pixel;
        private CPuntoMedio algoritmo;
        private Panel panelPixel; // panel creado en tiempo de ejecución sobre picCanvas

        public frmPuntoMedio()
        {
            InitializeComponent();

            // Enlazar eventos aquí
            this.Load += PuntoMedio_Load;
            this.btnCalcular.Click += BtnCalcular_Click;
            this.btnResetear.Click += BtnResetear_Click;
            this.btnSalir.Click += BtnSalir_Click;
        }

        public static frmPuntoMedio ObtenerInstancia()
        {
            // Si la instancia es nula O si ya ha sido cerrada/eliminada
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new frmPuntoMedio();
            }
            return instancia;
        }

        private void PuntoMedio_Load(object sender, EventArgs e)
        {
            // Crear un Panel dinámico encima de picCanvas para usar con cPixel
            panelPixel = new Panel
            {
                Name = "panelPixel",
                Location = picCanvas.Location,
                Size = picCanvas.Size,
                Anchor = picCanvas.Anchor,
                BackColor = picCanvas.BackColor
            };

            // Añadir el panel al grupo gráfico (mismo contenedor que picCanvas)
            this.grbGafico.Controls.Add(panelPixel);
            panelPixel.BringToFront();

            // Opcional: ocultar el PictureBox original
            picCanvas.Visible = false;

            // Instanciar cPixel con el panel recién creado
            pixel = new cPixel(panelPixel);

            // Instanciar la lógica del algoritmo y pasar la referencia a cPixel
            algoritmo = new CPuntoMedio();
            algoritmo.InitializeData(txtXo, txtXf, txtYo, txtYf, pixel);
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            // Leer datos y ejecutar algoritmo si la lectura es correcta
            if (algoritmo.ReadData(txtXo, txtXf, txtYo, txtYf))
            {
                algoritmo.DrawPuntoMedio(pixel);
            }
        }

        private void BtnResetear_Click(object sender, EventArgs e)
        {
            // Limpiar y redibujar cuadrícula con cPixel
            if (pixel != null)
            {
                pixel.limpiar();
                pixel.dibujarCuadricula();
            }

            // Limpiar TextBox
            txtXo.Clear();
            txtYo.Clear();
            txtXf.Clear();
            txtYf.Clear();
            txtXo.Focus();

            // Reiniciar estado interno del algoritmo
            algoritmo = new CPuntoMedio();
            algoritmo.InitializeData(txtXo, txtXf, txtYo, txtYf, pixel);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}