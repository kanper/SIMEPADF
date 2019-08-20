using DatabaseContext;
using DTO.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Services;
using System.Threading.Tasks;

namespace CoreApi.Controllers
{
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly simepadfContext _databaseContext;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioController(IUsuarioService usuarioService, simepadfContext databaseContext, UserManager<Usuario> userManager)
        {
            _usuarioService = usuarioService;
            _databaseContext = databaseContext;
            _userManager = userManager;
        }

        // GET api/values
        [HttpGet("usuario")]
        public IActionResult Get()
        {
            return Ok(
                _usuarioService.GetAll()
            );
        }

        // GET api/values/5
        [HttpGet("usuario/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(
                _usuarioService.Get(id)
            );
        }

        // POST api/values
        [HttpPost("usuario")]
        public async Task<IActionResult> Post([FromBody] PersonalDTO model)
        {
            var usuario = new Usuario(model.Id, model.Email, model.NombrePersonal, model.ApellidoPersonal, model.Cargo,
                    model.FechaAfilacion, model.Email, model.PhoneNumber, model.Password, model.Pais);

            var result = await _userManager.CreateAsync(usuario, model.Password);

            if (result.Succeeded)
            {
                return Ok(_usuarioService.Add(model));
            }
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("usuario/{id}")]
        public IActionResult Put([FromBody] PersonalDTO model, string id)
        {
            return Ok(
                _usuarioService.UpdateAsync(model, id)
            );
        }

        // DELETE api/values/5
        [HttpDelete("usuario-{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(
                _usuarioService.Delete(id)
            );
        }
    }
}
