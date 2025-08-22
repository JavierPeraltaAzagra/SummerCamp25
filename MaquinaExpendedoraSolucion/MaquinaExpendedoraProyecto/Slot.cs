using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedoraProyecto
{
    internal class Slot
    {
        public string Id { get; set; }
        public Producto Producto { get; set; }
        public int Capacidad { get; set; }
        public int Cantidad { get; set; }
        public DateTime UltimaReposicion { get; set; }
        public int StockMinimo { get; set; }

        public void Dispensar()
        {
            if (Cantidad > 0) Cantidad--;
        }

        public void Reponer(int cantidad)
        {
            if (Cantidad + cantidad <= Capacidad)
            {
                Cantidad += cantidad;
                UltimaReposicion = DateTime.Now;
            }
            else
            {
                Console.WriteLine("No se puede reponer más allá de la capacidad del slot.");
            }
        }
        
        public void EstablecerProducto(Producto producto)
        {
            Producto = producto;
            Cantidad = 0;
            UltimaReposicion = DateTime.Now;
        }
        
        public bool NecesitaReposicion()
        {
            return Cantidad < StockMinimo;
        }
        
        public bool ContieneProducto(string nombreProducto)
        {
            return Producto != null && Producto.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase);
        }
        
        public void Vaciar()
        {
            Producto = null;
            Cantidad = 0;
            UltimaReposicion = DateTime.MinValue;
        }
    }
}
