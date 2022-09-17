using System;
using ShareKernel.Core;

namespace Empleados.Domain.Event {
    public record HistoricoNavegacionCreado : DomainEvent {
        public Guid HistoricoID { get; }
        public string Origen { get; }
        public string Destino { get; }


        public HistoricoNavegacionCreado(Guid historicoID, string origen, string destino) : base(DateTime.Now) {
            HistoricoID = historicoID;
            Origen = origen;
            Destino = destino;
        }
    }
}
