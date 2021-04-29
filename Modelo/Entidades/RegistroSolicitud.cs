using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceId.Modelo.Entidades
{
    class RegistroSolicitud
    {
        public int idRegistro { get; set; }
        public string solicitd { get; set; }
        public int idPersona { get; set; }
        public string fecha { get; set; }
        //public string estado { get; set; }
        public string descripcion { get; set; }

        public RegistroSolicitud()
        {

        }
    }
}
