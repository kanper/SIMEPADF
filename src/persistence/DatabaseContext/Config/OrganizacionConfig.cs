using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    class OrganizacionConfig
    {
        public OrganizacionConfig(EntityTypeBuilder<OrganizacionResponsable> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.NombreOrganizacion).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.SiglasOrganizacion).IsRequired().HasMaxLength(20);
        }
    }
}
