using System;
using System.Drawing;
using System.Windows.Forms;

namespace algoritmos
{
    public class cGrafico
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private Panel panel;

        // Constructor
        public cGrafico(Panel panel)
        {
            this.panel = panel;

            // Activar double buffering en el panel
            panel.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic)
                .SetValue(panel, true, null);

            bitmap = new Bitmap(panel.Width, panel.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
            panel.BackgroundImage = bitmap;
        }

        // Dibujar un punto
        public void DibujarPunto(int x, int y, Color color, int tamaño = 4)
        {
            using (SolidBrush brush = new SolidBrush(color))
            {
                graphics.FillEllipse(brush, x - tamaño / 2, y - tamaño / 2, tamaño, tamaño);
            }
            panel.Refresh();
        }

        // Dibujar una línea
        public void DibujarLinea(int x1, int y1, int x2, int y2, Color color, int grosor = 2)
        {
            using (Pen pen = new Pen(color, grosor))
            {
                graphics.DrawLine(pen, x1, y1, x2, y2);
            }
            panel.Refresh();
        }

        // Obtener color de un pixel
        public Color ObtenerColor(int x, int y)
        {
            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                return Color.White;

            return bitmap.GetPixel(x, y);
        }

        // Pintar un pixel (para algoritmos de relleno)
        public void PintarPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < bitmap.Width && y >= 0 && y < bitmap.Height)
            {
                bitmap.SetPixel(x, y, color);
            }
        }

        // Refrescar el panel (llamar después de usar PintarPixel múltiples veces)
        public void Refrescar()
        {
            panel.Refresh();
        }

        // Limpiar el panel
        public void Limpiar()
        {
            graphics.Clear(Color.White);
            panel.Refresh();
        }

        // Obtener dimensiones del panel
        public int ObtenerAncho()
        {
            return panel.Width;
        }

        public int ObtenerAlto()
        {
            return panel.Height;
        }
    }
}