namespace NumbersToWords.Boundry
{
    public class ExpandedDigits
    {
        private readonly int _unexpandedValue;

        public int Units { get; set; }
        public int Tens { get; set; }
        public int Hundreds { get; set; }
        public int Thousands { get; set; }

        public ExpandedDigits(int unexpandedValue)
        {
            _unexpandedValue = unexpandedValue;
        }

        public int GetTensValue()
        {
            return Tens * 10;
        }

        public int GetHundredsValue()
        {
            return Hundreds * 100;
        }

        public int GetThousandsValue()
        {
            return Thousands * 1000;
        }

        public bool IsCompoundNumber()
        {
            var canidateNumber = GetTensValue() + Units;
            if (InCompoundRange(canidateNumber) && NotDivisibleBy10(canidateNumber))
            {
                return true;
            }

            return false;
        }

        public bool IsTeenNumber()
        {
            if (_unexpandedValue > 10 && _unexpandedValue < 20)
            {
                return true;
            }

            return false;
        }

        public bool IsSingleDigitNumber()
        {
            return _unexpandedValue <= 9;
        }

        private bool NotDivisibleBy10(int canidateNumber)
        {
            return canidateNumber % 10 != 0;
        }

        private bool InCompoundRange(int canidateNumber)
        {
            return canidateNumber >= 21 && canidateNumber <= 99;
        }
    }
}