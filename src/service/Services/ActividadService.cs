using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Model.Domain;

namespace Services
{
    public interface IActividadService
    {
        ActividadDTO Get(int id);
        IEnumerable<ActividadDTO> GetAll();
        IEnumerable<ActividadDTO> GetAll(int id);
        bool Add(ActividadDTO model, int id);
        bool Update(ActividadDTO model, int id);
        bool Delete(int id);
    }
    
    public class ActividadService : IActividadService
    {

        private readonly simepadfContext _context;

        public ActividadService(simepadfContext context)
        {
            _context = context;
        }

        public ActividadDTO Get(int id)
        {
            try
            {
                return (from o in _context.Objetivo
                    join r in _context.Resultado
                        on o equals r.Objetivo
                    join a in _context.Actividad
                        on r equals a.Resultado
                    where a.CodigoActividad == id
                    select new ActividadDTO()
                    {
                        Id = a.CodigoActividad,
                        CodigoObjetivo = o.CodigoObjetivo,
                        NombreObjetivo = o.NombreObjetivo,
                        CodigoResultado = r.CodigoResultado,
                        NombreResultado = r.NombreResultado,
                        NombreActividad = a.NombreActividad,                        
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<ActividadDTO> GetAll()
        {
            try
            {
                return (from o in _context.Objetivo
                    join r in _context.Resultado
                        on o equals r.Objetivo
                    join a in _context.Actividad
                        on r equals a.Resultado                   
                    select new ActividadDTO()
                    {
                        Id = a.CodigoActividad,
                        CodigoObjetivo = o.CodigoObjetivo,
                        NombreObjetivo = o.NombreObjetivo,
                        CodigoResultado = r.CodigoResultado,
                        NombreResultado = r.NombreResultado,
                        NombreActividad = a.NombreActividad,                        
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ActividadDTO>();
            }
        }

        public IEnumerable<ActividadDTO> GetAll(int id)
        {
            try
            {
                return (from r in _context.Resultado
                    join a in _context.Actividad
                        on r equals a.Resultado
                    where r.CodigoResultado == id
                    select new ActividadDTO()
                    {
                        Id = a.CodigoActividad,
                        CodigoResultado = r.CodigoResultado,
                        NombreResultado = r.NombreResultado,
                        NombreActividad = a.NombreActividad
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ActividadDTO>();
            }
        }

        public bool Add(ActividadDTO model, int id)
        {
            try
            {
                var resultado = _context.Resultado.Include(a => a.Actividades).Single(r => r.CodigoResultado == id);
                var actividad = new Actividad(model.NombreActividad, "N/A", 0);
                resultado.Actividades.Add(actividad);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Update(ActividadDTO model, int id)
        {
            try
            {
                var actividad = _context.Actividad.Single(a => a.CodigoActividad == id);
                actividad.NombreActividad = model.NombreActividad;
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
                _context.Actividad.Single(a => a.CodigoActividad == id).Deleted = true;
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