using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class ProveedorConfiguracion : EntityTypeConfiguration<Proveedor>
    {
        public ProveedorConfiguracion()
        {

            ToTable("Proveedores");

            Property(p => p.Id)
                .HasColumnName("Codigo");

            Property(p => p.RazonSocial)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Propietario)
                .HasMaxLength(50);

            Property(p => p.Contacto)
                .HasMaxLength(50);

            Property(p => p.Ruc)
                .IsRequired()
                .HasMaxLength(10);

            Property(p => p.Direccion)
                .HasMaxLength(255);

            Property(p => p.Telefono)
                .HasMaxLength(50);

            Property(p => p.CorreoElectronico)
                .HasMaxLength(50);
        }
    }
}