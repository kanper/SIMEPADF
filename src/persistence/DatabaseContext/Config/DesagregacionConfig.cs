using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class DesagregacionConfig
    {
        public DesagregacionConfig(EntityTypeBuilder<Desagregacion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TipoDesagregacion).IsRequired().HasMaxLength(100);
        }
    }
}