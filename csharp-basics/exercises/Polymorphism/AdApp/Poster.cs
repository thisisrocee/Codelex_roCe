using System;
using System.Collections.Generic;
using System.Text;

namespace AdApp
{
    public class Poster : Advert
    {
        private int _dimensions;
        private int _numOfCopies;
        private double _costPerCopy;

        public Poster(int fee, int dimensions, int numOfCopies, double costPerCopy) : base(fee)
        {
            SetFee(fee);
            _dimensions = dimensions;
            _numOfCopies = numOfCopies;
            _costPerCopy = costPerCopy;
        }

        public new int Cost()
        {
            var result = _dimensions * 0.2 + _numOfCopies * _costPerCopy;
            return (int)result;
        }

        public override string ToString()
        {
            return $"Poster total cost: {Cost()}";
        }
    }
}
