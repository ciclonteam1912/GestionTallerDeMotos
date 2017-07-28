using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class PersoneriaConfiguracion : EntityTypeConfiguration<Personeria>
    {
        public PersoneriaConfiguracion()
        {

            Property(p => p.Id)
            .HasColumnName("Codigo")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(p => p.Descripcion)
            .IsRequired()
            .HasMaxLength(20);
        }
    }
}