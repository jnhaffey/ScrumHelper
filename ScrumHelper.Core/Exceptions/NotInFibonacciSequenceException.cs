using System.Runtime.Serialization;

namespace ScrumHelper.Core.Exceptions
{
	[Serializable]
	public class NotInFibonacciSequenceException : Exception
	{
		public NotInFibonacciSequenceException(uint value) : base($"'{value}' is not part of the Fibonacci Sequence.")
		{
		}

		public NotInFibonacciSequenceException(string? message) : base(message)
		{
		}

		public NotInFibonacciSequenceException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected NotInFibonacciSequenceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}