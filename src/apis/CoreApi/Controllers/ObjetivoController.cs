using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;

namespace CoreApi.Controllers
{
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivoService _ObjetivoService;

        public ObjetivoController(IObjetivoService ObjetivoService)
        {
            _ObjetivoService = ObjetivoService;
        }

        // GET api/values  [Route("objetivo")]
        [HttpGet("objetivo")]
        public IActionResult Get()
        {
            return Ok(
                _ObjetivoService.GetAll()
            );
        }

        // GET api/values/5 [Route("objetivo/{id}")]
        [HttpGet("objetivo/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _ObjetivoService.Get(id)
            );
        }

        // POST api/values  [Route("objetivo")]
        [HttpPost("objetivo")]
        public IActionResult Post([FromBody] Objetivo model)
        {
            return Ok(
                _ObjetivoService.Add(model)
            );
        }

        // PUT api/values/5  [Route("objetivo/{id}")]
        [HttpPut("objetivo/{id}")]
        public IActionResult Put([FromBody] Objetivo model)
        {
            return Ok(
                _ObjetivoService.Update(model)
            );
        }

        // DELETE api/values/5[Route("objetivo-{id}")]
        [HttpDelete("objetivo-{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _ObjetivoService.Delete(id)
            );
        }
    }
}
