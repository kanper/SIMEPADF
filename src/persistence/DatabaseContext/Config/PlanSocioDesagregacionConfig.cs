using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class PlanSocioDesagregacionConfig
    {
        public PlanSocioDesagregacionConfig(EntityTypeBuilder<PlanSocioDesagregacion> builder)
        {
            builder.Property(x => x.CodigoPais).HasMaxLength(10);
        }
    }
}