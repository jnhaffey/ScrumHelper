using FluentAssertions;
using ScrumHelper.Core;
using ScrumHelper.Core.Exceptions;
using System;
using Xunit;

namespace ScrumHelper.BusinessLogic.Tests
{
	public class ConfigurationTests
	{
		private Configuration _configurationUnderTest;

		private const uint zero = 0;
		private const uint bottomLimit = 1;
		private const uint xSmallSize = 2;
		private const uint smallSize = 3;
		private const uint mediumSize = 5;
		private const uint largeSize = 8;
		private const uint xLargeSize = 13;
		private const uint topLimit = 21;

		private const string notInFibonacciSequenceMessage = "'0' is not part of the Fibonacci Sequence.";

		public ConfigurationTests()
		{
			_configurationUnderTest = new Configuration(xSmallSize, smallSize, mediumSize, largeSize, xLargeSize);
		}

		[Fact]
		public void Constructor()
		{
			_configurationUnderTest.XSmallTShirt.Should().Be(xSmallSize);
			_configurationUnderTest.SmallTShirt.Should().Be(smallSize);
			_configurationUnderTest.MediumTShirt.Should().Be(mediumSize);
			_configurationUnderTest.LargeTShirt.Should().Be(largeSize);
			_configurationUnderTest.XLargeTShirt.Should().Be(xLargeSize);
		}

		#region Invalid Value Tests

		[Fact]
		public void InValidValueForXSmallTShirt()
		{
			Action action = () => _configurationUnderTest.XSmallTShirt = zero;
			action.Should().Throw<NotInFibonacciSequenceException>().WithMessage(notInFibonacciSequenceMessage);
		}

		[Fact]
		public void InValidValueForSmallTShirt()
		{
			Action action = () => _configurationUnderTest.SmallTShirt = 0;
			action.Should().Throw<NotInFibonacciSequenceException>().WithMessage(notInFibonacciSequenceMessage);
		}

		[Fact]
		public void InValidValueForMediumTShirt()
		{
			Action action = () => _configurationUnderTest.MediumTShirt = 0;
			action.Should().Throw<NotInFibonacciSequenceException>().WithMessage(notInFibonacciSequenceMessage);
		}

		[Fact]
		public void InValidValueForLargeTShirt()
		{
			Action action = () => _configurationUnderTest.LargeTShirt = 0;
			action.Should().Throw<NotInFibonacciSequenceException>().WithMessage(notInFibonacciSequenceMessage);
		}

		[Fact]
		public void InValidValueForXLargeTShirt()
		{
			Action action = () => _configurationUnderTest.XLargeTShirt = 0;
			action.Should().Throw<NotInFibonacciSequenceException>().WithMessage(notInFibonacciSequenceMessage);
		}

		#endregion Invalid Value Tests

		#region X-Small T-Shirt Tests

		[Fact]
		public void XSmallTShirtSameAsSmallTShirt()
		{
			Action action = () => _configurationUnderTest.XSmallTShirt = smallSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"X-Small T-Shirt ({smallSize}) must be smaller than Small T-Shirt ({smallSize}).");
		}

