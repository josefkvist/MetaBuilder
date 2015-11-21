using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaBuilder.Core.Buildings.Zerg;
using MetaBuilder.Core.Models;
using MetaBuilder.Core.Units.Zerg;

namespace MetaBuilder.Core
{
    public static class Settings
    {
        public static double TimeStep = 0.1;
        public static double TimeBetweenHatcheries = 10;
        public static double TimeToMoveToBuildingSpot = 2;
    }

    public class BuildingSettings
    {
        public static BuildingValues Hatchery = new BuildingValues(300, 0, 71, "Hatchery");
        public static BuildingValues SpawningPool = new BuildingValues(200, 0, 45, "Spawning pool");
        public static BuildingValues BaneNest = new BuildingValues(100, 50, 39, "BanelingNest");
        public static BuildingValues Extractor = new BuildingValues(25, 0, 21, "Extractor");
        public static BuildingValues EvolutionChamber = new BuildingValues(75, 0, 26, "Evolution chamber");
        public static BuildingValues RoachWaren = new BuildingValues(150, 0, 39, "Roach waren");
    }

    public class UnitSettings
    {
        //                                  Supply, minerals, gas, time, name, buildingneeded
        public static UnitValues Drone = new UnitValues(1, 50, 0, 13, "Drone", typeof(Hatchery));
        public static UnitValues Overlord = new UnitValues(0, 100, 0, 18, "Overlord", typeof(Hatchery));
        public static UnitValues Queen = new UnitValues(2, 150, 0, 36, "Queen", typeof(Hatchery));
        public static UnitValues Ling = new UnitValues(0.5, 50, 0, 17, "Zergling", typeof(SpawningPool));
        public static UnitValues Roach = new UnitValues(2, 75, 25, 20, "Roach", typeof(RoachWaren));
        public static UnitValues Bane = new UnitValues(0.5, 15, 25, 20, "Baneling", typeof(BaneNest), typeof(Zergling));
    }

    public class UpgradeSettings
    {
        public static UpgradeValues LingSpeed = new UpgradeValues("Ling Speed", 79, 100, 100, typeof (SpawningPool));
        public static UpgradeValues Melee1 = new UpgradeValues("Melee 1", 115, 100, 100, typeof (EvolutionChamber));
        public static UpgradeValues Range1 = new UpgradeValues("Range 1", 115, 100, 100, typeof (EvolutionChamber));
    }

}
