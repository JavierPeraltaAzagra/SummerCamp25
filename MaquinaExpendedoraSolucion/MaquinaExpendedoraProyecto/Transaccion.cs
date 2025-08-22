using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedoraProyecto
{
    internal class Transaccion
    {
        public Producto Producto { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal Cambio { get; set; }
        public bool Exitosa { get; set; }
        public DateTime FechaHoraTransaccion { get; set; }
    }
}
