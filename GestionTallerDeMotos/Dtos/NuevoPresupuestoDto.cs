using System.Collections.Generic;

namespace GestionTallerDeMotos.Dtos
{
    public class NuevoPresupuestoDto
    {
        public PresupuestoDto Presupuesto { get; set; }

        public List<PresupuestoDetalleDto> PresupuestoDetalles { get; set; }
    }
}