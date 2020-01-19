using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;

namespace Services
{
    public interface IRegistroAprobacionService
    {
        ICollection<RegistroAprobadoDTO> GetAll(string proyectoId);
    }
    
    public class RegistroAprobacionService : IRegistroAprobacionService
    {
        private readonly simepadfContext _context;

        public RegistroAprobacionService(simepadfContext context)
        {
            _context = context;
        }

        public ICollection<RegistroAprobadoDTO> GetAll(string proyectoId)
        {
            try
            {
                return (from pp in _context.ProyectoPais
                    join p in _context.Pais on pp.Pais equals p
                    where pp.ProyectoId == proyectoId
                    select new RegistroAprobadoDTO()
                    {
                        CodigoProyecto = pp.ProyectoId,
                        Aprobado = pp.Aprobado,
                        Fecha = pp.FechaAprobado,
                        CodigoPais = p.Id,
                        NombrePais = p.NombrePais
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<RegistroAprobadoDTO>();
            }
        }
    }
}