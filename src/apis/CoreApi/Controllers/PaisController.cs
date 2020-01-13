using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _service;

        public PaisController(IPaisService service)
        {
            _service = service;
        }
        
        [HttpGet("pais")]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        
        [HttpGet("pais/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }
        
        [HttpPost("pais")]
        public IActionResult Post([FromBody] Pais model)
        {
            return Ok(_service.Add(model));
        }
        
        [HttpPut("pais/{id}")]
        public IActionResult Put([FromBody] Pais model)
        {
            return Ok(_service.Update(model));
        }
        
        [HttpDelete("pais/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}
