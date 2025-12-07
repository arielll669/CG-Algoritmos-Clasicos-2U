using System;
using System.Collections.Generic;
using System.Drawing;

namespace algoritmos
{
    public class cDDA
    {
        private int x1, y1, x2, y2;
        private float x, y;
        private float xIncremento, yIncremento;
        private int pasosTotales;
        private int pasoActual;
        private int prevX, prevY;
        private bool terminado;
        private bool inicializado;

        public cDDA()
        {
            inicializado = false;
        }

        public void Inicializar(int px1, int py1, int px2, int py2)
        {
            x1 = px1;
            y1 = py1;
            x2 = px2;
            y2 = py2;

            int dx = x2 - x1;
            int dy = y2 - y1;

            // Determinar el número de pasos basado en la distancia mayor
            pasosTotales = Math.Max(Math.Abs(dx), Math.Abs(dy));

            // Calcular los incrementos
            if (pasosTotales > 0)
            {
                xIncremento = (float)dx / pasosTotales;
                yIncremento = (float)dy / pasosTotales;
            }
            else
            {
                xIncremento = 0;
                yIncremento = 0;
            }

            // Inicializar las coordenadas actuales
            x = x1;
            y = y1;

            prevX = (int)Math.Round(x);
            prevY = (int)Math.Round(y);

            pasoActual = 0;
            terminado = false;
            inicializado = true;
        }

        public Point CalcularSiguientePunto()
        {
            if (!inicializado || terminado)
                return new Point((int)Math.Round(x), (int)Math.Round(y));

            prevX = (int)Math.Round(x);
            prevY = (int)Math.Round(y);

            // Incrementar las coordenadas
            x += xIncremento;
            y += yIncremento;

            pasoActual++;

            if (pasoActual >= pasosTotales)
            {
                x = x2;
                y = y2;
                terminado = true;
            }

            return new Point((int)Math.Round(x), (int)Math.Round(y));
        }

        public Point ObtenerPuntoActual()
        {
            return new Point((int)Math.Round(x), (int)Math.Round(y));
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

            int dx = bx - ax;
            int dy = by - ay;

            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

            if (steps == 0)
            {
                points.Add(new Point(ax, ay));
                return points;
            }

            float xIncrement = (float)dx / steps;
            float yIncrement = (float)dy / steps;

            float x = ax;
            float y = ay;

            for (int i = 0; i <= steps; i++)
            {
                points.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                x += xIncrement;
                y += yIncrement;
            }

            return points;
        }

        public List<Point> ObtenerPixelsEntreUltimoYActual()
        {
            return GenerarLineaPixels(prevX, prevY, (int)Math.Round(x), (int)Math.Round(y));
        }
    }
}