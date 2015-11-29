using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Units.Zerg;

namespace BuildOrder.Order.Units
{
    public class BanelingOrder : IOrder
    {
        public bool TryDoOrder(ref ZergBase zerg)
        {
            return zerg.TryBuildAdvancedArmyUnit<Baneling>(KeyGenerator.GetKey, ZergUnitSettings.Bane);

        }

        public bool IsDone { get; set; }
    }
}