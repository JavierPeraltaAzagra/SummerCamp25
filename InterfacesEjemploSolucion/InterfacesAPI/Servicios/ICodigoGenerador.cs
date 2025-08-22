using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesEjemploProyecto.Servicios
{
    public interface ICodigoGenerador
    {
        string GenerarCodigo(string prefijo);
    }
}
