using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
    public class EntidadUnicaValidacionController: ControllerBase
    {
        private readonly IEntidadUnicaValidacionService _service;

        public EntidadUnicaValidacionController(IEntidadUnicaValidacionService service)
        {
            _service = service;
        }

        [HttpGet("validacion/objetivo/{identificador}")]
        public IActionResult IsObjetivoUnico(string identificador)
        {
            return Ok(_service.IsObjetivoUnico(identificador));
        }

        [HttpGet("validacion/resultado/{identificador}")]
        public IActionResult IsResultadoUnico(string identificador)
        {
            return Ok(_service.IsResultadoUnico(identificador));
        }

        [HttpGet("validacion/actividad/{identificador}")]
        public IActionResult IsActividadUnico(string identificador)
        {
            return Ok(_service.IsActividadUnico(identificador));
        }

        [HttpGet("validacion/indicador/{identificador}")]
        public IActionResult IsIndicadorUnico(string identificador)
        {
            return Ok(_service.IsIndicadorUnico(identificador));
        }

        [HttpGet("validacion/organizacion/{identificador}")]
        public IActionResult IsOrganizacionUnico(string identificador)
        {
            return Ok(_service.IsOrganizacionUnico(identificador));
        }

        [HttpGet("validacion/socio/{identificador}")]
        public IActionResult IsSocioUnico(string identificador)
        {
            return Ok(_service.IsSocioUnico(identificador));
        }

        [HttpGet("validacion/pais/{identificador}")]
        public IActionResult IsPaisUnico(string identificador)
        {
            return Ok(_service.IsPaisUnico(identificador));
        }

        [HttpGet("validacion/fuente/{identificador}")]
        public IActionResult IsFuenteUnico(string identificador)
        {
            return Ok(_service.IsFuenteUnico(identificador));
        }

        [HttpGet("validacion/nivel/{identificador}")]
        public IActionResult IsNivelUnico(string identificador)
        {
            return Ok(_service.IsNivelUnico(identificador));
        }

        [HttpGet("validacion/desagregado/{identificador}")]
        public IActionResult IsDesagregadoUnico(string identificador)
        {
            return Ok(_service.IsDesagregadoUnico(identificador));
        }

        [HttpGet("validacion/proyecto/{identificador}")]
        public IActionResult IsProyectoUnico(string identificador)
        {
            return Ok(_service.IsProyectoUnico(identificador));
        }

        [HttpGet("validacion/actividadPT/{identificador}")]
        public IActionResult IsActividadPTUnico(string identificador)
        {
            return Ok(_service.IsPlanPTUnico(identificador));
        }
        
        [HttpGet("validacion/producto/{identificador}")]
        public IActionResult IsProductoUnico(string identificador)
        {
            return Ok(_service.IsProductoUnico(identificador));
        }

        [HttpGet("validacion/usuario/{identificador}")]
        public IActionResult IsUsuarioUnico(string identificador)
        {
            return Ok(_service.IsUsuarioUnico(identificador));
        }
    }
}