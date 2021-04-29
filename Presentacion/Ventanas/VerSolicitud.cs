using FaceId.Modelo.base_de_datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceId.Presentacion.Ventanas
{
    public partial class VerSolicitud : UserControl
    {
        public VerSolicitud()
        {
            InitializeComponent();
            RegistroSolicitudDto db = new RegistroSolicitudDto();
            dataGridView1.DataSource = db.verRegistro();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }

        private void registroSolicitudDtoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            
        }
    }
}
