using System;
using System.Collections.Generic;

namespace BancoConsola
{
    public class PersonaCliente
    {
        public string Documento { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string CorreoElectronico { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }

        public List<CuentaBancaria> CuentasBancarias { get; set; } = new List<CuentaBancaria>();

        public int Edad
        {
            get
            {
                var hoy = DateTime.Today;
                int edad = hoy.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
                return edad;
            }
        }

        public override string ToString()
        {
            return $"{NombreCompleto} (Doc: {Documento}) - Cel: {Celular} - Mail: {CorreoElectronico} - Edad: {Edad}";
        }
    }
}
