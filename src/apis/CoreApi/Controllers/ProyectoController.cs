using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoInformationService _informationService;
        private readonly IProyectoListService _listService;
        private readonly IProyectoManagementService _managementService;
        private readonly IProyectoProcessService _processService;

        public ProyectoController(IProyectoInformationService informationService, IProyectoListService listService, IProyectoManagementService managementService, IProyectoProcessService processService)
        {
            _informationService = informationService;
            _listService = listService;
            _managementService = managementService;
            _processService = processService;
        }

        [HttpGet("proyecto/{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_informationService.Get(id));
        }

        [HttpGet("proyecto/estado/{estado}")]
        public IActionResult GetAll(string estado)
        {
            return Ok(_listService.GetAll(estado));
        }
        
        [HttpGet("proyecto/estado/{estado}/pais/{pais}")]
        public IActionResult GetAll(string estado, string pais)
        {
            return Ok(pais.Equals("all") ? _listService.GetAll(estado) : _listService.GetAll(estado,pais));
        }

        [HttpPost("proyecto")]
        public IActionResult Post([FromBody]ProyectoDTO model)
        {           
            return Ok(_managementService.Add(model, "INCOMPLETO"));
        }
        
        [HttpPost("proyecto/estado/{estadoInicial}")]
        public IActionResult PostBy([FromBody]ProyectoDTO model, string estadoInicial)
        {           
            return Ok(_managementService.Add(model, estadoInicial));
        }

        [HttpPut("proyecto/{id}")]
        public IActionResult Put([FromBody]ProyectoDTO model, string id)
        {
            return Ok(_managementService.Update(model, id));
        }

        [HttpDelete("proyecto/{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(_managementService.Delete(id));
        }

        [HttpGet("proyecto/{id}/estado/{status}")]
        public IActionResult ChangeStatus(string id, string status)
        {
            return Ok(_processService.ChangeStatus(id, status));
        }

        [HttpGet("proyecto/{id}/aprobar/{pais}")]
        public IActionResult ApprovalProject(string id, string pais)
        {
            return Ok(_processService.Approval(id, pais));
        }

        [HttpGet("proyecto/{id}/estado/{estado}/pais/{pais}/check")]
        public IActionResult CheckProject(string id, string estado, string pais)
        {
            return Ok(_processService.Check(id, estado, pais));
        }

        [HttpGet("proyecto/{id}/retornar/{observation}/usuario/{rejectBy}")]
        public IActionResult RejectProject(string id, string observation, string rejectBy)
        {
            return Ok(_processService.Reject(id, observation, rejectBy));
        }
        
    }
}