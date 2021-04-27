using FaceId.Control.Ventanas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceId.Presentacion.Ventanas
{
    enum Ventana{ NoLogin, Login, Solicitud, Opciones, Ver }
    class Fabrica
    {
        public static UserControl getVentana(Ventana valor)
        {

            switch (valor)
            {
                case Ventana.NoLogin:
                    return new VenNoLogin();
                case Ventana.Login:
                    return new Login();
                case Ventana.Solicitud:
                    return new VenSolicitud();
                case Ventana.Opciones:
                    return new Opciones();
                case Ventana.Ver:
                    return new Ver();
                default:
                    return null;
            }
        }

    }
}
