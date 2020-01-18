using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class RegistroAprobacionController : ControllerBase
    {
        private readonly IRegistroAprobacionService _service;

        public RegistroAprobacionController(IRegistroAprobacionService service)
        {
            _service = service;
        }

        [HttpGet("registro-aprobacion/{id}")]
        public IActionResult GetAll(string id)
        {
            return Ok(_service.GetAll(id));
        }
    }
}