using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public interface IProyectoListService
    {
        IEnumerable<ProyectoDTO> GetAll(string estado);       
        IEnumerable<ProyectoDTO> GetAll(string estado, string pais);
    }
    public class ProyectoListService : IProyectoListService
    {
        private readonly simepadfContext _context;

        public ProyectoListService(simepadfContext context)
        {
            _context = context;
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
                    item.Paises = GetProjectCountries(item.Id);
                    item.IsPlanTrabajo = CheckPlanTrabajo(item.Id);
                    item.IsActividadPlanTrabajo = CheckActividadPlanTrabajo(item.Id);
                    item.IsIndicador = CheckPlanMonitoreoEvaluacion(item.Id);
                    item.TotalActividades = GetProjectTotalActivities(item.Id);
                    item.TotalActividadesFinalizadas = GetProjectEndedActivities(item.Id);
                    item.IsChecked = IsProjectReviewCompletedForStatus(item.Id, "all", estados);
                }
                return dto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoDTO>();
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
                    item.Paises = GetProjectCountries(item.Id);
                    item.IsPlanTrabajo = CheckPlanTrabajo(item.Id);
                    item.IsActividadPlanTrabajo = CheckActividadPlanTrabajo(item.Id);
                    item.IsIndicador = CheckPlanMonitoreoEvaluacion(item.Id);
                    item.TotalActividades = GetProjectTotalActivities(item.Id);
                    item.TotalActividadesFinalizadas = GetProjectEndedActivities(item.Id);
                    item.IsChecked = IsProjectReviewCompletedForStatus(item.Id, pais, estados);
                    item.IsApproved = IsProjectApprovedByCountry(item.Id, pais);
                }
                return dto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoDTO>();
            }
        }
        
        private bool CheckPlanTrabajo(string id)
        {
            try
            {
                return _context.PlanTrabajo.Any(p => p.CodigoPlanTrabajo.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
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
        
        
        private MapDTO[] GetProjectCountries(string id)
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
        
        private int GetProjectTotalActivities(string projectId)
        {
            try
            {
                return _context.ActividadPT.Count(a => a.PlanTrabajoCodigoPlanTrabajo == projectId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
        
        private int GetProjectEndedActivities(string projectId)
        {
            try
            {
                return _context.ActividadPT.Count(a => a.PlanTrabajoCodigoPlanTrabajo == projectId && a.Completa);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
        
        private bool IsProjectReviewCompletedForStatus(string projectId, string country, string[] status)
        {
            try
            {
                var reviewNumber = (from s in status where s.Contains("REVISION") select Int32.Parse(s.Replace("REVISION", ""))).ToList();
                if (reviewNumber.Count <= 0) return false;
                var review = (from reg in _context.RegistroRevision
                    join pp in _context.ProyectoPais on reg.ProyectoPais equals pp
                    join p in _context.Pais on pp.Pais equals p
                    where pp.ProyectoId == projectId && 
                          (p.NombrePais == country || country == "all") &&
                          reviewNumber.Contains(reg.NumeroRevision)
                    select reg).ToList();
                return review.All(r => r.Revisado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private bool IsProjectApprovedByCountry(string id, string pais)
        {
            try
            {
                var country = _context.Pais.Single(p => p.NombrePais == pais);
                return _context.ProyectoPais.Any(p => p.ProyectoId == id && p.PaisId == country.Id && p.Aprobado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}