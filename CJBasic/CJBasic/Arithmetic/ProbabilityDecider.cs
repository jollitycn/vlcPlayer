namespace CJBasic.Arithmetic
{
    using System;

    public class ProbabilityDecider
    {
        private int percentValue;
        private Random random;

        public ProbabilityDecider()
        {
            this.random = new Random();
            this.percentValue = 50;
        }

        public ProbabilityDecider(int _percentValue)
        {
            this.random = new Random();
            this.percentValue = 50;
            this.PercentValue = _percentValue;
        }

        public bool Try()
        {
            return (this.percentValue > this.random.Next(0, 100));
        }

        public int PercentValue
        {
            get
            {
                return this.percentValue;
            }
            set
            {
                if ((value < 0) || (value > 100))
                {
                    throw new Exception("PercentValue must be in the range (0,100).");
                }
                this.percentValue = value;
            }
        }
    }
}

