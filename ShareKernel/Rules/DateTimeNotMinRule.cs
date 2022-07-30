using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.Rules {
    public class DateTimeNotMinRule : IBussinessRule {
        private readonly DateTime _value;

        public DateTimeNotMinRule(DateTime value) {
            _value = value;
        }

        public string Message => "DateTime cannot be Min value";

        public bool IsValid() {
            return _value != DateTime.MinValue;
        }
    }
}
