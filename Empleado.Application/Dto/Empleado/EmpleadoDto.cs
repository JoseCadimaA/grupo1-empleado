using System;

namespace Empleados.Application.Dto.Empleados {
    public class EmpleadoDto {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string CI { get; set; }

        public EmpleadoDto() {

        }
    }
}

