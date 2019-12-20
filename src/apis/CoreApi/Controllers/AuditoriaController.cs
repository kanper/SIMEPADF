using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class AuditoriaController : ControllerBase
    {

        private readonly IAuditoriaService _service;

        public AuditoriaController(IAuditoriaService service)
        {
            _service = service;
        }

        [HttpGet("/auditoria/all")]
        public IActionResult GetAllAuditoria()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("/auditoria/indicador")]
        public IActionResult GetIndicadorAuditoria()
        {
            return Ok(_service.GetIndicador());
        }
        
        [HttpGet("/auditoria/actividad")]
        public IActionResult GetActividadAuditoria()
        {
            return Ok(_service.GetActividad());
        }

        [HttpGet("/auditoria/resultado")]
        public IActionResult GetResultadoAuditoria()
        {
            return Ok(_service.GetResultado());
        }

        [HttpGet("/auditoria/objetivo")]
        public IActionResult GetObjetivoAuditoria()
        {
            return Ok(_service.GetObjetivo());
        }

        [HttpGet("/auditoria/desagregado")]
        public IActionResult GetDesagregadoAuditoria()
        {
            return Ok(_service.GetDesagregacion());
        }

        [HttpGet("/auditoria/socio")]
        public IActionResult GetSocioInternacionalAuditoria()
        {
            return Ok(_service.GetSocioInternacional());
        }

        [HttpGet("/auditoria/organizacion")]
        public IActionResult GetOraganizacionResponsableAuditoria()
        {
            return Ok(_service.GetOrganizacionResponsable());
        }

        [HttpGet("/auditoria/pais")]
        public IActionResult GetPaisAuditoria()
        {
            return Ok(_service.GetPais());
        }

        [HttpGet("/auditoria/nivel")]
        public IActionResult GetNivelImpactoAuditoria()
        {
            return Ok(_service.GetNivelImpacto());
        }

        [HttpGet("/auditoria/fuente")]
        public IActionResult GetFuenteDatoAuditoria()
        {
            return Ok(_service.GetFuenteDato());
        }

        [HttpGet("/auditoria/proyecto")]
        public IActionResult GetProyectoAuditoria()
        {
            return Ok(_service.GetProyecto());
        }

        [HttpGet("/auditoria/producto")]
        public IActionResult GetProductoAuditoria()
        {
            return Ok(_service.GetProducto());
        }

        [HttpGet("/auditoria/actividadPT")]
        public IActionResult GetActividadPlanTrabajoAuditoria()
        {
            return Ok(_service.GetActividadPlanTrabajo());
        }
    }
}