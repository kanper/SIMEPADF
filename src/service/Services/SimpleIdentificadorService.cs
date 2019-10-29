using System;
using System.Linq;
using DatabaseContext;
using DTO.DTO;

namespace Services
{
    public interface ISimpleIdentificadorService
    {
        MapDTO GetMapProyecto(string id);
        MapDTO GetMapActividadPT(int id);
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
    }
}