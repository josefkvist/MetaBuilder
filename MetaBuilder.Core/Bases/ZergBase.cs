using System;
using System.Collections.Generic;
using System.Linq;
using MetaBuilder.Core.Buildings.Zerg;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Models;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Units.Zerg;
using MetaBuilder.Core.Worker;
using MetaBuilder.Core.Worker.Zerg;

namespace MetaBuilder.Core.Bases
{
    public class ZergBase : Base
    {


        private List<CounterModel> _counters;
        private List<Unit> _units;
        private List<Building> _buildings;
        private List<Hatchery> _hatcheries;
        private List<Overlord> _overLords;
        private List<IEnergy> _energies; 

        public ZergBase(double stepTime) : base(stepTime)
        {
            _energies = new List<IEnergy>();
            _counters = new List<CounterModel>();
            _units = new List<Unit>();
            _buildings = new List<Building>();
            _hatcheries = new List<Hatchery>();
            _overLords = new List<Overlord>();
            _counters.Add(new CounterModel(){Gas = 0, Minerals = 50, Supply = 12, SupplyLimit = 14});
            var mainHatch = new Hatchery();
            _overLords.Add(new Overlord());

            for (int i = 0; i < 12; i++)
            {
                //var drone = new MineralDrone(-Drone.UnitValues.BuildTime);
                var drone = new MineralDrone(0.2 * i - ZergUnitSettings.Drone.BuildTime);
                mainHatch.AddMineralDrone(drone);
                _units.Add(drone);

            }
            _buildings.Add(mainHatch);
            _hatcheries.Add(mainHatch);
        }

        public List<CounterModel> Counters { get { return _counters;} } 

        public void StepForward()
        {
            var time = Math.Round(_counters.Count*StepTime,3);

            var currentCounter = StepForHatcheries(time);

            EvenOutWorkers(time);

            StepForEnergies(time);

            StepForInProduction(time);

            StepForSupply(time, currentCounter);
            _counters.Add(currentCounter);
        }

        private void EvenOutWorkers(double time)
        {
            if (!_hatcheries.Any(x=>x.NoOfMineralDrones(time) > 16)) return;

            for (int i = 0; i < _hatcheries.Count; i++)
            {
                if (_hatcheries[i].NoOfMineralDrones(time) > 16 
                    && i + 1 <_hatcheries.Count)
                {
                    if (TryChangeDronesWork(i, i + 1, typeof (MineralDrone), typeof (MineralDrone), KeyGenerator.GetKey))
                        PrintHatcheriesSaturation();
                }
                
            }
        }

        private void StepForSupply(double time, CounterModel currentCounter)
        {
            var supply = (from unit in _units
                select unit.Supply).Sum();
            if (supply > 40)
            {
                var hej = "";
            }
            var supplyHatch = (from hatch in _hatcheries.Where(x => x.IsFinished(time)) select hatch.Supply).Sum();
            var supplyOl = (from ol in _overLords.Where(x => x.IsFinished(time)) select ol.Supply).Sum();
            currentCounter.SupplyLimit = supplyOl + supplyHatch;
            currentCounter.Supply = (int) Math.Round(supply,0);
        }

        private void StepForEnergies(double time)
        {
//energies
            foreach (var energy in _energies)
            {
                energy.CheckEnergy(time);
            }
        }

        private void StepForInProduction(double time)
        {
            var removables = new List<int>();
            foreach (var inProduction in InProductions)
            {
                if (time < 5) continue;
                if (inProduction.Value.PromilleDone(time) == 100000)
                {
                    if (inProduction.Value.IsBuiltRightNow(time))
                    {
                        Console.WriteLine("Time: " + (time).ToMinuteString() + ", " + inProduction.Value.Name + " completed");
                    }
                }

                ////delete next time around
                if (!inProduction.Value.IsBuiltRightNow(time) && inProduction.Value.PromilleDone(time) == 100000)
                    removables.Add(inProduction.Key);
            }
            foreach (var production in removables)
            {
                InProductions.Remove(production);
            }
        }

