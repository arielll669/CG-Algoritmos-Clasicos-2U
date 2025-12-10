using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace algoritmos
{
    public class cBoundaryFill
    {
        public static List<cPunto> Rellenar(Bitmap bitmap, cPunto puntoInicio, Color colorRelleno, Color colorBorde)
        {
            List<cPunto> pixelesPintados = new List<cPunto>();

            BitmapData bmpData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            int bytes = Math.Abs(bmpData.Stride) * bitmap.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(bmpData.Scan0, rgbValues, 0, bytes);

            int stride = bmpData.Stride;
            int ancho = bitmap.Width;
            int alto = bitmap.Height;

            Color colorActual = ObtenerColor(rgbValues, puntoInicio.X, puntoInicio.Y, stride);

            if (ColoresIguales(colorActual, colorRelleno) || ColoresIguales(colorActual, colorBorde))
            {
                bitmap.UnlockBits(bmpData);
                return pixelesPintados;
            }

            Stack<cPunto> pila = new Stack<cPunto>();
            pila.Push(puntoInicio);

            while (pila.Count > 0)
            {
                cPunto p = pila.Pop();

                if (p.X < 0 || p.X >= ancho || p.Y < 0 || p.Y >= alto)
                    continue;

                Color color = ObtenerColor(rgbValues, p.X, p.Y, stride);

                if (ColoresIguales(color, colorBorde) || ColoresIguales(color, colorRelleno))
                    continue;

                EstablecerColor(rgbValues, p.X, p.Y, stride, colorRelleno);
                pixelesPintados.Add(p);

                pila.Push(new cPunto(p.X + 1, p.Y));
                pila.Push(new cPunto(p.X - 1, p.Y));
                pila.Push(new cPunto(p.X, p.Y + 1));
                pila.Push(new cPunto(p.X, p.Y - 1));
            }

            Marshal.Copy(rgbValues, 0, bmpData.Scan0, bytes);
            bitmap.UnlockBits(bmpData);

            return pixelesPintados;
        }

        private static Color ObtenerColor(byte[] rgbValues, int x, int y, int stride)
        {
            int index = y * stride + x * 3;
            return Color.FromArgb(rgbValues[index + 2], rgbValues[index + 1], rgbValues[index]);
        }

        private static void EstablecerColor(byte[] rgbValues, int x, int y, int stride, Color color)
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