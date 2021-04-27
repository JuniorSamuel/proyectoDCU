using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceId.Modelo.Entidades
{
    class Persona
    {
        public int idPersona { get; set; }
        public string direccion { get; set; }
        public string nacionalidad { get; set; }
        public int cedula { get; set; }
        public string nombre { get; set; }
        public int telefono { get;  set; }
        public string fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public string apellido { get; set; }
        public Persona()
        {
        }

        public Persona(int idPersona, string nombre, string nacionalidad, string fecha_nacimiento, string sexo, int cedula, string direccion, int telefono)
        {
            this.idPersona = idPersona;
            this.cedula = cedula;
            this.nombre = nombre;
            this.telefono = telefono;
            this.fecha_nacimiento = fecha_nacimiento;
            this.sexo = sexo;
            this.nacionalidad = nacionalidad;
            this.direccion = direccion;
        }                
    }
}
