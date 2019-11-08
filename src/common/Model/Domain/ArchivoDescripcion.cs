using System.ComponentModel.DataAnnotations.Schema;
using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class ArchivoDescripcion: AudityEntity, ISoftDeleted
    {
        [ForeignKey("Producto")]
        public int CodigoArchivo { get; set; }
        public string NombreReal { get; set; }
        public string NombreArchivo { get; set; }
        public string Path { get; set; }
        public string Descripcion { get; set; }
        public string TipoContenido { get; set; }
        public long TamanioArchivo { get; set; }
        public Producto Producto { get; set; }
        public bool Deleted { get; set; }
    }
}