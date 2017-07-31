using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Combustible
    {
        public byte Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Combustible" : "Nuevo Combustible";
            }
        }

        public Combustible()
        {

        }

        public Combustible(Combustible combustible)
        {
            Id = combustible.Id;
            Nombre = combustible.Nombre;
        }
    }
}