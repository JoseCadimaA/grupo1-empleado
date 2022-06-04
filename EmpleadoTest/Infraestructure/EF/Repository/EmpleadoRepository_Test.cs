using Empleados.Infraestructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmpleadoTest.Infraestructure.EF.Repository
{
    public class EmpleadoRepository_Test
    {
        [Fact]
        public void Method_CreateAsync_IsValid()
        {
            EmpleadoRepository repository = new EmpleadoRepository();
            Task result = repository.CreateAsync(new Empleados.Domain.Model.Empleado.Empleado("Pepe Cadima", new DateTime(1996, 10, 04), "8137916"));

            Assert.Equal(result, Task.CompletedTask);
        }

        [Fact]
        public void Method_FindByFKAsync_IsValid()
        {
            EmpleadoRepository repository = new EmpleadoRepository();
            Task result = repository.FindByFKAsync("9166e2e7-d2a3-4b8a-9ab2-9e727d52e646");

            Assert.Null(result);
        }

        [Fact]
        public void Method_FindByIdAsync_IsValid()
        {
            EmpleadoRepository repository = new EmpleadoRepository();
            Task<Empleados.Domain.Model.Empleado.Empleado> result = repository.FindByIdAsync(Guid.NewGuid());

            Assert.Null(result);
        }

        [Fact]
        public void Method_RegistrarEmpleado_IsValid()
        {

            EmpleadoRepository repository = new EmpleadoRepository();
            Task result = repository.RegistrarEmpleado(new Empleados.Domain.Model.Empleado.Empleado("Pepe Cadima", new DateTime(1996, 10, 04), "8137916"));

            Assert.NotNull(result);
        }
    }
}
