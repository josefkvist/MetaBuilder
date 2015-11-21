using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Units.Zerg;

namespace BuildOrder.Order.Units
{
    public class BanelingOrder : IOrder
    {
        public bool TryDoOrder(ref Base zerg)
        {
            return zerg.TryBuildAdvancedArmyUnit<Baneling>(KeyGenerator.GetKey, UnitSettings.Bane);

        }

        public bool IsDone { get; set; }
    }
}