        private CounterModel StepForHatcheries(double time)
        {
            var currentCounter = new CounterModel(_counters.Last());

            if (_hatcheries.Count == 2)
            {
                var hej = "";
            }
            foreach (var hatchery in _hatcheries)
            {
                for (int i = 0; i < hatchery.MineralPatches.Count; i++)
                {
                    var mineralPatch = hatchery.MineralPatches[i];
                    var mineralDrones = mineralPatch.MineralDrones.Where(x => x.IsFinished(time)).ToList();
                    for (int j = 0; j < mineralDrones.Count; j++)
                    {
                        var mineralDrone = mineralDrones[j];
                        if (mineralDrone.HasFinishedMining(time, mineralDrones.Count))
                        {
                            currentCounter.Minerals += hatchery.MineralsPerDrone;
                            if (time >51)
                            {
                                //Console.WriteLine(string.Format("drone finished mining {0} {1} ",i, j));                            
                                
                            }
                        }
                    }
                }
                foreach (var extractor in hatchery.Extractors)
                {
                    foreach (var gasDrone in extractor.GasDrones)
                    {
                        if (gasDrone.HasFinishedMining(time, extractor.GasDrones.Count))
                            currentCounter.Gas += extractor.GasPerDrone;
                    }
                }
                hatchery.TickTock(time);
                hatchery.Inject(time);
            }
            currentCounter.Larvas = (from hatchery in _hatcheries select hatchery.NoOfLarvas).Sum();

            return currentCounter;
        }

        public bool TryBuildDrone<T>(int key) where T : Drone
        {
            var currentCounter = _counters.Last();
            var time = (_counters.Count - 1)*StepTime;
            var hatchWithLarva = _hatcheries.FirstOrDefault(x => x.HasLarvas());
            if (currentCounter.Minerals >= ZergUnitSettings.Drone.Cost.Minerals 
                && hatchWithLarva != null 
                && currentCounter.SupplyLimit >= currentCounter.Supply + ZergUnitSettings.Drone.Supply)
            {
                currentCounter.Minerals -= ZergUnitSettings.Drone.Cost.Minerals;
                currentCounter.Supply += (int)ZergUnitSettings.Drone.Supply;
                hatchWithLarva.ConsumeLarva();
                if (typeof (T) == typeof (MineralDrone))
                {
                    var drone = new MineralDrone(time);
                    hatchWithLarva.AddMineralDrone(drone);
                    _units.Add(drone);
                    InProductions.Add(key, drone);
                }
                else if (typeof (T) == typeof (GasDrone))
                {
                    var drone = new GasDrone(time);
                    hatchWithLarva.AddGasDrone(drone, time);
                    InProductions.Add(key, drone);
                    _units.Add(drone);
                }
                Console.WriteLine("Time: " + (time).ToMinuteString() + ", Drone started");
                return true;
            }
            return false;
        }

        public bool TryBuildOverlord(int key)
        {
            var currentCounter = _counters.Last();
            var time = (_counters.Count - 1) * StepTime;
            var hatchWithLarva = _hatcheries.FirstOrDefault(x => x.HasLarvas());
            if (currentCounter.Minerals >= ZergUnitSettings.Overlord.Cost.Minerals && hatchWithLarva != null)
            {
                currentCounter.Minerals -= ZergUnitSettings.Overlord.Cost.Minerals;
                hatchWithLarva.ConsumeLarva();
                var ol = new Overlord(time);
                _overLords.Add(ol);
                InProductions.Add(key, ol);
                Console.WriteLine("Time: " + (time).ToMinuteString() + ", Overlord started");
                return true;
            }
            return false;
        }

        public bool TryBuildBuilding<T>(int key, MovingDrone drone, BuildingValues buildingValues, Type dependType = null) where T : Building
        {
            var currentCounter = _counters.Last();
            var time = GetActualTime();
            var isDependTypeFinished = dependType == null || _buildings.Any(x => x.GetType() == dependType && x.IsFinished(time));

            if (currentCounter.Minerals >= buildingValues.Cost.Minerals 
                && currentCounter.Gas >= buildingValues.Cost.Gas 
                && isDependTypeFinished)
            {
                currentCounter.Minerals -= buildingValues.Cost.Minerals;
                currentCounter.Gas -= buildingValues.Cost.Gas;
                _units.Remove(drone);
                var building = (T)Activator.CreateInstance(typeof(T),time);
                _buildings.Add(building);
                InProductions.Add(key, building);
                Console.WriteLine("Time: " + (time).ToMinuteString() + ", " + building.Name + " started");                    
                
                return true;
            }
            return false;
        }

        public bool TryUpgrade(int key, UpgradeValues upgradeValues)
        {
            var currentCounter = _counters.Last();
            
            var time = GetActualTime();
            var building = _buildings.FirstOrDefault(x => x.IsIdle(time) && x.GetType() == upgradeValues.BuildingType);
            if (building == null) return false;
            if (currentCounter.Minerals < upgradeValues.MineralCost || currentCounter.Gas < upgradeValues.GasCost)
                return false;
            if (building.SwitchIdle()) return false;
            currentCounter.Minerals -= upgradeValues.MineralCost;
            currentCounter.Gas -= upgradeValues.GasCost;
            var upgrade = new Upgrade(time, upgradeValues.BuildTime, upgradeValues.Name);
            InProductions.Add(key, upgrade);
            Console.WriteLine("Time: " + (time).ToMinuteString() + ", " + upgrade.Name + " started");
            return true;
        }

