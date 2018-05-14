using System.Collections.Generic;
using NumbersToWords.Boundry;

namespace NumbersToWords
{
    public class NumberToWordConverter
    {
        private readonly DigitExpandor _digitExpandor;

        private const string NumberNotFound = "";

        public NumberToWordConverter(DigitExpandor digitExpandor)
        {
            _digitExpandor = digitExpandor;
        }

        public string ConvertToWords(int number)
        {
            var expandedDigits = _digitExpandor.Expand(number);

            var result = GetFourDigitNumber(expandedDigits) 
                         + GetThreeDigitNumber(expandedDigits) 
                         + GetTwoDigitNumber(expandedDigits) 
                         + GetGatedSingleDigitNumber(expandedDigits);

            return result.Trim();
        }

        private string GetFourDigitNumber(ExpandedDigits expandedDigits)
        {
            if (expandedDigits.Thousands == 0) return NumberNotFound;

            if (expandedDigits.CanCompressFourDigitNumberIntoThreeDigitNotation())
            {
                var compressedDigits = new ExpandedDigits {Tens = expandedDigits.Thousands, Units = expandedDigits.Hundreds};
                var compressionResult = GetTwoDigitNumber(compressedDigits) + GetSingleDigitNumber(compressedDigits.Units);
                return compressionResult + " hundred";
            }

            return GetSingleDigitNumber(expandedDigits.Thousands) + " thousand ";
        }

        private static bool FourDigitNumberCanCompressToThreeDigitNotation(ExpandedDigits expandedDigits)
        {
            return expandedDigits.Hundreds > 0 && expandedDigits.Tens == 0 && expandedDigits.Units == 0;
        }

        private string GetThreeDigitNumber(ExpandedDigits expandedDigits)
        {
            if (expandedDigits.Hundreds == 0 || expandedDigits.CanCompressFourDigitNumberIntoThreeDigitNotation())
            {
                return NumberNotFound;
            }

            return GetSingleDigitNumber(expandedDigits.Hundreds) + " hundred ";
        }

        private string GetTwoDigitNumber(ExpandedDigits digits)
        {
            if (digits.Tens == 0) return NumberNotFound;

            var tens = new Dictionary<int, string>
            {
                {10, "ten"},
                {20, "twenty"},
                {30, "thirty"},
                {40, "fourty"},
                {50, "fifty"},
                {60, "sixty"},
                {70, "seventy"},
                {80, "eighty"},
                {90, "ninety"},
            };

            var teens = new Dictionary<int, string>
            {
                {11, "eleven"},
                {12, "twelve"},
                {13, "thirteen"},
                {14, "fourteen"},
                {15, "fifteen"},
                {16, "sixteen"},
                {17, "seventeen"},
                {18, "eighteen"},
                {19, "nineteen"},
            };

            if (digits.IsTeenNumber())
            {
                var teenNumber = ReassemblyTeenNumber(digits);
                return teens[teenNumber];
            }

            var lookup = digits.GetTensValue();
            return digits.IsCompoundNumber() ? $"{tens[lookup]}-" : tens[lookup];
        }

        private int ReassemblyTeenNumber(ExpandedDigits digits)
        {
            return digits.GetTensValue() + digits.Units;
        }

        private string GetGatedSingleDigitNumber(ExpandedDigits digits)
        {
            if (digits.IsTeenNumber() || MultiDigitNumberEndingWithZero(digits)) return NumberNotFound;

            return GetSingleDigitNumber(digits.Units);
        }

        private bool MultiDigitNumberEndingWithZero(ExpandedDigits digits)
        {
            return !digits.IsSingleDigitNumber() && digits.Units == 0;
        }

        private string GetSingleDigitNumber(int number)
        {
            var singleDigitNumbers = new Dictionary<int, string>
            {
                {0, "zero"},
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {4, "four"},
                {5, "five"},
                {6, "six"},
                {7, "seven"},
                {8, "eight"},
                {9, "nine"},
            };

            string result;
            if (singleDigitNumbers.TryGetValue(number, out result))
            {
                return result;
            }

            return NumberNotFound;
        }
    }
}