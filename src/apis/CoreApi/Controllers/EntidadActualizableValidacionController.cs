using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class EntidadActualizableValidacionController : ControllerBase
    {

        private readonly IEntidadActualizableValidacionService _service;

        public EntidadActualizableValidacionController(IEntidadActualizableValidacionService service)
        {
            _service = service;
        }

        [HttpGet("/validation/update/producto/{id}")]
        public IActionResult ValidarProducto(int id)
        {
            return Ok(_service.IsProductoActualizable(id));
        }
    }
}