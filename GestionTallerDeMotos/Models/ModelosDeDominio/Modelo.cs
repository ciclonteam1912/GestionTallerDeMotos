using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Modelo
    {
        public byte Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public Marca Marca { get; set; }

        [Display(Name = "Marca")]
        public byte MarcaId { get; set; }
    }
}