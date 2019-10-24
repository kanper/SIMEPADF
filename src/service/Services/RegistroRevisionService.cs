using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;

namespace Services
{

    public interface IRegistroRevisionService
    {
        IEnumerable<RegistroRevisionDTO> GetAll(string id, string status);
        RegistroRevisionDTO Get(string id, string status, string pais);
    }
    
    public class RegistroRevisionService : IRegistroRevisionService
    {
        private readonly simepadfContext _context;

        public RegistroRevisionService(simepadfContext context)
        {
            _context = context;
        }

        public IEnumerable<RegistroRevisionDTO> GetAll(string id, string status)
        {
            try
            {
                return (from proy in _context.Proyecto
                    join pp in _context.ProyectoPais
                        on proy equals pp.Proyecto
                    join e in _context.EstadoProyecto 
                        on proy.EstadoProyecto equals e
                    join p in _context.Pais
                        on pp.Pais equals p
                    join r in _context.RegistroRevision
                        on pp equals r.ProyectoPais
                    where proy.CodigoProyecto == id && e.TipoEstado == status
                    select new RegistroRevisionDTO()
                    {
                        Pais = p.NombrePais,
                        Revisado = r.Revisado,
                        Fecha = r.FechaRevisado,
                        Numero = r.NumeroRevision,
                        Trimestre = r.Trimestre,
                        Retornado = r.Retornado
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<RegistroRevisionDTO>();
            }
        }

        public RegistroRevisionDTO Get(string id, string status, string pais)
        {
            try
            {
                return (from proy in _context.Proyecto
                    join pp in _context.ProyectoPais
                        on proy equals pp.Proyecto
                    join e in _context.EstadoProyecto 
                        on proy.EstadoProyecto equals e
                    join p in _context.Pais
                        on pp.Pais equals p
                    join r in _context.RegistroRevision
                        on pp equals r.ProyectoPais
                    where proy.CodigoProyecto == id &&
                          e.TipoEstado == status &&
                          p.NombrePais == pais
                    select new RegistroRevisionDTO()
                    {
                        Pais = p.NombrePais,
                        Revisado = r.Revisado,
                        Fecha = r.FechaRevisado,
                        Numero = r.NumeroRevision,
                        Trimestre = r.Trimestre,
                        Retornado = r.Retornado,
                        Comentario = r.Comentario
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