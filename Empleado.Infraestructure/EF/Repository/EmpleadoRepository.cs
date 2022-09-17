
using System;
using System.Threading.Tasks;
using Empleados.Domain.Repositories;
using ShareKernel.Core;


namespace Empleados.Infraestructure.EF.Repository {
    public class EmpleadoRepository : IEmpleadoRepository {

        public Task CreateAsync(Empleado.Domain.Model.Empleados.Empleado obj) {
            Console.WriteLine($"Insertando el empleado {obj.CI}");

            return Task.CompletedTask;
        }

        public Task<Empleado.Domain.Model.Empleados.Empleado> FindByFKAsync(string idFk) {
            return null;
        }



        public Task RegistrarEmpleado(Empleado.Domain.Model.Empleados.Empleado obj) {
            return Task.CompletedTask;
        }

        Task<Empleado.Domain.Model.Empleados.Empleado> IRepository<Empleado.Domain.Model.Empleados.Empleado, Guid>.FindByFKAsync(string idFk) {
            return null;
        }

        Task<Empleado.Domain.Model.Empleados.Empleado> IRepository<Empleado.Domain.Model.Empleados.Empleado, Guid>.FindByIdAsync(Guid id) {
            throw new NotImplementedException();
        }
    }
}
