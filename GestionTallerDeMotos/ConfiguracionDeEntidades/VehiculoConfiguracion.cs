using GestionTallerDeMotos.Models.ModelosDeDominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GestionTallerDeMotos.ConfiguracionDeEntidades
{
    public class VehiculoConfiguracion : EntityTypeConfiguration<Vehiculo>
    {
        public VehiculoConfiguracion()
        {
            ToTable("Vehiculos");

            Property(v => v.Id)
                .HasColumnName("Codigo");

            Property(v => v.Matricula)
                .IsRequired()
                .HasMaxLength(20);

            Property(v => v.Chasis)
                .HasMaxLength(20);

            Property(v => v.Motor)
                .HasMaxLength(20);

            Property(v => v.ModeloId)
                .HasColumnName("ModeloCodigo");

            Property(v => v.ClienteId)
                .HasColumnName("ClienteCodigo");

            Property(v => v.Color)
                .HasMaxLength(20);

            Property(v => v.CombustibleId)
                .HasColumnName("CombustibleCodigo");

            Property(v => v.AseguradoraId)
                .HasColumnName("AseguradoraCodigo");
        }
    }
}