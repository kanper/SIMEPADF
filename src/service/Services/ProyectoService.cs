using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Model.Domain;

namespace Services
{
    public interface IProyectoService
    {
        ProyectoDTO Get(string id);
        IEnumerable<ProyectoDTO> GetAll();
        bool Add(ProyectoDTO model);
        bool Update(ProyectoDTO model, string id);
        bool Delete(string id);
    }
    
    public class ProyectoService : IProyectoService
    {
        private readonly simepadfContext _context;

        public ProyectoService(simepadfContext context)
        {
            _context = context;
        }

        public ProyectoDTO Get(string id)
        {
            try
            {
                return (from p in _context.Proyecto
                    join e in _context.EstadoProyecto
                        on p.EstadoProyecto equals e
                        where p.CodigoProyecto == id
                    select new ProyectoDTO()
                    {
                        Id = p.CodigoProyecto,
                        NombreProyecto = p.NombreProyecto,
                        MontoProyecto = p.MontoProyecto,
                        FechaAprobacion = p.FechaAprobacion,
                        FechaInicio = p.FechaInicio,
                        FechaFin = p.FechaFin,
                        Beneficiarios = p.Beneficiarios,
                        EstadoProyecto = e.TipoEstado
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<ProyectoDTO> GetAll()
        {
            try
            {
                return (from p in _context.Proyecto
                    join e in _context.EstadoProyecto
                        on p.EstadoProyecto equals e
                    select new ProyectoDTO()
                    {
                        Id = p.CodigoProyecto,
                        NombreProyecto = p.NombreProyecto,
                        MontoProyecto = p.MontoProyecto,
                        FechaAprobacion = p.FechaAprobacion,
                        FechaInicio = p.FechaInicio,
                        FechaFin = p.FechaFin,
                        Beneficiarios = p.Beneficiarios,
                        EstadoProyecto = e.TipoEstado
                    }).ToList();               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoDTO>();
            }
        }

        public bool Add(ProyectoDTO model)
        {
            try
            {
                var proyecto = new Proyecto(model.NombreProyecto,model.FechaAprobacion,model.FechaInicio,model.FechaFin,model.MontoProyecto,model.Beneficiarios);
                _context.EstadoProyecto
                    .Include(p => p.Proyecto)
                    .Single(e => e.TipoEstado == model.EstadoProyecto)
                    .Proyecto.Add(proyecto);
                foreach (var dto in model.Paises)
                {
                    _context.Pais
                        .Include(p => p.ProyectoPaises)
                        .Single(p => p.Id == dto.Id).AddProyecto(proyecto);                    
                }

                foreach (var dto in model.Socios)
                {
                    _context.SocioInternacional
                        .Include(p => p.ProyectoSocios)
                        .Single(s => s.Id == dto.Id)
                        .AddProyecto(proyecto);
                }

                foreach (var dto in model.Organizaciones)
                {
                    _context.OrganizacionResponsable
                        .Include(p => p.ProyectoOrganizaciones)
                        .Single(o => o.Id == dto.Id)
                        .AddProyecto(proyecto);
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

        public bool Update(ProyectoDTO model, string id)
        {
            try
            {
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