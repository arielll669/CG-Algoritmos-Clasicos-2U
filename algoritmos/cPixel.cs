using System;
using System.Drawing;
using System.Windows.Forms;

namespace algoritmos
{
    public class cPixel
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private Panel panel;
        public int tamañoPixel = 15; // Aumentado a 20 para ver mejor

        // Constructor
        public cPixel(Panel panel)
        {
            this.panel = panel;

            // Activar double buffering en el panel
            panel.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic)
                .SetValue(panel, true, null);

            bitmap = new Bitmap(panel.Width, panel.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            panel.BackgroundImage = bitmap;
        }

        // Dibuja un pixel en coordenadas lógicas
        public void putpixel(int x, int y, Color color)
        {
            // Calcular el centro en términos de celdas completas
            int celdasX = panel.Width / tamañoPixel;
            int celdasY = panel.Height / tamañoPixel;
            int centroX = (celdasX / 2) * tamañoPixel;
            int centroY = (celdasY / 2) * tamañoPixel;

            // Calcular posición del pixel alineada a la cuadrícula
            int pixelX = centroX + (x * tamañoPixel);
            int pixelY = centroY - (y * tamañoPixel);

            using (SolidBrush brush = new SolidBrush(color))
            {
                graphics.FillRectangle(brush, pixelX, pixelY, tamañoPixel, tamañoPixel);
            }

            panel.Refresh();
        }

        public Color getpixel(int x, int y)
        {
            int celdasX = panel.Width / tamañoPixel;
            int celdasY = panel.Height / tamañoPixel;
            int centroX = (celdasX / 2) * tamañoPixel;
            int centroY = (celdasY / 2) * tamañoPixel;

            int pixelX = centroX + (x * tamañoPixel);
            int pixelY = centroY - (y * tamañoPixel);

            if (pixelX < 0 || pixelX >= bitmap.Width || pixelY < 0 || pixelY >= bitmap.Height)
                return Color.White;

            // Leer desde el centro del pixel
            return bitmap.GetPixel(pixelX + 1, pixelY + 1);
        }

        public void limpiar()
        {
            graphics.Clear(Color.White);
            panel.Refresh();
        }

        public void dibujarCuadricula()
        {
            Pen penGrid = new Pen(Color.LightGray, 1);
            Pen penEjes = new Pen(Color.Black, 2);

            // Calcular el centro en términos de celdas completas
            int celdasX = panel.Width / tamañoPixel;
            int celdasY = panel.Height / tamañoPixel;
            int centroX = (celdasX / 2) * tamañoPixel;
            int centroY = (celdasY / 2) * tamañoPixel;

            // Dibujar cuadrícula vertical
            for (int i = 0; i <= panel.Width; i += tamañoPixel)
            {
                graphics.DrawLine(penGrid, i, 0, i, panel.Height);
            }

            // Dibujar cuadrícula horizontal
            for (int i = 0; i <= panel.Height; i += tamañoPixel)
            {
                graphics.DrawLine(penGrid, 0, i, panel.Width, i);
            }

            // Dibujar ejes centrados en la cuadrícula
            graphics.DrawLine(penEjes, centroX, 0, centroX, panel.Height); // Eje Y
            graphics.DrawLine(penEjes, 0, centroY, panel.Width, centroY); // Eje X

            panel.Refresh();
        }
    }
}