using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Marca
    {
        public byte Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Marca" : "Nueva Marca";
            }
        }

        public Marca()
        {

        }

        public Marca(Marca marca)
        {
            Id = marca.Id;
            Nombre = marca.Nombre;
        }
    }
}