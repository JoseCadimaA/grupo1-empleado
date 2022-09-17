
using System;

namespace Empleados.Domain.Factories {
    public interface IEmpleadoFactory {

        Empleado.Domain.Model.Empleados.Empleado Create(string nombreCompleto, DateTime fechaNacimiento, string ci);
    }
}
