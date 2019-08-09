using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class FrecuenciaMedicionConfig
    {
        public FrecuenciaMedicionConfig(EntityTypeBuilder<FrecuenciaMedicion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NombreFrecuencia).IsRequired().HasMaxLength(50);
        }
    }
}