using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Application.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        public Task<string> GenerarNroPedidoAsync() => Task.FromResult("ABC");
    }
}
