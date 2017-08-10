using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class PresupuestoDetalleConfiguracion : EntityTypeConfiguration<PresupuestoDetalle>
    {
        public PresupuestoDetalleConfiguracion()
        {
            ToTable("PresupuestoDetalles");

            HasKey(pd => new { pd.Id, pd.PresupuestoId, pd.ProductoId });

            Property(pd => pd.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(pd => pd.PresupuestoId)
                .HasColumnName("PresupuestoCodigo");

            Property(pd => pd.ProductoId)
                .HasColumnName("ProductoCodigo");
        }
    }
}