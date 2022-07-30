using Empleados.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmpleadoTest.Domain {
    public class HistoricoNavegacionFactory_Test {
        [Fact]
        public void IsData_Valid() {
            var empleadoIDTest = Guid.NewGuid().ToString();
            var horasRealizadaTest = 2;
            var millasTest = 1000;
            var origenTest = "SC";
            var destinoTest = "LP";

            var factory = new HistoricoNavegacionFactory();
            var objHistorico = factory.Create(empleadoIDTest, 2, 1000, "SC", "LP");

            Assert.NotNull(objHistorico);
            Assert.Equal(empleadoIDTest, objHistorico.EmpleadoID);
            Assert.Equal(horasRealizadaTest, objHistorico.HorasRealizada);
            Assert.Equal(millasTest, objHistorico.Millas);
            Assert.Equal(origenTest, objHistorico.Origen);
            Assert.Equal(destinoTest, objHistorico.Destino);
        }

    }
}
