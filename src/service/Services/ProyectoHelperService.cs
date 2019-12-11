using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;

namespace Services
{
    public interface IProyectoHelperService
    {
        IEnumerable<MapDTO> GetPaisMap();
        IEnumerable<MapDTO> GetPaisMap(string proyectoId);
        IEnumerable<MapDTO> GetOrganizacionMap();
        IEnumerable<MapDTO> GetSocioMap();
        IEnumerable<MapDTO> GetEstadoMap();
        IEnumerable<MapingDTO> GetRolMap();
        IEnumerable<IndicadorDTO> GetIndicadores();
        IEnumerable<IndicadorDTO> GetIndicadores(string proyectoId);
        IEnumerable<MapDTO> GetFuenteMap();
        IEnumerable<MapDTO> GetFrecuenciaMap();
        IEnumerable<MapDTO> GetNivelMap();
        IEnumerable<MapDTO> GetDesagregacionMap();
    }
    
    public class ProyectoHelperService : IProyectoHelperService
    {

        private readonly simepadfContext _context;

        public ProyectoHelperService(simepadfContext context)
        {
            _context = context;
        }

        public IEnumerable<MapDTO> GetPaisMap()
        {
            try
            {
                return (from p in _context.Pais
                    select new MapDTO()
                    {
                        Id = p.Id,
                        Nombre = p.NombrePais
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapDTO>();
            }
        }

        public IEnumerable<MapDTO> GetPaisMap(string proyectoId)
        {
            try
            {
                return (from p in _context.Pais
                        join pa in _context.ProyectoPais
                            on p equals pa.Pais
                            where pa.ProyectoId == proyectoId
                        select new MapDTO()
                        {
                            Id = p.Id,
                            Nombre = p.NombrePais
                        }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapDTO>();
            }
        }

        public IEnumerable<MapDTO> GetOrganizacionMap()
        {
            try
            {
                return (from o in _context.OrganizacionResponsable
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

        public IEnumerable<MapDTO> GetSocioMap()
        {
            try
            {
                return (from s in _context.SocioInternacional
                    select new MapDTO()
                    {
                        Id = s.Id,
                        Nombre = s.NombreSocio
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapDTO>();
            }
        }

        public IEnumerable<MapDTO> GetEstadoMap()
        {
            try
            {
                return (from e in _context.EstadoProyecto
                    select new MapDTO()
                    {
                        Id = e.Id,
                        Nombre = e.TipoEstado
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapDTO>();
            }
        }

        public IEnumerable<MapingDTO> GetRolMap()
        {
            try
            {
                return (from r in _context.Rol
                        select new MapingDTO()
                        {
                            Id = r.Id,
                            Nombre = r.Name
                        }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapingDTO>();
            }
        }

        public IEnumerable<IndicadorDTO> GetIndicadores()
        {
            try
            {
                return (from o in _context.Objetivo
                    join r in _context.Resultado on o equals r.Objetivo
                    join a in _context.Actividad on r equals a.Resultado
                    join i in _context.Indicador on a equals i.Actividad
                    join m in _context.Meta on i equals m.Indicador
                    select new IndicadorDTO()
                    {
                        Id = i.CodigoIndicador,
                        NombreIndicador = i.NombreIndicador,
                        NombreActividad = a.NombreActividad,
                        NombreResultado = r.NombreResultado,
                        NombreObjetivo = o.NombreObjetivo,
                        TipoBeneficiario = i.TipoBeneficiario
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<IndicadorDTO>();
            }
        }

        public IEnumerable<IndicadorDTO> GetIndicadores(string proyectoId)
        {
            try
            {
                var all = (from o in _context.Objetivo
                    join r in _context.Resultado on o equals r.Objetivo
                    join a in _context.Actividad on r equals a.Resultado
                    join i in _context.Indicador on a equals i.Actividad
                    join m in _context.Meta on i equals m.Indicador
                    
                    select new IndicadorDTO()
                    {
                        Id = i.CodigoIndicador,
                        NombreIndicador = i.NombreIndicador,
                        NombreActividad = a.NombreActividad,
                        NombreResultado = r.NombreResultado,
                        NombreObjetivo = o.NombreObjetivo,
                        TipoBeneficiario = i.TipoBeneficiario
                    }).ToList();
                var included = (from plan in _context.PlanMonitoreoEvaluacion
                    where plan.ProyectoCodigoProyecto == proyectoId
                    select plan.IndicadorId).ToArray();
                foreach (var id in included)
                {
                    var item = all.SingleOrDefault(i => i.Id == id);
                    if (item != null)
                    {
                        all.Remove(item);
                    }
                }

                return all;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<IndicadorDTO>();
            }
        }       

        public IEnumerable<MapDTO> GetFuenteMap()
        {
            try
            {
                return (from f in _context.FuenteDato
                    select new MapDTO()
                    {
                        Id = f.Id,
                        Nombre = f.NombreFuente
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapDTO>();
            }
        }

        public IEnumerable<MapDTO> GetFrecuenciaMap()
        {
            try
            {
                return (from f in _context.FrecuenciaMedicion
                    select new MapDTO()
                    {
                        Id = f.Id,
                        Nombre = f.NombreFrecuencia
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapDTO>();
            }
        }

        public IEnumerable<MapDTO> GetNivelMap()
        {
            try
            {
                return (from n in _context.NivelImpacto
                    select new MapDTO()
                    {
                        Id = n.Id,
                        Nombre = n.NombreNivelImpacto
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapDTO>();
            }
        }

        public IEnumerable<MapDTO> GetDesagregacionMap()
        {
            try
            {
                return (from d in _context.Desagregacion
                    select new MapDTO()
                    {
                        Id = d.Id,
                        Nombre = d.TipoDesagregacion
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapDTO>();
            }
        }
    }
}