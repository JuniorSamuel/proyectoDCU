using FaceId.Control;
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
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
            frm.setVentana(Fabrica.getVentana(Ventana.Ver));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
            frm.setVentana(Fabrica.getVentana(Ventana.Solicitud));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
            frm.setVentana(Fabrica.getVentana(Ventana.Reporte));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
            frm.setVentana(Fabrica.getVentana(Ventana.VerSolicitud));
        }
    }
}
