using Empleados.Domain.Model.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Infraestructure.MemoryRepository {
    public class MemoryDatabase {
        private readonly List<Domain.Model.Empleado.Empleado> _empleados;
        private readonly List<Domain.Model.Historico.HistoricoNavegacion> _historicos;

        public List<Domain.Model.Empleado.Empleado> Empleados {
            get { return _empleados; }
        }

        public List<Domain.Model.Historico.HistoricoNavegacion> Historicos {
            get { return _historicos; }
        }

        public MemoryDatabase() {
            _empleados = new List<Domain.Model.Empleado.Empleado>();
            _historicos = new List<Domain.Model.Historico.HistoricoNavegacion>();
        }

    }
}
