using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    class PaisConfig
    {
        public PaisConfig (EntityTypeBuilder<Pais> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.NombrePais).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.SiglaPais).IsRequired().HasMaxLength(5);
        }
    }
}
