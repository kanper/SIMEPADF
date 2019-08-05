using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Model.Domain;

namespace Services
{
    public interface IResultadoService
    {
        ResultadoDTO Get(int id);
        IEnumerable<ResultadoDTO> GetAll();
        bool Add(ResultadoDTO model, int id);
        bool Update(ResultadoDTO model, int id);
        bool Delete(int id);
    }
    
    public class ResultadoService : IResultadoService
    {
        private readonly simepadfContext _context;

        public ResultadoService(simepadfContext context)
        {
            _context = context;
        }

        public ResultadoDTO Get(int id)
        {
            try
            {
                return (from o in _context.Objetivo
                    join r in _context.Resultado
                        on o equals r.Objetivo                    
                    where r.CodigoResultado == id
                    select new ResultadoDTO()
                    {
                        Id = r.CodigoResultado,
                        CodigoObjetivo = o.CodigoObjetivo,
                        NombreObjetivo = o.NombreObjetivo,
                        NombreResultado = r.NombreResultado,                        
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<ResultadoDTO> GetAll()
        {
            try
            {
                return (from o in _context.Objetivo
                    join r in _context.Resultado
                        on o equals r.Objetivo                                                          
                    select new ResultadoDTO()
                    {
                        Id    = r.CodigoResultado,
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

        public bool Add(ResultadoDTO model, int id)
        {
            try
            {
                var objetivo = _context.Objetivo.Include(r => r.Resultados).Single(x => x.CodigoObjetivo == id);
                var resultado = new Resultado(model.NombreResultado);
                objetivo.Resultados.Add(resultado);               
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Update(ResultadoDTO model, int id)
        {
            try
            {
                var resultado = _context.Resultado.Single(x => x.CodigoResultado == id);
                resultado.NombreResultado = model.NombreResultado;                
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
                _context.Resultado.Single(x => x.CodigoResultado == id).Deleted = true;
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