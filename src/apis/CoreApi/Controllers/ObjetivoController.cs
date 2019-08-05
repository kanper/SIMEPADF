using Microsoft.AspNetCore.Mvc;
using Model.Domain;
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

        [HttpGet("objetivo/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpPost("objetivo")]
        public IActionResult Post([FromBody] Objetivo model)
        {           
            return Ok(_service.Add(model));
        }

        [HttpPut("objetivo/{id}")]
        public IActionResult Put([FromBody] Objetivo model)
        {
            return Ok(_service.Update(model));
        }
        
        [HttpDelete("objetivo-{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}
