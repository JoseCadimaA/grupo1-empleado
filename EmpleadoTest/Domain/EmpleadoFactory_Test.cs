using Empleados.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmpleadoTest.Domain {
    public class EmpleadoFactory_Test {
        [Fact]
        public void Create_Correctly() {

            var nombreCompletoTest = "Pepe Cadima";
            var fechaNacimientoTest = new DateTime(1996, 10, 04);
            var ciTest = "8137916";

            var factory = new EmpleadoFactory();
            var objEmpleado = factory.Create(nombreCompletoTest, fechaNacimientoTest, ciTest);

            Assert.NotNull(objEmpleado);
            Assert.Equal(nombreCompletoTest, objEmpleado.NombreCompleto);
            Assert.Equal(fechaNacimientoTest, (DateTime)objEmpleado.FechaNacimiento);
            Assert.Equal(ciTest, objEmpleado.CI);
        }
    }
}
