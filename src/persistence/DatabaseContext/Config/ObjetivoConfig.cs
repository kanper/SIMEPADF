using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    class ObjetivoConfig
    {
        public ObjetivoConfig (EntityTypeBuilder<Objetivo> builder)
        {
            builder.HasKey(x => x.CodigoObjetivo);
            builder.Property(x => x.NombreObjetivo).IsRequired().HasMaxLength(500);
            builder.HasIndex(x => x.NombreObjetivo).IsUnique();
        }
    }
}
