using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Domain.Model.TripulacionVuelo;
using Empleado.Domain.Event;
using Empleados.Domain.Event;
using ShareKernel.Core;
using ShareKernel.ValueObjects;

namespace Empleado.Domain.Model.Empleados {
    public class Empleado : AggregateRoot<Guid> {
        public EmpleadoNameValue NombreCompleto { get; set; }
        public EmpleadoFechaNacValue FechaNacimiento { get; set; }
        public EmpleadoCiValue CI { get; set; }

        private readonly ICollection<TripulacionVuelo> tripulacionVuelos;

        public IReadOnlyCollection<TripulacionVuelo> DetalleTripilacionVuelos {
            get {
                return new ReadOnlyCollection<TripulacionVuelo>(tripulacionVuelos.ToList());
            }
        }

        public Empleado(string nombreCompleto, DateTime fechaNacimiento, string ci) {
            Id = Guid.NewGuid();
            this.tripulacionVuelos = new List<TripulacionVuelo>();
            NombreCompleto = nombreCompleto;
            FechaNacimiento = fechaNacimiento;
            CI = ci;
        }

        public Empleado() {
            Id = Guid.NewGuid();
            this.tripulacionVuelos = new List<TripulacionVuelo>();

        }

        public void AgregarItem(Guid codTripulacion, Guid codEmpleado, string estadoTri, int activoTri) {

            var detalleTripulacion = tripulacionVuelos.FirstOrDefault(x => x.codTripulacion == codTripulacion);
            if (detalleTripulacion is null) {
                detalleTripulacion = new TripulacionVuelo(codTripulacion, codEmpleado, estadoTri, activoTri, Id);
                tripulacionVuelos.Add(detalleTripulacion);
            }
            else {
                detalleTripulacion.ModificarTripulacionVuelo(estadoTri, activoTri);
            }


            AddDomainEvent(new TripulacionCreado(detalleTripulacion, DateTime.Now));

        }

        public void RegistrarEmpleado() {
            var evento = new EmpleadoCreado(Id, CI);
            AddDomainEvent(evento);
        }

    }
}