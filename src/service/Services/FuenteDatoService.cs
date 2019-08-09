using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Model.Domain;

namespace Services
{
    public interface IFuenteDatoService
    {
        FuenteDatoDTO Get(int id);
        IEnumerable<FuenteDatoDTO> GetAll();
        bool Add(FuenteDatoDTO model);
        bool Update(FuenteDatoDTO model, int id);
        bool Delete(int id);
    }
    
    public class FuenteDatoService : IFuenteDatoService
    {

        private readonly simepadfContext _context;

        public FuenteDatoService(simepadfContext context)
        {
            _context = context;
        }

        public FuenteDatoDTO Get(int id)
        {
            try
            {
                return (from f in _context.FuenteDato
                    where f.Id == id
                    select new FuenteDatoDTO()
                    {
                        Id = f.Id,
                        NombreFuente = f.NombreFuente
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<FuenteDatoDTO> GetAll()
        {
            try
            {
                return (from f in _context.FuenteDato                    
                    select new FuenteDatoDTO()
                    {
                        Id = f.Id,
                        NombreFuente = f.NombreFuente
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<FuenteDatoDTO>();
            }
        }

        public bool Add(FuenteDatoDTO model)
        {
            try
            {
                _context.FuenteDato.Add(new FuenteDato(model.NombreFuente));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Update(FuenteDatoDTO model, int id)
        {
            try
            {
                var fuenteDato = _context.FuenteDato.Single(f => f.Id == id);
                fuenteDato.NombreFuente = model.NombreFuente;
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
                _context.FuenteDato.Single(f => f.Id == id).Deleted = true;
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