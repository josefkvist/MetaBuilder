using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Upgrades
{
    public class Range1Order : IOrder
    {
        public bool TryDoOrder(ref Base zerg, int key)
        {
            return zerg.TryUpgrade(key, UpgradeSettings.Range1);
        }

        public bool IsDone { get; set; }

    }
}