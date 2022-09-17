using System.Threading;
using System.Threading.Tasks;
using Empleado.Domain.Event;
using MassTransit;
using MediatR;
using ShareKernel.Core;


namespace Empleado.Application.UseCases.DomainEventHandler.Tripulacion {
    public class PublishIntegrationEventWhenTripulacionCreadoHandler : INotificationHandler<ConfirmedDomainEvent<TripulacionCreado>> {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishIntegrationEventWhenTripulacionCreadoHandler(IPublishEndpoint publishEndpoint) {
            _publishEndpoint = publishEndpoint;
        }



        public async Task Handle(ConfirmedDomainEvent<TripulacionCreado> notification, CancellationToken cancellationToken) {
            ShareKernel.IntegrationEvents.TripulacionCreado evento = new ShareKernel.IntegrationEvents.TripulacionCreado() {
                vueloId = notification.DomainEvent.tripulacionVuelo.vueloId,
                codTripulacion = notification.DomainEvent.tripulacionVuelo.codTripulacion
            };
            await _publishEndpoint.Publish<ShareKernel.IntegrationEvents.TripulacionCreado>(evento);
        }



    }
}
