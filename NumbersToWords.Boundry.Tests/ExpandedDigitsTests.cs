using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace NumbersToWords.Boundry.Tests
{
    [TestFixture]
    public class ExpandedDigitsTests
    {
        [TestCase(0,0,1)]
        [TestCase(0,2,0)]
        public void IsCompoundNumber_WhenNot_ShouldReturnFalse(int units, int tens, int hundreds)
        {
            //---------------Arrange-------------------
            var sut = new ExpandedDigits
            {
                Hundreds = hundreds,
                Tens = tens,
                Units = units
            };
            //---------------Act----------------------
            var actual = sut.IsCompoundNumber();
            //---------------Assert-----------------------
            actual.Should().BeFalse();
        }

        [TestCase(1, 2, 0)]
        [TestCase(5, 7, 0)]
        [TestCase(9, 9, 0)]
        public void IsCompoundNumber_WhenIs_ShouldReturnTrue(int units, int tens, int hundreds)
        {
            //---------------Arrange-------------------
            var sut = new ExpandedDigits
            {
                Hundreds = hundreds,
                Tens = tens,
                Units = units
            };
            //---------------Act----------------------
            var actual = sut.IsCompoundNumber();
            //---------------Assert-----------------------
            actual.Should().BeTrue();
        }

        [Test]
        public void IsTeenNumber_WhenIs10_ShouldReturnFalse()
        {
            //---------------Arrange-------------------
            var sut = new ExpandedDigits
            {
                Tens = 1,
                Units = 0
            };
            //---------------Act----------------------
            var actual = sut.IsTeenNumber();
            //---------------Assert-----------------------
            actual.Should().BeFalse();
        }

        [TestCase(1, 1)]
        [TestCase(1, 4)]
        [TestCase(1, 9)]
        public void IsTeenNumber_WhenIs11Through19_ShouldReturnTrue(int tens, int units)
        {
            //---------------Arrange-------------------
            var sut = new ExpandedDigits
            {
                Tens = tens,
                Units = units
            };
            //---------------Act----------------------
            var actual = sut.IsTeenNumber();
            //---------------Assert-----------------------
            actual.Should().BeTrue();
        }

        [Test]
        public void IsTeenNumber_WhenIs20_ShouldReturnFalse()
        {
            //---------------Arrange-------------------
            var sut = new ExpandedDigits
            {
                Tens = 2,
                Units = 0
            };
            //---------------Act----------------------
            var actual = sut.IsTeenNumber();
            //---------------Assert-----------------------
            actual.Should().BeFalse();
        }

        [TestCase(0)]
        [TestCase(7)]
        [TestCase(9)]
        public void IsSingleDigitNumber_When0Through9_ShouldReturnTrue(int units)
        {
            //---------------Arrange-------------------
            var sut = new ExpandedDigits
            {
                Units = units
            };
            //---------------Act----------------------
            var actual = sut.IsSingleDigitNumber();
            //---------------Assert-----------------------
            actual.Should().BeTrue();
        }

        [Test]
        public void IsSingleDigitNumber_WhenIs10_ShouldReturnFalse()
        {
            //---------------Arrange-------------------
            var sut = new ExpandedDigits
            {
                Tens = 1,
                Units = 0
            };
            //---------------Act----------------------
            var actual = sut.IsSingleDigitNumber();
            //---------------Assert-----------------------
            actual.Should().BeFalse();
        }

        [Test]
        public void CanCompressFourDigitNumberIntoThreeDigitNotation_WhenPossible_ShouldReturnTrue()
        {
            //---------------Arrange-------------------
            var sut = new ExpandedDigits
            {
                Thousands = 5,
                Hundreds = 3,
                Tens = 0,
                Units = 0
            };
            //---------------Act----------------------
            var actual = sut.CanCompressFourDigitNumberIntoThreeDigitNotation();
            //---------------Assert-----------------------
            actual.Should().BeTrue();
        }

        [Test]
        public void CanCompressFourDigitNumberIntoThreeDigitNotation_WhenNotPossible_ShouldReturnFalse()
        {
            //---------------Arrange-------------------
            var sut = new ExpandedDigits
            {
                Thousands = 0,
                Hundreds = 3,
                Tens = 0,
                Units = 0
            };
            //---------------Act----------------------
            var actual = sut.CanCompressFourDigitNumberIntoThreeDigitNotation();
            //---------------Assert-----------------------
            actual.Should().BeFalse();
        }
    }
}
