using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public interface IRolService
    {
        IEnumerable<Rol> GetAll();
        Rol Get(string id);
        bool Add(Rol model);
        bool Update(Rol model);
        bool Delete(string id);

    }

    public class RolService : IRolService
    {
        private readonly ApplicationDbContext _databaseContext;

        public RolService(ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Rol> GetAll()
        {
            var result = new List<Rol>();
            try
            {
                result = _databaseContext.Rol.ToList();
            }
            catch (System.Exception)
            {
                
            }
            return result;
        }

        public Rol Get(string id)
        {
            var result = new Rol();
            try
            {
                result = _databaseContext.Rol.Single( x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Add(Rol model)
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

        public bool Update(Rol model)
        {
            try
            {
                var originalModel = _databaseContext.Rol.Single(x =>
                  x.Id == model.Id
                );

                originalModel.Name = model.Name;

                _databaseContext.Update(model);
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
                _databaseContext.Entry(new Rol { Id = id }).State = EntityState.Deleted;
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
