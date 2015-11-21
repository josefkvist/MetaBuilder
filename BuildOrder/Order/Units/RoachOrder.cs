using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Buildings.Zerg;
using MetaBuilder.Core.Units.Zerg;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class RoachOrder : IOrder
    {
        public bool TryDoOrder(ref Base zerg)
        {
            return zerg.TryBuildBasicArmyUnit<Roach>(KeyGenerator.GetKey, UnitSettings.Roach);
        }

        public bool IsDone { get; set; }
    }
}