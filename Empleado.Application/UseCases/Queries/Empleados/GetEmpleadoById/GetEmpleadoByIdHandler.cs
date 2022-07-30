using MediatR;
using Microsoft.Extensions.Logging;
using Empleados.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Empleados.Application.Dto.Empleados;

namespace Empleados.Application.UseCases.Queries.Empleados.GetEmpleadoById {
    public class GetEmpleadoByIdHandler : IRequestHandler<GetEmpleadoByIdQuery, EmpleadoDto> {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly ILogger<GetEmpleadoByIdQuery> _logger;

        public GetEmpleadoByIdHandler(IEmpleadoRepository empleadoRepository, ILogger<GetEmpleadoByIdQuery> logger) {
            _empleadoRepository = empleadoRepository;
            _logger = logger;
        }

        public async Task<EmpleadoDto> Handle(GetEmpleadoByIdQuery request, CancellationToken cancellationToken) {
            EmpleadoDto result = null;
            try {
                Domain.Model.Empleado.Empleado objEmpleado = await _empleadoRepository.FindByIdAsync(request.Id);

                result = new EmpleadoDto() {
                    Id = objEmpleado.Id,
                    NombreCompleto = objEmpleado.NombreCompleto,
                    FechaNacimiento = objEmpleado.FechaNacimiento,
                    CI = objEmpleado.CI,
                };
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error al obtener Empleado con id: { EmpleadoId }", request.Id);
            }

            return result;
        }
    }
}
