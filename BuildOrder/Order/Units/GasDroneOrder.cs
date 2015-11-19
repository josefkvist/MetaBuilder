using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class GasDroneOrder : IOrder 
    {
        public bool TryDoOrder(ref Base zerg)
        {
            return zerg.TryBuildDrone<GasDrone>(KeyGenerator.GetKey);
        }

        public bool IsDone { get; set; }

    }
}