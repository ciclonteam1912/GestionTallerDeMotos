using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class ServicioBasicoConfiguracion : EntityTypeConfiguration<ServicioBasico>
    {
        public ServicioBasicoConfiguracion()
        {
            ToTable("ServiciosBasicos");

            Property(sb => sb.Id)
                .HasColumnName("Codigo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(sb => sb.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            Property(sb => sb.Descripcion)
                .HasMaxLength(255);
        }
    }
}