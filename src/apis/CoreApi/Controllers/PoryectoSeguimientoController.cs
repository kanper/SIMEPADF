using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class PoryectoSeguimientoController : ControllerBase
    {
        private readonly IProyectoSeguimientoService _service;

        public PoryectoSeguimientoController(IProyectoSeguimientoService service)
        {
            _service = service;
        }

        [HttpGet("/proyecto/{id}/seguimiento/indicadores")]
        public IActionResult getIndicadores(string id)
        {
            return Ok(_service.getProyectInd(id));
        }

        [HttpGet("/proyecto/{idProyecto}/seguimiento/{idIndicador}/registro")]
        public IActionResult getSeguimientos(string idProyecto, int idIndicador)
        {
            return Ok(_service.getRegistro(idProyecto, idIndicador));
        }

        [HttpGet("/proyecto/{id}/socios")]
        public IActionResult getSocios(string id)
        {
            return Ok(_service.getCabezeras(id));
        }

        [HttpGet("/proyecto/{id}/oraganizaciones")]
        public IActionResult getOrganizaciones(string id)
        {
            return Ok(_service.getOrganizaciones(id));
        }
        
        [HttpGet("/proyecto/{idProyecto}/seguimiento/{idIndicador}/socio/{idSocio}/desagregado/{idDesagregado}/valor")]
        public IActionResult getValor(string idProyecto, int idIndicador, int idSocio, int idDesagregado)
        {
            return Ok(_service.getValor(idProyecto, idIndicador, idSocio, idDesagregado));
        }
        
        [HttpPut("/proyecto/{idProyecto}/seguimiento/{idIndicador}/socio/{idSocio}/desagregado/{idDesagregado}/valor/{valor}")]
        public IActionResult setValor(string idProyecto, int idIndicador, int idSocio, int idDesagregado, double valor)
        {
            return Ok(_service.setValor(idProyecto, idIndicador, idSocio, idDesagregado, valor));
        }
    }
}