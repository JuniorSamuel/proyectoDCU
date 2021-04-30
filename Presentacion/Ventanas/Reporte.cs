using FaceId.Control;
using FaceId.Modelo.base_de_datos;
using FaceId.Modelo.Entidades;
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
    public partial class Reporte : UserControl
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Mensajes.getMensajeCancelar())
            {
                CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
                frm.setVentana(Fabrica.getVentana(Ventana.Login));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroSolicitudDto db = new RegistroSolicitudDto();
            RegistroSolicitud registroSolicitud = new RegistroSolicitud();

            registroSolicitud.solicitd = getTipo();
            registroSolicitud.idPersona = CtlFrmInicio.user.idPersona;
            registroSolicitud.descripcion = txtDescripcion.Text;

            db.setRegistro(registroSolicitud);
        }

        private string getTipo()
        {
            if (radioButton1.Checked)            
                return "Reporte ceduda perdida";
            if (radioButton2.Checked)
                return "Reporte cedula robada";
            if (radioButton3.Checked)
                return "Reporte cedula dañada";
            return "Default";
                            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Mensajes.getMensajeCancelar())
            {
                CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
                frm.setVentana(Fabrica.getVentana(Ventana.Login));
            }
        }
    }
}
