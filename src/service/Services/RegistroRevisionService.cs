using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;

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
                var result = new List<RegistroRevisionDTO>();
                var q = (from proy in _context.Proyecto
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
                foreach (var item in q)
                {
                    if (item.Numero == 3)
                    {
                        var copy = result.Find(r => r.Numero == item.Numero);
                        if (copy == null)
                        {
                            result.Add(item);
                        }
                        else
                        {
                            var indexOf = result.IndexOf(copy);
                            copy.Pais = copy.Pais + ", " + item.Pais;
                            result[indexOf] = copy;
                        }
                    }
                    else
                    {
                        result.Add(item);
                    }
                }
                return result.OrderBy(r => r.Trimestre).ThenBy(r => r.Numero);
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

        private string GetCountryNamesByReviewNumber(string id)
        {
            return string.Join(", ",(from pp in _context.ProyectoPais
                join p in _context.Pais on pp.Pais equals p
                where pp.ProyectoId == id
                select p.NombrePais).ToArray());
        }
    }
}