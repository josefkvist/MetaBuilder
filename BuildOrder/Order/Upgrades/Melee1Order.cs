using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Upgrades
{
    public class Melee1Order : IOrder
    {
        public bool TryDoOrder(ref ZergBase zerg)
        {
            return zerg.TryUpgrade(KeyGenerator.GetKey, ZergUpgradeSettings.Melee1);
        }

        public bool IsDone { get; set; }

    }
}