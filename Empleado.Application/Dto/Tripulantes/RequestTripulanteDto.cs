using System;
using System.Collections.Generic;

namespace Empleado.Application.Dto.Tripulantes {
    public class RequestTripulanteDto {

        public Guid codVuelo { get; set; }
        public List<TripulacionDto> listTripulacionesDto { get; set; }
    }
}
