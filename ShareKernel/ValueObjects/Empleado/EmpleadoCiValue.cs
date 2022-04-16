using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.ValueObjects
{
    public record EmpleadoCiValue : ValueObject
    {
        public string Ci { get; }

        public EmpleadoCiValue(string ci)
        {
            CheckRule(new StringNotNullOrEmptyRule(ci));
            if(ci.Length > 10)
            {
                throw new BussinessRuleValidationException("EmpleadoCiValue no puede tener mas de 10 caracteres");
            }
            Ci = ci;
        }

        public static implicit operator string(EmpleadoCiValue value)
        {
            return value.Ci;
        }

        public static implicit operator EmpleadoCiValue(string ci)
        {
            return new EmpleadoCiValue(ci);
        }
    }
}
