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
    public partial class Opciones : UserControl
    {
        public Opciones()
        {
            InitializeComponent();
        }

        private void btnSolicitarOP_Click(object sender, EventArgs e)
        {
            FrmSolicitar Solicitud = new FrmSolicitar();
            Solicitud.Show();   
        }

        private void btnRegistrarOP_Click(object sender, EventArgs e)
        {
            FrmRegistro Registro = new FrmRegistro();
            Registro.Show();
        }

        private void btnVerDatosOP_Click(object sender, EventArgs e)
        {
            //btnRegistrarOP.Enabled = false;

            VerDatos1 VisualizarDatos = new VerDatos1();
            VisualizarDatos.Show();
        }

        private void btnSalirOP_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReporteOP_Click(object sender, EventArgs e)
        {
            FrmReporte Cedula = new FrmReporte();
            Cedula.Show();
        }
    }
}
