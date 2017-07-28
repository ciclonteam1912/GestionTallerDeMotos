using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class ClienteConfiguracion : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracion()
        {

            Property(c => c.Id)
            .HasColumnName("Codigo");

            Property(c => c.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            Property(c => c.Apellido)
            .HasMaxLength(50);

            Property(c => c.Direccion)
            .HasMaxLength(255);

            Property(c => c.Telefono)
            .HasMaxLength(50);

            Property(c => c.CorreoElectronico)
            .HasMaxLength(50);

            Property(c => c.NombrePropietario)
            .HasMaxLength(50);

            Property(c => c.PersoneriaId)
            .HasColumnName("PersoneriaCodigo");

            Property(c => c.TipoDocumentoId)
            .HasColumnName("TipoDocumentoCodigo");

            Property(c => c.ValorDocumento)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}