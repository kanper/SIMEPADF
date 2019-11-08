using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services;

namespace CoreApi.Controllers
{
    public class ProductoEvidenciaController : ControllerBase
    {

        private readonly IProductoEvidenciaService _service;
        private readonly IFileService _file;

        public ProductoEvidenciaController(IProductoEvidenciaService service, IFileService fileService)
        {
            _service = service;
            _file = fileService;

        }

        [HttpGet("/actividad/{id}/producto/evidencia")]
        public IActionResult GetAll(int id, string country)
        {
            return Ok(_service.GetAll(id));
        }
        
        [HttpGet("/actividad/producto/{id}/evidencia")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }
        
        [HttpGet("/actividad/producto/{id}/archivo/info")]
        public IActionResult GetFile(int id)
        {
            return Ok(_file.Get(id));
        }

        [HttpPost("/actividad/producto/{id}/archivo/upload")]
        public IActionResult Upload([FromForm] IFormFile file, int id)
        {
            return Ok(_file.Save(id, file, ""));
        }

        [HttpGet("/actividad/producto/{id}/archivo/download")]
        public IActionResult Download(int id)
        {
            Stream stream = _file.Download(id);
            if (stream == null)
            {
                return NotFound();
            }
            return File(stream, "application/pdf");
        }
        
        [HttpGet("/actividad/producto/{id}/archivo/download/{fileName}")]
        public IActionResult Download(int id, string fileName)
        {
            Stream stream = _file.Download(id);
            if (stream == null)
            {
                return NotFound();
            }
            return File(stream, "application/pdf", fileName);
        }

        [HttpPut("/actividad/producto/{id}/archivo/update")]
        public IActionResult Update(int id, [FromBody] ProductoEvidenciaDTO dto)
        {
            return Ok(_file.Update(id, dto));
        }
        
        [HttpDelete("/actividad/producto/{id}/archivo/remove")]
        public IActionResult RemoveFile(int id)
        {
            return Ok(_file.Remove(id));
        }
    }
}