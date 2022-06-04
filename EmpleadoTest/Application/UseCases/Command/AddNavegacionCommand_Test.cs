using Empleados.Application.UseCases.Command.Historicos.AddNavegacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmpleadoTest.Application.UseCases.Command
{
    public class AddNavegacionCommand_Test
    {
        [Fact]
        public void IsRequest_Valid()
        {
            //string empleadoID, int horasRealizada, int millas, string origen, string destino


            var empleadoID_Test = "60cfbed6-f6b2-42aa-a024-91e240555e1e";
            var horasRealizada_Test = 2;
            var millas_Test = 1000;
            var origen_Test = "SC";
            var destino_Test = "LP";

            var command = new AddNavegacionCommand(empleadoID_Test, horasRealizada_Test, millas_Test, origen_Test, destino_Test);

            Assert.Equal("60cfbed6-f6b2-42aa-a024-91e240555e1e", command.EmpleadoID);
        }


        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (AddNavegacionCommand)Activator.CreateInstance(typeof(AddNavegacionCommand), true);
            Assert.Null(command.EmpleadoID);
        }
    }
}
