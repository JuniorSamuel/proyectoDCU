using System;
using System.Collections.Generic;
using System.Drawing;
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
        public string nacionalidad { get; set; }
        public string fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public Bitmap imagen { get; set; }

        public Persona()
        {
        }

        public Persona(int idPersona, string nombre, string nacionalidad, string fecha_nacimiento, string sexo, int cedula)
        {
            this.idPersona = idPersona;
            this.cedula = cedula;
            this.nombre = nombre;
            this.nacionalidad = nacionalidad;
            this.fecha_nacimiento = fecha_nacimiento;
            this.sexo = sexo;
            this.nacionalidad = nacionalidad;
            this.telefono = telefono;
        }
        
        public string ToString()
        {
            return "id: " + idPersona + " cedula: " + cedula+" nombre: " + nombre + " nacionalidad: "+nacionalidad +" fecha:" + fecha_nacimiento + " sexo: " + sexo + " telefono:" + telefono + " direccion: " + direccion;
        }
    }
}
