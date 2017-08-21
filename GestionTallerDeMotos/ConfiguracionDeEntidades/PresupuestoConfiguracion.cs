using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class PresupuestoConfiguracion : EntityTypeConfiguration<Presupuesto>
    {
        public PresupuestoConfiguracion()
        {
            ToTable("Presupuestos");

            Property(p => p.Id)
                .HasColumnName("Codigo");

            Property(p => p.VehiculoId)
                .HasColumnName("VehiculoCodigo");

            Property(p => p.EstadoId)
                .HasColumnName("EstadoCodigo");
        }
    }
}