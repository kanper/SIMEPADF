using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

namespace Services
{
    public interface ISimpleIdentificadorService
    {
        MapDTO GetMapProyecto(string id);
        MapDTO GetMapActividadPT(int id);
        MapDTO GetMapIndicador(int id);
        IEnumerable<MapDTO> GetAllCountriesCodes();
        IEnumerable<MapDTO> GetAllSocioCodes();
        IEnumerable<MapDTO> GetAllDesagregados();
    }

    public class SimpleIdentificadorService : ISimpleIdentificadorService
    {
        private readonly simepadfContext _context;

        public SimpleIdentificadorService(simepadfContext context)
        {
            _context = context;
        }

        public MapDTO GetMapProyecto(string id)
        {
            try
            {
                return (from p in _context.Proyecto
                    where p.CodigoProyecto == id
                    select new MapDTO()
                    {
                        Nombre = p.NombreProyecto
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public MapDTO GetMapActividadPT(int id)
        {
            try
            {
                return (from apt in _context.ActividadPT
                    where apt.CodigoActividadPT == id
                    select new MapDTO()
                    {
                        Id = apt.CodigoActividadPT,
                        Nombre = apt.NombreActividad
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public MapDTO GetMapIndicador(int id)
        {
            try
            {
                return (from ind in _context.Indicador
                    where ind.CodigoIndicador == id
                    select new MapDTO()
                    {
                        Id = ind.CodigoIndicador,
                        Nombre = ind.NombreIndicador
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<MapDTO> GetAllCountriesCodes()
        {
            try
            {
                return (from pais in _context.Pais
                    select new MapDTO()
                    {
                        Id = pais.Id,
                        Nombre = pais.SiglaPais
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapDTO>();
            }
        }

        public IEnumerable<MapDTO> GetAllSocioCodes()
        {
            try
            {
                return (from socio in _context.SocioInternacional
                    select new MapDTO()
                    {
                        Id = socio.Id,
                        Nombre = socio.SiglasSocio
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<MapDTO>();
            }
        }

        public IEnumerable<MapDTO> GetAllDesagregados()
        {
            try
            {
                return (from des in _context.Desagregacion
                    select new MapDTO()
                    {
                        Id = des.Id,
                        Nombre = des.TipoDesagregacion
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