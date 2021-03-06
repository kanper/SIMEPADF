using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class PlanMonitoreoEvaluacionConfig
    {
        public PlanMonitoreoEvaluacionConfig(EntityTypeBuilder<PlanMonitoreoEvaluacion> builder)
        {
            builder.Property(x => x.MetodologiaRecoleccion).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.ValorLineaBase).IsRequired().HasMaxLength(1000);
        }
    }
}