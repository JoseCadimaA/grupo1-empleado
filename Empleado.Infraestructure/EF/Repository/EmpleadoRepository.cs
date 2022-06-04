
using Empleados.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Infraestructure.EF.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {

        public Task CreateAsync(Domain.Model.Empleado.Empleado obj)
        {
            Console.WriteLine($"Insertando el empleado { obj.CI }");

            return Task.CompletedTask;
        }

        public Task<Domain.Model.Empleado.Empleado> FindByFKAsync(string idFk)
        {
            return null;
        }

        public Task<Domain.Model.Empleado.Empleado> FindByIdAsync(Guid id)
        {
            Console.WriteLine($"Retornando el empleado { id }");

            return null;
        }     

        public Task RegistrarEmpleado(Domain.Model.Empleado.Empleado obj)
        {
            Console.WriteLine($"Insertando el empleado { obj.CI }");
            return Task.CompletedTask;
        }

        
    }
}
