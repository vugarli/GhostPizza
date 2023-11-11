using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.Core.Exceptions
{
    public class InvalidUserNameException : Exception
    {
        public InvalidUserNameException()
        {
        }

        public InvalidUserNameException(string? message) : base(message)
        {
        }

        public InvalidUserNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidUserNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    
}

