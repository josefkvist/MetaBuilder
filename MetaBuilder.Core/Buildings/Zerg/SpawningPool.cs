using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Models;

namespace MetaBuilder.Core.Buildings.Zerg
{
    public class SpawningPool : Building
    {
      
        public SpawningPool(double createdAt)
            : base(createdAt, BuildingSettings.SpawningPool.BuildTime, BuildingSettings.SpawningPool.Name)
        {
        }


    }
}
