using Empleados.Domain.Model.Historico;
using Empleados.Domain.Repositories;
using Empleados.Infraestructure.MemoryRepository;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Infraestructure.MemoryRepository
{
    public class MemoryHistoricoRepository : IHistoricoNavegacionRepository
    {
        private readonly MemoryDatabase _database;

        public MemoryHistoricoRepository(MemoryDatabase database)
        {
            _database = database;
        }

        public Task CreateAsync(HistoricoNavegacion obj)
        {
            _database.Historicos.Add(obj);
            return Task.CompletedTask;
        }

        public Task<HistoricoNavegacion> FindByFKAsync(string idFk)
        {
            return Task.FromResult(_database.Historicos.FirstOrDefault(x => x.EmpleadoID == idFk));
        }

        public Task<HistoricoNavegacion> FindByIdAsync(Guid id)
        {
            return Task.FromResult(_database.Historicos.FirstOrDefault(x => x.Id == id));
        }

        public Task RegistrarNavegacion(HistoricoNavegacion obj)
        {
            _database.Historicos.Add(obj);
            return Task.CompletedTask;
        }

    }
}
