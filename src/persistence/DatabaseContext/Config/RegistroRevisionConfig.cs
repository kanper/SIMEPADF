using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class RegistroRevisionConfig
    {
        public RegistroRevisionConfig(EntityTypeBuilder<RegistroRevision> builder)
        {
            builder.HasKey(x => x.RegistroRevisionId);
            builder.Property(x => x.Trimestre).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Revisado).IsRequired();
            builder.Property(x => x.RevisionCompleta).IsRequired();
            builder.Property(x => x.NumeroRevision).IsRequired().HasMaxLength(10);
        }
    }
}