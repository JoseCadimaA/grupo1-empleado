using System;
using System.Threading.Tasks;
using Empleados.Domain.Model.Historico;
using ShareKernel.Core;

namespace Empleados.Domain.Repositories {
    public interface IHistoricoNavegacionRepository : IRepository<HistoricoNavegacion, Guid> {
        Task RegistrarNavegacion(HistoricoNavegacion obj);

    }
}