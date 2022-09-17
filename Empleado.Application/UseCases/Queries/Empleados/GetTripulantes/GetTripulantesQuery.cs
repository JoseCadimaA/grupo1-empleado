using System;
using Empleados.Application.Dto.Empleados;
using MediatR;

namespace Empleados.Application.UseCases.Queries.Empleados.GetEmpleadoById {
    public class GetTripulantesQuery : IRequest<EmpleadoDto> {
        public Guid Id { get; set; }

        public GetTripulantesQuery(Guid id) {
            Id = id;
        }

        public GetTripulantesQuery() { }
    }
}
