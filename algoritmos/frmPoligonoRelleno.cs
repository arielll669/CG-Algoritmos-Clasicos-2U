using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace algoritmos
{
    public partial class frmPoligonoRelleno : Form
    {
        private cGrafico grafico;
        private cPoligono poligono;
        private cRellenoGrafico relleno;
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
            grafico = new cGrafico(panelPoligono);
            poligono = new cPoligono(grafico);
            relleno = new cRellenoGrafico(grafico);

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
                // Usar coordenadas directas del panel
                int x = e.X;
                int y = e.Y;

                // Detectar si el usuario hizo clic cerca del primer vértice (cierre automático)
                if (poligono.DetectarCierreAutomatico(x, y))
                {
                    // Cerrar el polígono
                    poligono.CerrarPoligono();
                    lstPixeles.Items.Add("--- Polígono cerrado automáticamente ---");

                    // Habilitar botones de relleno
                    btnFloodFill.Enabled = true;
                    btnBoundaryFill.Enabled = true;
                    btnFloodFillIterativo.Enabled = true;
                }
                else
                {
                    // Agregar vértice normal
                    poligono.AgregarVertice(x, y);

                    // Agregar a la lista
                    lstPixeles.Items.Add($"Vértice {poligono.ObtenerNumeroVertices()}: ({x}, {y})");
                }
            }
        }

        private void btnFloodFill_Click(object sender, EventArgs e)
        {
            if (poligono.poligonoCerrado)
            {
                lstPixeles.Items.Clear();
                lstPixeles.Items.Add("=== FLOOD FILL RECURSIVO ===");

                // Calcular punto interno del polígono (centro aproximado)
                List<Point> vertices = poligono.ObtenerVertices();
                int xCentro = 0, yCentro = 0;
                foreach (Point p in vertices)
                {
                    xCentro += p.X;
                    yCentro += p.Y;
                }
                xCentro /= vertices.Count;
                yCentro /= vertices.Count;

                // Aplicar Flood Fill Recursivo
                List<Point> pixelesPintados = relleno.FloodFillRecursivo(xCentro, yCentro, Color.LightBlue);

                lstPixeles.Items.Add($"Total de píxeles rellenados: {pixelesPintados.Count}");
                lstPixeles.Items.Add("Primeros 10 píxeles:");

                for (int i = 0; i < Math.Min(10, pixelesPintados.Count); i++)
                {
                    lstPixeles.Items.Add($"  ({pixelesPintados[i].X}, {pixelesPintados[i].Y})");
                }

                if (pixelesPintados.Count > 10)
                {
                    lstPixeles.Items.Add($"  ... y {pixelesPintados.Count - 10} más");
                }
            }
        }

        private void btnBoundaryFill_Click(object sender, EventArgs e)
        {
            if (poligono.poligonoCerrado)
            {
                lstPixeles.Items.Clear();
                lstPixeles.Items.Add("=== BOUNDARY FILL ===");

                // Calcular punto interno del polígono
                List<Point> vertices = poligono.ObtenerVertices();
                int xCentro = 0, yCentro = 0;
                foreach (Point p in vertices)
                {
                    xCentro += p.X;
                    yCentro += p.Y;
                }
                xCentro /= vertices.Count;
                yCentro /= vertices.Count;

                // Aplicar Boundary Fill
                List<Point> pixelesPintados = relleno.BoundaryFill(xCentro, yCentro, Color.LightGreen, Color.Black);

                lstPixeles.Items.Add($"Total de píxeles rellenados: {pixelesPintados.Count}");
                lstPixeles.Items.Add("Primeros 10 píxeles:");

                for (int i = 0; i < Math.Min(10, pixelesPintados.Count); i++)
                {
                    lstPixeles.Items.Add($"  ({pixelesPintados[i].X}, {pixelesPintados[i].Y})");
                }

                if (pixelesPintados.Count > 10)
                {
                    lstPixeles.Items.Add($"  ... y {pixelesPintados.Count - 10} más");
                }
            }
        }

        private void btnFloodFillIterativo_Click(object sender, EventArgs e)
        {
            if (poligono.poligonoCerrado)
            {
                lstPixeles.Items.Clear();
                lstPixeles.Items.Add("=== FLOOD FILL ITERATIVO ===");

                // Calcular punto interno del polígono
                List<Point> vertices = poligono.ObtenerVertices();
                int xCentro = 0, yCentro = 0;
                foreach (Point p in vertices)
                {
                    xCentro += p.X;
                    yCentro += p.Y;
                }
                xCentro /= vertices.Count;
                yCentro /= vertices.Count;

                // Aplicar Flood Fill Iterativo
                List<Point> pixelesPintados = relleno.FloodFillIterativo(xCentro, yCentro, Color.Yellow);

                lstPixeles.Items.Add($"Total de píxeles rellenados: {pixelesPintados.Count}");
                lstPixeles.Items.Add("Primeros 10 píxeles:");

                for (int i = 0; i < Math.Min(10, pixelesPintados.Count); i++)
                {
                    lstPixeles.Items.Add($"  ({pixelesPintados[i].X}, {pixelesPintados[i].Y})");
                }

                if (pixelesPintados.Count > 10)
                {
                    lstPixeles.Items.Add($"  ... y {pixelesPintados.Count - 10} más");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar panel
            grafico.Limpiar();

            // Limpiar polígono
            poligono.Limpiar();

            // Limpiar lista
            lstPixeles.Items.Clear();

            // Restablecer botones
            btnFloodFill.Enabled = false;
            btnBoundaryFill.Enabled = false;
            btnFloodFillIterativo.Enabled = false;
        }
    }
}