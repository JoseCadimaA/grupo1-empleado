using System;
using ShareKernel.Core;

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
