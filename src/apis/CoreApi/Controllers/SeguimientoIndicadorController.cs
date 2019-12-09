using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class SeguimientoIndicadorController : ControllerBase
    {

        private readonly ISeguimientoIndicadorServer _service;

        public SeguimientoIndicadorController(ISeguimientoIndicadorServer server)
        {
            _service = server;
        }

        [HttpGet("/seguimiento/indicadores/desagregados/anio/{anio}/trimestre/{trimestre}")]
        public IActionResult SeguimientoPorDesagregados(int anio, int trimestre)
        {
            return Ok(_service.ForDesagregados(anio, trimestre));
        }

        [HttpGet("/seguimiento/indicadores/pais/anio/{anio}/trimestre/{trimestre}")]
        public IActionResult SeguimientoPorPais(int anio, int trimestre)
        {
            return Ok(_service.ForPaises(anio, trimestre));
        }

        [HttpGet("/seguimiento/indicadores/region/anio/{anio}")]
        public IActionResult SeguimientoPorRegion(int anio, int trimestre)
        {
            return Ok(_service.ForRegiones(anio));
        }
    }
}