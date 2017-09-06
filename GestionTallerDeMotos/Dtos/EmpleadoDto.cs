using System;

namespace GestionTallerDeMotos.Dtos
{
    public class EmpleadoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Cedula { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string CorreoElectronico { get; set; }

        public DateTime? FechaDeNacimiento { get; set; }

        public string HoraDeEntrada { get; set; }

        public string HoraDeSalida { get; set; }

        public int Salario { get; set; }

        public byte? CargoId { get; set; }
    }
}