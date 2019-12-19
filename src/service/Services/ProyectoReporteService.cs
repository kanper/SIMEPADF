using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;

namespace Services
{
    public interface IProyectoReporteService
    {
        IEnumerable<ProyectoReporteDTO> GetAll(int year, int quarter, string countries, string socios);
    }
    
    public class ProyectoReporteService : IProyectoReporteService
    {

        private readonly simepadfContext _context;

        public ProyectoReporteService(simepadfContext context)
        {
            _context = context;
        }

        public IEnumerable<ProyectoReporteDTO> GetAll(int year, int quarter, string countries, string socios)
        {
            try
            {
                return (from proy in _context.Proyecto
                    join st in _context.EstadoProyecto on proy.EstadoProyecto equals st 
                    select new ProyectoReporteDTO()
                    {
                        Id = proy.CodigoProyecto,
                        NombreProyecto = proy.NombreProyecto,
                        Estado = st.TipoEstado
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProyectoReporteDTO>();
            }
        }
    }
}