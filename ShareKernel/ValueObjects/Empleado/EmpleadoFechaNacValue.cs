using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.ValueObjects
{
    public record EmpleadoFechaNacValue : ValueObject
    {
        public DateTime FechaNacimiento { get; }

        public EmpleadoFechaNacValue(DateTime fechaNacimiento)
        {
            CheckRule(new DateTimeNotMinRule(fechaNacimiento));
            if(fechaNacimiento <= new DateTime(1902, 01, 01))
            {
                throw new BussinessRuleValidationException("EmpleadoFechaNacValue no puede haber nacido antes de 1902");
            }
            FechaNacimiento = fechaNacimiento;
        }

        public static implicit operator DateTime(EmpleadoFechaNacValue value)
        {
            return value.FechaNacimiento;
        }

        public static implicit operator EmpleadoFechaNacValue(DateTime fechaNacimiento)
        {
            return new EmpleadoFechaNacValue(fechaNacimiento);
        }
    }
}
