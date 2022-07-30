using Empleados.Application.Services;
using Empleados.Application.UseCases.Command.Empleados.CrearEmpleado;
using Empleados.Domain.Factories;
using Empleados.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Empleados.Domain.Model.Empleado;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Empleados.Application.UseCases.Command.Empleados.AddEmpleado;
using System.Threading;
using static Moq.It;
using ShareKernel.Core;
using Empleados.Domain.Event;
using Empleados.Application.UseCases.Queries.Empleados.GetEmpleadoById;

namespace EmpleadoTest.Application.UseCases.Handler {
    public class AddEmpleadoHandler_Test {

        private readonly Mock<IEmpleadoRepository> empleadoRepository;
        private readonly Mock<ILogger<AddEmpleadoHandler>> logger;
        private readonly Mock<IEmpleadoFactory> empleadoFactory;
        private readonly Mock<IUnitOfWork> unitOfWork;

        private readonly Mock<ILogger<GetEmpleadoByIdQuery>> loggerGetEmpleado;

        private Empleados.Domain.Model.Empleado.Empleado objEmpleadoTest;
        private string nombreCompletoTest = "Pepe Cadima";
        private DateTime fechaNacimientoTest = new DateTime(1996, 10, 04);
        private string ciTest = "8137916";

        public AddEmpleadoHandler_Test() {
            empleadoRepository = new Mock<IEmpleadoRepository>();
            logger = new Mock<ILogger<AddEmpleadoHandler>>();
            empleadoFactory = new Mock<IEmpleadoFactory>();
            unitOfWork = new Mock<IUnitOfWork>();

            loggerGetEmpleado = new Mock<ILogger<GetEmpleadoByIdQuery>>();

            //objEmpleadoTest = new EmpleadoFactory().Create("Jose Cadima", new DateTime(1996, 10, 04), "8137917");

            objEmpleadoTest = new Empleados.Domain.Model.Empleado.Empleado("Jose Cadima", new DateTime(1996, 10, 04), "8137917");
        }


        [Fact]
        public void CrearEmpleadoHandler_HandleCorrectly() {
            //_empleadoService.Setup(empleadoService => empleadoService  .GenerarNroPedidoAsync()).Returns(Task.FromResult(nroPedidoTest));
            empleadoFactory.Setup(empleadoFactory => empleadoFactory.Create(nombreCompletoTest, fechaNacimientoTest, ciTest)).Returns(objEmpleadoTest);

            var objHandler = new AddEmpleadoHandler(
                empleadoRepository.Object,
                logger.Object,
                empleadoFactory.Object,
                unitOfWork.Object
            );
            var objRequest = new AddEmpleadoCommand(nombreCompletoTest, fechaNacimientoTest, ciTest);

            var tcs = new CancellationTokenSource(1000);
            var result = objHandler.Handle(objRequest, tcs.Token);

            empleadoRepository.Verify(mock => mock.CreateAsync(IsAny<Empleados.Domain.Model.Empleado.Empleado>()), Times.Once);
            unitOfWork.Verify(mock => mock.Commit(), Times.Once);
            Assert.IsType<Guid>(result.Result);

            var domainEventList = (List<DomainEvent>)objEmpleadoTest.DomainEvents;
            Assert.Equal(1, domainEventList.Count);
            Assert.IsType<EmpleadoCreado>(domainEventList[0]);



            // TESTING DE QUERIES EMPLEADOS
            var objetEmpleadoByIdHandler = new GetEmpleadoByIdHandler(
                empleadoRepository.Object,
                loggerGetEmpleado.Object
            );
            var objGetRequest = new GetEmpleadoByIdQuery(result.Result);
            var tcsGet = new CancellationTokenSource(1000);
            var resultGet = objetEmpleadoByIdHandler.Handle(objGetRequest, tcs.Token);

            Assert.Null(resultGet.Result);

        }

        //[Fact]
        //public void CrearEmpleadoHandler_Handle_Fail()
        //{
        //    // Failing by returning null values
        //    var objHandler = new AddEmpleadoHandler(
        //       empleadoRepository.Object,
        //       logger.Object,
        //       empleadoFactory.Object,
        //       unitOfWork.Object
        //   );
        //    var objRequest = new AddEmpleadoCommand(
        //      nombreCompletoTest, fechaNacimientoTest, ciTest
        //   );
        //    var tcs = new CancellationTokenSource(1000);
        //    var result = objHandler.Handle(objRequest, tcs.Token);
        //    logger.Verify(mock => mock.Log(
        //        It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
        //        It.Is<EventId>(eventId => eventId.Id == 0),
        //        It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear Empleado"),
        //        It.IsAny<Exception>(),
        //        It.IsAny<Func<It.IsAnyType, Exception, string>>())
        //    , Times.Once);
        //}
    }
}
