using System;
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
    }
}