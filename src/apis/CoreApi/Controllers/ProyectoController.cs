using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoService _service;

        public ProyectoController(IProyectoService service)
        {
            _service = service;
        }

        [HttpGet("proyecto/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("proyecto/estado/{estado}")]
        public IActionResult GetAll(string estado)
        {
            return Ok(_service.GetAll(estado));
        }
        
        [HttpGet("proyecto/estado/{estado}/pais/{pais}")]
        public IActionResult GetAll(string estado, string pais)
        {
            return Ok(pais.Equals("all") ? _service.GetAll(estado) : _service.GetAll(estado,pais));
        }

        [HttpPost("proyecto")]
        public IActionResult Post([FromBody]ProyectoDTO model)
        {           
            return Ok(_service.Add(model, "INCOMPLETO"));
        }
        
        [HttpPost("proyecto/estado/{estadoInicial}")]
        public IActionResult PostBy([FromBody]ProyectoDTO model, string estadoInicial)
        {           
            return Ok(_service.Add(model, estadoInicial));
        }

        [HttpPut("proyecto/{id}")]
        public IActionResult Put([FromBody]ProyectoDTO model, string id)
        {
            return Ok(_service.Update(model, id));
        }

        [HttpDelete("proyecto/{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(_service.Delete(id));
        }

        [HttpGet("proyecto/{id}/estado/{status}")]
        public IActionResult ChangeStatus(string id, string status)
        {
            return Ok(_service.ChangeStatus(id, status));
        }

        [HttpGet("proyecto/{id}/aprobar/{pais}")]
        public IActionResult ApprovalProject(string id, string pais)
        {
            return Ok(_service.Approval(id, pais));
        }

        [HttpGet("proyecto/{id}/estado/{estado}/pais/{pais}/check")]
        public IActionResult CheckProject(string id, string estado, string pais)
        {
            return Ok(_service.Check(id, estado, pais));
        }

        [HttpGet("proyecto/{id}/retornar/{observation}/usuario/{rejectBy}")]
        public IActionResult RejectProject(string id, string observation, string rejectBy)
        {
            return Ok(_service.Reject(id, observation, rejectBy));
        }
        
    }
}