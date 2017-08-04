using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.ViewModels
{
    public class ProductoViewModel
    {
        public IEnumerable<Proveedor> Proveedores { get; set; }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public string Marca { get; set; }

        [Display(Name = "Precio Costo")]
        public int? PrecioCosto { get; set; }

        [Display(Name = "Precio Venta")]
        public int? PrecioVenta { get; set; }

        [Display(Name = "Existencia Actual")]
        public int? ExistenciaActual { get; set; }

        [Display(Name = "Existencia Mínima")]
        public int? ExistenciaMinima { get; set; }

        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }

        public string Titulo
        {
            get
            {
                return Id != 0 ? "Editar Producto" : "Nuevo Producto";
            }
        }

        public ProductoViewModel()
        {

        }

        public ProductoViewModel(Producto producto)
        {
            Id = producto.Id;
            Descripcion = producto.Descripcion;
            Marca = producto.Marca;
            PrecioCosto = producto.PrecioCosto;
            PrecioVenta = producto.PrecioVenta;
            ExistenciaActual = producto.ExistenciaActual;
            ExistenciaMinima = producto.ExistenciaMinima;
            ProveedorId = producto.ProveedorId;
        }
    }
}