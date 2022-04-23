using Empleados.Application.Dto.Empleados;
using Empleados.Application.UseCases.Command.Empleados.AddEmpleado;
using Empleados.Application.UseCases.Queries.Empleados.GetEmpleadoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEmpleadoCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetPedidoById([FromRoute] GetEmpleadoByIdQuery command)
        {
            EmpleadoDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
