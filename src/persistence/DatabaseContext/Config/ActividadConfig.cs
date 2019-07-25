using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class ActividadConfig
    {
        public ActividadConfig(EntityTypeBuilder<Actividad> builder)
        {
            builder.HasKey(x => x.CodigoActividad);
            builder.Property(x => x.NombreActividad).IsRequired().HasMaxLength(500);
            builder.HasIndex(x => x.NombreActividad).IsUnique();
        }
    }
}