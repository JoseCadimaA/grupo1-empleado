using Empleados.Domain.Model.Historico;

namespace Empleados.Domain.Factories {
    public interface IHistoricoNavegacionFactory {
        HistoricoNavegacion Create(string empleadoID, int horasRealizada, int millas, string origen, string destino);
    }
}
