using System;
using System.Threading.Tasks;
using Empleado.Application.Dto.Historicos;
using Empleado.Application.UseCases.Command.Empleados.RegistrarTripulante;
using Empleados.Application.Dto.Empleados;
using Empleados.Application.UseCases.Command.Empleados.AddEmpleado;
using Empleados.Application.UseCases.Command.Historicos.AddNavegacion;
using Empleados.Application.UseCases.Queries.Empleados.GetEmpleadoById;
using Empleados.Application.UseCases.Queries.Empleados.GetHistoricoByIdEmpleado;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Empleados.WebApi.Controllers {
    [ApiController]
    [Route("/api/[controller]")]
    public class EmpleadoController : ControllerBase {
        private readonly IMediator _mediator;

        public int MyProperty { get; set; }

        public EmpleadoController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEmpleadoCommand command) {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }
        [Route("CreateTripulantes")]
        [HttpPost]
        public async Task<IActionResult> CreateTripulantes([FromBody] AddTripulanteCommand command) {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [Route("GetTripulaciones")]
        [HttpGet]
        public async Task<IActionResult> GetTripulaciones([FromRoute] GetEmpleadoByIdQuery command) {
            EmpleadoDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetEmpleadoById([FromRoute] GetEmpleadoByIdQuery command) {
            EmpleadoDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("AddHistorico")]
        [HttpPost]
        public async Task<IActionResult> AddHistorico([FromBody] AddNavegacionCommand command) {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }



        [Route("GetHistorico/{EmpleadoID:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetHistorico([FromRoute] GetHistoricoByIdEmpleadoQuery command) {
            HistoricoNavegacionDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
