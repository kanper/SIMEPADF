using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Model.Domain;

namespace Services
{
    public interface IProductoService
    {
        DTO.DTO.ProductoDTO Get(int id);
        IEnumerable<ProductoDTO> GetAll();       
        IEnumerable<ProductoDTO> GetAll(int idActividad);
        bool Add(int idActividad, ProductoDTO model);
        bool Update(int id, ProductoDTO model);
        bool Delete(int id);
    }
    
    public class ProductoService : IProductoService
    {

        private readonly simepadfContext _context;

        public ProductoService(simepadfContext context)
        {
            _context = context;
        }

        public ProductoDTO Get(int id)
        {
            try
            {
                return (from p in _context.Producto
                    where p.codigoProducto == id
                    select new ProductoDTO()
                    {
                        Id = p.codigoProducto,
                        NombreProducto = p.NombreProducto
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<ProductoDTO> GetAll()
        {
            try
            {
                return (from p in _context.Producto                
                    select new ProductoDTO()
                    {
                        Id = p.codigoProducto,
                        NombreProducto = p.NombreProducto
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProductoDTO>();
            }
        }

        public IEnumerable<ProductoDTO> GetAll(int idActividad)
        {
            try
            {
                return (from p in _context.Producto
                    where p.ActividadPTId == idActividad
                    select new ProductoDTO()
                    {
                        Id = p.codigoProducto,
                        NombreProducto = p.NombreProducto
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProductoDTO>();
            }
        }

        public bool Add(int idActividad, ProductoDTO model)
        {
            try
            {
                _context.ActividadPT
                    .Include(p => p.Productos)
                    .Single(a => a.CodigoActividadPT == idActividad)
                    .AddProducto(new Producto(model.NombreProducto));
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Update(int id, ProductoDTO model)
        {
            try
            {
                var producto = _context.Producto.Single(p => p.codigoProducto == id);
                producto.NombreProducto = model.NombreProducto;
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
                _context.Producto.Single(p => p.codigoProducto == id).Deleted = true;
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