using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Dtos
{
    public class AseguradoraDto
    {
        public byte Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Contacto { get; set; }

        public string Ruc { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string CorreoElectronico { get; set; }
    }
}