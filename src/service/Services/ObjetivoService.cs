using System;
using DatabaseContext;
using Model.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;

namespace Services
{

    public interface IObjetivoService
    {
        IEnumerable<ObjetivoDTO> GetAll();
        Objetivo Get(int id);
        bool Add(Objetivo model);
        bool Update(Objetivo model);
        bool Delete(int id);
    }

    public class ObjetivoService : IObjetivoService
    {
        private readonly simepadfContext _databaseContext;

        public ObjetivoService(simepadfContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Add(Objetivo model) 
        {
            try
            {
                _databaseContext.Add(model);
                _databaseContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {                
                Console.WriteLine(e);               
                return false;
            }                      
        }

        public bool Delete(int id)
        {
            try
            {
                _databaseContext.Objetivo.Single(x => x.CodigoObjetivo == id).Deleted = true;
                _databaseContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }           
        }

        public Objetivo Get(int id)
        {
            try
            {
                return _databaseContext.Objetivo.Single(x => x.CodigoObjetivo == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<ObjetivoDTO> GetAll()
        {
            try
            {               
                return (from o in _databaseContext.Objetivo
                    join r in _databaseContext.Resultado
                        on o equals r.Objetivo into oResult
                    select new ObjetivoDTO()
                    {
                        Id = o.CodigoObjetivo,
                        Nombre = o.NombreObjetivo,
                        Resultados = oResult.Count()
                    }).DefaultIfEmpty();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ObjetivoDTO>();
            }
        }

        public bool Update(Objetivo model)
        {
            try
            {
                var originalModel = _databaseContext.Objetivo.Single(x =>x.CodigoObjetivo == model.CodigoObjetivo);
                originalModel.NombreObjetivo = model.NombreObjetivo;
                _databaseContext.Update(originalModel);
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
