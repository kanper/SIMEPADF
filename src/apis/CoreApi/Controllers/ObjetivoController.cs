using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivoService _service;

        public ObjetivoController(IObjetivoService objetivoService)
        {
            _service = objetivoService;
        }
        
        [HttpGet("objetivo")]
        public IActionResult Get()
        {            
            return Ok(_service.GetAll());
        }

        [HttpGet("objetivo/{id}/resultados")]
        public IActionResult GetAll(int id)
        {
            return Ok(_service.GetAll(id));
        }

        [HttpGet("objetivo/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpPost("objetivo")]
        public IActionResult Post([FromBody] ObjetivoDTO model)
        {           
            return Ok(_service.Add(model));
        }

        [HttpPut("objetivo/{id}")]
        public IActionResult Put([FromBody] ObjetivoDTO model, int id)
        {
            return Ok(_service.Update(model, id));
        }
        
        [HttpDelete("objetivo/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}
