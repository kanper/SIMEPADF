using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class PlanMonitoreoEvaluacionController : ControllerBase
    {

        private readonly IPlanMonitoreoEvaluacionService _service;

        public PlanMonitoreoEvaluacionController(IPlanMonitoreoEvaluacionService service)
        {
            _service = service;
        }

        [HttpGet("proyecto/{proyectoId}/indicador/{indicadorId}")]
        public IActionResult Get(string proyectoId, int indicadorId)
        {
            return Ok(_service.Get(proyectoId, indicadorId));
        }

        [HttpGet("proyecto/{proyectoId}/indicador")]
        public IActionResult GetAll(string proyectoId)
        {
            return Ok(_service.GetAll(proyectoId));
        }

        [HttpPost("proyecto/{proyectoId}/indicador")]
        public IActionResult Post([FromBody] IndicadorDTO[] model, string proyectoId)
        {
            return Ok(_service.Add(model, proyectoId));
        }

        [HttpPut("proyecto/{proyectoId}/indicador/{indicadorId}")]
        public IActionResult Put([FromBody] PlanMEDTO model)
        {
            return Ok(_service.Update(model));
        }

        [HttpDelete("proyecto/{proyectoId}/indicador/{indicadorId}")]
        public IActionResult Delete(string proyectoId, int indicadorId)
        {
            return Ok(_service.Delete(proyectoId, indicadorId));
        }
    }
}