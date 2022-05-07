using Empleados.Domain.Model.Empleado;
using System;

namespace Empleados.ConsoleUI
{
    static class Program
    {
        static void Main(string[] args)
        {
            Empleado empleado = new("JOSE CADIMA APONTE", new DateTime(1996, 10, 04), "8139814SC");

            empleado.RegistrarEmpleado();


        }
    }
}
