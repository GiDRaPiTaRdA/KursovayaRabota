using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticResourse;

namespace StringHelper.Exceptions
{
    public class BadNameFormatException:Exception
    {
        private string message;

        public BadNameFormatException()
        {
            Innitialize(StaticValues.badNameFormatExceptionExtendedMessage);
        }

        public BadNameFormatException(string additionalMessage)
        {
            Innitialize(additionalMessage);
        }

        private void Innitialize(string message)
        {
            this.message = StaticValues.badNameFormatExceptionMessage + ": " + message;
        }

        public override string Message => message;
    }
}
