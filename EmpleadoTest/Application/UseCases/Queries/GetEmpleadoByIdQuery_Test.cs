using Empleados.Application.UseCases.Queries.Empleados.GetEmpleadoById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmpleadoTest.Application.UseCases.Queries
{
    public class GetEmpleadoByIdQuery_Test
    {
        [Fact]
        public void IsRequest_Valid()
        {
            var id_Test = Guid.NewGuid() ; 

            var command = new GetEmpleadoByIdQuery(id_Test);

            Assert.Equal(id_Test, command.Id);
        }


        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (GetEmpleadoByIdQuery)Activator.CreateInstance(typeof(GetEmpleadoByIdQuery), true);
            Assert.Equal(Guid.Empty,  command.Id);
        }
    }
}
