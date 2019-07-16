//using System.Linq;
//using DatabaseContext;
//using DTO.DTO;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Model.Domain;
//using Services;

//namespace CoreApi.Controllers
//{
//    [Route("[controller]")]
//    public class PersonalController : ControllerBase
//    {
//        private readonly ApplicationDbContext _db;
//        private readonly IUsuarioService _usuarioService;

//        public PersonalController(ApplicationDbContext db, IUsuarioService usuarioService)
//        {
//            this._db = db;
//            this._usuarioService = usuarioService;
//        }

//        // GET api/values
//        [HttpGet]
//        public IQueryable<PersonalDTO> Get()
//        {
//            var personal = from b in _db.Usuario
//                           select new PersonalDTO()
//                           {
//                               Id = b.Id,
//                               NombrePersonal = b.NombrePersonal,
//                               ApellidoPersonal = b.ApellidoPersonal,
//                               Cargo = b.Cargo,
//                               FechaAfilacion = b.FechaAfilacion,
//                               UserName = b.UserName,
//                               Email = b.Email,
//                               PhoneNumber = b.PhoneNumber,
//                               Rol = b.Rol
//                           };
//            return personal;
//        }

//        // GET api/values/5
//        [HttpGet("{id}")]
//        [ProducesResponseType(typeof(PersonalDTO), StatusCodes.Status200OK)]
//        public IActionResult Get(string id)
//        {
//            var personal = _db.Usuario.Include(b => b.Rol).Select(b =>
//                new PersonalDTO()
//                {
//                    Id = b.Id,
//                    NombrePersonal = b.NombrePersonal,
//                    ApellidoPersonal = b.ApellidoPersonal,
//                    Cargo = b.Cargo,
//                    FechaAfilacion = b.FechaAfilacion,
//                    UserName = b.UserName,
//                    Email = b.Email,
//                    PhoneNumber = b.PhoneNumber,
//                    Rol = b.Rol
//                }).SingleOrDefaultAsync(b => b.Id == id);
//            if (personal == null)
//            {
//                return NotFound();
//            }

//            return Ok(personal);
//        }

//        // POST api/values
//        [HttpPost]
//        public IActionResult Post([FromBody] PersonalDTO model)
//        {
//            Usuario user = new Usuario();
//            try
//            {
//                user.NombrePersonal = model.NombrePersonal;
//                user.ApellidoPersonal = model.ApellidoPersonal;
//                user.Cargo = model.Cargo;
//                user.FechaAfilacion = model.FechaAfilacion;
//                user.UserName = model.UserName;
//                user.Email = model.Email;
//                user.PhoneNumber = model.PhoneNumber;
//                user.Rol = model.Rol;

//                _db.Add(user);
//                _db.SaveChanges();
//                return Ok();
//            }
//            catch
//            {
//                return NoContent();
//            }

//        }

//        // PUT api/values/5
//        [HttpPut]
//        public IActionResult Put([FromBody] PersonalDTO model)
//        {
//            try
//            {
//                var originalModel = _db.Usuario.Single(x =>
//                  x.Id == model.Id
//                );

//                originalModel.NombrePersonal = model.NombrePersonal;
//                originalModel.ApellidoPersonal = model.ApellidoPersonal;
//                originalModel.Cargo = model.Cargo;
//                originalModel.FechaAfilacion = model.FechaAfilacion;
//                originalModel.UserName = model.UserName;
//                originalModel.Email = model.Email;
//                originalModel.PhoneNumber = model.PhoneNumber;
//                originalModel.Rol = model.Rol;

//                _db.Update(model);
//                _db.SaveChanges();

//                return Ok();
//            }
//            catch
//            {
//                return NoContent();
//            }
//        }

//        // DELETE api/values/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(string id)
//        {
//            return Ok(
//                _usuarioService.Delete(id)
//            );
//        }

//    }
//}
