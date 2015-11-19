using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class QueenOrder : IOrder
    {
        public bool TryDoOrder(ref Base zerg)
        {
            return zerg.TryBuildQueen(KeyGenerator.GetKey);
        }

        public bool IsDone { get; set; }
    }
}