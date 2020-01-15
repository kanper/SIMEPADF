using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

namespace Services
{
    public interface IProyectoSeguimientoService
    {
        IEnumerable<ProyectoSeguimientoIndicadorDTO> getProyectInd(string idProyect);
        IEnumerable<ProyectoSeguimientoRegistroDTO> getRegistro(string idProyecto, int idIndicador);
        IEnumerable<CabezeraDTO> getCabezeras(string id);
        IEnumerable<MapDTO> getOrganizaciones(string id);
        double getValor(string idProyecto, int idIndicador, int idSocio, int idDesagregado);
        bool setValor(string idProyecto, int idIndicador, int idSocio, int idDesagregado, double valor);
        bool setValor(string idProyecto, int idIndicador, int idSocio, int idDesagregado, double valor, string pais);
    }

    public class ProyectoSeguimientoService : IProyectoSeguimientoService
    {
        private readonly simepadfContext _context;

        public ProyectoSeguimientoService(simepadfContext context)
        {
            _context = context;
        }

        public IEnumerable<ProyectoSeguimientoIndicadorDTO> getProyectInd(string idProyect)
        {
            try
            {
                return (from plan in _context.PlanMonitoreoEvaluacion
                    join ind in _context.Indicador on plan.Indicador equals ind
                    join act in _context.Actividad on ind.Actividad equals act
                    join res in _context.Resultado on act.Resultado equals res
                    join obj in _context.Objetivo on res.Objetivo equals obj
                    where plan.ProyectoCodigoProyecto == idProyect
                    select new ProyectoSeguimientoIndicadorDTO()
                    {
                        IdIndicador = ind.CodigoIndicador,
                        IdProyecto = plan.ProyectoCodigoProyecto,
                        NombreIndicador = ind.NombreIndicador, 
                        NombreActividad = act.NombreActividad,
                        NombreResultado = res.NombreResultado,
                        NombreObjetivo = obj.NombreObjetivo
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoSeguimientoIndicadorDTO>();
            }
        }

        public IEnumerable<CabezeraDTO> getCabezeras(string id)
        {
            try
            {
                return (from ps in _context.ProyectoSocio
                    join s in _context.SocioInternacional on ps.SocioInternacional equals s
                    where ps.ProyectoId == id
                    select new CabezeraDTO()
                    {
                        Id = s.Id,
                        Text = s.SiglasSocio,
                        Value = "S" + s.Id,
                        Align = "start"
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<CabezeraDTO>();
            }
        }

        public IEnumerable<MapDTO> getOrganizaciones(string id)
        {
            try
            {
                return (from po in _context.ProyectoOrganizacion
                    join o in _context.OrganizacionResponsable on po.OrganizacionResponsable equals o
                    where po.ProyectoId == id
                    select new MapDTO()
                    {
                        Id = o.Id,
                        Nombre = o.NombreOrganizacion
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapDTO>();
            }
        }

        public IEnumerable<ProyectoSeguimientoRegistroDTO> getRegistro(string idProyecto, int idIndicador)
        {
            try
            {
                return (from r in _context.PlanSocioDesagregacion 
                join pd in _context.PlanDesagregacion on r.PlanDesagregacion equals pd
                join d in _context.Desagregacion on pd.Desagregacion equals d
                join s in _context.SocioInternacional on r.SocioInternacional equals s                
                    where pd.PlanMonitoreoEvaluacionProyectoCodigoProyecto == idProyecto &&
                          pd.PlanMonitoreoEvaluacionIndicadorId == idIndicador
                    select new ProyectoSeguimientoRegistroDTO()
                    {
                        Valor = r.Valor,
                        Trimestre = r.Trimestre,
                        IdDesagregado = d.Id,
                        NombreDesagregado = d.TipoDesagregacion,
                        IdSocio = s.Id,
                        NombreSocio = s.NombreSocio
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoSeguimientoRegistroDTO>();
            }
        }

        public double getValor(string idProyecto, int idIndicador, int idSocio, int idDesagregado)
        {
            try
            {
                return _context.PlanSocioDesagregacion
                    .Single(p => p.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto == idProyecto &&
                                 p.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == idIndicador &&
                                 p.SocioInternacionalId == idSocio &&
                                 p.PlanDesagregacionDesagregacionId == idDesagregado).Valor;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public bool setValor(string idProyecto, int idIndicador, int idSocio, int idDesagregado, double valor)
        {
            try
            {
                var reg = _context.PlanSocioDesagregacion
                    .Single(p => p.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto == idProyecto &&
                                 p.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == idIndicador &&
                                 p.SocioInternacionalId == idSocio &&
                                 p.PlanDesagregacionDesagregacionId == idDesagregado);
                reg.Valor = valor;
                reg.Fecha = DateTime.Now;
                _context.SaveChanges();
                updateProyectPercent(idProyecto);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private void updateProyectPercent(string idProyect)
        {
            try
            {
                var proyecto = _context.Proyecto.Single(p => p.CodigoProyecto == idProyect);
                var accumulated = 0.0;
                foreach (var reg in _context.PlanSocioDesagregacion.Where(psd => psd.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto == idProyect))
                {
                    accumulated = accumulated + reg.Valor;
                }
                proyecto.PorcentajeAvence = accumulated;
                _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool setValor(string idProyecto, int idIndicador, int idSocio, int idDesagregado, double valor, string pais)
        {
            try
            {
                var codigoPais = _context.Pais.Single(p => p.NombrePais == pais);
                if (codigoPais != null)
                {
                    var registro = _context.PlanSocioDesagregacion
                        .Single(p => p.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto == idProyecto &&
                                     p.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == idIndicador &&
                                     p.SocioInternacionalId == idSocio &&
                                     p.PlanDesagregacionDesagregacionId == idDesagregado);
                    registro.Valor = valor;
                    registro.CodigoPais = codigoPais.SiglaPais;
                    _context.SaveChanges();
                    updateProyectPercent(idProyecto);
                }
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