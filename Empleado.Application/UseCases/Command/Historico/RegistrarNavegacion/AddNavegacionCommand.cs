using MediatR;
using System;
using System.Collections.Generic;

namespace Empleados.Application.UseCases.Command.Historico.AddNavegacionCommand
{
    public class AddNavegacionCommand : IRequest<Guid>
    {
        private AddNavegacionCommand() { }

        public AddNavegacionCommand(Guid empleadoID, int horasRealizada, int millas, string origen, string destino)
        {
            EmpleadoID = empleadoID;
            HorasRealizada = horasRealizada;
            Millas = millas;
            Origen = origen;
            Destino = destino;
        }

        public Guid EmpleadoID { get; set; }
        public int HorasRealizada { get; set; }
        public int Millas { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }

    }
}
