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
                        FechaLimite = a.FechaLimite,
                        FechaCreacion = pt.FechaCreacion
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
                        FechaLimite = a.FechaLimite
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
                _context.PlanTrabajo
                    .Include(a => a.ActividadPTs)
                    .Single(p => p.CodigoPlanTrabajo == proyectoId)
                    .AddActividad(new ActividadPT(model.NombreActividad,model.FechaLimite,model.Monto));                
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
                var actividadPt = _context.ActividadPT.Single(p => p.CodigoActividadPT == id);
                actividadPt.FechaLimite = model.FechaLimite;
                actividadPt.Monto = model.Monto;
                actividadPt.NombreActividad = model.NombreActividad;
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
    }
}