
namespace Model.Domain
{
    public class ProyectoUsuario
    {
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public string ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
