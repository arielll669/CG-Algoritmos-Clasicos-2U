using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace algoritmos
{
    public class cIterativo
    {
        private cPixel pixel;
        public int velocidad = 10;

        // Constructor
        public cIterativo(cPixel pixel)
        {
            this.pixel = pixel;
        }
        // ALGORITMO DE ECUACIÓN EXPLÍCITA
        // Calcula puntos usando la ecuación del círculo: x² + y² = r²
        // Despeja: y = √(r² - x²) y x = √(r² - y²)
        // Recorre primero en X (vertical) y luego en Y (horizontal)
        // Efecto visual: Barrido vertical seguido de horizontal


        // Algoritmo de Ecuación Explícita (barrido vertical)
        public async Task CirculoEcuacionExplicita(int xc, int yc, int r)
        {
            for (int x = -r; x <= r; x++)
            {
                // Calcular Y usando la ecuación del círculo: y = √(r² - x²)
                double yCalculado = Math.Sqrt(r * r - x * x);

                int y1 = (int)Math.Round(yCalculado);
                int y2 = (int)Math.Round(-yCalculado);

                pixel.putpixel(xc + x, yc + y1, Color.Red);
                pixel.putpixel(xc + x, yc + y2, Color.Red);

                await Task.Delay(velocidad);
            }

            for (int y = -r; y <= r; y++)
            {
                // Calcular X usando la ecuación del círculo: x = √(r² - y²)
                double xCalculado = Math.Sqrt(r * r - y * y);

                // Dibujar los dos puntos simétricos (izquierda y derecha)
                int x1 = (int)Math.Round(xCalculado);
                int x2 = (int)Math.Round(-xCalculado);

                pixel.putpixel(xc + x1, yc + y, Color.Red);
                pixel.putpixel(xc + x2, yc + y, Color.Red);

                await Task.Delay(velocidad);
            }
        }

        // Flood Fill Iterativo usando Queue (NO recursivo)
        public void FloodFillIterativo(int x, int y, Color fillColor)
        {
            Color targetColor = pixel.getpixel(x, y);

            if (targetColor.ToArgb() == fillColor.ToArgb() ||
                targetColor.ToArgb() == Color.Red.ToArgb())
            {
                return;
            }

            Queue<Point> cola = new Queue<Point>();
            cola.Enqueue(new Point(x, y));

            while (cola.Count > 0)
            {
                Point punto = cola.Dequeue();
                int px = punto.X;
                int py = punto.Y;

                Color colorActual = pixel.getpixel(px, py);

                if (colorActual.ToArgb() == targetColor.ToArgb())
                {
                    pixel.putpixel(px, py, fillColor);

                    cola.Enqueue(new Point(px, py + 1)); // Norte
                    cola.Enqueue(new Point(px + 1, py)); // Este
                    cola.Enqueue(new Point(px, py - 1)); // Sur
                    cola.Enqueue(new Point(px - 1, py)); // Oeste
                }
            }
        }
    }
}