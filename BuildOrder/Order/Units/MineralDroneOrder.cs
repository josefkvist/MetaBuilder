using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class MineralDroneOrder : IOrder 
    {
        public bool TryDoOrder(ref ZergBase zerg)
        {
            return zerg.TryBuildDrone<MineralDrone>(KeyGenerator.GetKey);
        }

        public bool IsDone { get; set; }

    }
}