using System;
using System.Drawing;
using System.Windows.Forms;

namespace algoritmos
{
    public partial class frmCircunferencia2 : Form
    {
        private cPixel pixel;
        private cPolar polar;
        private static frmCircunferencia2 instancia;

        public frmCircunferencia2()
        {
            InitializeComponent();
            this.Load += Circunferencia2_Load;
        }

        public static frmCircunferencia2 ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new frmCircunferencia2();
            }
            return instancia;
        }

        private void Circunferencia2_Load(object sender, EventArgs e)
        {
            // Inicializar las clases
            pixel = new cPixel(panelCircunferencia);
            polar = new cPolar(pixel);

            // Dibujar cuadrícula inicial
            pixel.dibujarCuadricula();
        }




        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar entrada
                if (string.IsNullOrWhiteSpace(txtRadio.Text))
                {
                    MessageBox.Show("Por favor ingrese un radio", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int radio = int.Parse(txtRadio.Text);

                if (radio <= 0)
                {
                    MessageBox.Show("El radio debe ser mayor a 0", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Deshabilitar botones durante el proceso
                btnCalcular.Enabled = false;
                btnResetear.Enabled = false;

                // Limpiar y redibujar cuadrícula
                pixel.limpiar();
                pixel.dibujarCuadricula();

                // Dibujar el borde del círculo con algoritmo Polar (AWAIT aquí)
                await polar.CirculoPolar(0, 0, radio);

                // Rellenar desde el centro con Boundary Fill
                polar.BoundaryFill(0, 0, Color.LightGreen, Color.Blue);

                // Rehabilitar botones
                btnCalcular.Enabled = true;
                btnResetear.Enabled = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese un número válido", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCalcular.Enabled = true;
                btnResetear.Enabled = true;
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            // Limpiar panel
            pixel.limpiar();
            pixel.dibujarCuadricula();

            // Limpiar textbox
            txtRadio.Clear();
            txtRadio.Focus();
        }
    }
}