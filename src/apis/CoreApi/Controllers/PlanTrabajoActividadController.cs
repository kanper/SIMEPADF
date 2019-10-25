using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class PlanTrabajoActividadController : ControllerBase
    {
        private readonly IPlanTrabajoActividadService _service;

        public PlanTrabajoActividadController(IPlanTrabajoActividadService service)
        {
            _service = service;
        }

        [HttpGet("plan-trabajo/actividad/{id}/evidencia")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("plan-trabajo/{id}/actividad/evidencia")]
        public IActionResult GetAll(string id)
        {
            return Ok(_service.GetAll(id));
        }
    }
}