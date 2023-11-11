using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.UI.ExceptionRelated
{
    internal class InputFormatInvalidException : Exception
    {
        public InputFormatInvalidException()
        {
        }

        public InputFormatInvalidException(string? message) : base(message)
        {
        }

        public InputFormatInvalidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InputFormatInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
