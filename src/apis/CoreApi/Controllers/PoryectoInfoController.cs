using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class PoryectoInfoController : ControllerBase
    {
        private readonly IProyectoInfoService _service;

        public PoryectoInfoController(IProyectoInfoService service)
        {
            _service = service;
        }

        [HttpGet("proyecto-info/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("proyecto-info/{id}/all")]
        public IActionResult GetAll(string id)
        {
            return Ok(_service.GetAll(id));
        }
    }
}