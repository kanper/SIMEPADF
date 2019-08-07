using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class ResultadoController : ControllerBase
    {
        private readonly IResultadoService _service;
        
        public ResultadoController(IResultadoService service)
        {
            _service = service;
        }
        
        [HttpGet("resultado")]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("resultado/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpPost("objetivo/{id}/resultados")]
        public IActionResult Post([FromBody] ResultadoDTO model, int id)
        {
            return Ok(_service.Add(model,id));
        }

        [HttpPut("resultado/{id}")]
        public IActionResult Put([FromBody] ResultadoDTO model, int id)
        {
            return Ok(_service.Update(model, id));
        }

        [HttpDelete("resultado/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}