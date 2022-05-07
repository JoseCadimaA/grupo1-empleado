using Empleados.Domain.Event;
using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Domain.Model.Empleado
{
    public class Empleado : AggregateRoot<Guid>
    {
        public EmpleadoNameValue NombreCompleto { get; set; }
        public EmpleadoFechaNacValue FechaNacimiento { get; set; }
        public EmpleadoCiValue CI { get; set; }

        public Empleado(string nombreCompleto, DateTime fechaNacimiento, string ci)
        {
            Id = Guid.NewGuid();
            NombreCompleto = nombreCompleto;
            FechaNacimiento = fechaNacimiento;
            CI = ci;
        }

        public void RegistrarEmpleado()
        {
            var evento = new EmpleadoCreado(Id, CI);
            AddDomainEvent(evento);
        }

    }
}