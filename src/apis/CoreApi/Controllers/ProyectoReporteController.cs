using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    //[Authorize]
    public class ProyectoReporteController : ControllerBase
    {
        private readonly IProyectoReporteService _service;

        public ProyectoReporteController(IProyectoReporteService service)
        {
            _service = service;
        }

        [HttpGet("/proyecto/reporte/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("/proyecto/reporte/id/{id}/start/{startDate}/end/{endDate}")]
        public IActionResult Get(string id, string startDate, string endDate)
        {
            return Ok(_service.Get(id, startDate, endDate));
        }

        [HttpGet("/proyecto/reporte/anio/{year}/paises/{countries}/socios/{socios}")]
        public IActionResult GetAll(int year, int quarter, string countries, string socios)
        {
            return Ok(_service.GetAll(year, countries, socios));
        }
    }
}