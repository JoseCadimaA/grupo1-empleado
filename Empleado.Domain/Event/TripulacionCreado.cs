using System;
using Domain.Model.TripulacionVuelo;
using ShareKernel.Core;

namespace Empleado.Domain.Event {
    public record TripulacionCreado : DomainEvent {
        public TripulacionVuelo tripulacionVuelo { get; private set; }
        public TripulacionCreado(TripulacionVuelo tripulacionVuelo, DateTime occuredOn) : base(occuredOn) {

            this.tripulacionVuelo = tripulacionVuelo;

        }
    }
}
