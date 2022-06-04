
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
        public Task ActualizarEmpleado(Domain.Model.Empleado.Empleado obj)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Domain.Model.Empleado.Empleado obj)
        {
            Console.WriteLine($"Insertando el empleado { obj.CI }");

            return Task.CompletedTask;
        }

        public Task EliminarEmpleado(Domain.Model.Empleado.Empleado obj)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Model.Empleado.Empleado> FindByFKAsync(string idFk)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Model.Empleado.Empleado> FindByIdAsync(Guid id)
        {
            Console.WriteLine($"Retornando el empleado { id }");

            return null;
        }

        public Task ObtenerEmpleadoByTipo(string tipo)
        {
            throw new NotImplementedException();
        }

        public Task ObtenerListaEmpleados()
        {
            throw new NotImplementedException();
        }

        public Task RegistrarEmpleado(Domain.Model.Empleado.Empleado obj)
        {
            Console.WriteLine($"Insertando el empleado { obj.CI }");
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Model.Empleado.Empleado obj)
        {
            Console.WriteLine($"Actualizando el empleado { obj.CI }");

            return Task.CompletedTask;
        }
    }
}