        public bool TryBuildQueen(int key)
        {
            var currentCounter = _counters.Last();

            var time = GetActualTime();
            var hatch = _buildings.FirstOrDefault(x => x.IsIdle(time) && x.GetType() == typeof(Hatchery)) as Hatchery;
            var poolIsFinished = _buildings.Any(x => x.IsFinished(time) && x.GetType() == typeof (SpawningPool));
            if (hatch == null) return false;
            if (currentCounter.Minerals < ZergUnitSettings.Queen.Cost.Minerals || !poolIsFinished)
                return false;
            if (hatch.SwitchIdle()) return false;
            currentCounter.Minerals -= ZergUnitSettings.Queen.Cost.Minerals;
            var queen = new Queen(time);
            if(hatch.Queen == null)
                hatch.Queen = queen;
            InProductions.Add(key, queen);
            _units.Add(queen);
            _energies.Add(queen);
            Console.WriteLine("Time: " + (time).ToMinuteString() + ", " + ZergUnitSettings.Queen.Name + " started");
            return true;
        }

        public bool TryBuildHatchery(int key, MovingDrone drone)
        {
            var currentCounter = _counters.Last();
            var time = GetActualTime();
            if (currentCounter.Minerals >= ZergBuildingSettings.Hatchery.Cost.Minerals)
            {
                currentCounter.Minerals -= ZergBuildingSettings.Hatchery.Cost.Minerals;
                _units.Remove(drone);
                var hatch = new Hatchery(time, false);
                _buildings.Add(hatch);
                _hatcheries.Add(hatch);
                InProductions.Add(key, hatch);
                Console.WriteLine("Time: " + (time).ToMinuteString() + ", " + hatch.Name + " started");

                return true;
            }
            return false;
        }

        public bool TryBuildExtractor(int key)
        {
            var currentCounter = _counters.Last();
            var time = (_counters.Count - 1) * StepTime;
            var hatch = _hatcheries.FirstOrDefault(x=>x.Extractors.Count < 2);
            if (currentCounter.Minerals >= ZergBuildingSettings.Extractor.Cost.Minerals && hatch != null)
            {
                currentCounter.Minerals -= ZergBuildingSettings.Extractor.Cost.Minerals;
                var drone = hatch.RemoveMineralDrone(time);
                _units.Remove(drone);
                var hatchIndex = _hatcheries.IndexOf(hatch);
                var extractor = new Extractor(time);
                extractor.HatchIndex = hatchIndex;
                _buildings.Add(extractor);
                hatch.Extractors.Add(extractor);
                InProductions.Add(key, extractor);
                Console.WriteLine("Time: " + (time).ToMinuteString() + ", " + extractor.Name + " started");

                return true;
            }
            return false;
        }

        public bool TryChangeDronesWork(int fromHatchIndex, int toHatchIndex, Type fromType, Type toType, int key)
        {
            var fromHatch = _hatcheries.Count > fromHatchIndex ? _hatcheries[fromHatchIndex] : null;
            var toHatch = _hatcheries.Count > toHatchIndex ? _hatcheries[toHatchIndex] : null;
            if (fromHatchIndex == toHatchIndex)
            {
                if (fromType == typeof (MineralDrone) && toType == typeof(GasDrone))
                {
                    var drone = fromHatch.RemoveMineralDrone(GetActualTime());
                    var success =_units.Remove(drone);
                    if (!success) throw new Exception("unit wasn't removed");
                    var newDrone = new GasDrone(drone.Created);
                    _units.Add(newDrone);
                    toHatch.AddGasDrone(newDrone, GetActualTime());
                    return true;
                }
                else if (fromType == typeof (GasDrone) && toType == typeof (MineralDrone))
                {
                    var drone = fromHatch.RemoveGasDrone(GetActualTime());
                    var success = _units.Remove(drone);
                    if (!success) throw new Exception("unit wasn't removed");
                    var newDrone = new MineralDrone(drone.Created);
                    _units.Add(newDrone);
                    toHatch.AddMineralDrone(newDrone);
                    return true;
                }
            }
            else
            {
                if (fromType == typeof (MineralDrone) && toType == typeof(MineralDrone))
                {
                    var drone = fromHatch.RemoveMineralDrone(GetActualTime());
                    var success = _units.Remove(drone);
                    if (!success) throw new Exception("unit wasn't removed");
                    var newDrone = MineralDrone.MoveDrone(GetActualTime(), ZergSettings.TimeBetweenHatcheries);
                    _units.Add(newDrone);
                    toHatch.AddMineralDrone(newDrone);
                }
            }
           
            return false;
        }

