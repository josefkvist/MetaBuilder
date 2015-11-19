using System.Collections.Generic;
using System.Linq;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Models;

namespace MetaBuilder.Core.Buildings.Zerg
{
    public class EvolutionChamber : Building
    {
      

        public EvolutionChamber(double createdAt)
            : base(createdAt, BuildingSettings.EvolutionChamber.BuildTime, BuildingSettings.EvolutionChamber.Name)
        {
        }

      
    }
}