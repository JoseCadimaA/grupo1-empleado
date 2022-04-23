using Empleados.Domain.Model.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Infraestructure.MemoryRepository
{
    public class MemoryDatabase
    {
        private readonly List<Domain.Model.Empleado.Empleado> _pedidos;

        public List<Domain.Model.Empleado.Empleado> Empleados
        {
            get { return _pedidos; }
        }

        public MemoryDatabase()
        {
            _pedidos = new List<Domain.Model.Empleado.Empleado>();
        }

    }
}
