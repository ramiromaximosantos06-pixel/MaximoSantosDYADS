using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Entidades;
namespace Modelo
{
    public class Context : DbContext
    {
        private string Conexion = @"Data Source=DESKTOP-AF18HF7\SQLEXPRESS;
              Initial Catalog=CuentasCorrientesDB;
              Integrated Security=True;
              Persist Security Info=False;
              Pooling=False;
              Encrypt=False;";

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<CuentaCorriente> Cuentas { get; set; }

        public DbSet<Movimiento> Movimientos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(Conexion);
    }
}
