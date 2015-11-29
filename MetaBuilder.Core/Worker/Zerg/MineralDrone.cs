using System;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Units.Zerg;

namespace MetaBuilder.Core.Worker.Zerg
{
    public class MineralDrone : Drone, IWorker
    {
        private double _timePerTurn = 5.4;
        private double _timePerTurnWhenThree = 7.5;
        private double _startedAt;

        public MineralDrone(double createdAt) : base(createdAt)
        {
            _startedAt = Math.Round(createdAt,3) + ZergUnitSettings.Drone.BuildTime;
        }

        public static MineralDrone MoveDrone(double moved, double timeBetweenHatcheries)
        {
            return new MineralDrone(moved - ZergUnitSettings.Drone.BuildTime + timeBetweenHatcheries);
        }

        public bool HasFinishedMining(double time, int noOfDrones)
        {
            var roundedTime = Math.Round(time, 2);
            var timePerTurn = noOfDrones > 2 ? _timePerTurnWhenThree * (noOfDrones/3.0) : _timePerTurn;
            if (roundedTime.ToMilliSeconds() < _startedAt.ToMilliSeconds() + timePerTurn.ToMilliSeconds()) return false;
            var timeLeftTilReturn = timePerTurn.ToMilliSeconds() - (roundedTime.ToMilliSeconds() - Math.Round(_startedAt,2).ToMilliSeconds()) % timePerTurn.ToMilliSeconds();
            if (timePerTurn.ToMilliSeconds() - timeLeftTilReturn < CoreSettings.TimeStep.ToMilliSeconds())
                return true;
        
            return false;
        }
    }
}
