using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoService _service;

        public ProyectoController(IProyectoService service)
        {
            _service = service;
        }

        [HttpGet("proyecto/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("proyecto")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost("proyecto")]
        public IActionResult Post([FromBody]ProyectoDTO model)
        {
            return Ok(_service.Add(model));
        }

        [HttpPut("proyecto/{id}")]
        public IActionResult Put([FromBody]ProyectoDTO model, string id)
        {
            return Ok(_service.Update(model, id));
        }

        [HttpDelete("proyecto/{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(_service.Delete(id));
        }
        
        
        
    }
}