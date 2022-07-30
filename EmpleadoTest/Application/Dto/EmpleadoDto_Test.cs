using Empleados.Application.Dto.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmpleadoTest.Application.Dto {
    public class EmpleadoDto_Test {

        [Fact]
        public void IsData_Valid() {
            /*
                public Guid Id { get; set; }
                public string NombreCompleto { get; set; }
                public DateTime FechaNacimiento { get; set; }
                public string CI { get; set; }
            */
            var idTest = Guid.NewGuid();
            var nombreCompletoTest = "José Cadima";
            var fechaNacimientoTest = new DateTime(1996, 10, 04);
            var ciTest = "8137916";

            var objEmpleadoDto = new EmpleadoDto();

            Assert.Equal(Guid.Empty, objEmpleadoDto.Id);
            Assert.Null(objEmpleadoDto.NombreCompleto);
            Assert.Equal(DateTime.MinValue, objEmpleadoDto.FechaNacimiento);
            Assert.Null(objEmpleadoDto.CI);

            objEmpleadoDto.Id = idTest;
            objEmpleadoDto.NombreCompleto = nombreCompletoTest;
            objEmpleadoDto.FechaNacimiento = fechaNacimientoTest;
            objEmpleadoDto.CI = ciTest;

            Assert.Equal(idTest, objEmpleadoDto.Id);
            Assert.Equal(nombreCompletoTest, objEmpleadoDto.NombreCompleto);
            Assert.Equal(fechaNacimientoTest, objEmpleadoDto.FechaNacimiento);
            Assert.Equal(ciTest, objEmpleadoDto.CI);


        }
    }
}
