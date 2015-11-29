using System;
using System.Linq;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Buildings.Zerg;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Models;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Worker;
using MetaBuilder.Core.Worker.Zerg;

namespace BuildOrder.Order.Buildings
{
    public abstract class BuildingOrder
    {
        protected readonly int _moveOutMinerals;
        private int _waitingForKey;
        private MovingDrone _drone;
        private int _moveOutGas;

        protected BuildingOrder(int moveOutMinerals, int moveOutGas = 0)
        {
            _moveOutMinerals = moveOutMinerals;
            _moveOutGas = moveOutGas;
        }

        protected bool TryBuild<T>(ref ZergBase zerg, BuildingValues buildingValues, Type dependType) where T : Building
        {
            var key = KeyGenerator.GetKey;
            var counter = zerg.Counters.Last();
            var actualTime = Math.Round((zerg.Counters.Count - 1) * CoreSettings.TimeStep, 3);

            if (_waitingForKey == 0 &&
      counter.Minerals >= _moveOutMinerals && counter.Gas >= _moveOutGas)
            {

                zerg.MoveOutDrone(key, 0, typeof(MineralDrone), typeof(T));
                _waitingForKey = key;
                _drone = zerg.InProductions[key] as MovingDrone;
            }
            else if (_drone != null)
            {
                var inProduction = zerg.InProductions.ContainsKey(_waitingForKey)
                    ? zerg.InProductions[_waitingForKey]
                    : null;
                if (inProduction == null ||
                    inProduction.PromilleDone(actualTime) == (int)Percentage.P100)
                {
                    System.Console.WriteLine("Time: " + (actualTime).ToMinuteString() +
                                         ", drone ready to build " + buildingValues.Name);
                    return zerg.TryBuildBuilding<T>(key, _drone, buildingValues, dependType);
                }
            }

            return false;
        }
    }
}