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
    public partial class Ver : UserControl
    {
        public Ver()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            labCedula.Text = CtlFrmInicio.user.cedula.ToString();
            labNombre.Text = CtlFrmInicio.user.nombre.ToString();            
            labDireccion.Text = CtlFrmInicio.user.direccion.ToString();
            labFecha.Text = CtlFrmInicio.user.fecha_nacimiento.ToString();
            labTelefono.Text = CtlFrmInicio.user.telefono.ToString();
            labNacionalidad.Text = CtlFrmInicio.user.nacionalidad.ToString();
            labSexo.Text = CtlFrmInicio.user.sexo.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
            frm.setVentana(Fabrica.getVentana(Ventana.Login));
        }
    }
}
