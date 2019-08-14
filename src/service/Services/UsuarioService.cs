using DatabaseContext;
using DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{

    public interface IUsuarioService
    {
        IEnumerable<PersonalDTO> GetAll();
        PersonalDTO Get(string id);
        bool Add(PersonalDTO model);
        bool Update(PersonalDTO model, string id);
        bool Delete(string id);

    }

    public class UsuarioService : IUsuarioService
    {
        private readonly simepadfContext _databaseContext;
        //private Rol _roleManager => HttpContext.GetOwinContext().Get<Rol>();

        public UsuarioService(simepadfContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<PersonalDTO> GetAll()
        {
            var result = new List<PersonalDTO>();
            try
            {
                return (from u in _databaseContext.Usuario
                        join r in _databaseContext.Rol
                            on u.Rol equals r
                        select new PersonalDTO
                        {
                            Id = u.Id,
                            NombrePersonal = u.NombrePersonal,
                            ApellidoPersonal = u.ApellidoPersonal,
                            Cargo = u.Cargo,
                            FechaAfilacion = u.FechaAfilacion,
                            Email = u.Email,
                            PhoneNumber = u.PhoneNumber,
                            Password = u.PasswordHash,
                            Pais = u.Pais,
                            Name = r.Name
                        }
                   ).ToList();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return new List<PersonalDTO>();
            }
        }

        public PersonalDTO Get(string id)
        {
            var result = new PersonalDTO();
            try
            {
                return (from u in _databaseContext.Usuario
                        join r in _databaseContext.Rol
                            on u.Rol equals r
                        where u.Id ==id
                        select new PersonalDTO
                    {
                        Id = u.Id,
                        NombrePersonal = u.NombrePersonal,
                        ApellidoPersonal = u.ApellidoPersonal,
                        Cargo = u.Cargo,
                        FechaAfilacion = u.FechaAfilacion,
                        Email = u.Email,
                        PhoneNumber = u.PhoneNumber,
                        Password = u.PasswordHash,
                        Pais = u.Pais,
                        Name = r.Name
                    }
                   ).Single();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool Add(PersonalDTO model)
        {
            try
            {
                var usuario = new Usuario(model.Id, model.Email, model.NombrePersonal, model.ApellidoPersonal, model.Cargo, 
                    model.FechaAfilacion, model.Email, model.PhoneNumber, model.Password, model.Pais);
                _databaseContext.Rol
                    .Include(u => u.usuarios)
                    .Single(r => r.Name == model.Name)
                    .usuarios.Add(usuario);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Update(PersonalDTO model, string id)
        {
            try
            {

                var usuario = _databaseContext.Usuario
                    .Include(u => u.Rol)
                    .Single(u => u.Id == id);
                usuario.UserName = model.Email;
                usuario.NombrePersonal = model.NombrePersonal;
                usuario.ApellidoPersonal = model.ApellidoPersonal;
                usuario.Cargo = model.Cargo;
                usuario.FechaAfilacion = model.FechaAfilacion;
                usuario.Email = model.Email;
                usuario.PhoneNumber = model.PhoneNumber;
                usuario.PasswordHash = model.Password;
                usuario.Pais = model.Pais;

                var rol = _databaseContext.Rol.Single(r => r.Name == model.Name);

                usuario.RolId = rol.Id;


                _databaseContext.Update(usuario);
                _databaseContext.SaveChanges();
            }

                

            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(string id)
        {
            try
            {
                _databaseContext.Usuario.Single(x => x.Id == id).Deleted = true;
                _databaseContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }

    //public async Task CreateRoles()
    //{
    //    var roles = new List<Rol>
    //    {
    //        new Rol { Name = "" },
    //    };

    //    foreach (var r in roles)
    //    {
    //        if (!await _roleManager.RoleExistsAsync(r.Name))
    //        {
    //            await _roleManager.CreateAsync(r);
    //        }
    //    }
    //}
}
