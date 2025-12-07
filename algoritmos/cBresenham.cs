using System;
using System.Collections.Generic;
using System.Drawing;

namespace algoritmos
{
    public class cBresenham
    {
        private int x1, y1, x2, y2;
        private int dx, dy;
        private int x, y;
        private int p;
        private int stepX, stepY;
        private bool terminado;
        private bool inicializado;
        private int pasosTotales;
        private int pasoActual;
        private int prevX, prevY;

        public cBresenham()
        {
            inicializado = false;
        }

        public void Inicializar(int px1, int py1, int px2, int py2)
        {
            x1 = px1;
            y1 = py1;
            x2 = px2;
            y2 = py2;

            dx = Math.Abs(x2 - x1);
            dy = Math.Abs(y2 - y1);

            stepX = (x1 < x2) ? 1 : -1;
            stepY = (y1 < y2) ? 1 : -1;

            x = x1;
            y = y1;

            prevX = x;
            prevY = y;

            if (dx > dy)
            {
                p = 2 * dy - dx;
                pasosTotales = dx;
            }
            else
            {
                p = 2 * dx - dy;
                pasosTotales = dy;
            }

            pasoActual = 0;
            terminado = false;
            inicializado = true;
        }

        public Point CalcularSiguientePunto()
        {
            if (!inicializado || terminado)
                return new Point(x, y);

            prevX = x;
            prevY = y;

            if (dx > dy)
            {
                x = x + stepX;

                if (p < 0)
                {
                    p = p + 2 * dy;
                }
                else
                {
                    p = p + 2 * dy - 2 * dx;
                    y = y + stepY;
                }
            }
            else
            {
                y = y + stepY;

                if (p < 0)
                {
                    p = p + 2 * dx;
                }
                else
                {
                    p = p + 2 * dx - 2 * dy;
                    x = x + stepX;
                }
            }

            pasoActual++;

            if (pasoActual >= pasosTotales)
            {
                x = x2;
                y = y2;
                terminado = true;
            }

            return new Point(x, y);
        }

        public Point ObtenerPuntoActual()
        {
            return new Point(x, y);
        }

        public Point ObtenerPuntoAnterior()
        {
            return new Point(prevX, prevY);
        }

        public Point ObtenerPuntoInicial()
        {
            return new Point(x1, y1);
        }

        public bool EstaTerminado()
        {
            return terminado;
        }

        public bool EstaInicializado()
        {
            return inicializado;
        }

        public void Reiniciar()
        {
            inicializado = false;
            terminado = false;
            pasoActual = 0;
        }

        public static List<Point> GenerarLineaPixels(int ax, int ay, int bx, int by)
        {
            var points = new List<Point>();

            int x = ax;
            int y = ay;
            int dx = Math.Abs(bx - ax);
            int dy = Math.Abs(by - ay);
            int sx = ax < bx ? 1 : -1;
            int sy = ay < by ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                points.Add(new Point(x, y));
                if (x == bx && y == by) break;
                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y += sy;
                }
            }

            return points;
        }

        public List<Point> ObtenerPixelsEntreUltimoYActual()
        {
            return GenerarLineaPixels(prevX, prevY, x, y);
        }
    }
}