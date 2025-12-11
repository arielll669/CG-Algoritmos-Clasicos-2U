using System;
using System.Windows.Forms;

namespace algoritmos
{
    public partial class frmAyuda : Form
    {
        public frmAyuda()
        {
            InitializeComponent();
            CargarTextoAyuda();
        }

        private void CargarTextoAyuda()
        {
            txtHelp.Text =
@"Ayuda — Formularios y algoritmos (resumen)

Propósito general:
Aplicación de ejemplos de gráficos por computadora: trazado de primitivas, recorte y relleno.

Formularios y uso rápido:

1) frmPoligonoRelleno
- Qué hace: Permite dibujar polígonos con clics en el panel, cerrarlos y aplicar rellenos (FloodFill recursivo/iterativo, BoundaryFill, Scanline).
- Uso: clicar en el panel para añadir vértices; tras 3+ vértices usar 'Cerrar Polígono'; luego usar botones de relleno.
- Avisos: FloodFill recursivo puede desbordar pila en regiones grandes; prefiera FloodFillIterativo o Scanline.

2) frmRecorte
- Qué hace: Recorta polígonos (algoritmo Sutherland–Hodgman) contra una ventana de recorte; muestra polígono recortado y puntos de intersección.
- Uso: definir polígono y ventana de recorte desde la interfaz y ejecutar recorte.
- Avisos: el orden/orientación de la ventana influye en la prueba 'inside'; intersecciones se redondean a enteros.

3) frmPuntoMedio (puntoMedio)
- Qué hace: Traza líneas usando algoritmo Punto Medio (similar a Bresenham) y muestra la discretización paso a paso.
- Uso: introducir Xo, Yo, Xf, Yf → pulsar 'Calcular'. Origen centrado en la cuadrícula.
- Avisos: verificar que las coordenadas estén dentro del rango mostrado.

4) circunferencia1 / circunferencia2 / circunferencia3
- Qué hace: Dibujan circunferencias por distintos algoritmos (midpoint, polar, ecuación) y permiten rellenarlas.
- Uso: introducir radio o parámetros y pulsar 'Calcular'.
- Avisos: el origen es el centro de la cuadrícula; comprobar que el evento Click del botón esté enlazado si no responde.

Clases importantes:
- cPixel: manipula una cuadrícula centrada en un Panel. Métodos: putpixel/getpixel/limpiar/dibujarCuadricula. No modificar si desea conservar el mapeo lógico->pantalla.
- cGrafico: dibujo directo sobre Bitmap (píxel a píxel) para operaciones de relleno y líneas.
- cRellenoGrafico: implementa FloodFill recursivo, BoundaryFill, FloodFill iterativo y ScanlineFill. Devuelven lista de píxeles pintados.
- cSutherlandHodgman: recorta polígonos contra una ventana; devuelve polígono recortado y puntos de intersección.
- CPuntoMedio / cPoligono / cEcuacion / cPolar / cRecursivo: algoritmos de trazado y relleno específicos (ver código para detalles).

Consejos prácticos:
- Eventos del diseñador: si un botón no responde, compruebe que el evento Click esté enlazado al handler correcto (puede enlazarse en el diseñador: pestaña __Properties__ → __Events__).
- Unificar tamaño de célula/píxel: cPixel.tamañoPixel y cualquier PIXEL_SIZE deben corresponder para evitar desajustes.
- Para rendimiento en rellenos grandes prefiera métodos iterativos o Scanline y considere usar LockBits para operaciones masivas sobre Bitmap.

¿Quieres que añada botones en este diálogo para abrir la documentación de un formulario concreto o que abra ventanas de ayuda cortas por cada item del menú?";

            // Ajustar caret al principio
            txtHelp.SelectionStart = 0;
            txtHelp.SelectionLength = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}