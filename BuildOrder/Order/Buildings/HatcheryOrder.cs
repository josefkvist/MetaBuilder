using System;
using System.Linq;
using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Buildings.Zerg;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Worker;
using MetaBuilder.Core.Worker.Zerg;

namespace BuildOrder.Order.Buildings
{
    public class HatcheryOrder : IOrder
    {
        private int _moveOutMinerals;
        private int _waitingForKey;
        private MovingDrone _drone;
        public HatcheryOrder(int moveOutMinerals)
        {
            _moveOutMinerals = moveOutMinerals;
        }

        public bool TryDoOrder(ref ZergBase zerg)
        {
            var key = KeyGenerator.GetKey;
            var counter = zerg.Counters.Last();
            var actualTime = Math.Round((zerg.Counters.Count - 1) * CoreSettings.TimeStep, 3);
            if (_waitingForKey == 0 &&
                               counter.Minerals >= _moveOutMinerals)
            {
               
                zerg.MoveOutDrone(key, 0, typeof(MineralDrone), typeof(Hatchery));

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
                    return zerg.TryBuildHatchery(key, _drone);
                }
            }
            return false;
        }

        public bool IsDone { get; set; }

      
    }
}