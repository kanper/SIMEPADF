using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    class ObjetivoConfig
    {
        public ObjetivoConfig (EntityTypeBuilder<Objetivo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.CodigoObjetivo);
            entityBuilder.Property(x => x.NombreObjetivo).IsRequired().HasMaxLength(500);
        }
    }
}
