using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Movimiento
    {
        public int MovimientoId { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha {get; set; }

        public decimal Monto { get; set; }

        public TipoMovimiento Tipo { get; set; }

        public int CuentaCorrienteId { get; set; }

        public CuentaCorriente CuentaCorriente { get; set; }
    }
}
