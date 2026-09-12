using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioMDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tsbActivarBoton_Click(object sender, EventArgs e)
        {
            // 1. Busca en la lista global de formularios abiertos de la aplicación
            // si ya existe una instancia activa del tipo 'frmVentanaTexto'
            frmVentanaTexto ventanaTexto = Application.OpenForms.OfType<frmVentanaTexto>().FirstOrDefault();

            // 2. Evaluación condicional:
            if (ventanaTexto != null)
            {
                // Si el formulario YA existe en memoria:
                ventanaTexto.BringToFront(); // Coloca la ventana por encima de las demás dentro del padre
                ventanaTexto.Focus();        // Le otorga el foco de teclado/interacción al usuario
            }
            else
            {
                // Si el formulario NO está abierto:
                ventanaTexto = new frmVentanaTexto(); // Crea la nueva instancia
                ventanaTexto.MdiParent = this;         // Asigna Form1 (this) como el formulario padre
                ventanaTexto.Show();                  // Despliega la ventana dentro del contenedor MDI
            }
        }
    }
}
