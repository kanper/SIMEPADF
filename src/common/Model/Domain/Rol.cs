using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Model.Domain
{
    public class Rol : IdentityRole
    {
        public bool Enabled { get; set; }
        //public List<UsuarioRol> UsuarioRols { get; set; }
    }
}
