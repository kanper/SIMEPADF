using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class FuenteDatoConfig
    {
        public FuenteDatoConfig(EntityTypeBuilder<FuenteDato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NombreFuente).IsRequired().HasMaxLength(500);
        }
    }
}