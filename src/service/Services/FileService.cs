using System;
using System.IO;
using System.Linq;
using DatabaseContext;
using DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.Configuration;
using Model.Domain;

namespace Services
{

    public interface IFileService
    {
        ArchivoDTO Get(int id);
        Stream Download(int id);
        bool Save(int id, IFormFile file, string descripcion);
        bool Update(int id, ProductoEvidenciaDTO file);
        bool Remove(int id);
    }
    
    public class FileService : IFileService
    {
        private readonly simepadfContext _context;
        private readonly IConfiguration _config;

        public FileService(simepadfContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public ArchivoDTO Get(int id)
        {
            try
            {
                return (from f in _context.ArchivoDescripcion
                    where f.CodigoArchivo == id
                    select new ArchivoDTO()
                    {
                        Id = f.CodigoArchivo,
                        Name = f.NombreReal,
                        Path = f.Path,
                        Description = f.Descripcion,
                        Random = f.NombreArchivo,
                        Size = f.TamanioArchivo,
                        Type = f.TipoContenido
                    }).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Stream Download(int id)
        {
            try
            {
                var archivo = _context.ArchivoDescripcion.Single(f => f.CodigoArchivo == id);
                if (File.Exists(Path.Combine(_config["StoredFilesPath"], archivo.Path)))
                {
                    return File.Open(Path.Combine(_config["StoredFilesPath"], archivo.Path), FileMode.Open);
                }
                throw new FileNotFoundException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool Save(int id, IFormFile file, string descripcion)
        {
            try
            {
                var filePath = Path.Combine(_config["StoredFilesPath"], Path.GetRandomFileName());
                using (var stream = File.Create(filePath))
                {
                    file.CopyToAsync(stream);
                }
                productoEvidencia(id).Archivo = makeDescripcion(file, filePath, descripcion);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Update(int id, ProductoEvidenciaDTO file)
        {
            try
            {
                var archivo = _context.ArchivoDescripcion.Single(f => f.CodigoArchivo == id);
                archivo.Descripcion = file.DescripcionArchivo;
                archivo.NombreReal = file.NombreArchivo;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                var evidencia = _context.ArchivoDescripcion.Single(f => f.CodigoArchivo == id);
                if (File.Exists(evidencia.Path))
                {
                    File.Delete(evidencia.Path);
                }

                _context.ArchivoDescripcion.Remove(evidencia);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private ArchivoDescripcion makeDescripcion(IFormFile file, string path, string descripcion)
        {
            var archivo = new ArchivoDescripcion();
            archivo.NombreReal = Truncate(file.FileName, 250);
            archivo.NombreArchivo = Truncate(Path.GetFileName(path),250);
            archivo.TamanioArchivo = file.Length;
            archivo.TipoContenido = Truncate(Path.GetExtension(file.FileName),10);
            archivo.Path = path;
            archivo.Descripcion = Truncate(descripcion,250);
            return archivo;
        }

        private Producto productoEvidencia(int id)
        {
            return _context.Producto
                .Include(p => p.Archivo)
                .Single(p => p.codigoProducto == id);
        }
        
        private string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength); 
        }
    }
}