using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedoraProyecto
{
    internal class Producto
    {
        public string Nombre { get; }
        public decimal Precio { get; }

        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }
}
