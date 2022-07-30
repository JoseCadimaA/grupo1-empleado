using MediatR;
using Microsoft.Extensions.Logging;
using Empleados.Application.Services;
using Empleados.Domain.Factories;
using Empleados.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Empleados.Application.UseCases.Command.Empleados.AddEmpleado;
using Empleados.Domain.Model.Empleado;

namespace Empleados.Application.UseCases.Command.Empleados.CrearEmpleado {
    public class AddEmpleadoHandler : IRequestHandler<AddEmpleadoCommand, Guid> {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly ILogger<AddEmpleadoHandler> _logger;
        private readonly IEmpleadoFactory _empleadoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public AddEmpleadoHandler(IEmpleadoRepository empleadoRepository, ILogger<AddEmpleadoHandler> logger,
              IEmpleadoFactory empleadoFactory, IUnitOfWork unitOfWork) {
            _empleadoRepository = empleadoRepository;
            _logger = logger;
            _empleadoFactory = empleadoFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(AddEmpleadoCommand request, CancellationToken cancellationToken) {
            try {
                Domain.Model.Empleado.Empleado objEmpleado = _empleadoFactory.Create(request.NombreCompleto, request.FechaNacimiento, request.CI);

                objEmpleado.RegistrarEmpleado();

                await _empleadoRepository.CreateAsync(objEmpleado);

                await _unitOfWork.Commit();

                return objEmpleado.Id;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error al crear empleado");
            }
            return Guid.Empty;
        }
    }
}
