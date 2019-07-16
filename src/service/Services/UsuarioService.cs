using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public interface IUsuarioService
    {
        IEnumerable<PersonalDTO> GetAll();
        Usuario Get(string id);
        bool Add(Usuario model);
        bool Update(Usuario model);
        bool Delete(string id);

    }


    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _databaseContext;

        public UsuarioService(
            ApplicationDbContext databaseContext
            )
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<PersonalDTO> GetAll()
        {
            var result = new List<PersonalDTO>();
            try
            {
                result = (
                    from u in _databaseContext.Usuario
                    from ur in _databaseContext.UserRoles.Where(x => x.UserId == u.Id)
                    from r in _databaseContext.Rol.Where(x => x.Id == ur.RoleId && x.Enabled)
                    select new PersonalDTO
                    {
                        Id = u.Id,
                        NombrePersonal = u.NombrePersonal,
                        ApellidoPersonal = u.ApellidoPersonal,
                        Cargo = u.Cargo,
                        FechaAfilacion = u.FechaAfilacion,
                        UserName = u.UserName,
                        Email = u.Email,
                        PhoneNumber = u.PhoneNumber,
                        Name = r.Name
                    }
                   ).ToList();
            }
            catch (System.Exception)
            {
                
            }
            return result;
        }

        public Usuario Get(string id)
        {
            var result = new Usuario();
            try
            {
                result = _databaseContext.Usuario.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
             
            }
            return result;
        }

        public bool Add(Usuario model)
        {
            try
            {
                _databaseContext.Add(model);
                _databaseContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Usuario model)
        {
            try
            {
                var originalModel = _databaseContext.Usuario.Single(x =>
                  x.Id == model.Id
                );

                originalModel.UserName = model.UserName;
                originalModel.PasswordHash = model.PasswordHash;
                originalModel.Email = model.Email;
                originalModel.Estado = model.Estado;
                originalModel.FechaAfilacion = model.FechaAfilacion;
                //originalModel.UsuarioRols.RolId.Nombre = model.UsuarioRols.RolId.Nombre;

                _databaseContext.Update(originalModel);
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
                _databaseContext.Entry(new Usuario { Id = id }).State = EntityState.Deleted;
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
