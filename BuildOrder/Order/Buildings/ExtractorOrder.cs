using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Buildings
{
    public class ExtractorOrder : IOrder
    {
        public bool TryDoOrder(ref Base zerg, int key)
        {
            return zerg.TryBuildExtractor(key);
        }

        public bool IsDone { get; set; }

    }
}