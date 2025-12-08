using System;
using System.Collections.Generic;
using System.Drawing;

namespace algoritmos
{
    public class cFloodFillRecursivo
    {
        private static int contadorRecursion = 0;
        private const int MAX_RECURSION = 5000; // Límite de seguridad

        public static List<cPunto> Rellenar(Bitmap bitmap, cPunto puntoInicio, Color colorRelleno, Color colorBorde)
        {
            List<cPunto> pixelesPintados = new List<cPunto>();

            Color colorOriginal = bitmap.GetPixel(puntoInicio.X, puntoInicio.Y);

            // Si ya es del color de relleno o es el borde, no hacer nada
            if (colorOriginal == colorRelleno || colorOriginal == colorBorde)
                return pixelesPintados;

            contadorRecursion = 0;
            RellenarRecursivo(bitmap, puntoInicio.X, puntoInicio.Y, colorOriginal, colorRelleno, colorBorde, pixelesPintados);

            return pixelesPintados;
        }

        private static void RellenarRecursivo(Bitmap bitmap, int x, int y, Color colorOriginal, Color colorRelleno, Color colorBorde, List<cPunto> pixelesPintados)
        {
            // Límite de seguridad para evitar stack overflow
            contadorRecursion++;
            if (contadorRecursion > MAX_RECURSION)
                return;

            // Verificar límites
            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                return;

            Color colorActual = bitmap.GetPixel(x, y);

            // Si es borde, color de relleno, o diferente al original, salir
            if (colorActual == colorBorde || colorActual == colorRelleno || colorActual != colorOriginal)
                return;

            // Pintar el píxel
            bitmap.SetPixel(x, y, colorRelleno);
            pixelesPintados.Add(new cPunto(x, y));

            // Llamadas recursivas en 4 direcciones
            RellenarRecursivo(bitmap, x + 1, y, colorOriginal, colorRelleno, colorBorde, pixelesPintados); // Derecha
            RellenarRecursivo(bitmap, x - 1, y, colorOriginal, colorRelleno, colorBorde, pixelesPintados); // Izquierda
            RellenarRecursivo(bitmap, x, y + 1, colorOriginal, colorRelleno, colorBorde, pixelesPintados); // Abajo
            RellenarRecursivo(bitmap, x, y - 1, colorOriginal, colorRelleno, colorBorde, pixelesPintados); // Arriba
        }
    }
}