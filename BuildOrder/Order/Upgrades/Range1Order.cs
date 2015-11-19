using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Upgrades
{
    public class Range1Order : IOrder
    {
        public bool TryDoOrder(ref Base zerg)
        {
            return zerg.TryUpgrade(KeyGenerator.GetKey, UpgradeSettings.Range1);
        }

        public bool IsDone { get; set; }

    }
}