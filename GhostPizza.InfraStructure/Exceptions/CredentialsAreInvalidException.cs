using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.InfraStructure.Exceptions
{
	internal class CredentialsAreInvalidException : Exception
	{
		public CredentialsAreInvalidException()
		{
		}

		public CredentialsAreInvalidException(string? message) : base(message)
		{
		}

		public CredentialsAreInvalidException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected CredentialsAreInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
