namespace ScrumHelper.Core
{
	public static class FibonacciSequence
	{
		public static List<uint> GenerateUpToValue(uint maxValue)
		{
			if (maxValue == 0)
				throw new Exception("Fibonacci Sequence starts at 1.");

			var sequence = new List<uint> { 1 };
			uint i = 2;
			while (i <= maxValue)
			{
				sequence.Add(i);
				i = sequence[sequence.Count - 1] + sequence[sequence.Count - 2];
			};
			return sequence;
		}

		public static List<uint> GenerateUpToCount(uint maxCount)
		{
			if (maxCount == 0)
				throw new Exception("Fibonacci Sequence starts with 1 value.");

			var sequence = new List<uint> { 1 };
			uint v = 2;
			for (var i = 1; i < maxCount; i++)
			{
				sequence.Add(v);
				v = sequence[sequence.Count - 1] + sequence[sequence.Count - 2];
			}
			return sequence;
		}

		public static bool IsValidSequenceValue(uint value)
		{
			var sequence = GenerateUpToValue(value + 1);
			return sequence.Contains(value);
		}

		public static (uint lower, uint upper) GetClosesValues(uint value)
		{
			var sequenceToValue = GenerateUpToValue(value);
			var finalSequence = GenerateUpToCount(Convert.ToUInt32(sequenceToValue.Count() + 1));
			var lower = finalSequence[finalSequence.Count - 2];
			var upper = finalSequence[finalSequence.Count - 1];
			if (lower <= value && value < upper) return (lower, upper);
			throw new Exception("Invalid calulation.");
		}
	}
}