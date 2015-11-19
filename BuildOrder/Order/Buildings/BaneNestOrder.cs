using System;
using System.Linq;
using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Buildings.Zerg;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Worker;

namespace BuildOrder.Order.Buildings
{
    public class BaneNestOrder : IOrder
    {
        private readonly int _moveOutMinerals;

        private int _waitingForKey;
        private MovingDrone _drone;
        private int _moveOutGas;

        public BaneNestOrder(int moveOutMinerals, int moveOutGas)
        {
            _moveOutMinerals = moveOutMinerals;
            _moveOutGas = moveOutGas;
        }


        public bool TryDoOrder(ref Base zerg, int key)
        {
            var counter = zerg.Counters.Last();
            var actualTime = Math.Round((zerg.Counters.Count - 1) * Settings.TimeStep, 3);

            if (_waitingForKey == 0 &&
      counter.Minerals >= _moveOutMinerals && counter.Gas >= _moveOutGas)
            {

                    zerg.MoveOutDrone(key, 0, typeof(MineralDrone), typeof(BaneNest));
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
                                              ", drone at natural");
                        return zerg.TryBuildBuilding<BaneNest>(key, _drone, BuildingSettings.BaneNest, typeof(SpawningPool));
                }
            }

            return false;
        }

        public bool IsDone { get; set; }

    }
}