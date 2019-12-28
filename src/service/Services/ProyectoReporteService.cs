using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;

namespace Services
{
    public interface IProyectoReporteService
    {
        IEnumerable<ProyectoReporteDTO> GetAll(int year, string countries, string socios);
        ProyectoReporteDTO Get(string id);
        ProyectoReporteDTO Get(string id,int year, int quarter);
    }
    
    public class ProyectoReporteService : IProyectoReporteService
    {

        private readonly simepadfContext _context;

        public ProyectoReporteService(simepadfContext context)
        {
            _context = context;
        }

        public IEnumerable<ProyectoReporteDTO> GetAll(int year, string countries, string socios)
        {
            try
            {
                var paisesSeleccionados = countries.Split('$');
                var sociosSeleccionados = socios.Split('$');
                var processStatus = new[] {"EN_PROCESO","1REVISION","2REVISION","3REVISION"};
                var projects = (from proj in _context.Proyecto
                    join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                    join ps in _context.ProyectoSocio on proj equals ps.Proyecto
                    join pp in _context.ProyectoPais on proj equals pp.Proyecto
                    where proj.FechaInicio.Year == year && 
                          processStatus.Contains(st.TipoEstado) &&
                          paisesSeleccionados.Contains(pp.PaisId.ToString()) &&
                          sociosSeleccionados.Contains(ps.SocioInternacionalId.ToString())
                    group proj by proj.CodigoProyecto
                    into g
                    select g);
                var selectedProjects = new List<string>();
                foreach (var g in projects)
                {
                    selectedProjects.Add(g.Key);
                }
                return (from proj in _context.Proyecto
                    where selectedProjects.Contains(proj.CodigoProyecto)
                    select new ProyectoReporteDTO()
                    {
                        Id = proj.CodigoProyecto,
                        NombreProyecto = proj.NombreProyecto,
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoReporteDTO>();
            }
        }

        public ProyectoReporteDTO Get(string id)
        {
            try
            {
                return (from proj in _context.Proyecto
                    where proj.CodigoProyecto == id
                    select new ProyectoReporteDTO()
                    {
                        Id = proj.CodigoProyecto,
                        NombreProyecto = proj.NombreProyecto
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ProyectoReporteDTO Get(string id, int year, int quarter)
        {
            try
            {
                var result = (from proj in _context.Proyecto
                    join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                    where proj.CodigoProyecto == id
                    select new ProyectoReporteDTO()
                    {
                        Id = proj.CodigoProyecto,
                        NombreProyecto = proj.NombreProyecto,
                        Regional = proj.Regional,
                        Estado = st.TipoEstado,
                        Paises = (from pp in _context.ProyectoPais
                                join p in _context.Pais on pp.Pais equals p
                                where pp.ProyectoId == proj.CodigoProyecto
                                      select new MapDTO()
                                      {
                                          Nombre = p.NombrePais
                                      }).ToArray(),
                        Organizaciones = (from po in _context.ProyectoOrganizacion
                                join o in _context.OrganizacionResponsable on po.OrganizacionResponsable equals o
                                where po.ProyectoId == proj.CodigoProyecto
                                      select new MapDTO()
                                      {
                                          Nombre = o.NombreOrganizacion
                                      }).ToArray(),
                        Indicador = (from plan in _context.PlanMonitoreoEvaluacion
                                join ind in _context.Indicador on plan.Indicador equals ind
                                join act in _context.Actividad on ind.Actividad equals act
                                join res in _context.Resultado on act.Resultado equals res
                                join obj in _context.Objetivo on res.Objetivo equals obj
                                where plan.ProyectoCodigoProyecto == proj.CodigoProyecto
                                      select new SimpleIndicadorDTO()
                                      {
                                          Id = ind.CodigoIndicador,
                                          NombreIndicador = ind.NombreIndicador,
                                          NombreActividad = act.NombreActividad,
                                          NombreResultado = res.NombreResultado,
                                          NombreObjetivo = obj.NombreObjetivo
                                      }).ToArray()
                    }).Single();
                result.Desagregados = new List<MapDTO[]>();
                result.Registro = new List<SeguimientoIndicadorTableDTO[]>();
                foreach (var item in result.Indicador)
                {
                    result.Desagregados.Add(GetDesagregados(item.Id));
                    result.Registro.Add(GetRegistro(result.Id, item.Id));
                }
                return result;
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

        private SeguimientoIndicadorTableDTO[] GetRegistro(string projectId, int indId)
        {
            try
            {
                return (from plan in _context.PlanSocioDesagregacion
                    where plan.PlanDesagregacionPlanMonitoreoEvaluacionProyectoCodigoProyecto == projectId &&
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
    }
}