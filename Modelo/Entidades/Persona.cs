using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceId.Modelo.Entidades
{
    class Persona
    {
        public int cedula { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string fecha_nacimiento { get; set; }
        public char sexo { get; set; }

        public Persona()
        {
        }

        public Persona(int cedula, string nombre, int edad, string fecha_nacimiento, char sexo)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.edad = edad;
            this.fecha_nacimiento = fecha_nacimiento;
            this.sexo = sexo;
        }                
    }
}
