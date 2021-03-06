﻿using System.Collections.Generic;
using System.Linq;
using BuildOrder;
using BuildOrder.Interface;
using MetaBuilder.Core;
using MetaBuilder.Core.Bases;
using MetaBuilder.Core.Buildings.Zerg;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Worker;
using MetaBuilder.Core.Worker.Zerg;

namespace MetBuilder.Console
{
    public class Program
    {
        /*****************************************************
         *  *** Backlog ***
         * Queens make and larva inject - check
         * Upgrades - done
         * Roach - done
         * Den - done
         * Lings - done
         * Roaches - done
         * queen energy - done
         * bane nest - done
         * rally drones to natural - done
         * Banes -done

         * * Tune in
         * Queen not fixed on base
         * queen walk between hatches
         * Lair
         * extractortrick
         * ravager
         * ***************************************************/

        private static int _currentKey = 0;

        static void Main(string[] args)
        {

            var runProgram = true;
            while (runProgram)
            {
                RunProgram();

                var input = System.Console.ReadLine();
                if (input == "exit")
                {
                    runProgram = false;
                }
                else
                {
                    RunProgram();
                }
            }

        }

        private static void RunProgram()
        {
            var totalSimulationTime = 380.0;
            var outputTimeStep = 2.0;
            var timeStep = CoreSettings.TimeStep;
            var zerg = new ZergBase(timeStep);
            System.Console.WriteLine("Time: " + (0.0).ToMinuteString() + ", Minerals: " +
                                            zerg.Counters.First().Minerals
                                            + ", Gas: " + zerg.Counters.First().Gas
                                            + ", Supply: " + zerg.Counters.First().Supply
                                            + "/" + zerg.Counters.First().SupplyLimit
                                            + ", Larvas: " + zerg.Counters.First().Larvas);
            var buildOrders = new List<IOrder>();
            buildOrders.AddRange(Openers.ZvZSafeRoachOpener());
            var indexMax = (int)(totalSimulationTime / CoreSettings.TimeStep);
            for (int i = 1; i < indexMax; i++)
            {
                zerg.StepForward();
                var counter = zerg.Counters.Last();
                var actualTime = i * timeStep;
                if (actualTime.ToMilliSeconds() % outputTimeStep.ToMilliSeconds() < timeStep.ToMilliSeconds())
                {
                    System.Console.WriteLine("Time: " + (actualTime).ToMinuteString() + ", Minerals: " +
                                             counter.Minerals
                                             + ", Gas: " + counter.Gas
                                             + ", Supply: " + counter.Supply
                                             + "/" + counter.SupplyLimit
                                             + ", Larvas: " + counter.Larvas);
                }

                var extractor = zerg.InProductions.FirstOrDefault(x => x.Value.Name == ZergBuildingSettings.Extractor.Name);

                if (extractor.Value != null && extractor.Value.PromilleDone(actualTime) == (int)Percentage.P100)
                {
                    var extractorObj = (Extractor) extractor.Value;
                    var hatchIndex = extractorObj.HatchIndex;
                    zerg.TryChangeDronesWork(hatchIndex, hatchIndex, typeof(MineralDrone), typeof(GasDrone), 0);
                    zerg.TryChangeDronesWork(hatchIndex, hatchIndex, typeof(MineralDrone), typeof(GasDrone), 0);
                    zerg.TryChangeDronesWork(hatchIndex, hatchIndex, typeof(MineralDrone), typeof(GasDrone), 0);
                }

                var buildOrder = buildOrders.FirstOrDefault(x => !x.IsDone);

                if (buildOrder != null)
                {
                    buildOrder.IsDone = buildOrder.TryDoOrder(ref zerg);
                }
            }
        }

    }
}
