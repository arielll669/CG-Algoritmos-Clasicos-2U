using System;
using System.Drawing;
using System.Windows.Forms;

namespace algoritmos
{
    public partial class frmCircunferencia3 : Form
    {
        private cPixel pixel;
        private cIterativo iterativo;
        private static frmCircunferencia3 instancia;

        public frmCircunferencia3()
        {
            InitializeComponent();
            this.Load += Circunferencia3_Load;
        }

        public static frmCircunferencia3 ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new frmCircunferencia3();
            }
            return instancia;
        }

        private void Circunferencia3_Load(object sender, EventArgs e)
        {
            // Inicializar las clases
            pixel = new cPixel(panelCircunferencia);
            iterativo = new cIterativo(pixel);

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

                // Dibujar el borde del círculo con Ecuación Explícita (AWAIT aquí)
                await iterativo.CirculoEcuacionExplicita(0, 0, radio);

                // Rellenar desde el centro con Flood Fill Iterativo
                iterativo.FloodFillIterativo(0, 0, Color.Yellow);

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