using FaceId.Control.Ventanas;
using FaceId.Presentacion.Ventanas.subVentanas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceId.Presentacion.Ventanas
{
    enum Ventana{ 
        NoLogin, 
        Login, 
        Solicitud, 
        Reporte, 
        VerSolicitud, 
        Registro,
        Ver,
        Captural,
        selectSolicitud,
        ActaNacimiento
    }
    class Fabrica
    {
        public static UserControl getVentana(Ventana valor)
        {

            switch (valor)
            {
                case Ventana.NoLogin:
                    return new NoLogin();
                case Ventana.Login:
                    return new Login();
                case Ventana.Solicitud:
                    return new Solicitud();
                case Ventana.Reporte:
                    return new Reporte();
                case Ventana.VerSolicitud:
                    return new VerSolicitud();
                case Ventana.Registro:
                    return new Registro();
                case Ventana.Ver:
                    return new Ver();
                case Ventana.Captural:
                    return new Captural();
                case Ventana.selectSolicitud:
                    return new SelecSolicitud();
                case Ventana.ActaNacimiento:
                    return new ActaNacimiento();
                default:
                    return null;
            }
        }
    }
}
