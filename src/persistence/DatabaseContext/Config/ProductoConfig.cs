using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class ProductoConfig
    {
        public ProductoConfig(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(p => p.codigoProducto);
            builder.Property(p => p.NombreProducto).IsRequired().HasMaxLength(500);
        }
    }
}