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
                    where proy.CodigoProyecto == id && e.TipoEstado == status && r.RevisionCompleta == false
                    select new RegistroRevisionDTO()
                    {
                        Pais = p.NombrePais,
                        Revisado = r.Revisado,
                        Fecha = r.FechaRevisado,
                        Numero = r.NumeroRevision,
                        Trimestre = r.Trimestre
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<RegistroRevisionDTO>();
            }
        }
    }
}