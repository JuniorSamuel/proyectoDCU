using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceId.Modelo.Entidades
{
    class Persona
    {
        public int idPersona { get; set; }
        public int cedula { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string fecha_nacimiento { get; set; }
        public string sexo { get; set; }

        public Persona()
        {
        }

        public Persona(int idPersona, string nombre, int edad, string fecha_nacimiento, string sexo, int cedula)
        {
            this.idPersona = idPersona;
            this.cedula = cedula;
            this.nombre = nombre;
            this.edad = edad;
            this.fecha_nacimiento = fecha_nacimiento;
            this.sexo = sexo;
        }                
    }
}
