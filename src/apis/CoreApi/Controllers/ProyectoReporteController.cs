using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class ProyectoReporteController : ControllerBase
    {
        private readonly IProyectoReporteService _service;

        public ProyectoReporteController(IProyectoReporteService service)
        {
            _service = service;
        }

        [HttpGet("/proyecto/reporte/anio/{year}/trimestre/{quarter}/paises/{countries}/socios/{socios}")]
        public IActionResult GetAll(int year, int quarter, string countries, string socios)
        {
            return Ok(_service.GetAll(year, quarter, countries, socios));
        }
    }
}