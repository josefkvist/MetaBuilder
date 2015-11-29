using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Models;
using MetaBuilder.Core.Settings;

namespace MetaBuilder.Core.Units.Zerg
{
    public abstract class Drone : Unit
    {
        protected Drone(double created) 
            : base(created, ZergUnitSettings.Drone.BuildTime, ZergUnitSettings.Drone.Supply, ZergUnitSettings.Drone.Name)
        {
            
        }
    }
}
