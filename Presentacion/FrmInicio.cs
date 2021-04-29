using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;

using Emgu.CV;
using Emgu.CV.Structure;
using FaceId.Control;
using FaceId.Presentacion.Ventanas;

namespace FaceId
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
            CtlFrmInicio frmInicio = CtlFrmInicio.getCtlFrmInicio(this);
        }

        private void bnRegistro_Click(object sender, EventArgs e)
        {
            CtlFrmInicio frm = CtlFrmInicio.getCtlFrmInicio();
            frm.setVentana(Fabrica.getVentana(Ventana.Registro));
        }
    }
}
