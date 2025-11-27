using System;

namespace BancoConsola
{
    public class CuentaCorrienteBancaria : CuentaBancaria
    {
        public decimal MontoMaximoDescubierto { get; set; } = 8000m;

        public CuentaCorrienteBancaria(PersonaCliente titular) : base(titular)
        {
        }

        public override void Extraer(decimal monto)
        {
            if (monto <= 0)
                throw new Exception("El monto a extraer debe ser positivo.");

            decimal saldoPosterior = SaldoActual - monto;

            if (saldoPosterior < -MontoMaximoDescubierto)
                throw new Exception("Se supera el límite de descubierto autorizado.");

            SaldoActual -= monto;
            RegistrarMovimiento("Extracción", monto);
        }

        public override string ToString()
        {
            return base.ToString() + $" | Tipo: Cuenta Corriente | Descubierto: ${MontoMaximoDescubierto}";
        }
    }
}
