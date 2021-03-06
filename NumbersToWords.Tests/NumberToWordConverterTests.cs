﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NumbersToWords.Tests
{
    [TestFixture]
    public class NumberToWordConverterTests
    {
        [TestCase(0, "zero")]
        [TestCase(1, "one")]
        [TestCase(2, "two")]
        [TestCase(3, "three")]
        [TestCase(4, "four")]
        [TestCase(5, "five")]
        [TestCase(6, "six")]
        [TestCase(7, "seven")]
        [TestCase(8, "eight")]
        [TestCase(9, "nine")]
        public void ConvertToWords_WhenSingleDigitNumber_ShouldConvert(int input, string expected)
        {
            //---------------Arrange-------------------
            var sut = CreateNumberToWordConverter();
            //---------------Act----------------------
            var actual = sut.ConvertToWords(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(11, "eleven")]
        [TestCase(12, "twelve")]
        [TestCase(13, "thirteen")]
        [TestCase(14, "fourteen")]
        [TestCase(15, "fifteen")]
        [TestCase(16, "sixteen")]
        [TestCase(17, "seventeen")]
        [TestCase(18, "eighteen")]
        [TestCase(19, "nineteen")]
        public void ConvertToWords_WhenTwoDigitNumberDivisible11Through19_ShouldConvert(int input, string expected)
        {
            //---------------Arrange-------------------
            var sut = CreateNumberToWordConverter();
            //---------------Act----------------------
            var actual = sut.ConvertToWords(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, "ten")]
        [TestCase(20, "twenty")]
        [TestCase(30, "thirty")]
        [TestCase(40, "fourty")]
        [TestCase(50, "fifty")]
        [TestCase(60, "sixty")]
        [TestCase(70, "seventy")]
        [TestCase(80, "eighty")]
        [TestCase(90, "ninety")]
        public void ConvertToWords_WhenTwoDigitNumberDivisibleBy10_ShouldConvert(int input, string expected)
        {
            //---------------Arrange-------------------
            var sut = CreateNumberToWordConverter();
            //---------------Act----------------------
            var actual = sut.ConvertToWords(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(21, "twenty-one")]
        [TestCase(54, "fifty-four")]
        [TestCase(99, "ninety-nine")]
        public void ConvertToWords_WhenCompoundNumber_ShouldConvert(int input, string expected)
        {
            //---------------Arrange-------------------
            var sut = CreateNumberToWordConverter();
            //---------------Act----------------------
            var actual = sut.ConvertToWords(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, "one hundred")]
        [TestCase(300, "three hundred")]
        [TestCase(900, "nine hundred")]
        public void ConvertToWords_WhenThreeDigitNumberDivisibleBy10_ShouldConvert(int input, string expected)
        {
            //---------------Arrange-------------------
            var sut = CreateNumberToWordConverter();
            //---------------Act----------------------
            var actual = sut.ConvertToWords(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(101, "one hundred one")]
        [TestCase(420, "four hundred twenty")]
        [TestCase(877, "eight hundred seventy-seven")]
        public void ConvertToWords_WhenThreeDigitNumberNotDivisibleBy10_ShouldConvert(int input, string expected)
        {
            //---------------Arrange-------------------
            var sut = CreateNumberToWordConverter();
            //---------------Act----------------------
            var actual = sut.ConvertToWords(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1000, "one thousand")]
        [TestCase(5000, "five thousand")]
        [TestCase(9000, "nine thousand")]
        public void ConvertToWords_WhenFourDigitNumberDivisibleBy1000WithSingleDigitResult_ShouldConvert(int input, string expected)
        {
            //---------------Arrange-------------------
            var sut = CreateNumberToWordConverter();
            //---------------Act----------------------
            var actual = sut.ConvertToWords(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1001, "one thousand one")]
        [TestCase(2013, "two thousand thirteen")]
        [TestCase(3020, "three thousand twenty")]
        [TestCase(9999, "nine thousand nine hundred ninety-nine")]
        public void ConvertToWords_WhenFourDigitNumberNotDivisibleBy10_ShouldConvert(int input, string expected)
        {
            //---------------Arrange-------------------
            var sut = CreateNumberToWordConverter();
            //---------------Act----------------------
            var actual = sut.ConvertToWords(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5300, "fifty-three hundred")]
        [TestCase(2200, "twenty-two hundred")]
        public void ConvertToWords_WhenFourDigitNumberDivisibleBy1000WithM_ShouldConvert(int input, string expected)
        {
            //---------------Arrange-------------------
            var sut = CreateNumberToWordConverter();
            //---------------Act----------------------
            var actual = sut.ConvertToWords(input);
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        private static NumberToWordConverter CreateNumberToWordConverter()
        {
            var digitExpandor = new DigitExpandor();
            var sut = new NumberToWordConverter(digitExpandor);
            return sut;
        }
    }
}
