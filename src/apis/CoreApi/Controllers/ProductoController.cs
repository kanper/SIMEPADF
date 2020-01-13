using System.Drawing.Printing;
using DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
    public class ProductoController : ControllerBase
    {

        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet("actividad/producto/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("actividad/producto")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("actividad/{idActividad}/producto")]
        public IActionResult GetAll(int idActividad)
        {
            return Ok(_service.GetAll(idActividad));
        }

        [HttpPost("actividad/{idActividad}/producto")]
        public IActionResult Post(int idActividad, [FromBody]ProductoDTO model)
        {
            return Ok(_service.Add(idActividad, model));
        }

        [HttpPut("actividad/producto/{id}")]
        public IActionResult Put(int id, [FromBody]ProductoDTO model)
        {
            return Ok(_service.Update(id, model));
        }

        [HttpDelete("actividad/producto/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}