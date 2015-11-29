using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class OverlordOrder : IOrder
    {
        public bool TryDoOrder(ref ZergBase zerg)
        {
            return zerg.TryBuildOverlord(KeyGenerator.GetKey);
        }

        public bool IsDone { get; set; }
    }
}