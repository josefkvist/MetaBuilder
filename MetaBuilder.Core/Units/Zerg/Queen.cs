using System;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Settings;

namespace MetaBuilder.Core.Units.Zerg
{
    public class Queen : Unit, IEnergy
    {
        private double _energyTimer = 29.0/25.0;
        private double _maxEnergy = 200;

        public int Energy { get; set; }
        
        public Queen(double created)
            : base(created, ZergUnitSettings.Queen.BuildTime, ZergUnitSettings.Queen.Supply, ZergUnitSettings.Queen.Name)
        {
            Energy = 25;
        }

        public void CheckEnergy(double time)
        {
            if (!IsFinished(time)) return;

            var timeSinceBuilt = time - _created - _buildTime;

            var timerLeft = timeSinceBuilt % _energyTimer;

            if (Math.Abs(_energyTimer.ToMilliSeconds() - timerLeft.ToMilliSeconds() - _energyTimer.ToMilliSeconds())
                < CoreSettings.TimeStep.ToMilliSeconds()
                 && _maxEnergy < 3)
            {
                Energy++;
            }
        }
    }
}