using System;
using System.Threading;
using System.Threading.Tasks;
using Empleados.Domain.Factories;
using Empleados.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using ShareKernel.Core;

namespace Empleado.Application.UseCases.Command.Empleados.RegistrarTripulante {
    public class AddTripulanteHandler : IRequestHandler<AddTripulanteCommand, Guid> {
        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly ILogger<AddTripulanteHandler> _logger;
        private readonly IEmpleadoFactory _empleadoFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public AddTripulanteHandler(IEmpleadoRepository empleadoRepository, ILogger<AddTripulanteHandler> logger,
              IEmpleadoFactory empleadoFactory, IUnitOfWork unitOfWork, IMediator mediator) {
            _empleadoRepository = empleadoRepository;
            _logger = logger;
            _empleadoFactory = empleadoFactory;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }


        public async Task<Guid> Handle(AddTripulanteCommand request, CancellationToken cancellationToken) {
            try {
                Empleado.Domain.Model.Empleados.Empleado objEmpleado = new();

                foreach (var item in request.Detalle.listTripulacionesDto) {
                    objEmpleado.AgregarItem(item.codTripulacion, item.codEmpleado, item.estado, item.activo);
                }
                //objEmpleado.RegistrarEmpleado();




                foreach (var @event in objEmpleado.DomainEvents) {
                    Type type = typeof(ConfirmedDomainEvent<>)
                        .MakeGenericType(@event.GetType());

                    var confirmedEvent = (INotification)Activator
                        .CreateInstance(type, @event);

                    await _mediator.Publish(confirmedEvent);
                }
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
