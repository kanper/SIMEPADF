using Microsoft.AspNetCore.Identity;
using Model.Domain.DbHelper;
using System;
using System.Collections.Generic;

namespace Model.Domain
{
    public class Usuario : IdentityUser, ISoftDeleted
    {


        public Usuario(string userName, string nombrePersonal, string apellidoPersonal, string cargo, DateTime fechaAfilacion, string email, string phoneNumber, string password, string pais, bool deleted) : base(userName)
        {
            NombrePersonal = nombrePersonal;
            ApellidoPersonal = apellidoPersonal;
            Cargo = cargo;
            FechaAfilacion = fechaAfilacion;
            Email = email;
            PhoneNumber = phoneNumber;
            PasswordHash = password;
            Pais = pais;
            Deleted = deleted;
        }

        public string NombrePersonal { get; set; }
        public string ApellidoPersonal { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaAfilacion { get; set; }
        public string Pais { get; set; }
        private string PasswordHash;

        public bool Deleted { get; set; }

        public ICollection<Rol> Rols { get; set; }

        public ICollection<ProyectoUsuario> ProyectoUsuarios { get; set; }



    }

}
