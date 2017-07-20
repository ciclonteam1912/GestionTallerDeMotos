using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class TipoDocumentoConfiguracion : EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumentoConfiguracion()
        {

            ToTable("TiposDocumento");


            Property(tp => tp.Id)
            .HasColumnName("Codigo");


            Property(tp => tp.Descripcion)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}