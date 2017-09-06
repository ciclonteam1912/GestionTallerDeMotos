using System;
using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Cedula { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string CorreoElectronico { get; set; }

        public DateTime? FechaDeNacimiento { get; set; }

        public string HoraDeEntrada { get; set; }

        public string HoraDeSalida { get; set; }

        public int Salario { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public Cargo Cargo { get; set; }

        public byte? CargoId { get; set; }
    }
}