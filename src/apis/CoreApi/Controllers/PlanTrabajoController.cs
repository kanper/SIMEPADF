using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class PlanTrabajoController : ControllerBase
    {

        private readonly IPlanTrabajoService _service;

        public PlanTrabajoController(IPlanTrabajoService service)
        {
            _service = service;
        }

        [HttpGet("proyecto/plan-trabajo/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("proyecto/plan-trabajo")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost("proyecto/plan-trabajo/{id}")]
        public IActionResult Post(string id)
        {
            return Ok(_service.Add(id));
        }

        [HttpPut("proyecto/plan-trabajo/{id}")]
        public IActionResult Put(string id, [FromBody] PlanTrabajoDTO model)
        {
            return Ok(_service.Update(model, id));
        }

        [HttpDelete("proyecto/plan-trabajo/{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(_service.Delete(id));
        }
    }
}