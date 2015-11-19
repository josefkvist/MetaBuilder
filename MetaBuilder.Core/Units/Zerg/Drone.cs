using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaBuilder.Core.Interfaces;
using MetaBuilder.Core.Models;

namespace MetaBuilder.Core.Units.Zerg
{
    public abstract class Drone : Unit
    {
        protected Drone(double created) 
            : base(created, UnitSettings.Drone.BuildTime, UnitSettings.Drone.Supply, UnitSettings.Drone.Name)
        {
            
        }
    }
}
