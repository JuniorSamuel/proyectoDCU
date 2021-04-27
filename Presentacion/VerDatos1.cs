using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceId.Presentacion
{
    public partial class VerDatos1 : Form
    {
        public VerDatos1()
        {
            InitializeComponent();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            DatosPDF PDF = new DatosPDF();
            
        }

        private void lblFNFNVD_Click(object sender, EventArgs e)
        {

        }
    }
}
