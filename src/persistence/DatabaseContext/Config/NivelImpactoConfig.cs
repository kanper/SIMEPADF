using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class NivelImpactoConfig
    {
        public NivelImpactoConfig(EntityTypeBuilder<NivelImpacto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NombreNivelImpacto).IsRequired().HasMaxLength(100);
        }
    }
}