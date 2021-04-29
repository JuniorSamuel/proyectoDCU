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
    public partial class Captural : UserControl
    {
        public Captural()
        {
            InitializeComponent();
            CtlFrmInicio.captu = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Mensajes.getMensajeCancelar())
            { 
                CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
                frm.setVentana(Fabrica.getVentana(Ventana.Registro));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {                     
            PersonaDto db = new PersonaDto();
            db.setPersona(CtlFrmInicio.user);
        }
    }
}
