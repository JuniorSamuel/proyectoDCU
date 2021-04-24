using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceId.Control.IObserver
{
    public interface IObservable
    {
        //void Agregar(IObservador Objeto);
        //void eliminar(IObservador Objeto);
        void Notificar();
    }
}
