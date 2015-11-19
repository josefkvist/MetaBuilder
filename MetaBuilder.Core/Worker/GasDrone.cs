using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MetaBuilder.Core.Units.Zerg;

namespace MetaBuilder.Core.Worker
{
    public class GasDrone : Drone, IWorker
    {
        private double _timePerTurn = 4.5;
        private double _timePerTurnWhenThree = 6.5;
        private double _timePerTurnWhenFour = 11;
        private double _startedAt;
        public double StartedAt { get { return _startedAt; } set { _startedAt = value; } }

        public GasDrone(double createdAt) : base(createdAt)
        {
            _startedAt = createdAt + UnitSettings.Drone.BuildTime;
        }

        public bool HasFinishedMining(double time, int noOfDrones)
        {
            var timePerTurn = TimePerTurn(noOfDrones);

            var timeLeftTilReturn = TimeLeftTilReturn(time, noOfDrones);
            if (timeLeftTilReturn < 0) return false;
            if (timePerTurn.ToMilliSeconds() - timeLeftTilReturn < Settings.TimeStep.ToMilliSeconds())
                return true;
        
            return false;
        }

        public double TimeLeftTilReturn(double time, int noOfDrones)
        {
            var timePerTurn = TimePerTurn(noOfDrones);

            if (time.ToMilliSeconds() < _startedAt.ToMilliSeconds() + timePerTurn.ToMilliSeconds()) return -1.0;
            return timePerTurn.ToMilliSeconds() - (time.ToMilliSeconds() - _startedAt.ToMilliSeconds()) % timePerTurn.ToMilliSeconds();
           
        }

        public double TimePerTurn(int noOfDrones)
        {
            var timePerTurn = 0.0;
            if (noOfDrones < 3)
                timePerTurn = _timePerTurn;
            else if (noOfDrones == 3)
                timePerTurn = _timePerTurnWhenThree;
            else
                timePerTurn = _timePerTurnWhenFour * (noOfDrones / 4.0);

            return timePerTurn;
        }
     
    }
}
