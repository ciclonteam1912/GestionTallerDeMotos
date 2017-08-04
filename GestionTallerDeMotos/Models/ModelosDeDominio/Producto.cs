using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [MaxLength(50)]
        public string Marca { get; set; }

        [Display(Name = "Precio Costo")]
        public int PrecioCosto { get; set; }

        [Display(Name = "Precio Venta")]
        public int PrecioVenta { get; set; }

        [Display(Name = "Existencia Actual")]
        public int ExistenciaActual { get; set; }

        [Display(Name = "Existencia Mínima")]
        public int ExistenciaMinima { get; set; }
        
        public Proveedor Proveedor { get; set; }

        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }
    }
}