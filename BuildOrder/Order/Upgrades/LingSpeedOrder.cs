using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Upgrades
{
    public class LingSpeedOrder : IOrder
    {
        public bool TryDoOrder(ref Base zerg)
        {
            return zerg.TryUpgrade(KeyGenerator.GetKey, UpgradeSettings.LingSpeed);
        }

        public bool IsDone { get; set; }

    }
}