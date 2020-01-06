using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;
using System.Net.Http;

namespace CoreApi.Controllers
{
    public class OrganizacionResponsableController : ControllerBase
    {
        private readonly IOrganizacionResponsableService _service;

        public OrganizacionResponsableController(IOrganizacionResponsableService service)
        {
            _service = service;
        }
        
        [HttpGet("organizacion-responsable")]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        
        [HttpGet("organizacion-responsable/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }
        
        [HttpPost("organizacion-responsable")]
        public IActionResult Post([FromBody] OrganizacionResponsable model)
        {
            return Ok(_service.Add(model));
        }
        
        [HttpPut("organizacion-responsable/{id}")]
        public IActionResult Put([FromBody] OrganizacionResponsable model)
        {
            return Ok(_service.Update(model));
        }
        
        [HttpDelete("organizacion-responsable/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}
