using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class ProyectoHelperController : ControllerBase
    {

        private readonly IProyectoHelperService _service;

        public ProyectoHelperController(IProyectoHelperService service)
        {
            _service = service;
        }

        [HttpGet("proyecto/helper/pais")]
        public IActionResult PaisMap()
        {
            return Ok(_service.GetPaisMap());
        }

        [HttpGet("proyecto/helper/organizacion")]
        public IActionResult OrganizacionMap()
        {
            return Ok(_service.GetOrganizacionMap());
        }

        [HttpGet("proyecto/helper/socio")]
        public IActionResult SocioMap()
        {
            return Ok(_service.GetSocioMap());
        }

        [HttpGet("proyecto/helper/estado")]
        public IActionResult EstadoMap()
        {
            return Ok(_service.GetEstadoMap());
        }

        [HttpGet("proyecto/{id}/helper/indicador")]
        public IActionResult IndicadoresList(string id)
        {
            return Ok(_service.GetIndicadores(id));
        }

        [HttpGet("proyecto/helper/indicador")]
        public IActionResult IndicadoresList()
        {
            return Ok(_service.GetIndicadores());
        }
    
        [HttpGet("proyecto/helper/fuente")]
        public IActionResult FuenteMap()
        {
            return Ok(_service.GetFuenteMap());
        }

        [HttpGet("proyecto/helper/frecuencia")]
        public IActionResult FrecuenciaMap()
        {
            return Ok(_service.GetFrecuenciaMap());
        }

        [HttpGet("proyecto/helper/nivel")]
        public IActionResult NivelMap()
        {
            return Ok(_service.GetNivelMap());
        }

        [HttpGet("proyecto/helper/desagregacion")]
        public IActionResult DesagregacionMap()
        {
            return Ok(_service.GetDesagregacionMap());
        }
    }
}