using Microsoft.AspNetCore.Identity;
using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;

namespace Model.Domain
{
    public class Usuario : IdentityUser, ISoftDeleted
    {
        
        public string NombrePersonal { get; set; }
        public string ApellidoPersonal { get; set; }
        public string Cargo { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAfilacion { get; set; }

        public bool Deleted { get; set; }

        public ICollection<UsuarioRol> UsuarioRols { get; set; }

        public ICollection<ProyectoUsuario> ProyectoUsuarios { get; set; }


    }

}
