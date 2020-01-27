using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
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

        [HttpGet("/proyecto/{idProyecto}/seguimiento/{idIndicador}/trimestre/{quarter}/registro")]
        public IActionResult getSeguimientos(string idProyecto, int idIndicador, int quarter)
        {
            return Ok(_service.getRegistro(idProyecto, idIndicador, quarter));
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
        
        [HttpGet("/proyecto/{idProyecto}/seguimiento/{idIndicador}/socio/{idSocio}/desagregado/{idDesagregado}/trimestre/{quarter}/valor")]
        public IActionResult getValor(string idProyecto, int idIndicador, int idSocio, int idDesagregado, int quarter)
        {
            return Ok(_service.getValor(idProyecto, idIndicador, idSocio, idDesagregado, quarter));
        }
        
        [HttpPut("/proyecto/{idProyecto}/seguimiento/{idIndicador}/socio/{idSocio}/desagregado/{idDesagregado}/valor/{valor}/trimestre/{quarter}")]
        public IActionResult SetValor(string idProyecto, int idIndicador, int idSocio, int idDesagregado, double valor, int quarter)
        {
            return Ok(_service.setValor(idProyecto, idIndicador, idSocio, idDesagregado, valor, quarter));
        }

        [HttpPut("/proyecto/{idProyecto}/seguimiento/{idIndicador}/socio/{idSocio}/desagregado/{idDesagregado}/valor/{valor}/pais/{pais}/trimestre/{quarter}")]
        public IActionResult setValorPais(string idProyecto, int idIndicador, int idSocio, int idDesagregado,
            double valor, string pais, int quarter)
        {
            return Ok(_service.setValor(idProyecto, idIndicador, idSocio, idDesagregado, valor, pais, quarter));
        }

        [HttpGet("/proyecto/{id}/trimestre")]
        public IActionResult GetTrimestre(string id)
        {
            return Ok(_service.GetProyectoTrimestre(id));
        }
    }
}