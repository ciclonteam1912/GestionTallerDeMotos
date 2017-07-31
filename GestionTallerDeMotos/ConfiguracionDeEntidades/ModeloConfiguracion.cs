using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class ModeloConfiguracion : EntityTypeConfiguration<Modelo>
    {
        public ModeloConfiguracion()
        {
            ToTable("Modelos");

            Property(m => m.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(20);

            Property(m => m.MarcaId)
                .HasColumnName("MarcaCodigo");
        }
    }
}