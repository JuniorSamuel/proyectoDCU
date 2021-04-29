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
    public partial class Solicitud : UserControl
    {
        public Solicitud()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            ServicioDto db = new ServicioDto();
            List<Servicio> servicios = db.getServicio();            
            foreach (var item in servicios)
            {                
                cbSolicitud.Items.Add(item.nombre);
            }
            cbSolicitud.SelectedIndex = 0;
            setSubVentana(Fabrica.getVentana(Ventana.selectSolicitud));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Mensajes.getMensajeCancelar())
            {
                CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
                frm.setVentana(Fabrica.getVentana(Ventana.Login));
            }
        }

        private void cbSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbSolicitud.SelectedIndex)
            {
                case 0:
                    setSubVentana(Fabrica.getVentana(Ventana.selectSolicitud));
                    break;
                case 1:
                    setSubVentana(Fabrica.getVentana(Ventana.ActaNacimiento));
                    break;
                case 2:
                    setSubVentana(Fabrica.getVentana(Ventana.ActaNacimiento));
                    break;
                default:
                    break;
            }
        }

        private void setSubVentana(UserControl panel)
        {
            if (panSolicitud.Controls.Count != 0) panSolicitud.Controls.RemoveAt(0);
            //panel.Dock = DockStyle.Fill;
            panSolicitud.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            panSolicitud.Controls.Add(panel);

        }
    }
}
