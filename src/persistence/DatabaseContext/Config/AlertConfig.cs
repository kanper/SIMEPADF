using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class AlertConfig
    {
        public AlertConfig(EntityTypeBuilder<Alerta> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Mensaje).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Tipo).IsRequired().HasMaxLength(6);
            builder.Property(x => x.Pais).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Rol).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Usuario).IsRequired().HasMaxLength(110);
        }
    }
}