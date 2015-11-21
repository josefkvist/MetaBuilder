using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MetaBuilder.Core.Models
{
    public struct UnitValues
    {
        public UnitValues(double supply, int minerals, int gas, double buildTime, string name, Type buildingType, Type builtFromUnit = null, double extraSupply = 0.0)
            : this()
        {
            Supply = supply;
            BuildTime = buildTime;
            Cost = new Cost(minerals, gas);
            Name = name;
            BuildingType = buildingType;
            BuiltFromUnit = builtFromUnit;
            ExtraSupply = extraSupply;

        }

        public double Supply { get; set; }
        public double BuildTime { get; set; }
        public Cost Cost { get; set; }
        public string Name { get; set; }
        public Type BuildingType { get; set; }
        public Type BuiltFromUnit { get; set; }
        public double ExtraSupply { get; set; }
    }
}
