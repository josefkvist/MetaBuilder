using MetaBuilder.Core;

namespace BuildOrder.Interface
{
    public interface IOrder
    {
        bool TryDoOrder(ref Base zerg, int key);
        bool IsDone { get; set; }
    }
}
