using Empleados.Domain.Model.Historico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Domain.Factories {
    public interface IHistoricoNavegacionFactory {
        HistoricoNavegacion Create(string empleadoID, int horasRealizada, int millas, string origen, string destino);
    }
}
