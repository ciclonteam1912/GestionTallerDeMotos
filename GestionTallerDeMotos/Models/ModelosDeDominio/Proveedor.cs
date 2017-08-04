using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; }

        public string Contacto { get; set; }

        public string Propietario { get; set; }

        [Required]
        [Display(Name = "RUC")]
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
                return Id != 0 ? "Editar Proveedor" : "Nuevo Proveedor";
            }
        }

        public Proveedor()
        {

        }

        public Proveedor(Proveedor proveedor)
        {
            Id = proveedor.Id;
            RazonSocial = proveedor.RazonSocial;
            Contacto = proveedor.Contacto;
            Propietario = proveedor.Propietario;
            Ruc = proveedor.Ruc;
            Direccion = proveedor.Direccion;
            Telefono = proveedor.Telefono;
            CorreoElectronico = proveedor.CorreoElectronico;
        }
    }
}