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

namespace FaceId
{
    public partial class FrmInicio : Form
    {
        FilterInfoCollection filtro;
        VideoCaptureDevice dispositivo;

        public FrmInicio()
        {
            InitializeComponent();
            CtlFrmInicio frmInicio = new CtlFrmInicio(this);
        }
     }
}
