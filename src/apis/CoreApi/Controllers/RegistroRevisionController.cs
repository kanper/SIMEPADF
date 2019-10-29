using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class RegistroRevisionController : ControllerBase
    {

        private readonly IRegistroRevisionService _service;

        public RegistroRevisionController(IRegistroRevisionService service)
        {
            _service = service;
        }

        [HttpGet("registro-revision/{id}/estado/{status}/pais/{country}")]
        public IActionResult Get(string id, string status, string country)
        {
            return Ok(_service.Get(id, status, country));
        }

        [HttpGet("registro-revision/{id}/estado/{status}")]
        public IActionResult GetAll(string id, string status)
        {
            return Ok(_service.GetAll(id, status));
        }
    }
}