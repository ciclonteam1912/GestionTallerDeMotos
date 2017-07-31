using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Combustible
    {
        public byte Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}