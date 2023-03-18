using System;

namespace DragRace
{
    public class Skyline : ICar, IBoostable
    {
        private int currentSpeed = 0;
        public void SpeedUp()
        {
            currentSpeed += 19;
        }

        public void SlowDown()
        {
            currentSpeed -= 19;
        }

        public string ShowCurrentSpeed()
        {
            return currentSpeed.ToString();
        }

        public void UseNitrousOxideEngine()
        {
            currentSpeed += 25;
        }

        public void StartEngine()
        {
            Console.WriteLine("--boom-boom--");
        }
    }
}
