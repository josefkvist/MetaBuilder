using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaBuilder.Core.Models
{
    public struct UnitValues
    {
        public UnitValues(int supply, int minerals, int gas, double buildTime, string name, Type buildingType)
            : this()
        {
            Supply = supply;
            BuildTime = buildTime;
            Cost = new Cost(minerals, gas);
            Name = name;
            BuildingType = buildingType;
        }
        public int Supply { get; set; }
        public double BuildTime { get; set; }
        public Cost Cost { get; set; }
        public string Name { get; set; }
        public Type BuildingType { get; set; }
    }
}
