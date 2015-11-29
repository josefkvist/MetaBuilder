using System;
using System.Linq;
using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Buildings.Zerg;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Buildings
{
    public class BaneNestOrder : BuildingOrder, IOrder
    {
        
        public BaneNestOrder(int moveOutMinerals, int moveOutGas) : base(moveOutMinerals, moveOutGas)
        {
        }

        public bool TryDoOrder(ref ZergBase zerg)
        {
            return TryBuild<BaneNest>(ref zerg, ZergBuildingSettings.BaneNest, typeof(SpawningPool));
        }

        public bool IsDone { get; set; }
    }
}