using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