		[Fact]
		public void XSmallTShirtLargerThanSmallTShirt()
		{
			Action action = () => _configurationUnderTest.XSmallTShirt = mediumSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"X-Small T-Shirt ({mediumSize}) must be smaller than Small T-Shirt ({smallSize}).");
		}

		#endregion X-Small T-Shirt Tests

		#region Small T-Shirt Tests

		[Fact]
		public void SmallTShirtLessThanXSmallTShirt()
		{
			Action action = () => _configurationUnderTest.SmallTShirt = bottomLimit;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Small T-Shirt ({bottomLimit}) must be larger than X-Small T-Shirt ({xSmallSize}) and smaller than Medium T-Shirt ({mediumSize}).");
		}

		[Fact]
		public void SmallTShirtSameAsXSmallTShirt()
		{
			Action action = () => _configurationUnderTest.SmallTShirt = xSmallSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Small T-Shirt ({xSmallSize}) must be larger than X-Small T-Shirt ({xSmallSize}) and smaller than Medium T-Shirt ({mediumSize}).");
		}

		[Fact]
		public void SmallTShirtSameAsMeduimTShirt()
		{
			Action action = () => _configurationUnderTest.SmallTShirt = mediumSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Small T-Shirt ({mediumSize}) must be larger than X-Small T-Shirt ({xSmallSize}) and smaller than Medium T-Shirt ({mediumSize}).");
		}

		[Fact]
		public void SmallTShirtLessThanMeduimTShirt()
		{
			Action action = () => _configurationUnderTest.SmallTShirt = largeSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Small T-Shirt ({largeSize}) must be larger than X-Small T-Shirt ({xSmallSize}) and smaller than Medium T-Shirt ({mediumSize}).");
		}

		#endregion Small T-Shirt Tests

		#region Medium T-Shirt Tests

		[Fact]
		public void MediumTShirtSmallerThanSmallTShirt()
		{
			Action action = () => _configurationUnderTest.MediumTShirt = xSmallSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Medium T-Shirt ({xSmallSize}) must be larger than Small T-Shirt ({smallSize}) and smaller than Large T-Shirt ({largeSize}).");
		}

		[Fact]
		public void MediumTShirtSameAsSmallTShirt()
		{
			Action action = () => _configurationUnderTest.MediumTShirt = smallSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Medium T-Shirt ({smallSize}) must be larger than Small T-Shirt ({smallSize}) and smaller than Large T-Shirt ({largeSize}).");
		}

		[Fact]
		public void MediumTShirtSameAsLargeTShirt()
		{
			Action action = () => _configurationUnderTest.MediumTShirt = largeSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Medium T-Shirt ({largeSize}) must be larger than Small T-Shirt ({smallSize}) and smaller than Large T-Shirt ({largeSize}).");
		}

		[Fact]
		public void MediumTShirtLargerThanLargeTShirt()
		{
			Action action = () => _configurationUnderTest.MediumTShirt = xLargeSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Medium T-Shirt ({xLargeSize}) must be larger than Small T-Shirt ({smallSize}) and smaller than Large T-Shirt ({largeSize}).");
		}

		#endregion Medium T-Shirt Tests

		#region Large T-Shirt Tests

		[Fact]
		public void LargeTShirtLessThanMeduimTShirt()
		{
			Action action = () => _configurationUnderTest.LargeTShirt = smallSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Large T-Shirt ({smallSize}) must be larger than Medium T-Shirt ({mediumSize}) and smaller than X-Large T-Shirt ({xLargeSize}).");
		}

		[Fact]
		public void LargeTShirtSameAsMeduimTShirt()
		{
			Action action = () => _configurationUnderTest.LargeTShirt = mediumSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Large T-Shirt ({mediumSize}) must be larger than Medium T-Shirt ({mediumSize}) and smaller than X-Large T-Shirt ({xLargeSize}).");
		}

		[Fact]
		public void largeTShirtSameAsXLargeTShirt()
		{
			Action action = () => _configurationUnderTest.LargeTShirt = xLargeSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Large T-Shirt ({xLargeSize}) must be larger than Medium T-Shirt ({mediumSize}) and smaller than X-Large T-Shirt ({xLargeSize}).");
		}

		[Fact]
		public void LargeTShirtLargerThanXLargeTShirt()
		{
			Action action = () => _configurationUnderTest.LargeTShirt = topLimit;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"Large T-Shirt ({topLimit}) must be larger than Medium T-Shirt ({mediumSize}) and smaller than X-Large T-Shirt ({xLargeSize}).");
		}

		#endregion Large T-Shirt Tests

		#region X-Large T-Shirt Tests

		[Fact]
		public void XLargeTShirtSmallerThanLargeTShirt()
		{
			Action action = () => _configurationUnderTest.XLargeTShirt = mediumSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"X-Large T-Shirt ({mediumSize}) must be larger than Large T-Shirt ({largeSize}).");
		}

		[Fact]
		public void XLargeTShirtSameAsLargeTShirt()
		{
			Action action = () => _configurationUnderTest.XLargeTShirt = largeSize;
			action.Should().Throw<OutOfSequenceException>().WithMessage($"X-Large T-Shirt ({largeSize}) must be larger than Large T-Shirt ({largeSize}).");
		}

		#endregion X-Large T-Shirt Tests
	}
}