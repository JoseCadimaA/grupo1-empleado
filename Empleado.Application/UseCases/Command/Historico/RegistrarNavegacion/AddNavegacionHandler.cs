using MediatR;
using Microsoft.Extensions.Logging;
using Empleados.Application.Services;
using Empleados.Domain.Factories;
using Empleados.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Empleados.Domain.Model.Historico;
using Empleados.Application.UseCases.Command.Historico.AddNavegacionCommand;

namespace Empleados.Application.UseCases.Command.Empleados.CrearEmpleado
{
    public class AddNavegacionHandler : IRequestHandler<AddNavegacionCommand, Guid>
    {
        private readonly IHistoricoNavegacionRepository _historicoRepository;
        private readonly ILogger<AddNavegacionHandler> _logger;
        private readonly IHistoricoNavegacionService _historicoService;
        private readonly IHistoricoNavegacionFactory _historicoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public AddNavegacionHandler(IHistoricoNavegacionRepository historicoRepository, ILogger<AddNavegacionHandler> logger,
            IHistoricoNavegacionService historicoService, IHistoricoNavegacionFactory historicoFactory, IUnitOfWork unitOfWork)
        {
            _historicoRepository = historicoRepository;
            _logger = logger;
            _historicoService = historicoService;
            _historicoFactory = historicoFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(AddNavegacionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                HistoricoNavegacion objHistorico = _historicoFactory.Create(request.EmpleadoID, request.HorasRealizada, request.Millas, request.Origen, request.Destino);
                          

                await _historicoRepository.RegistrarNavegacion(objHistorico);

                await _unitOfWork.Commit();

                return objHistorico.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear HistoricoNavegacion");
            }
            return Guid.Empty;
        }
    }
}
