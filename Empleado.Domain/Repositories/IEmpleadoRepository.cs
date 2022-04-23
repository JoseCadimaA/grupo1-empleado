using Empleados.Domain.Model.Empleado;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Domain.Repositories
{
    public interface IEmpleadoRepository : IRepository<Empleado, Guid>
    {
        Task RegistrarEmpleado(Empleado obj);
        Task ActualizarEmpleado(Empleado obj);
        Task EliminarEmpleado(Empleado obj);
        Task ObtenerEmpleadoByTipo(string tipo);
        Task ObtenerListaEmpleados();

    }
}
