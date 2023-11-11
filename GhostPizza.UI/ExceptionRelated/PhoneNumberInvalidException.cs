using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.UI.ExceptionRelated
{
    public class PhoneNumberInvalidException : Exception
    {
        public PhoneNumberInvalidException()
        {
        }

        public PhoneNumberInvalidException(string? message) : base(message)
        {
        }

        public PhoneNumberInvalidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PhoneNumberInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
