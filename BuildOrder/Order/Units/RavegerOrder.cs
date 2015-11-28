using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Units.Zerg;

namespace BuildOrder.Order.Units
{
    public class RavegerOrder : IOrder
    {
        public bool TryDoOrder(ref Base zerg)
        {
            return zerg.TryBuildAdvancedArmyUnit<Raveger>(KeyGenerator.GetKey, UnitSettings.Raveger);

        }

        public bool IsDone { get; set; }
    }
}