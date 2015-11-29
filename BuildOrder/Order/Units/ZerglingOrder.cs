using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Buildings.Zerg;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Units.Zerg;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class ZerglingOrder : IOrder
    {
        public bool TryDoOrder(ref ZergBase zerg)
        {
            return zerg.TryBuildBasicArmyUnit<Zergling>(KeyGenerator.GetKey, ZergUnitSettings.Ling);
        }

        public bool IsDone { get; set; }

    
    }
}