using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Model.Domain;

namespace Services
{
    public interface IProyectoService
    {
        ProyectoDTO Get(string id);
        IEnumerable<ProyectoDTO> GetAll();
        IEnumerable<ProyectoDTO> GetAll(string estado);       
        IEnumerable<ProyectoDTO> GetAll(string estado, string pais);
        bool Add(ProyectoDTO model, string estadoInicial);              
        bool Update(ProyectoDTO model, string id);
        bool Delete(string id);
        bool ChangeStatus(string id, string status);
        bool Check(string id, string estado, string pais);
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
                        Regional = p.Regional,
                        MontoProyecto = p.MontoProyecto,
                        FechaAprobacion = p.FechaAprobacion,
                        FechaInicio = p.FechaInicio,
                        FechaFin = p.FechaFin,
                        Beneficiarios = p.Beneficiarios,
                        EstadoProyecto = e.TipoEstado,
                        Paises = (from pais in _context.Pais 
                            join pp in _context.ProyectoPais 
                                on pais equals pp.Pais 
                            where pp.ProyectoId == p.CodigoProyecto 
                            select new MapDTO()
                            {
                                Id = pais.Id, 
                                Nombre = pais.NombrePais
                            }).ToArray(),
                        Socios = (from socio in _context.SocioInternacional
                            join ps in _context.ProyectoSocio
                                on socio equals ps.SocioInternacional
                            where ps.ProyectoId == p.CodigoProyecto
                            select new MapDTO()
                                {
                                  Id = socio.Id,
                                  Nombre = socio.NombreSocio
                                }).ToArray(),
                        Organizaciones = (from org in _context.OrganizacionResponsable
                                join po in _context.ProyectoOrganizacion
                                    on org equals po.OrganizacionResponsable
                                where po.ProyectoId == p.CodigoProyecto
                                  select new MapDTO()
                                  {
                                      Id = org.Id,
                                      Nombre = org.NombreOrganizacion
                                  }).ToArray()
                        
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
                        Regional = p.Regional,
                        MontoProyecto = p.MontoProyecto,
                        FechaAprobacion = p.FechaAprobacion,
                        FechaInicio = p.FechaInicio,
                        FechaFin = p.FechaFin,
                        Beneficiarios = p.Beneficiarios,
                        EstadoProyecto = e.TipoEstado,                       
                    }).ToList();               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoDTO>();
            }
        }

        public IEnumerable<ProyectoDTO> GetAll(string estado, string pais)
        {
            string[] estados = estado.Split('$');
            try
            {
                return (from p in _context.Proyecto
                    join e in _context.EstadoProyecto
                        on p.EstadoProyecto equals e
                    join pp in _context.ProyectoPais
                        on p equals pp.Proyecto
                    join ps in _context.Pais
                        on pp.Pais equals ps
                    where estados.Contains(e.TipoEstado) &&
                          ps.NombrePais.Contains(pais) 
                    select new ProyectoDTO()
                    {
                        Id = p.CodigoProyecto,
                        NombreProyecto = p.NombreProyecto,
                        Regional = p.Regional,
                        MontoProyecto = p.MontoProyecto,
                        FechaAprobacion = p.FechaAprobacion,
                        FechaInicio = p.FechaInicio,
                        FechaFin = p.FechaFin,
                        Beneficiarios = p.Beneficiarios,
                        EstadoProyecto = e.TipoEstado,
                        IsPlanTrabajo = (from pl in _context.PlanTrabajo                            
                            where pl.CodigoPlanTrabajo == p.CodigoProyecto 
                            select pl).Any(),
                        IsIndicador = (from i in _context.PlanMonitoreoEvaluacion 
                            where i.ProyectoCodigoProyecto == p.CodigoProyecto                                                                  
                            select i).Any(),                        
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoDTO>();
            }
        }
        
        public IEnumerable<ProyectoDTO> GetAll(string estado)
        {
            string[] estados = estado.Split('$');
            try
            {
                return (from p in _context.Proyecto
                    join e in _context.EstadoProyecto
                        on p.EstadoProyecto equals e
                    where estados.Contains(e.TipoEstado)    
                    select new ProyectoDTO()
                    {
                        Id = p.CodigoProyecto,
                        NombreProyecto = p.NombreProyecto,
                        Regional = p.Regional,
                        MontoProyecto = p.MontoProyecto,
                        FechaAprobacion = p.FechaAprobacion,
                        FechaInicio = p.FechaInicio,
                        FechaFin = p.FechaFin,
                        Beneficiarios = p.Beneficiarios,
                        EstadoProyecto = e.TipoEstado,
                        IsPlanTrabajo = (from pl in _context.PlanTrabajo                            
                            where pl.CodigoPlanTrabajo == p.CodigoProyecto 
                            select pl).Any(),
                        IsIndicador = (from i in _context.PlanMonitoreoEvaluacion 
                            where i.ProyectoCodigoProyecto == p.CodigoProyecto                                                                  
                            select i).Any(),
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoDTO>();
            }
        }


        public bool Add(ProyectoDTO model, string estadoInicial)
        {
            try
            {
                var proyecto = new Proyecto(model.NombreProyecto, model.Regional, model.FechaAprobacion,model.FechaInicio,model.FechaFin,model.MontoProyecto,model.Beneficiarios);
                _context.EstadoProyecto
                    .Include(p => p.Proyecto)
                    .Single(e => e.TipoEstado == estadoInicial)
                    .Proyecto.Add(proyecto);
                /*
                 * Por cada lista guarda uno por uno los elementos
                 */
                foreach (var dto in model.Paises)
                {
                    _context.Pais
                        .Include(p => p.ProyectoPaises)
                        .Single(p => p.Id == dto.Id)
                        .AddProyecto(proyecto);                    
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
                var proyecto = _context.Proyecto
                    .Include(p => p.ProyectoPaises)
                    .Include(o => o.ProyectoOrganizaciones)
                    .Include(s => s.ProyectoSocios)
                    .Single(p => p.CodigoProyecto == id);
                proyecto.NombreProyecto = model.NombreProyecto;
                proyecto.Regional = model.Regional;
                proyecto.MontoProyecto = model.MontoProyecto;
                proyecto.Beneficiarios = model.Beneficiarios;
                proyecto.FechaAprobacion = model.FechaAprobacion;
                proyecto.FechaInicio = model.FechaInicio;
                proyecto.FechaFin = model.FechaFin;
                proyecto.ProyectoPaises.Clear();
                proyecto.ProyectoSocios.Clear();
                proyecto.ProyectoOrganizaciones.Clear();
                /*
                 * Se agregan los nuevo elementos a cada lista
                 */
                foreach (var dto in model.Paises)
                {                                                                                                    
                    proyecto.AddPais(GetPais(dto.Id));
                }

                foreach (var dto in model.Socios)
                {                    
                    proyecto.AddSocio(GetSocio(dto.Id));
                }

                foreach (var dto in model.Organizaciones)
                {                   
                    proyecto.AddOrganizacion(GetOrganizacion(dto.Id));
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

        public bool Delete(string id)
        {
            try
            {
                _context.Proyecto.Single(p => p.CodigoProyecto == id).Deleted = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool ChangeStatus(string id, string status)
        {
            try
            {
                CreateReviewSet(id, status);
                var proyecto = _context.Proyecto
                    .Include(s => s.EstadoProyecto)
                    .Single(p => p.CodigoProyecto == id);
                proyecto.EstadoProyecto = _context.EstadoProyecto.Single(s => s.TipoEstado == status);                
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Check(string id, string estado, string pais)
        {
            try
            {
                var revisiones = _context.ProyectoPais
                    .Include(pp => pp.Pais)
                    .Include(pp => pp.RegistroRevisiones)
                    .Where(pp => pp.ProyectoId == id && pp.Pais.NombrePais == pais)
                    .ToList();                
                {
                    
                }
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

        private bool IsPaisIncluded(ICollection<ProyectoPais> collection, int idPais)
        {
            return collection.Any(pp => idPais == pp.PaisId);
        }

        private bool IsSocioIncluded(ICollection<ProyectoSocio> collection, int idSocio)
        {
            return collection.Any(ps => idSocio == ps.SocioInternacionalId);
        }

        private bool IsOrganizacionIncluded(ICollection<ProyectoOrganizacion> collection, int idOrg)
        {
            return collection.Any(po => idOrg == po.OrganizacionResponsableId);
        }

        private bool IsIncluded(MapDTO[] map, int idPais)
        {
            return map.Any(dto => idPais == dto.Id);
        }

        private void CreateReviewSet(string id, string status)
        {
            if (status.Equals("EN_PROCESO"))
            {
                foreach (var proyectoPais in _context.ProyectoPais.Where(p => p.ProyectoId == id).ToList())
                {
                    proyectoPais.AddProcesoRevision();
                }
            }
        }
    }
}