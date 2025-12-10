using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace algoritmos
{
    public class cFloodFillRecursivo
    {
        private static List<cPunto> pixelesPintados;
        private static byte[] rgbValues;
        private static int stride;
        private static int ancho;
        private static int alto;
        private static Color colorOriginal;
        private static Color colorRellenoActual;
        private static Color colorBordeActual;
        private static int profundidadActual = 0;
        private const int MAX_PROFUNDIDAD = 100;

        public static List<cPunto> Rellenar(Bitmap bitmap, cPunto puntoInicio, Color colorRelleno, Color colorBorde)
        {
            pixelesPintados = new List<cPunto>();

            // Bloquear bits
            BitmapData bmpData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            int bytes = Math.Abs(bmpData.Stride) * bitmap.Height;
            rgbValues = new byte[bytes];
            Marshal.Copy(bmpData.Scan0, rgbValues, 0, bytes);

            stride = bmpData.Stride;
            ancho = bitmap.Width;
            alto = bitmap.Height;
            colorRellenoActual = colorRelleno;
            colorBordeActual = colorBorde;

            colorOriginal = ObtenerColor(puntoInicio.X, puntoInicio.Y);

            if (ColoresIguales(colorOriginal, colorRelleno) || ColoresIguales(colorOriginal, colorBorde))
            {
                bitmap.UnlockBits(bmpData);
                return pixelesPintados;
            }

            profundidadActual = 0;
            RellenarRecursivoSeguro(puntoInicio.X, puntoInicio.Y);

            // Copiar de vuelta
            Marshal.Copy(rgbValues, 0, bmpData.Scan0, bytes);
            bitmap.UnlockBits(bmpData);

            return pixelesPintados;
        }

        private static void RellenarRecursivoSeguro(int x, int y)
        {
            profundidadActual++;

            if (profundidadActual > MAX_PROFUNDIDAD)
            {
                profundidadActual--;
                RellenarIterativo(x, y);
                return;
            }

            if (x < 0 || x >= ancho || y < 0 || y >= alto)
            {
                profundidadActual--;
                return;
            }

            Color colorActual = ObtenerColor(x, y);

            if (ColoresIguales(colorActual, colorBordeActual) ||
                ColoresIguales(colorActual, colorRellenoActual) ||
                !ColoresIguales(colorActual, colorOriginal))
            {
                profundidadActual--;
                return;
            }

            EstablecerColor(x, y, colorRellenoActual);
            pixelesPintados.Add(new cPunto(x, y));

            RellenarRecursivoSeguro(x + 1, y);
            RellenarRecursivoSeguro(x - 1, y);
            RellenarRecursivoSeguro(x, y + 1);
            RellenarRecursivoSeguro(x, y - 1);

            profundidadActual--;
        }

        private static void RellenarIterativo(int inicioX, int inicioY)
        {
            Stack<cPunto> pila = new Stack<cPunto>();
            pila.Push(new cPunto(inicioX, inicioY));

            while (pila.Count > 0)
            {
                cPunto p = pila.Pop();

                if (p.X < 0 || p.X >= ancho || p.Y < 0 || p.Y >= alto)
                    continue;

                Color colorActual = ObtenerColor(p.X, p.Y);

                if (ColoresIguales(colorActual, colorBordeActual) ||
                    ColoresIguales(colorActual, colorRellenoActual) ||
                    !ColoresIguales(colorActual, colorOriginal))
                    continue;

                EstablecerColor(p.X, p.Y, colorRellenoActual);
                pixelesPintados.Add(p);

                pila.Push(new cPunto(p.X + 1, p.Y));
                pila.Push(new cPunto(p.X - 1, p.Y));
                pila.Push(new cPunto(p.X, p.Y + 1));
                pila.Push(new cPunto(p.X, p.Y - 1));
            }
        }

        private static Color ObtenerColor(int x, int y)
        {
            int index = y * stride + x * 3;
            return Color.FromArgb(rgbValues[index + 2], rgbValues[index + 1], rgbValues[index]);
        }

        private static void EstablecerColor(int x, int y, Color color)
        {
            int index = y * stride + x * 3;
            rgbValues[index] = color.B;
            rgbValues[index + 1] = color.G;
            rgbValues[index + 2] = color.R;
        }

        private static bool ColoresIguales(Color c1, Color c2)
        {
            return c1.R == c2.R && c1.G == c2.G && c1.B == c2.B;
        }
    }
}