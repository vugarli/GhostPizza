using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GhostPizza.InfraStructure.Exceptions
{
	internal class PizzaNotFoundException : Exception
	{
		public PizzaNotFoundException()
		{
		}

		public PizzaNotFoundException(string? message) : base(message)
		{
		}

		public PizzaNotFoundException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected PizzaNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
