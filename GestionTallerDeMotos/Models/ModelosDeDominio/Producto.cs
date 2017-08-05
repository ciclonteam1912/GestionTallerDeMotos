using GestionTallerDeMotos.Models.AtributosDeValidación;
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
        [Range(0, int.MaxValue, ErrorMessage = "El precio de costo debe ser mayor o igual a {1}")]
        public int PrecioCosto { get; set; }

        [Display(Name = "Precio Venta")]
        [Range(0, int.MaxValue, ErrorMessage = "El precio de venta debe ser mayor o igual a {1}")]
        [PrecioVentaMayorPrecioCosto]
        public int PrecioVenta { get; set; }

        [Display(Name = "Existencia Actual")]
        [Range(0, int.MaxValue, ErrorMessage = "La existencia actual debe ser mayor o igual a {1}")]
        public int ExistenciaActual { get; set; }

        [Display(Name = "Existencia Mínima")]
        [Range(0, int.MaxValue, ErrorMessage = "La existencia mínima debe ser mayor o igual a {1}")]
        [ExistenciaMinMenorExistenciaActual]
        public int ExistenciaMinima { get; set; }
        
        public Proveedor Proveedor { get; set; }

        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }
    }
}