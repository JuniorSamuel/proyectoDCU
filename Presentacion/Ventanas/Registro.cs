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
    public partial class Registro : UserControl
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CtlFrmInicio.user = new Persona
            {
                cedula = Int32.Parse(txtCedula.Text),
                nombre = txtNombre.Text,
                sexo = getSexo(),
                fecha_nacimiento = Calendario.SelectionRange.ToString(),
                nacionalidad = txtNacionalidad.Text,
                telefono = Int32.Parse(txtTelefono.Text)
            };            
            
            CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
            frm.setVentana(Fabrica.getVentana(Ventana.Captural));
        }
        private string getSexo()
        {
            if (rdbMasculino.Checked)
            {
                return "Masculino";
            }else
            {
                return "Famenino";
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (Mensajes.getMensajeCancelar())
            {
                CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
                frm.setVentana(Fabrica.getVentana(Ventana.Login));
            }
        }
    }
}
