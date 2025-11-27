using Entidades;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Controladora
    {
        private Repositorio repositorio = new Repositorio();

        private static Controladora instancia;
        public static Controladora Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Controladora();
                }
                return instancia;
            }
        }

        public string AgregarCuenta(CuentaCorriente cuenta)
        {
            var numeroValido = !string.IsNullOrWhiteSpace(cuenta.NumeroCuenta);
            var clienteValido = cuenta.ClienteId > 0;
            if (!numeroValido || !clienteValido) return "Datos de cuenta inválidos";

            
            if (repositorio.ExisteNumeroCuenta(cuenta.NumeroCuenta))
                return "Ya existe una cuenta con ese número.";

         
            repositorio.AgregarCuenta(cuenta);
            return "Cuenta registrada";
        }
        public IReadOnlyCollection<Cliente> ListarCliente() 
        {
            return repositorio.ListarClientes();
        }
        public IReadOnlyCollection<CuentaCorriente> ListarCuentas()
        {
            return repositorio.ListarCuentas();
        }
        public string EliminarCuenta(int cuentaId)
        {
            try
            {
                repositorio.EliminarCuenta(cuentaId);
                return "Cuenta eliminada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la cuenta: {ex.Message}";
            }
        }

        public string AgregarCliente(Cliente cliente)
        {
            var nombreValido = !string.IsNullOrWhiteSpace(cliente.Nombre);
            var apellidoValido = !string.IsNullOrWhiteSpace(cliente.Apellido);
            var dniValido = !string.IsNullOrWhiteSpace(cliente.Dni);

            if (nombreValido && apellidoValido && dniValido)
            {
                repositorio.AgregarCliente(cliente);
                return "Cliente registrado";
            }
            return "atos de cliente inválidos";
        }



        public IReadOnlyCollection<Movimiento> ListarMovimientos(int CuentaId)
        {
            return repositorio.ListarMovimiento(CuentaId);

        }
    
        public string AgregarMovimiento(Movimiento movimiento)
        {
            var montoValido = movimiento.Monto > 0;
            var tipoValido = movimiento.Tipo == TipoMovimiento.debito ||
                              movimiento.Tipo == TipoMovimiento.credito;
            var cuentaValida = movimiento.CuentaCorrienteId > 0;

            if (montoValido && tipoValido && cuentaValida)
            {
                repositorio.AgregarMovimiento(movimiento);
                return "Movimiento registrado";
            }

            return "Datos de movimiento inválidos";
        }

        public (decimal totalDebitos, decimal totalCreditos, decimal Saldo) ObtenerResumenCuenta(int CuentaId) 
        {
            var movimientos = repositorio.ListarMovimiento(CuentaId);

            var totalCreditos = movimientos
                .Where(m => m.Tipo == TipoMovimiento.credito)
                .Sum(m => m.Monto);

            var totalDebitos = movimientos
                .Where(m => m.Tipo == TipoMovimiento.debito)
                .Sum(m => m.Monto);

            var saldo = totalCreditos - totalDebitos;

            return (totalDebitos, totalCreditos, saldo);
        }
    }
}

