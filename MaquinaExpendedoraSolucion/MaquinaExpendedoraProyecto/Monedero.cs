using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedoraProyecto
{
    internal class Monedero
    {
        public decimal Saldo { get; private set; }
        public int MonedaTipoEuro { get; set; }
        public int MonedaTipoCincuentaCentimos { get; set; }

        public Monedero()
        {
            Saldo = 0;
        }

        public void InsertarMoneda(decimal cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("La cantidad debe ser mayor que cero.");
            }
            Saldo += cantidad;
        }

        public void RetirarSaldo()
        {
            Saldo = 0;
        }

        public bool SaldoSuficiente(decimal precio)
        {
            return Saldo >= precio;
        }
    }
}
