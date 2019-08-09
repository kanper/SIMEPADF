using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Model.Domain;

namespace Services
{
    public interface INivelImpactoService
    {
        NivelImpactoDTO Get(int id);
        IEnumerable<NivelImpactoDTO> GetAll();
        bool Add(NivelImpactoDTO model);
        bool Update(NivelImpactoDTO model, int id);
        bool Delete(int id);
    }
    
    public class NivelImpactoService : INivelImpactoService
    {

        private readonly simepadfContext _context;

        public NivelImpactoService(simepadfContext context)
        {
            _context = context;
        }

        public NivelImpactoDTO Get(int id)
        {
            try
            {
                return (from n in _context.NivelImpacto
                    where n.Id == id
                    select new NivelImpactoDTO()
                    {
                        Id = n.Id,
                        NombreNivel = n.NombreNivelImpacto
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<NivelImpactoDTO> GetAll()
        {
            try
            {
                return (from n in _context.NivelImpacto                    
                    select new NivelImpactoDTO()
                    {
                        Id = n.Id,
                        NombreNivel = n.NombreNivelImpacto
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<NivelImpactoDTO>();
            }
        }

        public bool Add(NivelImpactoDTO model)
        {
            try
            {
                _context.NivelImpacto.Add(new NivelImpacto(model.NombreNivel));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Update(NivelImpactoDTO model, int id)
        {
            try
            {
                var nivelImpacto = _context.NivelImpacto.Single(n => n.Id == id);
                nivelImpacto.NombreNivelImpacto = model.NombreNivel;
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
                _context.NivelImpacto.Single(n => n.Id == id).Deleted = true;
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