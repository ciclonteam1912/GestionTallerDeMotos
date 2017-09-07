using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class FormaPago
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
                return Id != 0 ? "Editar Forma de Pago" : "Agregar Forma de Pago";
            }
        }

        public FormaPago()
        {

        }

        public FormaPago(FormaPago formaPago)
        {
            Id = formaPago.Id;
            Nombre = formaPago.Nombre;
            Descripcion = formaPago.Descripcion;
        }
    }
}