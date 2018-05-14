using NumbersToWords.Boundry;

namespace NumbersToWords
{
    public class DigitExpandor : IDigitExpandor
    {
        public ExpandedDigits Expand(int input)
        {
            var thousandsDigit = input / 1000;
            var thousandsDigitValue = thousandsDigit * 1000;
            var leftOverValue = (input - thousandsDigitValue);

            var hundredsDigit = leftOverValue / 100;
            var hundredsDigitValue = hundredsDigit * 100;
            leftOverValue = (leftOverValue - hundredsDigitValue);

            var tensDigit =  leftOverValue / 10;
            var tensDigitValue = tensDigit * 10;

            var units = leftOverValue - tensDigitValue;

            return new ExpandedDigits
            {
                Units = units,
                Tens = tensDigit,
                Hundreds = hundredsDigit,
                Thousands = thousandsDigit
            };
        }
    }
}