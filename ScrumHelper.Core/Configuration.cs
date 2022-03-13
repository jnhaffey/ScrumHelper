using ScrumHelper.Core.Exceptions;

namespace ScrumHelper.Core
{
	public class Configuration
	{
		private uint _xSmallShirt;
		private uint _smallShirt;
		private uint _mediumShirt;
		private uint _largeShirt;
		private uint _xLargeShirt;
		private decimal _threshold = 0.5m;

		public Configuration(uint xSmallShirt, uint smallShirt, uint mediumShirt, uint largeShirt, uint xLargeShirt)
		{
			XLargeTShirt = xLargeShirt;
			LargeTShirt = largeShirt;
			MediumTShirt = mediumShirt;
			SmallTShirt = smallShirt;
			XSmallTShirt = xSmallShirt;
		}

		public uint XSmallTShirt
		{
			get { return _xSmallShirt; }
			set
			{
				if (!FibonacciSequence.IsValidSequenceValue(value))
				{
					throw new NotInFibonacciSequenceException(value);
				}
				if (value >= SmallTShirt)
				{
					throw new OutOfSequenceException($"X-Small T-Shirt ({value}) must be smaller than Small T-Shirt ({SmallTShirt}).");
				}
				_xSmallShirt = value;
			}
		}

		public uint SmallTShirt
		{
			get { return _smallShirt; }
			set
			{
				if (!FibonacciSequence.IsValidSequenceValue(value))
				{
					throw new NotInFibonacciSequenceException(value);
				}
				if (XSmallTShirt >= value || value >= MediumTShirt)
				{
					throw new OutOfSequenceException($"Small T-Shirt ({value}) must be larger than X-Small T-Shirt ({XSmallTShirt}) and smaller than Medium T-Shirt ({MediumTShirt}).");
				}
				_smallShirt = value;
			}
		}

		public uint MediumTShirt
		{
			get { return _mediumShirt; }
			set
			{
				if (!FibonacciSequence.IsValidSequenceValue(value))
				{
					throw new NotInFibonacciSequenceException(value);
				}
				if (SmallTShirt >= value || value >= LargeTShirt)
				{
					throw new OutOfSequenceException($"Medium T-Shirt ({value}) must be larger than Small T-Shirt ({SmallTShirt}) and smaller than Large T-Shirt ({LargeTShirt}).");
				}
				_mediumShirt = value;
			}
		}

		public uint LargeTShirt
		{
			get { return _largeShirt; }
			set
			{
				if (!FibonacciSequence.IsValidSequenceValue(value))
				{
					throw new NotInFibonacciSequenceException(value);
				}
				if (MediumTShirt >= value || value >= XLargeTShirt)
				{
					throw new OutOfSequenceException($"Large T-Shirt ({value}) must be larger than Medium T-Shirt ({MediumTShirt}) and smaller than X-Large T-Shirt ({XLargeTShirt}).");
				}
				_largeShirt = value;
			}
		}

		public uint XLargeTShirt
		{
			get { return _xLargeShirt; }
			set
			{
				if (!FibonacciSequence.IsValidSequenceValue(value))
				{
					throw new NotInFibonacciSequenceException(value);
				}
				if (LargeTShirt >= value)
				{
					throw new OutOfSequenceException($"X-Large T-Shirt ({value}) must be larger than Large T-Shirt ({LargeTShirt}).");
				}
				_xLargeShirt = value;
			}
		}

		public decimal PointThreshold
		{
			get => _threshold;
			set
			{
				if (value < 0) throw new Exception();
				if (value > 1) throw new Exception();
				_threshold = value;
			}
		}
	}
}