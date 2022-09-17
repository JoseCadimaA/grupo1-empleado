using System;
using System.Linq;
using System.Threading.Tasks;
using Empleados.Domain.Repositories;
using ShareKernel.Core;

namespace Empleados.Infraestructure.MemoryRepository {
    public class MemoryEmpleadoRepository : IEmpleadoRepository {
        private readonly MemoryDatabase _database;

        public MemoryEmpleadoRepository(MemoryDatabase database) {
            _database = database;
        }

        public Task<Empleado.Domain.Model.Empleados.Empleado> FindByIdAsync(Guid id) {
            return Task.FromResult(_database.Empleados.FirstOrDefault(x => x.Id == id));
        }

        public Task RegistrarEmpleado(Empleado.Domain.Model.Empleados.Empleado obj) {
            _database.Empleados.Add(obj);
            return Task.CompletedTask;
        }

        Task<Empleado.Domain.Model.Empleados.Empleado> IRepository<Empleado.Domain.Model.Empleados.Empleado, Guid>.FindByIdAsync(Guid id) {
            return Task.FromResult(_database.Empleados.FirstOrDefault(x => x.Id == id));
        }

        public Task CreateAsync(Empleado.Domain.Model.Empleados.Empleado obj) {
            _database.Empleados.Add(obj);
            return Task.CompletedTask;
        }



        public Task<Empleado.Domain.Model.Empleados.Empleado> FindByFKAsync(string idFk) {
            throw new NotImplementedException();
        }
    }
}
