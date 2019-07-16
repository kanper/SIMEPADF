using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;

namespace CoreApi.Controllers
{
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _PaisService;

        public PaisController(IPaisService PaisService)
        {
            _PaisService = PaisService;
        }

        // GET api/values
        [HttpGet("pais")]
        public IActionResult Get()
        {
            return Ok(
                _PaisService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("pais/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _PaisService.Get(id)
            );
        }

        // POST api/values
        [HttpPost("pais")]
        public IActionResult Post([FromBody] Pais model)
        {
            return Ok(
                _PaisService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut("pais/{id}")]
        public IActionResult Put([FromBody] Pais model)
        {
            return Ok(
                _PaisService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("pais-{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _PaisService.Delete(id)
            );
        }
    }
}
