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
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<PersonalDTO>();
            }
        }

        public PersonalDTO Get(string id)
        {
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
            catch (Exception e)
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(PersonalDTO model, string id)
        {
            try
            {
                var user = _databaseContext.Usuario
                    .Include(u => u.Rol)
                    .Single(u => u.Id == id);
                if(model.Email != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                }
                if (model.NombrePersonal != null) user.NombrePersonal = model.NombrePersonal;
                if (model.ApellidoPersonal != null) user.ApellidoPersonal = model.ApellidoPersonal;
                if (model.Cargo != null) user.Cargo = model.Cargo;
                if (model.PhoneNumber != null) user.PhoneNumber = model.PhoneNumber;
                if (model.Pais != null) user.Pais = model.Pais;
                if(model.newPassword != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    await _userManager.ResetPasswordAsync(user, token, model.newPassword);
                }
                 
                await _userManager.UpdateAsync(user);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                _databaseContext.Usuario.Single(x => x.Id == id).Deleted = true;
                _databaseContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
