using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;

namespace Services
{
    public interface IPlanTrabajoActividadService
    {
        PlanTrabajoActividadDTO Get(int id);
        IEnumerable<PlanTrabajoActividadDTO> GetAll(string id, string country);
    }
    
    public class PlanTrabajoActividadService : IPlanTrabajoActividadService
    {
        private readonly simepadfContext _context;

        public PlanTrabajoActividadService(simepadfContext context)
        {
            _context = context;
        }

        public PlanTrabajoActividadDTO Get(int id)
        {
            try
            {
                return (from p in _context.Proyecto
                    join pp in _context.PlanTrabajo on p equals pp.Proyecto
                    join pt in _context.ActividadPT on pp equals pt.PlanTrabajo
                    where pt.CodigoActividadPT == id
                    select new PlanTrabajoActividadDTO()
                    {
                        Id = pt.CodigoActividadPT,
                        CodigoProyecto = p.CodigoProyecto,
                        NombreProyecto = p.NombreProyecto,
                        FechaInicio = pt.FechaInicio,
                        FechaFin = p.FechaFin,
                        FechaLimite = pt.FechaLimite,
                        Paises = (from ap in _context.ActividadPTPais
                            join pais in _context.Pais on ap.Pais equals pais
                            where ap.ActividadPTCodigoActividadPT == pt.CodigoActividadPT
                            select new MapDTO()
                            {
                                Id = pais.Id,
                                Nombre = pais.NombrePais
                            }).ToArray()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<PlanTrabajoActividadDTO> GetAll(string id, string country)
        {
            try
            {
                return (from p in _context.Proyecto
                    join pp in _context.PlanTrabajo on p equals pp.Proyecto
                    join pt in _context.ActividadPT on pp equals pt.PlanTrabajo
                    join pc in _context.ProyectoPais on p equals pc.Proyecto
                    join c in _context.Pais on pc.Pais equals c
                    where p.CodigoProyecto == id && c.NombrePais == country
                    select new PlanTrabajoActividadDTO()
                          {
                              Id = pt.CodigoActividadPT,
                              CodigoProyecto = p.CodigoProyecto,
                              NombreProyecto = p.NombreProyecto,
                              FechaInicio = pt.FechaInicio,
                              FechaFin = p.FechaFin,
                              FechaLimite = pt.FechaLimite,
                              NombreActividad = pt.NombreActividad,
                              Paises = (from ap in _context.ActividadPTPais
                                  join pais in _context.Pais on ap.Pais equals pais
                                  where ap.ActividadPTCodigoActividadPT == pt.CodigoActividadPT
                                  select new MapDTO()
                                  {
                                      Id = pais.Id,
                                      Nombre = pais.NombrePais
                                  }).ToArray()
                          }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<PlanTrabajoActividadDTO>();
            }
        }
    }
}