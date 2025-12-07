using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace algoritmos
{
    public partial class frmRecorte : Form
    {
        private static frmRecorte instancia;
        public frmRecorte()
        {
            InitializeComponent();
        }

        public static frmRecorte ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new frmRecorte();
            }
            return instancia;
        }


    }
}
