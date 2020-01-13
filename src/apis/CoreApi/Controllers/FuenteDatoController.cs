using DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
    public class FuenteDatoController : ControllerBase
    {
        private readonly IFuenteDatoService _service;

        public FuenteDatoController(IFuenteDatoService service)
        {
            _service = service;
        }

        [HttpGet("fuente-dato/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("fuente-dato")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost("fuente-dato")]
        public IActionResult Post([FromBody] FuenteDatoDTO model)
        {
            return Ok(_service.Add(model));
        }

        [HttpPut("fuente-dato/{id}")]
        public IActionResult Put([FromBody] FuenteDatoDTO model, int id)
        {
            return Ok(_service.Update(model, id));
        }

        [HttpDelete("fuente-dato/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}