using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using InterfacesEjemploProyecto.Servicios;

namespace InterfacesEjemploProyecto
{
    public class CodigoGenerador : ICodigoGenerador
    {
        public CodigoGenerador() { }

        public string GenerarCodigo(string prefijo)
        {
            Random random = new Random();
            int numRandom = random.Next(1000,9999);
            return $"Codigo generado: {prefijo}-{numRandom}";
        }
    }
}
