
using System;

namespace Empleados.Domain.Factories {
    public class EmpleadoFactory : IEmpleadoFactory {
        public Empleado.Domain.Model.Empleados.Empleado Create(string nombreCompleto, DateTime fechaNacimiento, string ci) {
            return new Empleado.Domain.Model.Empleados.Empleado(nombreCompleto, fechaNacimiento, ci);
        }
    }
}
