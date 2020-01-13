using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
    public class EntidadUtilizadaValidacionController : ControllerBase
    {

        private readonly IEntidadUtilizadaValidacionService _service;

        public EntidadUtilizadaValidacionController(IEntidadUtilizadaValidacionService service)
        {
            _service = service;
        }

        [HttpGet("/actividad/producto/used/{id}")]
        public IActionResult ValidarProducto(int id)
        {
            return Ok(_service.IsProductoUsado(id));
        }

        [HttpGet("/objetivo/used/{id}")]
        public IActionResult ValidarObjetivo(int id)
        {
            return Ok(_service.IsObjetivoUsado(id));
        }

        [HttpGet("/resultado/used/{id}")]
        public IActionResult ValidarResultados(int id)
        {
            return Ok(_service.IsResultadoUsado(id));
        }

        [HttpGet("/actividad/used/{id}")]
        public IActionResult ValidarActividad(int id)
        {
            return Ok(_service.IsActividadUsado(id));
        }

        [HttpGet("/indicador/used/{id}")]
        public IActionResult ValidarIndicador(int id)
        {
            return Ok(_service.IsIndicadorUsado(id));
        }

        [HttpGet("/organizacion-responsable/used/{id}")]
        public IActionResult ValidarOrganzacion(int id)
        {
            return Ok(_service.IsOrganizacionUsado(id));
        }

        [HttpGet("/socio-internacional/used/{id}")]
        public IActionResult ValidarSocio(int id)
        {
            return Ok(_service.IsSocioUsado(id));
        }

        [HttpGet("/pais/used/{id}")]
        public IActionResult ValidarPais(int id)
        {
            return Ok(_service.IsPaisUsado(id));
        }

        [HttpGet("/fuente-dato/used/{id}")]
        public IActionResult ValidarFuente(int id)
        {
            return Ok(_service.IsFuenteUsado(id));
        }

        [HttpGet("/nivel-impacto/used/{id}")]
        public IActionResult ValidarNivel(int id)
        {
            return Ok(_service.IsNivelUsado(id));
        }

        [HttpGet("/desagregacion/used/{id}")]
        public IActionResult ValidarDesagregado(int id)
        {
            return Ok(_service.IsDesagregadoUsado(id));
        }

        [HttpGet("/proyecto/used/{id}")]
        public IActionResult ValidarProyecto(string id)
        {
            return Ok(_service.IsProyectoUsado(id));
        }

        [HttpGet("/plan-trabajo/actividad/used/{id}")]
        public IActionResult ValidarActividadPT(int id)
        {
            return Ok(_service.IsActividadPTUsado(id));
        }

        [HttpGet("/usuario/used/{id}")]
        public IActionResult ValidarUsuario(string id)
        {
            return Ok(_service.IsUsuarioUsado(id));
        }
    }
}