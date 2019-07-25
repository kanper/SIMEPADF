using System.Security.Policy;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class ResultadoConfig
    {
        public ResultadoConfig(EntityTypeBuilder<Resultado> builder)
        {
            builder.HasKey(x => x.CodigoResultado);
            builder.Property(x => x.NombreResultado).IsRequired().HasMaxLength(500);
            builder.HasIndex(x => x.NombreResultado).IsUnique();
        }
    }
}