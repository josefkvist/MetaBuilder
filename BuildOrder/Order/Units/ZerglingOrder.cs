using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Buildings.Zerg;
using MetaBuilder.Core.Units.Zerg;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class ZerglingOrder : IOrder
    {
        public bool TryDoOrder(ref Base zerg)
        {
            return zerg.TryBuildBasicArmyUnit<Zergling>(KeyGenerator.GetKey, UnitSettings.Ling, typeof(SpawningPool));
        }

        public bool IsDone { get; set; }

    
    }
}