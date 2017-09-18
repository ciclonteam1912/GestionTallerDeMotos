using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class TalonarioConfiguracion : EntityTypeConfiguration<Talonario>
    {
        public TalonarioConfiguracion()
        {
            ToTable("Talonarios");

            Property(t => t.Id)
                .HasColumnName("Codigo");
        }
    }
}