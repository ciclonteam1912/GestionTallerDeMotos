using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Data.Entity.ModelConfiguration;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class EmpleadoConfiguracion : EntityTypeConfiguration<Empleado>
    {
        public EmpleadoConfiguracion()
        {
            ToTable("Empleados");

            Property(e => e.Id)
                .HasColumnName("Codigo");

            Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Cedula)
                .HasMaxLength(50)
                .IsRequired();

            Property(e => e.Direccion)
                .HasMaxLength(255);

            Property(e => e.Telefono)
                .HasMaxLength(50);

            Property(e => e.CorreoElectronico)
                .HasMaxLength(50);

            Property(e => e.HoraDeEntrada)
                .HasMaxLength(10);

            Property(e => e.HoraDeSalida)
                .HasMaxLength(10);

            Property(e => e.CargoId)
                .HasColumnName("CargoCodigo");
        }
    }
}