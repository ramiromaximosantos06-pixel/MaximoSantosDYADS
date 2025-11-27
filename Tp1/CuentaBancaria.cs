using System;
using System.Collections.Generic;

namespace BancoConsola
{
    public abstract class CuentaBancaria
    {
        private static int contadorCuentas = 10000;

        public int NumeroCuenta { get; private set; }
        public PersonaCliente Titular { get; set; }
        public decimal SaldoActual { get; protected set; }
        public List<Movimiento> HistorialMovimientos { get; set; } = new List<Movimiento>();

        protected CuentaBancaria(PersonaCliente titular)
        {
            NumeroCuenta = contadorCuentas++;
            Titular = titular;
            SaldoActual = 0m;
        }

        public abstract void Extraer(decimal monto);

        public virtual void Acreditar(decimal monto)
        {
            if (monto <= 0)
                throw new Exception("El monto a acreditar debe ser mayor que cero.");

            SaldoActual += monto;
            RegistrarMovimiento("Depósito", monto);
        }

        protected void RegistrarMovimiento(string concepto, decimal monto)
        {
            HistorialMovimientos.Add(new Movimiento(DateTime.Now, concepto, monto));
        }

        public override string ToString()
        {
            return $"Cuenta N°: {NumeroCuenta} | Titular: {Titular.NombreCompleto} | Saldo: ${SaldoActual}";
        }
    }
}
