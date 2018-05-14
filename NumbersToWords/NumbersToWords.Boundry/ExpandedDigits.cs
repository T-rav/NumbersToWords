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
            if (NumberInCompundRange() && NumberNotDivisibleBy10())
            {
                return true;
            }

            return false;
        }

        private bool NumberNotDivisibleBy10()
        {
            return _unexpandedValue % 10 != 0;
        }

        private bool NumberInCompundRange()
        {
            return InCompoundRange() && NotDivisibleBy10();
        }

        private bool NotDivisibleBy10()
        {
            return _unexpandedValue % 10 != 0;
        }

        private bool InCompoundRange()
        {
            return _unexpandedValue >= 21 && _unexpandedValue <= 99;
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
    }
}