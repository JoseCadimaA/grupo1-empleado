using System.Collections.Generic;

namespace Empleados.Infraestructure.MemoryRepository {
    public class MemoryDatabase {
        private readonly List<Empleado.Domain.Model.Empleados.Empleado> _empleados;
        private readonly List<Domain.Model.Historico.HistoricoNavegacion> _historicos;

        public List<Empleado.Domain.Model.Empleados.Empleado> Empleados {
            get { return _empleados; }
        }

        public List<Domain.Model.Historico.HistoricoNavegacion> Historicos {
            get { return _historicos; }
        }

        public MemoryDatabase() {
            _empleados = new List<Empleado.Domain.Model.Empleados.Empleado>();
            _historicos = new List<Domain.Model.Historico.HistoricoNavegacion>();
        }

    }
}
