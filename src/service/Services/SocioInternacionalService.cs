using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public interface ISocioInternacionalService
    {
        IEnumerable<SocioInternacional> GetAll();
        SocioInternacional Get(int id);
        bool Add(SocioInternacional model);
        bool Update(SocioInternacional model);
        bool Delete(int id);

    }


    public class SocioInternacionalService : ISocioInternacionalService
    {
        private readonly ApplicationDbContext _databaseContext;

        public SocioInternacionalService(
            ApplicationDbContext databaseContext
            )
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<SocioInternacional> GetAll()
        {
            var result = new List<SocioInternacional>();
            try
            {
                result = _databaseContext.SocioInternacional.ToList();
            }
            catch (System.Exception)
            {
                
            }
            return result;
        }

        public SocioInternacional Get(int id)
        {
            var result = new SocioInternacional();
            try
            {
                result = _databaseContext.SocioInternacional.Single( x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Add(SocioInternacional model)
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

        public bool Update(SocioInternacional model)
        {
            try
            {
                var originalModel = _databaseContext.SocioInternacional.Single(x =>
                  x.Id == model.Id
                );

                originalModel.NombreSocio = model.NombreSocio;
                originalModel.SiglasSocio = model.SiglasSocio;

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
                _databaseContext.Entry(new SocioInternacional { Id = id }).State = EntityState.Deleted;
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
