using Empleados.Application.UseCases.Command.Empleados.AddEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmpleadoTest.Application.UseCases.Command {
    public class AddEmpleadoCommand_Test {
        [Fact]
        public void IsRequest_Valid() {
            //(str/ing nombreCompleto, DateTime fechaNacimiento, string cI)


            var nombreCompleto_Test = "Pepe Cadima";
            var fechaNacimiento_Test = new DateTime(1996, 10, 04);
            var ci_Test = "8137916";

            var command = new AddEmpleadoCommand(nombreCompleto_Test, fechaNacimiento_Test, ci_Test);

            Assert.Equal("8137916", command.CI);
        }


        [Fact]
        public void TestConstructor_IsPrivate() {
            var command = (AddEmpleadoCommand)Activator.CreateInstance(typeof(AddEmpleadoCommand), true);
            Assert.Null(command.NombreCompleto);
        }
    }
}
