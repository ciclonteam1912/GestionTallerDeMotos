using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class CombustibleConfiguracion : EntityTypeConfiguration<Combustible>
    {
        public CombustibleConfiguracion()
        {
            Property(c => c.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}