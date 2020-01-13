using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
    public class EntidadRemovibleValidacionController : ControllerBase
    {

        private readonly IEntidadRemovibleValidacionService _service;

        public EntidadRemovibleValidacionController(IEntidadRemovibleValidacionService service)
        {
            _service = service;
        }

        [HttpGet("organizacion-responsable/removable/{id}")]
        public IActionResult ValidarOrganizacion(int id)
        {
            return Ok(_service.OrganizacionRemovible(id));
        }

        [HttpGet("socio-internacional/removable/{id}")]
        public IActionResult ValidarSocio(int id)
        {
            return Ok(_service.SocioRemovible(id));
        }

        [HttpGet("pais/removable/{id}")]
        public IActionResult ValidarPais(int id)
        {
            return Ok(_service.PaisRemovible(id));
        }

        [HttpGet("fuente-dato/removable/{id}")]
        public IActionResult ValidarFuente(int id)
        {
            return Ok(_service.FuenteRemovible(id));
        }

        [HttpGet("nivel-impacto/removable/{id}")]
        public IActionResult ValidarNivel(int id)
        {
            return Ok(_service.NivelRemovible(id));
        }

        [HttpGet("desagregacion/removable/{id}")]
        public IActionResult ValidarDesagregado(int id)
        {
            return Ok(_service.DesagregadoRemovible(id));
        }

        [HttpGet("objetivo/removable/{id}")]
        public IActionResult ValidarObjetivo(int id)
        {
            return Ok(_service.ObjetivoRemovible(id));
        }

        [HttpGet("resultado/removable/{id}")]
        public IActionResult ValidarResultado(int id)
        {
            return Ok(_service.ResultadoRemovible(id));
        }

        [HttpGet("actividad/removable/{id}")]
        public IActionResult ValidarActividad(int id)
        {
            return Ok(_service.ActividadRemovible(id));
        }

        [HttpGet("indicador/removable/{id}")]
        public IActionResult ValidarIndicador(int id)
        {
            return Ok(_service.IndicadorRemovible(id));
        }

        [HttpGet("producto/removable/{id}")]
        public IActionResult ValidarProducto(int id)
        {
            return Ok(_service.ProductoRemovible(id));
        }

        [HttpGet("plan-trabajo/actividad/removable/{id}")]
        public IActionResult ValidarActividadPT(int id)
        {
            return Ok(_service.ActividadPTRemovible(id));
        }

        [HttpGet("proyecto/removable/{id}")]
        public IActionResult ValidarProyecto(string id)
        {
            return Ok(_service.ProyectoRemovible(id));
        }

        [HttpGet("usuario/removable/{id}")]
        public IActionResult ValidarUsuario(string id)
        {
            return Ok(_service.UsuarioRemovible(id));
        }
        
    }
}