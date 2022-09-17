using System;
using ShareKernel.Core;

namespace ShareKernel.IntegrationEvents {
    public record TripulacionCreado : IntegrationEvent {

        //public Guid Id { get; set; }
        public Guid vueloId { get; set; }
        public Guid codTripulacion { get; set; }
        public Guid codEmpleado { get; set; }
        public string estado { get; set; }
        public int activo { get; set; }
    }
}
