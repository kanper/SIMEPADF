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
    }
}