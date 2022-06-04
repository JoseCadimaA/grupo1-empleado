using Empleado.Application.Dto.Historicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmpleadoTest.Application.Dto
{
    public class HistoricoNavegacionDto_Test
    {
        [Fact]
        public void IsData_Valid()
        {
            /*
             * public Guid Id { get; set; }
                public Guid EmpleadoID { get; set; }
                public int HorasRealizada { get; set; }
                public int Millas { get; set; }
                public string Origen { get; set; }
                public string Destino { get; set; }
             */

            var idTest = Guid.NewGuid();
            var empleadoIDTest = Guid.NewGuid();
            var horasRealizadaTest=  2;
            var millasTest = 1000;
            var origenTest = "SC";
            var destinoTest = "LP";

            var objHistorico = new HistoricoNavegacionDto();

            Assert.Equal(Guid.Empty, objHistorico.Id);
            Assert.Equal(Guid.Empty, objHistorico.EmpleadoID);
            Assert.Equal(0, objHistorico.HorasRealizada);
            Assert.Equal(0, objHistorico.Millas);
            Assert.Null(objHistorico.Origen);
            Assert.Null(objHistorico.Destino);

            objHistorico = new HistoricoNavegacionDto(idTest, empleadoIDTest, horasRealizadaTest, millasTest, origenTest, destinoTest);

            //objHistorico.Id = idTest;
            //objHistorico.EmpleadoID = empleadoIDTest;
            //objHistorico.HorasRealizada = horasRealizadaTest;
            //objHistorico.Millas = millasTest;
            //objHistorico.Origen = origenTest;
            //objHistorico.Destino = destinoTest;

            Assert.Equal(idTest, objHistorico.Id);
            Assert.Equal(empleadoIDTest, objHistorico.EmpleadoID);
            Assert.Equal(horasRealizadaTest, objHistorico.HorasRealizada);
            Assert.Equal(millasTest, objHistorico.Millas);
            Assert.Equal(origenTest, objHistorico.Origen);
            Assert.Equal(destinoTest, objHistorico.Destino);


        }
    }
}