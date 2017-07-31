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
    }
}