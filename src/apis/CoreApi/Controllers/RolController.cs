//using Microsoft.AspNetCore.Mvc;
//using Model.Domain;
//using Services;

//namespace CoreApi.Controllers
//{
//    [Route("[controller]")]
//    public class RolController : ControllerBase
//    {
//        private readonly IRolService _rolService;

//        public RolController(IRolService rolService)
//        {
//            _rolService = rolService;
//        }

//        // GET api/values
//        [HttpGet]
//        public IActionResult Get()
//        {
//            return Ok(
//                _rolService.GetAll()
//            );
//        }

//        // GET api/values/5
//        [HttpGet("{id}")]
//        public IActionResult Get(string id)
//        {
//            return Ok(
//                _rolService.Get(id)
//            );
//        }

//        // POST api/values
//        [HttpPost]
//        public IActionResult Post([FromBody] Rol model)
//        {
//            return Ok(
//                _rolService.Add(model)
//            );
//        }

//        // PUT api/values/5
//        [HttpPut]
//        public IActionResult Put([FromBody] Rol model)
//        {
//            return Ok(
//                _rolService.Add(model)
//            );
//        }

//        // DELETE api/values/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(string id)
//        {
//            return Ok(
//                _rolService.Delete(id)
//            );
//        }
//    }
//}
