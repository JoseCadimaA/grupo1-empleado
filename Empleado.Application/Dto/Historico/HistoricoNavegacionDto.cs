using Empleados.Domain.Model.Historico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleado.Application.Dto.Historicos {
    public class HistoricoNavegacionDto {
        public Guid Id { get; set; }
        public string EmpleadoID { get; set; }
        public int HorasRealizada { get; set; }
        public int Millas { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }

        public HistoricoNavegacionDto(Guid id, string empleadoID, int horasRealizada, int millas, string origen, string destino) {
            Id = id;
            EmpleadoID = empleadoID;
            HorasRealizada = horasRealizada;
            Millas = millas;
            Origen = origen;
            Destino = destino;
        }

        public HistoricoNavegacionDto() {
        }
    }
}
