using Empleado.Application.Dto.Historicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmpleadoTest.Application.Dto {
    public class HistoricoNavegacionDto_Test {
        [Fact]
        public void IsData_Valid() {
            var idTest = Guid.NewGuid();
            var empleadoIDTest = Guid.NewGuid().ToString();
            var horasRealizadaTest = 2;
            var millasTest = 1000;
            var origenTest = "SC";
            var destinoTest = "LP";

            var objHistorico = new HistoricoNavegacionDto();

            Assert.Equal(Guid.Empty, objHistorico.Id);
            Assert.Null(objHistorico.EmpleadoID);
            Assert.Equal(0, objHistorico.HorasRealizada);
            Assert.Equal(0, objHistorico.Millas);
            Assert.Null(objHistorico.Origen);
            Assert.Null(objHistorico.Destino);

            objHistorico = new HistoricoNavegacionDto(idTest, empleadoIDTest, horasRealizadaTest, millasTest, origenTest, destinoTest);

            Assert.Equal(idTest, objHistorico.Id);
            Assert.Equal(empleadoIDTest, objHistorico.EmpleadoID);
            Assert.Equal(horasRealizadaTest, objHistorico.HorasRealizada);
            Assert.Equal(millasTest, objHistorico.Millas);
            Assert.Equal(origenTest, objHistorico.Origen);
            Assert.Equal(destinoTest, objHistorico.Destino);


        }
    }
}