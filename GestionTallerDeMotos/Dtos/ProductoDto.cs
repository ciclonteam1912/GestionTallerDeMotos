using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public string Marca { get; set; }

        public int PrecioCosto { get; set; }

        public int PrecioVenta { get; set; }

        public int ExistenciaActual { get; set; }

        public int ExistenciaMinima { get; set; }

        public ProveedorDto Proveedor { get; set; }

        public int ProveedorId { get; set; }
    }
}