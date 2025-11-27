using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CuentaCorriente
    {
        public int CuentaCorrienteId { get; set; }

        public string NumeroCuenta { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public List<Movimiento> Movimientos { get; set; } = new List<Movimiento>();


        public decimal saldo

        {
            get
            {
                var TotalCredito = Movimientos.Where(m => m.Tipo == TipoMovimiento.credito).Sum(m => (decimal?)m.Monto) ?? 0m;

                var TotalDebito = Movimientos.Where(m => m.Tipo == TipoMovimiento.debito).Sum(m => (decimal?)m.Monto) ?? 0m;

                return TotalCredito - TotalDebito;
            }
        }
    }
}
