using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class PlanTrabajoConfig
    {
        public PlanTrabajoConfig(EntityTypeBuilder<PlanTrabajo> builder)
        {
            builder.HasKey(p => p.CodigoPlanTrabajo);
        }
    }
}