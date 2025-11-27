using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoConsola
{
    public class GestorBanco
    {
        public List<PersonaCliente> ListaClientes { get; set; } = new List<PersonaCliente>();

        public void RegistrarCliente(PersonaCliente nuevoCliente)
        {
            if (ListaClientes.Any(c => c.Documento == nuevoCliente.Documento))
                throw new Exception("Ya hay un cliente registrado con ese documento.");

            if (string.IsNullOrWhiteSpace(nuevoCliente.NombreCompleto) ||
                string.IsNullOrWhiteSpace(nuevoCliente.Celular) ||
                string.IsNullOrWhiteSpace(nuevoCliente.CorreoElectronico))
                throw new Exception("Nombre, teléfono y correo son obligatorios.");

            ListaClientes.Add(nuevoCliente);
        }

        public PersonaCliente? ObtenerClientePorDocumento(string documento)
        {
            return ListaClientes.FirstOrDefault(c => c.Documento == documento);
        }

        public List<PersonaCliente> BuscarClientesPorNombre(string textoNombre)
        {
            return ListaClientes
                .Where(c => c.NombreCompleto.Contains(textoNombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void QuitarCliente(string documento)
        {
            var cliente = ObtenerClientePorDocumento(documento);
            if (cliente == null)
                throw new Exception("No se encontró un cliente con ese documento.");

            if (cliente.CuentasBancarias.Any())
                throw new Exception("No se puede eliminar un cliente que aún tiene cuentas asociadas.");

            ListaClientes.Remove(cliente);
        }

        public void VincularCuentaACliente(PersonaCliente titular, CuentaBancaria nuevaCuenta)
        {
            titular.CuentasBancarias.Add(nuevaCuenta);
        }

        public void BorrarCuenta(CuentaBancaria cuenta)
        {
            if (cuenta.SaldoActual != 0)
                throw new Exception("La cuenta debe tener saldo cero para poder eliminarla.");

            cuenta.Titular.CuentasBancarias.Remove(cuenta);
        }
    }
}
