using System.Collections.Generic;
using System.Linq;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Settings;
using MetaBuilder.Core.Worker;

namespace MetaBuilder.Core.Buildings.Zerg
{
    public class Extractor : Building
    {

        public List<GasDrone> GasDrones { get; set; }
        public int GasPerDrone { get; private set; }
        public int HatchIndex { get; set; }

        public Extractor(double createdAt) 
            : base(createdAt, ZergBuildingSettings.Extractor.BuildTime, ZergBuildingSettings.Extractor.Name)
        {
            GasPerDrone = 4;
            GasDrones = new List<GasDrone>();
        }


        public void AddGasDrone(GasDrone gasDrone, double time)
        {
            if (GasDrones.Any())
            {
                var timePerTurn = gasDrone.TimePerTurn(GasDrones.Count + 1);
                var distanceBetweenDrones = timePerTurn/(GasDrones.Count + 1);

                gasDrone.StartedAt = GasDrones.Last().StartedAt + distanceBetweenDrones;
            }
            GasDrones.Add(gasDrone);
        }
    }
}