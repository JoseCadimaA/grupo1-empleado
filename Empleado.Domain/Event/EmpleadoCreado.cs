using System;
using ShareKernel.Core;

namespace Empleados.Domain.Event {
    public record EmpleadoCreado : DomainEvent {
        public Guid EmpleadoId { get; }
        public string CI { get; }

        public EmpleadoCreado(Guid pedidoId,
            string ci) : base(DateTime.Now) {
            EmpleadoId = pedidoId;
            CI = ci;

        }
    }
}
