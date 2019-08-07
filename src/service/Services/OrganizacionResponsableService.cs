using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public interface IOrganizacionResponsableService
    {
        IEnumerable<OrganizacionResponsable> GetAll();
        OrganizacionResponsable Get(int id);
        bool Add(OrganizacionResponsable model);
        bool Update(OrganizacionResponsable model);
        bool Delete(int id);

    }

    public class OrganizacionResponsableService : IOrganizacionResponsableService
    {
        private readonly simepadfContext _databaseContext;

        public OrganizacionResponsableService(simepadfContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<OrganizacionResponsable> GetAll()
        {
            var result = new List<OrganizacionResponsable>();
            try
            {
                result = _databaseContext.OrganizacionResponsable.ToList();
            }
            catch (System.Exception)
            {
                
            }
            return result;
        }

        public OrganizacionResponsable Get(int id)
        {
            var result = new OrganizacionResponsable();
            try
            {
                result = _databaseContext.OrganizacionResponsable.Single( x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Add(OrganizacionResponsable model)
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

        public bool Update(OrganizacionResponsable model)
        {
            try
            {
                var originalModel = _databaseContext.OrganizacionResponsable.Single(x =>
                  x.Id == model.Id
                );

                originalModel.NombreOrganizacion = model.NombreOrganizacion;
                originalModel.SiglasOrganizacion = model.SiglasOrganizacion;

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
                _databaseContext.Entry(new OrganizacionResponsable { Id = id }).State = EntityState.Deleted;
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
