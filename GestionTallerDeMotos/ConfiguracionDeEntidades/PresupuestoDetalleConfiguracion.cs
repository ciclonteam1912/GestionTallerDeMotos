using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class PresupuestoDetalleConfiguracion : EntityTypeConfiguration<PresupuestoDetalle>
    {
        public PresupuestoDetalleConfiguracion()
        {
            ToTable("PresupuestoDetalles");

            Property(pd => pd.Id)
                .HasColumnName("Codigo");

            Property(pd => pd.PresupuestoId)
                .HasColumnName("PresupuestoCodigo");

            Property(pd => pd.ProductoId)
                .HasColumnName("ProductoCodigo");
        }
    }
}