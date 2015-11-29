using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Models;
using MetaBuilder.Core.Resources;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Units.Zerg;
using MetaBuilder.Core.Worker;
using MetaBuilder.Core.Worker.Zerg;

namespace MetaBuilder.Core.Buildings.Zerg
{
    public class Hatchery : Building, ISupply
    {
        #region Properties
        public int Supply { get; private set; }
        private int _naturalLarvas;
        private int _injectedLarvas;
        private double _lastInject;
        private bool _isInjected;
        private double _injectTimeToLarva = 29;
        private double _naturalLarvaTimer = 11.0;
        public Queen Queen { get; set; }
        public int NoOfLarvas { get { return _injectedLarvas + _naturalLarvas; } }
        public List<MineralPatch> MineralPatches { get; set; }
        public int MineralsPerDrone { get; private set; }
        public List<Extractor> Extractors { get; set; }
       
        #endregion

        #region Constructors
        public Hatchery()
            : base(-ZergBuildingSettings.Hatchery.BuildTime, ZergBuildingSettings.Hatchery.BuildTime, ZergBuildingSettings.Hatchery.Name) 
        {

            _naturalLarvas = 3;
            _injectedLarvas = 0;
            MineralsPerDrone = 5;
            Supply = 6;
            CreateMineralPatches();
            Extractors = new List<Extractor>();
        }

        public Hatchery(double createTime, bool isGoldExpansion)
            : base(createTime, ZergBuildingSettings.Hatchery.BuildTime, ZergBuildingSettings.Hatchery.Name)
        {
            _naturalLarvas = 1;
            _injectedLarvas = 0;
            MineralsPerDrone = isGoldExpansion ? 10 : 5;
            Supply = 6;
            CreateMineralPatches();
            Extractors = new List<Extractor>();
        }

        private void CreateMineralPatches()
        {
            MineralPatches = new List<MineralPatch>();
            for (int i = 0; i < 8; i++)
            {
                MineralPatches.Add(new MineralPatch());
            }
        }

        #endregion

        #region Drone
        public void AddMineralDrone(MineralDrone drone)
        {
            var added = false;
            var noOfDrones = 0;
            while (!added)
            {
                var patch = MineralPatches.FirstOrDefault(x => x.MineralDrones.Count == noOfDrones);
                if (patch != null)
                {
                    patch.MineralDrones.Add(drone);
                    added = true;
                }
                noOfDrones++;
            }
        }

        public MineralDrone RemoveMineralDrone(double time)
        {
            var patch = MineralPatches.OrderByDescending(x => x.MineralDrones.Where(o=>o.IsFinished(time)).Count()).FirstOrDefault();
            if (patch == null) return null;
            var drone = patch.MineralDrones.FirstOrDefault(d=>d.IsFinished(time));
            patch.MineralDrones.Remove(drone);

            return drone;
        }
        public void AddGasDrone(GasDrone gasDrone, double time)
        {
            var added = false;
            var noOfDrones = 0;
            while (!added)
            {
                var extractor = Extractors.FirstOrDefault(x => x.GasDrones.Count == noOfDrones);
                if (extractor != null)
                {
                    extractor.AddGasDrone(gasDrone, time);
                    
                    added = true;
                }
                noOfDrones++;
            }
        }

        public GasDrone RemoveGasDrone(double time)
        {
            var extractor = Extractors.OrderByDescending(x => x.GasDrones.Count).FirstOrDefault();
            if (extractor == null) return null;
            var drone = extractor.GasDrones.FirstOrDefault(d=>d.IsFinished(time));
            extractor.GasDrones.Remove(drone);

            return drone;
        }

        public int NoOfMineralDrones(double time)
        {
            var sum = 0;
            foreach (var mineralPatch in MineralPatches)
            {
                sum += mineralPatch.MineralDrones.Where(x=>x.IsFinished(time)).Count();
            }
            return sum;
        }
        public int NoOfGasDrones()
        {
            var sum = 0;
            foreach (var extractor in Extractors)
            {
                sum += extractor.GasDrones.Count;
            }
            return sum;
        }
        #endregion

        #region Larvas
        public bool HasLarvas()
        {
            return (_naturalLarvas > 0 || _injectedLarvas > 0);
        }

        public void ConsumeLarva()
        {
            if (_injectedLarvas > 0)
                _injectedLarvas--;
            else if (_naturalLarvas > 0)
                _naturalLarvas--;
            else
            {
                throw new Exception("No larva to consume");
            }
        }

        #endregion
        public void TickTock(double time)
        {
            if (!IsFinished(time)) return;

            //Natural larva
            var timeSinceBuilt = time - _created - _buildTime;

            var timerLeft = timeSinceBuilt%_naturalLarvaTimer;

            if ( Math.Abs(_naturalLarvaTimer.ToMilliSeconds()-timerLeft.ToMilliSeconds() - _naturalLarvaTimer.ToMilliSeconds())
                < CoreSettings.TimeStep.ToMilliSeconds() 
                 && _naturalLarvas < 3)
            {
                _naturalLarvas++;
            }

            //injected Larva
            if (!_isInjected) return;
            var timeSinceInject = time.ToMilliSeconds() - _lastInject.ToMilliSeconds() - _injectTimeToLarva.ToMilliSeconds();
            if (timeSinceInject > 0)
            {
                _isInjected = false;
                _injectedLarvas += 3;
                Console.WriteLine("Time: " + (time).ToMinuteString() + ", New injected larvas");
            }
            
        }

        public bool Inject(double time)
        {
            if (_isInjected) return false;
            if (Queen == null) return false;
            if (!Queen.IsFinished(time)) return false;
            this.Queen.Energy -= 25;
            _isInjected = true;
            _lastInject = time;
            return true;
        }

        public override bool IsFinished(double time)
        {
            return time >= _created + _buildTime;
        }


    }
}
