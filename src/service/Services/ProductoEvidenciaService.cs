using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Model.Domain;

namespace Services
{
    public interface IProductoEvidenciaService
    {
        ProductoEvidenciaDTO Get(int id);
        IEnumerable<ProductoEvidenciaDTO> GetAll(int id);
        bool Upload(int id);
        bool Download(int id);
        bool Delete(int id);
    }
    
    public class ProductoEvidenciaService : IProductoEvidenciaService
    {
        private readonly simepadfContext _context;

        public ProductoEvidenciaService(simepadfContext context)
        {
            _context = context;
        }

        public ProductoEvidenciaDTO Get(int id)
        {
            try
            {
                return (from p in _context.Producto
                    join fl in _context.ArchivoDescripcion on p equals fl.Producto 
                    where p.codigoProducto == id
                    select new ProductoEvidenciaDTO()
                    {
                        Id = p.codigoProducto,
                        NombreProducto = p.NombreProducto,
                        ArchivoAdjunto = true,
                        NombreArchivo = fl.NombreArchivo,
                        TamanioArchivo = fl.TamanioArchivo,
                        TipoArchivo = fl.TipoContenido,
                        DescripcionArchivo = fl.Descripcion
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public IEnumerable<ProductoEvidenciaDTO> GetAll(int id)
        {
            try
            {
                return (from p in _context.Producto
                    where p.ActividadPTId == id
                    select new ProductoEvidenciaDTO()
                    {
                        Id = p.codigoProducto,
                        NombreProducto = p.NombreProducto,
                        ArchivoAdjunto = (from fl in _context.ArchivoDescripcion
                            where fl.CodigoArchivo == p.codigoProducto
                            select fl).Any()
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProductoEvidenciaDTO>();
            }
        }

        public bool Upload(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Download(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            try
            {
                var file = _context.ArchivoDescripcion.Single(f => f.CodigoArchivo == id);
                _context.Remove(file);
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