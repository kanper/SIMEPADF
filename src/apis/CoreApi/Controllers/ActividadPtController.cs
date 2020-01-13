using DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
    public class ActividadPtController : ControllerBase
    {

        private readonly IActividadPtService _service;

        public ActividadPtController(IActividadPtService service)
        {
            _service = service;
        }

        [HttpGet("plan-trabajo/actividad/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }
        
        [HttpGet("plan-trabajo/actividad")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("plan-trabajo/{idPlan}/actividad")]
        public IActionResult GetAll(string idPlan)
        {
            return Ok(_service.GetAll(idPlan));
        }

        [HttpPost("plan-trabajo/{idPlan}/actividad")]
        public IActionResult Post(string idPlan, [FromBody] ActividadPtDTO model)
        {
            return Ok(_service.Add(model, idPlan));
        }

        [HttpPut("plan-trabajo/actividad/{id}")]
        public IActionResult Put(int id, [FromBody] ActividadPtDTO model)
        {
            return Ok(_service.Update(model, id));
        }

        [HttpDelete("plan-trabajo/actividad/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}