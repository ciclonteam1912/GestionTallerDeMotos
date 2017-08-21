using System;

namespace GestionTallerDeMotos.Dtos
{
    public class PresupuestoDto
    {
        public int Id { get; set; }

        public DateTime FechaEmision { get; set; }

        public int VehiculoId { get; set; }

        public int TotalPresupuesto { get; set; }

        public byte EstadoId { get; set; }
    }
}