using System;
using System.Collections.Generic;

namespace algoritmos
{
    public class cSutherlandHodgman
    {
        public static ResultadoRecorte Recortar(List<cPunto> poligonoOriginal, List<cPunto> ventanaRecorte)
        {
            ResultadoRecorte resultado = new ResultadoRecorte();
            resultado.PoligonoRecortado = new List<cPunto>(poligonoOriginal);
            resultado.PuntosInterseccion = new List<cPunto>();

            for (int i = 0; i < ventanaRecorte.Count; i++)
            {
                if (resultado.PoligonoRecortado.Count == 0)
                    break;

                cPunto aristaInicio = ventanaRecorte[i];
                cPunto aristaFin = ventanaRecorte[(i + 1) % ventanaRecorte.Count];

                List<cPunto> entrada = new List<cPunto>(resultado.PoligonoRecortado);
                resultado.PoligonoRecortado.Clear();

                for (int j = 0; j < entrada.Count; j++)
                {
                    cPunto puntoActual = entrada[j];
                    cPunto puntoAnterior = entrada[(j - 1 + entrada.Count) % entrada.Count];

                    bool actualDentro = EstaAdentro(puntoActual, aristaInicio, aristaFin);
                    bool anteriorDentro = EstaAdentro(puntoAnterior, aristaInicio, aristaFin);

                    if (actualDentro)
                    {
                        if (!anteriorDentro)
                        {
                            cPunto? interseccion = CalcularInterseccion(puntoAnterior, puntoActual, aristaInicio, aristaFin);
                            if (interseccion.HasValue)
                            {
                                resultado.PoligonoRecortado.Add(interseccion.Value);
                                resultado.PuntosInterseccion.Add(interseccion.Value);
                            }
                        }
                        resultado.PoligonoRecortado.Add(puntoActual);
                    }
                    else if (anteriorDentro)
                    {
                        cPunto? interseccion = CalcularInterseccion(puntoAnterior, puntoActual, aristaInicio, aristaFin);
                        if (interseccion.HasValue)
                        {
                            resultado.PoligonoRecortado.Add(interseccion.Value);
                            resultado.PuntosInterseccion.Add(interseccion.Value);
                        }
                    }
                }
            }

            return resultado;
        }

        private static bool EstaAdentro(cPunto punto, cPunto aristaInicio, cPunto aristaFin)
        {
            return (aristaFin.X - aristaInicio.X) * (punto.Y - aristaInicio.Y) -
                   (aristaFin.Y - aristaInicio.Y) * (punto.X - aristaInicio.X) >= 0;
        }

        private static cPunto? CalcularInterseccion(cPunto p1, cPunto p2, cPunto p3, cPunto p4)
        {
            double x1 = p1.X, y1 = p1.Y;
            double x2 = p2.X, y2 = p2.Y;
            double x3 = p3.X, y3 = p3.Y;
            double x4 = p4.X, y4 = p4.Y;

            double denominador = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

            if (Math.Abs(denominador) < 0.0001)
                return null; // Líneas paralelas

            double t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / denominador;

            int x = (int)(x1 + t * (x2 - x1));
            int y = (int)(y1 + t * (y2 - y1));

            return new cPunto(x, y);
        }
    }

    public class ResultadoRecorte
    {
        public List<cPunto> PoligonoRecortado { get; set; }
        public List<cPunto> PuntosInterseccion { get; set; }
    }
}