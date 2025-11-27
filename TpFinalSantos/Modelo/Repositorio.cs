using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Microsoft.EntityFrameworkCore;
namespace Modelo
{
    public class Repositorio
    {
        public IReadOnlyCollection<CuentaCorriente> ListarCuentas()
        {
            using (var context = new Context())
            {
                return context.Cuentas
                    .Include(c => c.Cliente)
                    .Include(c => c.Movimientos)
                    .ToList();
            }
        }

        public IReadOnlyCollection<Movimiento> ListarMovimiento(int CuentaId)
        {
            using (var context = new Context())
            {
                return context.Movimientos
                    .Where(m => m.CuentaCorrienteId == CuentaId)
                    .OrderBy(m => m.Fecha)
                    .ToList();
            }
        }

        public IReadOnlyCollection<Cliente> ListarClientes()
        {
            using (var context = new Context())
            {
                return context.Clientes
                              .OrderBy(c => c.Apellido)
                              .ThenBy(c => c.Nombre)
                              .ToList();
            }
        }
        public void AgregarCliente(Cliente cliente)
        {
            using (var context = new Context())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }
        public void EliminarCuenta(int cuentaId)
        {
            using (var context = new Context())
            {
                var cuenta = context.Cuentas
                    .Include(c => c.Movimientos)
                    .FirstOrDefault(c => c.CuentaCorrienteId == cuentaId);

                if (cuenta != null)
                {
                  
                    if (cuenta.Movimientos.Any())
                        context.Movimientos.RemoveRange(cuenta.Movimientos);

                    context.Cuentas.Remove(cuenta);
                    context.SaveChanges();
                }
            }
        }
        public void AgregarCuenta(CuentaCorriente cuenta)
        {
            using (var context = new Context())
            {
                context.Cuentas.Add(cuenta);
                context.SaveChanges();
            }
        }
        public bool ExisteNumeroCuenta(string numero)
        {
            using var context = new Context();
            return context.Cuentas.Any(c => c.NumeroCuenta == numero);
        }

      
        public bool ExisteNumeroCuentaParaCliente(int clienteId, string numero)
        {
            using var context = new Context();
            return context.Cuentas.Any(c => c.ClienteId == clienteId && c.NumeroCuenta == numero);
        }
        public void AgregarMovimiento(Movimiento movimiento)
        {
            using (var context = new Context())
            {
                context.Movimientos.Add(movimiento);
                context.SaveChanges();
            }


        }
    }
}
