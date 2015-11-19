using MetaBuilder.Core;

namespace BuildOrder.Interface
{
    public interface IOrder
    {
        bool TryDoOrder(ref Base zerg);
        bool IsDone { get; set; }
    }
}
