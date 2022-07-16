using Empleado.Application.Dto.Historicos;
using Empleados.Application.Dto.Empleados;
using Empleados.Application.UseCases.Command.Empleados.AddEmpleado;
using Empleados.Application.UseCases.Command.Historicos.AddNavegacion;
using Empleados.Application.UseCases.Queries.Empleados.GetEmpleadoById;
using Empleados.Application.UseCases.Queries.Empleados.GetHistoricoByIdEmpleado;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empleados.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IMediator _mediator;   

        public EmpleadoController(IMediator mediator)
        {
            _mediator = mediator;
              _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEmpleadoCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
            {

            }

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetEmpleadoById([FromRoute] GetEmpleadoByIdQuery command)
        {
            EmpleadoDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [Route("AddHistorico")]
        [HttpPost]
        public async Task<IActionResult> AddHistorico([FromBody] AddNavegacionCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }



        [Route("GetHistorico/{EmpleadoID:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetHistorico([FromRoute] GetHistoricoByIdEmpleadoQuery command)
        {
            HistoricoNavegacionDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
