
namespace Model.Domain
{
    public class UsuarioRol
    {
        public UsuarioRol()
        {
        }

        public UsuarioRol(Usuario usuario, Rol rol)
        {
            Usuario = usuario;
            Rol = rol;
        }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public string RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
