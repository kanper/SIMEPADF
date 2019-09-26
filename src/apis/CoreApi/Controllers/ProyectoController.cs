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

        [HttpGet("proyecto/estado/{estado}")]
        public IActionResult GetAll(string estado)
        {
            return Ok(_service.GetAll(estado));
        }

        [HttpPost("proyecto")]
        public IActionResult Post([FromBody]ProyectoDTO model)
        {           
            return Ok(_service.Add(model, "INCOMPLETO"));
        }
        
        [HttpPost("proyecto/estado/{estadoInicial}")]
        public IActionResult PostBy([FromBody]ProyectoDTO model, string estadoInicial)
        {           
            return Ok(_service.Add(model, estadoInicial));
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

        [HttpGet("proyecto/{id}/estado/{status}")]
        public IActionResult ChangeStatus(string id, string status)
        {
            return Ok(_service.ChangeStatus(id, status));
        }                
        
    }
}