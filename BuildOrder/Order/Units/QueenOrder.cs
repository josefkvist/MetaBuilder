using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class QueenOrder : IOrder
    {
        public bool TryDoOrder(ref Base zerg, int key)
        {
            return zerg.TryBuildQueen(key);
        }

        public bool IsDone { get; set; }
    }
}