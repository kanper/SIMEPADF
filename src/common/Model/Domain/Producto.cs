using Model.Domain.DbHelper;

namespace Model.Domain
{
    public class Producto : AudityEntity, ISoftDeleted
    {
        public Producto()
        {
        }
        public Producto(string nombreProducto)
        {
            NombreProducto = nombreProducto;
        }
        public int codigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public ActividadPT ActividadPT { get; set; }
        public int ActividadPTId { get; set; }
        public ArchivoDescripcion Archivo { get; set; }
        public bool Deleted { get; set; }
    }
}