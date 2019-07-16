using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    class EstadoProyectoConfig
    {
        public EstadoProyectoConfig(EntityTypeBuilder<EstadoProyecto> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.TipoEstado).IsRequired().HasMaxLength(50);
        }
    }
}
