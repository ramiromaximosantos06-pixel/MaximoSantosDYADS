using System;

namespace BancoConsola
{
    public class Movimiento
    {
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }

        public Movimiento(DateTime fecha, string concepto, decimal monto)
        {
            Fecha = fecha;
            Concepto = concepto;
            Monto = monto;
        }

        public override string ToString()
        {
            return $"{Fecha:g} - {Concepto}: ${Monto}";
        }
    }
}
