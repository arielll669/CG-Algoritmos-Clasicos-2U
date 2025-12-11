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
    public partial class frmRecorte : Form
    {
        private static frmRecorte instancia;

        private Bitmap bitmap;
        private Graphics graphics;
        private List<cPunto> puntosPoligono;
        private List<cPunto> ventanaRecorte;
        private bool poligonoCerrado;
        private bool recorteRealizado;

        private Color colorVentana = Color.Red;
        private Color colorPoligonoOriginal = Color.Blue;
        private Color colorPoligonoRecortado = Color.Green;
        private Color colorInterseccion = Color.Yellow;
        private Color colorFondo = Color.White;

        private const int TOLERANCIA_CIERRE = 10;
        public frmRecorte()
        {
            InitializeComponent();
            panelRecorte.MouseClick += panelRecorte_MouseClick;
            InicializarCanvas();
            CargarFigurasRecorte();
        }

        public static frmRecorte ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new frmRecorte();
            }
            return instancia;
        }

        private void InicializarCanvas()
        {
            bitmap = new Bitmap(panelRecorte.Width, panelRecorte.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(colorFondo);
            panelRecorte.BackgroundImage = bitmap;

            puntosPoligono = new List<cPunto>();
            poligonoCerrado = false;
            recorteRealizado = false;

            lblInstrucciones.Text = "Selecciona una figura de recorte y dibuja tu polígono";
            lblCantidadVertices.Text = "Vértices recortados: 0";
            lblCantidadIntersecciones.Text = "Intersecciones: 0";
            lstVerticesRecortados.Items.Clear();
            lstIntersecciones.Items.Clear();
        }

        private void CargarFigurasRecorte()
        {
            cboFiguraRecorte.Items.Clear();
            cboFiguraRecorte.Items.Add("Rectángulo");
            cboFiguraRecorte.Items.Add("Hexágono");
            cboFiguraRecorte.Items.Add("Estrella");
            cboFiguraRecorte.SelectedIndex = 0;
        }

        private void cboFiguraRecorte_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarVentanaRecorte();
            RedibujarTodo();
        }

        private void GenerarVentanaRecorte()
        {
            string figuraSeleccionada = cboFiguraRecorte.SelectedItem.ToString();

            switch (figuraSeleccionada)
            {
                case "Rectángulo":
                    ventanaRecorte = cFigurasRecorte.GenerarRectangulo(panelRecorte.Width, panelRecorte.Height, 300, 250);
                    break;
                case "Hexágono":
                    ventanaRecorte = cFigurasRecorte.GenerarHexagono(panelRecorte.Width, panelRecorte.Height, 150);
                    break;
                case "Estrella":
                    ventanaRecorte = cFigurasRecorte.GenerarEstrella(panelRecorte.Width, panelRecorte.Height, 150);
                    break;
            }
        }


        private void panelRecorte_MouseClick(object sender, MouseEventArgs e)
        {
            if (poligonoCerrado || recorteRealizado)
                return;

            cPunto puntoActual = new cPunto(e.X, e.Y);

            if (puntosPoligono.Count == 0)
            {
                puntosPoligono.Add(puntoActual);
                DibujarPunto(puntoActual, colorPoligonoOriginal, 5);
                lblInstrucciones.Text = "Click cerca del punto inicial para cerrar";
            }
            else
            {
                if (puntosPoligono.Count >= 3 && puntoActual.DistanciaA(puntosPoligono[0]) < TOLERANCIA_CIERRE)
                {
                    CerrarPoligono();
                }
                else
                {
                    DibujarLinea(puntosPoligono[puntosPoligono.Count - 1], puntoActual, colorPoligonoOriginal);
                    puntosPoligono.Add(puntoActual);
                    DibujarPunto(puntoActual, colorPoligonoOriginal, 3);
                }
            }

            panelRecorte.Invalidate();
        }

        private void CerrarPoligono()
        {
            DibujarLinea(puntosPoligono[puntosPoligono.Count - 1], puntosPoligono[0], colorPoligonoOriginal);
            poligonoCerrado = true;
            lblInstrucciones.Text = "Polígono cerrado. Click en 'Recortar' para aplicar el algoritmo";
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            if (!poligonoCerrado)
            {
                MessageBox.Show("Primero debes cerrar el polígono", "Advertencia");
                return;
            }

            if (ventanaRecorte == null || ventanaRecorte.Count == 0)
            {
                MessageBox.Show("Selecciona una figura de recorte", "Advertencia");
                return;
            }

            // Ejecutar el algoritmo
            ResultadoRecorte resultado = cSutherlandHodgman.Recortar(puntosPoligono, ventanaRecorte);

            // Redibujar todo
            graphics.Clear(colorFondo);
            DibujarVentanaRecorte();

            // Dibujar polígono original atenuado
            DibujarPoligono(puntosPoligono, Color.LightGray, 1);

            // Dibujar polígono recortado
            if (resultado.PoligonoRecortado.Count > 0)
            {
                DibujarPoligono(resultado.PoligonoRecortado, colorPoligonoRecortado, 3);
                RellenarPoligono(resultado.PoligonoRecortado, Color.FromArgb(100, colorPoligonoRecortado));
            }

            // Dibujar puntos de intersección
            foreach (cPunto interseccion in resultado.PuntosInterseccion)
            {
                DibujarPunto(interseccion, colorInterseccion, 6);
            }

            // Actualizar listas
            MostrarResultados(resultado);

            recorteRealizado = true;
            lblInstrucciones.Text = "Recorte completado. Click en 'Limpiar' para empezar de nuevo";
            panelRecorte.Invalidate();
        }

        private void MostrarResultados(ResultadoRecorte resultado)
        {
            lstVerticesRecortados.Items.Clear();
            lstIntersecciones.Items.Clear();

            lblCantidadVertices.Text = $"Vértices recortados: {resultado.PoligonoRecortado.Count}";
            lblCantidadIntersecciones.Text = $"Intersecciones: {resultado.PuntosInterseccion.Count}";

            foreach (cPunto vertice in resultado.PoligonoRecortado)
            {
                lstVerticesRecortados.Items.Add(vertice.ToString());
            }

            foreach (cPunto interseccion in resultado.PuntosInterseccion)
            {
                lstIntersecciones.Items.Add(interseccion.ToString());
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            InicializarCanvas();
            GenerarVentanaRecorte();
            RedibujarTodo();
        }

        private void RedibujarTodo()
        {
            graphics.Clear(colorFondo);
            DibujarVentanaRecorte();

            if (puntosPoligono.Count > 0)
            {
                DibujarPoligono(puntosPoligono, colorPoligonoOriginal, 2);
            }

            panelRecorte.Invalidate();
        }

        private void DibujarVentanaRecorte()
        {
            if (ventanaRecorte != null && ventanaRecorte.Count > 0)
            {
                DibujarPoligono(ventanaRecorte, colorVentana, 2);
            }
        }

        private void DibujarPoligono(List<cPunto> vertices, Color color, int grosor)
        {
            if (vertices.Count < 2)
                return;

            using (Pen pen = new Pen(color, grosor))
            {
                for (int i = 0; i < vertices.Count; i++)
                {
                    cPunto p1 = vertices[i];
                    cPunto p2 = vertices[(i + 1) % vertices.Count];
                    DibujarLinea(p1, p2, color, grosor);
                }
            }
        }

        private void RellenarPoligono(List<cPunto> vertices, Color color)
        {
            if (vertices.Count < 3)
                return;

            Point[] puntos = new Point[vertices.Count];
            for (int i = 0; i < vertices.Count; i++)
            {
                puntos[i] = new Point(vertices[i].X, vertices[i].Y);
            }

            using (SolidBrush brush = new SolidBrush(color))
            {
                graphics.FillPolygon(brush, puntos);
            }
        }

        private void DibujarLinea(cPunto p1, cPunto p2, Color color, int grosor = 2)
        {
            using (Pen pen = new Pen(color, grosor))
            {
                graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
            }
        }

        private void DibujarPunto(cPunto punto, Color color, int tamaño)
        {
            using (SolidBrush brush = new SolidBrush(color))
            {
                graphics.FillEllipse(brush, punto.X - tamaño / 2, punto.Y - tamaño / 2, tamaño, tamaño);
            }
        }
    }
}
