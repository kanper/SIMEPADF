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
        IEnumerable<ProyectoDTO> GetAll(string estado);       
        IEnumerable<ProyectoDTO> GetAll(string estado, string pais);
        bool Add(ProyectoDTO model, string estadoInicial);              
        bool Update(ProyectoDTO model, string id);
        bool Delete(string id);
        bool ChangeStatus(string id, string status);
        bool Check(string id, string estado, string pais);
        bool Reject(string id, string observation, string username);
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
                        TipoBeneficiario = p.TipoBeneficiario,
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
                              }).ToArray(),
                        Indicadores = (from pme in _context.PlanMonitoreoEvaluacion
                            join indicador in _context.Indicador 
                                on pme.Indicador equals indicador
                            join actividad in _context.Actividad 
                                on indicador.Actividad equals actividad
                            join resultado in _context.Resultado 
                                on actividad.Resultado equals resultado
                            join objetivo in _context.Objetivo 
                                on resultado.Objetivo equals objetivo 
                            where pme.ProyectoCodigoProyecto == id
                                  select new PlanMEDTO()
                                  {
                                      IndicadorId = indicador.CodigoIndicador,
                                      NombreIndicador = indicador.NombreIndicador,
                                      ActividadId = actividad.CodigoActividad,
                                      NombreActividad = actividad.NombreActividad,
                                      ResultadoId = resultado.CodigoResultado,
                                      NombreResultado = resultado.NombreResultado,
                                      ObjetivoId = objetivo.CodigoObjetivo,
                                      NombreObjetivo = objetivo.NombreObjetivo,
                                      Metodologia = pme.MetodologiaRecoleccion,
                                      LineaBase =  pme.ValorLineaBase,
                                      NivelImpacto = (from nivel in _context.NivelImpacto 
                                          where nivel == pme.NivelImpacto 
                                          select new MapDTO {Id = nivel.Id, Nombre = nivel.NombreNivelImpacto}).SingleOrDefault(),
                                      FuenteDato = (from fuente in _context.FuenteDato 
                                          where fuente == pme.FuenteDato 
                                          select new MapDTO {Id = fuente.Id, Nombre = fuente.NombreFuente}).SingleOrDefault(),
                                      FrecuenciaMedicion = (from frecuencia in _context.FrecuenciaMedicion 
                                          where frecuencia == pme.FrecuenciaMedicion 
                                          select new MapDTO {Id = frecuencia.Id, Nombre = frecuencia.NombreFrecuencia}).SingleOrDefault(),
                                      Desagregaciones = (from pds in _context.PlanDesagregacion
                                          join desg in _context.Desagregacion on pds.Desagregacion  equals desg
                                          where pds.PlanMonitoreoEvaluacionProyectoCodigoProyecto == id
                                            select new MapDTO
                                            {
                                                Id = desg.Id,
                                                Nombre = desg.TipoDesagregacion
                                            }).ToArray()
                                  }).ToArray(),
                        Planes = (from plan in _context.PlanTrabajo
                            join apt in _context.ActividadPT on plan equals apt.PlanTrabajo
                            where plan.CodigoPlanTrabajo == id
                                  select new ActividadPtDTO()
                                  {
                                      Id = apt.CodigoActividadPT,
                                      Monto = apt.Monto,
                                      NombreActividad = apt.NombreActividad,
                                      FechaCreacion = plan.FechaCreacion,
                                      FechaInicio = apt.FechaInicio,
                                      FechaLimite = apt.FechaLimite,
                                      Paises = (from aps in _context.ActividadPTPais 
                                          join pais in _context.Pais on aps.Pais equals pais
                                          where aps.ActividadPTCodigoActividadPT == apt.CodigoActividadPT
                                                select new MapDTO()
                                                {
                                                    Id = pais.Id,
                                                    Nombre = pais.NombrePais
                                                }).ToArray(),
                                      Productos = (from prd in _context.Producto
                                      where prd.ActividadPTId == apt.CodigoActividadPT
                                            select new MapDTO()
                                            {
                                                Id = prd.codigoProducto,
                                                Nombre = prd.NombreProducto
                                            }).ToArray()
                                  }
                             ).ToArray()
                        
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        
        public IEnumerable<ProyectoDTO> GetAll(string estado, string pais)
        {
            try
            {
                var estados = estado.Split('$');
                var dto = (from p in _context.Proyecto
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
                        PorcentajeAvance = p.PorcentajeAvence,
                        EstadoProyecto = e.TipoEstado,
                    }).ToList();
                foreach (var item in dto)
                {
                    item.Paises = GetProyectCountries(item.Id);
                    item.IsPlanTrabajo = CheckPlanTrabajo(item.Id);
                    item.IsActividadPlanTrabajo = CheckActividadPlanTrabajo(item.Id);
                    item.IsIndicador = CheckPlanMonitoreoEvaluacion(item.Id);
                }
                return dto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoDTO>();
            }
        }
        
        public IEnumerable<ProyectoDTO> GetAll(string estado)
        {
            try
            {
                var estados = estado.Split('$');
                var dto = (from p in _context.Proyecto
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
                        PorcentajeAvance = p.PorcentajeAvence,
                    }).ToList();
                foreach (var item in dto)
                {
                    item.Paises = GetProyectCountries(item.Id);
                    item.IsPlanTrabajo = CheckPlanTrabajo(item.Id);
                    item.IsActividadPlanTrabajo = CheckActividadPlanTrabajo(item.Id);
                    item.IsIndicador = CheckPlanMonitoreoEvaluacion(item.Id);
                }
                return dto;
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
                var registroRevision = (from proy in _context.Proyecto
                    join pp in _context.ProyectoPais
                        on proy equals pp.Proyecto
                    join e in _context.EstadoProyecto 
                        on proy.EstadoProyecto equals e
                    join p in _context.Pais
                        on pp.Pais equals p
                    join r in _context.RegistroRevision
                        on pp equals r.ProyectoPais
                    where proy.CodigoProyecto == id &&
                          e.TipoEstado == estado &&
                          (p.NombrePais == pais || pais == "all") && 
                          r.RevisionCompleta == false
                    select r).ToArray();
                if (pais == "all")
                {
                    foreach (var revision in registroRevision)
                    {
                        revision.Revisado = true;
                        revision.FechaRevisado = DateTime.Now;
                    }
                }
                else
                {
                    if (registroRevision.First() != null)
                    {
                        registroRevision.First().Revisado = true;
                        registroRevision.First().FechaRevisado = DateTime.Now;
                    }
                }
                _context.SaveChanges();
                CheckIfAllCountryWasReviewed(id, estado);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private void CheckIfAllCountryWasReviewed(string id, string estado)
        {
            var rev = Int32.Parse(estado.Remove(1));
            var registroRevisiones = from r in _context.RegistroRevision
                where r.ProyectoPais.ProyectoId == id &&
                      r.NumeroRevision == rev &&
                      r.RevisionCompleta == false
                select r;
            if (registroRevisiones.All(r => r.Revisado))
            {
                foreach (var revision in registroRevisiones)
                {
                    revision.RevisionCompleta = true;
                }
                MoveToNextStatus(id);
                _context.SaveChanges();
            }            
        }
        
        private void MoveToNextStatus(string id)
        {
            var proyecto = _context.Proyecto
                .Include(p => p.EstadoProyecto)
                .Single(p => p.CodigoProyecto == id);
            if (proyecto.EstadoProyecto.TipoEstado.Equals("3REVISION")) return;
            proyecto.EstadoProyecto = _context.EstadoProyecto.Single(e => e.Id == (proyecto.EstadoProyecto.Id + 1));
        }

        public bool Reject(string id, string observation, string username)
        {
            try
            {
                MoveToPrevious(id);
                CreateRejectNotification(id, observation, username);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private void MoveToPrevious(string id)
        {
            var proyecto = _context.Proyecto
                .Include(p => p.EstadoProyecto)
                .Single(P => P.CodigoProyecto == id);
            proyecto.EstadoProyecto = _context.EstadoProyecto.Single(e => e.TipoEstado == "EN_PROCESO");
        }

        private void CreateRejectNotification(string id, string observation, string username)
        {
            var paises = (from p in _context.Pais
                join pp in _context.ProyectoPais on p equals pp.Pais
                where pp.ProyectoId == id
                select p.NombrePais).ToArray();
            foreach (var pais in paises)
            {
                _context.Alertas.Add(new Alerta("Proyecto Retornado",observation,"warnin","4",pais,username));
                _context.SaveChanges();
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

        private void CreateReviewSet(string id, string status)
        {
            if (status.Equals("EN_PROCESO"))
            {
                foreach (var proyectoPais in _context.ProyectoPais
                    .Include(rr => rr.RegistroRevisiones)
                    .Where(p => p.ProyectoId == id).ToList())
                {
                    proyectoPais.AddProcesoRevision();
                }
            }
        }

        private bool CheckPlanMonitoreoEvaluacion(string id)
        {
            try
            {
                var result = false;
                var evaluacions = _context.PlanMonitoreoEvaluacion
                    .Include(p => p.NivelImpacto)
                    .Include(p => p.FuenteDato)
                    .Include(p => p.FrecuenciaMedicion)
                    .Include(p => p.PlanDesagregaciones)
                    .Where(p => p.ProyectoCodigoProyecto == id);
                foreach (var evaluacion in evaluacions)
                {
                    if (evaluacion.MetodologiaRecoleccion.Length > 0 &&
                        evaluacion.ValorLineaBase.Length > 0)
                    {
                        if (evaluacion.NivelImpacto != null &&
                            evaluacion.FuenteDato != null &&
                            evaluacion.FrecuenciaMedicion != null &&
                            evaluacion.PlanDesagregaciones.Count > 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                };
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private bool CheckActividadPlanTrabajo(string id)
        {
            try
            {
                var result = false;
                var pts = _context.ActividadPT
                    .Include(pt => pt.Productos)
                    .Include(pt => pt.ActividadPTPaises)
                    .Where(pt => pt.PlanTrabajoCodigoPlanTrabajo == id);
                foreach (var pt in pts)
                {
                    if (pt.Monto > 0 &&
                        pt.Productos.Count > 0 &&
                        pt.ActividadPTPaises.Count > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private bool CheckPlanTrabajo(string id)
        {
            try
            {
                return _context.PlanTrabajo.Single(p => p.CodigoPlanTrabajo.Equals(id)) != null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private MapDTO[] GetProyectCountries(string id)
        {
            try
            {
                return (from pais in _context.Pais
                    join pp in _context.ProyectoPais
                        on pais equals pp.Pais
                    where pp.ProyectoId == id
                    select new MapDTO()
                    {
                        Id = pais.Id,
                        Nombre = pais.NombrePais
                    }).ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}