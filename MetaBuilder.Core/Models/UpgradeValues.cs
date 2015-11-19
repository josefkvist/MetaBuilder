using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaBuilder.Core.Enum;

namespace MetaBuilder.Core.Models
{
    public class UpgradeValues
    {
        public UpgradeValues(string name, double buildTime, int mineralCost, int gasCost, Type buildngType)
        {
            Name = name;
            BuildTime = buildTime;
            MineralCost = mineralCost;
            GasCost = gasCost;
            BuildingType = buildngType;
        }

        public string Name { get; set; }
        public double BuildTime { get; set; }
        public int MineralCost { get; set; }
        public int GasCost { get; set; }
        public bool IsStarted { get; set; }
        public Type BuildingType { get; set; }
    }
}