        public bool MoveOutDrone(int key, int fromHatchIndex, Type droneType, Type building)
        {
            var fromHatch = _hatcheries[fromHatchIndex];
            if (typeof (MineralDrone) == droneType)
            {
                var drone = fromHatch.RemoveMineralDrone(GetActualTime());
                _units.Remove(drone);

            }
            else if (droneType == typeof (GasDrone))
            {
                var drone = fromHatch.RemoveGasDrone(GetActualTime());
                _units.Remove(drone);
            }
            MovingDrone newDrone;
            if (building == typeof (Hatchery))
            {
                newDrone = new MovingDrone(GetActualTime(), ZergSettings.TimeBetweenHatcheries);
            }
            else
            {
                newDrone = new MovingDrone(GetActualTime(), ZergSettings.TimeToMoveToBuildingSpot);
            }
            InProductions.Add(key, newDrone);
            _units.Add(newDrone);
            Console.WriteLine("Time: " + (GetActualTime()).ToMinuteString() + ", moving out drone");
            return true;
        }

        public bool TryBuildBasicArmyUnit<T>(int key, UnitValues unitValues) where T : Unit
        {
            var currentCounter = _counters.Last();
            var time = GetActualTime();
            var hatchWithLarva = _hatcheries.FirstOrDefault(x => x.HasLarvas());
            var neededBuilding =
                _buildings.FirstOrDefault(x => x.IsFinished(time) && x.GetType() == unitValues.BuildingType);
            if (currentCounter.Minerals >= unitValues.Cost.Minerals 
                && currentCounter.Gas >= unitValues.Cost.Gas 
                && currentCounter.Supply + unitValues.Supply <= currentCounter.SupplyLimit 
                && hatchWithLarva != null
                && neededBuilding != null)
            {
                currentCounter.Supply += unitValues.Supply;
                currentCounter.Minerals -= unitValues.Cost.Minerals;
                currentCounter.Gas -= unitValues.Cost.Gas;
                hatchWithLarva.ConsumeLarva();
                if (typeof (T) == typeof (Zergling))
                {
                    var extraUnit = (T)Activator.CreateInstance(typeof(T), time);
                    _units.Add(extraUnit);
                }
                var unit = (T)Activator.CreateInstance(typeof(T), time);
                _units.Add(unit);
                InProductions.Add(key, unit);
                Console.WriteLine("Time: " + (time).ToMinuteString() + ", "+ unitValues.Name +" started");
                return true;
            }
            return false;
        }

        public bool TryBuildAdvancedArmyUnit<T>(int key, UnitValues unitValues) where T : Unit
        {
            
            var currentCounter = _counters.Last();
            var time = GetActualTime();
            var builtFromUnit = _units.FirstOrDefault(x => x.IsFinished(time) && x.GetType() == unitValues.BuiltFromUnit);
            var isDependBuildingFinsihed =
                _buildings.Any(x => x.IsFinished(time) && x.GetType() == unitValues.BuildingType);
            if (currentCounter.Minerals >= unitValues.Cost.Minerals
                && currentCounter.Gas >= unitValues.Cost.Gas
                && currentCounter.Supply + unitValues.ExtraSupply <= currentCounter.SupplyLimit
                && builtFromUnit != null
                && isDependBuildingFinsihed)
            {
                currentCounter.Supply += unitValues.ExtraSupply;
                currentCounter.Minerals -= unitValues.Cost.Minerals;
                currentCounter.Gas -= unitValues.Cost.Gas;
                _units.Remove(builtFromUnit);
                var newUnit = (T)Activator.CreateInstance(typeof(T), time);
                _units.Add(newUnit);
                InProductions.Add(key, newUnit);
                Console.WriteLine("Time: " + (time).ToMinuteString() + ", " + unitValues.Name + " started");
                return true;
            }


            return false;
        }

        public double GetActualTime()
        {
            return Math.Round((Counters.Count - 1) * CoreSettings.TimeStep, 3);
        }

        public void PrintHatcheriesSaturation()
        {
            for (int i = 0; i < _hatcheries.Count; i++)
            {
                Console.WriteLine("Hatchery " + i + ", " + _hatcheries[i].NoOfMineralDrones(GetActualTime()) + " on minerals, " + _hatcheries[i].NoOfGasDrones() + " on gas."  );
            }
        }

    }
}
