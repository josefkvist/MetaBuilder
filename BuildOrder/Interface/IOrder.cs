using MetaBuilder.Core;
using MetaBuilder.Core.Bases;

namespace BuildOrder.Interface
{
    public interface IOrder
    {
        bool TryDoOrder(ref ZergBase zerg);
        bool IsDone { get; set; }
    }
}
