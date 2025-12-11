using System;
using System.Collections.Generic;

namespace algoritmos
{
    public class cFigurasRecorte
    {
        public static List<cPunto> GenerarRectangulo(int anchoPanel, int altoPanel, int ancho, int alto)
        {
            List<cPunto> vertices = new List<cPunto>();

            int centroX = anchoPanel / 2;
            int centroY = altoPanel / 2;

            int x1 = centroX - ancho / 2;
            int y1 = centroY - alto / 2;
            int x2 = centroX + ancho / 2;
            int y2 = centroY + alto / 2;

            // Sentido horario
            vertices.Add(new cPunto(x1, y1)); // Superior izquierda
            vertices.Add(new cPunto(x2, y1)); // Superior derecha
            vertices.Add(new cPunto(x2, y2)); // Inferior derecha
            vertices.Add(new cPunto(x1, y2)); // Inferior izquierda

            return vertices;
        }

        public static List<cPunto> GenerarHexagono(int anchoPanel, int altoPanel, int radio)
        {
            List<cPunto> vertices = new List<cPunto>();

            int centroX = anchoPanel / 2;
            int centroY = altoPanel / 2;

            for (int i = 0; i < 6; i++)
            {
                double angulo = Math.PI / 3 * i;
                int x = centroX + (int)(radio * Math.Cos(angulo));
                int y = centroY + (int)(radio * Math.Sin(angulo));
                vertices.Add(new cPunto(x, y));
            }

            return vertices;
        }

        public static List<cPunto> GenerarEstrella(int anchoPanel, int altoPanel, int radioExterior)
        {
            List<cPunto> vertices = new List<cPunto>();

            int centroX = anchoPanel / 2;
            int centroY = altoPanel / 2;
            int radioInterior = radioExterior / 2;

            for (int i = 0; i < 10; i++)
            {
                double angulo = (Math.PI * 2 / 10) * i - Math.PI / 2;
                int radio = (i % 2 == 0) ? radioExterior : radioInterior;

                int x = centroX + (int)(radio * Math.Cos(angulo));
                int y = centroY + (int)(radio * Math.Sin(angulo));
                vertices.Add(new cPunto(x, y));
            }

            return vertices;
        }
    }
}