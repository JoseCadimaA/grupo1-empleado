using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.ValueObjects {
    public record HistoricoOrigenValue : ValueObject {
        public string Ci { get; }

        public HistoricoOrigenValue(string ci) {
            CheckRule(new StringNotNullOrEmptyRule(ci));
            if (ci.Length > 10) {
                throw new BussinessRuleValidationException("HistoricoOrigenValue no puede tener mas de 10 caracteres");
            }
            Ci = ci;
        }

        public static implicit operator string(HistoricoOrigenValue value) {
            return value.Ci;
        }

        public static implicit operator HistoricoOrigenValue(string ci) {
            return new HistoricoOrigenValue(ci);
        }
    }
}

