using Empleados.Application.UseCases.Queries.Empleados.GetHistoricoByIdEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmpleadoTest.Application.UseCases.Queries {
    public class GetHistoricoByIdEmpleadoQuery_Test {
        [Fact]
        public void IsRequest_Valid() {
            var id_Test = Guid.NewGuid();
            var empleadoId_Test = "60cfbed6-f6b2-42aa-a024-91e240555e1e";

            var command = new GetHistoricoByIdEmpleadoQuery(id_Test);
            var command2 = new GetHistoricoByIdEmpleadoQuery(id_Test, empleadoId_Test);

            Assert.Equal(id_Test, command.Id);
            Assert.Equal(empleadoId_Test, command2.EmpleadoID);
        }


        [Fact]
        public void TestConstructor_IsPrivate() {
            var command = (GetHistoricoByIdEmpleadoQuery)Activator.CreateInstance(typeof(GetHistoricoByIdEmpleadoQuery), true);
            Assert.Equal(Guid.Empty, command.Id);
        }
    }
}
