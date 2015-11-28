using System.Collections.Generic;
using BuildOrder.Interface;
using BuildOrder.Order.Buildings;
using BuildOrder.Order.Units;
using BuildOrder.Order.Upgrades;

namespace BuildOrder
{
    public static class Openers
    {


        public static List<IOrder> DroneOpener()
        {
            return new List<IOrder>()
            {
                new MineralDroneOrder(),
                new OverlordOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new HatcheryOrder(250),
                new MineralDroneOrder(),
                new ExtractorOrder(),
                new MineralDroneOrder(),
                new OverlordOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new OverlordOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new ExtractorOrder(),
                new MineralDroneOrder(),
            };
        } 

        public static List<IOrder> BasicOpener()
        {
            return new List<IOrder>()
            {
                new MineralDroneOrder(),
                new OverlordOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new HatcheryOrder(250),
                new MineralDroneOrder(),
                new ExtractorOrder(),
                new MineralDroneOrder(),
                new SpawningPoolOrder(190),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new OverlordOrder(),
                new LingSpeedOrder(),
                new QueenOrder(),
                new QueenOrder(),
                new ZerglingOrder(),

            };
        }
        public static List<IOrder> ZvZOpener()
        {
            return new List<IOrder>()
            {
                new MineralDroneOrder(),
                new OverlordOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new HatcheryOrder(250),
                new MineralDroneOrder(),
                new SpawningPoolOrder(190),
                new ExtractorOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new QueenOrder(),
                new BaneNestOrder(90, 50),
                new MineralDroneOrder(),
                new OverlordOrder(),
                new OverlordOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new ZerglingOrder(),
                new BanelingOrder(),
                new MineralDroneOrder(),
                new LingSpeedOrder(),

            };
        }

        public static List<IOrder> ZvZSpeedpoolOpener()
        {
            return new List<IOrder>()
            {
                new ExtractorOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new SpawningPoolOrder(190),
                new MineralDroneOrder(),
                new OverlordOrder(),
                new LingSpeedOrder(),
                new ZerglingOrder(),
                new ZerglingOrder(),
                new ZerglingOrder(),
            };
        }

        public static List<IOrder> ZvZSafeRoachOpener()
        {
            return new List<IOrder>()
            {
                new MineralDroneOrder(),
                new OverlordOrder(),
                new MineralDroneOrder(),

                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new HatcheryOrder(160),
                new MineralDroneOrder(),
                new SpawningPoolOrder(190),
                new ExtractorOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new OverlordOrder(),
                new QueenOrder(),
                new ZerglingOrder(),
                new BaneNestOrder(90, 50),
                new QueenOrder(),
                new ZerglingOrder(),
                new ZerglingOrder(),
                new ZerglingOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new BanelingOrder(),
                new BanelingOrder(),
                new BanelingOrder(),
                new MineralDroneOrder(),
                new OverlordOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new EvoChamberOrder(60),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new ExtractorOrder(),
                new ExtractorOrder(),
                new RoachWarenOrder(140),
                new OverlordOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new Range1Order(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new OverlordOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new OverlordOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new RavegerOrder(),
                new RavegerOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new OverlordOrder(),
                new RavegerOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new OverlordOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new RoachOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
                new MineralDroneOrder(),
            };
        }
    }
}