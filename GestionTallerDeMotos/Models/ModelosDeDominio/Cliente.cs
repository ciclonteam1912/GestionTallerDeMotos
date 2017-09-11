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

        public string Direccion { get; set; }

        public string CorreoElectronico { get; set; }

        public string NombrePropietario { get; set; }

        public DateTime? FechaDeNacimiento { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public Personeria Personeria { get; set; }

        public byte PersoneriaId { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public byte TipoDocumentoId { get; set; }

        [Required]
        public string ValorDocumento { get; set; }

        public string NombreCompleto
        {
            get
            {
                return Nombre.ToUpper() + " " + Apellido.ToUpper();
            }
        }
    }
}