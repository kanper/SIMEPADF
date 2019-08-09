using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Model.Domain;

namespace Services
{
    public interface IDesagregacionService
    {
        DesagregacionDTO Get(int id);
        IEnumerable<DesagregacionDTO> GetAll();
        bool Add(DesagregacionDTO model);
        bool Update(DesagregacionDTO model, int id);
        bool Delete(int id);
    }
    
    public class DesagregacionService : IDesagregacionService
    {

        private readonly simepadfContext _context;

        public DesagregacionService(simepadfContext context)
        {
            _context = context;
        }

        public DesagregacionDTO Get(int id)
        {
            try
            {
                return (from d in _context.Desagregacion
                    where d.Id == id
                    select new DesagregacionDTO()
                    {
                        Id = d.Id,
                        NombreDesagregacion = d.TipoDesagregacion
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<DesagregacionDTO> GetAll()
        {
            try
            {
                return (from d in _context.Desagregacion                    
                    select new DesagregacionDTO()
                    {
                        Id = d.Id,
                        NombreDesagregacion = d.TipoDesagregacion
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<DesagregacionDTO>();
            }
        }

        public bool Add(DesagregacionDTO model)
        {
            try
            {
                _context.Desagregacion.Add(new Desagregacion(model.NombreDesagregacion));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Update(DesagregacionDTO model, int id)
        {
            try
            {
                var desagregacion = _context.Desagregacion.Single(d => d.Id == id);
                desagregacion.TipoDesagregacion = model.NombreDesagregacion;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _context.Desagregacion.Single(d => d.Id == id).Deleted = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}