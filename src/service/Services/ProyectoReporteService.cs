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

        public IEnumerable<ProyectoReporteDTO> GetAll(int year, int quarter, string countries, string socios)
        {
            try
            {
                var processStatus = new[] {"EN_PROCESO","1REVISION","2REVISION","3REVISION"};
                return (from proy in _context.Proyecto
                    join st in _context.EstadoProyecto on proy.EstadoProyecto equals st
                    where processStatus.Contains(st.TipoEstado) 
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
                                      }).ToArray()
                    }).Single();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}