using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Model.Domain;

namespace Services
{
    public interface IActividadPtService 
    {
        ActividadPtDTO Get(int id);
        ICollection<ActividadPtDTO> GetAll();
        ICollection<ActividadPtDTO> GetAll(string proyectoId);        
        bool Add(ActividadPtDTO model, string proyectoId);
        bool Update(ActividadPtDTO model, int id);
        bool Delete(int id);
    }
    
    public class ActividadPtService : IActividadPtService
    {

        private readonly simepadfContext _context;

        public ActividadPtService(simepadfContext context)
        {
            _context = context;
        }

        public ActividadPtDTO Get(int id)
        {
            try
            {
                return (from a in _context.ActividadPT
                    join pt in _context.PlanTrabajo
                        on a.PlanTrabajo equals pt
                    join p in _context.Proyecto
                        on pt.Proyecto equals p
                    where a.CodigoActividadPT == id
                    select new ActividadPtDTO()
                    {
                        Id = a.CodigoActividadPT,
                        NombreProyecto = p.NombreProyecto,
                        NombreActividad = a.NombreActividad,
                        Monto = a.Monto,
                        FechaInicio = a.FechaInicio,
                        FechaLimite = a.FechaLimite,
                        FechaCreacion = pt.FechaCreacion,
                        Completa = a.Completa,
                        Paises = (from pais in _context.Pais
                                  join ap in _context.ActividadPTPais
                                      on pais equals ap.Pais
                                  where ap.ActividadPTCodigoActividadPT == a.CodigoActividadPT
                                  select new MapDTO()
                                  {
                                      Id = pais.Id,
                                      Nombre = pais.NombrePais
                                  }).DefaultIfEmpty().ToArray()
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ICollection<ActividadPtDTO> GetAll()
        {
            try
            {
                return (from a in _context.ActividadPT
                    join pt in _context.PlanTrabajo
                        on a.PlanTrabajo equals pt
                        join p in _context.Proyecto
                            on pt.Proyecto equals p
                    select new ActividadPtDTO()
                    {
                        Id = a.CodigoActividadPT,
                        NombreProyecto = p.NombreProyecto,
                        NombreActividad = a.NombreActividad,
                        Monto = a.Monto,
                        FechaInicio = a.FechaInicio,
                        FechaLimite = a.FechaLimite,
                        FechaCreacion = pt.FechaCreacion
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ActividadPtDTO>();
            }
        }

        public ICollection<ActividadPtDTO> GetAll(string proyectoId)
        {
            try
            {
                return (from a in _context.ActividadPT
                    where a.PlanTrabajoCodigoPlanTrabajo == proyectoId
                    select new ActividadPtDTO()
                    {
                        Id = a.CodigoActividadPT,
                        NombreActividad = a.NombreActividad,
                        Monto = a.Monto,
                        FechaInicio = a.FechaInicio,
                        FechaLimite = a.FechaLimite,
                        Completa = a.Completa
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ActividadPtDTO>();
            }
        }

        public bool Add(ActividadPtDTO model, string proyectoId)
        {
            try
            {
                var actividadPT = new ActividadPT(model.NombreActividad, model.FechaInicio, model.FechaLimite, model.Monto);
                _context.PlanTrabajo
                    .Include(a => a.ActividadPTs)
                    .Single(p => p.CodigoPlanTrabajo == proyectoId)
                    .AddActividad(actividadPT);

                /*
                 * Por cada lista guarda uno por uno los elementos
                 */
                foreach (var dto in model.Paises)
                {
                    _context.Pais
                        .Include(p => p.ActividadPTPaises)
                        .Single(p => p.Id == dto.Id)
                        .AddActividad(actividadPT);
                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Update(ActividadPtDTO model, int id)
        {
            try
            {
                var actividadPt = _context.ActividadPT
                    .Include(ap => ap.ActividadPTPaises)
                    .Single(p => p.CodigoActividadPT == id);
                actividadPt.FechaLimite = model.FechaLimite;
                actividadPt.FechaInicio = model.FechaInicio;
                actividadPt.Monto = model.Monto;
                actividadPt.NombreActividad = model.NombreActividad;
                actividadPt.ActividadPTPaises.Clear();

                /*
                 * Se agregan los nuevo elementos a cada lista
                 */
                foreach (var dto in model.Paises)
                {
                    actividadPt.AddPais(GetPais(dto.Id));
                }

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
                _context.ActividadPT.Single(p => p.CodigoActividadPT == id).Deleted = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private Pais GetPais(int id)
        {
            return _context.Pais.Single(p => p.Id == id);
        }
    }
}