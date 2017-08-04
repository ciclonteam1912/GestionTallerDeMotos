using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class ProductoConfiguracion : EntityTypeConfiguration<Producto>
    {
        public ProductoConfiguracion()
        {
            ToTable("Productos");

            Property(p => p.Id)
                .HasColumnName("Codigo");

            Property(p => p.Descripcion)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Marca)
                .HasMaxLength(50);

            Property(p => p.ProveedorId)
                .HasColumnName("ProveedorCodigo");
        }
    }
}