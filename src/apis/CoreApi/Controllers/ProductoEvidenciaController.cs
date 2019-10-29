using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class ProductoEvidenciaController : ControllerBase
    {

        private readonly IProductoEvidenciaService _service;

        public ProductoEvidenciaController(IProductoEvidenciaService service)
        {
            _service = service;
        }

        [HttpGet("/actividad/producto/{id}/evidencia")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("/actividad/{id}/producto/evidencia")]
        public IActionResult GetAll(int id)
        {
            return Ok(_service.GetAll(id));
        }
    }
}