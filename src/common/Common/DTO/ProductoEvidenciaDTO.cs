using System.IO;

namespace DTO.DTO
{
    public class ProductoEvidenciaDTO
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public bool ArchivoAdjunto { get; set; }
        public string NombreArchivo { get; set; }
        public string TipoArchivo { get; set; }
        public long TamanioArchivo { get; set; }
        public string DescripcionArchivo { get; set; }
        public string TamanioF => $"{(TamanioArchivo/1024):N0} KB";
    }
}