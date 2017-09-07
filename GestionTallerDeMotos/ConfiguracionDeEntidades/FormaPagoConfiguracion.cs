using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class FormaPagoConfiguracion : EntityTypeConfiguration<FormaPago>
    {
        public FormaPagoConfiguracion()
        {
            ToTable("FormaPagos");

            Property(fp => fp.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(fp => fp.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            Property(fp => fp.Descripcion)
                .HasMaxLength(255);
        }
    }
}