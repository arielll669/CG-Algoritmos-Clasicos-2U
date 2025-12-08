using System;
using System.Collections.Generic;
using System.Drawing;

namespace algoritmos
{
    public class cBoundaryFill
    {
        public static List<cPunto> Rellenar(Bitmap bitmap, cPunto puntoInicio, Color colorRelleno, Color colorBorde)
        {
            List<cPunto> pixelesPintados = new List<cPunto>();

            Color colorActual = bitmap.GetPixel(puntoInicio.X, puntoInicio.Y);

            // Si ya es del color de relleno o es el borde, no hacer nada
            if (colorActual == colorRelleno || colorActual == colorBorde)
                return pixelesPintados;

            Stack<cPunto> pila = new Stack<cPunto>();
            pila.Push(puntoInicio);

            int ancho = bitmap.Width;
            int alto = bitmap.Height;

            while (pila.Count > 0)
            {
                cPunto p = pila.Pop();

                // Verificar límites
                if (p.X < 0 || p.X >= ancho || p.Y < 0 || p.Y >= alto)
                    continue;

                Color color = bitmap.GetPixel(p.X, p.Y);

                // La diferencia con FloodFill: se detiene en el BORDE específico
                // y no pinta si ya es del color de relleno
                if (color == colorBorde || color == colorRelleno)
                    continue;

                // Pintar el píxel
                bitmap.SetPixel(p.X, p.Y, colorRelleno);
                pixelesPintados.Add(p);

                // Agregar vecinos en 4 direcciones
                pila.Push(new cPunto(p.X + 1, p.Y));     // Derecha
                pila.Push(new cPunto(p.X - 1, p.Y));     // Izquierda
                pila.Push(new cPunto(p.X, p.Y + 1));     // Abajo
                pila.Push(new cPunto(p.X, p.Y - 1));     // Arriba
            }

            return pixelesPintados;
        }
    }
}