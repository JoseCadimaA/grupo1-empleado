
using System;
using System.Threading.Tasks;
using ShareKernel.Core;

namespace Empleados.Domain.Repositories {
    public interface IEmpleadoRepository : IRepository<Empleado.Domain.Model.Empleados.Empleado, Guid> {
        Task RegistrarEmpleado(Empleado.Domain.Model.Empleados.Empleado obj);


    }
}
