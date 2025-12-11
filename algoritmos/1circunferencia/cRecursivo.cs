using System;
using System.Drawing;
using System.Threading.Tasks;

namespace algoritmos
{
    public class cRecursivo
    {
        private cPixel pixel;
        public int velocidad = 25; 

        public cRecursivo(cPixel pixel)
        {
            this.pixel = pixel;
        }

        async Task PlotPoint(int xc, int yc, int x, int y)
        {
            pixel.putpixel(xc + x, yc + y, Color.Black);
            await Task.Delay(velocidad);

            pixel.putpixel(xc - x, yc + y, Color.Black);
            await Task.Delay(velocidad);

            pixel.putpixel(xc + x, yc - y, Color.Black);
            await Task.Delay(velocidad);

            pixel.putpixel(xc - x, yc - y, Color.Black);
            await Task.Delay(velocidad);

            pixel.putpixel(xc + y, yc + x, Color.Black);
            await Task.Delay(velocidad);

            pixel.putpixel(xc - y, yc + x, Color.Black);
            await Task.Delay(velocidad);

            pixel.putpixel(xc + y, yc - x, Color.Black);
            await Task.Delay(velocidad);

            pixel.putpixel(xc - y, yc - x, Color.Black);
            await Task.Delay(velocidad);
        }

        public async Task CircleMidPoint(int xc, int yc, int r)
        {
            int x, y, p;
            x = 0;
            y = r;
            p = 1 - r;
            await PlotPoint(xc, yc, x, y);

            while (x < y)
            {
                x = x + 1;
                if (p < 0)
                    p = p + 2 * x + 3;
                else
                {
                    y = y - 1;
                    p = p + 2 * (x - y) + 5;
                }
                await PlotPoint(xc, yc, x, y);
            }
        }

        public void mi_floodfill(int x, int y, Color color)
        {
            Color pixelColor = pixel.getpixel(x, y);

            if (pixelColor.ToArgb() != Color.Black.ToArgb() &&
                pixelColor.ToArgb() != color.ToArgb())
            {
                pixel.putpixel(x, y, color);
                mi_floodfill(x, y + 1, color); // Norte
                mi_floodfill(x + 1, y, color); // Este
                mi_floodfill(x, y - 1, color); // Sur
                mi_floodfill(x - 1, y, color); // Oeste
            }
        }

    }
}