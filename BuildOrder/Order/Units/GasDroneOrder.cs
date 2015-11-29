using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Worker;
using MetaBuilder.Core.Worker.Zerg;

namespace BuildOrder.Order.Units
{
    public class GasDroneOrder : IOrder 
    {
        public bool TryDoOrder(ref ZergBase zerg)
        {
            return zerg.TryBuildDrone<GasDrone>(KeyGenerator.GetKey);
        }

        public bool IsDone { get; set; }

    }
}