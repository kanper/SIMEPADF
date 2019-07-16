using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;

namespace CoreApi.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET api/values
        [HttpGet]
        [Route("usuario")]
        public IActionResult Get()
        {
            return Ok(
                _usuarioService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("usuario/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(
                _usuarioService.Get(id)
            );
        }

        // POST api/values
        [HttpPost]
        [Route("usuario")]
        public IActionResult Post([FromBody] Usuario model)
        {
            return Ok(
                _usuarioService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        [Route("usuario/{id}")]
        public IActionResult Put([FromBody] Usuario model)
        {
            return Ok(
                _usuarioService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("usuario-{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(
                _usuarioService.Delete(id)
            );
        }
    }
}
