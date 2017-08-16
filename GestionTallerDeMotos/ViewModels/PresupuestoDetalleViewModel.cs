using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Collections.Generic;

namespace GestionTallerDeMotos.ViewModels
{
    public class PresupuestoDetalleViewModel
    {
        public IEnumerable<Producto> Productos { get; set; }
    }
}