using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Domain;

namespace DatabaseContext.Config
{
    public class ArchivoDescripcionConfig
    {
        public ArchivoDescripcionConfig(EntityTypeBuilder<ArchivoDescripcion> builder)
        {
            builder.HasKey(x => x.CodigoArchivo);
            builder.Property(x => x.NombreArchivo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.TipoContenido).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Descripcion).HasMaxLength(250);
        }
    }
}