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

            var result = GetThousandsWord(expandedDigits) 
                         + GetHundredsWord(expandedDigits) 
                         + GetTensWord(expandedDigits) 
                         + GetGatedUnitWord(expandedDigits);

            return result.Trim();
        }

        private string GetThousandsWord(ExpandedDigits expandedDigits)
        {
            if (expandedDigits.Thousands == 0 || expandedDigits.CanCompressFourDigitNumberIntoThreeDigitNotation())
            {
                return NumberNotFound;
            }

            return GetUnitsWord(expandedDigits.Thousands) + " thousand ";
        }

        private string GetHundredsWord(ExpandedDigits expandedDigits)
        {
            if (expandedDigits.Hundreds == 0)
            {
                return NumberNotFound;
            }

            if (expandedDigits.CanCompressFourDigitNumberIntoThreeDigitNotation())
            {
                var compressedDigits = new ExpandedDigits { Tens = expandedDigits.Thousands, Units = expandedDigits.Hundreds };
                var compressionResult = GetTensWord(compressedDigits) + GetUnitsWord(compressedDigits.Units);
                return compressionResult + " hundred";
            }

            return GetUnitsWord(expandedDigits.Hundreds) + " hundred ";
        }

        private string GetTensWord(ExpandedDigits digits)
        {
            if (digits.Tens == 0) return NumberNotFound;

            if (digits.IsTeenNumber())
            {
                return GetTeenNumberWord(digits);
            }

            return GetTensDigitWord(digits);
        }

        private string GetTensDigitWord(ExpandedDigits digits)
        {
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

            var lookup = digits.GetTensValue();
            return digits.IsCompoundNumber() ? $"{tens[lookup]}-" : tens[lookup];
        }

        private string GetTeenNumberWord(ExpandedDigits digits)
        {
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

            var teenNumber = ReassemblyTeenNumber(digits);
            return teens[teenNumber];
        }

        private int ReassemblyTeenNumber(ExpandedDigits digits)
        {
            return digits.GetTensValue() + digits.Units;
        }

        private string GetGatedUnitWord(ExpandedDigits digits)
        {
            if (digits.IsTeenNumber() || MultiDigitNumberEndingWithZero(digits)) return NumberNotFound;

            return GetUnitsWord(digits.Units);
        }

        private bool MultiDigitNumberEndingWithZero(ExpandedDigits digits)
        {
            return !digits.IsSingleDigitNumber() && digits.Units == 0;
        }

        private string GetUnitsWord(int number)
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