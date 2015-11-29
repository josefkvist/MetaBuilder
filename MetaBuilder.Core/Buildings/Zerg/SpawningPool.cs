using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaBuilder.Core.Enum;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Models;
using MetaBuilder.Core.Settings;

namespace MetaBuilder.Core.Buildings.Zerg
{
    public class SpawningPool : Building
    {
      
        public SpawningPool(double createdAt)
            : base(createdAt, ZergBuildingSettings.SpawningPool.BuildTime, ZergBuildingSettings.SpawningPool.Name)
        {
        }


    }
}
