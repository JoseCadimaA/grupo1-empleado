using MediatR;
using System;
using System.Collections.Generic;

namespace Empleados.Application.UseCases.Command.Historicos.AddNavegacion
{
    public class AddNavegacionCommand : IRequest<Guid>
    {
        private AddNavegacionCommand() { }

        public AddNavegacionCommand(string empleadoID, int horasRealizada, int millas, string origen, string destino)
        {
            EmpleadoID = empleadoID;
            HorasRealizada = horasRealizada;
            Millas = millas;
            Origen = origen;
            Destino = destino;
        }

        public string EmpleadoID { get; set; }
        public int HorasRealizada { get; set; }
        public int Millas { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }

    }
}
