using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class GasDroneOrder : IOrder 
    {
        public bool TryDoOrder(ref Base zerg, int key)
        {
            return zerg.TryBuildDrone<GasDrone>(key);
        }

        public bool IsDone { get; set; }

    }
}