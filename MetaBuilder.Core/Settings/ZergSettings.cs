using MetaBuilder.Core.Buildings.Zerg;
using MetaBuilder.Core.Models;
using MetaBuilder.Core.Units.Zerg;

namespace MetaBuilder.Core.Settings
{
    public static class ZergSettings
    {
        public static double TimeBetweenHatcheries = 10;
        public static double TimeToMoveToBuildingSpot = 2;
    }

    public class ZergBuildingSettings
    {
        public static BuildingValues Hatchery = new BuildingValues(300, 0, 71, "Hatchery");
        public static BuildingValues SpawningPool = new BuildingValues(200, 0, 46, "Spawning pool");
        public static BuildingValues BaneNest = new BuildingValues(100, 50, 39, "BanelingNest");
        public static BuildingValues Extractor = new BuildingValues(25, 0, 21, "Extractor");
        public static BuildingValues EvolutionChamber = new BuildingValues(75, 0, 26, "Evolution chamber");
        public static BuildingValues RoachWaren = new BuildingValues(150, 0, 39, "Roach waren");
    }

    public class ZergUnitSettings
    {
        //                                  Supply, minerals, gas, time, name, buildingneeded
        public static UnitValues Drone = new UnitValues(1, 50, 0, 14, "Drone", typeof(Hatchery));
        public static UnitValues Overlord = new UnitValues(0, 100, 0, 18, "Overlord", typeof(Hatchery));
        public static UnitValues Queen = new UnitValues(2, 150, 0, 36, "Queen", typeof(Hatchery));
        public static UnitValues Ling = new UnitValues(0.5, 50, 0, 17, "Zergling", typeof(SpawningPool));
        public static UnitValues Roach = new UnitValues(2, 75, 25, 19, "Roach", typeof(RoachWaren));
        public static UnitValues Bane = new UnitValues(0.5, 15, 25, 14, "Baneling", typeof(BaneNest), typeof(Zergling));
        public static UnitValues Raveger = new UnitValues(3, 25, 75, 9, "Raveger", typeof(RoachWaren), typeof(Roach),1);
    }

    public class ZergUpgradeSettings
    {
        public static UpgradeValues LingSpeed = new UpgradeValues("Ling Speed", 79, 100, 100, typeof (SpawningPool));
        public static UpgradeValues Melee1 = new UpgradeValues("Melee 1", 114, 100, 100, typeof (EvolutionChamber));
        public static UpgradeValues Range1 = new UpgradeValues("Range 1", 114, 100, 100, typeof (EvolutionChamber));
    }

}
