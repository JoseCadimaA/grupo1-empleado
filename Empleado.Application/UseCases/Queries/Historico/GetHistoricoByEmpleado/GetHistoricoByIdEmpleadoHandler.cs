using MediatR;
using Microsoft.Extensions.Logging;
using Empleados.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Empleado.Application.Dto.Historicos;
using Empleados.Domain.Model.Historico;

namespace Empleados.Application.UseCases.Queries.Empleados.GetHistoricoByIdEmpleado {
    public class GetHistoricoByIdEmpleadoHandler : IRequestHandler<GetHistoricoByIdEmpleadoQuery, HistoricoNavegacionDto> {
        private readonly IHistoricoNavegacionRepository _historicoRepository;
        private readonly ILogger<GetHistoricoByIdEmpleadoQuery> _logger;

        public GetHistoricoByIdEmpleadoHandler(IHistoricoNavegacionRepository historicoRepository, ILogger<GetHistoricoByIdEmpleadoQuery> logger) {
            _historicoRepository = historicoRepository;
            _logger = logger;
        }

        public async Task<HistoricoNavegacionDto> Handle(GetHistoricoByIdEmpleadoQuery request, CancellationToken cancellationToken) {
            HistoricoNavegacionDto result = null;
            try {
                HistoricoNavegacion objHistorico = await _historicoRepository.FindByFKAsync(request.EmpleadoID);

                result = new HistoricoNavegacionDto() {
                    Id = objHistorico.Id,
                    EmpleadoID = objHistorico.EmpleadoID,
                    HorasRealizada = objHistorico.HorasRealizada,
                    Millas = objHistorico.Millas,
                    Origen = objHistorico.Origen,
                    Destino = objHistorico.Destino

                };
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error al obtener Empleado con id: { EmpleadoId }", request.Id);
            }

            return result;
        }
    }
}
