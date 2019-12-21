using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using DatabaseContext;
using DTO.DTO;

namespace Services
{
    public interface ISeguimientoIndicadorServer
    {
        IEnumerable<SeguimientoIndicadorWrapperDTO> ForDesagregados(string inicio, string fin);
        IEnumerable<SeguimientoIndicadorWrapperDTO> ForPaises(int year, int quarter);
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

        public IEnumerable<SeguimientoIndicadorWrapperDTO> ForPaises(int year, int quarter)
        {
            try
            {
                return (from obj in _context.Objetivo
                    join res in _context.Resultado on obj equals res.Objetivo
                    orderby obj.CodigoObjetivo
                    select new SeguimientoIndicadorWrapperDTO()
                    {
                        Id = obj.CodigoObjetivo,
                        NombreObjetivo = obj.NombreObjetivo,
                        NombreResultado = res.NombreResultado,
                        Indicadores = (from ind in _context.Indicador
                            join act in _context.Actividad on ind.Actividad equals act
                            join plan in _context.PlanMonitoreoEvaluacion on ind equals plan.Indicador
                            join niv in _context.NivelImpacto on plan.NivelImpacto equals niv  
                            join proy in _context.Proyecto on plan.Proyecto equals proy 
                            where act.Resultado == res &&
                                  proy.FechaInicio.Year == year
                                  select new SeguimientoIndicadorDTO()
                                  {
                                      Id = ind.CodigoIndicador,
                                      NombreIndicador = ind.NombreIndicador,
                                      NombreActividad = act.NombreActividad,
                                      Nivel = niv.NombreNivelImpacto,
                                      OrganizacionesResponsables = (from org in _context.OrganizacionResponsable
                                          join proyorg in _context.ProyectoOrganizacion on org equals proyorg.OrganizacionResponsable
                                          where proyorg.Proyecto == proy
                                              select new MapDTO()
                                              {
                                                  Id = org.Id,
                                                  Nombre = org.NombreOrganizacion
                                              }).ToArray(),
                                      Desagregados = (from des in _context.Desagregacion
                                          join plandes in _context.PlanDesagregacion on des equals plandes.Desagregacion
                                          where plandes.PlanMonitoreoEvaluacionIndicadorId == ind.CodigoIndicador &&
                                                plandes.PlanMonitoreoEvaluacionProyectoCodigoProyecto == proy.CodigoProyecto
                                                select new MapDTO()
                                                {
                                                    Id = des.Id,
                                                    Nombre = des.TipoDesagregacion
                                                }).ToArray(),
                                      RegistroSocios = (from psd in _context.PlanSocioDesagregacion
                                              join psocio in _context.SocioInternacional on psd.SocioInternacional equals psocio
                                              where psd.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == ind.CodigoIndicador &&
                                                    psd.Trimestre == quarter
                                              select new SeguimientoIndicadorTableDTO()
                                                    {
                                                        Id = psd.SocioInternacionalId,
                                                        IdDesagregado = psd.PlanDesagregacionDesagregacionId,
                                                        Codigo = psd.CodigoPais,
                                                        Valor = psd.Valor
                                                    }).ToArray()

                                  }).ToArray()
                    }).ToList();
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
                return (from obj in _context.Objetivo
                    join res in _context.Resultado on obj equals res.Objetivo
                    orderby obj.CodigoObjetivo
                    select new SeguimientoIndicadorWrapperDTO()
                    {
                        Id = obj.CodigoObjetivo,
                        NombreObjetivo = obj.NombreObjetivo,
                        NombreResultado = res.NombreResultado,
                        Indicadores = (from ind in _context.Indicador
                            join act in _context.Actividad on ind.Actividad equals act
                            join meta in _context.Meta on ind equals meta.Indicador
                            join plan in _context.PlanMonitoreoEvaluacion on ind equals plan.Indicador
                            join niv in _context.NivelImpacto on plan.NivelImpacto equals niv
                            join fue in _context.FuenteDato on plan.FuenteDato equals fue
                            join fre in _context.FrecuenciaMedicion on plan.FrecuenciaMedicion equals fre
                            join proy in _context.Proyecto on plan.Proyecto equals proy 
                            where act.Resultado == res &&
                                  proy.FechaInicio.Year == year
                                  select new SeguimientoIndicadorDTO()
                                  {
                                      Id = ind.CodigoIndicador,
                                      NombreIndicador = ind.NombreIndicador,
                                      NombreActividad = act.NombreActividad,
                                      Meta = meta.ValorMeta,
                                      Nivel = niv.NombreNivelImpacto,
                                      Fuente = fue.NombreFuente,
                                      Frecuencia = fre.NombreFrecuencia,
                                      Metodologia = plan.MetodologiaRecoleccion,
                                      TotalQ1 = (from psd in _context.PlanSocioDesagregacion
                                          join s in _context.SocioInternacional on psd.SocioInternacional equals s
                                          join ps in _context.ProyectoSocio on s equals ps.SocioInternacional
                                          join p in _context.Proyecto on ps.Proyecto equals p
                                          where psd.Trimestre == 1 && p.FechaInicio.Year == year && psd.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == ind.CodigoIndicador
                                          select psd.Valor).Sum(),
                                      TotalQ2 = (from psd in _context.PlanSocioDesagregacion
                                          join s in _context.SocioInternacional on psd.SocioInternacional equals s
                                          join ps in _context.ProyectoSocio on s equals ps.SocioInternacional
                                          join p in _context.Proyecto on ps.Proyecto equals p
                                          where psd.Trimestre == 2 && p.FechaInicio.Year == year && psd.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == ind.CodigoIndicador
                                          select psd.Valor).Sum(),
                                      TotalQ3 = (from psd in _context.PlanSocioDesagregacion
                                          join s in _context.SocioInternacional on psd.SocioInternacional equals s
                                          join ps in _context.ProyectoSocio on s equals ps.SocioInternacional
                                          join p in _context.Proyecto on ps.Proyecto equals p
                                          where psd.Trimestre == 3 && p.FechaInicio.Year == year && psd.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == ind.CodigoIndicador
                                          select psd.Valor).Sum(),
                                      TotalQ4 = (from psd in _context.PlanSocioDesagregacion
                                          join s in _context.SocioInternacional on psd.SocioInternacional equals s
                                          join ps in _context.ProyectoSocio on s equals ps.SocioInternacional
                                          join p in _context.Proyecto on ps.Proyecto equals p
                                          where psd.Trimestre == 4 && p.FechaInicio.Year == year && psd.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == ind.CodigoIndicador
                                          select psd.Valor).Sum(),
                                      TotalAnterior = (from psd in _context.PlanSocioDesagregacion
                                          join s in _context.SocioInternacional on psd.SocioInternacional equals s
                                          join ps in _context.ProyectoSocio on s equals ps.SocioInternacional
                                          join p in _context.Proyecto on ps.Proyecto equals p
                                          where p.FechaInicio.Year == (year - 1) && psd.PlanDesagregacionPlanMonitoreoEvaluacionIndicadorId == ind.CodigoIndicador
                                          select psd.Valor).Sum(),
                                      OrganizacionesResponsables = (from org in _context.OrganizacionResponsable
                                          join proyorg in _context.ProyectoOrganizacion on org equals proyorg.OrganizacionResponsable
                                          where proyorg.Proyecto == proy
                                              select new MapDTO()
                                              {
                                                  Id = org.Id,
                                                  Nombre = org.NombreOrganizacion
                                              }).ToArray(),
                                      Desagregados = (from des in _context.Desagregacion
                                          join plandes in _context.PlanDesagregacion on des equals plandes.Desagregacion
                                          where plandes.PlanMonitoreoEvaluacionIndicadorId == ind.CodigoIndicador &&
                                                plandes.PlanMonitoreoEvaluacionProyectoCodigoProyecto == proy.CodigoProyecto
                                                select new MapDTO()
                                                {
                                                    Id = des.Id,
                                                    Nombre = des.TipoDesagregacion
                                                }).ToArray(),
                                  }).ToArray()
                    }).ToList();
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