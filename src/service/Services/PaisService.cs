using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public interface IPaisService
    {
        IEnumerable<Pais> GetAll();
        Pais Get(int id);
        bool Add(Pais model);
        bool Update(Pais model);
        bool Delete(int id);

    }


    public class PaisService : IPaisService
    {
        private readonly ApplicationDbContext _databaseContext;

        public PaisService(
            ApplicationDbContext databaseContext
            )
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Pais> GetAll()
        {
            var result = new List<Pais>();
            try
            {
                result = _databaseContext.Pais.ToList();
            }
            catch (System.Exception)
            {
                
            }
            return result;
        }

        public Pais Get(int id)
        {
            var result = new Pais();
            try
            {
                result = _databaseContext.Pais.Single( x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Add(Pais model)
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

        public bool Update(Pais model)
        {
            try
            {
                var originalModel = _databaseContext.Pais.Single(x =>
                  x.Id == model.Id
                );

                originalModel.NombrePais = model.NombrePais;
                originalModel.SiglaPais = model.SiglaPais;

                _databaseContext.Update(originalModel);
                _databaseContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _databaseContext.Entry(new Pais { Id = id }).State = EntityState.Deleted;
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
