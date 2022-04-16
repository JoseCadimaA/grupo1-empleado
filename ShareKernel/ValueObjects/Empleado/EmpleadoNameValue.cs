using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.ValueObjects
{
    public record EmpleadoNameValue : ValueObject
    {
        public string Name { get; }

        public EmpleadoNameValue(string name)
        {
            CheckRule(new StringNotNullOrEmptyRule(name));
            if(name.Length > 500)
            {
                throw new BussinessRuleValidationException("EmpleadoNameValue no puede tener mas de 500 caracteres");
            }
            Name = name;
        }

        public static implicit operator string(EmpleadoNameValue value)
        {
            return value.Name;
        }

        public static implicit operator EmpleadoNameValue(string name)
        {
            return new EmpleadoNameValue(name);
        }
    }
}
