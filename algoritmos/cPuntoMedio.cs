using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace algoritmos
{
    internal class CPuntoMedio
    {
        private int mXo;
        private int mYo;
        private int mXf;
        private int mYf;
        private List<Point> mLinePoints;
        private int mCurrentStep;

        // Referencia a cPixel (no se modifica cPixel)
        private cPixel mPixel;

        // Propiedades para mostrar valores específicos de Punto Medio
        public int DeltaX { get; private set; } = 0;
        public int DeltaY { get; private set; } = 0;
        public int D_Inicial { get; private set; } = 0;

        public CPuntoMedio()
        {
            mXo = 0; mYo = 0;
            mXf = 0; mYf = 0;
            mLinePoints = new List<Point>();
            mCurrentStep = 0;
        }

        // Asignar instancia de cPixel (desde el formulario)
        public void SetPixel(cPixel pixel)
        {
            mPixel = pixel;
        }

        public bool ReadData(TextBox txtXo, TextBox txtXf, TextBox txtYo, TextBox txtYf)
        {
            bool respuesta = true;
            try
            {
                mXo = int.Parse(txtXo.Text);
                mXf = int.Parse(txtXf.Text);
                mYo = int.Parse(txtYo.Text);
                mYf = int.Parse(txtYf.Text);
                // Coordenadas negativas permitidas
            }
            catch
            {
                respuesta = false;
                MessageBox.Show("Ingrese Datos válidos...!", "ERROR!");
            }

            return respuesta;
        }

        // Inicializa datos y limpia el canvas mediante cPixel
        public void InitializeData(TextBox txtXo, TextBox txtXf, TextBox txtYo, TextBox txtYf, cPixel pixel)
        {
            mXo = 0; mYo = 0;
            mXf = 0; mYf = 0;

            txtXo.Text = ""; txtYo.Text = "";
            txtXf.Text = ""; txtYf.Text = "";

            mLinePoints.Clear();
            mCurrentStep = 0;

            // Usar el pixel proporcionado para limpiar y dibujar cuadrícula
            SetPixel(pixel);
            if (mPixel != null)
            {
                mPixel.limpiar();
                mPixel.dibujarCuadricula();
            }

            txtXo.Focus();
        }

        public void CloseForm(Form form)
        {
            form.Close();
        }

        // Método principal que ejecuta el algoritmo de Punto Medio usando cPixel
        public async void DrawPuntoMedio(cPixel pixel)
        {
            if (!ValidarPuntos())
            {
                return;
            }

            // Asegurar la referencia a cPixel
            SetPixel(pixel);
            if (mPixel == null)
            {
                MessageBox.Show("Error interno: referencia a cPixel nula", "Error");
                return;
            }

            // Calcular todos los puntos según el algoritmo de Punto Medio
            CalculateMidpoint();

            // Dibujar con animación usando cPixel
            await DrawCompleteAnimated();
        }

        // Validar que los puntos no sean iguales
        private bool ValidarPuntos()
        {
            if (mXo == mXf && mYo == mYf)
            {
                MessageBox.Show("Los puntos inicial y final son iguales", "Advertencia");
                return false;
            }
            return true;
        }

        // Algoritmo de Punto Medio para líneas (sin cambios lógicos)
        private void CalculateMidpoint()
        {
            mLinePoints.Clear();

            int dx = Math.Abs(mXf - mXo);
            int dy = Math.Abs(mYf - mYo);

            DeltaX = dx;
            DeltaY = dy;

            int sx = (mXo < mXf) ? 1 : -1;
            int sy = (mYo < mYf) ? 1 : -1;

            int x = mXo;
            int y = mYo;

            // Algoritmo de Punto Medio
            if (dx > dy)
            {
                // Pendiente < 1
                int d = 2 * dy - dx;
                D_Inicial = d;

                mLinePoints.Add(new Point(x, y));

                while (x != mXf)
                {
                    x += sx;

                    if (d < 0)
                    {
                        d = d + 2 * dy;
                    }
                    else
                    {
                        y += sy;
                        d = d + 2 * dy - 2 * dx;
                    }

                    mLinePoints.Add(new Point(x, y));
                }
            }
            else
            {
                // Pendiente >= 1
                int d = 2 * dx - dy;
                D_Inicial = d;

                mLinePoints.Add(new Point(x, y));

                while (y != mYf)
                {
                    y += sy;

                    if (d < 0)
                    {
                        d = d + 2 * dx;
                    }
                    else
                    {
                        x += sx;
                        d = d + 2 * dx - 2 * dy;
                    }

                    mLinePoints.Add(new Point(x, y));
                }
            }

            mCurrentStep = 0;
        }

        // Muestra todos los pasos como animación usando cPixel
        private async Task DrawCompleteAnimated()
        {
            if (mPixel == null) return;

            // Dibujar cuadrícula inicial
            mPixel.limpiar();
            mPixel.dibujarCuadricula();

            for (int i = 0; i < mLinePoints.Count; i++)
            {
                mCurrentStep = i;
                DrawUpToStep(i);
                await Task.Delay(50);
            }
        }

        // Dibuja todos los puntos hasta el paso actual usando cPixel
        private void DrawUpToStep(int step)
        {
            if (mPixel == null) return;

            // Limpiar y redibujar cuadrícula en cada paso para refrescar el estado
            mPixel.limpiar();
            mPixel.dibujarCuadricula();

            // Dibujar los puntos hasta el paso actual
            for (int i = 0; i <= Math.Min(step, mLinePoints.Count - 1); i++)
            {
                Point p = mLinePoints[i];
                Color pointColor = (i == step) ? Color.Red : Color.Blue;
                mPixel.putpixel(p.X, p.Y, pointColor);
            }

            // Nota: para la "línea continua" se podría dibujar con más puntos o exponer
            // un método en cPixel para dibujar líneas; aquí se mantiene la discretización.
        }

        // Obtener información del punto actual
        public string GetCurrentPointInfo()
        {
            if (mLinePoints.Count == 0 || mCurrentStep >= mLinePoints.Count)
                return "Sin datos";

            Point current = mLinePoints[mCurrentStep];
            return $"Paso {mCurrentStep + 1}/{mLinePoints.Count} - Punto ({current.X}, {current.Y})";
        }
    }
}