using MetaBuilder.Core.Interfaces;

namespace MetaBuilder.Core.Worker
{
    public class MovingDrone : Unit
    {
        public MovingDrone(double created, double movingTime) 
            : base(created, movingTime, UnitSettings.Drone.Supply, UnitSettings.Drone.Name)
        {

        }

        public override bool IsFinished(double time)
        {
            return true;
        }

        
    }
}