using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class MetaConfig
    {
        public MetaConfig(EntityTypeBuilder<Meta> builder)
        {
            builder.HasKey(x => x.CodigoMeta);
            builder.Property(x => x.ValorMeta).IsRequired();
        }
    }
}