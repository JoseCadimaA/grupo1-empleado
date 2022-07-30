using Empleados.Application.Dto.Empleados;
using MediatR;
using System;

namespace Empleados.Application.UseCases.Queries.Empleados.GetEmpleadoById {
    public class GetEmpleadoByIdQuery : IRequest<EmpleadoDto> {
        public Guid Id { get; set; }

        public GetEmpleadoByIdQuery(Guid id) {
            Id = id;
        }

        public GetEmpleadoByIdQuery() { }
    }
}
