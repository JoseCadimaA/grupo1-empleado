using Empleados.Application.UseCases.Command.Empleados.CrearEmpleado;
using Empleados.Application.UseCases.Command.Historicos.AddNavegacion;
using Empleados.Domain.Event;
using Empleados.Domain.Factories;
using Empleados.Domain.Model.Historico;
using Empleados.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Moq.It;

namespace EmpleadoTest.Application.UseCases.Handler
{
    public class AddNavegacionHandler_Test
    {
        private readonly Mock<IHistoricoNavegacionRepository> historicoRepository;
        private readonly Mock<ILogger<AddNavegacionHandler>> logger;
        private readonly Mock<IHistoricoNavegacionFactory> historicoFactory;
        private readonly Mock<IUnitOfWork> unitOfWork;

        private HistoricoNavegacion objHistoricoTest;
        //string empleadoID, int horasRealizada, int millas, string origen, string destino)
        private string empleadoID_Test = "60cfbed6-f6b2-42aa-a024-91e240555e1e";
        private int horasRealizada_Test = 4;
        private int millas_Test = 2000;
        private string origen_Test = "SC";
        private string destino_Test = "LP";

        public AddNavegacionHandler_Test()
        {
            historicoRepository = new Mock<IHistoricoNavegacionRepository>();
            logger = new Mock<ILogger<AddNavegacionHandler>>();
            historicoFactory = new Mock<IHistoricoNavegacionFactory>();
            unitOfWork = new Mock<IUnitOfWork>();

            objHistoricoTest = new HistoricoNavegacionFactory().Create("9166e2e7-d2a3-4b8a-9ab2-9e727d52e646", 2, 1000, "BE", "CH");
        }

        [Fact]
        public void CrearHistoricoHandler_HandleCorrectly()
        {
            //_empleadoService.Setup(empleadoService => empleadoService  .GenerarNroPedidoAsync()).Returns(Task.FromResult(nroPedidoTest));
            historicoFactory.Setup(historicoFactory => historicoFactory.Create(empleadoID_Test, horasRealizada_Test, millas_Test, origen_Test, destino_Test)).Returns(objHistoricoTest);

            var objHandler = new AddNavegacionHandler(
                historicoRepository.Object,
                logger.Object,
                historicoFactory.Object,
                unitOfWork.Object
            );
            var objRequest = new AddNavegacionCommand(empleadoID_Test, horasRealizada_Test, millas_Test, origen_Test, destino_Test);

            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);
            
            historicoRepository.Verify(mock => mock.RegistrarNavegacion(IsAny<HistoricoNavegacion>()), Times.Once);
            unitOfWork.Verify(mock => mock.Commit(), Times.Once);
            Assert.IsType<Guid>(result.Result);

            var domainEventList = (List<DomainEvent>)objHistoricoTest.DomainEvents;
            //Assert.Equal(1, domainEventList.Count);
            //Assert.IsType<HistoricoNavegacionCreado>(domainEventList[0]);
        }

        [Fact]
        public void CrearHistoricoHandler_Handle_Fail()
        {
            // Failing by returning null values
            var objHandler = new AddNavegacionHandler(
               historicoRepository.Object,
               logger.Object,
               historicoFactory.Object,
               unitOfWork.Object
           );
            var objRequest = new AddNavegacionCommand(empleadoID_Test, horasRealizada_Test, millas_Test, origen_Test, destino_Test  );
            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);

            logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear Historico"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);
        }
    }
}
