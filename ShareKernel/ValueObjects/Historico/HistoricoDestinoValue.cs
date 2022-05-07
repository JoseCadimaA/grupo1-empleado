using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.ValueObjects
{
    public record HistoricoDestinoValue : ValueObject
    {
        public string Ci { get; }

        public HistoricoDestinoValue(string ci)
        {
            CheckRule(new StringNotNullOrEmptyRule(ci));
            if (ci.Length > 10)
            {
                throw new BussinessRuleValidationException("HistoricoDestinoValue no puede tener mas de 10 caracteres");
            }
            Ci = ci;
        }

        public static implicit operator string(HistoricoDestinoValue value)
        {
            return value.Ci;
        }

        public static implicit operator HistoricoDestinoValue(string ci)
        {
            return new HistoricoDestinoValue(ci);
        }
    }
}

