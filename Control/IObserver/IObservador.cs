using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceId.Control.IObserver
{
    interface IObservador
    {
        void Actualizar(int count, int id); 
    }
}
