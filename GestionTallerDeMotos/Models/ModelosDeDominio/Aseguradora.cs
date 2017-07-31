using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Aseguradora
    {
        public byte Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Contacto { get; set; }

        public string Ruc { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Aseguradora" : "Nueva Aseguradora";
            }
        }

        public Aseguradora()
        {

        }

        public Aseguradora(Aseguradora aseguradora)
        {
            Id = aseguradora.Id;
            Nombre = aseguradora.Nombre;
            Contacto = aseguradora.Contacto;
            Ruc = aseguradora.Ruc;
            Direccion = aseguradora.Direccion;
            Telefono = aseguradora.Telefono;
            CorreoElectronico = aseguradora.CorreoElectronico;
        }
    }
}