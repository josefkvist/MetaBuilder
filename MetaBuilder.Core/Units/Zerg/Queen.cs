using System;
using MetaBuilder.Core.Interfaces;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Queen : Unit, IEnergy
    {
        private double _energyTimer = 29.0/25.0;
        private double _maxEnergy = 200;

        public int Energy { get; set; }
        
        public Queen(double created)
            : base(created, UnitSettings.Queen.BuildTime, UnitSettings.Queen.Supply, UnitSettings.Queen.Name)
        {
            Energy = 25;
        }

        public void CheckEnergy(double time)
        {
            if (!IsFinished(time)) return;

            var timeSinceBuilt = time - _created - _buildTime;

            var timerLeft = timeSinceBuilt % _energyTimer;

            if (Math.Abs(_energyTimer.ToMilliSeconds() - timerLeft.ToMilliSeconds() - _energyTimer.ToMilliSeconds())
                < Settings.TimeStep.ToMilliSeconds()
                 && _maxEnergy < 3)
            {
                Energy++;
            }
        }
    }
}