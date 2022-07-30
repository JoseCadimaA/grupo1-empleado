using Empleados.Domain.Model.Historico;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Domain.Repositories {
    public interface IHistoricoNavegacionRepository : IRepository<HistoricoNavegacion, Guid> {
        Task RegistrarNavegacion(HistoricoNavegacion obj);

    }
}