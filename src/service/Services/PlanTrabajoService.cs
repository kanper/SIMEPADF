using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Model.Domain;

namespace Services
{
    public interface IPlanTrabajoService
    {
        PlanTrabajoDTO Get(string id);
        IEnumerable<PlanTrabajoDTO> GetAll();
        bool Add(string proyectoId);
        bool Update(PlanTrabajoDTO model, string proyectoId);
        bool Delete(string id);
    }
    
    public class PlanTrabajoService : IPlanTrabajoService
    {
        private readonly simepadfContext _context;

        public PlanTrabajoService(simepadfContext context)
        {
            _context = context;
        }

        public PlanTrabajoDTO Get(string id)
        {
            try
            {
                return (from p in _context.Proyecto
                    join pt in _context.PlanTrabajo
                        on p equals pt.Proyecto into plan
                    from planTrabajo in plan.DefaultIfEmpty()
                    where p.CodigoProyecto == id
                    select new PlanTrabajoDTO()
                    {
                        Id = planTrabajo == null ? p.CodigoProyecto : planTrabajo.CodigoPlanTrabajo,
                        FechaCreacion = planTrabajo == null ? DateTime.Now : planTrabajo.FechaCreacion,
                        ProyectoId = p.CodigoProyecto,
                        NombreProyecto = p.NombreProyecto,
                        IsPlanTrabajo = planTrabajo != null                        
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<PlanTrabajoDTO> GetAll()
        {
            try
            {
                return (from p in _context.Proyecto
                    join pt in _context.PlanTrabajo
                        on p equals pt.Proyecto into plan
                    from planTrabajo in plan.DefaultIfEmpty()
                    select new PlanTrabajoDTO()
                    {
                        Id = planTrabajo == null ? p.CodigoProyecto : planTrabajo.CodigoPlanTrabajo,
                        FechaCreacion = planTrabajo == null ? DateTime.Now : planTrabajo.FechaCreacion,
                        ProyectoId = p.CodigoProyecto,
                        NombreProyecto = p.NombreProyecto,
                        IsPlanTrabajo = planTrabajo != null
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<PlanTrabajoDTO>();
            }
        }

        public bool Add(string proyectoId)
        {
            try
            {
                var proyecto = _context.Proyecto                    
                    .Single(p => p.CodigoProyecto == proyectoId);
                var plan = new PlanTrabajo(DateTime.Now);
                proyecto.PlanTrabajo = plan;
                plan.Proyecto = proyecto;
                _context.PlanTrabajo.Add(plan);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Update(PlanTrabajoDTO model, string proyectoId)
        {
            try
            {
                var planTrabajo = _context.PlanTrabajo.Single(p => p.CodigoPlanTrabajo == proyectoId);
                planTrabajo.FechaCreacion = model.FechaCreacion;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var planTrabajo = _context.PlanTrabajo.Single(p => p.CodigoPlanTrabajo == id);
                _context.PlanTrabajo.Remove(planTrabajo);
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