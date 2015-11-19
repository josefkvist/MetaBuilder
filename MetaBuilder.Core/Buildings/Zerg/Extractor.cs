using System.Collections.Generic;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Worker;

namespace MetaBuilder.Core.Buildings.Zerg
{
    public class Extractor : Building
    {

        public List<GasDrone> GasDrones { get; set; }
        public int GasPerDrone { get; private set; }
        public int HatchIndex { get; set; }

        public Extractor(double createdAt) 
            : base(createdAt, BuildingSettings.Extractor.BuildTime, BuildingSettings.Extractor.Name)
        {
            GasPerDrone = 4;
            GasDrones = new List<GasDrone>();
        }

       
    }
}