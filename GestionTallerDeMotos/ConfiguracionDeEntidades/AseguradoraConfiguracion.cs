using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class AseguradoraConfiguracion : EntityTypeConfiguration<Aseguradora>
    {
        public AseguradoraConfiguracion()
        {
            Property(a => a.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Nombre)
                .IsRequired()
                .HasMaxLength(20);

            Property(a => a.Contacto)
                .HasMaxLength(50);

            Property(a => a.Ruc)
                .HasMaxLength(10);

            Property(a => a.Direccion)
                .HasMaxLength(255);

            Property(a => a.Telefono)
                .HasMaxLength(50);

            Property(a => a.CorreoElectronico)
                .HasMaxLength(50);
        }
    }
}