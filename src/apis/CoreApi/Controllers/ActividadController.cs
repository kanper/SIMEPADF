using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;

namespace CoreApi.Controllers
{
    public class ActividadController :ControllerBase
    {

        private readonly IActividadService _service;

        public ActividadController(IActividadService service)
        {
            _service = service;
        }

        [HttpGet("actividad/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("actividad")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("resultado/{id}/actividades")]
        public IActionResult GetAll(int id)
        {           
            return Ok(_service.GetAll(id));
        }

        [HttpPost("resultado/{id}/actividad")]
        public IActionResult Post([FromBody]ActividadDTO model, int id)
        {
            return Ok(_service.Add(model, id));
        }

        [HttpPut("actividad/{id}")]
        public IActionResult Put([FromBody] ActividadDTO model, int id)
        {
            return Ok(_service.Update(model, id));
        }

        [HttpDelete("actividad/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
        
    }
}