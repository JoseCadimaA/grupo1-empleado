using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Domain.Event
{
    public record EmpleadoCreado : DomainEvent
    {
        public Guid EmpleadoId { get;  }
        public string CI { get; }

        public EmpleadoCreado(Guid pedidoId,
            string ci) : base(DateTime.Now)
        {
            EmpleadoId = pedidoId;
            CI = ci;

        }
    }
}
