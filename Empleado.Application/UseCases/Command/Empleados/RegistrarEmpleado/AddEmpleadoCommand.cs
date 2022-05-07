using Empleados.Domain.Model.Historico;
using MediatR;
using System;
using System.Collections.Generic;

namespace Empleados.Application.UseCases.Command.Empleados.AddEmpleado
{
    public class AddEmpleadoCommand : IRequest<Guid>
    {
        private AddEmpleadoCommand() { }        

        public AddEmpleadoCommand(string nombreCompleto, DateTime fechaNacimiento, string cI)
        {
            NombreCompleto = nombreCompleto;
            FechaNacimiento = fechaNacimiento;
            CI = cI;
        }

        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CI { get; set; }
    }
}
