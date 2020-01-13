using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
    public class EntidadActualizableValidacionController : ControllerBase
    {

        private readonly IEntidadActualizableValidacionService _service;

        public EntidadActualizableValidacionController(IEntidadActualizableValidacionService service)
        {
            _service = service;
        }

        [HttpGet("validacion/producto/{id}/identificador/{identifier}")]
        public IActionResult ValidarProducto(int id, string identifier)
        {
            return Ok(_service.IsProductoActualizable(id, identifier));
        }

        [HttpGet("validacion/proyecto/{id}/identificador/{identifier}")]
        public IActionResult ValidarProyecto(string id, string identifier)
        {
            return Ok(_service.IsProyectoActualizable(id, identifier));
        }

        [HttpGet("validacion/actividadPT/{id}/identificador/{identifier}")]
        public IActionResult ValidarActividadPT(int id, string identifier)
        {
            return Ok(_service.IsActividadPTActualizable(id, identifier));
        }

        [HttpGet("validacion/objetivo/{id}/identificador/{identifier}")]
        public IActionResult ValidarObjetivo(int id, string identifier)
        { 
            return Ok(_service.IsObjetivoActualizable(id, identifier));
        }

        [HttpGet("validacion/resultado/{id}/identificador/{identifier}")]
        public IActionResult ValidarResultado(int id, string identifier)
        {
            return Ok(_service.IsResultadoActualizable(id, identifier));
        }

        [HttpGet("validacion/actividad/{id}/identificador/{identifier}")]
        public IActionResult ValidarActividad(int id, string identifier)
        {
            return Ok(_service.IsActividadActualizable(id, identifier));
        }

        [HttpGet("validacion/indicador/{id}/identificador/{identifier}")]
        public IActionResult ValidarIndicador(int id, string identifier)
        {
            return Ok(_service.IsIndicadorActualizable(id, identifier));
        }

        [HttpGet("validacion/organizacion/{id}/identificador/{identifier}")]
        public IActionResult ValidarOrganizacion(int id, string identifier)
        {
            return Ok(_service.IsOrganizacionActualizable(id, identifier));
        }

        [HttpGet("validacion/socio/{id}/identificador/{identifier}")]
        public IActionResult ValidarSocio(int id, string identifier)
        {
            return Ok(_service.IsSocioActualizable(id, identifier));
        }

        [HttpGet("validacion/pais/{id}/identificador/{identifier}")]
        public IActionResult ValidarPais(int id, string identifier)
        {
            return Ok(_service.IsPaisActualizable(id, identifier));
        }

        [HttpGet("validacion/fuente/{id}/identificador/{identifier}")]
        public IActionResult ValidarFuente(int id, string identifier)
        {
            return Ok(_service.IsFuenteActualizable(id, identifier));
        }

        [HttpGet("validacion/nivel/{id}/identificador/{identifier}")]
        public IActionResult ValidarNivel(int id, string identifier)
        {
            return Ok(_service.IsNivelActualizable(id, identifier));
        }

        [HttpGet("validacion/desagregado/{id}/identificador/{identifier}")]
        public IActionResult ValidarDesagregado(int id, string identifier)
        {
            return Ok(_service.IsDesagregadoActualizable(id, identifier));
        }

        [HttpGet("validacion/usuario/{id}/identificador/{identifier}")]
        public IActionResult ValidarUsuario(string id, string identifier)
        {
            return Ok(_service.IsUsuarioActualizable(id, identifier));
        }
    }
}