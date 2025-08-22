using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedoraProyecto
{
    internal class VendingMachine
    {
        public Slot Slot1 { get; set; }
        public Slot Slot2 { get; set; }
        public Slot Slot3 { get; set; }
        public Monedero Monedero { get; set; }

        public void InsertarMoneda(decimal cantidad) { /* ... */ }
        public void SeleccionarProducto(int slotId) { /* ... */ }
    }
}
