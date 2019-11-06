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
                    join fl in _context.ArchivoDescripcion on p equals fl.Producto into FileDescp
                    from des in FileDescp.DefaultIfEmpty()
                    where p.codigoProducto == id
                    select new ProductoEvidenciaDTO()
                    {
                        Id = p.codigoProducto,
                        NombreProducto = p.NombreProducto,
                        NombreArchivo = des == null ? "" : des.NombreReal,
                        TamanioArchivo = des == null ? 0 : des.TamanioArchivo,
                        TipoArchivo = des == null ? "" : des.TipoContenido,
                        DescripcionArchivo = des == null ? "" : des.Descripcion
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
                    join fl in _context.ArchivoDescripcion on p equals fl.Producto into FileDescp
                    from des in FileDescp.DefaultIfEmpty()
                    where p.ActividadPTId == id
                    select new ProductoEvidenciaDTO()
                    {
                        Id = p.codigoProducto,
                        NombreProducto = p.NombreProducto,
                        ArchivoAdjunto = des != null,
                        NombreArchivo = des == null ? "Ningún archivo cargado..." : des.NombreReal,
                        TamanioArchivo = des == null ? 0 : des.TamanioArchivo,
                        TipoArchivo = des == null ? "" : des.TipoContenido,
                        DescripcionArchivo = des == null ? "" : des.Descripcion
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<ProductoEvidenciaDTO>();
            }
        }
    }
}