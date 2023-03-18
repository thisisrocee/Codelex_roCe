using System;

namespace AdApp
{
    public class Hoarding: Advert
    {
        private int _rate;
        private int _numDays;
        private bool _isPrimeLoc;

        public Hoarding(int fee, int rate, int numDays, bool isPrimeLoc) : base(fee)
        {
            SetFee(fee);
            _rate = rate;
            _numDays = numDays;
            _isPrimeLoc = isPrimeLoc;
        }

        public new int Cost()
        {
            var result = _rate * _numDays;
            var surcharge = result * 1.5;
            return _isPrimeLoc ? result : (int)surcharge;
        }

        public override string ToString()
        {
            return $"Hoarding total cost: {Cost()}";
        }
    }
}