using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class AuditUserConfig
    {
        public AuditUserConfig(EntityTypeBuilder<AuditUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.User).IsUnique();
        }
    }
}