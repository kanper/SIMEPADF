using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;

namespace CoreApi.Controllers
{
    public class RolController : ControllerBase
    {
        private readonly IRolService _RolService;

        public RolController(IRolService RolService)
        {
            _RolService = RolService;
        }

        // GET api/values
        [HttpGet("rol")]
        public IActionResult Get()
        {
            return Ok(
                _RolService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("rol/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(
                _RolService.Get(id)
            );
        }

        // POST api/values
        [HttpPost("rol")]
        public IActionResult Post([FromBody] Rol model)
        {
            return Ok(
                _RolService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut("rol/{id}")]
        public IActionResult Put([FromBody] Rol model)
        {
            return Ok(
                _RolService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("rol-{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(
                _RolService.Delete(id)
            );
        }
    }
}
