using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Settings;

namespace MetaBuilder.Core.Worker.Zerg
{
    public class MovingDrone : Unit
    {
        public MovingDrone(double created, double movingTime) 
            : base(created, movingTime, ZergUnitSettings.Drone.Supply, ZergUnitSettings.Drone.Name)
        {

        }

        public override bool IsFinished(double time)
        {
            return true;
        }

        
    }
}