using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceId.Presentacion
{
    public partial class RegistrarDatos : UserControl
    {
        public RegistrarDatos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sus Datos han sido guardado exitosamente");

        }
    }
}
