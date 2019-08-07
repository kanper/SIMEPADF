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
        
    }
}