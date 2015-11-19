using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class MineralDroneOrder : IOrder 
    {
        public bool TryDoOrder(ref Base zerg, int key)
        {
            return zerg.TryBuildDrone<MineralDrone>(key);
        }

        public bool IsDone { get; set; }

    }
}