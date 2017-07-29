using System;
using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        [Display(Name = "Teléfono")]
        public string Direccion { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Propietario")]
        public string NombrePropietario { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaDeNacimiento { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public Personeria Personeria { get; set; }

        [Display(Name = "Personería")]
        public byte PersoneriaId { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        [Display(Name = "Tipo de Documento")]
        public byte TipoDocumentoId { get; set; }

        [Required]
        [Display(Name = "Valor del Documento")]
        public string ValorDocumento { get; set; }
    }
}