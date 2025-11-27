using System;

namespace BancoConsola
{
    public class CajaAhorroSimple : CuentaBancaria
    {
        public decimal TopeExtraccionPorOperacion { get; set; } = 25000m;

        public CajaAhorroSimple(PersonaCliente titular) : base(titular)
        {
        }

        public override void Extraer(decimal monto)
        {
            if (monto <= 0)
                throw new Exception("El monto a extraer debe ser positivo.");

            if (monto > SaldoActual)
                throw new Exception("No dispone de fondos suficientes.");

            if (monto > TopeExtraccionPorOperacion)
                throw new Exception($"El límite por operación es de {TopeExtraccionPorOperacion}.");

            SaldoActual -= monto;
            RegistrarMovimiento("Extracción", monto);
        }

        public override string ToString()
        {
            return base.ToString() + " | Tipo: Caja de Ahorro";
        }
    }
}
