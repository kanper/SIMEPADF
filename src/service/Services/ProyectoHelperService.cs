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
        IEnumerable<MapDTO> GetOrganizacionMap();
        IEnumerable<MapDTO> GetSocioMap();
        IEnumerable<MapDTO> GetEstadoMap();
        IEnumerable<MapingDTO> GetRolMap();
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
    }
}