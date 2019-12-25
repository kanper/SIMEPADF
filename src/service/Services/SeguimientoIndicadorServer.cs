using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using DatabaseContext;
using DTO.DTO;
using Microsoft.VisualBasic.CompilerServices;

namespace Services
{
    public interface ISeguimientoIndicadorServer
    {
        IEnumerable<SeguimientoIndicadorWrapperDTO> ForDesagregados(string inicio, string fin);
        IEnumerable<SeguimientoIndicadorWrapperDTO> ForPaises(string inicio, string fin);
        IEnumerable<SeguimientoIndicadorWrapperDTO> ForRegiones(int year);
    }
    
    public class SeguimientoIndicadorServer : ISeguimientoIndicadorServer
    {

        private readonly simepadfContext _context;

        public SeguimientoIndicadorServer(simepadfContext context)
        {
            _context = context;
        }

        public IEnumerable<SeguimientoIndicadorWrapperDTO> ForDesagregados(string inicio, string fin)
        {
            try
            {
                var result = (from obj in _context.Objetivo
                    join res in _context.Resultado on obj equals res.Objetivo
                    orderby obj.CodigoObjetivo
                    select new SeguimientoIndicadorWrapperDTO()
                    {
                        Id = obj.CodigoObjetivo,
                        CodigoResultado = res.CodigoResultado,
                        NombreObjetivo = obj.NombreObjetivo,
                        NombreResultado = res.NombreResultado,
                        Indicadores = (from ind in _context.Indicador
                            join act in _context.Actividad on ind.Actividad equals act
                            where act.Resultado == res
                            select new SeguimientoIndicadorDTO()
                                  {
                                      Id = ind.CodigoIndicador,
                                      CodigoActividad = act.CodigoActividad,
                                      NombreIndicador = ind.NombreIndicador,
                                      NombreActividad = act.NombreActividad,
                                  }).ToArray()
                    }).ToList();
                foreach (var ind in result.SelectMany(wrap => wrap.Indicadores))
                {
                    ind.OrganizacionesResponsables = GetOrganizacionesResponsables(ind.Id);
                    ind.Desagregados = GetDesagregados(ind.Id);
                    ind.RegistroSocios = GetRegistro(ind.Id, inicio, fin);
                }
                return result;
            }
            catch (Exception e)             
            {
                Console.WriteLine(e);
                return new List<SeguimientoIndicadorWrapperDTO>();
            }
        }

