using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Units.Zerg;

namespace BuildOrder.Order.Units
{
    public class RavegerOrder : IOrder
    {
        public bool TryDoOrder(ref ZergBase zerg)
        {
            return zerg.TryBuildAdvancedArmyUnit<Raveger>(KeyGenerator.GetKey, ZergUnitSettings.Raveger);

        }

        public bool IsDone { get; set; }
    }
}