using System;
using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        public string Chasis { get; set; }

        public float? Kilometro { get; set; }

        public string Motor { get; set; }

        public int? Cilindrada { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public string Color { get; set; }

        public Modelo Modelo { get; set; }

        [Display(Name = "Modelo")]
        public byte ModeloId { get; set; }

        public Cliente Cliente { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        public Combustible Combustible { get; set; }

        [Display(Name = "Combustible")]
        public byte CombustibleId { get; set; }

        public Aseguradora Aseguradora { get; set; }

        [Display(Name = "Aseguradora")]
        public byte AseguradoraId { get; set; }
    }
}