using Empleados.Domain.Event;
using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Domain.Model.Historico {
    public class HistoricoNavegacion : AggregateRoot<Guid> {
        public string EmpleadoID { get; set; }
        public int HorasRealizada { get; set; }
        public int Millas { get; set; }
        public HistoricoOrigenValue Origen { get; set; }
        public HistoricoDestinoValue Destino { get; set; }

        public HistoricoNavegacion(string empleadoID, int horasRealizada, int millas, HistoricoOrigenValue origen, HistoricoDestinoValue destino) {
            Id = Guid.NewGuid();
            EmpleadoID = empleadoID;
            HorasRealizada = horasRealizada;
            Millas = millas;
            Origen = origen;
            Destino = destino;
        }

    }
}
