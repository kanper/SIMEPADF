using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    class ProyectoConfig
    {
        public ProyectoConfig(EntityTypeBuilder<Proyecto> entityBuilder)
        {
            entityBuilder.HasKey(x => x.CodigoProyecto);
            entityBuilder.Property(x => x.NombreProyecto).IsRequired().HasMaxLength(500);
            entityBuilder.Property(x => x.Regional).IsRequired();
            entityBuilder.Property(x => x.FechaAprobacion).IsRequired();
            entityBuilder.Property(x => x.FechaInicio).IsRequired();
            entityBuilder.Property(x => x.FechaFin).IsRequired();
            entityBuilder.Property(x => x.MontoProyecto).IsRequired();
            entityBuilder.Property(x => x.TipoBeneficiario).HasMaxLength(1);
        }
    }
}
