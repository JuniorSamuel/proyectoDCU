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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
            frm.setVentana(Fabrica.getVentana(Ventana.Login));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
