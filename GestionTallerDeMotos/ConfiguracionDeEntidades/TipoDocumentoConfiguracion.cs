using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class TipoDocumentoConfiguracion : EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumentoConfiguracion()
        {

            ToTable("TiposDocumento");


            Property(tp => tp.Id)
            .HasColumnName("Codigo")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(tp => tp.Descripcion)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}