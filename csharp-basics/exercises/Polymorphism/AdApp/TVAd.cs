using System.Security.Cryptography;

namespace AdApp
{
    public class TVAd: Advert
    {
        private int _seconds;
        private int _costPerSecond;
        private bool _isPeak;

        public TVAd(int fee, int seconds, int costPerSecond, bool isPeak) : base(fee)
        {
            SetFee(fee);
            _seconds = seconds;
            _costPerSecond = costPerSecond;
            _isPeak = isPeak;
        }
        
        public new int Cost() 
        {
            var result = _seconds * _costPerSecond;
            var peakTime = result * 2;
            return _isPeak ? result : peakTime;
        }

        public override string ToString() 
        {
            return $"TVad total cost: {Cost()}";
        }
    }
}