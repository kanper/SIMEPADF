using System;
using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CoreApi.Controllers
{
    public class AlertaController : ControllerBase
    {

        private readonly IAlertService _service;

        public AlertaController(IAlertService service)
        {
            _service = service;
        }

        [HttpGet("/alerta/rol/{rol}/pais/{pais}")]
        public IActionResult GetAll(string rol, string pais)
        {
            return Ok(_service.FindAll(rol, pais));
        }

        [HttpPut("/alerta/{id}")]
        public IActionResult CheckRead(int id)
        {
            return Ok(_service.MarkAsRead(id));
        }

        [HttpPost("/alerta")]
        public IActionResult Add([FromBody] AlertaDTO model) 
        {
            return Ok(_service.CreateAlert(model));
        }
    }
}