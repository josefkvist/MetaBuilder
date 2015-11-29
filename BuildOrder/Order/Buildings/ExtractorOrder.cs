using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Buildings
{
    public class ExtractorOrder : IOrder
    {
        public bool TryDoOrder(ref ZergBase zerg)
        {
            return zerg.TryBuildExtractor(KeyGenerator.GetKey);
        }

        public bool IsDone { get; set; }

    }
}