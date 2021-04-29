using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceId.Control
{
    class Mensajes
    {
        public static bool getMensajeCancelar()
        {
            DialogResult dialogResult = MessageBox.Show("¿Quieres cancelar el proceso ? ", "Cancelar proceso", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }
    }
}
