using Empleados.Domain.Model.Historico;

namespace Empleados.Domain.Factories {
    public class HistoricoNavegacionFactory : IHistoricoNavegacionFactory {
        public HistoricoNavegacion Create(string empleadoID, int horasRealizada, int millas, string origen, string destino) {
            return new HistoricoNavegacion(empleadoID, horasRealizada, millas, origen, destino);
        }
    }
}
