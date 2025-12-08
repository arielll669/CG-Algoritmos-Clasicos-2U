using System;
using System.Collections.Generic;
using System.Drawing;

namespace algoritmos
{
    public class cPoligono
    {
        private cGrafico grafico;
        private List<Point> vertices; // Lista de vértices del polígono
        public bool poligonoCerrado = false;

        // Constructor
        public cPoligono(cGrafico grafico)
        {
            this.grafico = grafico;
            vertices = new List<Point>();
        }

        // Agregar un vértice al polígono
        public void AgregarVertice(int x, int y)
        {
            Point nuevoVertice = new Point(x, y);
            vertices.Add(nuevoVertice);

            // Dibujar el punto del vértice
            grafico.DibujarPunto(x, y, Color.Red, 6);

            // Si hay más de un vértice, dibujar línea desde el anterior
            if (vertices.Count > 1)
            {
                Point anterior = vertices[vertices.Count - 2];
                grafico.DibujarLinea(anterior.X, anterior.Y, x, y, Color.Black, 2);
            }
        }

        // Cerrar el polígono conectando último vértice con el primero
        public void CerrarPoligono()
        {
            if (vertices.Count >= 3)
            {
                Point primero = vertices[0];
                Point ultimo = vertices[vertices.Count - 1];
                grafico.DibujarLinea(ultimo.X, ultimo.Y, primero.X, primero.Y, Color.Black, 2);
                poligonoCerrado = true;
            }
        }

        // Detectar si un clic está cerca del primer vértice (cierre automático)
        public bool DetectarCierreAutomatico(int x, int y, int tolerancia = 15)
        {
            // Necesitamos al menos 3 vértices para formar un polígono
            if (vertices.Count < 3)
                return false;

            Point primero = vertices[0];

            // Calcular distancia entre el clic y el primer vértice
            double distancia = Math.Sqrt(Math.Pow(x - primero.X, 2) + Math.Pow(y - primero.Y, 2));

            return distancia <= tolerancia;
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

        // Obtener lista de vértices (para referencia)
        public List<Point> ObtenerVertices()
        {
            return new List<Point>(vertices);
        }
    }
}