using FluentAssertions;
using ScrumHelper.Core;
using System;
using Xunit;

namespace ScrumHelper.BusinessLogic.Tests
{
	public class FibonacciTests
	{
		[Fact]
		public void GenereateFromZero()
		{
			Action action = () => FibonacciSequence.GenerateUpToValue(0);
			action.Should().Throw<Exception>().WithMessage("Fibonacci Sequence starts at 1.");
		}

		[Theory]
		[InlineData(1, new uint[] { 1 })]
		[InlineData(2, new uint[] { 1, 2 })]
		[InlineData(3, new uint[] { 1, 2, 3 })]
		[InlineData(4, new uint[] { 1, 2, 3 })]
		[InlineData(5, new uint[] { 1, 2, 3, 5 })]
		[InlineData(6, new uint[] { 1, 2, 3, 5 })]
		[InlineData(7, new uint[] { 1, 2, 3, 5 })]
		[InlineData(8, new uint[] { 1, 2, 3, 5, 8 })]
		[InlineData(9, new uint[] { 1, 2, 3, 5, 8 })]
		[InlineData(10, new uint[] { 1, 2, 3, 5, 8 })]
		[InlineData(11, new uint[] { 1, 2, 3, 5, 8 })]
		[InlineData(12, new uint[] { 1, 2, 3, 5, 8 })]
		[InlineData(13, new uint[] { 1, 2, 3, 5, 8, 13 })]
		[InlineData(21, new uint[] { 1, 2, 3, 5, 8, 13, 21 })]
		[InlineData(22, new uint[] { 1, 2, 3, 5, 8, 13, 21 })]
		[InlineData(100, new uint[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 })]
		public void GenerateSequencesUpToValue(uint maxValue, uint[] expectedResults)
		{
			var test = FibonacciSequence.GenerateUpToValue(maxValue);
			test.Should().Equal(expectedResults);
		}

		[Theory]
		[InlineData(1, new uint[] { 1 })]
		[InlineData(2, new uint[] { 1, 2 })]
		[InlineData(3, new uint[] { 1, 2, 3 })]
		[InlineData(4, new uint[] { 1, 2, 3, 5 })]
		[InlineData(5, new uint[] { 1, 2, 3, 5, 8 })]
		[InlineData(6, new uint[] { 1, 2, 3, 5, 8, 13 })]
		[InlineData(7, new uint[] { 1, 2, 3, 5, 8, 13, 21 })]
		[InlineData(8, new uint[] { 1, 2, 3, 5, 8, 13, 21, 34 })]
		[InlineData(9, new uint[] { 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
		[InlineData(10, new uint[] { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 })]
		public void GenreateSequeencesUpToCount(uint maxCount, uint[] expectedResults)
		{
			var actualResult = FibonacciSequence.GenerateUpToCount(maxCount);
			actualResult.Should().Equal(expectedResults);
		}

		[Theory]
		[InlineData(1, true)]
		[InlineData(2, true)]
		[InlineData(3, true)]
		[InlineData(4, false)]
		[InlineData(5, true)]
		[InlineData(6, false)]
		[InlineData(7, false)]
		[InlineData(8, true)]
		[InlineData(9, false)]
		[InlineData(10, false)]
		public void IsValidSequenceValue(uint value, bool expectedResult)
		{
			FibonacciSequence.IsValidSequenceValue(value).Should().Be(expectedResult);
		}

		[Theory]
		[InlineData(1, 1, 2)]
		[InlineData(2, 2, 3)]
		[InlineData(3, 3, 5)]
		[InlineData(4, 3, 5)]
		[InlineData(5, 5, 8)]
		[InlineData(6, 5, 8)]
		[InlineData(7, 5, 8)]
		[InlineData(8, 8, 13)]
		[InlineData(9, 8, 13)]
		[InlineData(10, 8, 13)]
		[InlineData(11, 8, 13)]
		[InlineData(12, 8, 13)]
		[InlineData(13, 13, 21)]
		[InlineData(14, 13, 21)]
		public void GetClosesValues(uint value, uint expectedLower, uint expectedUpper)
		{
			var actualResults = FibonacciSequence.GetClosesValues(value);
			actualResults.lower.Should().Be(expectedLower);
			actualResults.upper.Should().Be(expectedUpper);
		}
	}
}