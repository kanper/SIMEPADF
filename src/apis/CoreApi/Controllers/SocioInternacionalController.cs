using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;

namespace CoreApi.Controllers
{
    public class SocioInternacionalController : ControllerBase
    {
        private readonly ISocioInternacionalService _SocioService;

        public SocioInternacionalController(ISocioInternacionalService SocioService)
        {
            _SocioService = SocioService;
        }

        // GET api/values
        [HttpGet("sociointernacional")]
        public IActionResult Get()
        {
            return Ok(
                _SocioService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("sociointernacional/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _SocioService.Get(id)
            );
        }

        // POST api/values
        [HttpPost("sociointernacional")]
        public IActionResult Post([FromBody] SocioInternacional model)
        {
            return Ok(
                _SocioService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut("sociointernacional/{id}")]
        public IActionResult Put([FromBody] SocioInternacional model)
        {
            return Ok(
                _SocioService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("sociointernacional-{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _SocioService.Delete(id)
            );
        }
    }
}
