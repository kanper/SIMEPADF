using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using DatabaseContext;
using DTO.DTO;

namespace Services
{
    public interface ISeguimientoIndicadorServer
    {
        IEnumerable<SeguimientoIndicadorWrapperDTO> ForDesagregados(int year, int quarter);
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

        public IEnumerable<SeguimientoIndicadorWrapperDTO> ForDesagregados(int year, int quarter)
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
                            join proy in _context.Proyecto on plan.Proyecto equals proy 
                            where act.Resultado == res &&
                                  proy.FechaInicio.Year == year
                                  select new SeguimientoIndicadorDTO()
                                  {
                                      Id = ind.CodigoIndicador,
                                      NombreIndicador = ind.NombreIndicador,
                                      NombreActividad = act.NombreActividad,
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
    }
}