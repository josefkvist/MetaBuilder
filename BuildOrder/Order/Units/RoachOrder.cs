﻿using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Units.Zerg;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Units
{
    public class RoachOrder : IOrder
    {
        public bool TryDoOrder(ref Base zerg, int key)
        {
            return zerg.TryBuildBasicArmyUnit<Roach>(key, UnitSettings.Roach);
        }

        public bool IsDone { get; set; }
    }
}