        public IEnumerable<SeguimientoIndicadorWrapperDTO> ForPaises(string inicio, string fin)
        {
            try
            {
                var result = (from obj in _context.Objetivo
                    join res in _context.Resultado on obj equals res.Objetivo
                    orderby obj.CodigoObjetivo
                    select new SeguimientoIndicadorWrapperDTO()
                    {
                        Id = obj.CodigoObjetivo,
                        CodigoResultado = res.CodigoResultado,
                        NombreObjetivo = obj.NombreObjetivo,
                        NombreResultado = res.NombreResultado,
                        Indicadores = (from ind in _context.Indicador
                            join act in _context.Actividad on ind.Actividad equals act
                            where act.Resultado == res 
                            select new SeguimientoIndicadorDTO()
                                  {
                                      Id = ind.CodigoIndicador,
                                      CodigoActividad = act.CodigoActividad,
                                      NombreIndicador = ind.NombreIndicador,
                                      NombreActividad = act.NombreActividad,
                                  }).ToArray()
                    }).ToList();
                foreach (var ind in result.SelectMany(wrap => wrap.Indicadores))
                {
                    ind.OrganizacionesResponsables = GetOrganizacionesResponsables(ind.Id);
                    ind.Niveles = GetNiveles(ind.Id, inicio, fin);
                    ind.RegistroSocios = GetRegistro(ind.Id, inicio, fin);
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<SeguimientoIndicadorWrapperDTO>();
            }
        }

        public IEnumerable<SeguimientoIndicadorWrapperDTO> ForRegiones(int year)
        {
            try
            {
                var result = (from obj in _context.Objetivo
                    join res in _context.Resultado on obj equals res.Objetivo
                    orderby obj.CodigoObjetivo
                    select new SeguimientoIndicadorWrapperDTO()
                    {
                        Id = obj.CodigoObjetivo,
                        CodigoResultado = res.CodigoResultado,
                        NombreObjetivo = obj.NombreObjetivo,
                        NombreResultado = res.NombreResultado,
                        Indicadores = (from ind in _context.Indicador
                            join act in _context.Actividad on ind.Actividad equals act
                            join meta in _context.Meta on ind equals meta.Indicador
                            where act.Resultado == res
                            select new SeguimientoIndicadorDTO()
                                  {
                                      Id = ind.CodigoIndicador,
                                      CodigoActividad = act.CodigoActividad,
                                      NombreIndicador = ind.NombreIndicador,
                                      NombreActividad = act.NombreActividad,
                                      Meta = ind.MetaGlobal,
                                      MetaAnual = meta.ValorMeta
                                  }).ToArray()
                    }).ToList();
                foreach (var ind in result.SelectMany(wrap => wrap.Indicadores))
                {
                    ind.OrganizacionesResponsables = GetOrganizacionesResponsables(ind.Id);
                    ind.Desagregados = GetDesagregados(ind.Id);
                    ind.Niveles = GetNiveles(ind.Id, year);
                    ind.Frecuencias = GetFrecuencias(ind.Id, year);
                    ind.Metodologias = GetMetodologias(ind.Id, year);
                    ind.Fuentes = GetFuentes(ind.Id, year);
                    ind.TotalQ1 = GetTotalTrimestre(ind.Id, 1, year);
                    ind.TotalQ2 = GetTotalTrimestre(ind.Id, 2, year);
                    ind.TotalQ3 = GetTotalTrimestre(ind.Id, 3, year);
                    ind.TotalQ4 = GetTotalTrimestre(ind.Id, 4, year);
                    ind.TotalAnterior = GetTotalAnioPasado(ind.Id, year);
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<SeguimientoIndicadorWrapperDTO>();
            }
        }

        private MapDTO[] GetOrganizacionesResponsables(int indId)
        {
            try
            {
                var result = new List<MapDTO>();
                var q = (from orgProj in _context.ProyectoOrganizacion
                    join proj in _context.Proyecto on orgProj.Proyecto equals proj
                    join plan in _context.PlanMonitoreoEvaluacion on proj equals plan.Proyecto
                    where plan.IndicadorId == indId
                    group orgProj.ProyectoId by orgProj.OrganizacionResponsableId
                    into g
                    select g);
                foreach (var g in q)
                {
                    result.Add((from org in _context.OrganizacionResponsable
                        where org.Id == g.Key
                        select new MapDTO()
                        {
                            Id = org.Id,
                            Nombre = org.NombreOrganizacion
                        }).Single());
                }
                return result.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private MapDTO[] GetDesagregados(int indId)
        {
            try
            {
                var result = new List<MapDTO>();
                var q = (from plan in _context.PlanMonitoreoEvaluacion
                    join planDes in _context.PlanDesagregacion on plan equals planDes.PlanMonitoreoEvaluacion
                    where plan.IndicadorId == indId
                    group planDes by planDes.DesagregacionId
                    into g
                    select g);
                foreach (var g in q)
                {
                    result.Add((from des in _context.Desagregacion
                        where des.Id == g.Key
                        select new MapDTO()
                        {
                            Id = des.Id,
                            Nombre = des.TipoDesagregacion
                        }).Single());
                }
                return result.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private SeguimientoIndicadorTableDTO[] GetRegistro(int indId, string start, string end)
        {
            try
            {
                var projectIds = (from proj in _context.Proyecto
                    where proj.FechaInicio >= GetStartDate(start) &&
                          proj.FechaInicio <= GetEndDate(end)
                    select proj.CodigoProyecto).ToList();
                
                return (from plan in _context.PlanSocioDesagregacion
                    where projectIds.Contains(plan.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto) &&
                          plan.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == indId
                    select new SeguimientoIndicadorTableDTO()
                    {
                        Id = plan.SocioInternacionalId,
                        IdDesagregado = plan.PlanDesagregacionDesagregacionId,
                        Codigo = plan.CodigoPais,
                        Valor = plan.Valor
                    }).ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private string[] GetNiveles(int indId, string start, string end)
        {
            try
            {
                var result = new List<string>();
                var q = (from plan in _context.PlanMonitoreoEvaluacion
                    join niv in _context.NivelImpacto on plan.NivelImpacto equals niv
                    join proj in _context.Proyecto on plan.Proyecto equals proj
                    where plan.IndicadorId == indId &&
                          proj.FechaInicio >= GetStartDate(start) &&
                          proj.FechaInicio <= GetEndDate(end)
                    group plan by niv.NombreNivelImpacto
                    into g
                    select g);
                foreach (var g in q)
                {
                    result.Add(g.Key);
                }
                return result.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        
        private string[] GetNiveles(int indId, int year)
        {
            try
            {
                var result = new List<string>();
                var q = (from plan in _context.PlanMonitoreoEvaluacion
                    join niv in _context.NivelImpacto on plan.NivelImpacto equals niv
                    join proj in _context.Proyecto on plan.Proyecto equals proj
                    where plan.IndicadorId == indId &&
                          proj.FechaInicio.Year == year
                    group plan by niv.NombreNivelImpacto
                    into g
                    select g);
                foreach (var g in q)
                {
                    result.Add(g.Key);
                }
                return result.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private string[] GetFuentes(int indId, int year)
        {
            try
            {
                var result = new List<string>();
                var q = (from plan in _context.PlanMonitoreoEvaluacion
                    join f in _context.FuenteDato on plan.FuenteDato equals f
                    join proj in _context.Proyecto on plan.Proyecto equals proj
                    where plan.IndicadorId == indId &&
                          proj.FechaInicio.Year == year
                    group plan by f.NombreFuente
                    into g
                    select g);
                foreach (var g in q)
                {
                    result.Add(g.Key);
                }

                return result.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private string[] GetFrecuencias(int indId, int year)
        {
            try
            {
                var result = new List<string>();
                var q = (from plan in _context.PlanMonitoreoEvaluacion
                    join f in _context.FrecuenciaMedicion on plan.FrecuenciaMedicion equals f
                    join proj in _context.Proyecto on plan.Proyecto equals proj
                    where plan.IndicadorId == indId &&
                          proj.FechaInicio.Year == year
                    group plan by f.NombreFrecuencia
                    into g
                    select g);
                foreach (var g in q)
                {
                    result.Add(g.Key);
                }

                return result.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private string[] GetMetodologias(int indId, int year)
        {
            try
            {
                var result = new List<string>();
                var q = (from plan in _context.PlanMonitoreoEvaluacion
                    join proj in _context.Proyecto on plan.Proyecto equals proj
                    where plan.IndicadorId == indId &&
                          proj.FechaInicio.Year == year
                    group plan by plan.MetodologiaRecoleccion
                    into g
                    select g);
                foreach (var g in q)
                {
                    result.Add(g.Key);
                }
                return result.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private double GetTotalTrimestre(int indId, int quarter, int year)
        {
            try
            {
                var projectsIds = (from proj in _context.Proyecto
                    where proj.FechaInicio.Year == year
                    select proj.CodigoProyecto).ToList();
                return (from psd in _context.PlanSocioDesagregacion
                        where psd.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == indId &&
                              projectsIds.Contains(psd.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto) &&
                              psd.Trimestre == quarter
                              select psd.Valor).Sum();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        private double GetTotalAnioPasado(int indId, int year)
        {
            try
            {
                var projectsIds = (from proj in _context.Proyecto
                    where proj.FechaInicio.Year == (year -1)
                    select proj.CodigoProyecto).ToList();
                return (from psd in _context.PlanSocioDesagregacion
                    where psd.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == indId &&
                          projectsIds.Contains(psd.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto)
                    select psd.Valor).Sum();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        private int GetDateYear(string date)
        {
            if (date == null) throw new ArgumentNullException(nameof(date));
            var values = date.Split("-");
            return int.Parse(values[0]);
        }

        private int GetDateMonth(string date)
        {
            if (date == null) throw new ArgumentNullException(nameof(date));
            var values = date.Split("-");
            return int.Parse(values[1]);
        }
        
        private int GetDateQuarter(string date)
        {
            return (GetDateMonth(date) + 2)/3;
        }

        private DateTime GetStartDate(string date)
        {
            return new DateTime(GetDateYear(date),GetDateMonth(date), 1);
        }

        private DateTime GetEndDate(string date)
        {
            return new DateTime(GetDateYear(date),GetDateMonth(date), DateTime.DaysInMonth(GetDateYear(date),GetDateMonth(date)));
        }
    }
}