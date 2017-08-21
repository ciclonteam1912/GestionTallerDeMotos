using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class EstadoConfiguracion : EntityTypeConfiguration<Estado>
    {
        public EstadoConfiguracion()
        {
            ToTable("Estados");

            Property(e => e.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}