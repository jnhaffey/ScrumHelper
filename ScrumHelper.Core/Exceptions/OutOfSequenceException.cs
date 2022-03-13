using System.Runtime.Serialization;

namespace ScrumHelper.Core.Exceptions
{
	[Serializable]
	public class OutOfSequenceException : Exception
	{
		public OutOfSequenceException()
		{
		}

		public OutOfSequenceException(string? message) : base(message)
		{
		}

		public OutOfSequenceException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected OutOfSequenceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}