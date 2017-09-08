using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class ServicioBasico
    {
        public byte Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Servicio Básico" : "Agregar Servicio Básico";
            }
        }

        public ServicioBasico()
        {

        }

        public ServicioBasico(ServicioBasico servicioBasico)
        {
            Id = servicioBasico.Id;
            Nombre = servicioBasico.Nombre;
            Descripcion = servicioBasico.Descripcion;
        }
    }
}