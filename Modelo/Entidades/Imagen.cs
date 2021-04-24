using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceId.Modelo.Entidades
{
    class Imagen
    {
        public int idImagen { get; set; }
        public int idCedula { get; set; }
        public byte[] imagen {get; set;}
 
        public Imagen()
        {
        }

        public Imagen(int idImagen, int idCedula, byte[] imagene)
        {
            this.idImagen = idImagen;
            this.idCedula = idCedula;
            this.imagen = imagen;
        }
    }
}
