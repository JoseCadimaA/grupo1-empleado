using Empleados.Domain.Model.Historico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Domain.Factories
{
    public class HistoricoNavegacionFactory : IHistoricoNavegacionFactory
    {
        public HistoricoNavegacion Create(Guid empleadoID, int horasRealizada, int millas, string origen, string destino)
        {
            return new HistoricoNavegacion(empleadoID, horasRealizada, millas, origen, destino);
        }
    }
}
