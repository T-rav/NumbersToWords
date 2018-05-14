using FluentAssertions;
using NumbersToWords.Boundry;
using NUnit.Framework;

namespace NumbersToWords.Tests
{
    [TestFixture]
    public class DigitExpandorTests
    {
        [Test]
        public void Expand_WhenSingleDigitNumber_ShouldReturnUnitsPopulated()
        {
            //---------------Arrange-------------------
            var input = 5;
            var sut = new DigitExpandor();
            //---------------Act----------------------
            var actual = sut.Expand(input);
            //---------------Assert-----------------------
            var expected = new ExpandedDigits
            {
                Units = 5
            };
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Expand_WhenDoubleDigitNumber_ShouldReturnTensAndUnitsPopulated()
        {
            //---------------Arrange-------------------
            var input = 39;
            var sut = new DigitExpandor();
            //---------------Act----------------------
            var actual = sut.Expand(input);
            //---------------Assert-----------------------
            var expected = new ExpandedDigits
            {
                Units = 9,
                Tens = 3
            };
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Expand_WhenTrippleDigitNumber_ShouldReturnHundredsAndTensAndUnitsPopulated()
        {
            //---------------Arrange-------------------
            var input = 270;
            var sut = new DigitExpandor();
            //---------------Act----------------------
            var actual = sut.Expand(input);
            //---------------Assert-----------------------
            var expected = new ExpandedDigits
            {
                Units = 0,
                Tens = 7,
                Hundreds = 2
            };
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Expand_WhenFourDigitNumber_ShouldReturnThousandsAndHundredsAndTensAndUnitsPopulated()
        {
            //---------------Arrange-------------------
            var input = 5023;
            var sut = new DigitExpandor();
            //---------------Act----------------------
            var actual = sut.Expand(input);
            //---------------Assert-----------------------
            var expected = new ExpandedDigits
            {
                Units = 3,
                Tens = 2,
                Hundreds = 0,
                Thousands = 5
            };
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetTensValue_WhenPopulated_ShouldReturnTensDigitMultipledBy10()
        {
            //---------------Arrange-------------------
            var input = 35;
            var sut = new DigitExpandor();
            //---------------Act----------------------
            var actual = sut.Expand(input);
            //---------------Assert-----------------------
            var expected = 30;
            actual.GetTensValue().Should().Be(expected);
        }

        [Test]
        public void GetHundredsValue_WhenPopulated_ShouldReturnHundredsDigitMultipledBy100()
        {
            //---------------Arrange-------------------
            var input = 823;
            var sut = new DigitExpandor();
            //---------------Act----------------------
            var actual = sut.Expand(input);
            //---------------Assert-----------------------
            var expected = 800;
            actual.GetHundredsValue().Should().Be(expected);
        }

        [Test]
        public void GetThousandsValue_WhenPopulated_ShouldReturnThousandsDigitMultipledBy1000()
        {
            //---------------Arrange-------------------
            var input = 4852;
            var sut = new DigitExpandor();
            //---------------Act----------------------
            var actual = sut.Expand(input);
            //---------------Assert-----------------------
            var expected = 4000;
            actual.GetThousandsValue().Should().Be(expected);
        }
    }
}
