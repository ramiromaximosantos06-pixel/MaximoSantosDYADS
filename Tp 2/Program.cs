using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ejercicio02
{
    public enum GeneroContenido { Drama, Comedia, Accion, CienciaFiccion, Documental, Fantasia, Terror, Romance }
    public enum TipoPlan { Basico, Plus, Premium }

    public class Capitulo
    {
        public int Numero { get; }
        public string Titulo { get; }

        public Capitulo(int numero, string titulo)
        {
            Numero = numero;
            Titulo = titulo;
        }

        public override string ToString() => $"Ep{Numero}: {Titulo}";
    }

    public class TemporadaSerie
    {
        public int Numero { get; }
        public List<Capitulo> Capitulos { get; } = new();

        public TemporadaSerie(int numero)
        {
            Numero = numero;
        }

        public override string ToString() => $"Temporada {Numero} ({Capitulos.Count} capítulos)";
    }

    public class SerieTv
    {
        public string Nombre { get; }
        public GeneroContenido Genero { get; }
        public string Director { get; }
        public double Puntuacion { get; }
        public List<TemporadaSerie> Temporadas { get; } = new();

        public SerieTv(string nombre, GeneroContenido genero, string director, double puntuacion)
        {
            Nombre = nombre;
            Genero = genero;
            Director = director;
            Puntuacion = puntuacion;
        }

        public SerieTv(string nombre, GeneroContenido genero, string director)
            : this(nombre, genero, director, 3.0) { }

        public override string ToString()
            => $"{Nombre} | {Genero} | Dir: {Director} | Rank: {Puntuacion:F1} | Temps: {Temporadas.Count}";
    }

    public class CanalTv
    {
        public string Nombre { get; }
        public bool EsExclusivo { get; }
        public List<SerieTv> Series { get; } = new();

        public CanalTv(string nombre, bool esExclusivo)
        {
            Nombre = nombre;
            EsExclusivo = esExclusivo;
        }

        public override string ToString()
            => $"{Nombre} {(EsExclusivo ? "(Exclusivo)" : "")}";
    }

    public abstract class Plan
    {
        public string Codigo { get; }
        public string Nombre { get; }
        public decimal CostoPropio { get; }
        public List<CanalTv> Canales { get; } = new();

        protected Plan(string codigo, string nombre, decimal costoPropio)
        {
            Codigo = codigo;
            Nombre = nombre;
            CostoPropio = costoPropio;
        }

        public abstract TipoPlan Tipo { get; }
        public abstract decimal RecargoSobreAbono(decimal abonoBase);

        public decimal ImporteTotal(decimal abonoBase)
            => CostoPropio + abonoBase + RecargoSobreAbono(abonoBase);

        public override string ToString()
            => $"[{Tipo}] {Nombre} (Cod: {Codigo}) | Costo plan: $ {CostoPropio:N2} | Canales: {Canales.Count}";
    }

    public class PlanBasico : Plan
    {
        public PlanBasico(string codigo, string nombre, decimal costoPropio)
            : base(codigo, nombre, costoPropio) { }

        public override TipoPlan Tipo => TipoPlan.Basico;
        public override decimal RecargoSobreAbono(decimal abonoBase) => 0m;
    }

    public class PlanPlus : Plan
    {
        public PlanPlus(string codigo, string nombre, decimal costoPropio)
            : base(codigo, nombre, costoPropio) { }

        public override TipoPlan Tipo => TipoPlan.Plus;
        public override decimal RecargoSobreAbono(decimal abonoBase)
            => Math.Round(abonoBase * 0.15m, 2);
    }

    public class PlanPremium : Plan
    {
        public PlanPremium(string codigo, string nombre, decimal costoPropio)
            : base(codigo, nombre, costoPropio) { }

        public override TipoPlan Tipo => TipoPlan.Premium;
        public override decimal RecargoSobreAbono(decimal abonoBase)
            => Math.Round(abonoBase * 0.20m, 2);
    }

    public class ClienteCable
    {
        public string Codigo { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public string Dni { get; }
        public DateTime FechaNacimiento { get; }
        public decimal AbonoBase { get; }
        public Plan? PlanContratado { get; private set; }

        public ClienteCable(string codigo, string nombre, string apellido, string dni,
                            DateTime fechaNacimiento, decimal abonoBase)
        {
            Codigo = codigo;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            FechaNacimiento = fechaNacimiento;
            AbonoBase = abonoBase;
        }

        public string NombreCompleto => $"{Apellido}, {Nombre}";

        public void ContratarPlan(Plan plan) => PlanContratado = plan;
        public void DarDeBajaPlan() => PlanContratado = null;

        public decimal ImporteMensual()
            => PlanContratado == null ? AbonoBase : PlanContratado.ImporteTotal(AbonoBase);

        public override string ToString()
            => $"{NombreCompleto} (Cod: {Codigo}, DNI: {Dni}) | Abono base: $ {AbonoBase:N2} | Plan: {(PlanContratado?.Nombre ?? "-")}";
    }

    internal class Program
    {
        static readonly List<CanalTv> Canales = new();
        static readonly List<Plan> Planes = new();
        static readonly List<ClienteCable> Clientes = new();
        static readonly Dictionary<string, int> VentasPorPlan = new();

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            PrecargarDatos();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de TV por Cable (Versión simplificada) ===\n");
                Console.WriteLine("1) Gestión de clientes");
                Console.WriteLine("2) Gestión de contenido (canales / series)");
                Console.WriteLine("3) Gestión de planes y contrataciones");
                Console.WriteLine("4) Reportes");
                Console.WriteLine("0) Salir");
                Console.Write("Opción: ");
                var op = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (op)
                    {
                        case "1": MenuClientes(); break;
                        case "2": MenuContenido(); break;
                        case "3": MenuPlanes(); break;
                        case "4": MenuReportes(); break;
                        case "0": return;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }

                Pausa();
            }
        }

        // CLIENTES

        static void MenuClientes()
        {
            Console.WriteLine("-- CLIENTES --");
            Console.WriteLine("1) Alta de cliente");
            Console.WriteLine("2) Listado de clientes");
            Console.WriteLine("3) Contratar plan");
            Console.WriteLine("4) Dar de baja plan");
            Console.Write("Opción: ");
            var op = Console.ReadLine();

            switch (op)
            {
                case "1": AltaCliente(); break;
                case "2": ListarClientesDetallado(); break;
                case "3": ContratarPlanACliente(); break;
                case "4": BajaPlanCliente(); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }

        static void AltaCliente()
        {
            var codigo = LeerTexto("Código");
            if (Clientes.Any(c => c.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("El código de cliente ya existe.");

            var nombre = LeerTexto("Nombre");
            var apellido = LeerTexto("Apellido");
            var dni = LeerTexto("DNI");

            if (Clientes.Any(c => c.Dni.Equals(dni, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Ya hay un cliente con ese DNI.");

            var fnac = LeerFecha("Fecha de nacimiento (dd/mm/aaaa)");
            var abono = LeerMonto("Abono base");

            var nuevo = new ClienteCable(codigo, nombre, apellido, dni, fnac, abono);
            Clientes.Add(nuevo);
            Console.WriteLine("Cliente creado correctamente.");
        }

        static void ListarClientesDetallado()
        {
            foreach (var c in Clientes.OrderBy(x => x.Apellido).ThenBy(x => x.Nombre))
            {
                Console.WriteLine(c);
                Console.WriteLine("   → Importe mensual: $ " + c.ImporteMensual().ToString("N2"));
            }
        }

        static void ContratarPlanACliente()
        {
            if (!Clientes.Any() || !Planes.Any())
            {
                Console.WriteLine("Faltan clientes o planes para operar.");
                return;
            }

            ListarClientesSimple();
            var codCli = LeerTexto("Código de cliente");
            var cliente = Clientes.FirstOrDefault(c => c.Codigo.Equals(codCli, StringComparison.OrdinalIgnoreCase));
            if (cliente == null) throw new Exception("Cliente no encontrado.");

            ListarPlanesSimple();
            var codPlan = LeerTexto("Código de plan");
            var plan = Planes.FirstOrDefault(p => p.Codigo.Equals(codPlan, StringComparison.OrdinalIgnoreCase));
            if (plan == null) throw new Exception("Plan no encontrado.");

            cliente.ContratarPlan(plan);

            if (!VentasPorPlan.ContainsKey(plan.Codigo))
                VentasPorPlan[plan.Codigo] = 0;
            VentasPorPlan[plan.Codigo]++;

            Console.WriteLine($"Plan contratado: {plan.Nombre}. Nuevo importe mensual: $ {cliente.ImporteMensual():N2}");
        }

        static void BajaPlanCliente()
        {
            ListarClientesSimple();
            var codCli = LeerTexto("Código de cliente");
            var cliente = Clientes.FirstOrDefault(c => c.Codigo.Equals(codCli, StringComparison.OrdinalIgnoreCase));
            if (cliente == null) throw new Exception("Cliente no encontrado.");

            cliente.DarDeBajaPlan();
            Console.WriteLine("Plan dado de baja para el cliente.");
        }

        // CONTENIDO

        static void MenuContenido()
        {
            Console.WriteLine("-- CONTENIDO --");
            Console.WriteLine("1) Alta de canal");
            Console.WriteLine("2) Alta de serie en canal");
            Console.WriteLine("3) Alta de temporada en serie");
            Console.WriteLine("4) Alta de capítulo en temporada");
            Console.WriteLine("5) Listado completo de contenido");
            Console.Write("Opción: ");
            var op = Console.ReadLine();

            switch (op)
            {
                case "1": AltaCanal(); break;
                case "2": AltaSerie(); break;
                case "3": AltaTemporada(); break;
                case "4": AltaCapitulo(); break;
                case "5": ListarContenidoDetallado(); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }

        static void AltaCanal()
        {
            var nombre = LeerTexto("Nombre del canal");
            var exclusivo = LeerSiNo("¿Es exclusivo? (s/n)");

            if (Canales.Any(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Ya existe un canal con ese nombre.");

            Canales.Add(new CanalTv(nombre, exclusivo));
            Console.WriteLine("Canal creado.");
        }

        static void AltaSerie()
        {
            if (!Canales.Any())
            {
                Console.WriteLine("Antes tenés que crear un canal.");
                return;
            }

            ListarCanalesSimple();
            var nombreCanal = LeerTexto("Canal destino");
            var canal = Canales.FirstOrDefault(c => c.Nombre.Equals(nombreCanal, StringComparison.OrdinalIgnoreCase));
            if (canal == null) throw new Exception("Canal no encontrado.");

            var nombre = LeerTexto("Nombre de la serie");
            var genero = ElegirGenero();
            var director = LeerTexto("Director");

            Console.Write("Puntuación (0..5, vacío = 3.0): ");
            var s = Console.ReadLine();
            SerieTv serie = string.IsNullOrWhiteSpace(s)
                ? new SerieTv(nombre, genero, director)
                : new SerieTv(nombre, genero, director, double.Parse(s!, CultureInfo.InvariantCulture));

            canal.Series.Add(serie);
            Console.WriteLine("Serie agregada al canal.");
        }

        static void AltaTemporada()
        {
            var canal = ElegirCanal();
            var serie = ElegirSerie(canal);
            var numTemp = LeerEntero("> Número de temporada");

            if (serie.Temporadas.Any(t => t.Numero == numTemp))
                throw new Exception("Esa temporada ya existe para la serie.");

            serie.Temporadas.Add(new TemporadaSerie(numTemp));
            Console.WriteLine("Temporada creada.");
        }

        static void AltaCapitulo()
        {
            var canal = ElegirCanal();
            var serie = ElegirSerie(canal);
            var numTemp = LeerEntero("> Número de temporada");
            var temp = serie.Temporadas.FirstOrDefault(t => t.Numero == numTemp);
            if (temp == null) throw new Exception("Temporada no encontrada.");

            var numCap = LeerEntero("> Número de capítulo");
            var titulo = LeerTexto("> Título del capítulo");
            temp.Capitulos.Add(new Capitulo(numCap, titulo));
            Console.WriteLine("Capítulo agregado.");
        }

        static void ListarContenidoDetallado()
        {
            foreach (var c in Canales)
            {
                Console.WriteLine("Canal: " + c);
                foreach (var s in c.Series)
                {
                    Console.WriteLine("  - " + s);
                    foreach (var t in s.Temporadas)
                    {
                        Console.WriteLine("     • " + t);
                        foreach (var e in t.Capitulos)
                            Console.WriteLine("        · " + e);
                    }
                }
            }
        }

        // PLANES

        static void MenuPlanes()
        {
            Console.WriteLine("-- PLANES --");
            Console.WriteLine("1) Crear plan");
            Console.WriteLine("2) Agregar canal a plan");
            Console.WriteLine("3) Listar planes");
            Console.Write("Opción: ");
            var op = Console.ReadLine();

            switch (op)
            {
                case "1": CrearPlan(); break;
                case "2": AgregarCanalAPlan(); break;
                case "3": ListarPlanesDetallado(); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }

        static void CrearPlan()
        {
            Console.WriteLine("Tipo de plan: 1) Básico  2) Plus  3) Premium");
            var tipo = Console.ReadLine();

            var codigo = LeerTexto("Código");
            var nombre = LeerTexto("Nombre");
            var costo = LeerMonto("Costo propio del plan");

            Plan plan;
            switch (tipo)
            {
                case "1": plan = new PlanBasico(codigo, nombre, costo); break;
                case "2": plan = new PlanPlus(codigo, nombre, costo); break;
                case "3": plan = new PlanPremium(codigo, nombre, costo); break;
                default:
                    Console.WriteLine("Tipo de plan inválido.");
                    return;
            }

            if (Planes.Any(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Ya existe un plan con ese código.");

            Planes.Add(plan);
            Console.WriteLine("Plan creado correctamente.");
        }

        static void AgregarCanalAPlan()
        {
            if (!Planes.Any() || !Canales.Any())
            {
                Console.WriteLine("Faltan planes o canales.");
                return;
            }

            ListarPlanesSimple();
            var codPlan = LeerTexto("Código del plan");
            var plan = Planes.FirstOrDefault(p => p.Codigo.Equals(codPlan, StringComparison.OrdinalIgnoreCase));
            if (plan == null) throw new Exception("Plan no encontrado.");

            ListarCanalesSimple();
            var nombreCanal = LeerTexto("Nombre del canal a agregar");
            var canal = Canales.FirstOrDefault(c => c.Nombre.Equals(nombreCanal, StringComparison.OrdinalIgnoreCase));
            if (canal == null) throw new Exception("Canal no encontrado.");

            if (plan.Canales.Any(c => c.Nombre.Equals(canal.Nombre, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Ese canal ya está incluido en el plan.");

            plan.Canales.Add(canal);
            Console.WriteLine("Canal sumado al plan.");
        }

        static void ListarPlanesDetallado()
        {
            foreach (var p in Planes)
            {
                Console.WriteLine(p);
                foreach (var c in p.Canales)
                {
                    Console.WriteLine("  - " + c.Nombre);
                    foreach (var s in c.Series)
                        Console.WriteLine("     • " + s.Nombre);
                }
            }
        }

        // REPORTES

        static void MenuReportes()
        {
            Console.WriteLine("-- REPORTES --");
            Console.WriteLine("1) Plan de cada cliente + importes");
            Console.WriteLine("2) Total recaudado mensual");
            Console.WriteLine("3) Plan más vendido + series incluidas");
            Console.WriteLine("4) Series con ranking > 3.5");
            Console.Write("Opción: ");
            var op = Console.ReadLine();

            switch (op)
            {
                case "1": ReporteClientesConImportes(); break;
                case "2": ReporteTotalRecaudado(); break;
                case "3": ReportePlanMasVendido(); break;
                case "4": ReporteSeriesConBuenRanking(); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }

        static void ReporteClientesConImportes()
        {
            foreach (var c in Clientes)
            {
                Console.WriteLine($"{c.NombreCompleto} | Plan: {c.PlanContratado?.Nombre ?? "(ninguno)"} | Importe mensual: $ {c.ImporteMensual():N2}");
            }
        }

        static void ReporteTotalRecaudado()
        {
            var total = Clientes.Sum(c => c.ImporteMensual());
            Console.WriteLine($"Total recaudado en el mes: $ {total:N2}");
        }

        static void ReportePlanMasVendido()
        {
            if (!VentasPorPlan.Any())
            {
                Console.WriteLine("No hay contrataciones registradas.");
                return;
            }

            var kv = VentasPorPlan.OrderByDescending(x => x.Value).First();
            var plan = Planes.FirstOrDefault(p => p.Codigo == kv.Key);
            if (plan == null)
            {
                Console.WriteLine("No se encontraron datos del plan.");
                return;
            }

            Console.WriteLine($"Plan más contratado: {plan.Nombre} ({plan.Tipo}) - {kv.Value} venta(s)");
            foreach (var c in plan.Canales)
            {
                Console.WriteLine("  - " + c.Nombre);
                foreach (var s in c.Series)
                    Console.WriteLine("     • " + s.Nombre);
            }
        }

        static void ReporteSeriesConBuenRanking()
        {
            var series = Canales
                .SelectMany(c => c.Series)
                .Where(s => s.Puntuacion > 3.5)
                .OrderByDescending(s => s.Puntuacion)
                .ToList();

            if (!series.Any())
            {
                Console.WriteLine("No hay series con ranking mayor a 3.5.");
                return;
            }

            foreach (var s in series)
                Console.WriteLine($"{s.Nombre} | Rank {s.Puntuacion:F1} | {s.Genero} | Dir. {s.Director}");
        }

        // HELPERS

        static string LeerTexto(string etiqueta)
        {
            Console.Write(etiqueta + ": ");
            var s = Console.ReadLine();
            return string.IsNullOrWhiteSpace(s) ? "" : s.Trim();
        }

        static DateTime LeerFecha(string etiqueta)
        {
            while (true)
            {
                Console.Write(etiqueta + ": ");
                var s = Console.ReadLine();
                if (DateTime.TryParseExact(s, new[] { "dd/MM/yyyy", "d/M/yyyy" },
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                    return dt.Date;

                Console.WriteLine("* Fecha inválida (ej: 05/04/2002).");
            }
        }

        static decimal LeerMonto(string etiqueta)
        {
            while (true)
            {
                Console.Write(etiqueta + ": ");
                var s = Console.ReadLine();
                if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out var d) && d >= 0)
                    return Math.Round(d, 2);

                Console.WriteLine("* Monto inválido (>= 0).");
            }
        }

        static int LeerEntero(string etiqueta)
        {
            while (true)
            {
                Console.Write(etiqueta + ": ");
                var s = Console.ReadLine();
                if (int.TryParse(s, out var n) && n > 0)
                    return n;

                Console.WriteLine("* Número inválido (> 0).");
            }
        }

        static bool LeerSiNo(string etiqueta)
        {
            while (true)
            {
                Console.Write(etiqueta + " ");
                var s = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
                if (s == "s" || s == "si" || s == "sí") return true;
                if (s == "n" || s == "no") return false;
                Console.WriteLine("* Responder s/n.");
            }
        }

        static GeneroContenido ElegirGenero()
        {
            var values = Enum.GetValues(typeof(GeneroContenido)).Cast<GeneroContenido>().ToList();
            for (int i = 0; i < values.Count; i++)
                Console.WriteLine($" {i + 1}) {values[i]}");

            while (true)
            {
                Console.Write("Elegí género (número): ");
                var s = Console.ReadLine();
                if (int.TryParse(s, out var n) && n >= 1 && n <= values.Count)
                    return values[n - 1];

                Console.WriteLine("* Opción inválida.");
            }
        }

        static CanalTv ElegirCanal()
        {
            ListarCanalesSimple();
            var nombre = LeerTexto("Canal");
            var canal = Canales.FirstOrDefault(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (canal == null) throw new Exception("Canal no encontrado.");
            return canal;
        }

        static SerieTv ElegirSerie(CanalTv canal)
        {
            foreach (var s in canal.Series)
                Console.WriteLine(" - " + s.Nombre);

            var nombre = LeerTexto("Serie");
            var serie = canal.Series.FirstOrDefault(x => x.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (serie == null) throw new Exception("Serie no encontrada.");
            return serie;
        }

        static void ListarPlanesSimple()
        {
            foreach (var p in Planes)
                Console.WriteLine($"{p.Codigo} - {p.Nombre} [{p.Tipo}]");
        }

        static void ListarCanalesSimple()
        {
            foreach (var c in Canales)
                Console.WriteLine("- " + c.Nombre + (c.EsExclusivo ? " (Exclusivo)" : ""));
        }

        static void ListarClientesSimple()
        {
            foreach (var c in Clientes)
                Console.WriteLine($"{c.Codigo} - {c.NombreCompleto}");
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresioná una tecla para continuar...");
            Console.ReadKey(true);
        }

        // SEED

        static void PrecargarDatos()
        {
            var hbo = new CanalTv("HBO Max", true);
            var natgeo = new CanalTv("NatGeo", false);
            Canales.Add(hbo);
            Canales.Add(natgeo);

            var cosmos = new SerieTv("Cosmos", GeneroContenido.Documental, "Ann Druyan", 4.8);
            var temp1 = new TemporadaSerie(1);
            temp1.Capitulos.Add(new Capitulo(1, "Standing Up"));
            cosmos.Temporadas.Add(temp1);
            natgeo.Series.Add(cosmos);

            var lastK = new SerieTv("The Last Kingdom", GeneroContenido.Accion, "Peter Hoar", 4.4);
            var temp2 = new TemporadaSerie(1);
            temp2.Capitulos.Add(new Capitulo(1, "Episode 1"));
            temp2.Capitulos.Add(new Capitulo(2, "Episode 2"));
            lastK.Temporadas.Add(temp2);
            hbo.Series.Add(lastK);

            var basico = new PlanBasico("PL-BAS", "Básico", 0);
            basico.Canales.Add(natgeo);

            var plus = new PlanPlus("PL-PLS", "Plus", 1000);
            plus.Canales.Add(natgeo);

            var premium = new PlanPremium("PL-PRM", "Premium", 2500);
            premium.Canales.Add(hbo);
            premium.Canales.Add(natgeo);

            Planes.Add(basico);
            Planes.Add(plus);
            Planes.Add(premium);

            VentasPorPlan["PL-BAS"] = 0;
            VentasPorPlan["PL-PLS"] = 0;
            VentasPorPlan["PL-PRM"] = 0;

            Clientes.Add(new ClienteCable("CL001", "Ana", "Gómez", "30111222", new DateTime(1995, 5, 12), 8000));
            Clientes.Add(new ClienteCable("CL002", "Bruno", "Pérez", "33123456", new DateTime(1990, 10, 3), 6500));
        }
    }
}
