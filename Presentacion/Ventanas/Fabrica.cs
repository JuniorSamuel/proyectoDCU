using FaceId.Control.Ventanas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceId.Presentacion.Ventanas
{
    enum Ventana{ Inicio, Solicitud }
    class Fabrica
    {
        public static UserControl getVentana(Ventana valor)
        {

            switch (valor)
            {
                case Ventana.Inicio:
                    return new VenInicio();
                case Ventana.Solicitud:
                    return new VenSolicitud();
                default:
                    return null;
            }
        }

    }
}
