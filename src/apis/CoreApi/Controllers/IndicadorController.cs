using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;

namespace CoreApi.Controllers
{
    public class IndicadorController : ControllerBase
    {

        private readonly IIndicadorService _service;

        public IndicadorController(IIndicadorService service)
        {
            _service = service;
        }

        [HttpGet("indicador/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("indicador")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }      

        [HttpPut("indicador/{id}")]
        public IActionResult Put([FromBody]IndicadorDTO model, int id)
        {
            return Ok(_service.Update(model, id));
        }

        [HttpDelete("indicador/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}