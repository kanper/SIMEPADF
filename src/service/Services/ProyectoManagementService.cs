using System;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Model.Domain;

namespace Services
{
    public interface IProyectoManagementService
    {
        bool Add(ProyectoDTO model, string initialStatus);              
        bool Update(ProyectoDTO model, string idProject);
        bool Delete(string idProject);
    }
    public class ProyectoManagementService : IProyectoManagementService
    {
        private readonly simepadfContext _context;

        public ProyectoManagementService(simepadfContext context)
        {
            _context = context;
        }

        public bool Add(ProyectoDTO model, string initialStatus)
        {
            try
            {
                var project = new Proyecto(model.NombreProyecto, model.Regional, model.FechaAprobacion,model.FechaInicio,model.FechaFin,model.MontoProyecto,model.Beneficiarios);
                _context.EstadoProyecto
                    .Include(p => p.Proyecto)
                    .Single(e => e.TipoEstado == initialStatus)
                    .Proyecto.Add(project);
                
                foreach (var dto in model.Paises)
                {
                    _context.Pais
                        .Include(p => p.ProyectoPaises)
                        .Single(p => p.Id == dto.Id)
                        .AddProyecto(project);                    
                }

                foreach (var dto in model.Socios)
                {
                    _context.SocioInternacional
                        .Include(p => p.ProyectoSocios)
                        .Single(s => s.Id == dto.Id)
                        .AddProyecto(project);
                }

                foreach (var dto in model.Organizaciones)
                {
                    _context.OrganizacionResponsable
                        .Include(p => p.ProyectoOrganizaciones)
                        .Single(o => o.Id == dto.Id)
                        .AddProyecto(project);
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

        public bool Update(ProyectoDTO model, string idProject)
        {
            try
            {
                var project = _context.Proyecto
                    .Include(p => p.ProyectoPaises)
                    .Include(o => o.ProyectoOrganizaciones)
                    .Include(s => s.ProyectoSocios)
                    .Single(p => p.CodigoProyecto == idProject);
                project.NombreProyecto = model.NombreProyecto;
                project.Regional = model.Regional;
                project.MontoProyecto = model.MontoProyecto;
                project.Beneficiarios = model.Beneficiarios;
                project.FechaAprobacion = model.FechaAprobacion;
                project.FechaInicio = model.FechaInicio;
                project.FechaFin = model.FechaFin;
                project.ProyectoPaises.Clear();
                project.ProyectoSocios.Clear();
                project.ProyectoOrganizaciones.Clear();
                
                foreach (var dto in model.Paises)
                {                                                                                                    
                    project.AddPais(GetPais(dto.Id));
                }

                foreach (var dto in model.Socios)
                {                    
                    project.AddSocio(GetSocio(dto.Id));
                }

                foreach (var dto in model.Organizaciones)
                {                   
                    project.AddOrganizacion(GetOrganizacion(dto.Id));
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

        public bool Delete(string idProject)
        {
            try
            {
                _context.Proyecto.Single(p => p.CodigoProyecto == idProject).Deleted = true;
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

        private SocioInternacional GetSocio(int id)
        {
            return _context.SocioInternacional.Single(s => s.Id == id);
        }

        private OrganizacionResponsable GetOrganizacion(int id)
        {
            return _context.OrganizacionResponsable.Single(o => o.Id == id);
        }
    }
}