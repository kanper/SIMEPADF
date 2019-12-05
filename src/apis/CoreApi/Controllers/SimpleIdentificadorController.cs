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

        [HttpGet("identificador/indicador/{id}")]
        public IActionResult GetNombreIndicador(int id)
        {
            return Ok(_service.GetMapIndicador(id));
        }

        [HttpGet("identificador/paises/codigos")]
        public IActionResult GetAllPaisesCodes()
        {
            return Ok(_service.GetAllCountriesCodes());
        }

        [HttpGet("identificador/socios/codigos")]
        public IActionResult GetAllSociosCodes()
        {
            return Ok(_service.GetAllSocioCodes());
        }

        [HttpGet("identificador/desagregados")]
        public IActionResult GetAllDesagregados()
        {
            return Ok(_service.GetAllDesagregados());
        }
    }
}