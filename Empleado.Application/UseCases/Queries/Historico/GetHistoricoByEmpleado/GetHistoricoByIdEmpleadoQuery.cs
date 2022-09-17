
using System;
using Empleado.Application.Dto.Historicos;
using MediatR;

namespace Empleados.Application.UseCases.Queries.Empleados.GetHistoricoByIdEmpleado {
    public class GetHistoricoByIdEmpleadoQuery : IRequest<HistoricoNavegacionDto> {
        public Guid Id { get; set; }
        public string EmpleadoID { get; set; }

        public GetHistoricoByIdEmpleadoQuery(Guid id) {
            Id = id;
        }

        public GetHistoricoByIdEmpleadoQuery(Guid id, string empleadoID) {
            Id = id;
            EmpleadoID = empleadoID;
        }

        public GetHistoricoByIdEmpleadoQuery() { }
    }
}
