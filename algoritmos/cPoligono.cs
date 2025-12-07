using System;
using System.Collections.Generic;
using System.Drawing;

namespace algoritmos
{
    public class cPoligono
    {
        private cPixel pixel;
        private List<Point> vertices; // Lista de vértices del polígono
        public bool poligonoCerrado = false;

        // Constructor
        public cPoligono(cPixel pixel)
        {
            this.pixel = pixel;
            vertices = new List<Point>();
        }

        // Agregar un vértice al polígono
        public void AgregarVertice(int x, int y)
        {
            Point nuevoVertice = new Point(x, y);
            vertices.Add(nuevoVertice);

            // Dibujar el punto del vértice
            pixel.putpixel(x, y, Color.Black);

            // Si hay más de un vértice, dibujar línea desde el anterior
            if (vertices.Count > 1)
            {
                Point anterior = vertices[vertices.Count - 2];
                DibujarLinea(anterior.X, anterior.Y, x, y);
            }
        }

        // Cerrar el polígono conectando último vértice con el primero
        public void CerrarPoligono()
        {
            if (vertices.Count >= 3)
            {
                Point primero = vertices[0];
                Point ultimo = vertices[vertices.Count - 1];
                DibujarLinea(ultimo.X, ultimo.Y, primero.X, primero.Y);
                poligonoCerrado = true;
            }
        }

        // Limpiar el polígono
        public void Limpiar()
        {
            vertices.Clear();
            poligonoCerrado = false;
        }

        // Obtener número de vértices
        public int ObtenerNumeroVertices()
        {
            return vertices.Count;
        }

        // Algoritmo de Bresenham para dibujar líneas
        private void DibujarLinea(int x0, int y0, int x1, int y1)
        {
            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                pixel.putpixel(x0, y0, Color.Black);

                if (x0 == x1 && y0 == y1)
                    break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x0 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y0 += sy;
                }
            }
        }
    }
}