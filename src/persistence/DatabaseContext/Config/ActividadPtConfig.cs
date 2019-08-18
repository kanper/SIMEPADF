using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class ActividadPtConfig
    {
        public ActividadPtConfig(EntityTypeBuilder<ActividadPT> builder)
        {
            builder.HasKey(a => a.CodigoActividadPT);
            builder.Property(a => a.NombreActividad).IsRequired().HasMaxLength(100);
        }
    }
}