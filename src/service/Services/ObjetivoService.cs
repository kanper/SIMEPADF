using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Services
{

    public interface IObjetivoService
    {
        IEnumerable<Objetivo> GetAll();
        Objetivo Get(int id);
        bool Add(Objetivo model);
        bool Update(Objetivo model);
        bool Delete(int id);

    }

    public class ObjetivoService : IObjetivoService
    {
        private readonly ApplicationDbContext _databaseContext;

        public ObjetivoService(
            ApplicationDbContext databaseContext
            )
        {
            _databaseContext = databaseContext;
        }


        public bool Add(Objetivo model)
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

        public bool Delete(int id)
        {
            try
            {
                _databaseContext.Entry(new Objetivo { CodigoObjetivo = id }).State = EntityState.Deleted;
                _databaseContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Objetivo Get(int id)
        {
            var result = new Objetivo();
            try
            {
                result = _databaseContext.Objetivo.Single(x => x.CodigoObjetivo == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public IEnumerable<Objetivo> GetAll()
        {
            var result = new List<Objetivo>();
            try
            {
                result = _databaseContext.Objetivo.ToList();
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Update(Objetivo model)
        {
            try
            {
                var originalModel = _databaseContext.Objetivo.Single(x =>
                  x.CodigoObjetivo == model.CodigoObjetivo
                );

                originalModel.NombreObjetivo = model.NombreObjetivo;

                _databaseContext.Update(originalModel);
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
