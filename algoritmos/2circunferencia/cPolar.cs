using System;
using System.Drawing;
using System.Threading.Tasks;

namespace algoritmos
{
    public class cPolar
    {
        private cPixel pixel;
        public int velocidad = 10;

        public cPolar(cPixel pixel)
        {
            this.pixel = pixel;
        }


        // ALGORITMO POLAR (PARAMÉTRICO)
        // Usa funciones trigonométricas para calcular puntos del círculo
        // Fórmula: x = xc + r*cos(θ), y = yc + r*sin(θ)
        // Recorre de 0° a 360° con incrementos de 1°
        // Efecto visual: Barrido circular continuo

        // Algoritmo Polar para dibujar círculos
        public async Task CirculoPolar(int xc, int yc, int r)
        {
            double incremento = 1.0;
            
            for (double angulo = 0; angulo <= 360; angulo += incremento)
            {
                double radianes = angulo * Math.PI / 180.0;
                
                int x = (int)Math.Round(xc + r * Math.Cos(radianes));
                int y = (int)Math.Round(yc + r * Math.Sin(radianes));
                
                pixel.putpixel(x, y, Color.Blue);
                
                await Task.Delay(velocidad);
            }
        }

        // Algoritmo Boundary Fill (relleno por detección de borde)
        public void BoundaryFill(int x, int y, Color fillColor, Color borderColor)
        {
            Color pixelColor = pixel.getpixel(x, y);
            
            if (pixelColor.ToArgb() != borderColor.ToArgb() && 
                pixelColor.ToArgb() != fillColor.ToArgb())
            {
                pixel.putpixel(x, y, fillColor);
                
                BoundaryFill(x, y + 1, fillColor, borderColor); // Norte
                BoundaryFill(x + 1, y, fillColor, borderColor); // Este
                BoundaryFill(x, y - 1, fillColor, borderColor); // Sur
                BoundaryFill(x - 1, y, fillColor, borderColor); // Oeste
            }
        }
    }
}