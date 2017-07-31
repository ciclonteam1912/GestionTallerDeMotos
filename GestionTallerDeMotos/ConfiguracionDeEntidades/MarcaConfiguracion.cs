using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class MarcaConfiguracion : EntityTypeConfiguration<Marca>
    {
        public MarcaConfiguracion()
        {
            Property(m => m.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}