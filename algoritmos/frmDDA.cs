using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace algoritmos
{
    public partial class frmDDA : Form
    {
        private cDDA algoritmo;
        private Bitmap lienzo;
        private Graphics g;
        private int centroX, centroY;
        private int escala = 20;
        private int fase = 0;

        private static frmDDA instancia;

        public frmDDA()
        {
            InitializeComponent();

            this.btnCalcular.Click += this.btnCalcular_Click;
            this.btnResetear.Click += this.btnResetear_Click;
            this.Load += this.DDA_Load;

            algoritmo = new cDDA();
            InicializarLienzo();
        }

        public static frmDDA ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new frmDDA();
            }
            return instancia;
        }

        private void DDA_Load(object sender, EventArgs e)
        {
            InicializarLienzo();
        }

        private void InicializarLienzo()
        {
            int anchoAjustado = (picCanvas.Width / escala) * escala;
            int altoAjustado = (picCanvas.Height / escala) * escala;

            picCanvas.Width = anchoAjustado;
            picCanvas.Height = altoAjustado;

            lienzo = new Bitmap(picCanvas.Width, picCanvas.Height);
            g = Graphics.FromImage(lienzo);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            centroX = (picCanvas.Width / escala / 2) * escala;
            centroY = (picCanvas.Height / escala / 2) * escala;

            DibujarCuadricula();
            picCanvas.Image = lienzo;
        }

        private void DibujarCuadricula()
        {
            g.Clear(Color.White);

            Pen lapizCuadricula = new Pen(Color.LightGray, 1);

            for (int i = 0; i <= picCanvas.Width; i += escala)
            {
                g.DrawLine(lapizCuadricula, i, 0, i, picCanvas.Height);
            }

            for (int i = 0; i <= picCanvas.Height; i += escala)
            {
                g.DrawLine(lapizCuadricula, 0, i, picCanvas.Width, i);
            }

            Pen lapizEjes = new Pen(Color.Black, 2);
            g.DrawLine(lapizEjes, centroX, 0, centroX, picCanvas.Height);
            g.DrawLine(lapizEjes, 0, centroY, picCanvas.Width, centroY);
        }

        private Point ConvertirCoordenadas(int x, int y)
        {
            int pantallaX = centroX + (x * escala);
            int pantallaY = centroY - (y * escala);
            return new Point(pantallaX, pantallaY);
        }

        private void DibujarPixel(int x, int y)
        {
            Point p = ConvertirCoordenadas(x, y);
            SolidBrush brocha = new SolidBrush(Color.Yellow);
            g.FillRectangle(brocha, p.X - escala / 2 + 1, p.Y - escala / 2 + 1, escala - 2, escala - 2);
        }

        private void DibujarLineaCompleta()
        {
            Point inicial = algoritmo.ObtenerPuntoInicial();
            Point actual = algoritmo.ObtenerPuntoActual();

            Point p1 = ConvertirCoordenadas(inicial.X, inicial.Y);
            Point p2 = ConvertirCoordenadas(actual.X, actual.Y);

            Pen lapiz = new Pen(Color.Red, 2);
            g.DrawLine(lapiz, p1, p2);
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            // Reiniciar el algoritmo
            algoritmo.Reiniciar();

            // Volver a fase inicial
            fase = 0;

            // Limpiar los TextBox
            txt1.Clear();
            txt2.Clear();
            txt3.Clear();
            txt4.Clear();

            // Redibujar solo la cuadrícula limpia
            DibujarCuadricula();
            picCanvas.Refresh();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (fase == 0)
                {
                    // FASE 0: Inicializar
                    int x1 = int.Parse(txt1.Text);
                    int y1 = int.Parse(txt2.Text);
                    int x2 = int.Parse(txt3.Text);
                    int y2 = int.Parse(txt4.Text);

                    DibujarCuadricula();
                    algoritmo.Inicializar(x1, y1, x2, y2);

                    Point actual = algoritmo.ObtenerPuntoActual();
                    DibujarPixel(actual.X, actual.Y);
                    picCanvas.Refresh();

                    fase = 1;
                }
                else if (fase == 1)
                {
                    algoritmo.CalcularSiguientePunto();
                    fase = 2;
                }
                else if (fase == 2)
                {
                    List<Point> pixeles = algoritmo.ObtenerPixelsEntreUltimoYActual();
                    foreach (var pixel in pixeles)
                    {
                        DibujarPixel(pixel.X, pixel.Y);
                    }
                    picCanvas.Refresh();

                    fase = 3;
                }
                else if (fase == 3)
                {
                    DibujarCuadricula();

                    List<Point> todosLosPixeles = cDDA.GenerarLineaPixels(
                        algoritmo.ObtenerPuntoInicial().X,
                        algoritmo.ObtenerPuntoInicial().Y,
                        algoritmo.ObtenerPuntoActual().X,
                        algoritmo.ObtenerPuntoActual().Y
                    );

                    foreach (var pixel in todosLosPixeles)
                    {
                        DibujarPixel(pixel.X, pixel.Y);
                    }

                    DibujarLineaCompleta();

                    picCanvas.Refresh();

                    if (algoritmo.EstaTerminado())
                    {
                        MessageBox.Show("Línea completada");
                        algoritmo.Reiniciar();
                        fase = 0;
                    }
                    else
                    {
                        fase = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}