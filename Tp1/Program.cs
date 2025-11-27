using System;

namespace BancoConsola
{
    internal class Program
    {
        static GestorBanco gestor = new GestorBanco();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                MostrarMenu();
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese un número válido.");
                    continue;
                }

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            AltaCliente();
                            break;
                        case 2:
                            MostrarClientes();
                            break;
                        case 3:
                            AltaCuenta();
                            break;
                        case 4:
                            RealizarDeposito();
                            break;
                        case 5:
                            RealizarExtraccion();
                            break;
                        case 6:
                            BajaCliente();
                            break;
                        case 7:
                            BajaCuenta();
                            break;
                        case 0:
                            Console.WriteLine("Fin del programa.");
                            break;
                        default:
                            Console.WriteLine("Opción inexistente.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] {ex.Message}");
                }

            } while (opcion != 0);
        }

        static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== SISTEMA BANCARIO - MENÚ PRINCIPAL =====");
            Console.WriteLine("1) Registrar nuevo cliente");
            Console.WriteLine("2) Listar clientes y sus cuentas");
            Console.WriteLine("3) Crear cuenta para un cliente");
            Console.WriteLine("4) Realizar depósito");
            Console.WriteLine("5) Realizar extracción");
            Console.WriteLine("6) Eliminar cliente");
            Console.WriteLine("7) Eliminar cuenta");
            Console.WriteLine("0) Salir");
            Console.Write("Elija una opción: ");
        }

        static void AltaCliente()
        {
            Console.Write("Documento: ");
            string documento = Console.ReadLine() ?? string.Empty;

            Console.Write("Nombre y Apellido: ");
            string nombre = Console.ReadLine() ?? string.Empty;

            Console.Write("Celular: ");
            string celular = Console.ReadLine() ?? string.Empty;

            Console.Write("Correo electrónico: ");
            string correo = Console.ReadLine() ?? string.Empty;

            Console.Write("Fecha de nacimiento (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaNac))
                throw new Exception("Fecha no válida.");

            var cliente = new PersonaCliente
            {
                Documento = documento,
                NombreCompleto = nombre,
                Celular = celular,
                CorreoElectronico = correo,
                FechaNacimiento = fechaNac
            };

            gestor.RegistrarCliente(cliente);
            Console.WriteLine("Cliente registrado correctamente.");
        }

        static void MostrarClientes()
        {
            if (gestor.ListaClientes.Count == 0)
            {
                Console.WriteLine("No hay clientes cargados.");
                return;
            }

            foreach (var cliente in gestor.ListaClientes)
            {
                Console.WriteLine(cliente);
                if (cliente.CuentasBancarias.Count == 0)
                {
                    Console.WriteLine("   (sin cuentas asociadas)");
                }
                else
                {
                    foreach (var cuenta in cliente.CuentasBancarias)
                    {
                        Console.WriteLine("   " + cuenta);
                    }
                }
            }
        }

        static void AltaCuenta()
        {
            var cliente = SeleccionarClientePorDocumento();
            Console.WriteLine("Tipo de cuenta a crear:");
            Console.WriteLine("1) Caja de Ahorro");
            Console.WriteLine("2) Cuenta Corriente");
            Console.Write("Opción: ");

            if (!int.TryParse(Console.ReadLine(), out int tipo))
                throw new Exception("Debe ingresar un número.");

            CuentaBancaria cuenta;
            switch (tipo)
            {
                case 1:
                    cuenta = new CajaAhorroSimple(cliente);
                    break;
                case 2:
                    cuenta = new CuentaCorrienteBancaria(cliente);
                    break;
                default:
                    throw new Exception("Tipo de cuenta no válido.");
            }

            gestor.VincularCuentaACliente(cliente, cuenta);
            Console.WriteLine("Cuenta creada y asociada al cliente.");
        }

        static void RealizarDeposito()
        {
            var cuenta = SeleccionarCuentaDeCliente();
            Console.Write("Monto a depositar: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal monto))
                throw new Exception("Monto no válido.");

            cuenta.Acreditar(monto);
            Console.WriteLine("Depósito realizado correctamente.");
        }

        static void RealizarExtraccion()
        {
            var cuenta = SeleccionarCuentaDeCliente();
            Console.Write("Monto a extraer: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal monto))
                throw new Exception("Monto no válido.");

            cuenta.Extraer(monto);
            Console.WriteLine("Extracción realizada correctamente.");
        }

        static void BajaCliente()
        {
            Console.Write("Documento del cliente a eliminar: ");
            string documento = Console.ReadLine() ?? string.Empty;

            gestor.QuitarCliente(documento);
            Console.WriteLine("Cliente eliminado del sistema.");
        }

        static void BajaCuenta()
        {
            var cuenta = SeleccionarCuentaDeCliente();
            gestor.BorrarCuenta(cuenta);
            Console.WriteLine("Cuenta eliminada correctamente.");
        }

        static PersonaCliente SeleccionarClientePorDocumento()
        {
            Console.Write("Documento del cliente: ");
            string documento = Console.ReadLine() ?? string.Empty;

            var cliente = gestor.ObtenerClientePorDocumento(documento);
            if (cliente == null)
                throw new Exception("Cliente no encontrado.");

            return cliente;
        }

        static CuentaBancaria SeleccionarCuentaDeCliente()
        {
            var cliente = SeleccionarClientePorDocumento();

            if (cliente.CuentasBancarias.Count == 0)
                throw new Exception("El cliente no tiene cuentas.");

            Console.WriteLine("Cuentas del cliente:");
            for (int i = 0; i < cliente.CuentasBancarias.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {cliente.CuentasBancarias[i]}");
            }

            Console.Write("Seleccione el número de cuenta: ");
            if (!int.TryParse(Console.ReadLine(), out int indice))
                throw new Exception("Opción no válida.");

            indice--;

            if (indice < 0 || indice >= cliente.CuentasBancarias.Count)
                throw new Exception("Selección fuera de rango.");

            return cliente.CuentasBancarias[indice];
        }
    }
}
