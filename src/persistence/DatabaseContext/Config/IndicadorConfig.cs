using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class IndicadorConfig
    {
        public IndicadorConfig(EntityTypeBuilder<Indicador> builder)
        {
            builder.HasKey(x => x.CodigoIndicador);
            builder.Property(x => x.NombreIndicador).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.TipoBeneficiario).HasMaxLength(1);
        }
    }
}