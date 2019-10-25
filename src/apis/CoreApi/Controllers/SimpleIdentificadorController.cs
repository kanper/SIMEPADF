using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class SimpleIdentificadorController: ControllerBase
    {
        private readonly ISimpleIdentificadorService _service;

        public SimpleIdentificadorController(ISimpleIdentificadorService service)
        {
            _service = service;
        }

        [HttpGet("identificador/proyecto/{id}")]
        public IActionResult GetNombreProyecto(string id)
        {
            return Ok(_service.GetMapProyecto(id));
        }

        [HttpGet("identificador/actividad-pt/{id}")]
        public IActionResult GetNombreActividadPt(int id)
        {
            return Ok(_service.GetMapActividadPT(id));
        }
    }
}