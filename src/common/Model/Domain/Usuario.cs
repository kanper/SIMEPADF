using Microsoft.AspNetCore.Identity;
using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;

namespace Model.Domain
{
    public class Usuario : IdentityUser, ISoftDeleted
    {
        public Usuario()
        {
        }

        public Usuario(string id, string username, string nombrePersonal, string apellidoPersonal, string cargo, DateTime fechaAfilacion, string email, string phoneNumber, string passwordHash, string pais)
        {
            UserName = username;
            NombrePersonal = nombrePersonal;
            ApellidoPersonal = apellidoPersonal;
            Cargo = cargo;
            FechaAfilacion = fechaAfilacion;
            Email = email;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            Pais = pais;
        }

        public string NombrePersonal { get; set; }
        public string ApellidoPersonal { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaAfilacion { get; set; }
        public string Pais { get; set; }

        public bool Deleted { get; set; }

        public string RolId { get; set; }
        public Rol Rol { get; set; }

        public ICollection<ProyectoUsuario> ProyectoUsuarios { get; set; }



    }

}
