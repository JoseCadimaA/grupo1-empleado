using Empleados.Domain.Model.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Domain.Factories {
    public interface IEmpleadoFactory {

        Empleado Create(string nombreCompleto, DateTime fechaNacimiento, string ci);
    }
}
