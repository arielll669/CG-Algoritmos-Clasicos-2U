using System;
using System.Collections.Generic;
using System.Drawing;

namespace algoritmos
{
    public class cRellenoGrafico
    {
        private cGrafico grafico;

        // Constructor
        public cRellenoGrafico(cGrafico grafico)
        {
            this.grafico = grafico;
        }

        // ALGORITMO 1: Flood Fill Recursivo
        public List<Point> FloodFillRecursivo(int x, int y, Color colorRelleno)
        {
            List<Point> pixelesPintados = new List<Point>();
            Color colorObjetivo = grafico.ObtenerColor(x, y);

            // Si el color objetivo es el mismo que el de relleno o es negro (borde), no hacer nada
            if (colorObjetivo.ToArgb() == colorRelleno.ToArgb() ||
                colorObjetivo.ToArgb() == Color.Black.ToArgb())
            {
                return pixelesPintados;
            }

            FloodFillRecursivoInterno(x, y, colorObjetivo, colorRelleno, pixelesPintados);
            grafico.Refrescar();

            return pixelesPintados;
        }

        private void FloodFillRecursivoInterno(int x, int y, Color colorObjetivo, Color colorRelleno, List<Point> pixelesPintados)
        {
            // Verificar límites
            if (x < 0 || x >= grafico.ObtenerAncho() || y < 0 || y >= grafico.ObtenerAlto())
                return;

            Color colorActual = grafico.ObtenerColor(x, y);

            // Si el pixel es del color objetivo (no es borde ni ya rellenado)
            if (colorActual.ToArgb() == colorObjetivo.ToArgb())
            {
                grafico.PintarPixel(x, y, colorRelleno);
                pixelesPintados.Add(new Point(x, y));

                // Recursión en 4 direcciones
                FloodFillRecursivoInterno(x, y + 1, colorObjetivo, colorRelleno, pixelesPintados);
                FloodFillRecursivoInterno(x + 1, y, colorObjetivo, colorRelleno, pixelesPintados);
                FloodFillRecursivoInterno(x, y - 1, colorObjetivo, colorRelleno, pixelesPintados);
                FloodFillRecursivoInterno(x - 1, y, colorObjetivo, colorRelleno, pixelesPintados);
            }
        }

        // ALGORITMO 2: Boundary Fill
        public List<Point> BoundaryFill(int x, int y, Color colorRelleno, Color colorBorde)
        {
            List<Point> pixelesPintados = new List<Point>();
            BoundaryFillInterno(x, y, colorRelleno, colorBorde, pixelesPintados);
            grafico.Refrescar();

            return pixelesPintados;
        }

        private void BoundaryFillInterno(int x, int y, Color colorRelleno, Color colorBorde, List<Point> pixelesPintados)
        {
            // Verificar límites
            if (x < 0 || x >= grafico.ObtenerAncho() || y < 0 || y >= grafico.ObtenerAlto())
                return;

            Color colorActual = grafico.ObtenerColor(x, y);

            // Si el pixel NO es del color del borde Y NO está ya rellenado
            if (colorActual.ToArgb() != colorBorde.ToArgb() &&
                colorActual.ToArgb() != colorRelleno.ToArgb())
            {
                grafico.PintarPixel(x, y, colorRelleno);
                pixelesPintados.Add(new Point(x, y));

                // Recursión en 4 direcciones
                BoundaryFillInterno(x, y + 1, colorRelleno, colorBorde, pixelesPintados);
                BoundaryFillInterno(x + 1, y, colorRelleno, colorBorde, pixelesPintados);
                BoundaryFillInterno(x, y - 1, colorRelleno, colorBorde, pixelesPintados);
                BoundaryFillInterno(x - 1, y, colorRelleno, colorBorde, pixelesPintados);
            }
        }

        // ALGORITMO 3: Flood Fill Iterativo (con Queue)
        public List<Point> FloodFillIterativo(int x, int y, Color colorRelleno)
        {
            List<Point> pixelesPintados = new List<Point>();
            Color colorObjetivo = grafico.ObtenerColor(x, y);

            // Si ya es del color de relleno o es el borde, no hacer nada
            if (colorObjetivo.ToArgb() == colorRelleno.ToArgb() ||
                colorObjetivo.ToArgb() == Color.Black.ToArgb())
            {
                return pixelesPintados;
            }

            // Crear una cola para almacenar los puntos pendientes
            Queue<Point> cola = new Queue<Point>();
            cola.Enqueue(new Point(x, y));

            while (cola.Count > 0)
            {
                Point punto = cola.Dequeue();
                int px = punto.X;
                int py = punto.Y;

                // Verificar límites
                if (px < 0 || px >= grafico.ObtenerAncho() || py < 0 || py >= grafico.ObtenerAlto())
                    continue;

                Color colorActual = grafico.ObtenerColor(px, py);

                // Verificar si el punto es válido para pintar
                if (colorActual.ToArgb() == colorObjetivo.ToArgb())
                {
                    grafico.PintarPixel(px, py, colorRelleno);
                    pixelesPintados.Add(new Point(px, py));

                    // Agregar los 4 vecinos a la cola
                    cola.Enqueue(new Point(px, py + 1));
                    cola.Enqueue(new Point(px + 1, py));
                    cola.Enqueue(new Point(px, py - 1));
                    cola.Enqueue(new Point(px - 1, py));
                }
            }

            grafico.Refrescar();
            return pixelesPintados;
        }
    }
}