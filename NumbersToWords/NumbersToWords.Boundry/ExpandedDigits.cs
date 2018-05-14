namespace NumbersToWords.Boundry
{
    public class ExpandedDigits
    {
        public int Units { get; set; }
        public int Tens { get; set; }
        public int Hundreds { get; set; }
        public int Thousands { get; set; }

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
            var canidateNumber = GetLastTwoDigitsAssembled();
            if (InCompoundRange(canidateNumber) && NotDivisibleBy10(canidateNumber))
            {
                return true;
            }

            return false;
        }

        public bool IsTeenNumber()
        {
            var canidateValue = GetLastTwoDigitsAssembled();

            if (canidateValue > 10 && canidateValue < 20)
            {
                return true;
            }

            return false;
        }

        public bool IsSingleDigitNumber()
        {
            var canidateValue = GetThousandsValue() + GetHundredsValue() + GetTensValue() + Units;
            return canidateValue <= 9;
        }

        private bool NotDivisibleBy10(int canidateNumber)
        {
            return canidateNumber % 10 != 0;
        }

        private bool InCompoundRange(int canidateNumber)
        {
            return canidateNumber >= 21 && canidateNumber <= 99;
        }
        
        private int GetLastTwoDigitsAssembled()
        {
            return GetTensValue() + Units;
        }

        public bool CanCompressFourDigitNumberIntoThreeDigitNotation()
        {
            return Thousands > 0 && Hundreds > 0 && Tens == 0 && Units == 0;
        }
    }
}