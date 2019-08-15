using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    class SocioConfig
    {
        public SocioConfig (EntityTypeBuilder<SocioInternacional> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.NombreSocio).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.SiglasSocio).IsRequired().HasMaxLength(20);
        }
    }
}
