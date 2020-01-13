using DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
    public class NivelImpactoController : ControllerBase
    {

        private readonly INivelImpactoService _service;

        public NivelImpactoController(INivelImpactoService service)
        {
            _service = service;
        }

        [HttpGet("nivel-impacto/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("nivel-impacto")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost("nivel-impacto")]
        public IActionResult Post([FromBody] NivelImpactoDTO model)
        {
            return Ok(_service.Add(model));
        }

        [HttpPut("nivel-impacto/{id}")]
        public IActionResult Put([FromBody] NivelImpactoDTO model, int id)
        {
            return Ok(_service.Update(model, id));
        }

        [HttpDelete("nivel-impacto/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}