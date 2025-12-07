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
    public partial class frmCircunferencia1 : Form
    {
        private cPixel pixel;
        private cRecursivo recursivo;
        private static frmCircunferencia1 instancia;
        public frmCircunferencia1()
        {
            InitializeComponent();
            // Inicializar después de que el panel esté creado
            this.Load += Circunferencia1_Load;
        }


        public static frmCircunferencia1 ObtenerInstancia()
        {
            // Si la instancia es nula O si ya ha sido cerrada/eliminada
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new frmCircunferencia1();
            }
            return instancia;
        }


        private void Circunferencia1_Load(object sender, EventArgs e)
        {
            // Inicializar las clases
            pixel = new cPixel(panelCircunferencia);
            recursivo = new cRecursivo(pixel);

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

                // Dibujar el borde del círculo con animación (AWAIT aquí)
                await recursivo.CircleMidPoint(0, 0, radio);

                // Rellenar desde el centro
                recursivo.mi_floodfill(0, 0, Color.LightBlue);

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
