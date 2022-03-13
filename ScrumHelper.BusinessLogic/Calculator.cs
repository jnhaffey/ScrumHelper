using ScrumHelper.Core;

namespace ScrumHelper.BusinessLogic
{
	public class Calculator
	{
		private readonly Configuration config;

		public Calculator(Configuration config)
		{
			this.config = config;
		}

		public uint GenerateStoryPointValue(TShirtSizes complexity, TShirtSizes uncertainty, TShirtSizes effort)
		{
			var complexityValue = GetPointValue(complexity);
			var uncertaintyValue = GetPointValue(uncertainty);
			var effortValue = GetPointValue(effort);
			var averageValue = (complexityValue + uncertaintyValue + effortValue) / 3;
			var closedValues = FibonacciSequence.GetClosesValues(averageValue);
			var thresholdValue = closedValues.lower + ((closedValues.upper - closedValues.lower) * config.PointThreshold);
			return averageValue >= thresholdValue ? closedValues.upper : closedValues.lower;
		}

		private uint GetPointValue(TShirtSizes shirtSize)
		{
			switch (shirtSize)
			{
				case TShirtSizes.X_Small:
					return config.XSmallTShirt;

				case TShirtSizes.Small:
					return config.SmallTShirt;

				case TShirtSizes.Medium:
					return config.MediumTShirt;

				case TShirtSizes.Large:
					return config.LargeTShirt;

				case TShirtSizes.X_Large:
					return config.XLargeTShirt;

				default:
					return 0;
			}
		}
	}
}