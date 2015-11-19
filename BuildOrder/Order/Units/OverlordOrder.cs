using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class OverlordOrder : IOrder
    {
        public bool TryDoOrder(ref Base zerg, int key)
        {
            return zerg.TryBuildOverlord(key);
        }

        public bool IsDone { get; set; }
    }
}