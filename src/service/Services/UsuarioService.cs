using DatabaseContext;
using DTO.DTO;
using Microsoft.AspNetCore.Identity;
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
        Task<bool> UpdateAsync(PersonalDTO model, string id);
        bool Delete(string id);

    }

    public class UsuarioService : IUsuarioService
    {
        private readonly simepadfContext _databaseContext;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioService(simepadfContext databaseContext, UserManager<Usuario> userManager)
        {
            _databaseContext = databaseContext;
            _userManager = userManager;
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
                var user = _databaseContext.Usuario.Single(x => x.Email == model.Email);

                _databaseContext.Rol
                    .Include(u => u.usuarios)
                    .Single(r => r.Name == model.Name)
                    .usuarios.Add(user);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(PersonalDTO model, string id)
        {
            try
            {

                var usuario = _databaseContext.Usuario
                    .Include(u => u.Rol)
                    .Single(u => u.Id == id);

                var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                var cambio = await _userManager.ResetPasswordAsync(usuario, token, model.newPassword);
                if (cambio.Succeeded)
                {
                    usuario.UserName = model.Email;
                    usuario.NombrePersonal = model.NombrePersonal;
                    usuario.ApellidoPersonal = model.ApellidoPersonal;
                    usuario.Cargo = model.Cargo;
                    usuario.Email = model.Email;
                    usuario.PhoneNumber = model.PhoneNumber;
                    usuario.Pais = model.Pais;
                 
                    var result = await _userManager.UpdateAsync(usuario);
                    _databaseContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {
                return false;
            }
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
}
