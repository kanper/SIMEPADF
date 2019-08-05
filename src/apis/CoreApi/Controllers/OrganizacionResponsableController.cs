using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;
using System.Net.Http;

namespace CoreApi.Controllers
{
    public class OrganizacionResponsableController : ControllerBase
    {
        private readonly IOrganizacionResponsableService _OrganizacionService;

        public OrganizacionResponsableController(IOrganizacionResponsableService OrganizacionService)
        {
            _OrganizacionService = OrganizacionService;
        }

        // GET api/values
        [HttpGet("organizacionresponsable")]
        public IActionResult Get()
        {
            return Ok(
                _OrganizacionService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("organizacionresponsable/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _OrganizacionService.Get(id)
            );
        }

        // POST api/values
        [HttpPost("organizacionresponsable")]
        public IActionResult Post([FromBody] OrganizacionResponsable model)
        {
            return Ok(
                _OrganizacionService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut("organizacionresponsable/{id}")]
        public IActionResult Put([FromBody] OrganizacionResponsable model)
        {
            return Ok(
                _OrganizacionService.Update(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("organizacionresponsable-{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _OrganizacionService.Delete(id)
            );
        }
    }
}
