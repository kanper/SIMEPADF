using System;
using System.Linq;
using DatabaseContext;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic.CompilerServices;
using Model.Domain;

namespace Services
{
    public interface IEntidadUtilizadaValidacionService
    {
        bool IsProductoUsado(int id);
        bool IsObjetivoUsado(int id);
        bool IsResultadoUsado(int id);
        bool IsActividadUsado(int id);
        bool IsIndicadorUsado(int id);
        bool IsOrganizacionUsado(int id);
        bool IsSocioUsado(int id);
        bool IsPaisUsado(int id);
        bool IsFuenteUsado(int id);
        bool IsNivelUsado(int id);
        bool IsDesagregadoUsado(int id);
        bool IsProyectoUsado(string id);
        bool IsActividadPTUsado(int id);
        bool IsUsuarioUsado(string id);
    }
    
    public class EntidadUtilizadaValidacionService : IEntidadUtilizadaValidacionService
    {
        private readonly simepadfContext _context;
        private string[] OnUsedProjectStatus = {"INCOMPLETO","PRE_VERIFICAR","VERIFICAR","EN_PROCESO","1REVISION","2REVISION","3REVISION"};

        public EntidadUtilizadaValidacionService(simepadfContext context)
        {
            _context = context;
        }

        public bool IsProductoUsado(int id)
        {
            try
            {
                return _context.ArchivoDescripcion.Any(a => a.CodigoArchivo == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsObjetivoUsado(int id)
        {
            try
            {
                if (_context.Resultado.Any(r => r.ObjetivoId == id))
                {
                    return (from r in _context.Resultado
                               join a in _context.Actividad on r equals a.Resultado
                               join i in _context.Indicador on a equals i.Actividad
                               join p in _context.PlanMonitoreoEvaluacion on i equals p.Indicador
                               join proj in _context.Proyecto on p.Proyecto equals proj
                               join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                               where r.ObjetivoId == id &&
                                     OnUsedProjectStatus.Contains(st.TipoEstado)
                               select p).ToList().Count != 0;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsResultadoUsado(int id)
        {
            try
            {
                try
                {
                    if (_context.Actividad.Any(a => a.ResultadoId == id))
                    {
                        return (from a in _context.Actividad
                                   join i in _context.Indicador on a equals i.Actividad
                                   join p in _context.PlanMonitoreoEvaluacion on i equals p.Indicador
                                   join proj in _context.Proyecto on p.Proyecto equals proj
                                   join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                                   where a.ResultadoId == id &&
                                         OnUsedProjectStatus.Contains(st.TipoEstado)
                                   select p).ToList().Count != 0;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsActividadUsado(int id)
        {
            try
            {
                if (_context.Indicador.Any(i => i.CodigoIndicador == id))
                {
                    return (from p in _context.PlanMonitoreoEvaluacion
                               join proj in _context.Proyecto on p.Proyecto equals proj
                               join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                               where p.IndicadorId == id &&
                                     OnUsedProjectStatus.Contains(st.TipoEstado)
                               select p).ToList().Count != 0;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsIndicadorUsado(int id)
        {
            try
            {
                return (from p in _context.PlanMonitoreoEvaluacion
                           join proj in _context.Proyecto on p.Proyecto equals proj
                           join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                           where p.IndicadorId == id &&
                                 OnUsedProjectStatus.Contains(st.TipoEstado)
                           select p).ToList().Count != 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsOrganizacionUsado(int id)
        {
            try
            {
                if (_context.ProyectoOrganizacion.Any(o => o.OrganizacionResponsableId == id))
                {
                    return (from op in _context.ProyectoOrganizacion
                               join proj in _context.Proyecto on op.Proyecto equals proj
                               join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                               where op.OrganizacionResponsableId == id &&
                                     OnUsedProjectStatus.Contains(st.TipoEstado)
                               select proj).ToList().Count != 0;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsSocioUsado(int id)
        {
            try
            {
                if (_context.ProyectoSocio.Any(s => s.SocioInternacionalId == id))
                {
                    return (from sp in _context.ProyectoSocio
                               join proj in _context.Proyecto on sp.Proyecto equals proj
                               join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                               where sp.SocioInternacionalId == id &&
                                     OnUsedProjectStatus.Contains(st.TipoEstado)
                               select proj).ToList().Count != 0;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsPaisUsado(int id)
        {
            try
            {
                if (_context.ProyectoPais.Any(p => p.PaisId == id))
                {
                    return (from pp in _context.ProyectoPais
                               join proj in _context.Proyecto on pp.Proyecto equals proj
                               join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                               where pp.PaisId == id &&
                                     OnUsedProjectStatus.Contains(st.TipoEstado)
                               select proj).ToList().Count != 0;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsFuenteUsado(int id)
        {
            try
            {
                return (from proj in _context.Proyecto
                           join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                           join plan in _context.PlanMonitoreoEvaluacion on proj equals plan.Proyecto
                           join f in _context.FuenteDato on plan.FuenteDato equals f
                           where f.Id == id &&
                                 OnUsedProjectStatus.Contains(st.TipoEstado)
                           select plan).ToList().Count != 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsNivelUsado(int id)
        {
            try
            {
                return (from proj in _context.Proyecto
                           join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                           join plan in _context.PlanMonitoreoEvaluacion on proj equals plan.Proyecto
                           join n in _context.NivelImpacto on plan.NivelImpacto equals n
                           where n.Id == id &&
                                 OnUsedProjectStatus.Contains(st.TipoEstado)
                           select plan).ToList().Count != 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsDesagregadoUsado(int id)
        {
            try
            {
                if (_context.PlanDesagregacion.Any(d => d.DesagregacionId == id))
                {
                    return (from pd in _context.PlanDesagregacion
                               join plan in _context.PlanMonitoreoEvaluacion on pd.PlanMonitoreoEvaluacion equals plan
                               join proj in _context.Proyecto on plan.Proyecto equals proj
                               join st in _context.EstadoProyecto on proj.EstadoProyecto equals st
                               where pd.DesagregacionId == id &&
                                     OnUsedProjectStatus.Contains(st.TipoEstado)
                               select plan).ToList().Count != 0;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsProyectoUsado(string id)
        {
            try
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsActividadPTUsado(int id)
        {
            try
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool IsUsuarioUsado(string id)
        {
            try
            {
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}