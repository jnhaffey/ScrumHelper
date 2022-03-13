using FluentAssertions;
using ScrumHelper.Core;
using Xunit;

namespace ScrumHelper.BusinessLogic.Tests
{
	public class CalculatorTests
	{
		private Configuration _configuration;
		private Calculator _calulatorUnderTest;
		private const uint xSmallSize = 2;
		private const uint smallSize = 3;
		private const uint mediumSize = 5;
		private const uint largeSize = 8;
		private const uint xLargeSize = 13;

		public CalculatorTests()
		{
			_configuration = new Configuration(xSmallSize, smallSize, mediumSize, largeSize, xLargeSize);
			_calulatorUnderTest = new Calculator(_configuration);
		}

		[Theory]
		[InlineData(TShirtSizes.X_Small, TShirtSizes.X_Small, TShirtSizes.X_Small, xSmallSize)]
		[InlineData(TShirtSizes.Small, TShirtSizes.Small, TShirtSizes.Small, smallSize)]
		[InlineData(TShirtSizes.Medium, TShirtSizes.Medium, TShirtSizes.Medium, mediumSize)]
		[InlineData(TShirtSizes.Large, TShirtSizes.Large, TShirtSizes.Large, largeSize)]
		[InlineData(TShirtSizes.X_Large, TShirtSizes.X_Large, TShirtSizes.X_Large, xLargeSize)]
		public void AllValuesSame(TShirtSizes complexityValue, TShirtSizes uncertaintyValue, TShirtSizes effortValue, uint expectedResult)
		{
			var actualResult = _calulatorUnderTest.GenerateStoryPointValue(complexityValue, uncertaintyValue, effortValue);
			actualResult.Should().Be(expectedResult);
		}

		[Theory]
		[InlineData(TShirtSizes.X_Small, TShirtSizes.Small, TShirtSizes.Medium, smallSize)]
		[InlineData(TShirtSizes.X_Small, TShirtSizes.Medium, TShirtSizes.X_Large, mediumSize)]
		[InlineData(TShirtSizes.X_Small, TShirtSizes.X_Small, TShirtSizes.X_Large, mediumSize)]
		[InlineData(TShirtSizes.X_Small, TShirtSizes.X_Large, TShirtSizes.X_Large, largeSize)]
		[InlineData(TShirtSizes.Medium, TShirtSizes.Large, TShirtSizes.X_Large, largeSize)]
		public void GenerateStoryPointValue(TShirtSizes complexityValue, TShirtSizes uncertaintyValue, TShirtSizes effortValue, uint expectedResult)
		{
			var actualResult = _calulatorUnderTest.GenerateStoryPointValue(complexityValue, uncertaintyValue, effortValue);
			actualResult.Should().Be(expectedResult);
		}
	}
}