using System;
using Empleado.Application.Dto.Tripulantes;
using MediatR;

namespace Empleado.Application.UseCases.Command.Empleados.RegistrarTripulante {
    public class AddTripulanteCommand : IRequest<Guid> {
        private AddTripulanteCommand() { }

        public AddTripulanteCommand(RequestTripulanteDto detalle) {
            Detalle = detalle;
        }

        public RequestTripulanteDto Detalle { get; set; }
    }
}
