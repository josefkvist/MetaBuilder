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
    public class EvoChamberOrder : BuildingOrder, IOrder
    {
        public EvoChamberOrder(int moveOutMinerals) : base(moveOutMinerals)  
        {
        }

        public bool TryDoOrder(ref ZergBase zerg)
        {
            return TryBuild<EvolutionChamber>(ref zerg, ZergBuildingSettings.EvolutionChamber, typeof (SpawningPool));
        }

        public bool IsDone { get; set; }
    }
}