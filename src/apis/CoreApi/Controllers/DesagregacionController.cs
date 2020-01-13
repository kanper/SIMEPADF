using DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
    public class DesagregacionController : ControllerBase
    {

        private readonly IDesagregacionService _service;

        public DesagregacionController(IDesagregacionService service)
        {
            _service = service;
        }

        [HttpGet("desagregacion/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("desagregacion")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost("desagregacion")]
        public IActionResult Post([FromBody] DesagregacionDTO model)
        {
            return Ok(_service.Add(model));
        }

        [HttpPut("desagregacion/{id}")]
        public IActionResult Put([FromBody] DesagregacionDTO model, int id)
        {
            return Ok(_service.Update(model, id));
        }

        [HttpDelete("desagregacion/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}