using System;
using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Dtos
{
    public class VehiculoDto
    {
        public int Id { get; set; }

        [Required]
        public string Matricula { get; set; }

        public string Chasis { get; set; }

        public float Kilometro { get; set; }

        public string Motor { get; set; }

        public int Cilindrada { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public string Color { get; set; }

        public ModeloDto Modelo { get; set; }

        public byte ModeloId { get; set; }

        public ClienteDto Cliente { get; set; }

        public int ClienteId { get; set; }

        public CombustibleDto Combustible { get; set; }

        public byte CombustibleId { get; set; }

        public AseguradoraDto Aseguradora { get; set; }

        public byte AseguradoraId { get; set; }
    }
}