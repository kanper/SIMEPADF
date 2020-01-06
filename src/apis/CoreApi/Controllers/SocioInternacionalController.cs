using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;

namespace CoreApi.Controllers
{
    public class SocioInternacionalController : ControllerBase
    {
        private readonly ISocioInternacionalService _service;

        public SocioInternacionalController(ISocioInternacionalService service)
        {
            _service = service;
        }
        
        [HttpGet("socio-internacional")]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        
        [HttpGet("socio-internacional/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }
        
        [HttpPost("socio-internacional")]
        public IActionResult Post([FromBody] SocioInternacional model)
        {
            return Ok(_service.Add(model));
        }
        
        [HttpPut("socio-internacional/{id}")]
        public IActionResult Put([FromBody] SocioInternacional model)
        {
            return Ok(_service.Update(model));
        }
        
        [HttpDelete("socio-internacional/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}
