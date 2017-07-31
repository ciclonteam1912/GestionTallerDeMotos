using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Dtos
{
    public class CombustibleDto
    {
        public byte Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}