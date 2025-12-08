using System;

namespace algoritmos
{
    public struct cPunto
    {
        public int X { get; set; }
        public int Y { get; set; }

        public cPunto(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Calcula la distancia entre dos puntos
        public double DistanciaA(cPunto otro)
        {
            int dx = X - otro.X;
            int dy = Y - otro.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}