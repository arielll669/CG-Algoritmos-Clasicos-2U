using System;
using System.Drawing;
using System.Windows.Forms;

namespace algoritmos
{
    public partial class frmPoligonoRelleno : Form
    {
        private cPixel pixel;
        private cPoligono poligono;
        private cRecursivo recursivo;
        private cPolar polar;
        private cEcuacion ecuacion;
        private static frmPoligonoRelleno instancia;

        public frmPoligonoRelleno()
        {
            InitializeComponent();
            this.Load += FrmPoligonoRelleno_Load;
        }

        public static frmPoligonoRelleno ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new frmPoligonoRelleno();
            }
            return instancia;
        }

        private void FrmPoligonoRelleno_Load(object sender, EventArgs e)
        {
            // Inicializar clases
            pixel = new cPixel(panelPoligono);
            poligono = new cPoligono(pixel);
            recursivo = new cRecursivo(pixel);
            polar = new cPolar(pixel);
            ecuacion = new cEcuacion(pixel);

            // Dibujar cuadrícula inicial
            pixel.dibujarCuadricula();

            // Deshabilitar botones de relleno hasta que se cierre el polígono
            btnFloodFill.Enabled = false;
            btnBoundaryFill.Enabled = false;
            btnFloodFillIterativo.Enabled = false;

            // Evento de clic en el panel para agregar vértices
            panelPoligono.MouseClick += PanelPoligono_MouseClick;
        }

        private void PanelPoligono_MouseClick(object sender, MouseEventArgs e)
        {
            // Solo agregar vértices si el polígono no está cerrado
            if (!poligono.poligonoCerrado)
            {
                // Convertir coordenadas del panel a coordenadas lógicas
                int celdasX = panelPoligono.Width / pixel.tamañoPixel;
                int celdasY = panelPoligono.Height / pixel.tamañoPixel;
                int centroX = (celdasX / 2) * pixel.tamañoPixel;
                int centroY = (celdasY / 2) * pixel.tamañoPixel;

                // Calcular coordenadas lógicas del clic
                int x = (e.X - centroX) / pixel.tamañoPixel;
                int y = (centroY - e.Y) / pixel.tamañoPixel;

                // Agregar vértice
                poligono.AgregarVertice(x, y);

                // Agregar a la lista
                lstPixeles.Items.Add($"Vértice {poligono.ObtenerNumeroVertices()}: ({x}, {y})");

                // Habilitar botón de cerrar si hay al menos 3 vértices
                if (poligono.ObtenerNumeroVertices() >= 3)
                {
                    btnCerrarPoligono.Enabled = true;
                }
            }
        }


        private void btnBoundaryFill_Click_1(object sender, EventArgs e)
        {
            if (poligono.poligonoCerrado)
            {
                lstPixeles.Items.Clear();
                lstPixeles.Items.Add("=== BOUNDARY FILL ===");

                // Aplicar Boundary Fill desde el centro (0,0)
                polar.BoundaryFill(0, 0, Color.LightGreen, Color.Black);

                lstPixeles.Items.Add("Relleno completado con Boundary Fill");
            }
        }

        private void btnFloodFill_Click_1(object sender, EventArgs e)
        {
            if (poligono.poligonoCerrado)
            {
                lstPixeles.Items.Clear();
                lstPixeles.Items.Add("=== FLOOD FILL RECURSIVO ===");

                // Aplicar Flood Fill Recursivo desde el centro (0,0)
                recursivo.mi_floodfill(0, 0, Color.LightBlue);

                lstPixeles.Items.Add("Relleno completado con Flood Fill Recursivo");
            }
        }

        private void btnFloodFillIterativo_Click_1(object sender, EventArgs e)
        {
            if (poligono.poligonoCerrado)
            {
                lstPixeles.Items.Clear();
                lstPixeles.Items.Add("=== FLOOD FILL ITERATIVO ===");

                // Aplicar Flood Fill Iterativo desde el centro (0,0)
                ecuacion.FloodFillIterativo(0, 0, Color.Yellow);

                lstPixeles.Items.Add("Relleno completado con Flood Fill Iterativo");
            }
            else
            {
                // Mensaje y registro para depuración
                MessageBox.Show("El polígono no está cerrado. Añade al menos 3 vértices y pulsa 'Cerrar Poligono'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstPixeles.Items.Add("Intento de FloodFillIterativo fallido: polígono no cerrado");
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            // Limpiar panel
            pixel.limpiar();
            pixel.dibujarCuadricula();

            // Limpiar polígono
            poligono.Limpiar();

            // Limpiar lista
            lstPixeles.Items.Clear();

            // Restablecer botones
            btnCerrarPoligono.Enabled = false;
            btnFloodFill.Enabled = false;
            btnBoundaryFill.Enabled = false;
            btnFloodFillIterativo.Enabled = false;
        }

        private void btnCerrarPoligono_Click_1(object sender, EventArgs e)
        {
            if (poligono.ObtenerNumeroVertices() >= 3 && !poligono.poligonoCerrado)
            {
                poligono.CerrarPoligono();
                lstPixeles.Items.Add("--- Polígono cerrado ---");

                // Deshabilitar botón de cerrar
                btnCerrarPoligono.Enabled = false;

                // Habilitar botones de relleno
                btnFloodFill.Enabled = true;
                btnBoundaryFill.Enabled = true;
                btnFloodFillIterativo.Enabled = true;
            }
        }
    }
}