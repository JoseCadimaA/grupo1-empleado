
using Empleado.Application.Dto.Historicos;
using MediatR;
using System;

namespace Empleados.Application.UseCases.Queries.Empleados.GetHistoricoByIdEmpleado
{
    public class GetHistoricoByIdEmpleadoQuery : IRequest<HistoricoNavegacionDto>
    {
        public Guid Id { get; set; }
        public Guid EmpleadoID { get; set; }

        public GetHistoricoByIdEmpleadoQuery(Guid id)
        {
            Id = id;
        }

        public GetHistoricoByIdEmpleadoQuery(Guid id, Guid empleadoID) 
        {
            Id = id;
            EmpleadoID = empleadoID;
        }

        public GetHistoricoByIdEmpleadoQuery() { }
    }
}
