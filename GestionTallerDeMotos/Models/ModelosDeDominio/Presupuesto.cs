using System;

namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Presupuesto
    {
        public int Id { get; set; }

        public DateTime FechaEmision { get; set; }

        public Vehiculo Vehiculo { get; set; }

        public int VehiculoId { get; set; }

        public bool PresupuestoAceptado { get; set; }
    }
}