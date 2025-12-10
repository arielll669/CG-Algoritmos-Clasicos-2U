using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace algoritmos
{
    public partial class frmPoligonoRelleno : Form
    {
        private static frmPoligonoRelleno instancia;

        private Bitmap bitmap;
        private Graphics graphics;
        private List<cPunto> puntosPoligono;
        private bool poligonoCerrado;
        private Color colorBorde = Color.Black;
        private Color colorRelleno = Color.Blue;
        private Color colorFondo = Color.White;
        private const int TOLERANCIA_CIERRE = 10;
        private bool modoRelleno = false;
        private string algoritmoSeleccionado = "";

        public frmPoligonoRelleno()
        {
            InitializeComponent();
            InicializarCanvas();
        }

        public static frmPoligonoRelleno ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new frmPoligonoRelleno();
            }
            return instancia;
        }

        private void InicializarCanvas()
        {
            bitmap = new Bitmap(panelPoligono.Width, panelPoligono.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(colorFondo);
            panelPoligono.BackgroundImage = bitmap;

            puntosPoligono = new List<cPunto>();
            poligonoCerrado = false;

            lblInstrucciones.Text = "Click para dibujar líneas del polígono";
            lblCantidadPixeles.Text = "Píxeles pintados: 0";
            lstPixeles.Items.Clear();
        }

private void panelPoligono_MouseClick(object sender, MouseEventArgs e)
{
    // Si está en modo relleno, rellenar desde donde hizo click
    if (modoRelleno)
    {
        cPunto puntoClick = new cPunto(e.X, e.Y);
        EjecutarRelleno(puntoClick);
        modoRelleno = false;
        lblInstrucciones.Text = "Click para dibujar líneas del polígono";
        return;
    }

    // Modo dibujo normal
    if (poligonoCerrado)
        return;

    cPunto puntoActual = new cPunto(e.X, e.Y);

    // Si es el primer punto
    if (puntosPoligono.Count == 0)
    {
        puntosPoligono.Add(puntoActual);
        DibujarPunto(puntoActual, colorBorde, 5);
        lblInstrucciones.Text = "Click cerca del punto inicial para cerrar (opcional)";
    }
    else
    {
        // Verificar si está cerca del punto inicial para cerrar
        if (puntosPoligono.Count >= 3 && puntoActual.DistanciaA(puntosPoligono[0]) < TOLERANCIA_CIERRE)
        {
            CerrarPoligono();
        }
        else
        {
            // Dibujar línea desde el último punto al actual
            DibujarLinea(puntosPoligono[puntosPoligono.Count - 1], puntoActual);
            puntosPoligono.Add(puntoActual);
            DibujarPunto(puntoActual, colorBorde, 3);
        }
    }

    panelPoligono.Invalidate();
}

        private void CerrarPoligono()
        {
            // Dibujar línea final conectando al primer punto
            DibujarLinea(puntosPoligono[puntosPoligono.Count - 1], puntosPoligono[0]);
            poligonoCerrado = true;
            lblInstrucciones.Text = "Polígono cerrado. Selecciona un algoritmo de relleno";
        }

        private void DibujarLinea(cPunto p1, cPunto p2)
        {
            List<Point> pixeles = cBresenham.GenerarLineaPixels(p1.X, p1.Y, p2.X, p2.Y);

            foreach (Point p in pixeles)
            {
                if (p.X >= 0 && p.X < bitmap.Width && p.Y >= 0 && p.Y < bitmap.Height)
                {
                    bitmap.SetPixel(p.X, p.Y, colorBorde);
                }
            }
        }

        private void DibujarPunto(cPunto punto, Color color, int tamaño)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillEllipse(new SolidBrush(color), punto.X - tamaño / 2, punto.Y - tamaño / 2, tamaño, tamaño);
            }
        }

        private void btnFloodFillRecursivo_Click(object sender, EventArgs e)
        {
            if (puntosPoligono.Count < 3)
            {
                MessageBox.Show("Dibuja al menos 3 puntos", "Advertencia");
                return;
            }

            modoRelleno = true;
            algoritmoSeleccionado = "FloodFillRecursivo";
            lblInstrucciones.Text = "Click DENTRO del área que deseas rellenar";
            panelPoligono.Cursor = Cursors.Cross;
        }

        private void btnFloodFillIterativo_Click(object sender, EventArgs e)
        {
            if (puntosPoligono.Count < 3)
            {
                MessageBox.Show("Dibuja al menos 3 puntos", "Advertencia");
                return;
            }

            modoRelleno = true;
            algoritmoSeleccionado = "FloodFillIterativo";
            lblInstrucciones.Text = "Click DENTRO del área que deseas rellenar";
            panelPoligono.Cursor = Cursors.Cross;
        }

        private void btnBoundaryFill_Click(object sender, EventArgs e)
        {
            if (puntosPoligono.Count < 3)
            {
                MessageBox.Show("Dibuja al menos 3 puntos", "Advertencia");
                return;
            }

            modoRelleno = true;
            algoritmoSeleccionado = "BoundaryFill";
            lblInstrucciones.Text = "Click DENTRO del área que deseas rellenar";
            panelPoligono.Cursor = Cursors.Cross;
        }
        private void EjecutarRelleno(cPunto puntoInicio)
        {
            List<cPunto> pixeles = new List<cPunto>();

            try
            {
                switch (algoritmoSeleccionado)
                {
                    case "FloodFillRecursivo":
                        pixeles = cFloodFillRecursivo.Rellenar(bitmap, puntoInicio, colorRelleno, colorBorde);
                        break;
                    case "FloodFillIterativo":
                        pixeles = cFloodFillIterativo.Rellenar(bitmap, puntoInicio, colorRelleno, colorBorde);
                        break;
                    case "BoundaryFill":
                        pixeles = cBoundaryFill.Rellenar(bitmap, puntoInicio, colorRelleno, colorBorde);
                        break;
                }

                MostrarPixeles(pixeles);
                panelPoligono.Invalidate();
                panelPoligono.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al rellenar: {ex.Message}", "Error");
                panelPoligono.Cursor = Cursors.Default;
            }
        }


        private cPunto CalcularCentroide()
        {
            int sumX = 0, sumY = 0;
            foreach (cPunto p in puntosPoligono)
            {
                sumX += p.X;
                sumY += p.Y;
            }
            return new cPunto(sumX / puntosPoligono.Count, sumY / puntosPoligono.Count);
        }

        private void MostrarPixeles(List<cPunto> pixeles)
        {
            lstPixeles.Items.Clear();
            lblCantidadPixeles.Text = $"Píxeles pintados: {pixeles.Count}";

            // Limitar cantidad mostrada para no saturar el ListBox
            int limite = Math.Min(pixeles.Count, 1000);

            for (int i = 0; i < limite; i++)
            {
                lstPixeles.Items.Add(pixeles[i].ToString());
            }

            if (pixeles.Count > limite)
            {
                lstPixeles.Items.Add($"... y {pixeles.Count - limite} más");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            InicializarCanvas();
            panelPoligono.Invalidate();
            modoRelleno = false;
            panelPoligono.Cursor = Cursors.Default; // Agregar esta línea
        }
    }
}