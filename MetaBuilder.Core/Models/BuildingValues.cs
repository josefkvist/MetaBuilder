using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaBuilder.Core.Models
{
    public struct BuildingValues
    {
        public BuildingValues(int minerals, int gas, double buildTime, string name)
            : this()
        {
            BuildTime = buildTime;
            Cost = new Cost(minerals, gas);
            Name = name;
        }
        public Cost Cost { get; set; }
        public double BuildTime { get; set; }
        public string Name { get; set; }
    }
}
