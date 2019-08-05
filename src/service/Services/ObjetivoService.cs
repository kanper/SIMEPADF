using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Model.Domain;

namespace Services
{

    public interface IObjetivoService
    {
        IEnumerable<ObjetivoDTO> GetAll();
        IEnumerable<ResultadoDTO> GetAll(int id);
        ObjetivoDTO Get(int id);
        bool Add(ObjetivoDTO model);
        bool Update(ObjetivoDTO model, int id);
        bool Delete(int id);
    }

    public class ObjetivoService : IObjetivoService
    {
        private readonly simepadfContext _context;

        public ObjetivoService(simepadfContext context)
        {
            _context = context;
        }
        
        public ObjetivoDTO Get(int id)
        {
            try
            {
                return (from o in _context.Objetivo                   
                    where o.CodigoObjetivo == id
                    select new ObjetivoDTO()
                    {
                        Id = o.CodigoObjetivo,
                        Nombre = o.NombreObjetivo,                       
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<ResultadoDTO> GetAll(int id)
        {
            try
            {
                return (from o in _context.Objetivo
                    join r in _context.Resultado
                        on o equals r.Objetivo                   
                    where o.CodigoObjetivo == id
                    select new ResultadoDTO()
                    {
                        Id = r.CodigoResultado,
                        CodigoObjetivo = o.CodigoObjetivo,
                        NombreObjetivo = o.NombreObjetivo,
                        NombreResultado = r.NombreResultado,
                        Actividades = _context.Actividad.Count(a => a.Resultado == r)
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ResultadoDTO>();
            }
        }

        public IEnumerable<ObjetivoDTO> GetAll()
        {
            try
            {               
                return (from o in _context.Objetivo                    
                    select new ObjetivoDTO()
                    {
                        Id = o.CodigoObjetivo,
                        Nombre = o.NombreObjetivo,
                        Resultados = _context.Resultado.Count(r => r.Objetivo == o)
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ObjetivoDTO>();
            }
        }

        public bool Add(ObjetivoDTO model) 
        {
            try
            {
                var objetivo = new Objetivo(model.Nombre);
                _context.Objetivo.Add(objetivo);
                _context.SaveChanges();
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
                _context.Objetivo.Single(x => x.CodigoObjetivo == id).Deleted = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }           
        }

        public bool Update(ObjetivoDTO model, int id)
        {
            try
            {
                var originalModel = _context.Objetivo.Single(x =>x.CodigoObjetivo == id);
                originalModel.NombreObjetivo = model.Nombre;               
                _context.SaveChanges();
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
