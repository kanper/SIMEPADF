using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    class UsuarioConfig
    {
        public UsuarioConfig(EntityTypeBuilder<Usuario> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.NombrePersonal).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.ApellidoPersonal).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Cargo).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.PasswordHash).IsRequired();
            entityBuilder.Property(x => x.Pais).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.FechaAfilacion).IsRequired();
        }
    }
}